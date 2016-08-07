
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    PageManager.cs
 * CreatedOn:   2008-07-31
 * CreatedBy:   30372245@qq.com
 * 
 * 
 * Description：
 *      ->
 *   
 * History：
 *      ->
 * 
 * 
 * 
 * 
 */

#endregion

using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.ComponentModel;
using System.Drawing;
using System.Web.UI.WebControls;
using System.Web;
using System.Web.UI.Design;
using System.Drawing.Design;

namespace FineUI
{
    /// <summary>
    /// 页面配置管理器（每个页面必须包含一个 PageManager 控件）
    /// </summary>
    [Designer("FineUI.Design.PageManagerDesigner, FineUI.Design")]
    [ToolboxData("<{0}:PageManager runat=\"server\"></{0}:PageManager>")]
    [ToolboxBitmap(typeof(PageManager), "toolbox.PageManager.bmp")]
    [Description("页面配置管理器（每个页面必须包含一个 PageManager 控件）")]
    [ParseChildren(true)]
    [PersistChildren(false)]
    public class PageManager : ControlBase, IPostBackEventHandler
    {
        #region static

        internal static readonly string PAGELOADING_TEMLATE = "<div id='loading-mask'></div><div id='loading'><div class='loading-indicator'><img align='absmiddle' src='#LOADING_IMAGE_SRC#'/></div></div>";

        internal static readonly string PAGELOADING_IMAGE_PATH = "/res/images/loading_32.gif";


        #endregion

        #region Unsupported Properties

        ///// <summary>
        ///// 不支持此属性
        ///// </summary>
        //[Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public override bool WrapperDisplayInline
        //{
        //    get
        //    {
        //        return false;
        //    }
        //}

        /// <summary>
        /// 不支持此属性
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override bool Enabled
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// 不支持此属性
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override bool Hidden
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// 不支持此属性
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override bool Visible
        {
            get
            {
                return true;
            }
        }


        /// <summary>
        /// 不支持此属性
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override HideMode HideMode
        {
            get
            {
                return HideMode.Display;
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// 自定义页面加载图片
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("自定义页面加载图片")]
        [Editor(typeof(ImageUrlEditor), typeof(UITypeEditor))]
        public string PageLoadingImageUrl
        {
            get
            {
                object obj = FState["PageLoadingImageUrl"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                FState["PageLoadingImageUrl"] = value;
            }
        }

        #region old code


        // v1.2.9版本后不需要此属性，实现为JS的静态方法
        ///// <summary>
        ///// 向页面注册监视页面中表单内容改变的脚本
        ///// </summary>
        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue(false)]
        //[Description("向页面注册监视页面中表单内容改变的脚本")]
        //public bool RegisterPageStateChangedScript
        //{
        //    get
        //    {
        //        object obj = BoxState["RegisterPageStateChangedScript"];
        //        return obj == null ? false : (bool)obj;
        //    }
        //    set
        //    {
        //        BoxState["RegisterPageStateChangedScript"] = value;
        //    }
        //}


        // 内联样式表和Javascipt
        // 这两个没啥效果，干脆先去掉
        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue(false)]
        //[Description("启用内联的样式表和脚本引擎")]
        //public bool EnableInlineStyleJavascript
        //{
        //    get
        //    {
        //        object obj = BoxState["EnableInlineStyleJavascript"];
        //        return obj == null ? false : (bool)obj;
        //    }
        //    set
        //    {
        //        BoxState["EnableInlineStyleJavascript"] = value;
        //    }
        //}
        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue(false)]
        //[Description("使用父页面的样式表和脚本引擎")]
        //public bool ApplyParentStyleJavascript
        //{
        //    get
        //    {
        //        object obj = BoxState["ApplyParentStyleJavascript"];
        //        return obj == null ? false : (bool)obj;
        //    }
        //    set
        //    {
        //        BoxState["ApplyParentStyleJavascript"] = value;
        //    }
        //} 

        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue(false)]
        //[Description("启用设计时样式")]
        //public bool EnableDesignTimeStyle
        //{
        //    get
        //    {
        //        object obj = BoxState["EnableDesignTimeStyle"];
        //        return obj == null ? false : (bool)obj;
        //    }
        //    set
        //    {
        //        BoxState["EnableDesignTimeStyle"] = value;
        //    }
        //}

        #endregion

        /// <summary>
        /// 自动调整此容器的宽度和高度，以填充整个页面
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("自动调整此容器的宽度和高度，以填充整个页面")]
        public string AutoSizePanelID
        {
            get
            {
                object obj = FState["AutoSizePanelID"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                FState["AutoSizePanelID"] = value;
            }
        }

        ///// <summary>
        ///// 是否隐藏滚动条
        ///// </summary>
        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue(false)]
        //[Description("是否隐藏滚动条")]
        //[Obsolete("请使用 HideScrollbars 属性")]
        //public bool HideScrollbar
        //{
        //    get
        //    {
        //        return HideScrollbars;
        //    }
        //    set
        //    {
        //        HideScrollbars = value;
        //    }
        //}


        /// <summary>
        /// 是否隐藏滚动条
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("是否隐藏滚动条")]
        public bool HideScrollbars
        {
            get
            {
                object obj = FState["HideScrollbars"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                FState["HideScrollbars"] = value;
            }
        }

        ///// <summary>
        ///// 启用Asp.Net提交按钮（type=submit）的AJAX功能
        ///// </summary>
        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue(true)]
        //[Description("启用Asp.Net提交按钮（type=submit）的AJAX功能")]
        //public bool EnableAspnetSubmitButtonAjax
        //{
        //    get
        //    {
        //        object obj = FState["EnableAspnetSubmitButtonAjax"];
        //        return obj == null ? true : (bool)obj;
        //    }
        //    set
        //    {
        //        FState["EnableAspnetSubmitButtonAjax"] = value;
        //    }
        //}


        /// <summary>
        /// 每次页面回发后总是执行onReady脚本（包括Ajax局部回发）
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("每次页面回发后总是执行onReady脚本（包括Ajax局部回发）")]
        public bool ExecuteOnReadyWhenPostBack
        {
            get
            {
                object obj = FState["ExecuteOnReadyWhenPostBack"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                FState["ExecuteOnReadyWhenPostBack"] = value;
            }
        }


        /// <summary>
        /// 是否启用页面加载标示
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("是否启用页面加载标示")]
        public bool EnablePageLoading
        {
            get
            {
                object obj = FState["EnablePageLoading"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                FState["EnablePageLoading"] = value;
            }
        }


        /// <summary>
        /// 需要在AJAX回发时更新的Asp.net控件列表（逗号分隔）
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(null)]
        [Description("需要在AJAX回发时更新的Asp.net控件列表（逗号分隔）")]
        [TypeConverter(typeof(StringArrayConverter))]
        public string[] AjaxAspnetControls
        {
            get
            {
                object obj = FState["AjaxAspnetControls"];
                return obj == null ? null : (string[])obj;
            }
            set
            {
                FState["AjaxAspnetControls"] = value;
            }
        }


        //private List<string> _ajaxGridClientIDs = new List<string>();
        ///// <summary>
        ///// 本次AJAX请求过程中需要更新TemplateField的表格
        ///// </summary>
        //internal List<string> AjaxGridClientIDs
        //{
        //    get
        //    {
        //        return _ajaxGridClientIDs;
        //    }
        //    set
        //    {
        //        _ajaxGridClientIDs = value;
        //    }
        //}
        //internal void AddAjaxGridClientID(string clientID)
        //{
        //    if (!_ajaxGridClientIDs.Contains(clientID))
        //    {
        //        _ajaxGridClientIDs.Add(clientID);
        //    }
        //}

        private List<string> _ajaxGridReloadedClientIDs = new List<string>();

        /// <summary>
        /// 本次AJAX请求过程中重新加载的表格
        /// </summary>
        internal List<string> AjaxGridReloadedClientIDs
        {
            get
            {
                return _ajaxGridReloadedClientIDs;
            }
            set
            {
                _ajaxGridReloadedClientIDs = value;
            }
        }

        internal void AddAjaxGridReloadedClientID(string clientID)
        {
            if (!_ajaxGridReloadedClientIDs.Contains(clientID))
            {
                _ajaxGridReloadedClientIDs.Add(clientID);
            }
        }


        #endregion

        #region 配置参数

        /// <summary>
        /// 是否启用表单改变确认对话框
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(ConfigPropertyValue.ENABLE_FORMCHANGECONFIRM_DEFAULT)]
        [Description("是否启用表单改变确认对话框")]
        public bool EnableFormChangeConfirm
        {
            get
            {
                object obj = FState["EnableFormChangeConfirm"];
                if (obj == null)
                {
                    if (DesignMode)
                    {
                        return ConfigPropertyValue.ENABLE_FORMCHANGECONFIRM_DEFAULT;
                    }
                    else
                    {
                        return GlobalConfig.GetEnableFormChangeConfirm();
                    }
                }
                return (bool)obj;
            }
            set
            {
                FState["EnableFormChangeConfirm"] = value;
            }
        }


        /// <summary>
        /// 样式
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(Theme.Neptune)]
        [Description("样式")]
        public Theme Theme
        {
            get
            {
                object obj = FState["Theme"];
                if (obj == null)
                {
                    if (DesignMode)
                    {
                        return Theme.Neptune;
                    }
                    else
                    {
                        return GlobalConfig.GetTheme();
                    }
                }
                return (Theme)obj;
            }
            set
            {
                FState["Theme"] = value;
            }
        }

        /// <summary>
        /// 自定义样式的根路径
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("自定义样式的根路径")]
        public string CustomThemeBasePath
        {
            get
            {
                object obj = FState["CustomThemeBasePath"];
                if (obj == null)
                {
                    if (DesignMode)
                    {
                        return "";
                    }
                    else
                    {
                        return GlobalConfig.GetCustomThemeBasePath();
                    }
                }
                return obj.ToString();
            }
            set
            {
                FState["CustomThemeBasePath"] = value;
            }
        }


        /// <summary>
        /// 自定义样式的名称
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("自定义样式的名称")]
        public string CustomTheme
        {
            get
            {
                object obj = FState["CustomTheme"];
                if (obj == null)
                {
                    if (DesignMode)
                    {
                        return "";
                    }
                    else
                    {
                        return GlobalConfig.GetCustomTheme();
                    }
                }
                return obj.ToString();
            }
            set
            {
                FState["CustomTheme"] = value;
            }
        }


        /// <summary>
        /// 语言
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(Language.ZH_CN)]
        [Description("语言")]
        public Language Language
        {
            get
            {
                object obj = FState["Language"];
                if (obj == null)
                {
                    if (DesignMode)
                    {
                        return Language.ZH_CN;
                    }
                    else
                    {
                        return GlobalConfig.GetLanguage();
                    }
                }
                return (Language)obj;
            }
            set
            {
                FState["Language"] = value;
            }
        }


        ///// <summary>
        ///// 是否启用大字体
        ///// </summary>
        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue(false)]
        //[Description("是否启用大字体")]
        //public bool EnableBigFont
        //{
        //    get
        //    {
        //        object obj = FState["EnableBigFont"];
        //        if (obj == null)
        //        {
        //            if (DesignMode)
        //            {
        //                return false;
        //            }
        //            else
        //            {
        //                return GlobalConfig.GetEnableBigFont();
        //            }
        //        }
        //        return (bool)obj;
        //    }
        //    set
        //    {
        //        FState["EnableBigFont"] = value;
        //    }
        //}


        /// <summary>
        /// 是否启用Ajax
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("是否启用Ajax")]
        public override bool EnableAjax
        {
            get
            {
                object obj = FState["EnableAjax"];
                if (obj == null)
                {
                    if (DesignMode)
                    {
                        return true;
                    }
                    else
                    {
                        return GlobalConfig.GetEnableAjax();
                    }
                }
                return (bool)obj;
            }
            set
            {
                FState["EnableAjax"] = value;
            }
        }



        /// <summary>
        /// 是否启用Ajax正在加载提示
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("是否启用Ajax正在加载提示")]
        public new bool EnableAjaxLoading
        {
            get
            {
                object obj = FState["EnableAjaxLoading"];
                if (obj == null)
                {
                    if (DesignMode)
                    {
                        return true;
                    }
                    else
                    {
                        return GlobalConfig.GetEnableAjaxLoading();
                    }
                }
                return (bool)obj;
            }
            set
            {
                FState["EnableAjaxLoading"] = value;
            }
        }


        /// <summary>
        /// Ajax正在加载提示的类型
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(AjaxLoadingType.Default)]
        [Description("Ajax正在加载提示的类型")]
        public new AjaxLoadingType AjaxLoadingType
        {
            get
            {
                object obj = FState["AjaxLoadingType"];
                if (obj == null)
                {
                    if (DesignMode)
                    {
                        return AjaxLoadingType.Default;
                    }
                    else
                    {
                        return GlobalConfig.GetAjaxLoadingType();
                    }
                }
                return (AjaxLoadingType)obj;
            }
            set
            {
                FState["AjaxLoadingType"] = value;
            }
        }


        /// <summary>
        /// Ajax超时时间（单位：秒，默认：60秒）
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(ConfigPropertyValue.AJAX_TIMEOUT_DEFAULT)]
        [Description("Ajax超时时间（单位：秒，默认：60秒）")]
        public int AjaxTimeout
        {
            get
            {
                object obj = FState["AjaxTimeout"];
                if (obj == null)
                {
                    if (DesignMode)
                    {
                        return (int)ConfigPropertyValue.AJAX_TIMEOUT_DEFAULT;
                    }
                    else
                    {
                        return (int)GlobalConfig.GetAjaxTimeout();
                    }
                }
                return (int)obj;
            }
            set
            {
                FState["AjaxTimeout"] = value;
            }
        }


        /// <summary>
        /// 是否启用FState压缩（默认为false）
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("是否启用FState压缩（默认为false）")]
        public new bool EnableFStateCompress
        {
            get
            {
                object obj = FState["EnableFStateCompress"];
                if (obj == null)
                {
                    if (DesignMode)
                    {
                        return false;
                    }
                    else
                    {
                        return GlobalConfig.GetEnableFStateCompress();
                    }
                }
                return (bool)obj;
            }
            set
            {
                FState["EnableFStateCompress"] = value;
            }
        }


        /// <summary>
        /// 是否向页面输出IE=edge标识
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("是否向页面输出IE=edge标识")]
        public bool IEEdge
        {
            get
            {
                object obj = FState["IEEdge"];
                if (obj == null)
                {
                    if (DesignMode)
                    {
                        return true;
                    }
                    else
                    {
                        return GlobalConfig.GetIEEdge();
                    }
                }
                return (bool)obj;
            }
            set
            {
                FState["IEEdge"] = value;
            }
        }

        #endregion

        #region ValidateForms/ValidateTarget/ValidateMessageBox


        /// <summary>
        /// 需要验证的表单名称列表（逗号分隔），需配合CustomEvent使用
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(null)]
        [Description("需要验证的表单名称列表（逗号分隔），需配合CustomEvent使用")]
        [TypeConverter(typeof(StringArrayConverter))]
        public string[] ValidateForms
        {
            get
            {
                object obj = FState["ValidateForms"];
                return obj == null ? null : (string[])obj;
            }
            set
            {
                FState["ValidateForms"] = value;
            }
        }

        /// <summary>
        /// 验证失败时提示对话框弹出位置，需配合CustomEvent使用
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(Target.Self)]
        [Description("验证失败时提示对话框弹出位置，需配合CustomEvent使用")]
        public Target ValidateTarget
        {
            get
            {
                object obj = FState["ValidateTarget"];
                return obj == null ? Target.Self : (Target)obj;
            }
            set
            {
                FState["ValidateTarget"] = value;
            }
        }


        /// <summary>
        /// 验证失败时是否出现提示对话框，需配合CustomEvent使用
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("验证失败时是否出现提示对话框，需配合CustomEvent使用")]
        public bool ValidateMessageBox
        {
            get
            {
                object obj = FState["ValidateMessageBox"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                FState["ValidateMessageBox"] = value;
            }
        }

        #endregion

        #region Form Settings

        /// <summary>
        /// 表单中消息的位置
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(typeof(MessageTarget), ConfigPropertyValue.FORM_MESSAGETARGET_DEFAULT_STRING)]
        [Description("表单中提示消息的位置")]
        public MessageTarget FormMessageTarget
        {
            get
            {
                object obj = FState["FormMessageTarget"];
                if (obj == null)
                {
                    if (DesignMode)
                    {
                        return ConfigPropertyValue.FORM_MESSAGETARGET_DEFAULT;
                    }
                    else
                    {
                        return GlobalConfig.GetFormMessageTarget();
                    }
                }
                return (MessageTarget)obj;
            }
            set
            {
                FState["FormMessageTarget"] = value;
            }
        }

        /// <summary>
        /// 表单行子项之间的间距
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(typeof(Unit), ConfigPropertyValue.FORMROW_ITEMSSPACE_DEFAULT_STRING)]
        [Description("表单行子项之间的间距")]
        public Unit FormRowItemsSpace
        {
            get
            {
                object obj = FState["FormRowItemsSpace"];
                if (obj == null)
                {
                    if (DesignMode)
                    {
                        return (Unit)ConfigPropertyValue.FORMROW_ITEMSSPACE_DEFAULT;
                    }
                    else
                    {
                        return (Unit)GlobalConfig.GetFormRowItemsSpace();
                    }
                }
                return (Unit)obj;
            }
            set
            {
                FState["FormRowItemsSpace"] = value;
            }
        }



        /// <summary>
        /// 表单中标签的位置
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(typeof(LabelAlign), ConfigPropertyValue.FORM_LABELALIGN_DEFAULT_STRING)]
        [Description("表单中标签的位置")]
        public LabelAlign FormLabelAlign
        {
            get
            {
                object obj = FState["FormLabelAlign"];
                if (obj == null)
                {
                    if (DesignMode)
                    {
                        return ConfigPropertyValue.FORM_LABELALIGN_DEFAULT;
                    }
                    else
                    {
                        return GlobalConfig.GetFormLabelAlign();
                    }
                }
                return (LabelAlign)obj;
            }
            set
            {
                FState["FormLabelAlign"] = value;
            }
        }

        /// <summary>
        /// 表单中右侧的空白宽度
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(typeof(Unit), ConfigPropertyValue.FORM_OFFSETRIGHT_DEFAULT_STRING)]
        [Description("表单中右侧的空白宽度")]
        public Unit FormOffsetRight
        {
            get
            {
                object obj = FState["FormOffsetRight"];
                if (obj == null)
                {
                    if (DesignMode)
                    {
                        return (Unit)ConfigPropertyValue.FORM_OFFSETRIGHT_DEFAULT;
                    }
                    else
                    {
                        return (Unit)GlobalConfig.GetFormOffsetRight();
                    }
                }
                return (Unit)obj;
            }
            set
            {
                FState["FormOffsetRight"] = value;
            }
        }


        /// <summary>
        /// 表单中字段标签的宽度
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(typeof(Unit), ConfigPropertyValue.FORM_LABELWIDTH_DEFAULT_STRING)]
        [Description("表单中标签的宽度")]
        public Unit FormLabelWidth
        {
            get
            {
                object obj = FState["FormLabelWidth"];
                if (obj == null)
                {
                    if (DesignMode)
                    {
                        return (Unit)ConfigPropertyValue.FORM_LABELWIDTH_DEFAULT;
                    }
                    else
                    {
                        return (Unit)GlobalConfig.GetFormLabelWidth();
                    }
                }
                return (Unit)obj;
            }
            set
            {
                FState["FormLabelWidth"] = value;
            }
        }

        /// <summary>
        /// 表单中字段与标签的分隔符
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(typeof(String), ConfigPropertyValue.FORM_LABELSEPARATOR_DEFAULT)]
        [Description("表单中字段与标签的分隔符")]
        public string FormLabelSeparator
        {
            get
            {
                object obj = FState["FormLabelSeparator"];
                if (obj == null)
                {
                    if (DesignMode)
                    {
                        return ConfigPropertyValue.FORM_LABELSEPARATOR_DEFAULT;
                    }
                    else
                    {
                        return GlobalConfig.GetFormLabelSeparator();
                    }
                }
                return (String)obj;
            }
            set
            {
                FState["FormLabelSeparator"] = value;
            }
        }

        #endregion

        #region oldcode

        ///// <summary>
        ///// PageLoading控件是否存在页面
        ///// </summary>
        //internal bool PageLoadingControlExist
        //{
        //    get
        //    {
        //        Control loading = ControlUtil.FindControl(Page, typeof(PageLoading));
        //        return loading != null;
        //    }
        //}

        #endregion

        #region RenderBeginTag/RenderEndTag

        /// <summary>
        /// 渲染控件的开始标签
        /// </summary>
        /// <param name="writer">输出流</param>
        protected override void RenderBeginTag(HtmlTextWriter writer)
        {
            if (EnablePageLoading)
            {
                //string content = PAGELOADING_TEMLATE;
                //content = content.Replace("#LOADING_IMAGE_SRC#", ResolveUrl(GlobalConfig.GetJSBasePath() + PAGELOADING_IMAGE_PATH)); // ResourceHelper.GetWebResourceUrlResAxd(Page, PageLoading.LOADING_IMAGE_NAME));

                string content = PAGELOADING_TEMLATE;

                string imageUrl = String.Empty;
                if (!String.IsNullOrEmpty(PageLoadingImageUrl))
                {
                    imageUrl = ResolveUrl(PageLoadingImageUrl);
                }
                else
                {
                    imageUrl = ResolveUrl(GlobalConfig.GetJSBasePath() + PAGELOADING_IMAGE_PATH); //ResourceHelper.GetWebResourceUrl(Page, LOADING_IMAGE_NAME);
                }

                content = content.Replace("#LOADING_IMAGE_SRC#", imageUrl);

                writer.Write(content);
            }



            base.RenderBeginTag(writer);
        }

        /// <summary>
        /// 渲染控件的结束标签
        /// </summary>
        /// <param name="writer">输出流</param>
        protected override void RenderEndTag(HtmlTextWriter writer)
        {
            base.RenderEndTag(writer);
        }

        #endregion

        #region OnPreRender

        /// <summary>
        /// 渲染 HTML 之前调用（AJAX回发）
        /// </summary>
        protected override void OnAjaxPreRender()
        {
            base.OnAjaxPreRender();

            StringBuilder sb = new StringBuilder();
            //if (PropertyModified("Readonly"))
            //{
            //    sb.AppendFormat("{0}.setReadOnly({1});", XID, Readonly.ToString().ToLower());
            //}

            AddAjaxScript(sb);
        }

        /// <summary>
        /// 渲染 HTML 之前调用（页面第一次加载或者普通回发）
        /// </summary>
        protected override void OnFirstPreRender()
        {
            base.OnFirstPreRender();

            // 不渲染
            RenderWrapperNode = false;

            // 这个是必须的，2009-08-04
            // 因为每个页面都会有 PageManager 控件，每个页面要至少调用 GetPostBackEventReference 一次，以在页面产生 __doPostBack 函数。
            Page.ClientScript.GetPostBackEventReference(this, "");

            // Move it to ResourceManager.cs
            // 为页面的 Form 添加 autocomplete="off" 属性
            // 参考http://www.cnblogs.com/sanshi/archive/2009/09/04/1560146.html#1635830
            // Page.Form.Attributes["autocomplete"] = "off";

            #region HideScrollbars

            if (HideScrollbars)
            {
                //if (Page.Request.UserAgent.ToLower().Contains("msie"))
                //{
                //    //Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "noscroll", String.Format("window.document.body.scroll='no';"), true);
                //    AddStartupAbsoluteScript("window.document.body.scroll='no';");
                //}
                //else
                //{
                //    //Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "noscroll",  String.Format("window.document.body.style.overflow='hidden';"), true);
                //    AddStartupAbsoluteScript("window.document.body.style.overflow='hidden';");
                //}
                AddStartupAbsoluteScript("F.util.hideScrollbar();");
            }

            #endregion

            #region oldcode

            //if (!PageLoadingControlExist)
            //{
            //    string jsContent = String.Empty;

            //    if (EnablePageLoading)
            //    {
            //        jsContent += "F.util.removePageLoading(false);";
            //    }

            //    AddStartupAbsoluteScript(jsContent);
            //}


            #endregion

            //#region EnableAjax

            //if (!EnableAjax)
            //{
            //    AddStartupAbsoluteScript("F.global_disable_ajax=true;");
            //}

            //#endregion

            #region AutoSizePanelID

            if (!String.IsNullOrEmpty(AutoSizePanelID))
            {
                PanelBase autosizePanel = ControlUtil.FindControl(Page.Form, AutoSizePanelID) as PanelBase;

                if (autosizePanel != null)
                {
                    #region oldcode
                    //string resizePanelScript = String.Empty;

                    //resizePanelScript += String.Format("{0}_resize_outerpanel=function(){{var panel=Ext.getCmp('{1}');panel.setSize(Ext.getBody().getSize());panel.doLayout();}};", ClientJavascriptID, panel.ClientID);
                    //resizePanelScript += String.Format("{0}_resize_outerpanel();", ClientJavascriptID);
                    //resizePanelScript += String.Format("if(Ext.isIE){{X.{0}_resize_outerpanel.defer(60);}}", ClientJavascriptID);
                    //resizePanelScript += String.Format("Ext.EventManager.onWindowResize(function(){{X.{0}_resize_outerpanel();}},box);", ClientJavascriptID);

                    //AddAbsoluteStartupScript(resizePanelScript);

                    // X._3=new Ext.FormViewport({renderTo:"RegionPanel1_wrapper",id:"RegionPanel1",layout:"border",items:[X._1,X._2],bodyStyle:"",border:false,animCollapse:false});

                    #endregion

                    // 子节点不向页面输出HTML，此PageManager向页面输出HTML
                    autosizePanel.RenderWrapperNode = false;
                    RenderWrapperNode = true;

                    OB.AddProperty("layout", "fit");
                    OB.AddProperty("border", false);
                    OB.AddProperty("items", String.Format("{0}", autosizePanel.XID), true);

                    string jsContent = String.Format("var {0}=Ext.create('Ext.ux.FormViewport',{1});", XID, OB.ToString());

                    // 确保FormViewport脚本在所以用户自定义脚本（PageContext.RegisterStartupScript）之前执行
                    AddStartupAbsoluteScript(jsContent, Constants.ABSOLUTE_STARTUP_SCRIPT_DEFAULT_LEVEL - 20);
                }
            }

            #endregion

            //if (EnableBigFont)
            //{
            //    AddStartupAbsoluteScript("Ext.getBody().addClass('bigfont');");
            //}

            #region oldcode

            // Move to F.util.init
            // Asp.Net Buttons(type="submit")
            // AddStartupAbsoluteScript("F.util.makeAspnetSubmitButtonAjax();");

            #endregion

            JsObjectBuilder job = new JsObjectBuilder();

            job.AddProperty("name", UniqueID);

            if (ValidateForms != null && ValidateForms.Length > 0)
            {
                JsObjectBuilder validate = new JsObjectBuilder();
                validate.AddProperty("forms", ControlUtil.GetControlClientIDs(ValidateForms));
                validate.AddProperty("target", TargetHelper.GetName(ValidateTarget));
                validate.AddProperty("messagebox", ValidateMessageBox.ToString().ToLower());
                job.AddProperty("validate", validate);

            }

            string createScript = String.Format("F.f_pagemanager={1};", XID, job);
            AddStartupScript(createScript);
        }

        #region old code

        //private PanelBase GetFirstPanelControl(ControlCollection controls)
        //{
        //    foreach (Control c in controls)
        //    {
        //        if (c is PanelBase)
        //        {
        //            return c as PanelBase;
        //        }
        //        else if (c.Controls != null && c.Controls.Count > 0)
        //        {
        //            PanelBase findPanel = GetFirstPanelControl(c.Controls);
        //            if (findPanel != null)
        //            {
        //                return findPanel;
        //            }
        //        }
        //    }

        //    return null;
        //} 

        #endregion

        #endregion

        #region Instance

        //// 这是一个严重的错误，不应该将_manager保存为全局变量，而是作为随页面存在的
        //private static PageManager _manager = null;
        /// <summary>
        /// PageManager在当前页面的实例
        /// </summary>
        public static PageManager Instance
        {
            get
            {
                if (HttpContext.Current != null)
                {
                    if (HttpContext.Current.Items["PageManagerInstanceCached"] == null)
                    {
                        HttpContext.Current.Items["PageManagerInstanceCached"] = true;
                        HttpContext.Current.Items["PageManagerInstance"] = ControlUtil.FindControl(typeof(FineUI.PageManager)) as PageManager;
                    }
                    return HttpContext.Current.Items["PageManagerInstance"] as PageManager;
                }
                // It's design time.
                return null;
            }
        }

        ///// <summary>
        ///// 获取PageManager实例
        ///// </summary>
        ///// <param name="site"></param>
        ///// <returns></returns>
        //public static PageManager GetInstance(ISite site)
        //{
        //    foreach (System.ComponentModel.IComponent c in site.Container.Components)
        //    {
        //        if (c is FineUI.PageManager)
        //        {
        //            return c as FineUI.PageManager;
        //        }
        //    }
        //    return null;
        //}

        //public static PageManager GetInstance(Page page)
        //{
        //    if (page == null)
        //    {
        //        page = HttpContext.Current.CurrentHandler as Page;
        //    }

        //    PageManager pageManager = ControlUtil.FindControl(page, typeof(FineUI.PageManager)) as PageManager;
        //    if (pageManager == null)
        //    {
        //        throw new Exception("每个页面必须包含一个PageManager控件。");
        //    }

        //    return pageManager;
        //}

        #endregion

        #region oldcode

        //private List<string> beforeAjaxPostBackScriptKeys = new List<string>();

        //private string beforeAjaxPostBackScript = String.Empty;

        //internal string BeforeAjaxPostBackScript
        //{
        //    get { return beforeAjaxPostBackScript; }
        //    set { beforeAjaxPostBackScript = value; }
        //}

        ///// <summary>
        ///// Used by FCKeditor, Add script before ajax postback.
        ///// </summary>
        ///// <param name="key"></param>
        ///// <param name="script"></param>
        //public void RegisterOnAjaxPostBack(string key, string script)
        //{
        //    if (!beforeAjaxPostBackScriptKeys.Contains(key))
        //    {
        //        beforeAjaxPostBackScriptKeys.Add(key);
        //        BeforeAjaxPostBackScript += script;
        //    }
        //}

        #endregion

        #region GetCustomEventReference

        /// <summary>
        /// 获取回发的客户端脚本（触发PageManager的CustomEvent事件）
        /// </summary>
        /// <param name="eventArgument">事件参数</param>
        /// <returns>客户端脚本</returns>
        public string GetCustomEventReference(string eventArgument)
        {
            return GetCustomEventReference(eventArgument, false);
        }

        /// <summary>
        /// 获取回发的客户端脚本（触发PageManager的CustomEvent事件）
        /// </summary>
        /// <param name="enableAjax">当前请求是否启用AJAX</param>
        /// <param name="eventArgument">事件参数</param>
        /// <returns>客户端脚本</returns>
        public string GetCustomEventReference(bool enableAjax, string eventArgument)
        {
            return GetCustomEventReference(enableAjax, eventArgument, false);
        }

        /// <summary>
        /// 获取回发的客户端脚本（触发PageManager的CustomEvent事件）
        /// </summary>
        /// <param name="eventArgument">事件参数</param>
        /// <param name="validateForms">是否在回发前验证表单（在PageManager上进行表单配置）</param>
        /// <returns>客户端脚本</returns>
        public string GetCustomEventReference(string eventArgument, bool validateForms)
        {
            return GetCustomEventReference(eventArgument, validateForms, false);
        }

        /// <summary>
        /// 获取回发的客户端脚本（触发PageManager的CustomEvent事件）
        /// </summary>
        /// <param name="enableAjax">当前请求是否启用AJAX</param>
        /// <param name="eventArgument">事件参数</param>
        /// <param name="validateForms">是否在回发前验证表单（在PageManager上进行表单配置）</param>
        /// <returns>客户端脚本</returns>
        public string GetCustomEventReference(bool enableAjax, string eventArgument, bool validateForms)
        {
            return GetCustomEventReference(enableAjax, eventArgument, validateForms, false);
        }

        /// <summary>
        /// 获取回发的客户端脚本（触发PageManager的CustomEvent事件）
        /// </summary>
        /// <param name="eventArgument">事件参数</param>
        /// <param name="validateForms">是否在回发前验证表单（在PageManager上进行表单配置）</param>
        /// <param name="persistOriginal">保持eventArgument参数原样输出</param>
        /// <returns>客户端脚本</returns>
        public string GetCustomEventReference(string eventArgument, bool validateForms, bool persistOriginal)
        {
            string arg = eventArgument;
            if (!persistOriginal)
            {
                arg = JsHelper.Enquote(arg);
            }
            return String.Format("F.f_customEvent({0},{1});", arg, validateForms.ToString().ToLower());
        }

        /// <summary>
        /// 获取回发的客户端脚本（触发PageManager的CustomEvent事件）
        /// </summary>
        /// <param name="enableAjax">当前请求是否启用AJAX</param>
        /// <param name="eventArgument">事件参数</param>
        /// <param name="validateForms">是否在回发前验证表单（在PageManager上进行表单配置）</param>
        /// <param name="persistOriginal">保持eventArgument参数原样输出</param>
        /// <returns>客户端脚本</returns>
        public string GetCustomEventReference(bool enableAjax, string eventArgument, bool validateForms, bool persistOriginal)
        {
            string arg = eventArgument;
            if (!persistOriginal)
            {
                arg = JsHelper.Enquote(arg);
            }
            return String.Format("F.f_customEvent({0},{1},{2});", enableAjax.ToString().ToLower(), arg, validateForms.ToString().ToLower());
        }

        #endregion

        #region IPostBackEventHandler

        /// <summary>
        /// 处理回发事件
        /// </summary>
        /// <param name="eventArgument">事件参数</param>
        public void RaisePostBackEvent(string eventArgument)
        {
            OnCustomEvent(new CustomEventArgs(eventArgument));
        }


        private static readonly object _handlerKey = new object();

        /// <summary>
        /// 自定义事件
        /// </summary>
        [Category(CategoryName.ACTION)]
        [Description("自定义事件")]
        public event EventHandler<CustomEventArgs> CustomEvent
        {
            add
            {
                Events.AddHandler(_handlerKey, value);
            }
            remove
            {
                Events.RemoveHandler(_handlerKey, value);
            }
        }

        /// <summary>
        /// 触发自定义事件
        /// </summary>
        /// <param name="e">事件参数</param>
        protected virtual void OnCustomEvent(CustomEventArgs e)
        {
            EventHandler<CustomEventArgs> handler = Events[_handlerKey] as EventHandler<CustomEventArgs>;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion

    }
}
