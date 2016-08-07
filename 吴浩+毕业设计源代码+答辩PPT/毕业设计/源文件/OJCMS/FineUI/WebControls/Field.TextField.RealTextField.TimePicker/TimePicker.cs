
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    TimePicker.cs
 * CreatedOn:   2012-11-01
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
using System.Globalization;

namespace FineUI
{
    /// <summary>
    /// 时间选择框控件
    /// </summary>
    [Designer("FineUI.Design.TimePickerDesigner, FineUI.Design")]
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:TimePicker Label=\"Label\" runat=\"server\"></{0}:TimePicker>")]
    [ToolboxBitmap(typeof(TimePicker), "toolbox.TimePicker.bmp")]
    [DefaultEvent("DateSelect")]
    [Description("时间选择框控件")]
    [ControlBuilder(typeof(NotAllowWhitespaceLiteralsBuilder))]
    public class TimePicker : RealTextField, IPostBackEventHandler
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
        /// 选择的时间
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(null)]
        [Description("选择的时间")]
        [Editor("System.ComponentModel.Design.DateTimeEditor", typeof(UITypeEditor))]
        public DateTime? SelectedDate
        {
            get
            {
                if (DesignMode)
                {
                    object obj = FState["SelectedDate"];
                    return obj == null ? null : (DateTime?)obj;
                }
                else
                {

                    if (String.IsNullOrEmpty(Text))
                    {
                        return null;
                    }
                    else
                    {
                        try
                        {
                            // OktaEndy - return null when DateFormatString = "dd/MM/yyyy" - Trying to Parse DateTime using it's DateFormatString
                            // http://stackoverflow.com/questions/1368636/why-cant-datetime-parseexact-parse-9-1-2009-using-m-d-yyyy
                            return DateTime.ParseExact(Text, TimeFormatString, CultureInfo.InvariantCulture);
                        }
                        catch (Exception)
                        {
                            // Text is not valid DateTime fomat.
                            return null;
                        }
                    }
                }
            }
            set
            {
                if (DesignMode)
                {
                    FState["SelectedDate"] = value;
                }
                else
                {
                    if (value == null)
                    {
                        Text = String.Empty;
                    }
                    else
                    {
                        Text = value.Value.ToString(TimeFormatString);
                    }
                }
            }
        }

        
        /// <summary>
        /// 尝试解析时间的格式列表
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(null)]
        [Description("尝试解析时间的格式列表")]
        [TypeConverter(typeof(StringArrayConverter))]
        public string[] AltFormats
        {
            get
            {
                object obj = FState["AltFormats"];
                return obj == null ? null : (string[])obj;
            }
            set
            {
                FState["AltFormats"] = value;
            }
        }


        /// <summary>
        /// 时间格式（默认为HH:mm，24小时制，比如“20:30”）
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("HH:mm")]
        [Description("时间格式")]
        public string TimeFormatString
        {
            get
            {
                object obj = FState["TimeFormatString"];
                return obj == null ? "HH:mm" : (string)obj;
            }
            set
            {
                FState["TimeFormatString"] = value;
            }
        }

        /// <summary>
        /// 最大时间
        /// </summary>
        [Category(CategoryName.VALIDATION)]
        [DefaultValue(null)]
        [Description("最大时间")]
        [Editor("System.ComponentModel.Design.DateTimeEditor", typeof(UITypeEditor))]
        public DateTime? MaxTime
        {
            get
            {
                object obj = FState["MaxTime"];
                return obj == null ? null : (DateTime?)obj;
            }
            set
            {
                FState["MaxTime"] = value;
            }
        }

        /// <summary>
        /// 最大时间的字符串形式
        /// </summary>
        [Category(CategoryName.VALIDATION)]
        [DefaultValue(null)]
        [Description("最大时间的字符串形式")]
        public string MaxTimeText
        {
            get
            {
                object obj = FState["MaxTimeText"];
                return obj == null ? null : (string)obj;
            }
            set
            {
                FState["MaxTimeText"] = value;
            }
        }

        /// <summary>
        /// 最小时间
        /// </summary>
        [Category(CategoryName.VALIDATION)]
        [DefaultValue(null)]
        [Description("最小时间")]
        [Editor("System.ComponentModel.Design.DateTimeEditor", typeof(UITypeEditor))]
        public DateTime? MinTime
        {
            get
            {
                object obj = FState["MinTime"];
                return obj == null ? null : (DateTime?)obj;
            }
            set
            {
                FState["MinTime"] = value;
            }
        }

        /// <summary>
        /// 最小时间的字符串形式
        /// </summary>
        [Category(CategoryName.VALIDATION)]
        [DefaultValue(null)]
        [Description("最小时间的字符串形式")]
        public string MinTimeText
        {
            get
            {
                object obj = FState["MinTimeText"];
                return obj == null ? null : (string)obj;
            }
            set
            {
                FState["MinTimeText"] = value;
            }
        }


        private const short INCREMENT_DEFAULT = 15;

        /// <summary>
        /// 列表中每个时间值相差的分钟数（默认为15分钟）
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(INCREMENT_DEFAULT)]
        [Description("列表中每个时间值相差的分钟数（默认为15分钟）")]
        public short Increment 
        {
            get
            {
                object obj = FState["Increment"];
                return obj == null ? INCREMENT_DEFAULT : (short)obj;
            }
            set
            {
                FState["Increment"] = value;
            }
        }

        /// <summary>
        /// 选择时间是否自动回发
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("选择时间是否自动回发")]
        public bool EnableTimeSelectEvent
        {
            get
            {
                object obj = FState["EnableTimeSelectEvent"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                FState["EnableTimeSelectEvent"] = value;
            }
        }

        ///// <summary>
        ///// 选择时间是否自动回发
        ///// </summary>
        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue(false)]
        //[Description("选择时间是否自动回发")]
        //[Obsolete("此属性已废除，请使用EnableTimeSelectEvent属性")]
        //public bool EnableTimeSelect
        //{
        //    get
        //    {
        //        return EnableTimeSelectEvent;
        //    }
        //    set
        //    {
        //        EnableTimeSelectEvent = value;
        //    }
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

            //// 日期选择器也需要菜单组件的支持
            //ResourceManager.Instance.AddJavaScriptComponent("menu");

            // extjs 的日期格式化字符串
            string extjsDateFormatString = DateUtil.ConvertToClientDateFormat(TimeFormatString);
            OB.AddProperty("format", extjsDateFormatString);

            if (AltFormats != null)
            {
                StringBuilder formats = new StringBuilder();
                foreach (string format in AltFormats)
                {
                    formats.Append(DateUtil.ConvertToClientDateFormat(format));
                    formats.Append("|");
                }
                OB.AddProperty("altFormats", formats.ToString().TrimEnd('|'));
            }

            if (Increment != INCREMENT_DEFAULT)
            {
                OB.AddProperty("increment", Increment); 
            }


            ////// 当前选中的日期值，这个在父类中已经设置了
            ////OB.RemoveProperty(OptionName.Value);
            ////if (SelectedDate != null) OB.AddProperty(OptionName.Value, Text);


            if (MaxTime.HasValue)
            {
                OB.AddProperty("maxValue", MaxTime.Value.ToString(TimeFormatString));
            }
            else if (!String.IsNullOrEmpty(MaxTimeText))
            {
                OB.AddProperty("maxValue", MaxTimeText);
            }

            if (MinTime.HasValue)
            {
                OB.AddProperty("minValue", MinTime.Value.ToString(TimeFormatString));
            }
            else if (!String.IsNullOrEmpty(MinTimeText))
            {
                OB.AddProperty("minValue", MinTimeText);
            }

            if (!EnableEdit)
            {
                OB.AddProperty("editable", false);
            }


            if (EnableTimeSelectEvent)
            {
                //OB.Listeners.AddProperty("select", JsHelper.GetFunction(GetPostBackEventReference("Select")), true);
                AddListener("select", GetPostBackEventReference("Select"));
            }


            string jsContent = String.Format("var {0}=Ext.create('Ext.form.field.Time',{1});", XID, OB.ToString());
            AddStartupScript(jsContent);
        }

        #endregion

        #region RaisePostBackEvent

        /// <summary>
        /// 处理回发事件
        /// </summary>
        /// <param name="eventArgument">事件参数</param>
        public override void RaisePostBackEvent(string eventArgument)
        {
            base.RaisePostBackEvent(eventArgument);

            if (eventArgument.StartsWith("Select"))
            {
                OnDateSelect(EventArgs.Empty);
            }
        }

        #endregion

        #region OnDateSelect

        private object _handlerKey = new object();

        /// <summary>
        /// 日期选择事件（需要启用EnableDateSelect）
        /// </summary>
        [Category(CategoryName.ACTION)]
        [Description("日期选择事件（需要启用EnableDateSelect）")]
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
        /// 触发日期选择事件
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

    }
}
