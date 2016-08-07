
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    TriggerBox.cs
 * CreatedOn:   2008-06-18
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

namespace FineUI
{
    /// <summary>
    /// 扩展文本框控件
    /// </summary>
    [Designer("FineUI.Design.TriggerBoxDesigner, FineUI.Design")]
    [DefaultProperty("Text")]
    [DefaultEvent("TriggerClick")]
    [ToolboxData("<{0}:TriggerBox Label=\"Label\" TriggerIcon=\"Search\" runat=\"server\"></{0}:TriggerBox>")]
    [ToolboxBitmap(typeof(TriggerBox), "toolbox.TriggerBox.bmp")]
    [Description("扩展文本框控件")]
    [ControlBuilder(typeof(NotAllowWhitespaceLiteralsBuilder))]
    public class TriggerBox : RealTextField, IPostBackEventHandler
    {
        #region Properties

        /// <summary>
        /// 是否允许编辑
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("是否允许编辑")]
        public bool EnableEdit
        {
            get
            {
                object obj = FState["EnableEdit"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                FState["EnableEdit"] = value;
            }
        }

        /// <summary>
        /// 是否显示触发器
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("是否显示触发器")]
        public bool ShowTrigger
        {
            get
            {
                object obj = FState["ShowTrigger"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                FState["ShowTrigger"] = value;
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
        /// 右侧按钮的图片
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("右侧按钮的图片")]
        public virtual string TriggerIconUrl
        {
            get
            {
                object obj = FState["TriggerIconUrl"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                FState["TriggerIconUrl"] = value;
            }
        }


        /// <summary>
        /// 右侧的图标
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(TriggerIcon.None)]
        [Description("右侧的图标")]
        public virtual TriggerIcon TriggerIcon
        {
            get
            {
                object obj = FState["TriggerIcon"];
                return obj == null ? TriggerIcon.None : (TriggerIcon)obj;
            }
            set
            {
                FState["TriggerIcon"] = value;
            }
        }


        /// <summary>
        /// 点击按钮时需要执行的客户端脚本
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("点击按钮时需要执行的客户端脚本")]
        public string OnClientTriggerClick
        {
            get
            {
                object obj = FState["OnClientTriggerClick"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                FState["OnClientTriggerClick"] = value;
            }
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



            #region options
            if (!ShowTrigger)
            {
                OB.AddProperty("hideTrigger", true);
            }

            if (!EnableEdit)
            {
                OB.AddProperty("editable", false);
            }



            #endregion

            #region TriggerIcon

            if (TriggerIcon != TriggerIcon.None)
            {
                OB.AddProperty("triggerCls", TriggerIconHelper.GetName(TriggerIcon));
            }
            else if (!String.IsNullOrEmpty(TriggerIconUrl))
            {
                string className = String.Format("f_{0}_triggerbox_icon", XID);
                string selector = String.Format(".{0}", className);
                AddStartupCSS(className, StyleUtil.GetBackgroundStyle(selector, ResolveUrl(TriggerIconUrl)));

                OB.AddProperty("triggerCls", className);
            }


            #endregion

            #region TriggerClick

            //if (Enabled)
            //{
            string clientClickScript = OnClientTriggerClick;
            if (!String.IsNullOrEmpty(clientClickScript) && !clientClickScript.EndsWith(";"))
            {
                clientClickScript += ";";
            }

            string postbackScript = String.Empty;
            if (EnablePostBack)
            {
                postbackScript = GetPostBackEventReference();
            }

            OB.AddProperty("onTriggerClick", JsHelper.GetFunction(clientClickScript + postbackScript), true);
            //}

            #endregion

            #region Specialkey

            //if (Enabled)
            //{
            // 首先启用enableKeyEvents
            //OB.AddProperty("enableKeyEvents", true);
            //OB.Listeners.AddProperty("specialkey", String.Format("function(field,e){{if(e.getKey()==e.ENTER){{{0}.onTriggerClick();e.stopEvent();}}}}", XID), true);
            AddListener("specialkey", String.Format("if(e.getKey()==e.ENTER){{{0}.onTriggerClick();e.stopEvent();}}", XID), "field", "e");
            //}

            #endregion

            #region EnableEdit
            // extjsv4.x 的enableedit=false，不能点击输入框触发
            if (!EnableEdit)
            {
                //OB.Listeners.AddProperty("render", "function(field){field.mon(field.inputEl,'click',field.onTriggerClick,field);}", true);
                AddListener("render", "field.mon(field.inputEl,'click',field.onTriggerClick,field);", "field");

            }
            #endregion


            #region old code

            //// 只禁用文本框，不禁用Trigger
            //if (Readonly)
            //{
            //    //OB.AddProperty(OptionName.Disabled, true);
            //    //AddAbsoluteStartupScript( String.Format("{0}.el.dom.disabled=true;", ClientID));



            //    //OB.Listeners.AddProperty(OptionName.Focus, String.Format("function(field){{field.blur.defer(10,field);\r\n}}"), true);
            //    //OB.Listeners.AddProperty(OptionName.Keydown, String.Format("function(){{return false;}}"), true);


            //    // 晕，最后的解决方案居然是设置 readonly=true
            //    OB.AddProperty(OptionName.ReadOnly, true);

            //    //string cssClassName = CssClass;
            //    //cssClassName += "x-item-disabled";

            //    //OB.RemoveProperty(OptionName.Cls);
            //    //OB.AddProperty(OptionName.Cls, cssClassName);
            //    //OB.AddProperty(OptionName.FocusClass, "");
            //}

            #endregion

            string jsContent = String.Format("var {0}=Ext.create('Ext.form.field.Trigger',{1});", XID, OB.ToString());
            AddStartupScript(jsContent);
        }

        #endregion

        #region IPostBackEventHandler Members


        private static readonly object _handlerKey = new object();

        /// <summary>
        /// 触发按钮点击事件
        /// </summary>
        [Category(CategoryName.ACTION)]
        [Description("触发按钮点击事件")]
        public event EventHandler TriggerClick
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
        protected virtual void OnTriggerClick(EventArgs e)
        {
            EventHandler handler = Events[_handlerKey] as EventHandler;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        /// <summary>
        /// 处理回发事件
        /// </summary>
        /// <param name="eventArgument">事件参数</param>
        public override void RaisePostBackEvent(string eventArgument)
        {
            base.RaisePostBackEvent(eventArgument);

            OnTriggerClick(EventArgs.Empty);
        }

        #endregion
    }
}
