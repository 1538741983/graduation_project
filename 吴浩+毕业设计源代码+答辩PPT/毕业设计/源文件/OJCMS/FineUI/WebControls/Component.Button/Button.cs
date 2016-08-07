
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    Button.cs
 * CreatedOn:   2008-04-07
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
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Design;
using System.Web.UI.Design;

namespace FineUI
{
    /// <summary>
    /// 按钮控件
    /// </summary>
    [Designer("FineUI.Design.ButtonDesigner, FineUI.Design")]
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:Button Text=\"Button\" runat=\"server\"></{0}:Button>")]
    [ToolboxBitmap(typeof(Button), "toolbox.Button.bmp")]
    [Description("按钮控件")]
    [DefaultEvent("Click")]
    [ParseChildren(true)]
    [PersistChildren(false)]
    [ControlBuilder(typeof(NotAllowWhitespaceLiteralsBuilder))]
    public class Button : BoxComponent, IPostBackEventHandler, IPostBackDataHandler
    {
        #region Constructor

        /// <summary>
        /// 构造函数
        /// </summary>
        public Button()
        {
            AddServerAjaxProperties("Text", "Icon", "IconUrl", "ToolTip", "OnClientClick", "ConfirmTitle", "ConfirmText", "ConfirmIcon", "ConfirmTarget");
            AddClientAjaxProperties("Pressed");
        }

        #endregion

        #region Properties

        /// <summary>
        /// 回发之前禁用按钮（防止重复提交）
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("回发之前禁用按钮（防止重复提交）")]
        public bool DisableControlBeforePostBack
        {
            get
            {
                object obj = FState["DisableControlBeforePostBack"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                FState["DisableControlBeforePostBack"] = value;
            }
        }

        /// <summary>
        /// 是否可以回发
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("是否可以回发")]
        public bool EnablePostBack
        {
            get
            {
                object obj = FState["EnablePostBack"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                FState["EnablePostBack"] = value;
            }
        }


        /// <summary>
        /// [AJAX属性]是否被按下
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("[AJAX属性]是否被按下")]
        public bool Pressed
        {
            get
            {
                object obj = FState["Pressed"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                FState["Pressed"] = value;
            }
        }

        /// <summary>
        /// 是否可以按下
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("是否可以按下")]
        public bool EnablePress
        {
            get
            {
                object obj = FState["EnablePress"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                FState["EnablePress"] = value;
            }
        }

        /// <summary>
        /// [AJAX属性]点击按钮时需要执行的客户端脚本
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("[AJAX属性]点击按钮时需要执行的客户端脚本")]
        public string OnClientClick
        {
            get
            {
                object obj = FState["OnClientClick"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                FState["OnClientClick"] = value;
            }
        }

        /// <summary>
        /// [AJAX属性]预定义图标
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(Icon.None)]
        [Description("[AJAX属性]预定义图标")]
        public Icon Icon
        {
            get
            {
                object obj = FState["Icon"];
                return obj == null ? Icon.None : (Icon)obj;
            }
            set
            {
                FState["Icon"] = value;
            }
        }

        /// <summary>
        /// 按钮的大小
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(ButtonSize.Small)]
        [Description("按钮的大小")]
        public ButtonSize Size
        {
            get
            {
                object obj = FState["Size"];
                return obj == null ? ButtonSize.Small : (ButtonSize)obj;
            }
            set
            {
                FState["Size"] = value;
            }
        }

        /// <summary>
        /// 图标地址
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("图标地址")]
        [Editor(typeof(ImageUrlEditor), typeof(UITypeEditor))]
        public string IconUrl
        {
            get
            {
                object obj = FState["IconUrl"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                FState["IconUrl"] = value;
            }
        }

        /// <summary>
        /// 图标摆放位置
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(IconAlign.Left)]
        [Description("图标摆放位置")]
        public IconAlign IconAlign
        {
            get
            {
                object obj = FState["IconAlign"];
                return obj == null ? IconAlign.Left : (IconAlign)obj;
            }
            set
            {
                FState["IconAlign"] = value;
            }
        }


        /// <summary>
        /// [AJAX属性]按钮文本
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("[AJAX属性]按钮文本")]
        public string Text
        {
            get
            {
                object obj = FState["Text"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                FState["Text"] = value;
            }
        }

        /// <summary>
        /// [AJAX属性]提示文本
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("[AJAX属性]提示文本")]
        public string ToolTip
        {
            get
            {
                object obj = FState["ToolTip"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                FState["ToolTip"] = value;
            }
        }


        /// <summary>
        /// 提示文本类型
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(ToolTipType.Qtip)]
        [Description("提示文本类型")]
        public ToolTipType ToolTipType
        {
            get
            {
                object obj = FState["ToolTipType"];
                return obj == null ? ToolTipType.Qtip : (ToolTipType)obj;
            }
            set
            {
                FState["ToolTipType"] = value;
            }
        }



        /// <summary>
        /// Tab键索引
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(null)]
        [Description("Tab键索引")]
        public short? TabIndex
        {
            get
            {
                object obj = FState["TabIndex"];
                return obj == null ? null : (short?)obj;
            }
            set
            {
                FState["TabIndex"] = value;
            }
        }

        /// <summary>
        /// 按钮类型
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(ButtonType.Button)]
        [Description("按钮类型")]
        public virtual ButtonType Type
        {
            get
            {
                object obj = FState["ButtonType"];
                return obj == null ? ButtonType.Button : (ButtonType)obj;
            }
            set
            {
                FState["ButtonType"] = value;
            }
        }


        #endregion

        #region ValidateForms/ValidateTarget/ValidateMessageBox


        /// <summary>
        /// 需要验证的表单名称列表（逗号分隔）
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(null)]
        [Description("需要验证的表单名称列表（逗号分隔）")]
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
        /// 验证失败时提示对话框弹出位置
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(Target.Self)]
        [Description("验证失败时提示对话框弹出位置")]
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
        /// 验证失败时是否出现提示对话框
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("验证失败时是否出现提示对话框")]
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

        #region ConfirmText/ConfirmTitle/ConfirmIcon/ConfirmTarget

        /// <summary>
        /// [AJAX属性]确认对话框标题
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("[AJAX属性]确认对话框标题")]
        public string ConfirmTitle
        {
            get
            {
                object obj = FState["ConfirmTitle"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                FState["ConfirmTitle"] = value;
            }
        }

        /// <summary>
        /// [AJAX属性]确认对话框内容
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("[AJAX属性]确认对话框内容")]
        public string ConfirmText
        {
            get
            {
                object obj = FState["ConfirmText"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                FState["ConfirmText"] = value;
            }
        }


        /// <summary>
        /// [AJAX属性]确认对话框提示图标
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(MessageBoxIcon.Warning)]
        [Description("[AJAX属性]确认对话框提示图标")]
        public MessageBoxIcon ConfirmIcon
        {
            get
            {
                object obj = FState["ConfirmIcon"];
                return obj == null ? MessageBoxIcon.Warning : (MessageBoxIcon)obj;
            }
            set
            {
                FState["ConfirmIcon"] = value;
            }
        }

        /// <summary>
        /// [AJAX属性]确认对话框弹出位置
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(Target.Self)]
        [Description("[AJAX属性]确认对话框弹出位置")]
        public Target ConfirmTarget
        {
            get
            {
                object obj = FState["ConfirmTarget"];
                return obj == null ? Target.Self : (Target)obj;
            }
            set
            {
                FState["ConfirmTarget"] = value;
            }
        }

        #endregion

        #region Menu

        /// <summary>
        /// 按钮的上下文菜单
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("按钮的上下文菜单")]
        public string MenuID
        {
            get
            {
                object obj = FState["MenuID"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                FState["MenuID"] = value;
            }
        }



        private Menu _menu;

        /// <summary>
        /// 按钮的上下文菜单
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("按钮的上下文菜单")]
        public Menu Menu
        {
            get
            {
                if (_menu == null)
                {
                    _menu = new Menu();

                    //_menu.RenderWrapperNode = false;
                    Controls.Add(_menu);

                }
                return _menu;
            }
        }


        #endregion

        #region PressedHiddenFieldID

        //[Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        private string PressedHiddenFieldID
        {
            get
            {
                return String.Format("{0}_Pressed", ClientID);
            }
        }

        #endregion

        #region OnAjaxPreRender

        /// <summary>
        /// 渲染 HTML 之前调用（AJAX回发）
        /// </summary>
        protected override void OnAjaxPreRender()
        {
            base.OnAjaxPreRender();

            StringBuilder sb = new StringBuilder();

            if (PropertyModified("Text"))
            {
                sb.AppendFormat("{0}.f_setText();", XID);
            }

            if (EnablePress)
            {
                if (PropertyModified("Pressed"))
                {
                    //if (ClientPropertyModifiedInServer("Pressed"))

                    sb.AppendFormat("{0}.f_toggle();", XID);

                }
            }

            if (PropertyModified("Icon", "IconUrl"))
            {
                string resolvedIconUrl = IconHelper.GetResolvedIconUrl(Icon, IconUrl);
                if (!String.IsNullOrEmpty(resolvedIconUrl))
                {
                    sb.AppendFormat("{0}.setIcon({1});", XID, JsHelper.Enquote(resolvedIconUrl));
                }
            }

            if (PropertyModified("ToolTip"))
            {
                sb.AppendFormat("{0}.f_setTooltip();", XID);
            }

            if (PropertyModified("OnClientClick", "ConfirmTitle", "ConfirmText", "ConfirmTarget", "ConfirmIcon"))
            {
                //sb.AppendFormat("{0}.un('click', {0}.initialConfig.listeners.click);", XID);
                //sb.AppendFormat("{0}.on('click',{1});", XID, GetClickScriptFunction());

                sb.AppendFormat("{0}.setHandler({1});", XID, JsHelper.GetFunction(GetClickScript()));
            }

            AddAjaxScript(sb);
        }

        #endregion

        #region OnFirstPreRender

        /// <summary>
        /// 渲染 HTML 之前调用（页面第一次加载或者普通回发）
        /// </summary>
        protected override void OnFirstPreRender()
        {
            base.OnFirstPreRender();

            //ResourceManager.Instance.AddJavaScriptComponent("button");
            //if (Menu.Items.Count > 0)
            //{
            //    ResourceManager.Instance.AddJavaScriptComponent("menu");
            //}

            #region Properties
            if (TabIndex != null)
            {
                OB.AddProperty("tabIndex", TabIndex);
            }

            if (!String.IsNullOrEmpty(ToolTip))
            {
                OB.AddProperty("tooltip", ToolTip);
                OB.AddProperty("tooltipType", ToolTipTypeName.GetName(ToolTipType));
            }

            OB.AddProperty("text", Text);

            if (EnablePress)
            {
                OB.AddProperty("enableToggle", EnablePress);
                OB.AddProperty("pressed", Pressed);

                //hiddenFieldsScript += GetSetHiddenFieldValueScript(PressedHiddenFieldID, Pressed.ToString().ToLower());
                //string toggleScript = String.Format("function(btn,pressed){{F.util.setHiddenFieldValue('{0}',pressed);}}", PressedHiddenFieldID);
                //OB.Listeners.AddProperty(OptionName.Toggle, toggleScript, true);
            }

            //if (Type != ButtonType.Button)
            //{
            //    OB.AddProperty("type", ButtonTypeName.GetName(Type));
            //}



            if (Size != ButtonSize.Small)
            {
                OB.AddProperty("scale", ButtonSizeName.GetName(Size));
            }

            #endregion

            #region Icon IconUrl

            string resolvedIconUrl = IconHelper.GetResolvedIconUrl(Icon, IconUrl);
            if (!String.IsNullOrEmpty(resolvedIconUrl))
            {
                // 不需要先删除原来的属性，因为在AddProperty内部已经有这个逻辑了
                OB.AddProperty("cls", CssClass + " x-btn-text-icon");
                OB.AddProperty("icon", resolvedIconUrl);

                if (IconAlign != IconAlign.Left)
                {
                    OB.AddProperty("iconAlign", IconAlignHelper.GetName(IconAlign));
                }
            }

            #endregion

            #region Click

            string clickScript = GetClickScript();
            if (!String.IsNullOrEmpty(clickScript))
            {
                OB.AddProperty("handler", JsHelper.GetFunction(clickScript), true);
            }

            #endregion

            #region oldcode

            //string clickScriptFunction = GetClickScriptFunction();
            //if (AjaxPropertyChanged("ClickScriptFunction", clickScriptFunction))
            //{
            //    string ajaxClickFunction = String.Empty;
            //    //ajaxClickFunction += String.Format("{0}.purgeListeners('click');", ClientJavascriptID);
            //    ajaxClickFunction += String.Format("{0}.un('click', X.{0}.initialConfig.listeners.click);", XID);
            //    ajaxClickFunction += String.Format("{0}.on('click',{1});", XID, clickScriptFunction);

            //    AddAjaxPropertyChangedScript(ajaxClickFunction);
            //}

            //OB.Listeners.AddProperty(OptionName.Click, String.Format("{0}_click", ClientJavascriptID), true);


            //OB.AddProperty(OptionName.Handler, "function(){alert('sss');}", true);



            //string style = String.Empty;

            //if (CssStyle == "" || !CssStyle.ToLower().Contains("display"))
            //{
            //    style += CssStyle + "display:inline;";
            //}

            //OB.RemoveProperty(OptionName.Style);
            //OB.AddProperty(OptionName.Style, style);

            //AddExtraStyle("display", "inline");

            #endregion

            #region Menu

            if (_menu != null && Menu.Items.Count > 0)
            {
                OB.AddProperty("menu", Menu.XID, true);
            }
            else if (!String.IsNullOrEmpty(MenuID))
            {
                Menu contextMenu = ControlUtil.FindControlInUserControlOrPage(this, MenuID) as Menu;
                if (contextMenu != null)
                {
                    OB.AddProperty("menu", contextMenu.XID, true);
                }
            }


            #endregion

            #region Type

            string submitButtonScript = String.Empty;
            if (Type == ButtonType.Submit)
            {
                submitButtonScript = String.Format("F.submitbutton='{0}';", ClientID);
            }
            else if (Type == ButtonType.Reset)
            {
                OB.AddProperty("handler", JsHelper.GetFunction("F.util.reset();"), true);
            }

            #endregion

            string createScript = String.Format("var {0}=Ext.create('Ext.button.Button',{1});", XID, OB.ToString());
            AddStartupScript(submitButtonScript + createScript);
        }

        private string GetClickScript()
        {
            string disableControlJavascriptID = ClientID;
            if (!DisableControlBeforePostBack)
            {
                disableControlJavascriptID = String.Empty;
            }

            //string clientScript = OnClientClick;
            //if (Type == ButtonType.Reset)
            //{
            //    clientScript += "document.forms[0].reset();";
            //}

            return ResolveClientScript(ValidateForms, ValidateTarget, ValidateMessageBox, EnablePostBack, GetPostBackEventReference(),
                ConfirmText, ConfirmTitle, ConfirmIcon, ConfirmTarget, OnClientClick, disableControlJavascriptID);
        }

        #endregion

        #region ResolveClientScript

        /// <summary>
        /// 获取按钮客户端点击事件的脚本
        /// </summary>
        /// <param name="validateForms">验证表单列表</param>
        /// <param name="validateTarget">表单验证提示消息目标页面</param>
        /// <param name="validateMessageBox">是否显示表单验证提示对话框</param>
        /// <param name="enablePostBack">启用回发</param>
        /// <param name="postBackEventReference">回发脚本</param>
        /// <param name="confirmText">确认对话框消息</param>
        /// <param name="confirmTitle">确认对话框标题</param>
        /// <param name="confirmIcon">确认对话框图标</param>
        /// <param name="confirmTarget">确认对话框目标页面</param>
        /// <param name="onClientClick">自定义客户端点击脚本</param>
        /// <param name="disableControlJavascriptID">需要禁用的控件客户端ID</param>
        /// <returns>客户端脚本</returns>
        internal static string ResolveClientScript(string[] validateForms, Target validateTarget, bool validateMessageBox, bool enablePostBack, string postBackEventReference,
            string confirmText, string confirmTitle, MessageBoxIcon confirmIcon, Target confirmTarget, string onClientClick, string disableControlJavascriptID)
        {
            // 1. 表单验证
            string validateScript = String.Empty;
            if (validateForms != null && validateForms.Length > 0)
            {
                //JsArrayBuilder array = new JsArrayBuilder();
                //foreach (string formID in validateForms)
                //{
                //    Control control = ControlUtil.FindControl(formID);
                //    if (control != null && control is ControlBase)
                //    {
                //        array.AddProperty((control as ControlBase).ClientID);
                //    }
                //}

                JsArrayBuilder array = ControlUtil.GetControlClientIDs(validateForms);

                validateScript = String.Format("if(!F.util.validForms({0},'{1}',{2})){{return false;}}", array.ToString(), TargetHelper.GetName(validateTarget), validateMessageBox.ToString().ToLower());
            }

            // 2. 用户自定义脚本
            string clientClickScript = onClientClick;
            if (!String.IsNullOrEmpty(clientClickScript) && !clientClickScript.EndsWith(";"))
            {
                clientClickScript += ";";
            }


            // 3. 回发脚本
            string postBackScript = String.Empty;
            if (enablePostBack)
            {
                if (!String.IsNullOrEmpty(disableControlJavascriptID))
                {
                    postBackScript += String.Format("F.f_disable('{0}');", disableControlJavascriptID);
                }
                postBackScript += postBackEventReference;
            }

			// 确认对话框
            if (!String.IsNullOrEmpty(confirmText))
            {
                postBackScript = Confirm.GetShowReference(confirmText, confirmTitle, confirmIcon, postBackScript, "", confirmTarget);
            }

            return validateScript + clientClickScript + postBackScript;
        }


        #endregion

        #region IPostBackDataHandler

        /// <summary>
        /// 处理回发数据
        /// </summary>
        /// <param name="postDataKey">回发数据键</param>
        /// <param name="postCollection">回发数据集</param>
        /// <returns>回发数据是否改变</returns>
        public bool LoadPostData(string postDataKey, System.Collections.Specialized.NameValueCollection postCollection)
        {
            if (EnablePress)
            {
                bool pressed = Convert.ToBoolean(postCollection[PressedHiddenFieldID]);
                if (pressed != Pressed)
                {
                    Pressed = pressed;
                    FState.BackupPostDataProperty("Pressed");
                }
            }

            return false;
        }

        /// <summary>
        /// 触发回发数据改变事件
        /// </summary>
        public void RaisePostDataChangedEvent()
        {
            
        }

        #endregion

        #region IPostBackEventHandler

        /// <summary>
        /// 处理回发事件
        /// </summary>
        /// <param name="eventArgument">事件参数</param>
        public void RaisePostBackEvent(string eventArgument)
        {
            OnClick(EventArgs.Empty);
        }


        private static readonly object _handlerKey = new object();

        /// <summary>
        /// 按钮点击事件
        /// </summary>
        [Category(CategoryName.ACTION)]
        [Description("按钮点击事件")]
        public event EventHandler Click
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
        /// 触发按钮点击事件
        /// </summary>
        /// <param name="e">事件参数</param>
        protected virtual void OnClick(EventArgs e)
        {
            EventHandler handler = Events[_handlerKey] as EventHandler;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion

        #region oldcode

        //protected override void CreateChildControls()
        //{
        //    base.CreateChildControls();

        //    //// 添加子控件
        //    //foreach (Menu menu in Menus)
        //    //{
        //    //    menu.RenderWrapperDiv = false;
        //    //    Controls.Add(menu);
        //    //}
        //}

        //#region HiddenFieldID

        //[Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //[Description("是否按下隐藏字段的ID")]
        //protected string PressedHiddenFieldID
        //{
        //    get
        //    {
        //        return String.Format("{0}_pressed", XID);
        //    }
        //}

        //#endregion

        //public Unit MarginRight_Default = Unit.Empty;

        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue(typeof(Unit), "")]
        //[Description("右侧空白宽度")]
        //public Unit MarginRight
        //{
        //    get
        //    {
        //        object obj = BoxState["MarginRight"];
        //        return obj == null ? MarginRight_Default : (Unit)obj;
        //    }
        //    set
        //    {
        //        BoxState["MarginRight"] = value;
        //    }
        //}

        //private Unit MinWidth_Default = Unit.Empty;

        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue(typeof(Unit), "")]
        //[Description("最小宽度")]
        //public Unit MinWidth
        //{
        //    get
        //    {
        //        object obj = BoxState["MinWidth"];
        //        return obj == null ? MinWidth_Default : (Unit)obj;
        //    }
        //    set
        //    {
        //        BoxState["MinWidth"] = value;
        //    }
        //}

        //public bool LoadPostData(string postDataKey, System.Collections.Specialized.NameValueCollection postCollection)
        //{
        //    //if (EnablePress)
        //    //{
        //    //    string postValue = postCollection[PressedHiddenFieldID];
        //    //    bool postPressed = Convert.ToBoolean(postValue);
        //    //    if (Pressed != postPressed)
        //    //    {
        //    //        Pressed = postPressed;
        //    //        return true;
        //    //    }
        //    //}

        //    return false;
        //}

        //public void RaisePostDataChangedEvent()
        //{
        //    //throw new NotImplementedException();
        //}

        #endregion

    }
}
