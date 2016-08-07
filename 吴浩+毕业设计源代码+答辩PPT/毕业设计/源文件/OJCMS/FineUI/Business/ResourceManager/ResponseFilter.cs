using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Web;
using System.Web.UI;
using HtmlAgilityPack;
using System.Text.RegularExpressions;


namespace FineUI
{
    /// <summary>
    /// AJAX输出过滤器
    /// </summary>
    internal class ResponseFilter : Stream
    {
        #region fields

        private Stream _responseStream;
        private MemoryStream _memoryStream;

        #endregion

        #region Constructor

        internal ResponseFilter(Stream responseStream)
        {
            _responseStream = responseStream;
            _memoryStream = new MemoryStream();
        }

        #endregion

        #region overrides

        public override bool CanRead
        {
            get { return false; }
        }

        public override bool CanSeek
        {
            get { return false; }
        }

        public override bool CanWrite
        {
            get { return true; }
        }

        public override void Flush()
        {
            _memoryStream.Flush();
        }

        public override long Length
        {
            get { return 0; }
        }

        public override long Position
        {
            get { return 0; }
            set { }
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            return 0;
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return 0;
        }

        public override void SetLength(long value)
        {
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            _memoryStream.Write(buffer, offset, count);
        }

        public override void Close()
        {
            StringBuilder sb = new StringBuilder();
            ResolveResponseScripts(sb);

            string responseText = sb.ToString();

            // 文件上传，此时应该对返回的数据进行编码，因为ExtJs会将返回的数据放在<pre></pre>中，不编码会导致HTML标签错乱
            if (HttpContext.Current.Request.ContentType.Contains("multipart/form-data"))
            {
                // HttpUtility.UrlEncode 在 Encode 的时候, 将空格转换成加号，而客户端的 encodeURIComponent 则是将空格转换为 %20
                responseText = HttpUtility.UrlEncode(responseText);
                responseText = responseText.Replace("+", "%20");
            }

            // 从输出流创建TextWriter
            TextWriter writer = new StreamWriter(_responseStream, Encoding.UTF8);

            writer.Write(responseText);

            // 输出
            writer.Flush();
            writer.Dispose();
            base.Close();
            _responseStream.Close();
        }



        #endregion

        #region ResolveResponseScripts

        private void ResolveResponseScripts(StringBuilder sb)
        {
            // 我们不需要把Response的代码放在自执行的函数中，因为在X.ajax.js中，通过new Function(scripts)();来执行Response的代码。
            // Wrapper all the JavaScript in a self-execution function to prevent pollution of global JavaScript namespace.
            //writer.Write("(function(){");

            #region 网页重定向

            // 重定向页面
            if (HttpContext.Current.Response.RedirectLocation != null)
            {
                sb.Append("window.location.replace('" + HttpContext.Current.Response.RedirectLocation + "');");
                return;
            }

            #endregion

            #region 生成的HTML代码

            // 生成的页面内容
            string completeHtml = GetCompleteHtml();

            HtmlDocument doc = new HtmlDocument();
            doc.OptionFixNestedTags = true;
            doc.LoadHtml(completeHtml);

            #endregion

            #region 监视ViewState的改变

            // 更新ViewState，如果本AJAX请求的ViewState和当前页面上的ViewState不一致，则丢弃本次更新
            UpdateViewState(sb, doc);


            #endregion
            #region 页面上每个控件应该输出的脚本

            //// 设置提交表单的按钮等元素可用enable（有可能在后面的被覆盖）
            //sb.Append(GetEnableTargetControlScript());

            // 添加所有需要在AJAX时更新的脚本
            StringBuilder ajaxScriptBuilder = new StringBuilder();
            foreach (string script in ResourceManager.Instance.AjaxScriptList)
            {
                ajaxScriptBuilder.Append(script);
            }
            foreach (string script in ResourceManager.Instance.AjaxAbsoluteScriptList)
            {
                ajaxScriptBuilder.Append(script);
            }

            /*
            StringBuilder gridTplsBuilder = new StringBuilder();
            StringBuilder shortNameBuilder = new StringBuilder();
            Dictionary<string, string> shortNameDic = ResourceManager.Instance.AjaxShortNameList;
            if (shortNameDic.Count > 0)
            {
                shortNameBuilder.Append("var ");
                int index = 0, count = shortNameDic.Count;
                foreach (string clientId in shortNameDic.Keys)
                {
                    string xid = shortNameDic[clientId];
                    string scriptId = String.Format("F('{0}')", clientId);
                    shortNameBuilder.AppendFormat("{0}={1}", xid, scriptId);
                    if (index == count - 1)
                    {
                        shortNameBuilder.Append(';');
                    }
                    else
                    {
                        shortNameBuilder.Append(',');
                    }

                    // 不能将所有的F('RegionPanel1_Button1')替换为x0，因为有时F('RegionPanel1_Button1')会出现在HTML片段中
                    //ajaxScriptBuilder.Replace(scriptId, xid);


                    /////////////////////////
                    // 重新加载表格数据（也就是存在对x_loadData函数的调用）
                    if (PageManager.Instance.AjaxGridReloadedClientIDs.Contains(clientId) && PageManager.Instance.AjaxGridClientIDs.Contains(clientId))
                    {
                        PageManager.Instance.AjaxGridClientIDs.Remove(clientId);

                        gridTplsBuilder.AppendFormat("{0}.f_tpls={1};", xid, GetGridTpls(doc, clientId));

                    }

                    index++;
                }
            }

            // 不需要重新加载表格数据，但是要更新模板列
            if (PageManager.Instance.AjaxGridClientIDs.Count != 0)
            {
                foreach (string clientId in PageManager.Instance.AjaxGridClientIDs)
                {
                    gridTplsBuilder.AppendFormat("F('{0}').f_updateTpls({1});", clientId, GetGridTpls(doc, clientId));
                }
            }
            */

            // 2. 短名称
            string shortNameScript = String.Empty;
            List<string> shortNameList = new List<string>();
            Dictionary<string, string> shortNameDic = ResourceManager.Instance.AjaxShortNameList;
            if (shortNameDic.Count > 0)
            {
                foreach (string clientId in shortNameDic.Keys)
                {
                    string xid = shortNameDic[clientId];
                    shortNameList.Add(String.Format("{0}=F('{1}')", xid, clientId));
                }
            }
            if (shortNameList.Count > 0)
            {
                shortNameScript = String.Format("var {0};", String.Join(",", shortNameList.ToArray()));
            }

            // 3. 表格相关
            StringBuilder gridTplsBuilder = new StringBuilder();

            // 重新加载表格数据（也就是存在对f_loadData函数的调用）
            if (PageManager.Instance.AjaxGridReloadedClientIDs.Count > 0)
            {
                foreach (string reloadGridClientID in PageManager.Instance.AjaxGridReloadedClientIDs)
                {
                    string xid = shortNameDic[reloadGridClientID];
                    gridTplsBuilder.AppendFormat("{0}.f_tpls={1};", xid, GetGridTpls(doc, reloadGridClientID));
                }
            }

            
            // 当前控件
            sb.Append(shortNameScript + gridTplsBuilder.ToString() + ajaxScriptBuilder.ToString());


            //// 执行 onReady 脚本
            //sb.Append(GetExecuteOnReadyScript());

            #endregion

            #region 监视输出HTML的改变

            // 更新执行的控件（一般是标准的ASP.NET控件）
            UpdateASPNETControls(sb, doc);

            //// 更新ViewState
            //UpdateViewState(sb, doc, false);

            //// 更新压缩后的ViewState
            //UpdateViewState(sb, doc, true);

            // 更新EventValidation（如果存在则更新）
            UpdateEventValidation(sb, doc);


            #endregion

            //writer.Write("})();");

            #region oldcode
            //List<ScriptBlock> sortedList = ResourceManager.Instance.GetSortedControlScriptList();
            //for (int i = 0, count = sortedList.Count; i < count; i++)
            //{
            //    //Control control = sortedList[i].Control as Control;
            //    string scriptContent = sortedList[i].Script;

            //    // 如果要注册脚本为空，则跳过
            //    if (String.IsNullOrEmpty(scriptContent))
            //    {
            //        continue;
            //    }

            //    // 换行符去掉
            //    scriptContent = scriptContent.Replace("\r\n", "");
            //    writer.Write(scriptContent);
            //} 
            #endregion
        }

        #region GetEnableTargetControlScript

        //// 执行用户自定义的 onReady 脚本
        //private static string GetExecuteOnReadyScript()
        //{
        //    StringBuilder sb = new StringBuilder();
        //    if (PageManager.Instance.ExecuteOnReadyWhenPostBack)
        //    {
        //        // 每次ajax调用后都要调用onReady脚本
        //        //sb.Append("if(typeof(onReady)=='function'){onReady();}");
        //        sb.Append("F.ready();");
        //    }

        //    //sb.Append("if(typeof(onAjaxReady)=='function'){onAjaxReady();}");
        //    //sb.Append("F.ajaxReady();");

        //    return sb.ToString();
        //}


        ///// <summary>
        ///// 设置引起本次回发的按钮（或其他控件）可用
        ///// </summary>
        ///// <returns></returns>
        //private static string GetEnableTargetControlScript()
        //{
        //    string targetControlClientID = HttpContext.Current.Request.Form[ResourceManager.DISABLED_CONTROL_BEFORE_POSTBACK];
        //    if (!String.IsNullOrEmpty(targetControlClientID))
        //    {
        //        return String.Format("F.f_enable('{0}');", targetControlClientID);
        //    }
        //    return String.Empty;
        //}

        #endregion

        #endregion

        #region GetGridTpls

        private string GetGridTpls(HtmlDocument doc, string controlId)
        {
            string html = String.Empty;
            string tpls = GetHtmlNodeInnerHTML(controlId + "_tpls", doc);
            if (!String.IsNullOrEmpty(tpls))
            {
                // 删除生成HTML中的 "\r\n     "
                html = Regex.Replace(tpls, "\r?\n\\s*", "");
            }

            return JsHelper.Enquote(html);
        }

        #endregion

        #region UpdateViewState & UpdateEventValidation

        /// <summary>
        /// 更新 EventValidation 节点的值
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="doc"></param>
        private void UpdateEventValidation(StringBuilder sb, HtmlDocument doc)
        {
            string oldEventValidation = HttpContext.Current.Request.Form["__EVENTVALIDATION"];
            //string newEventValidation = GetHtmlNodeValue("<input type=\"hidden\" name=\"__EVENTVALIDATION\" id=\"__EVENTVALIDATION\" value=\"", completeHtml);
            string newEventValidation = GetHtmlNodeValue("__EVENTVALIDATION", doc);

            if (!String.IsNullOrEmpty(newEventValidation) && (oldEventValidation != newEventValidation))
            {
                sb.Append(String.Format("F.f_eventValidation('{0}');", newEventValidation));
            }

        }

        /// <summary>
        /// 更新 ViewState 节点的值
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="doc"></param>
        private void UpdateViewState(StringBuilder sb, HtmlDocument doc)
        {
            string viewStateHiddenFieldID = StringUtil.VIEWSTATE_ID;
            //if (gzipped)
            //{
            //    viewStateHiddenFieldID = StringUtil.GZIPPED_VIEWSTATE_ID;
            //}

            string oldViewState = HttpContext.Current.Request.Form[viewStateHiddenFieldID];
            string newViewState = GetHtmlNodeValue(viewStateHiddenFieldID, doc);

            if (!String.IsNullOrEmpty(newViewState) && (oldViewState != newViewState))
            {
                int minLength = Math.Min(oldViewState.Length, newViewState.Length);
                int changeIndex = minLength;
                for (int i = 0, length = minLength; i < length; i++)
                {
                    if (newViewState[i] != oldViewState[i])
                    {
                        changeIndex = i;
                        break;
                    }
                }


                /*
                if (changeIndex == 0)
                {
                    sb.Append(String.Format("F.util.updateViewState('{0}',{1});", newViewState, gzipped.ToString().ToLower()));
                }
                else
                {
                    string changedStr = String.Empty;
                    if (newViewState.Length >= changeIndex)
                    {
                        changedStr = newViewState.Substring(changeIndex);
                    }

                    sb.Append(String.Format("F.util.updateViewState('{0}',{1},{2});", changedStr, changeIndex, gzipped.ToString().ToLower()));
                }
                */


                // 如果只有很少的一些字符没改变（小于等于150个字符），还是返回完整的ViewState
                if (changeIndex <= 150)
                {
                    sb.Append(String.Format("if(!F.f_viewState(__VIEWSTATE,'{0}'))return;", newViewState));
                }
                else
                {
                    string changedStr = String.Empty;
                    if (newViewState.Length >= changeIndex)
                    {
                        changedStr = newViewState.Substring(changeIndex);
                    }

                    sb.Append(String.Format("if(!F.f_viewState(__VIEWSTATE,'{0}',{1}))return;", changedStr, changeIndex));
                }
            }
            else
            {
                sb.Append("if(!F.f_viewState(__VIEWSTATE))return;");
            }
        }



        #endregion

        #region UpdateASPNETControls

        /// <summary>
        /// 更新ASP.NET控件
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="doc"></param>
        private void UpdateASPNETControls(StringBuilder sb, HtmlDocument doc)
        {
            if (PageManager.Instance.AjaxAspnetControls == null)
            {
                return;
            }
            foreach (string controlId in PageManager.Instance.AjaxAspnetControls)
            {
                string controlClientID = controlId;
                Control control = ControlUtil.FindControl(controlId);
                if (control != null)
                {
                    controlClientID = control.ClientID;
                }
                string updateHtml = GetHtmlNodeOuterHTML(controlClientID, doc);
                if (!String.IsNullOrEmpty(updateHtml))
                {
                    sb.Append(String.Format("F.util.replace('{0}',{1});", controlClientID, JsHelper.Enquote(updateHtml)));

                    /*
                    // 如果是Asp.net按钮或者ImageButton，需要重新注册点击时AJAX回发页面，而不是调用Button(type=submit)的默认行为
                    if (control != null && (control is System.Web.UI.WebControls.Button
                        || control is System.Web.UI.WebControls.ImageButton))
                    {
                        sb.Append(String.Format("F.util.makeAspnetSubmitButtonAjax('{0}');", control.ClientID));
                    }
                     * */
                }
            }

        }

        #endregion

        #region GetCompleteHtml & GetHtmlNodeValue & GetHtmlNodeOuterHTML

        ///// <summary>
        ///// 取得 HTML 中一个节点的值
        ///// </summary>
        ///// <param name="searchValue"></param>
        ///// <param name="completeHtml"></param>
        ///// <returns></returns>
        //public string GetHtmlNodeValue(string searchValue, string completeHtml)
        //{
        //    //string search = "<input type=\"hidden\" name=\"__VIEWSTATE\" id=\"__VIEWSTATE\" value=\"";
        //    int si = completeHtml.IndexOf(searchValue);
        //    if (si >= 0)
        //    {
        //        si += searchValue.Length;
        //        int ei = completeHtml.IndexOf('\"', si);
        //        if (ei >= 0)
        //        {
        //            return completeHtml.Substring(si, ei - si);
        //        }
        //    }

        //    return null;
        //}


        /// <summary>
        /// 取得 HTML 中一个节点的值
        /// </summary>
        /// <param name="nodeId"></param>
        /// <param name="doc"></param>
        /// <returns></returns>
        public string GetHtmlNodeValue(string nodeId, HtmlDocument doc)
        {
            HtmlNode node = doc.DocumentNode.SelectSingleNode("//*[@id='" + nodeId + "']");
            if (node != null)
            {
                return node.Attributes["value"].Value;
            }
            return null;
        }

        /// <summary>
        /// 取得 HTML 中一个节点的OuterHtml
        /// </summary>
        /// <param name="nodeId"></param>
        /// <param name="doc"></param>
        /// <returns></returns>
        public string GetHtmlNodeOuterHTML(string nodeId, HtmlDocument doc)
        {
            HtmlNode node = doc.DocumentNode.SelectSingleNode("//*[@id='" + nodeId + "']");
            if (node != null)
            {
                return node.OuterHtml;
            }
            return null;
        }

        public string GetHtmlNodeInnerHTML(string nodeId, HtmlDocument doc)
        {
            HtmlNode node = doc.DocumentNode.SelectSingleNode("//*[@id='" + nodeId + "']");
            if (node != null)
            {
                return node.InnerHtml;
            }
            return null;
        }

        /// <summary>
        /// 获取当前输出流的HTML内容
        /// </summary>
        /// <returns></returns>
        public string GetCompleteHtml()
        {
            string _completeHtml;

            _memoryStream.Position = 0;
            using (TextReader reader = new StreamReader(_memoryStream))
            {
                _completeHtml = reader.ReadToEnd();
            }

            return _completeHtml;
        }

        #endregion

    }
}
