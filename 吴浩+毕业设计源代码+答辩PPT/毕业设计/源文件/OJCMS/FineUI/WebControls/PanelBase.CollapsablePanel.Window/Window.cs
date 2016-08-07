
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    Window.cs
 * CreatedOn:   2008-05-20
 * CreatedBy:   30372245@qq.com
 * 
 * 
 * Description：
 *      ->
 *   
 * History：
 *      ->Window有很多特殊的地方：
            1.不受页面中嵌套层次的限制
            2.ClientJavascriptID和ID一样（这个不好，容易混淆多个层次中的Window，废除）
            3.不使用ClientJavascriptID（也即是不压缩js对象的名称）（这个不好，容易混淆多个层次中的Window，废除）
            4.想到一个办法，通过IFrame的url向子页面传递所在的窗口的信息（比如窗口的客户端名称）
            5.综合2，3点，现在ClientJavascriptID==ClientID，同时ClientID经过特殊处理，保证在多个页面唯一性。
 *          
 * 
 *      ->想让Ext-Window不受嵌套层次的限制（总在最外层），好办 
 *      只需在创建Window对象之前，使用Javascript向form中添加一个DIV用来放置Window对象（而不是使用RenderImmediately的方法实现）
 *      30372245@qq.com 2009-02-25 
 *      
 *      ->当前的Ext-Window可能要在父页面弹出，也就是要添加到父页面，为了放置名称的冲突，需要随机一个GUID，以便向父页面添加Ext-Window时使用
 *      30372245@qq.com 2009-02-25 
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
using System.Web.UI.Design.WebControls;

using Newtonsoft.Json;
using System.Web.UI.HtmlControls;
using System.ComponentModel.Design;

namespace FineUI
{
    //  Window控件区别于其他容器控件的地方：RenderImmediately=true，也就是说Window不会渲染为其它控件的子控件，尽管Window可以放在其它控件内
    /// <summary>
    /// 窗体控件
    /// </summary>
    [Designer("FineUI.Design.WindowDesigner, FineUI.Design")]
    [ToolboxData("<{0}:Window IsModal=\"true\" Width=\"500px\" Height=\"350px\" Title=\"Window\" BodyPadding=\"5px\" runat=\"server\"></{0}:Window>")]
    [ToolboxBitmap(typeof(Window), "toolbox.Window.bmp")]
    [Description("窗体控件")]
    [ParseChildren(true)]
    [PersistChildren(false)]
    [ControlBuilder(typeof(NotAllowWhitespaceLiteralsBuilder))]
    public class Window : CollapsablePanel, IPostBackEventHandler
    {
        #region Constructor

        /// <summary>
        /// 构造函数
        /// </summary>
        public Window()
        {
            ServerAjaxProperties.Remove("Hidden");
            ClientAjaxProperties.Add("Hidden");

            AddServerAjaxProperties();
            AddClientAjaxProperties();
        }

        #endregion

        #region private properties

        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue(true)]
        //[Description("是否将窗体标题限制在可视区域")]
        //[Browsable(false)]
        //private bool ConstrainHeader
        //{
        //    get
        //    {
        //        object obj = BoxState["ConstrainHeader"];
        //        return obj == null ? true : (bool)obj;
        //    }
        //    set
        //    {
        //        BoxState["ConstrainHeader"] = value;
        //    }
        //}


        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue(false)]
        //[Description("是否将窗体限制在可视区域")]
        //[Browsable(false)]
        //private bool Constrain
        //{
        //    get
        //    {
        //        object obj = BoxState["Constrain"];
        //        return obj == null ? false : (bool)obj;
        //    }
        //    set
        //    {
        //        BoxState["Constrain"] = value;
        //    }
        //}

        ///// <summary>
        ///// 是否内容区域为透明色
        ///// </summary>
        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue(false)]
        //[Description("是否内容区域为透明色")]
        //[Browsable(false)]
        //private bool Plain
        //{
        //    get
        //    {
        //        object obj = BoxState["Plain"];
        //        return obj == null ? false : (bool)obj;
        //    }
        //    set
        //    {
        //        BoxState["Plain"] = value;
        //    }
        //}

        #endregion

        #region Unsupported Properties

        /// <summary>
        /// 不支持此属性
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override bool ShowHeader
        {
            get
            {
                return base.ShowHeader;
            }
        }

        /// <summary>
        /// 不支持此属性
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override bool ShowBorder
        {
            get
            {
                return base.ShowBorder;
            }
        }

        #endregion

        #region GUID & IFrameName

        ///// <summary>
        ///// 这是Window非常特殊的地方
        ///// </summary>
        //[Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //[Description("控件的客户端ID")]
        //internal override string ClientJavascriptID
        //{
        //    get
        //    {
        //        return ClientID;
        //    }
        //}

        ///// <summary>
        ///// 为了放置不同页面的Window的ClientID发生冲突，加上GUID
        ///// </summary>
        //[Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //[Description("控件的客户端ID")]
        //public override string ClientID
        //{
        //    get
        //    {
        //        object obj = BoxState["ClientID"];
        //        if (obj == null)
        //        {
        //            obj = BoxState["ClientID"] = String.Format("{0}_{1}", base.ClientID, System.Guid.NewGuid().ToString("N"));
        //        }

        //        return (string)obj;
        //    }
        //}

        /// <summary>
        /// 为了放置不同页面的Window的ClientID发生冲突，加上GUID
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("GUID")]
        internal string GUID
        {
            get
            {
                object obj = FState["GUID"];
                if (obj == null)
                {
                    obj = FState["GUID"] = String.Format("{0}_{1}", XID, System.Guid.NewGuid().ToString("N"));
                }

                return (string)obj;
            }
        }

        /// <summary>
        /// [只读]Window的IFrameName必须是唯一的，在所有页面中是唯一的
        /// 所以不要手工定义Window的IFrameName
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override string IFrameName
        {
            get
            {
                return GUID;
            }
        }

        #endregion

        #region Properties


        /// <summary>
        /// 窗口的位置
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(WindowPosition.Center)]
        [Description("窗口的位置")]
        public WindowPosition WindowPosition
        {
            get
            {
                object obj = FState["WindowPosition"];
                return obj == null ? WindowPosition.Center : (WindowPosition)obj;
            }
            set
            {
                FState["WindowPosition"] = value;
            }
        }


        ///// <summary>
        ///// 是否弹出窗体
        ///// </summary>
        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue(true)]
        //[Description("是否弹出窗体")]
        //[Obsolete("请使用Hidden属性来标记是否弹出窗口")]
        //public bool Popup
        //{
        //    get
        //    {
        //        return !Hidden;
        //    }
        //    set
        //    {
        //        Hidden = !value;
        //    }
        //}


        ///// <summary>
        ///// 是否最大化
        ///// </summary>
        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue(false)]
        //[Description("是否最大化")]
        //public bool Maximized
        //{
        //    get
        //    {
        //        object obj = FState["Maximized"];
        //        return obj == null ? false : (bool)obj;
        //    }
        //    set
        //    {
        //        FState["Maximized"] = value;
        //    }
        //}


        /// <summary>
        /// 左上角位置
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(typeof(Unit), "")]
        [Description("左上角位置")]
        public Unit Top
        {
            get
            {
                object obj = FState["Top"];
                return obj == null ? Unit.Empty : (Unit)obj;
            }
            set
            {
                FState["Top"] = value;
            }
        }


        /// <summary>
        /// 左上角位置
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(typeof(Unit), "")]
        [Description("左上角位置")]
        public Unit Left
        {
            get
            {
                object obj = FState["Left"];
                return obj == null ? Unit.Empty : (Unit)obj;
            }
            set
            {
                FState["Left"] = value;
            }
        }


        /// <summary>
        /// 是否可以关闭
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("是否可以关闭")]
        public bool EnableClose
        {
            get
            {
                object obj = FState["EnableClose"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                FState["EnableClose"] = value;
            }
        }


        /// <summary>
        /// 是否可以移动
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("是否可以移动")]
        public bool EnableDrag
        {
            get
            {
                object obj = FState["EnableDrag"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                FState["EnableDrag"] = value;
            }
        }


        /// <summary>
        /// 是否可以最大化
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("是否可以最大化")]
        public bool EnableMaximize
        {
            get
            {
                object obj = FState["EnableMaximize"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                FState["EnableMaximize"] = value;
            }
        }


        /// <summary>
        /// 是否可以最小化
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("是否可以最小化")]
        public bool EnableMinimize
        {
            get
            {
                object obj = FState["EnableMinimize"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                FState["EnableMinimize"] = value;
            }
        }


        /// <summary>
        /// 最小高度
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(typeof(Unit), "100")]
        [Description("最小高度")]
        public new Unit MinHeight
        {
            get
            {
                object obj = FState["MinHeight"];
                return obj == null ? (Unit)100 : (Unit)obj;
            }
            set
            {
                FState["MinHeight"] = value;
            }
        }


        /// <summary>
        /// 最小宽度
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(typeof(Unit), "200")]
        [Description("最小宽度")]
        public new Unit MinWidth
        {
            get
            {
                object obj = FState["MinWidth"];
                return obj == null ? (Unit)200 : (Unit)obj;
            }
            set
            {
                FState["MinWidth"] = value;
            }
        }

        /// <summary>
        /// 是否模式窗口
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("是否模式窗口")]
        public bool IsModal
        {
            get
            {
                object obj = FState["IsModal"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                FState["IsModal"] = value;
            }
        }

        /// <summary>
        /// 是否可以改变窗口大小
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("是否可以改变窗口大小")]
        public bool EnableResize
        {
            get
            {
                object obj = FState["EnableResize"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                FState["EnableResize"] = value;
            }
        }


        /// <summary>
        /// 点击关闭按钮时需要执行的客户端脚本
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("点击关闭按钮时需要执行的客户端脚本")]
        public string OnClientCloseButtonClick
        {
            get
            {
                object obj = FState["OnClientCloseButtonClick"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                FState["OnClientCloseButtonClick"] = value;
            }
        }


        ///// <summary>
        ///// 关闭窗体之前弹出确认窗体内IFrame中表单改变的对话框
        ///// </summary>
        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue(false)]
        //[Description("关闭窗体之前弹出确认窗体内IFrame中表单改变的对话框")]
        //public bool EnableConfirmOnClose
        //{
        //    get
        //    {
        //        object obj = FState["EnableConfirmOnClose"];
        //        return obj == null ? false : (bool)obj;
        //    }
        //    set
        //    {
        //        FState["EnableConfirmOnClose"] = value;
        //    }
        //}

        /// <summary>
        /// 关闭窗体的动作（点击关闭按钮或者按 ESC 键都会执行此动作）
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(CloseAction.Hide)]
        [Description("关闭窗体的动作（点击关闭按钮或者按 ESC 键都会执行此动作）")]
        public CloseAction CloseAction
        {
            get
            {
                object obj = FState["CloseAction"];
                return obj == null ? CloseAction.Hide : (CloseAction)obj;
            }
            set
            {
                FState["CloseAction"] = value;
            }
        }


        ///// <summary>
        ///// 弹出窗口的目标位置，支持_self,_parent
        ///// </summary>
        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue("_self")]
        //[Description("弹出窗口的目标位置，支持_self,_parent")]
        //public string Target
        //{
        //    get
        //    {
        //        object obj = BoxState["Target"];
        //        return obj == null ? "_self" : (string)obj;
        //    }
        //    set
        //    {
        //        BoxState["Target"] = value;
        //    }
        //}

        /// <summary>
        /// 弹出窗口的目标位置（只有在EnableIFrame=true的情况下有效）
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(Target.Self)]
        [Description("弹出窗口的目标位置（只有在EnableIFrame=true的情况下有效）")]
        public Target Target
        {
            get
            {
                object obj = FState["Target"];
                return obj == null ? Target.Self : (Target)obj;
            }
            set
            {
                FState["Target"] = value;
            }
        }

        ///// <summary>
        ///// 内容区域颜色是否和边框颜色相同，默认为true
        ///// </summary>
        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue(true)]
        //[Description("内容区域颜色是否和边框颜色相同，默认为true")]
        //public bool Plain
        //{
        //    get
        //    {
        //        object obj = FState["Plain"];
        //        return obj == null ? true : (bool)obj;
        //    }
        //    set
        //    {
        //        FState["Plain"] = value;
        //    }
        //}

        #region old code

        //private CloseAction CloseAction_Default = CloseAction.None;

        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue(CloseAction.None)]
        //[Description("关闭窗体的动作")]
        //public CloseAction CloseAction
        //{
        //    get
        //    {
        //        object obj = BoxState["CloseAction"];
        //        return obj == null ? CloseAction_Default : (CloseAction)obj;
        //    }
        //    set
        //    {
        //        BoxState["CloseAction"] = value;
        //    }
        //}


        //private string ClosePostBackArgument_Default = "";

        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue("")]
        //[Description("关闭窗体引起回发的参数")]
        //public string ClosePostBackArgument
        //{
        //    get
        //    {
        //        object obj = BoxState["ClosePostBackArgument"];
        //        return obj == null ? ClosePostBackArgument_Default : (string)obj;
        //    }
        //    set
        //    {
        //        BoxState["ClosePostBackArgument"] = value;
        //    }
        //} 

        //private string DefaultButtonID_Default = "";

        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue("")]
        //[Description("缺省按钮ID")]
        //public string DefaultButtonID
        //{
        //    get
        //    {
        //        object obj = BoxState["DefaultButtonID"];
        //        return obj == null ? DefaultButtonID_Default : (string)obj;
        //    }
        //    set
        //    {
        //        BoxState["DefaultButtonID"] = value;
        //    }
        //}



        ///// <summary>
        ///// 在父窗口中显示（根据Target属性判断）
        ///// </summary>
        //internal bool ShowInParent
        //{
        //    get
        //    {
        //        if (!String.IsNullOrEmpty(Target) && Target.ToLower() == "_parent")
        //        {
        //            return true;
        //        }
        //        return false;
        //    }
        //}
        #endregion

        #endregion

        #region Constrain/ConstrainHeader

        // 目前，没法加这两个属性，因为Window是渲染到<form>标签中的一个DIV中的，而这个DIV如果是全屏显示的话会遮盖住后面的元素。
        ///// <summary>
        ///// 强制整个窗体始终位于页面的可视区域内
        ///// </summary>
        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue(false)]
        //[Description("强制整个窗体始终位于页面的可视区域内")]
        //public bool Constrain
        //{
        //    get
        //    {
        //        object obj = FState["Constrain"];
        //        return obj == null ? false : (bool)obj;
        //    }
        //    set
        //    {
        //        FState["Constrain"] = value;
        //    }
        //}

        ///// <summary>
        ///// 强制窗体的标题栏始终位于页面的可视区域内
        ///// </summary>
        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue(false)]
        //[Description("强制窗体的标题栏始终位于页面的可视区域内")]
        //public bool ConstrainHeader
        //{
        //    get
        //    {
        //        object obj = FState["ConstrainHeader"];
        //        return obj == null ? false : (bool)obj;
        //    }
        //    set
        //    {
        //        FState["ConstrainHeader"] = value;
        //    }
        //}

        #endregion

        #region RenderBeginTag/RenderEndTag

        /// <summary>
        /// 不向页面输出任何HTML代码，通过Javascript代码添加DIV标签
        /// </summary>
        /// <param name="writer">输出流</param>
        protected override void RenderBeginTag(HtmlTextWriter writer)
        {
            //base.RenderBeginTag(writer);

            //writer.Write(String.Format("<input type=\"hidden\" value=\"{1}\" id=\"{0}\" name=\"{0}\"/>",
            //    PopUpHiddenFieldID, Popup.ToString().ToLower()));

            //writer.Write(String.Format("<input type=\"hidden\" value=\"{1}\" id=\"{0}\" name=\"{0}\"/>",
            //    TitleHiddenFieldID, Title.ToString()));

            //// 如果启用IFrame
            //if (EnableIFrame)
            //{
            //    writer.Write(String.Format("<input type=\"hidden\" value=\"{1}\" id=\"{0}\" name=\"{0}\"/>",
            //        IFrameUrlHiddenFieldID, IFrameUrl.ToString()));
            //}
        }

        /// <summary>
        /// 不向页面输出任何HTML代码，通过Javascript代码添加DIV标签
        /// </summary>
        /// <param name="writer">输出流</param>
        protected override void RenderEndTag(HtmlTextWriter writer)
        {
            //base.RenderEndTag(writer);
        }

        #endregion

        #region OnPreRender

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("是否隐藏窗体")]
        private string HiddenHiddenFieldID
        {
            get
            {
                return String.Format("{0}_Hidden", ClientID);
            }
        }

        /// <summary>
        /// 渲染 HTML 之前调用（AJAX回发）
        /// </summary>
        protected override void OnAjaxPreRender()
        {
            base.OnAjaxPreRender();

            StringBuilder sb = new StringBuilder();
            //if (PropertyModified("Text"))
            //{
            //    sb.AppendFormat("{0}.setValue({1});", XID, JsHelper.Enquote(Text));
            //}

            AddAjaxScript(sb);
        }

        /// <summary>
        /// 渲染 HTML 之前调用（页面第一次加载或者普通回发）
        /// </summary>
        protected override void OnFirstPreRender()
        {
            base.OnFirstPreRender();

            //ResourceManager.Instance.AddJavaScriptComponent("window");

            #region old code

            ////string windowObj = "window";
            //bool showInParent = false;

            //if (!String.IsNullOrEmpty(Target) && Target.ToLower() == "_parent")
            //{
            //    //windowObj = "parent.window";
            //    showInParent = true;
            //}


            //// 以后IFrame中的高度自动处理，不会涉及这块的内容
            //// 因为Window渲染时，如果设置高度600px，则实际生成的高度有601px，所以这里减一
            //if (Height != Unit.Empty)
            //{
            //    OB.RemoveProperty(OptionName.Height);
            //    OB.AddProperty(OptionName.Height, Height.Value - 1);
            //}

            #endregion

            #region 验证EnableIFrame和Target是否冲突
            
            if (!EnableIFrame && Target != Target.Self)
            {
                Target = Target.Self;
            } 

            #endregion

            #region Properties

            OB.AddProperty("closeAction", "hide");

            //if (EnableClose != EnableClose_Default) OB.AddProperty(OptionName.Closable, EnableClose);
            //OB.AddProperty(OptionName.Constrain, Constrain);
            //OB.AddProperty(OptionName.ConstrainHeader, ConstrainHeader);
            //OB.AddProperty("plain", Plain);
            
            OB.AddProperty("draggable", EnableDrag);

            OB.AddProperty("minimizable", EnableMinimize);
            OB.AddProperty("minHeight", MinHeight.Value);
            OB.AddProperty("minWidth", MinWidth.Value);

            OB.AddProperty("resizable", EnableResize);

            //OB.AddProperty("maximized", Maximized);


            // 由于renderTo不是Ext.getBody，所以modal不能正常工作
            OB.AddProperty("modal", IsModal);


            // 在 F.util.init 中定义
            OB.AddProperty("manager", "F.window_default_group", true);


            // 此Window显示的位置
            //OB.AddProperty("box_property_show_in_parent", ShowInParent);
            OB.AddProperty("f_property_target", TargetHelper.GetName(Target));
            OB.AddProperty("f_property_guid", GUID);
            OB.AddProperty("f_property_left", Left != Unit.Empty ? Convert.ToInt32(Left.Value).ToString() : "");
            OB.AddProperty("f_property_top", Top != Unit.Empty ? Convert.ToInt32(Top.Value).ToString() : "");
            OB.AddProperty("f_property_position", WindowPosition == WindowPosition.GoldenSection ? "true" : "false", true);

            if (!EnableAjax)
            {
                OB.AddProperty("f_property_enable_ajax", false);
            }

            //if (Constrain)
            //{
            //    OB.AddProperty("constrain", true);
            //}

            //if (ConstrainHeader)
            //{
            //    OB.AddProperty("constrainHeader", true);
            //}


            
            // 这个为了在客户端生成 PostBack 脚本，比如 __doPostBack('ctl00$ContentPlaceHolder1$Toolbar1$testwindow','')
            OB.AddProperty("name", UniqueID);

            #endregion

            #region IconUrl

            if (!String.IsNullOrEmpty(IconUrl))
            {
                // 重新对PanelBase中的IconUrl进行定义
                // 因为Window控件可能会在父页面打开，所以在页面中添加CSS的方式是不行的。
                // Modified by sanshi.ustc@gamil.com at 2009-8-1

                // 首先删除已经添加的CSS样式
                RemoveStartupCSS(String.Format("f-{0}-panelbase-icon", XID));

                string className = String.Format("f-{0}-window-icon", GUID);

                var addCSSPrefix = String.Empty;
                if (Target == Target.Parent)
                {
                    addCSSPrefix = "parent.";
                }
                else if (Target == Target.Top)
                {
                    addCSSPrefix = "top.";
                }
                string addCSSScript = String.Format("{0}F.addCSS('{1}','{2}');", addCSSPrefix, className, StyleUtil.GetNoRepeatBackgroundStyle("." + className, ResolveUrl(IconUrl)));


                // 这里不需要extWindow渲染之前才添加CSS样式，只需要在页面加载完毕后就能添加此CSS样式
                //OB.Listeners.AddProperty("beforerender", String.Format("function(){{{0}}}", addCSSScript), true);
                AddStartupAbsoluteScript(addCSSScript);


                OB.AddProperty("iconCls", className);

                //AddStartupScript(this, "F.util.addCSS('xxxxxxxxxxxxxxxx','');");
                //AddStartupScript(this, "Ext.DomHelper.append(Ext.fly(document.getElementsByTagName('head')[0]),{tag: 'style',type: 'text/css'});");
                //AddStartupScript(this, "Ext.DomHelper.append(document.getElementsByTagName('head')[0], '<style type=\"text/css\"></style>');");
            }


            #endregion

            #region boxHideScript

            #region old code

            ////string hideFunctionId = String.Format("{0}_hide", ClientJavascriptID);

            //// 1.正常关闭
            //StringBuilder boxHideSB = new StringBuilder();

            //boxHideSB.Append("var panel=null;");
            //if (ShowInParent)
            //{
            //    boxHideSB.Append("var panel=this.box_parent_window;");
            //}
            //else
            //{
            //    boxHideSB.Append("var panel=this;");
            //}




            //boxHideSB.AppendFormat("Ext.get('{0}').dom.value='false';", PopUpHiddenFieldID);
            //// 清空iframe的src，好像不起作用
            //if (EnableIFrame)
            //{
            //    //boxHideSB.AppendFormat("{0}.setSrc('#');", IFrameID);
            //    //boxHideSB.AppendFormat("Ext.get('{0}').dom.innerHTML='';", ChildrenContentID);
            //    //boxHideSB.AppendFormat("panel.body.dom.innerHTML='';");
            //    //boxHideSB.AppendFormat("panel.box_property_iframe_loaded=false;");
            //    boxHideSB.AppendFormat("panel.body.first().dom.src='about:blank';");//alert(panel.body.first().dom.src);
            //    //boxHideSB.AppendFormat("panel.box_property_iframe_url='about:blank';");

            //}

            //boxHideSB.AppendFormat("panel.hide();");

            //// 以后可能还要做，回收垃圾
            ////if (ShowInParent)
            ////{
            ////    boxHideSB.AppendFormat("parent.window.Ext.get('{0}').remove();", ClientJavascriptID);
            ////    boxHideSB.Append("this.box_parent_window=null;");
            ////}

            //// 1.正常关闭
            //OB.AddProperty("box_hide", JsHelper.GetFunctionWrapper(boxHideSB.ToString()), true); 

            #endregion

            /*
             * 隐藏窗体的JS代码在 extender.js 中定义
             * 
            string hideFunctionScript = String.Format("function(){{F.wnd.hide(this, '{0}', {1}, '{2}', '{3}');}}",
                TargetHelper.GetName(Target),
                EnableIFrame.ToString().ToLower(),
                HiddenHiddenFieldID,
                GUID);
            OB.AddProperty("box_hide", hideFunctionScript, true);

           
            OB.AddProperty("box_hide_refresh", JsHelper.GetFunction("this.box_hide();window.location.reload();"), true);

            OB.AddProperty("box_hide_postback", String.Format("function(argument){{this.box_hide();{0}}}", GetPostBackEventReference("$ARG$").Replace("'$ARG$'", "argument")), true);
            */

            #endregion

            #region boxShowScript

            #region old code

            //X.c1 = new Ext.Window({
            //renderTo: "__Window2_wrapper", id: "Window2",
            //width: 650, height: 450, bodyStyle: "",
            //border: true, box_property_iframe: true, box_property_iframe_url: "",
            //box_property_iframe_name: "c1_iframe", box_property_iframe_loaded: false,
            //animCollapse: false, collapsible: false, collapsed: false,
            //title: " 弹出的窗口 2", closeAction: "hide", plain: false, modal: true,
            //draggable: true, maximizable: false, minimizable: false, minHeight: 100,
            //minWidth: 200, resizable: false, manager: X.window_default_group,
            //box_hide: function() {
            //    var panel = null; var panel = this.box_parent_window;
            //    Ext.get('__c1_popup').dom.value = 'false';
            //    panel.body.first().dom.src = 'about:blank';
            //    panel.hide();
            //},
            //box_hide_refresh: function() {
            //    this.box_hide();
            //    window.location = window.location;
            //},
            //box_hide_postback: function(argument) {
            //    this.box_hide();
            //    __doPostBack('Window2', argument);
            //},
            //box_show: function(iframeUrl, windowTitle) {
            //    var panel = null;
            //    if (!this.box_parent_window) {
            //        if (!parent.window.Ext.get('__Window2_wrapper')) {
            //            Ext.DomHelper.append(parent.window.document.forms[0], '<div id="__Window2_wrapper" style="display:inline;"></div>');
            //        } else {
            //            parent.window.Ext.get('__Window2_wrapper').dom.innerHTML = '';
            //        }
            //        this.box_parent_window = new parent.window.Ext.Window(this.cloneConfig({
            //            manager: parent.window.X.window_default_group,
            //            id: "c1",
            //            box_hide: null, box_hide_refresh: null,
            //            box_hide_postback: null, box_show: null,
            //            box_property_frame_element_name: window.frameElement.name
            //        }));
            //    }
            //    var panel = this.box_parent_window;
            //    if (iframeUrl != '') {
            //        box_resolveIFrameElement(panel, iframeUrl);
            //    }
            //    if (windowTitle != '') {
            //        panel.setTitle(windowTitle);
            //    }
            //    var bodySize = parent.window.Ext.getBody().getSize();
            //    var windowSize = panel.getSize();
            //    var leftTop = box_calculateGoldenPosition(bodySize, windowSize);
            //    panel.setPosition(leftTop.left, leftTop.top);
            //    Ext.get('__c1_popup').dom.value = 'true';
            //    panel.show();
            //},
            //closable: false,
            //tools: [{ id: "close",
            //    qtip: "关闭此窗口",
            //    handler: function(event, toolEl, panel) {
            //        box_getIFrameWindowObject(X.c1.box_parent_window).X.box_pageStateChanged();
            //    } }]
            //});

            ///////////////////////////////////////////////////////////

            //StringBuilder boxShowSB = new StringBuilder();
            //boxShowSB.Append("var panel=null;");
            //if (ShowInParent)
            //{
            //    boxShowSB.Append("if(!this.box_parent_window){");

            //    boxShowSB.AppendFormat("if(!parent.window.Ext.get('{0}')){{Ext.DomHelper.append(parent.window.document.forms[0],'<div id=\"{0}\" style=\"display:inline;\"></div>');}}else{{parent.window.Ext.get('{0}').dom.innerHTML='';}}", WrapperID);
            //    //// 添加Manager
            //    //OB.AddProperty(OptionName.Manager, String.Format("{1}", ResourceManager.WINDOW_DEFAULT_GROUP_ID), true);

            //    JsObjectBuilder configBuilder = new JsObjectBuilder();
            //    configBuilder.AddProperty("manager", "parent.window." + ResourceManager.WINDOW_DEFAULT_GROUP_ID, true);
            //    // 注意：一定要传递参数进来，否则的话ext会自动生成id
            //    // An id property can be passed on this object, otherwise one will be generated to avoid duplicates.
            //    configBuilder.AddProperty("id", ClientJavascriptID);
            //    configBuilder.AddProperty("box_hide", "null", true);
            //    configBuilder.AddProperty("box_hide_refresh", "null", true);
            //    configBuilder.AddProperty("box_hide_postback", "null", true);
            //    configBuilder.AddProperty("box_show", "null", true);
            //    //configBuilder.AddProperty("draggable", true);

            //    // 需要设置本Window所在页面的iframe的名称
            //    configBuilder.AddProperty("box_property_frame_element_name", "window.frameElement.name", true);

            //    //configBuilder.AddProperty("box_property_frame_element_name", "window.frameElement.name", true);


            //    boxShowSB.AppendFormat("this.box_parent_window=new parent.window.Ext.Window(this.cloneConfig({0}));", configBuilder);

            //    boxShowSB.Append("}");

            //    boxShowSB.AppendFormat("var panel=this.box_parent_window;");
            //}
            //else
            //{
            //    boxShowSB.Append("var panel=this;");
            //}


            //// 将IFrameUrl的设置放在显示弹出窗口值
            //boxShowSB.Append("if(iframeUrl!=''){");   // alert(new Date()-time11);
            ////boxShowSB.Append("\r\n");
            ////boxShowSB.AppendFormat("{0}.setSrc(iframeUrl);", IFrameID);
            ////boxShowSB.AppendFormat("{0}.box_property_iframe_url=iframeUrl;", ClientJavascriptID);
            //boxShowSB.AppendFormat("box_resolveIFrameElement(panel,iframeUrl);");
            ////boxShowSB.AppendFormat("Ext.get('{0}').dom.value=iframeUrl;", IFrameUrlHiddenFieldID);
            ////boxShowSB.Append("\r\n");
            //boxShowSB.Append("}");


            //boxShowSB.Append("if(windowTitle!=''){");
            //boxShowSB.AppendFormat("panel.setTitle(windowTitle);");
            ////boxShowSB.AppendFormat("Ext.get('{0}').dom.value=windowTitle;", TitleHiddenFieldID);
            //boxShowSB.Append("}");

            //// 如果定义了左上角的位置
            //if (Top != Unit.Empty && Left != Unit.Empty)
            //{
            //    // 设置了Top/Left
            //    boxShowSB.AppendFormat("panel.setPosition({0},{1});", Left.Value, Top.Value);
            //}
            //else
            //{
            //    // 如果没有定义左上角的位置
            //    if (WindowPosition == WindowPositionType.GoldenSection)
            //    {
            //        // 1.使用黄金分割点
            //        // TOP: Vertical = (screen.height - (screen.height/1.618)) - (pop-up_height/2)
            //        // Left: Horizontal = (screen.width - pop-up_width)/2
            //        if (ShowInParent)
            //        {
            //            boxShowSB.Append("var bodySize=parent.window.Ext.getBody().getSize();");
            //        }
            //        else
            //        {
            //            boxShowSB.Append("var bodySize=Ext.getBody().getSize();");
            //        }
            //        boxShowSB.Append("var windowSize=panel.getSize();");
            //        // 计算黄金分割点
            //        boxShowSB.Append("var leftTop=box_calculateGoldenPosition(bodySize,windowSize);");
            //        boxShowSB.Append("panel.setPosition(leftTop.left,leftTop.top);");
            //    }
            //    else
            //    {
            //        // 2.中间位置
            //        boxShowSB.AppendFormat("panel.alignTo(Ext.getBody(), \"c-c\");");
            //    }
            //}
            //boxShowSB.AppendFormat("Ext.get('{0}').dom.value='true';", PopUpHiddenFieldID);
            //boxShowSB.AppendFormat("panel.show();");  //alert(new Date()-time11)
            ////boxShowSB.Append("var time_2=new Date();if(time_1){alert(time_2-time_1);}");


            //string boxShowFunction = String.Format("function(iframeUrl,windowTitle){{{0}}}", boxShowSB.ToString());
            ////string boxShowScript = String.Format("{0}_show={1};", ClientJavascriptID, boxShowFunction);
            //OB.AddProperty("box_show", boxShowFunction, true); 

            #endregion

            /*
            string showFunctionScript = String.Format("function(iframeUrl, windowTitle){{F.wnd.show(this, iframeUrl, windowTitle, '{0}', '{1}', {2}, '{3}');}}",
                Left != Unit.Empty ? Convert.ToInt32(Left.Value).ToString() : "",
                Top != Unit.Empty ? Convert.ToInt32(Top.Value).ToString() : "",
                WindowPosition == WindowPosition.GoldenSection ? "true" : "false",
                HiddenHiddenFieldID);
            OB.AddProperty("f_show", showFunctionScript, true);
            */

            #endregion

            #region tools

            #region old code

            //string closeButtonClickScript = String.Empty;

            //closeButtonClickScript += "\r\n";

            //if (EnableClose)
            //{
            //    #region old code

            //    //string closeScript = String.Empty;
            //    //if (CloseAction == CloseAction.None)
            //    //{
            //    //    closeScript = String.Format("(this.{0}_hide).createDelegate(this)", ClientJavascriptID);
            //    //}
            //    //else if (CloseAction == CloseAction.PostBack)
            //    //{
            //    //    closeScript = String.Format("(this.{0}_hide_postback).createDelegate(this,['{1}'])", ClientJavascriptID, ClosePostBackArgument);
            //    //}
            //    //else if (CloseAction == CloseAction.Refresh)
            //    //{
            //    //    closeScript = String.Format("(this.{0}_hide_refresh).createDelegate(this)", ClientJavascriptID);
            //    //}


            //    //string closeButtonClickScript = String.Format("{0}.tools.close.on('click',{1},this);", ClientJavascriptID, closeScript);
            //    //AddAbsoluteStartupScript( closeButtonClickScript); 

            //    #endregion

            //    string closeButtonScript = OnClientCloseButtonClick;
            //    if (String.IsNullOrEmpty(closeButtonScript))
            //    {
            //        closeButtonScript = GetCloseReference();
            //    }
            //    closeButtonScript = String.Format("function(e){{{0}}}", closeButtonScript);

            //    // 要先取消 close 注册的事件
            //    closeButtonClickScript += String.Format("{0}.tools.close.removeAllListeners();X.{0}.tools.close.on('click',{1},box);", ClientJavascriptID, closeButtonScript);
            //    //AddAbsoluteStartupScript( closeButtonClickScript);
            //} 
            #endregion

            //JsArrayBuilder toolsBuilder = new JsArrayBuilder();

            if (EnableMaximize)
            {
                OB.AddProperty("maximizable", true);

                // 这个事件可以处理两种情况，一是点击最大化按钮，二是双击Window标题栏最大化
                //OB.Listeners.AddProperty("maximize", "function(win){F.wnd.fixMaximize(win);}", true);
                AddListener("maximize", "F.wnd.fixMaximize(win);", "win");

                //OB.Listeners.AddProperty("resize", "function(win,width,height){console.log(width + ' - ' +height);}", true);
                //JsObjectBuilder maxObj = new JsObjectBuilder();
                //maxObj.AddProperty("type", "maximize");
                //maxObj.AddProperty("handler", String.Format("function(event,toolEl,win){{{0}}}", "win.maximize();"), true);
                //toolsBuilder.AddProperty(maxObj);

                //JsObjectBuilder minObj = new JsObjectBuilder();
                //minObj.AddProperty("type", "restore");
                //minObj.AddProperty("hidden", true);
                //minObj.AddProperty("handler", String.Format("function(event,toolEl,win){{{0}}}", "win.restore();"), true);
                //toolsBuilder.AddProperty(minObj);


                //// This is a bug of Extjs.
                //// If the window is not render to window.body, the maximize button works abnormal.
                //OB.Listeners.AddProperty("maximize", "function(window){var bodySize=Ext.getBody().getViewSize();window.setSize(bodySize.width,bodySize.height);}", true);
            }
            else
            {
                OB.AddProperty("maximizable", false);
            }

            

            if (EnableClose)
            {
                string closeScript = String.Empty;

                OB.AddProperty("closable", true);

                if (!String.IsNullOrEmpty(OnClientCloseButtonClick))
                {
                    closeScript = OnClientCloseButtonClick;
                }
                else
                {
                    //if (EnableConfirmOnClose)
                    //{
                    //    switch (CloseAction)
                    //    {
                    //        case CloseAction.Hide:
                    //            closeScript = GetConfirmHideReference();
                    //            break;
                    //        case CloseAction.HideRefresh:
                    //            closeScript = GetConfirmHideRefreshReference();
                    //            break;
                    //        case CloseAction.HidePostBack:
                    //            closeScript = GetConfirmHidePostBackReference();
                    //            break;
                    //    }
                    //}
                    //else
                    //{
                        switch (CloseAction)
                        {
                            case CloseAction.Hide:
                                closeScript = GetHideReference();
                                break;
                            case CloseAction.HideRefresh:
                                closeScript = GetHideRefreshReference();
                                break;
                            case CloseAction.HidePostBack:
                                closeScript = GetHidePostBackReference();
                                break;
                        }
                    //}
                }

                //JsObjectBuilder closeObj = new JsObjectBuilder();
                //closeObj.AddProperty("type", "close");
                //closeObj.AddProperty("qtip", "F.wnd.closeButtonTooltip", true);
                //if (!String.IsNullOrEmpty(closeScript))
                //{
                //    // ESC 按键和右上角的关闭按钮使用相同的事件处理函数
                //    string closeFunction = JsHelper.GetFunction(closeScript);
                //    closeObj.AddProperty("handler", closeFunction, true);
                //    OB.AddProperty("onEsc", closeFunction, true);

                //    // TODO:这样会死循环
                //    //OB.Listeners.AddProperty("beforehide", JsHelper.GetFunction(closeScript + "return false;"), true);
                //}

                //toolsBuilder.AddProperty(closeObj);


                //// ESC 按键和右上角的关闭按钮使用相同的事件处理函数
                //string closeFN = XID + "_close";
                //closeScript = String.Format("var {0}={1};", closeFN, JsHelper.GetFunction(closeScript + "return false;"));

                //// 用户按ESC键关闭窗口
                //OB.AddProperty("onEsc", closeFN, true);
                //// 用户点击右上角关闭按钮关闭窗口
                //OB.Listeners.AddProperty("beforeclose", closeFN, true);


                // 【点击右上角关闭按钮】和【用户按ESC键】都会调用 beforeclose 事件处理函数，return false; 表示自行处理关闭事件
                AddListener("beforeclose", closeScript + "return false;");
            }
            else
            {
                OB.AddProperty("closable", false);
            }

            #endregion

            #region Show Window

            string showWindowScript = String.Empty;

            // 我们不依赖于extjs的hidden配置属性，而是手工调用
            OB.RemoveProperty("hidden");

            // 如果页面第一次加载或者非原生回发，需要显示窗体
            if (!Hidden)
            {
                showWindowScript = GetShowReference().Replace(ScriptID + ".", XID + ".");
                //AddStartupAbsoluteScript(GetShowReference());
            }


            #endregion

            #region HiddenFields

            //
            // 有一个原则：只要是能在客户端改变的属性，均要在回发时保持状态，否则会出现莫名奇妙的问题
            //
            string hiddenFieldsScript = String.Empty;

            hiddenFieldsScript += GetSetHiddenFieldValueScript(HiddenHiddenFieldID, Hidden.ToString().ToLower());
            //hiddenFieldsScript += "\r\n";

            //hiddenFieldsScript += GetAddHiddenFieldScript(TitleHiddenFieldID, Title.ToString());

            //// 如果启用IFrame
            //if (EnableIFrame)
            //{
            //    hiddenFieldsScript += GetAddHiddenFieldScript(IFrameUrlHiddenFieldID, IFrameUrl.ToString());
            //}
            #endregion

            #region AddStartupScript

            // 无论把 Window 控件放在哪里（母版页，或者用户控件中都行），因为下面会输出 Window 在页面上的节点，所以一定要输出 renderTo 
            OB.AddProperty("renderTo", WrapperID);


            // 创建Window对象
            string jsContent = String.Format("var {0}=Ext.create('Ext.window.Window',{1});", XID, OB.ToString());

            // 通过Javascript的方式向页面添加Window的DIV包裹容器
            string addWrapperScript = String.Format("F.util.appendFormNode('{0}');", String.Format("<div class=\"x-window-wrapper\" id=\"{0}\"></div>", WrapperID));
            //addWrapperScript += "\r\n";

            // 添加隐藏表单字段的脚本和创建Window对象的脚本
            jsContent = addWrapperScript + hiddenFieldsScript + jsContent + showWindowScript;
            AddStartupScript(jsContent);

            #endregion

        }

        /// <summary>
        /// 获取 Hidden 属性改变的 JavaScript 脚本
        /// Window 控件需要特殊处理，而不是像其他客户端组件一样调用 f_setVisible 函数
        /// </summary>
        protected override string GetHiddenPropertyChangedScript()
        {
            if (PropertyModified("Hidden"))
            {
                return Hidden ? GetHideReference() : GetShowReference();

            }
            return String.Empty;
        }

        #region old code

        ///// <summary>
        ///// 隐藏窗体，并且执行窗体关闭动作
        ///// </summary>
        ///// <returns></returns>
        //private string GetHideFunctionId()
        //{
        //    if (CloseAction == CloseAction.Refresh)
        //    {
        //        return String.Format("{0}_hide_refresh", ClientJavascriptID);
        //    }
        //    else if (CloseAction == CloseAction.PostBack)
        //    {
        //        return String.Format("{0}_hide_postback", ClientJavascriptID);
        //    }
        //    else
        //    {
        //        return String.Format("{0}_hide", ClientJavascriptID);
        //    }
        //}

        #endregion

        #endregion

        #region GetSaveStateReference

        /// <summary>
        /// 保存服务器控件的ClientID
        /// 可以调用ActiveWindow.GetWriteBackValueReference在子页面向这些服务器控件写入值
        /// </summary>
        public string GetSaveStateReference(params string[] values)
        {
            string valuesJS = JsHelper.EnquoteStringArray(values);

            return String.Format("{0}.f_property_save_state_control_client_ids={1};", ScriptID, valuesJS);
        }

        ///// <summary>
        ///// 保存值到Window对象中
        ///// </summary>
        //public string GetSaveValueReference(bool value)
        //{
        //    return String.Format("{0}.box_bool_value='{1}';", ClientJavascriptID, value.ToString().ToLower());
        //}

        #endregion

        #region GetIFramePostBackEventReference
        /// <summary>
        /// 获取窗体内IFrame回发页面的客户端脚本（比如：__doPostBack('','eventArgument');)
        /// </summary>
        /// <param name="eventArgument">事件参数</param>
        /// <returns>客户端脚本</returns>
        public string GetIFramePostBackEventReference(string eventArgument)
        {
            return String.Format("F.wnd.getIFrameWindowObject({0}).__doPostBack('',{1});", ScriptID, JsHelper.Enquote(eventArgument));
        }

        /// <summary>
        /// 获取窗体内IFrame回发的客户端脚本（触发PageManager的CustomEvent事件）
        /// </summary>
        /// <param name="eventArgument">事件参数</param>
        /// <returns>客户端脚本</returns>
        public string GetIFrameCustomEventReference(string eventArgument)
        {
            return GetIFrameCustomEventReference(eventArgument, false);
        }

        /// <summary>
        /// 获取窗体内IFrame回发的客户端脚本（触发PageManager的CustomEvent事件）
        /// </summary>
        /// <param name="eventArgument">事件参数</param>
        /// <param name="validateForms">是否在回发前验证表单（在PageManager上进行表单配置）</param>
        /// <returns>客户端脚本</returns>
        public string GetIFrameCustomEventReference(string eventArgument, bool validateForms)
        {
            return String.Format("F.wnd.getIFrameWindowObject({0}).F.f_customEvent({1}, {2});", ScriptID, JsHelper.Enquote(eventArgument), validateForms.ToString().ToLower());
        }
        #endregion

        #region GetShowReference

        /// <summary>
        /// 获取显示窗体的客户端脚本
        /// </summary>
        /// <returns>客户端脚本</returns>
        public string GetShowReference()
        {
            string iframeUrl = String.Empty;
            if (EnableIFrame)
            {
                iframeUrl = IFrameUrl;
            }

            return GetShowReference(iframeUrl, String.Empty);
        }

        /// <summary>
        /// 获取显示窗体的客户端脚本
        /// </summary>
        /// <param name="iframeUrl">IFrame地址</param>
        /// <returns>客户端脚本</returns>
        public string GetShowReference(string iframeUrl)
        {
            return GetShowReference(iframeUrl, String.Empty);
        }

        /// <summary>
        /// 获取显示窗体的客户端脚本
        /// </summary>
        /// <param name="iframeUrl">IFrame地址</param>
        /// <param name="windowTitle">窗体标题</param>
        /// <returns>客户端脚本</returns>
        public string GetShowReference(string iframeUrl, string windowTitle)
        {
            return GetShowReference(iframeUrl, windowTitle, Unit.Empty, Unit.Empty);
        }

        /// <summary>
        /// 获取显示窗体的客户端脚本
        /// </summary>
        /// <param name="width">窗体宽度</param>
        /// <param name="height">窗体高度</param>
        /// <returns>客户端脚本</returns>
        public string GetShowReference(Unit width, Unit height)
        {
            string iframeUrl = String.Empty;
            if (EnableIFrame)
            {
                iframeUrl = IFrameUrl;
            }

            return GetShowReference(iframeUrl, String.Empty, width, height);
        }

        /// <summary>
        /// 获取显示窗体的客户端脚本
        /// </summary>
        /// <param name="windowTitle">窗体标题</param>
        /// <param name="width">窗体宽度</param>
        /// <param name="height">窗体高度</param>
        /// <returns>客户端脚本</returns>
        public string GetShowReference(string windowTitle, Unit width, Unit height)
        {
            string iframeUrl = String.Empty;
            if (EnableIFrame)
            {
                iframeUrl = IFrameUrl;
            }

            return GetShowReference(iframeUrl, windowTitle, width, height);
        }

        /// <summary>
        /// 获取显示窗体的客户端脚本
        /// </summary>
        /// <param name="iframeUrl">IFrame地址</param>
        /// <param name="windowTitle">窗体标题</param>
        /// <param name="width">窗体宽度</param>
        /// <param name="height">窗体高度</param>
        /// <returns>客户端脚本</returns>
        public string GetShowReference(string iframeUrl, string windowTitle, Unit width, Unit height)
        {
            if (!String.IsNullOrEmpty(iframeUrl))
            {
                iframeUrl = ResolveIFrameUrl(iframeUrl);
            }

            iframeUrl = JsHelper.EnquoteWithScriptTag(iframeUrl);
            windowTitle = JsHelper.Enquote(windowTitle);

            if (width != Unit.Empty && height != Unit.Empty)
            {
                return String.Format("{0}.f_show({1},{2},{3},{4});", ScriptID,
                    iframeUrl,
                    windowTitle,
                    width.Value,
                    height.Value);
            }
            else
            {
                return String.Format("{0}.f_show({1},{2});", ScriptID,
                   iframeUrl,
                   windowTitle);
            }
        }

        /// <summary>
        /// 获取最大化窗体尺寸的客户端脚本
        /// </summary>
        /// <returns>客户端脚本</returns>
        public string GetMaximizeReference()
        {
            return String.Format("{0}.f_maximize();", ScriptID);
        }

        /// <summary>
        /// 获取恢复窗体尺寸的客户端脚本
        /// </summary>
        /// <returns>客户端脚本</returns>
        public string GetRestoreReference()
        {
            return String.Format("{0}.f_restore();", ScriptID);
        }

        /// <summary>
        /// 获取最小化窗体尺寸的客户端脚本
        /// </summary>
        /// <returns>客户端脚本</returns>
        public string GetMinimizeReference()
        {
            return String.Format("{0}.f_minimize();", ScriptID);
        }


        #endregion

        #region GetHideReference GetHideRefreshReference GetHidePostBackReference

        /// <summary>
        /// 获取关闭当前激活Window的客户端脚本
        /// </summary>
        /// <returns>客户端脚本</returns>
        public string GetHideReference()
        {
            return String.Format("{0}.f_hide();", ScriptID);
        }

        /// <summary>
        /// 获取关闭当前激活Window然后刷新页面的客户端脚本
        /// </summary>
        /// <returns>客户端脚本</returns>
        public string GetHideRefreshReference()
        {
            return String.Format("{0}.f_hide_refresh();", ScriptID);
        }

        /// <summary>
        /// 获取关闭当前激活Window然后回发页面的客户端脚本
        /// </summary>
        /// <returns>客户端脚本</returns>
        public string GetHidePostBackReference()
        {
            return String.Format("{0}.f_hide_postback();", ScriptID);
        }

        /// <summary>
        /// 获取关闭当前激活Window然后回发页面的客户端脚本
        /// </summary>
        /// <returns>客户端脚本</returns>
        public string GetHidePostBackReference(string argument)
        {
            //return String.Format("{0}.box_hide_postback('{1}');", ScriptID, argument.Replace("'", "\""));
            return String.Format("{0}.f_hide_postback({1});", ScriptID, JsHelper.Enquote(argument));
        }

        /// <summary>
        /// 获取关闭当前激活Window然后执行脚本的客户端脚本
        /// </summary>
        /// <param name="argument">执行的脚本</param>
        /// <returns>客户端脚本</returns>
        public string GetHideExecuteScriptReference(string argument)
        {
            return String.Format("{0}.f_hide_executescript({1});", ScriptID, JsHelper.Enquote(argument));
        }

        #endregion

        #region oldcode

        ///// <summary>
        ///// 获取先确认IFrame的页面中表单改变，然后关闭弹出窗口的客户端脚本
        ///// </summary>
        ///// <returns>客户端脚本</returns>
        //public string GetConfirmHideReference()
        //{
        //    return String.Format("F.wnd.iframeModifiedConfirm({0}, function(){{{1}}});",
        //        ScriptID,
        //        GetHideReference());
        //}

        ///// <summary>
        ///// 获取先确认IFrame的页面中表单改变，然后关闭弹出窗口，然后刷新父页面的客户端脚本
        ///// </summary>
        ///// <returns>客户端脚本</returns>
        //public string GetConfirmHideRefreshReference()
        //{
        //    return String.Format("F.wnd.iframeModifiedConfirm({0}, function(){{{1}}});",
        //        ScriptID,
        //        GetHideRefreshReference());
        //}

        ///// <summary>
        ///// 获取先确认IFrame的页面中表单改变，然后关闭弹出窗口，然后回发父页面的客户端脚本
        ///// </summary>
        ///// <returns>客户端脚本</returns>
        //public string GetConfirmHidePostBackReference()
        //{
        //    return String.Format("F.wnd.iframeModifiedConfirm({0}, function(){{{1}}});",
        //        ScriptID,
        //        GetHidePostBackReference());
        //}


        ///// <summary>
        ///// 获取先确认IFrame的页面中表单改变，然后关闭弹出窗口，然后回发父页面的客户端脚本
        ///// </summary>
        ///// <returns>客户端脚本</returns>
        //public string GetConfirmHidePostBackReference(string argument)
        //{
        //    return String.Format("F.wnd.iframeModifiedConfirm({0},function(){{{1}}});",
        //        ScriptID,
        //        GetHidePostBackReference(argument));
        //}


        ///// <summary>
        ///// 获取先确认IFrame的页面中表单改变，然后关闭弹出窗口，然后执行脚本的客户端脚本
        ///// </summary>
        ///// <param name="argument">回发参数</param>
        ///// <returns>客户端脚本</returns>
        //public string GetConfirmHideExecuteScriptReference(string argument)
        //{
        //    return String.Format("F.wnd.iframeModifiedConfirm({0},function(){{{1}}});",
        //        ScriptID,
        //        GetHideExecuteScriptReference(argument));
        //}


        #region oldcode
        //public string GetConfirmFormModifiedCloseRefreshReference()
        //{
        //    return String.Format("F.wnd.extWindowIFrameFormModifiedConfirm({0}, {1}, '{2}');",
        //        String.Format("{0}", ClientJavascriptID),
        //        ShowInParent.ToString().ToLower(),
        //        GUID);
        //}



        ///// <summary>
        ///// 
        ///// </summary>
        ///// <returns></returns>
        //public string GetIFramePageStateChangedReference()
        //{
        //    string panel = String.Format("{0}", ClientJavascriptID);
        //    if (ShowInParent)
        //    {
        //        panel = String.Format("parent.X.{0}", GUID);
        //    }
        //    return String.Format("F.wnd.getIFrameWindowObject({0}).F.util.isPageStateChanged()", panel);
        //}

        //public string GetIFramePageStateChangedConfirmReference(string confirmTitle, string confirmMsg, string okScript, string cancelScript)
        //{
        //    return GetIFramePageStateChangedConfirmReference(confirmTitle, confirmMsg, okScript, cancelScript, okScript);
        //}

        ///// <summary>
        ///// 页面状态已经变化的提示信息
        ///// </summary>
        ///// <param name="alertMsg"></param>
        ///// <returns></returns>
        //public string GetIFramePageStateChangedConfirmReference(string confirmTitle, string confirmMsg, string okScript, string cancelScript, string notChangeScript)
        //{
        //    string confirmScript = Confirm.GetShowReference(confirmMsg, confirmTitle, MessageBoxIcon.Warning, okScript, cancelScript, String.Format("{0}.getWindow()", IFrameID));
        //    return String.Format("if({0}){{{1}}}else{{{2}}}", GetIFramePageStateChangedReference(), confirmScript, notChangeScript);
        //} 
        #endregion

        #endregion

        #region IPostBackDataHandler Members

        /// <summary>
        /// 处理回发数据
        /// </summary>
        /// <param name="postDataKey">回发数据键</param>
        /// <param name="postCollection">回发数据集</param>
        /// <returns>回发数据是否改变</returns>
        public override bool LoadPostData(string postDataKey, System.Collections.Specialized.NameValueCollection postCollection)
        {
            base.LoadPostData(postDataKey, postCollection);

            bool postHidden = Convert.ToBoolean(postCollection[HiddenHiddenFieldID]);
            if (Hidden != postHidden)
            {
                Hidden = postHidden;
                FState.BackupPostDataProperty("Hidden");
            }

            return false;
        }

        ///// <summary>
        ///// 触发回发数据改变事件
        ///// </summary>
        //public override void RaisePostDataChangedEvent()
        //{
        //    base.RaisePostDataChangedEvent();

        //}

        #endregion

        #region IPostBackEventHandler Members

        /// <summary>
        /// 处理回发事件
        /// </summary>
        /// <param name="eventArgument">事件参数</param>
        public override void RaisePostBackEvent(string eventArgument)
        {
            base.RaisePostBackEvent(eventArgument);

            if (eventArgument.StartsWith("Close$"))
            {
                OnClose(new WindowCloseEventArgs(eventArgument.Substring("Close$".Length)));
            }
        }

        #endregion

        #region OnClose

        private static readonly object _handlerKey = new object();

        /// <summary>
        /// 窗体关闭事件（需要设置EnableClose=true和CloseAction=HidePostBack）
        /// </summary>
        [Category(CategoryName.ACTION)]
        [Description("窗体关闭事件（需要设置EnableClose=true和CloseAction=HidePostBack）")]
        public event EventHandler<WindowCloseEventArgs> Close
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
        /// 触发窗体关闭事件
        /// </summary>
        /// <param name="e">事件参数</param>
        protected virtual void OnClose(WindowCloseEventArgs e)
        {
            EventHandler<WindowCloseEventArgs> handler = Events[_handlerKey] as EventHandler<WindowCloseEventArgs>;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion

        #region old code

        //#region SaveViewState/LoadViewState/TrackViewState

        //protected override object SaveViewState()
        //{
        //    object[] states = new object[2];

        //    states[0] = base.SaveViewState();

        //    states[1] = ((IStateManager)Rows).SaveViewState();

        //    return states;
        //}

        //protected override void LoadViewState(object savedState)
        //{
        //    if (savedState != null)
        //    {
        //        object[] states = (object[])savedState;

        //        base.LoadViewState(states[0]);

        //        ((IStateManager)Rows).LoadViewState(states[1]);
        //    }
        //}

        //protected override void TrackViewState()
        //{
        //    base.TrackViewState();

        //    ((IStateManager)Rows).TrackViewState();
        //}

        //#endregion 

        #endregion


    }
}
