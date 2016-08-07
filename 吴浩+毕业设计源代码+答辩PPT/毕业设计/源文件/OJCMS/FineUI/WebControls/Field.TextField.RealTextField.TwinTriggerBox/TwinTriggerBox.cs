
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    TwinTriggerBox.cs
 * CreatedOn:   2008-06-27
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
    [Designer("FineUI.Design.TwinTriggerBoxDesigner, FineUI.Design")]
    [DefaultProperty("Text")]
    [DefaultEvent("TriggerClick")]
    [ToolboxData("<{0}:TwinTriggerBox Label=\"Label\" Trigger1Icon=\"Clear\" Trigger2Icon=\"Search\" runat=\"server\"></{0}:TwinTriggerBox>")]
    [ToolboxBitmap(typeof(TwinTriggerBox), "toolbox.TwinTriggerBox.bmp")]
    [Description("扩展文本框控件")]
    [ControlBuilder(typeof(NotAllowWhitespaceLiteralsBuilder))]
    public class TwinTriggerBox : RealTextField, IPostBackEventHandler, IPostBackDataHandler
    {
        #region Constructor

        /// <summary>
        /// 构造函数
        /// </summary>
        public TwinTriggerBox()
        {
            AddServerAjaxProperties("ShowTrigger1", "ShowTrigger2");
            AddClientAjaxProperties();
        }

        #endregion

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
        /// [AJAX属性]是否显示第一个触发器
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("[AJAX属性]是否显示第一个触发器")]
        public bool ShowTrigger1
        {
            get
            {
                object obj = FState["ShowTrigger1"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                FState["ShowTrigger1"] = value;
            }
        }


        /// <summary>
        /// [AJAX属性]是否显示第一个触发器
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("[AJAX属性]是否显示第二个触发器")]
        public bool ShowTrigger2
        {
            get
            {
                object obj = FState["ShowTrigger2"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                FState["ShowTrigger2"] = value;
            }
        }


        /// <summary>
        /// 是否可以回发第一个触发器
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("是否可以回发第一个触发器")]
        public bool EnableTrigger1PostBack
        {
            get
            {
                object obj = FState["EnableTrigger1PostBack"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                FState["EnableTrigger1PostBack"] = value;
            }
        }


        /// <summary>
        /// 是否可以回发第一个触发器
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("是否可以回发")]
        public bool EnableTrigger2PostBack
        {
            get
            {
                object obj = FState["EnableTrigger2PostBack"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                FState["EnableTrigger2PostBack"] = value;
            }
        }


        /// <summary>
        /// 第一个触发器图片
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("第一个触发器图片")]
        public virtual string Trigger1IconUrl
        {
            get
            {
                object obj = FState["Trigger1IconUrl"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                FState["Trigger1IconUrl"] = value;
            }
        }

        /// <summary>
        /// 第二个触发器图片
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("第二个触发器图片")]
        public virtual string Trigger2IconUrl
        {
            get
            {
                object obj = FState["Trigger2IconUrl"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                FState["Trigger2IconUrl"] = value;
            }
        }



        /// <summary>
        /// 第一个触发器图片
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(TriggerIcon.None)]
        [Description("第一个触发器图片")]
        public virtual TriggerIcon Trigger1Icon
        {
            get
            {
                object obj = FState["Trigger1Icon"];
                return obj == null ? TriggerIcon.None : (TriggerIcon)obj;
            }
            set
            {
                FState["Trigger1Icon"] = value;
            }
        }

        /// <summary>
        /// 第二个触发器图片
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(TriggerIcon.None)]
        [Description("第二个触发器图片")]
        public virtual TriggerIcon Trigger2Icon
        {
            get
            {
                object obj = FState["Trigger2Icon"];
                return obj == null ? TriggerIcon.None : (TriggerIcon)obj;
            }
            set
            {
                FState["Trigger2Icon"] = value;
            }
        }

        /// <summary>
        /// 点击第一个触发器时需要执行的客户端脚本
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("点击第一个触发器时需要执行的客户端脚本")]
        public string OnClientTrigger1Click
        {
            get
            {
                object obj = FState["OnClientTrigger1Click"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                FState["OnClientTrigger1Click"] = value;
            }
        }

        /// <summary>
        /// 点击第二个触发器时需要执行的客户端脚本
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("点击第二个触发器时需要执行的客户端脚本")]
        public string OnClientTrigger2Click
        {
            get
            {
                object obj = FState["OnClientTrigger2Click"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                FState["OnClientTrigger2Click"] = value;
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
            if (PropertyModified("ShowTrigger1"))
            {
                sb.AppendFormat("{0}.triggerCell.item(0).setDisplayed({1});", XID, ShowTrigger1 ? "true" : "false");
            }

            if (PropertyModified("ShowTrigger2"))
            {
                sb.AppendFormat("{0}.triggerCell.item(1).setDisplayed({1});", XID, ShowTrigger2 ? "true" : "false");
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

            if (!ShowTrigger)
            {
                OB.AddProperty("hideTrigger", true);
            }

            if (!EnableEdit)
            {
                OB.AddProperty("editable", false);
            }


            string renderScript = String.Empty;
            if (!ShowTrigger1)
            {
                renderScript += String.Format("this.triggerCell.item(0).setDisplayed(false);");
            }
            if (!ShowTrigger2)
            {
                renderScript += String.Format("this.triggerCell.item(1).setDisplayed(false);");
            }

            if (!String.IsNullOrEmpty(renderScript))
            {
                //renderScript += "this.updateLayout();";
                //OB.Listeners.AddProperty("afterrender", JsHelper.GetFunction(renderScript), true); 
                AddListener("afterrender", renderScript);
            }


            #endregion

            #region Trigger1Icon/Trigger2Icon

            if (Trigger1Icon != TriggerIcon.None)
            {
                OB.AddProperty("trigger1Cls", TriggerIconHelper.GetName(Trigger1Icon));
            }
            else if (!String.IsNullOrEmpty(Trigger1IconUrl))
            {
                string className = String.Format("f_{0}_twintriggerbox_icon1", XID);
                string selector = String.Format(".{0}", className);
                AddStartupCSS(className, StyleUtil.GetBackgroundStyle(selector, ResolveUrl(Trigger1IconUrl)));

                OB.AddProperty("trigger1Cls", className);
            }


            if (Trigger2Icon != TriggerIcon.None)
            {
                OB.AddProperty("trigger2Cls", TriggerIconHelper.GetName(Trigger2Icon));
            }
            else if (!String.IsNullOrEmpty(Trigger2IconUrl))
            {
                string className = String.Format("f_{0}_twintriggerbox_icon2", XID);
                string selector = String.Format(".{0}", className);
                AddStartupCSS(className, StyleUtil.GetBackgroundStyle(selector, ResolveUrl(Trigger2IconUrl)));

                OB.AddProperty("trigger2Cls", className);
            }


            #endregion

            #region Trigger1Click/Trigger1Click

            //if (Enabled)
            //{
            string clientTrigger1ClickScript = OnClientTrigger1Click;
            if (!String.IsNullOrEmpty(clientTrigger1ClickScript) && !clientTrigger1ClickScript.EndsWith(";"))
            {
                clientTrigger1ClickScript += ";";
            }
            string trigger1PostbackScript = String.Empty;
            if (EnableTrigger1PostBack)
            {
                trigger1PostbackScript = GetPostBackEventReference("Trigger$1");
            }
            //string trigger1ClickScript = String.Format("function(){{{0}}}", clientTrigger1ClickScript + trigger1PostbackScript);
            //// createDelegate 用来为一个Function创建一个Scope
            //OB.AddProperty(OptionName.OnTrigger1Click, String.Format("({0}).createDelegate(box)", trigger1ClickScript), true);
            OB.AddProperty("onTrigger1Click", JsHelper.GetFunction(clientTrigger1ClickScript + trigger1PostbackScript), true);


            string clientTrigger2ClickScript = OnClientTrigger2Click;
            if (!String.IsNullOrEmpty(clientTrigger2ClickScript) && !clientTrigger2ClickScript.EndsWith(";"))
            {
                clientTrigger2ClickScript += ";";
            }
            string trigger2PostbackScript = String.Empty;
            if (EnableTrigger2PostBack)
            {
                trigger2PostbackScript = GetPostBackEventReference("Trigger$2");
            }
            //string trigger2ClickScript = String.Format("function(){{{0}}}", clientTrigger2ClickScript + Trigger2PostbackScript);
            //// createDelegate 用来为一个Function创建一个Scope
            //OB.AddProperty(OptionName.OnTrigger2Click, String.Format("({0}).createDelegate(box)", trigger2ClickScript), true);
            OB.AddProperty("onTrigger2Click", JsHelper.GetFunction(clientTrigger2ClickScript + trigger2PostbackScript), true);

            //}

            #endregion

            #region Specialkey

            //if (Enabled)
            //{
            // 首先启用enableKeyEvents
            //OB.AddProperty("enableKeyEvents", true);
            //OB.Listeners.AddProperty("specialkey", String.Format("function(field,e){{if(e.getKey()==e.ENTER){{{0}.onTrigger2Click();e.stopEvent();}}}}", XID), true);
            AddListener("specialkey", String.Format("if(e.getKey()==e.ENTER){{{0}.onTrigger2Click();e.stopEvent();}}", XID), "field", "e");
            //}

            #endregion

            #region EnableEdit
            // extjsv4.x 的enableedit=false，不能点击输入框触发
            if (!EnableEdit)
            {
                //OB.Listeners.AddProperty("render", "function(field){field.mon(field.inputEl,'click',field.onTrigger2Click,field);}", true);
                AddListener("render", "field.mon(field.inputEl,'click',field.onTrigger2Click,field);", "field");

            }
            #endregion

            string jsContent = String.Format("var {0}=Ext.create('Ext.form.field.Trigger',{1});", XID, OB.ToString());
            AddStartupScript(jsContent);

        }

        #endregion

        #region IPostBackEventHandler Members

        /// <summary>
        /// 处理回发事件
        /// </summary>
        /// <param name="eventArgument">事件参数</param>
        public override void RaisePostBackEvent(string eventArgument)
        {
            base.RaisePostBackEvent(eventArgument);

            if (eventArgument == "Trigger$1")
            {
                OnTrigger1Click(EventArgs.Empty);
            }
            else if (eventArgument == "Trigger$2")
            {
                OnTrigger2Click(EventArgs.Empty);
            }
        }

        #endregion

        #region Trigger1Click

        private static readonly object _trigger1HandlerKey = new object();

        /// <summary>
        /// 第一个触发按钮点击事件
        /// </summary>
        [Category(CategoryName.ACTION)]
        [Description("第一个触发按钮点击事件")]
        public event EventHandler Trigger1Click
        {
            add
            {
                Events.AddHandler(_trigger1HandlerKey, value);
            }
            remove
            {
                Events.RemoveHandler(_trigger1HandlerKey, value);
            }
        }

        /// <summary>
        /// 触发第一个触发按钮点击事件
        /// </summary>
        /// <param name="e">事件参数</param>
        protected virtual void OnTrigger1Click(EventArgs e)
        {
            EventHandler handler = Events[_trigger1HandlerKey] as EventHandler;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion

        #region Trigger2Click

        private static readonly object _Trigger2HandlerKey = new object();

        /// <summary>
        /// 第二个触发按钮点击事件
        /// </summary>
        [Category(CategoryName.ACTION)]
        [Description("第二个触发按钮点击事件")]
        public event EventHandler Trigger2Click
        {
            add
            {
                Events.AddHandler(_Trigger2HandlerKey, value);
            }
            remove
            {
                Events.RemoveHandler(_Trigger2HandlerKey, value);
            }
        }

        /// <summary>
        /// 触发第二个触发按钮点击事件
        /// </summary>
        /// <param name="e">事件参数</param>
        protected virtual void OnTrigger2Click(EventArgs e)
        {
            EventHandler handler = Events[_Trigger2HandlerKey] as EventHandler;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion
    }
}
