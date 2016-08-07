
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    ResourceHelper.cs
 * CreatedOn:   2008-04-07
 * CreatedBy:   30372245@qq.com
 * 
 * 
 * Description：
 *      ->
 *   
 * History：
 *       
 * 
 * 
 * 
 * 
 */

#endregion

using System;
using System.Collections.Generic;
using System.Text;

using System.Web;
using System.Web.UI;
using System.Collections.Specialized;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;


namespace FineUI
{
    /// <summary>
    /// 资源帮助类
    /// </summary>
    public static class ResourceHelper
    {
        #region GetWebResourceUrl

        /// <summary>
        /// 获取嵌入资源的 res.axd 地址
        /// </summary>
        /// <param name="resName">资源名称</param>
        /// <returns>资源地址</returns>
        public static string GetWebResourceUrlResAxd(string resName)
        {
            Page page = HttpContext.Current.CurrentHandler as Page;
            if (page != null)
            {
                return GetWebResourceUrlResAxd(page, resName);
            }

            return String.Empty;
        }


        /// <summary>
        /// 获取嵌入资源的 res.axd 地址
        /// </summary>
        /// <param name="page">页面对象</param>
        /// <param name="resName">资源名称</param>
        /// <returns>资源地址</returns>
        public static string GetWebResourceUrlResAxd(Page page, string resName)
        {
            //return ResourceHelper.GetWebResourceUrl(page, resName);
            string typeName = "", typeValue = "";

            if (resName.StartsWith("FineUI.js."))
            {
                if (resName.StartsWith("FineUI.js.lang."))
                {
                    typeName = "lang";
                    typeValue = resName.Substring("FineUI.js.lang.".Length);
                }
                else
                {
                    typeName = "js";
                    typeValue = resName.Substring("FineUI.js.".Length);
                }
            }
            else if (resName.StartsWith("FineUI.res."))
            {
                if (resName.StartsWith("FineUI.res.css."))
                {
                    typeName = "css";
                    typeValue = resName.Substring("FineUI.res.css.".Length);
                }
                else if (resName.StartsWith("FineUI.res.img."))
                {
                    typeName = "img";
                    typeValue = resName.Substring("FineUI.res.img.".Length);
                }
                else if (resName.StartsWith("FineUI.res.theme."))
                {
                    typeName = "theme";
                    typeValue = resName.Substring("FineUI.res.theme.".Length);
                }
            }

            if (!String.IsNullOrEmpty(typeName))
            {
                return page.ResolveUrl(String.Format("~/res.axd?{0}={1}", typeName, typeValue));
            }
            return null;
        } 

        /// <summary>
        /// 获取嵌入资源的地址
        /// </summary>
        /// <param name="resourceName">资源名称</param>
        /// <returns>资源地址</returns>
        public static string GetWebResourceUrl(string resourceName)
        {
            Page page = HttpContext.Current.CurrentHandler as Page;
            if (page != null)
            {
                return GetWebResourceUrl(page, resourceName);
            }

            return String.Empty;
        }

        /// <summary>
        /// 获取嵌入资源的地址
        /// </summary>
        /// <param name="page">页面实例</param>
        /// <param name="resourceName">资源名称</param>
        /// <returns>资源地址</returns>
        public static string GetWebResourceUrl(Page page, string resourceName)
        {
            string resourceUrl = String.Empty;
            resourceUrl = page.ClientScript.GetWebResourceUrl(typeof(FineUI.ControlBase), resourceName);

            return resourceUrl;
        }

        ///// <summary>
        ///// 设计时嵌入资源url地址
        ///// </summary>
        ///// <param name="site"></param>
        ///// <param name="resourceName"></param>
        ///// <returns></returns>
        //public static string GetWebResourceUrl(ISite site, string resourceName)
        //{
        //    string resourceUrl = String.Empty;
        //    if (site != null)
        //    {
        //        IResourceUrlGenerator service = (IResourceUrlGenerator)site.GetService(typeof(IResourceUrlGenerator));
        //        if (service != null)
        //        {
        //            resourceUrl = service.GetResourceUrl(site.Component.GetType(), resourceName);
        //        }
        //    }

        //    //// 告诉HttpCompress，不要设置ETag，同时设置Expires为一年后的今天
        //    //resourceUrl += "&expires=1";

        //    return resourceUrl;
        //}
        #endregion

        #region GetResourceContent

        /// <summary>
        /// 取得资源的内容
        /// </summary>
        /// <param name="resourceName">资源名称</param>
        /// <returns>资源内容</returns>
        public static string GetResourceContent(string resourceName)
        {
            string result = String.Empty;
            using (StreamReader sr = new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName)))
            {
                result = sr.ReadToEnd();
            }

            return result;
        }


        /// <summary>
        /// 取得资源的二进制内容
        /// </summary>
        /// <param name="resourceName">资源名称</param>
        /// <returns>资源的二进制内容</returns>
        public static byte[] GetResourceContentAsBinary(string resourceName)
        {
            byte[] buf;
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
            {
                buf = new byte[stream.Length];
                stream.Read(buf, 0, buf.Length);
            }

            return buf;
        }

        
        //public static string ResolveResourceContent(Page page, string resourceContent)
        //{
        //    Regex regex = new Regex(@"<%=WebResource\("".*\.(gif|png)*""\)%>");
        //    MatchCollection matches = regex.Matches(resourceContent);
        //    foreach (Match match in matches)
        //    {
        //        string url = match.Value.Replace("<%=WebResource(\"", string.Empty).Replace("\")%>", string.Empty);
        //        resourceContent = resourceContent.Replace(match.Value, string.Format("{0}", GetWebResourceUrl(page, url)));
        //    }

        //    return resourceContent;
        //}

        #endregion

        #region GetEmptyImageUrl

        /// <summary>
        /// 获取空白图片的地址
        /// </summary>
        /// <returns>空白图片的地址</returns>
        public static string GetEmptyImageUrl()
        {
            return String.Format("{0}/res/s.gif", GlobalConfig.GetJSBasePath());
        } 

        #endregion
    }
}
