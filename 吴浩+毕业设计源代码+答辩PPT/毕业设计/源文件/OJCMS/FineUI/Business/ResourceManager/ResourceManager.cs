﻿
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    ResourceManager.cs
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
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Reflection;
using System.Collections;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace FineUI
{
    /// <summary>
    /// 存在 Page.Items 上下文中，向页面注册资源
    /// </summary>
    internal class ResourceManager
    {
        #region static fields

        public static readonly string RESOURCE_MANAGER_CONTEXT_NAME = "ResourceManagerContextName";

        //public static readonly string BLANK_IMAGE_RESOURCE_NAME = "FineUI.res.img.s.gif";
        //public static readonly string BLANK_IMAGE_TEMPLATE = "Ext.BLANK_IMAGE_URL='{0}';";
        //public static readonly string SCRIPT_ONREADY_TEMPLATE = "window.box=new (function(){this._onReady=function(){window.box_page_render_start_time=new Date();Ext.QuickTips.init();#CONTENT#};Ext.onReady(function(){this._onReady();},this);})();" + DEBUG_LINE_BREAK;
        //public static readonly string SCRIPT_ONREADY_TEMPLATE = "Ext.onReady(function(){window.boxPage_render_start_time=new Date();Ext.QuickTips.init();#CONTENT#});" + DEBUG_LINE_BREAK;
        //public static readonly string SCRIPT_ONREADY_TEMPLATE = "window.box=new (function(){this._onReady=function(){window.boxPage_render_start_time=new Date();Ext.QuickTips.init();#CONTENT#};this._onReady();})();" + DEBUG_LINE_BREAK;

        // Ext.onReady(function(){window.startOnReady2=new Date();});
        //public static readonly string WINDOW_DEFAULT_GROUP_ID = "F.window_default_group";
        //public static readonly string COOKIE_PROVIDER_ID = "F.cookie_provider";
        //public static readonly string HIDDEN_FIELDS_ID = "F.hiddenFields";


        public static readonly string PAGE_STATE_CHANGED_ID = "F_CHANGED";

        //// 在FineUI-Utility.js中被使用，不要修改
        //public static readonly string DISABLED_CONTROL_BEFORE_POSTBACK = "F_TARGET";



        //public static readonly string DISABLE_AJAX_CONTROL_ID = "__box_disable_ajax_control_id";

        //public static readonly string CREATE_EXT_OBJECT_PREFIX = "box_destroyObject(X.{0});";

        //public static readonly string PRELOAD_IMAGES_ID = "F.preload_images";

        #endregion

        #region fields

        private bool _isPageInitCompleted = false;

        public bool IsPageInitCompleted
        {
            get { return _isPageInitCompleted; }
            set { _isPageInitCompleted = value; }
        }



        private List<AbsoluteScriptBlock> _startupAbsoluteScriptBlockList = new List<AbsoluteScriptBlock>();
        public List<AbsoluteScriptBlock> StartupAbsoluteScriptBlockList
        {
            get { return _startupAbsoluteScriptBlockList; }
            set { _startupAbsoluteScriptBlockList = value; }
        }

        private List<ScriptBlock> _startupScriptBlockList = new List<ScriptBlock>();
        public List<ScriptBlock> StartupScriptBlockList
        {
            get { return _startupScriptBlockList; }
            set { _startupScriptBlockList = value; }
        }

        /// <summary>
        /// 需要向页面注册的样式列表
        /// </summary>
        private Dictionary<string, string> _startupCssDic = new Dictionary<string, string>();



        //private List<string> _javascriptComponentList = new List<string>();
        ///// <summary>
        ///// 页面需要的JavaScript组件列表
        ///// </summary>
        //public List<string> JavaScriptComponentList
        //{
        //    get { return _javascriptComponentList; }
        //    set { _javascriptComponentList = value; }
        //}



        private List<string> _ajaxScriptList = new List<string>();
        /// <summary>
        /// AJAX时每个控件需要注册的脚本
        /// </summary>
        public List<string> AjaxScriptList
        {
            get { return _ajaxScriptList; }
            set { _ajaxScriptList = value; }
        }


        private List<string> _ajaxAbsoluteScriptList = new List<string>();
        /// <summary>
        /// AJAX时不依赖控件的脚本
        /// </summary>
        public List<string> AjaxAbsoluteScriptList
        {
            get { return _ajaxAbsoluteScriptList; }
            set { _ajaxAbsoluteScriptList = value; }
        }


        private Dictionary<string, string> _ajaxShortNameList = new Dictionary<string, string>();
        /// <summary>
        /// AJAX时使用到的所有短名称列表
        /// 比如：F('SimpleForm1_tbxUserName')  -> cmp0
        /// F('SimpleForm1_tbxPassword') -> cmp1
        /// </summary>
        public Dictionary<string, string> AjaxShortNameList
        {
            get { return _ajaxShortNameList; }
            set { _ajaxShortNameList = value; }
        }

        public void AddAjaxShortName(string scriptid, string xid)
        {
            if (!_ajaxShortNameList.ContainsKey(scriptid))
            {
                _ajaxShortNameList.Add(scriptid, xid);
            }
        }


        #endregion

        #region Instance

        public ResourceManager()
            : this(HttpContext.Current.Handler as Page)
        {
        }

        public ResourceManager(Page page)
        {
            _page = page;
            _page.PreRenderComplete += new EventHandler(Page_PreRenderComplete);
            _page.InitComplete += Page_InitComplete;
        }

        private Page _page = null;
        public Page Page
        {
            get
            {
                return _page;
            }
        }


        /// <summary>
        /// 取得 ResourceManager 的实例，单件模式
        /// </summary>
        public static ResourceManager Instance
        {
            get
            {
                ResourceManager rm = HttpContext.Current.Items[ResourceManager.RESOURCE_MANAGER_CONTEXT_NAME] as ResourceManager;
                if (rm == null)
                {
                    rm = new ResourceManager();
                    HttpContext.Current.Items[ResourceManager.RESOURCE_MANAGER_CONTEXT_NAME] = rm;
                }

                return rm;
            }
        }

        /// <summary>
        /// 确保ResourceManager实例的Page和当前页面一致
        /// </summary>
        /// <param name="page"></param>
        internal static void EnsureResourceManagerInstance(Page page)
        {
            ResourceManager rm = ResourceManager.Instance;

            // 在 Server.Transfer 时会进入此分支
            if (rm.Page != page)
            {
                rm = new ResourceManager(page);
                HttpContext.Current.Items[ResourceManager.RESOURCE_MANAGER_CONTEXT_NAME] = rm;
            }
        }


        #endregion

        #region Page_PreRenderComplete

        protected void Page_InitComplete(object sender, EventArgs e)
        {
            IsPageInitCompleted = true;

            if (!IsFineUIAjaxPostBack)
            {
                // 页头注册公共CSS/Javascript
                CommonResourceHelper.RegisterCommonResource(Page);
            }

        }


        /// <summary>
        /// 准备呈现页面内容，在保存页面状态之前
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_PreRenderComplete(object sender, EventArgs e)
        {
            // 如果是 FineUI 的Ajax
            if (IsFineUIAjaxPostBack)
            {
                // The server response is parsed by the browser to create the document for the IFRAME. If the server is using JSON to send the return object, then the Content-Type header must be set to "text/html" in order to tell the browser to insert the text unchanged into the document body.
                HttpContext.Current.Trace.IsEnabled = false;
                HttpContext.Current.Response.ContentType = "text/html";
                //HttpContext.Current.Response.ContentEncoding = Encoding.UTF8;
                //HttpContext.Current.Response.Charset = "UTF-8";
                HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);

                FineUI.ResponseFilter filter = new FineUI.ResponseFilter(HttpContext.Current.Response.Filter);
                HttpContext.Current.Response.Filter = filter;
            }
            else
            {
                SetupFirstLoadResource();
            }
        }

        #endregion

        #region SetupFirstLoadResource

        /// <summary>
        /// 注册页面第一次加载时的样式和脚本
        /// </summary>
        private void SetupFirstLoadResource()
        {
            // 注册样式
            RegisterStartupCss();

            // 注册脚本
            RegisterStartupScript();
        }


        private void RegisterStartupCss()
        {
            if (_startupCssDic.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                foreach (string value in _startupCssDic.Values)
                {
                    sb.Append(value);
                }
                CommonResourceHelper.RegisterHeaderCSS(Page, sb.ToString());
            }

        }

        /// <summary>
        /// 注册页面脚本
        /// </summary>
        public void RegisterStartupScript()
        {
            #region oldcode - 不支持Asp.net AJAX

            //if (IsAspNetAjaxPostBack)
            //{
            //    #region 局部回发
            //    // 局部回发
            //    for (int i = 0, count = sortedList.Count; i < count; i++)
            //    {
            //        Control control = sortedList[i].Control as Control;
            //        string scriptContent = sortedList[i].Script;

            //        // 如果要注册脚本为空，则跳过
            //        if (String.IsNullOrEmpty(scriptContent))
            //        {
            //            continue;
            //        }

            //        // 换行符去掉
            //        scriptContent = scriptContent.Replace("\r\n", "");

            //        if (control != null)
            //        {
            //            // 如果脚本关联的有控件，则注册脚本（控件级别）
            //            string scriptKey = "partial_postback_script_" + control.ID;
            //            AjaxScriptManagerRegisterStartupScript(control, scriptKey, scriptContent);
            //        }
            //        else
            //        {
            //            // 如果脚本关联的没有控件，则注册脚本（页面级别）
            //            string scriptKey = "partial_postback_script_" + Math.Abs(scriptContent.GetHashCode()).ToString();
            //            AjaxScriptManagerRegisterStartupScript(Page, scriptKey, scriptContent);
            //        }
            //    }

            //    if (PageManager.Instance.ExecuteOnReadyWhenPostBack)
            //    {
            //        // 每次ajax调用后都要调用onReady脚本
            //        AjaxScriptManagerRegisterStartupScript(Page, "onReady", "if(typeof(onReady)=='function'){onReady();}");
            //    }
            //    #endregion
            //}
            //else
            //{
            //} 

            #endregion

            // 页面第一次加载 或者 页面回发
            List<ScriptBlock> sortedList = GetSortedControlScriptList();
            StringBuilder sb = new StringBuilder();
            foreach (ScriptBlock controlScript in sortedList)
            {
                if (controlScript.Script.Trim() != "")
                {
                    sb.AppendFormat("{0}", controlScript.Script);
                }
            }

            string scriptContent = GetStartupScript(sb.ToString());

            // 格式化输入 JavaScript 脚本
            if (GlobalConfig.GetDebugMode())
            {
                JSBeautifyLib.JSBeautify jsb = new JSBeautifyLib.JSBeautify(scriptContent,
                    new JSBeautifyLib.JSBeautifyOptions());

                scriptContent = jsb.GetResult();
            }

            Page.ClientScript.RegisterStartupScript(Page.GetType(), "page_startup_script", scriptContent, true);
        }

        #endregion

        #region GetStartupScript

        /// <summary>
        /// 是否注册startup脚本
        /// </summary>
        /// <param name="scriptKey"></param>
        /// <returns></returns>
        private bool IsStartupScriptRegistered(string scriptKey)
        {
            return Page.ClientScript.IsStartupScriptRegistered(scriptKey);
        }

        /// <summary>
        /// 取得页面初始化时脚本
        /// </summary>
        /// <param name="script"></param>
        /// <returns></returns>
        private string GetStartupScript(string script)
        {
            #region beforeBuilder

            StringBuilder beforeBuilder = new StringBuilder();

            //beforeBuilder.Append("F.init();");

            // ExtJS2.2的BUG，Ext.onReady会被调用两次（在ExtJS 2.2.1中已经修正）
            // Ext.onReady在extjsv3.1.0中依然有问题，在IE下有时会导致页面空白，不能继续执行，只有在点击Stop按钮或者重新刷新后才行。
            // http://www.extjs.net/forum/showthread.php?t=69437
            // http://www.extjs.com/forum/showthread.php?p=347524#post347524
            // https://extjs.net/forum/showthread.php?t=86948
            //beforeBuilder.Append("if(X.initialized){return;}X.initialized=true;");

            // 空白图片，只在 IE6 和 IE7 下设置（默认为 http://www.sencha.com/s.gif ），其他浏览器下使用 data URL
            //beforeBuilder.AppendFormat("if(Ext.isIE6||Ext.isIE7){{Ext.BLANK_IMAGE_URL='{0}';}}", ResourceHelper.GetWebResourceUrl("FineUI.res.img.s.gif"));

            //beforeBuilder.Append("F.util.init();");

            // form 相关配置
            //beforeBuilder.Append("var fieldPro=Ext.form.Base.prototype;");
            //beforeBuilder.AppendFormat("fieldPro.msgTarget='{0}';", MsgTargetHelper.GetName(PageManager.Instance.FormMessageTarget));
            //beforeBuilder.AppendFormat("fieldPro.labelWidth={0};", PageManager.Instance.FormLabelWidth.Value);
            //beforeBuilder.AppendFormat("fieldPro.labelSeparator='{0}';", PageManager.Instance.FormLabelSeparator);
            //beforeBuilder.AppendFormat("F.util.init('{0}',{1},'{2}','{3}',{4},'{5}',{6},'{7}',{8});",
            //    MessageTargetHelper.GetName(PageManager.Instance.FormMessageTarget),
            //    PageManager.Instance.FormLabelWidth.Value,
            //    PageManager.Instance.FormLabelSeparator,
            //    //PageManager.Instance.EnableBigFont.ToString().ToLower(),
            //    Page.ResolveUrl(ResourceHelper.GetEmptyImageUrl()), //String.Format("{0}/res/images/s.gif", GlobalConfig.GetExtjsBasePath())), //ResourceHelper.GetWebResourceUrlResAxd("FineUI.res.img.s.gif&v=1"),
            //    //PageManager.Instance.EnableAspnetSubmitButtonAjax.ToString().ToLower(),
            //    PageManager.Instance.EnableAjaxLoading.ToString().ToLower(),
            //    AjaxLoadingTypeName.GetName(PageManager.Instance.AjaxLoadingType),
            //    PageManager.Instance.EnableAjax.ToString().ToLower(),
            //    ThemeHelper.GetName(PageManager.Instance.Theme),
            //    PageManager.Instance.EnableFormChangeConfirm.ToString().ToLower()
            //    );


            //beforeBuilder.AppendFormat("F.util.init('{0}',{1},'{2}','{3}',{4},'{5}',{6},'{7}',{8});",
            //    MessageTargetHelper.GetName(PageManager.Instance.FormMessageTarget),
            //    PageManager.Instance.FormLabelWidth.Value,
            //    PageManager.Instance.FormLabelSeparator,
            //    //PageManager.Instance.EnableBigFont.ToString().ToLower(),
            //    Page.ResolveUrl(ResourceHelper.GetEmptyImageUrl()), //String.Format("{0}/res/images/s.gif", GlobalConfig.GetExtjsBasePath())), //ResourceHelper.GetWebResourceUrlResAxd("FineUI.res.img.s.gif&v=1"),
            //    //PageManager.Instance.EnableAspnetSubmitButtonAjax.ToString().ToLower(),
            //    PageManager.Instance.EnableAjaxLoading.ToString().ToLower(),
            //    AjaxLoadingTypeName.GetName(PageManager.Instance.AjaxLoadingType),
            //    PageManager.Instance.EnableAjax.ToString().ToLower(),
            //    ThemeHelper.GetName(PageManager.Instance.Theme),
            //    PageManager.Instance.EnableFormChangeConfirm.ToString().ToLower()
            //    );

            JsObjectBuilder initObj = new JsObjectBuilder();

            if (PageManager.Instance.FormMessageTarget != ConfigPropertyValue.FORM_MESSAGETARGET_DEFAULT)
            {
                initObj.AddProperty("msgTarget", MessageTargetHelper.GetName(PageManager.Instance.FormMessageTarget));
            }

            if (PageManager.Instance.FormLabelWidth != ConfigPropertyValue.FORM_LABELWIDTH_DEFAULT)
            {
                initObj.AddProperty("labelWidth", PageManager.Instance.FormLabelWidth.Value);
            }

            if (PageManager.Instance.FormLabelSeparator != ConfigPropertyValue.FORM_LABELSEPARATOR_DEFAULT)
            {
                initObj.AddProperty("labelSeparator", PageManager.Instance.FormLabelSeparator);
            }

            //initObj.AddProperty("blankImageUrl", Page.ResolveUrl(ResourceHelper.GetEmptyImageUrl()));

            if (PageManager.Instance.EnableAjaxLoading != ConfigPropertyValue.ENABLE_AJAX_LOADING_DEFAULT)
            {
                initObj.AddProperty("enableAjaxLoading", PageManager.Instance.EnableAjaxLoading.ToString().ToLower());
            }

            if (PageManager.Instance.AjaxLoadingType != ConfigPropertyValue.AJAX_LOADING_TYPE_DEFAULT)
            {
                initObj.AddProperty("ajaxLoadingType", AjaxLoadingTypeName.GetName(PageManager.Instance.AjaxLoadingType));
            }

            if (PageManager.Instance.EnableAjax != ConfigPropertyValue.ENABLE_AJAX_DEFAULT)
            {
                initObj.AddProperty("enableAjax", PageManager.Instance.EnableAjax.ToString().ToLower());
            }

            if (PageManager.Instance.Theme != Theme.Neptune)
            {
                initObj.AddProperty("theme", ThemeHelper.GetName(PageManager.Instance.Theme));
            }

            if (PageManager.Instance.Language != ConfigPropertyValue.LANGUAGE_DEFAULT)
            {
                initObj.AddProperty("language", LanguageHelper.GetName(PageManager.Instance.Language));
            }



            if (PageManager.Instance.EnableFormChangeConfirm)
            {
                initObj.AddProperty("formChangeConfirm", PageManager.Instance.EnableFormChangeConfirm.ToString().ToLower());
            }

            if (PageManager.Instance.AjaxTimeout != ConfigPropertyValue.AJAX_TIMEOUT_DEFAULT)
            {
                initObj.AddProperty("ajaxTimeout", PageManager.Instance.AjaxTimeout);
            }

            initObj.AddProperty("_version", GlobalConfig.ProductVersion);

            beforeBuilder.AppendFormat("F.init({0});", initObj);

            //if (PageManager.Instance.BeforeAjaxPostBackScript != String.Empty)
            //{
            //    beforeBuilder.AppendFormat("F.util.beforeAjaxPostBackScript=function(){{{0}}};", PageManager.Instance.BeforeAjaxPostBackScript);
            //}

            //beforeBuilder.Append("F.ajax.hookPostBack();");

            //if (PageManager.Instance.EnableAjax)
            //{
            //    if (PageManager.Instance.AjaxTimeout != ConfigPropertyValue.AJAX_TIMEOUT_DEFAULT)
            //    {
            //        beforeBuilder.AppendFormat("Ext.Ajax.timeout={0};", PageManager.Instance.AjaxTimeout * 1000);
            //    }
            //}

            //if (PageManager.Instance.EnableBigFont)
            //{
            //    beforeBuilder.Append("Ext.getBody().addCls('bigfont');");
            //}


            // WindowGroup
            //beforeBuilder.AppendFormat("{0}=new Ext.WindowGroup();{0}.zseed=6000;", WINDOW_DEFAULT_GROUP_ID);

            //// CookieProvider
            //beforeBuilder.AppendFormat("{0}=new Ext.state.CookieProvider();", COOKIE_PROVIDER_ID);

            //// HiddenFields
            //beforeBuilder.AppendFormat("{0}=[];", HIDDEN_FIELDS_ID);

            // 保存页面中可输入的表单字段状态是否发生变化的隐藏字段
            //innderBuilder.AppendFormat("var sn=document.createElement('input');sn.type='hidden';sn.value='false';sn.id=sn.name='{0}';Ext.getBody().query('form')[0].appendChild(sn);", PAGE_STATE_CHANGED_ID);
            //innderBuilder.AppendFormat("Ext.DomHelper.append(document.forms[0],{{tag:'input',type:'hidden',value:'false',id:'{0}',name:'{0}'}});", PAGE_STATE_CHANGED_ID);
            //beforeBuilder.AppendFormat("F.util.setHiddenFieldValue('{0}','false');", PAGE_STATE_CHANGED_ID);

            // 5.预加载图片
            //beforeBuilder.AppendFormat("{0}=[];", PRELOAD_IMAGES_ID);
            //beforeBuilder.AppendFormat("{0}.push('{1}');", PRELOAD_IMAGES_ID, ResourceHelper.GetWebResourceUrl(Page, "FineUI.res.img.default.form.error-tip-corners.gif"));
            //beforeBuilder.AppendFormat("box_preloadImages({0});", PRELOAD_IMAGES_ID);

            #endregion

            #region afterBuilder

            //StringBuilder afterBuilder = new StringBuilder();

            //afterBuilder.Append("\r\n");

            // 注册隐藏字段
            //string hiddenFieldScript = "var itemNode=Ext.get(item[0]);if(itemNode==null){Ext.DomHelper.append(document.forms[0],{tag:'input',type:'hidden',value:item[1],id:item[0],name:item[0]});}else{itemNode.dom.value=item[1];}";
            //afterBuilder.AppendFormat("Ext.each({0},function(item){{{1}}},box);", HIDDEN_FIELDS_ID, hiddenFieldScript);
            //afterBuilder.Append("box_alertDEBUG();");

            //afterBuilder.Append("if(typeof(onReady)==='function'){onReady.call(window);}");
            //afterBuilder.Append("F.util.triggerReady();");
            //// 如果是回发并且允许回发注册onReady脚本
            //if (!Page.IsPostBack || (Page.IsPostBack && PageManager.Instance.ExecuteOnReadyWhenPostBack))
            //{
            //    afterBuilder.Append("if(typeof(onReady)==='function'){onReady.call(window);}");
            //}
            //afterBuilder.Append("\r\n");

            //#if DEBUG
            //            afterBuilder.Append("window.f_render_end_time = new Date();");
            //#endif
            #endregion


            // 需要注册script
            //string contentScript = String.Format("EXTASPNET_READY=function(){{{0}}};", beforeBuilder.ToString() + script + afterBuilder.ToString());
            //contentScript += "Ext.onReady(EXTASPNET_READY);";//Ext.EventManager.on(window,'onload',function(){EXTASPNET_READY();});";//if(Ext.isIE){}else{Ext.onReady(EXTASPNET_READY);}";
            string contentScript = String.Format("F.load(function(){{{0}}});", beforeBuilder.ToString() + script);
            //#if DEBUG
            //            contentScript += "var x_end_time=new Date();";
            //#endif

            #region RELEASE模式下去除换行符

            if (!GlobalConfig.GetDebugMode())
            {
                contentScript = contentScript.Replace("\r\n", "");
            }

            #endregion

            string checkScript = "if(!F&&!Ext){if(confirm('ERROR: extjs folder is lost, download it now?')){window.location.href='http://fineui.com/bbs/forum.php?mod=viewthread&tid=3218';}}";

            return checkScript + contentScript;
        }



        /// <summary>
        /// 返回经过排序的 _startupControlScriptList 列表，子控件排在父控件的前面
        /// </summary>
        /// <returns></returns>
        internal List<ScriptBlock> GetSortedControlScriptList()
        {
            List<ScriptBlock> result = new List<ScriptBlock>();

            #region old code

            //if (!String.IsNullOrEmpty(_exclusiveScript))
            //{
            //    result.Add(new ScriptBlock(null, _exclusiveScript));

            //    return result;
            //}

            #endregion

            #region 1.插入AbsoluteScript(Level<0)

            // Level的正值和负值的分割点
            int levelZeroIndex = 0;

            // 插入所有 Control 为 null 的记录
            for (levelZeroIndex = 0; levelZeroIndex < _startupAbsoluteScriptBlockList.Count; levelZeroIndex++)
            {
                AbsoluteScriptBlock controlScript = _startupAbsoluteScriptBlockList[levelZeroIndex];

                if (controlScript.Level < 0)
                {
                    result.Add(new ScriptBlock(null, controlScript.Script));
                }
                else
                {
                    break;
                }
            }

            #endregion

            #region 2.排序，子控件排在父控件的前面

            for (int i = 0, count = _startupScriptBlockList.Count; i < count; i++)
            {
                ScriptBlock controlScript = _startupScriptBlockList[i];

                // Alert 静态类的 Control 为null
                if (controlScript.Control == null)
                {
                    // 如果 Control 为null，则不处理这条记录
                    continue;
                }

                int insertIndex = GetInsertIndex(controlScript.Control, result);

                #region old code
                //#if DEBUG
                //                // 在JS脚本前面增加 \t ，这样层次关系明显一点
                //                controlScript.Script = GetLineBreakString(insertIndex, result) + controlScript.Script;
                //#endif 
                #endregion

                result.Insert(insertIndex, controlScript);
            }

            #endregion

            #region 计算渲染时间

            //string timeScript ="F.endDateTime=new Date();";
            //string totalTime = "'FineUI渲染时间：'+X.endDateTime.getElapsed(X.startDateTime)+'ms'";
            //totalTime += "+'['+X.startPageLayoutDateTime.getElapsed(X.startDateTime)+','";
            //totalTime += "+X.endPageLayoutDateTime.getElapsed(X.startPageLayoutDateTime)+']'";
            //timeScript += String.Format("if(!X.startPageLayoutDateTime){{X.startPageLayoutDateTime=X.endPageLayoutDateTime=X.endDateTime;}}if(window.location.href.indexOf('DEBUG')>0){{alert({0});}}", totalTime);

            //result.Add(new ScriptBlock(null, "box_alertDEBUG();"));

            #endregion

            #region 4.插入AbsoluteScript(Level>0)

            // 插入所有 Control 为 null 的记录
            for (levelZeroIndex = 0; levelZeroIndex < _startupAbsoluteScriptBlockList.Count; levelZeroIndex++)
            {
                AbsoluteScriptBlock controlScript = _startupAbsoluteScriptBlockList[levelZeroIndex];

                if (controlScript.Level >= 0)
                {
                    //#if DEBUG
                    //                    controlScript.Script = "\r\n" + controlScript.Script;
                    //#endif

                    result.Add(new ScriptBlock(null, controlScript.Script));
                }
            }

            #endregion

            return result;
        }

        #region GetLineBreakString

        ///// <summary>
        ///// 取得要插入位置的 换行前缀
        ///// </summary>
        ///// <param name="insertIndex"></param>
        ///// <param name="list"></param>
        ///// <returns></returns>
        //private string GetLineBreakString(int insertIndex, List<ScriptBlock> list)
        //{
        //    if (insertIndex == list.Count)
        //    {
        //        return DEBUG_LINE_BREAK;
        //    }
        //    else
        //    {
        //        return "\r\n" + '\t' + GetStringPrefix(list[insertIndex].Script);
        //    }
        //}

        ///// <summary>
        ///// 取得字符串的换行前缀
        ///// </summary>
        ///// <param name="script"></param>
        ///// <returns></returns>
        //private string GetStringPrefix(string script)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    for (int i = 2, count = script.Length; i < count; i++)
        //    {
        //        if (script[i] == '\t')
        //        {
        //            sb.Append("\t");
        //        }
        //        else
        //        {
        //            break;
        //        }
        //    }

        //    return sb.ToString();
        //}

        #endregion

        #region GetInsertIndex

        /// <summary>
        /// 取得应该将Script插入的位置
        /// 要能够向上回溯，因为控件的父控件可能不存在列表中，而父控件的父控件存在列表中
        /// </summary>
        /// <param name="testControl"></param>
        /// <param name="checkList"></param>
        /// <returns></returns>
        private int GetInsertIndex(ControlBase testControl, List<ScriptBlock> checkList)
        {
            int returnIndex = checkList.Count;

            // 这个地方不能是ControlBase，比如用户控件中控件，要能向上回溯到UserControlConnector
            Control parentControl = testControl.Parent;
            while (parentControl != null)
            {
                for (int i = 0, count = checkList.Count; i < count; i++)
                {
                    Control checkControl = checkList[i].Control;

                    if (checkControl != null && parentControl == checkControl)
                    {
                        return i;
                    }
                }

                parentControl = parentControl.Parent;
            }

            if (testControl is Menu)
            {
                // 如果菜单控件没有上级，则默认将脚本放在最前面
                return 0;
            }
            else
            {
                return returnIndex;
            }
        }

        ///// <summary>
        ///// 测试testControl 是否 existControl的子控件
        ///// </summary>
        ///// <param name="testControl"></param>
        ///// <param name="existControl"></param>
        ///// <returns></returns>
        //private bool IsTestControlChildOf(Control testControl, Control existControl)
        //{
        //    bool result = false;

        //    Control parentControl = testControl.Parent;

        //    // 如果父控件不是HtmlForm
        //    while (!(parentControl is System.Web.UI.HtmlControls.HtmlForm))
        //    {

        //    }
        //}

        #endregion

        #endregion

        #region AddStartupCSS

        /// <summary>
        /// 添加样式
        /// </summary>
        /// <param name="key"></param>
        /// <param name="cssConent"></param>
        /// <returns></returns>
        public void AddStartupCSS(string key, string cssConent)
        {
            // 如果已经包含Key的样式已经存在，则覆盖
            if (_startupCssDic.ContainsKey(key))
            {
                _startupCssDic[key] = cssConent;
            }
            else
            {
                _startupCssDic.Add(key, cssConent);
            }

            //// 内容有相同的
            //foreach (string name in _startupCssDic.Keys)
            //{
            //    if (_startupCssDic[name] == cssConent)
            //    {
            //        return name;
            //    }
            //}
        }

        /// <summary>
        /// 删除已经添加的CSS样式
        /// </summary>
        /// <param name="key"></param>
        public void RemoveStartupCSS(string key)
        {
            if (_startupCssDic.ContainsKey(key))
            {
                _startupCssDic.Remove(key);
            }
        }

        #endregion

        #region AddAbsoluteStartupScript

        public void AddAbsoluteStartupScript(string script)
        {
            AddAbsoluteStartupScript(script, Constants.ABSOLUTE_STARTUP_SCRIPT_DEFAULT_LEVEL);
        }

        public void AddAbsoluteStartupScript(string script, int level)
        {
            AbsoluteScriptBlock scriptBlock = new AbsoluteScriptBlock(script, level);

            for (int i = 0; i < _startupAbsoluteScriptBlockList.Count; i++)
            {
                AbsoluteScriptBlock currentScript = _startupAbsoluteScriptBlockList[i];
                if (scriptBlock.Level < currentScript.Level)
                {
                    _startupAbsoluteScriptBlockList.Insert(i, scriptBlock);
                    return;
                }
            }

            _startupAbsoluteScriptBlockList.Add(scriptBlock);
        }

        #endregion

        #region AddStartupScript/IsStartupScriptExist

        public void AddStartupScript(ControlBase control, string script)
        {
            AddStartupScript(control, script, String.Empty);
        }

        /// <summary>
        /// 添加脚本
        /// 相同控件的脚本合并在一起（30372245@qq.com 2008-7-4）
        /// </summary>
        /// <param name="control"></param>
        /// <param name="script"></param>
        /// <param name="extraScript"></param>
        public void AddStartupScript(ControlBase control, string script, string extraScript)
        {
            ScriptBlock cs = new ScriptBlock(control, script);

            ScriptBlock existBlock = GetStartupScript(control);
            if (existBlock == null)
            {
                _startupScriptBlockList.Add(cs);
            }
            else
            {
                existBlock.Script += script;
                //existBlock.ExtraScript += extraScript;
            }
        }


        /// <summary>
        /// 控件control的注册脚本是否存在
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        public bool IsStartupScriptExist(ControlBase control)
        {
            foreach (ScriptBlock cs in _startupScriptBlockList)
            {
                if (cs.Control == control)
                {
                    return true;
                }
            }

            return false;
        }


        public ScriptBlock GetStartupScript(ControlBase control)
        {
            foreach (ScriptBlock cs in _startupScriptBlockList)
            {
                if (cs.Control == control)
                {
                    return cs;
                }
            }

            return null;
        }


        public void RemoveStartupScript(ControlBase control)
        {
            for (int i = 0; i < _startupScriptBlockList.Count; i++)
            {
                if (_startupScriptBlockList[i].Control == control)
                {
                    _startupScriptBlockList.RemoveAt(i);
                    break;
                }
            }
        }

        #endregion

        #region PostBackStates

        private JObject _requestState = null;

        public JObject PostBackStates
        {
            get
            {
                if (_requestState == null && Page.IsPostBack)
                {
                    //string state = HttpUtility.UrlDecode(HttpContext.Current.Request.Form["F_STATE"]);
                    string state = HttpContext.Current.Request.Form["F_STATE"];
                    string xstateURI = HttpContext.Current.Request.Form["F_STATE_URI"];
                    if (!String.IsNullOrEmpty(state))
                    {
                        if (String.IsNullOrEmpty(xstateURI))
                        {
                            state = DecodeFrom64(state);
                        }
                        else
                        {
                            state = HttpUtility.UrlDecode(state);
                        }
                    }

                    if (String.IsNullOrEmpty(state))
                    {
                        state = "{}";
                    }
                    _requestState = JObject.Parse(state);
                }
                return _requestState;
            }
        }

        private string DecodeFrom64(string encodedData)
        {
            byte[] encodedDataAsBytes = System.Convert.FromBase64String(encodedData);
            return System.Text.UTF8Encoding.UTF8.GetString(encodedDataAsBytes);
        }

        private string EncodeTo64(string toEncode)
        {
            byte[] toEncodeAsBytes = System.Text.UTF8Encoding.UTF8.GetBytes(toEncode);
            return System.Convert.ToBase64String(toEncodeAsBytes);
        }

        #endregion

        #region IsFineUIAjaxPostBack

        public bool IsFineUIAjaxPostBack
        {
            get
            {
                return HttpContext.Current.Request.Form["F_AJAX"] == "true";
            }
        }

        #endregion

        #region oldcode - we don't support Asp.Net Ajax

        ///// <summary>
        ///// 注册脚本 - 控件级别
        ///// </summary>
        ///// <param name="control"></param>
        ///// <param name="scriptKey"></param>
        ///// <param name="scriptContent"></param>
        //public void AjaxScriptManagerRegisterStartupScript(Control control, string scriptKey, string scriptContent)
        //{
        //    object scriptManagerInstance = GetAjaxScriptManagerInstance();

        //    if (scriptManagerInstance != null)
        //    {
        //        Type[] types = new Type[] { typeof(Control), typeof(Type), typeof(string), typeof(string), typeof(bool) };
        //        MethodInfo method = scriptManagerInstance.GetType().GetMethod("RegisterStartupScript", types);
        //        object[] parameters = new object[] { control, control.GetType(), scriptKey, scriptContent, true };
        //        method.Invoke(scriptManagerInstance, parameters);
        //    }
        //}

        ///// <summary>
        ///// 注册脚本 - 页面级别
        ///// </summary>
        ///// <param name="control"></param>
        ///// <param name="scriptKey"></param>
        ///// <param name="scriptContent"></param>
        //public void AjaxScriptManagerRegisterStartupScript(Page page, string scriptKey, string scriptContent)
        //{
        //    object scriptManagerInstance = GetAjaxScriptManagerInstance();

        //    if (scriptManagerInstance != null)
        //    {
        //        Type[] types = new Type[] { typeof(Page), typeof(Type), typeof(string), typeof(string), typeof(bool) };
        //        MethodInfo method = scriptManagerInstance.GetType().GetMethod("RegisterStartupScript", types);
        //        object[] parameters = new object[] { page, page.GetType(), scriptKey, scriptContent, true };
        //        method.Invoke(scriptManagerInstance, parameters);
        //    }
        //}

        /////// <summary>
        /////// 是否局部回发
        /////// 这种方法也是也可以的
        /////// </summary>
        /////// <returns></returns>
        ////public static bool IsPartialPostBack()
        ////{
        ////    if (HttpContext.Current != null && HttpContext.Current.Request != null)
        ////    {
        ////        string ajaxValue = HttpContext.Current.Request.Headers["X-MicrosoftAjax"];

        ////        if (!String.IsNullOrEmpty(ajaxValue) && ajaxValue.ToLower().Contains("delta=true"))
        ////        {
        ////            return true;
        ////        }
        ////    }

        ////    return false;
        ////}

        ///// <summary>
        ///// 当前是否局部回发
        ///// </summary>
        ///// <param name="page"></param>
        ///// <returns></returns>
        //public bool IsAspNetAjaxPostBack
        //{
        //    get
        //    {
        //        object scriptManagerInstance = GetAjaxScriptManagerInstance();

        //        if (scriptManagerInstance != null)
        //        {
        //            PropertyInfo pInfo = scriptManagerInstance.GetType().GetProperty("IsInAsyncPostBack");

        //            object isInAsyncPostBackObj = pInfo.GetValue(scriptManagerInstance, null);

        //            if (Convert.ToBoolean(isInAsyncPostBackObj))
        //            {
        //                return true;
        //            }
        //        }

        //        return false;
        //    }
        //}

        ///// <summary>
        ///// 包含的 System.Web.UI.ScriptManager 实例
        ///// </summary>
        ///// <returns></returns>
        //public object GetAjaxScriptManagerInstance()
        //{
        //    foreach (DictionaryEntry entry in Page.Items)
        //    {
        //        if (entry.Key.ToString().Contains("System.Web.UI.ScriptManager"))
        //        {
        //            return entry.Value;
        //        }
        //    }

        //    return null;
        //}

        #endregion

    }
}
