
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    Timer.cs
 * CreatedOn:   2009-09-14
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
using System.Drawing.Design;
using System.Web.UI.Design;

namespace FineUI
{
    /// <summary>
    /// 定时器控件
    /// </summary>
    [Designer("FineUI.Design.TimerDesigner, FineUI.Design")]
    [ToolboxData("<{0}:Timer Interval=\"30\" runat=\"server\"></{0}:Timer>")]
    [ToolboxBitmap(typeof(Timer), "toolbox.Timer.bmp")]
    [Description("定时器")]
    [DefaultEvent("Tick")]
    [ControlBuilder(typeof(NotAllowWhitespaceLiteralsBuilder))]
    public class Timer : ControlBase, IPostBackEventHandler
    {
        #region Constructor

        /// <summary>
        /// 构造函数
        /// </summary>
        public Timer()
        {
            AddServerAjaxProperties();
            AddClientAjaxProperties();
        }

        #endregion

        #region Properties

        /// <summary>
        /// 不向页面输出控件的外部容器
        /// </summary>
        internal override bool RenderWrapperNode
        {
            get
            {
                return false;
            }
        }


        /// <summary>
        /// 定时间隔（单位：秒）
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(30)]
        [Description("定时间隔（单位：秒）")]
        public int Interval
        {
            get
            {
                object obj = FState["Interval"];
                return obj == null ? 30 : (int)obj;
            }
            set
            {
                FState["Interval"] = value;
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


            AddAjaxScript(sb);
        }

        /// <summary>
        /// 渲染 HTML 之前调用（页面第一次加载或者普通回发）
        /// </summary>
        protected override void OnFirstPreRender()
        {
            //RenderWrapperNode = false;

            base.OnFirstPreRender();

            if (Enabled)
            {
                AddStartupAbsoluteScript(GetTimerScript());
            }

            string contentScript = String.Format("var {0}=Ext.create('Ext.Component',{1});", XID, OB.ToString());
            AddStartupScript(contentScript);
        }

        private string GetTimerScript()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("window.clearInterval({0}.f_timer);", XID);

            if (Enabled)
            {
                sb.AppendFormat("{0}.f_timer=window.setInterval(function(){{{1}}}, {2});", XID, GetPostBackEventReference(), Interval * 1000);
            }

            return sb.ToString();
        }

        /// <summary>
        /// 获取 Hidden 属性改变的 JavaScript 脚本
        /// </summary>
        /// <returns>客户端脚本</returns>
        protected override string GetEnabledPropertyChangedScript()
        {
            if (PropertyModified("Enabled"))
            {
                return GetTimerScript();
            }
            return String.Empty;
        }

        #endregion

        #region IPostBackEventHandler

        /// <summary>
        /// 处理回发事件
        /// </summary>
        /// <param name="eventArgument">事件参数</param>
        public void RaisePostBackEvent(string eventArgument)
        {
            OnTick(EventArgs.Empty);
        }

        #endregion

        #region OnTick

        private static readonly object _handlerKey = new object();

        /// <summary>
        /// 定时事件
        /// </summary>
        [Category(CategoryName.ACTION)]
        [Description("定时事件")]
        public event EventHandler Tick
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
        /// 触发定时事件
        /// </summary>
        /// <param name="e">事件参数</param>
        protected virtual void OnTick(EventArgs e)
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
