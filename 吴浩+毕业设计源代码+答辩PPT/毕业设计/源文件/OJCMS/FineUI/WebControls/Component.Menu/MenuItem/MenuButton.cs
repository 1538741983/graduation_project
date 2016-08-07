
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    MenuButton.cs
 * CreatedOn:   2008-07-12
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
using System.Web.UI.Design.WebControls;

using Newtonsoft.Json;
using System.Web.UI.HtmlControls;

namespace FineUI
{
    /// <summary>
    /// 菜单项按钮控件
    /// </summary>
    [Designer("FineUI.Design.MenuButtonDesigner, FineUI.Design")]
    [ToolboxData("<{0}:MenuButton runat=\"server\"></{0}:MenuButton>")]
    [ToolboxBitmap(typeof(MenuButton), "toolbox.MenuButton.bmp")]
    [Description("菜单项按钮控件")]
    [ControlBuilder(typeof(NotAllowWhitespaceLiteralsBuilder))]
    [DefaultEvent("Click")]
    public class MenuButton : MenuItem, IPostBackEventHandler
    {
        #region Constructor

        /// <summary>
        /// 构造函数
        /// </summary>
        public MenuButton()
        {
            // Two type of ajax properties: 1. Can only be changed in server-side. 2. Can be changed both in client and server.
            // Can be changed in client and server properties: null
            // AddAjaxProperties("ConfirmText", "ConfirmTitle", "ConfirmIcon", "ConfirmTarget", "OnClientClick");

        }

        #endregion

        #region Properties

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
        /// 点击按钮时需要执行的客户端脚本
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("点击按钮时需要执行的客户端脚本")]
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
        /// 提交之前需要验证的表单名称列表
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(null)]
        [Description("提交之前需要验证的表单名称列表")]
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

        #region ConfirmText/ConfirmTitle/ConfirmIcon


        /// <summary>
        /// 确认对话框标题
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("确认对话框标题")]
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
        /// 确认对话框内容
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("确认对话框内容")]
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
        /// 确认对话框提示图标
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(MessageBoxIcon.Warning)]
        [Description("确认对话框提示图标")]
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

        ///// <summary>
        ///// 确认对话框弹出位置
        ///// </summary>
        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue("")]
        //[Description("确认对话框弹出位置")]
        //public string ConfirmTarget
        //{
        //    get
        //    {
        //        object obj = BoxState["ConfirmTarget"];
        //        return obj == null ? "" : (string)obj;
        //    }
        //    set
        //    {
        //        BoxState["ConfirmTarget"] = value;
        //    }
        //}

        /// <summary>
        /// 确认对话框弹出位置
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(Target.Self)]
        [Description("确认对话框弹出位置")]
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

        #region OnPreLoad

        //protected override void OnPreLoad(object sender, EventArgs e)
        //{
        //    base.OnPreLoad(sender, e);

        //    SaveAjaxProperty("ClickScriptFunction", GetClickScriptFunction());
        //}

        #endregion

        #region OnPreRender

        /// <summary>
        /// 渲染 HTML 之前调用（AJAX回发）
        /// </summary>
        protected override void OnAjaxPreRender()
        {
            base.OnAjaxPreRender();

            StringBuilder sb = new StringBuilder();
            if (PropertyModified("ConfirmText", "ConfirmTitle", "ConfirmIcon", "ConfirmTarget", "OnClientClick"))
            {
                sb.AppendFormat("{0}.un('click', {0}.initialConfig.listeners.click);", XID);
                sb.AppendFormat("{0}.on('click',{1});", XID, GetClientClickFunction());
            }

            AddAjaxScript(sb);
        }

        /// <summary>
        /// 渲染 HTML 之前调用（页面第一次加载或者普通回发）
        /// </summary>
        protected override void OnFirstPreRender()
        {
            base.OnFirstPreRender();


            #region options


            #endregion

            #region Click

            //string clickScriptFunction = GetClickScriptFunction();
            //if (AjaxPropertyChanged("ClickScriptFunction", clickScriptFunction))
            //{
            //    string ajaxClickFunction = String.Empty;
            //    ajaxClickFunction += String.Format("{0}.un('click',X.{0}_click);", XID);
            //    ajaxClickFunction += clickScriptFunction;
            //    ajaxClickFunction += String.Format("{0}.on('click',X.{0}_click);", XID);

            //    AddAjaxPropertyChangedScript(ajaxClickFunction);
            //}

            //OB.Listeners.AddProperty("click", String.Format("{0}_click", XID), true);

            OB.Listeners.AddProperty("click", GetClientClickFunction(), true);
            
            #endregion

            string jsContent = String.Format("var {0}=Ext.create('Ext.menu.Item',{1});", XID, OB.ToString());
            AddStartupScript(jsContent);

        }

        private string GetClientClickFunction()
        {
            string clickScript = Button.ResolveClientScript(ValidateForms, ValidateTarget, ValidateMessageBox, EnablePostBack, GetPostBackEventReference(),
                ConfirmText, ConfirmTitle, ConfirmIcon, ConfirmTarget, OnClientClick, ClientID);

            clickScript += "e.stopEvent();";

            return GetListenerFunction("click", clickScript, "button", "e");

            //return String.Format("function(button,e){{{0}e.stopEvent();}}", clickScript);
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

        #endregion

        #region OnClick

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

    }
}
