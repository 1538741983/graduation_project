
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    TextField.cs
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
using System.Drawing.Design;

namespace FineUI
{
    /// <summary>
    /// 表单文本输入框字段基类（抽象类）
    /// </summary>
    public abstract class TextField : Field
    {
        #region Constructor

        /// <summary>
        /// 构造函数
        /// </summary>
        public TextField()
        {
            AddServerAjaxProperties();
            AddClientAjaxProperties();

        }

        #endregion

        #region Validate Properties

        /// <summary>
        /// 是否必填项
        /// </summary>
        [Category(CategoryName.VALIDATION)]
        [DefaultValue(false)]
        [Description("是否必填项")]
        public bool Required
        {
            get
            {
                object obj = FState["Required"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                FState["Required"] = value;
            }
        }

        /// <summary>
        /// 为空时提示信息
        /// </summary>
        [Category(CategoryName.VALIDATION)]
        [DefaultValue("")]
        [Description("为空时提示信息")]
        public string RequiredMessage
        {
            get
            {
                object obj = FState["RequiredMessage"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                FState["RequiredMessage"] = value;
            }
        }

        /// <summary>
        /// 最大长度
        /// </summary>
        [Category(CategoryName.VALIDATION)]
        [DefaultValue(null)]
        [Description("最大长度")]
        public int? MaxLength
        {
            get
            {
                object obj = FState["MaxLength"];
                return obj == null ? null : (int?)obj;
            }
            set
            {
                FState["MaxLength"] = value;
            }
        }

        /// <summary>
        /// 超过最大长度时提示信息
        /// </summary>
        [Category(CategoryName.VALIDATION)]
        [DefaultValue("")]
        [Description("超过最大长度时提示信息")]
        public string MaxLengthMessage
        {
            get
            {
                object obj = FState["MaxLengthMessage"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                FState["MaxLengthMessage"] = value;
            }
        }


        /// <summary>
        /// 最小长度
        /// </summary>
        [Category(CategoryName.VALIDATION)]
        [DefaultValue(null)]
        [Description("最小长度")]
        public int? MinLength
        {
            get
            {
                object obj = FState["MinLength"];
                return obj == null ? null : (int?)obj;
            }
            set
            {
                FState["MinLength"] = value;
            }
        }


        /// <summary>
        /// 少于最小长度时提示信息
        /// </summary>
        [Category(CategoryName.VALIDATION)]
        [DefaultValue("")]
        [Description("少于最小长度时提示信息")]
        public string MinLengthMessage
        {
            get
            {
                object obj = FState["MinLengthMessage"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                FState["MinLengthMessage"] = value;
            }
        }

        /// <summary>
        /// RegexPattern
        /// </summary>
        [Category(CategoryName.VALIDATION)]
        [DefaultValue(RegexPattern.None)]
        [Description("正则表达式常用类型")]
        public RegexPattern RegexPattern
        {
            get
            {
                object obj = FState["RegexPattern"];
                return obj == null ? RegexPattern.None : (RegexPattern)obj;
            }
            set
            {
                FState["RegexPattern"] = value;
            }
        }


        /// <summary>
        /// 正则表达式
        /// </summary>
        [Category(CategoryName.VALIDATION)]
        [DefaultValue("")]
        [Description("正则表达式")]
        [Editor("System.Web.UI.Design.WebControls.RegexTypeEditor", typeof(UITypeEditor))]
        public string Regex
        {
            get
            {
                object obj = FState["Regex"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                FState["Regex"] = value;
            }
        }

        /// <summary>
        /// 不满足正则表达式时提示信息
        /// </summary>
        [Category(CategoryName.VALIDATION)]
        [DefaultValue("")]
        [Description("不满足正则表达式时提示信息")]
        public string RegexMessage
        {
            get
            {
                object obj = FState["RegexMessage"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                FState["RegexMessage"] = value;
            }
        }



        /// <summary>
        /// 正则表达式是否忽略大小写
        /// </summary>
        [Category(CategoryName.VALIDATION)]
        [DefaultValue(true)]
        [Description("正则表达式是否忽略大小写")]
        public bool RegexIgnoreCase
        {
            get
            {
                object obj = FState["RegexIgnoreCase"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                FState["RegexIgnoreCase"] = value;
            }
        }

        #endregion

        #region Compare

        /// <summary>
        /// 需要比较的控件ID
        /// </summary>
        [Category(CategoryName.VALIDATION)]
        [DefaultValue("")]
        [Description("需要比较的控件ID")]
        public string CompareControl
        {
            get
            {
                object obj = FState["CompareControl"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                FState["CompareControl"] = value;
            }
        }



        /// <summary>
        /// 需要比较的值
        /// </summary>
        [Category(CategoryName.VALIDATION)]
        [DefaultValue("")]
        [Description("需要比较的值")]
        public string CompareValue
        {
            get
            {
                object obj = FState["CompareValue"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                FState["CompareValue"] = value;
            }
        }


        /// <summary>
        /// 比较操作符
        /// </summary>
        [Category(CategoryName.VALIDATION)]
        [DefaultValue(Operator.Equal)]
        [Description("比较操作符")]
        public Operator CompareOperator
        {
            get
            {
                object obj = FState["CompareOperator"];
                return obj == null ? Operator.Equal : (Operator)obj;
            }
            set
            {
                FState["CompareOperator"] = value;
            }
        }

        /// <summary>
        /// 比较的类型
        /// </summary>
        [Category(CategoryName.VALIDATION)]
        [DefaultValue(CompareType.String)]
        [Description("比较的类型")]
        public CompareType CompareType
        {
            get
            {
                object obj = FState["CompareType"];
                return obj == null ? CompareType.String : (CompareType)obj;
            }
            set
            {
                FState["CompareType"] = value;
            }
        }

        /// <summary>
        /// 不满足比较条件时提示信息
        /// </summary>
        [Category(CategoryName.VALIDATION)]
        [DefaultValue("")]
        [Description("不满足比较条件时提示信息")]
        public string CompareMessage
        {
            get
            {
                object obj = FState["CompareMessage"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                FState["CompareMessage"] = value;
            }
        }

        #endregion

        #region NextFocusControl

        /// <summary>
        /// 下一步获得焦点的控件（响应回车事件）
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("下一步获得焦点的控件（响应回车事件）")]
        public virtual string NextFocusControl
        {
            get
            {
                object obj = FState["NextFocusControl"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                FState["NextFocusControl"] = value;
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


            #region validate properties

            if (Required)
            {
                OB.AddProperty("allowBlank", false);
                if (!String.IsNullOrEmpty(RequiredMessage))
                {
                    OB.AddProperty("blankText", RequiredMessage);
                }
            }

            if (MaxLength != null)
            {
                OB.AddProperty("maxLength", MaxLength.Value);
                if (!String.IsNullOrEmpty(MaxLengthMessage))
                {
                    OB.AddProperty("maxLengthText", MaxLengthMessage);
                }
            }
            if (MinLength != null)
            {
                OB.AddProperty("minLength", MinLength.Value);
                if (!String.IsNullOrEmpty(MinLengthMessage))
                {
                    OB.AddProperty("minLengthText", MinLengthMessage);
                }
            }

            // Calculate regex expression via RegexPattern and Regex
            string regexStr = String.Empty;
            if (RegexPattern != RegexPattern.None)
            {
                regexStr = RegexPatternHelper.GetRegexValue(RegexPattern);
            }
            else if (!String.IsNullOrEmpty(Regex))
            {
                regexStr = Regex;
            }

            if (!String.IsNullOrEmpty(regexStr))
            {
                string ignoreCaseStr = String.Empty;
                if (RegexIgnoreCase)
                {
                    ignoreCaseStr = ",'i'";
                }

                OB.AddProperty("regex", String.Format("new RegExp({0}{1})", JsHelper.Enquote(regexStr), ignoreCaseStr), true);
                if (!String.IsNullOrEmpty(RegexMessage))
                {
                    OB.AddProperty("regexText", RegexMessage);
                }
            }

            #endregion

            //OB.AddProperty("enableKeyEvents", true);

            #region NextFocusControl

            if (!String.IsNullOrEmpty(NextFocusControl))
            {
                ControlBase nextControl = ControlUtil.FindControlInUserControlOrPage(this, NextFocusControl) as ControlBase;

                if (nextControl != null)
                {
                    //// true to enable the proxying of key events for the HTML input field (defaults to false)
                    //OB.AddProperty("enableKeyEvents", true);
                    // Fires when any key related to navigation (arrows, tab, enter, esc, etc.) is pressed. 
                    //OB.Listeners.AddProperty("specialkey", String.Format("function(field,e){{if(e.getKey()==e.ENTER){{{0}.focus(true,10);e.stopEvent();}}}}", (nextControl as ControlBase).XID), true);

                    string enterScript = String.Empty;

                    if (nextControl is Button)
                    {
                        enterScript = String.Format("{0}.el.dom.click();", nextControl.XID);
                    }
                    else
                    {
                        enterScript = String.Format("{0}.focus(true,10);", nextControl.XID);
                    }

                    AddListener("specialkey", String.Format("if(e.getKey()==e.ENTER){{{0}e.stopEvent();}}", enterScript), "field","e");
                }
            }

            #endregion

            #region ControlToCompare

            string compareValue = String.Empty;
            // 如果CompareControl 和 CompareValue 同时存在，则 CompareControl 拥有更高的优先级
            if (!String.IsNullOrEmpty(CompareControl))
            {
                Control compareControl = ControlUtil.FindControlInUserControlOrPage(this, CompareControl);
                if (compareControl != null && compareControl is ControlBase)
                {
                    compareValue = String.Format("F.fieldValue({0})", JsHelper.Enquote((compareControl as ControlBase).ClientID));
                }
            }
            else if (!String.IsNullOrEmpty(CompareValue))
            {
                compareValue = CompareValue;
                if (CompareType == CompareType.String)
                {
                    compareValue = JsHelper.Enquote(compareValue);
                }
            }

            // Check whether compareValue exist, which may produced from CompareControl or CompareValue.
            if (!String.IsNullOrEmpty(compareValue))
            {
                string compareOperatorJs = OperatorHelper.GetName(CompareOperator);
                string compareExpressionScript = String.Empty;
                if (CompareType == CompareType.String)
                {
                    compareExpressionScript = String.Format("value{0}{1}", compareOperatorJs, compareValue);
                }
                else if (CompareType == CompareType.Int)
                {
                    compareExpressionScript = String.Format("parseInt(value,10){0}parseInt({1},10)", compareOperatorJs, compareValue);
                }
                else if (CompareType == CompareType.Float)
                {
                    compareExpressionScript = String.Format("parseFloat(value){0}parseFloat({1})", compareOperatorJs, compareValue);
                }

                string compareScript = String.Format("if({0}){{return true;}}else{{return {1};}}", compareExpressionScript, JsHelper.Enquote(CompareMessage));
                OB.AddProperty("validator", String.Format("function(){{var value=F.fieldValue(this);{0}}}", compareScript), true);
            }

            #endregion
        }

        #endregion

    }
}
