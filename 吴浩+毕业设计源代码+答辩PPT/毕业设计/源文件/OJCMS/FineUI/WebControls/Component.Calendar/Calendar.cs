
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    js_css_resource.cs
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
using System.Drawing;
using System.Drawing.Design;
using System.Globalization;

namespace FineUI
{
    /// <summary>
    /// 日期控件
    /// </summary>
    [Designer("FineUI.Design.CalendarDesigner, FineUI.Design")]
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:Calendar runat=server></{0}:Calendar>")]
    [ToolboxBitmap(typeof(Calendar), "toolbox.Calendar.bmp")]
    [DefaultEvent("DateSelect")]
    [Description("日期控件")]
    [ControlBuilder(typeof(NotAllowWhitespaceLiteralsBuilder))]
    public class Calendar : Component, IPostBackEventHandler, IPostBackDataHandler
    {
        #region Constructor

        /// <summary>
        /// 构造函数
        /// </summary>
        public Calendar()
        {
            AddServerAjaxProperties();
            AddClientAjaxProperties("SelectedDate");
        }

        #endregion

        #region Properties

        /// <summary>
        /// [AJAX属性]选择的日期
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(null)]
        [Description("[AJAX属性]选择的日期")]
        [Editor("System.ComponentModel.Design.DateTimeEditor", typeof(UITypeEditor))]
        public DateTime? SelectedDate
        {
            get
            {
                object obj = FState["SelectedDate"];
                return obj == null ? null : (DateTime?)obj;
            }
            set
            {
                if (DesignMode)
                {
                    FState["SelectedDate"] = value;
                }
                else
                {
                    // 传入的值可能包含时间信息，这里就是为了把时间信息去掉，只保留日期信息
                    FState["SelectedDate"] = DateTime.ParseExact(value.Value.ToString(DateFormatString), DateFormatString, CultureInfo.InvariantCulture);
                }
            }
        }


        /// <summary>
        /// 日期格式
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("yyyy-MM-dd")]
        [Description("日期格式")]
        public string DateFormatString
        {
            get
            {
                object obj = FState["DateFormatString"];
                return obj == null ? "yyyy-MM-dd" : (string)obj;
            }
            set
            {
                FState["DateFormatString"] = value;
            }
        }

        /// <summary>
        /// 最大日期
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(null)]
        [Description("最大日期")]
        [Editor("System.ComponentModel.Design.DateTimeEditor", typeof(UITypeEditor))]
        public DateTime? MaxDate
        {
            get
            {
                object obj = FState["MaxDate"];
                return obj == null ? null : (DateTime?)obj;
            }
            set
            {
                FState["MaxDate"] = value;
            }
        }

        /// <summary>
        /// 最小日期
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(null)]
        [Description("最小日期")]
        [Editor("System.ComponentModel.Design.DateTimeEditor", typeof(UITypeEditor))]
        public DateTime? MinDate
        {
            get
            {
                object obj = FState["MinDate"];
                return obj == null ? null : (DateTime?)obj;
            }
            set
            {
                FState["MinDate"] = value;
            }
        }

        ///// <summary>
        ///// 选择日期是否自动回发
        ///// </summary>
        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue(false)]
        //[Description("选择日期是否自动回发")]
        //[Obsolete("此属性已废除，请使用EnableDateSelectEvent属性")]
        //public bool EnableDateSelect
        //{
        //    get
        //    {
        //        object obj = FState["EnableDateSelect"];
        //        return obj == null ? false : (bool)obj;
        //    }
        //    set
        //    {
        //        FState["EnableDateSelect"] = value;
        //    }
        //}

        /// <summary>
        /// 选择日期是否自动回发
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("选择日期是否自动回发")]
        public bool EnableDateSelectEvent
        {
            get
            {
                object obj = FState["EnableDateSelectEvent"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                FState["EnableDateSelectEvent"] = value;
            }
        }

        #endregion

        #region SelectedDateHiddenFieldID

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        private string SelectedDateHiddenFieldID
        {
            get
            {
                return String.Format("{0}_SelectedDate", ClientID);
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

            if (PropertyModified("SelectedDate"))
            {
                sb.AppendFormat("{0}.setValue({1});", XID, DateUtil.GetClientDateObject(SelectedDate.Value));
            }

            AddAjaxScript(sb);
        }

        /// <summary>
        /// 渲染 HTML 之前调用（页面第一次加载或者普通回发）
        /// </summary>
        protected override void OnFirstPreRender()
        {
            base.OnFirstPreRender();

            
            // extjs 的日期格式化字符串
            string extjsDateFormatString = DateUtil.ConvertToClientDateFormat(DateFormatString);
            OB.AddProperty("format", extjsDateFormatString);

            //if (EnableChineseAltFormats)
            //{
            //    OB.AddProperty("altFormats", "Y-m-d|Y-n-j|Ymd|Ynj|y-m-d|y-n-j|ymd|ynj");
            //}

            if (SelectedDate != null)
            {
                OB.AddProperty("value", DateUtil.GetClientDateObject(SelectedDate.Value), true);
            }

            if (MaxDate != null)
            {
                OB.AddProperty("maxDate", DateUtil.GetClientDateObject(MaxDate.Value), true);
            }

            if (MinDate != null)
            {
                OB.AddProperty("minDate", DateUtil.GetClientDateObject(MinDate.Value), true);
            }


            if (EnableDateSelectEvent)
            {
                //OB.Listeners.AddProperty("select", JsHelper.GetFunction(GetPostBackEventReference("Select")), true);
                AddListener("select", GetPostBackEventReference("Select"));
            }


            string jsContent = String.Format("var {0}=Ext.create('Ext.picker.Date',{1});", XID, OB.ToString());
            AddStartupScript(jsContent);
        }

        #endregion

        #region RaisePostBackEvent

        /// <summary>
        /// 处理回发事件
        /// </summary>
        /// <param name="eventArgument">事件参数</param>
        public void RaisePostBackEvent(string eventArgument)
        {
            if (eventArgument.StartsWith("Select"))
            {
                OnDateSelect(EventArgs.Empty);
            }
        }

        #endregion

        #region OnDateSelect

        private object _handlerKey = new object();

        /// <summary>
        /// 日期选定事件（需要启用EnableDateSelect）
        /// </summary>
        [Category(CategoryName.ACTION)]
        [Description("日期选定事件（需要启用EnableDateSelect）")]
        public virtual event EventHandler DateSelect
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
        /// 触发日期选定事件
        /// </summary>
        /// <param name="e">事件参数</param>
        protected virtual void OnDateSelect(EventArgs e)
        {
            EventHandler handler = Events[_handlerKey] as EventHandler;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion

        #region IPostBackDataHandler Members

        /// <summary>
        /// 处理回发数据
        /// </summary>
        /// <param name="postDataKey">回发数据键</param>
        /// <param name="postCollection">回发数据集</param>
        /// <returns>回发数据是否改变</returns>
        public virtual bool LoadPostData(string postDataKey, System.Collections.Specialized.NameValueCollection postCollection)
        {
            string postSelectedDateStr = postCollection[SelectedDateHiddenFieldID];
            if (!String.IsNullOrEmpty(postSelectedDateStr))
            {
                DateTime currentSelectedDate = DateTime.ParseExact(postSelectedDateStr, DateFormatString, CultureInfo.InvariantCulture);
                if (currentSelectedDate != SelectedDate)
                {
                    SelectedDate = currentSelectedDate;
                    FState.BackupPostDataProperty("SelectedDate");
                }
            }
            
            return false;
        }

        /// <summary>
        /// 触发回发数据改变事件
        /// </summary>
        public virtual void RaisePostDataChangedEvent()
        {
            //OnCollapsedChanged(EventArgs.Empty);
        }

       

        #endregion
    }
}
