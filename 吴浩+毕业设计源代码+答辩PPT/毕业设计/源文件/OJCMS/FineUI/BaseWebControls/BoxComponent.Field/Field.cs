
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
 */

#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FineUI
{
    /// <summary>
    /// 表单字段基类（抽象类）
    /// </summary>
    public abstract class Field : BoxComponent
    {
        #region Constructor

        /// <summary>
        /// 构造函数
        /// </summary>
        public Field()
        {
            AddServerAjaxProperties("Readonly", "Label");
            AddClientAjaxProperties();
        }

        #endregion

        #region Properties

        /// <summary>
        /// 是否显示标签
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("是否显示标签")]
        public virtual bool ShowLabel
        {
            get
            {
                object obj = FState["ShowLabel"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                FState["ShowLabel"] = value;
            }
        }

        /// <summary>
        /// 是否显示空白的标签
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("是否显示空白的标签")]
        public virtual bool ShowEmptyLabel
        {
            get
            {
                object obj = FState["ShowEmptyLabel"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                FState["ShowEmptyLabel"] = value;
            }
        }


        /// <summary>
        /// [AJAX属性]标签文本
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("[AJAX属性]标签文本")]
        public virtual string Label
        {
            get
            {
                object obj = FState["Label"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                FState["Label"] = value;
            }
        }



        /// <summary>
        /// 在标签后面显示红色的星号（用来标识必填项）
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("在标签后面显示红色的星号（用来标识必填项）")]
        public bool ShowRedStar
        {
            get
            {
                object obj = FState["ShowRedStar"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                FState["ShowRedStar"] = value;
            }
        }

        #region old code

        //private string LabelSeparator_Default = "";

        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue("")]
        //[Description("标签分割符")]
        //public string LabelSeparator
        //{
        //    get
        //    {
        //        object obj = BoxState["LabelSeparator"];
        //        return obj == null ? LabelSeparator_Default : (string)obj;
        //    }
        //    set
        //    {
        //        BoxState["LabelSeparator"] = value;
        //    }
        //}


        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue(MsgTarget.Qtip)]
        //[Description("提示消息类型")]
        //public virtual MsgTarget MsgTarget
        //{
        //    get
        //    {
        //        object obj = BoxState["MsgTarget"];
        //        return obj == null ? MsgTarget.Qtip : (MsgTarget)obj;
        //    }
        //    set
        //    {
        //        BoxState["MsgTarget"] = value;
        //    }
        //}


        #endregion


        /// <summary>
        /// [AJAX属性]表单控件的只读状态
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("[AJAX属性]表单控件的只读状态")]
        public virtual bool Readonly
        {
            get
            {
                object obj = FState["Readonly"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                FState["Readonly"] = value;
            }
        }

        ///// <summary>
        ///// 是否可用
        ///// </summary>
        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue(true)]
        //[Description("是否可用")]
        //public virtual bool Enabled
        //{
        //    get
        //    {
        //        object obj = FState["Enabled"];
        //        return obj == null ? true : (bool)obj;
        //    }
        //    set
        //    {
        //        FState["Enabled"] = value;
        //    }
        //}

        /// <summary>
        /// Tab按键的跳转顺序
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(null)]
        [Description("Tab按键的跳转顺序")]
        public virtual short? TabIndex
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
        /// 表单中字段与标签的分隔符
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(typeof(String), ConfigPropertyValue.FORM_LABELSEPARATOR_DEFAULT)]
        [Description("表单中字段与标签的分隔符")]
        public virtual string LabelSeparator
        {
            get
            {
                object obj = FState["LabelSeparator"];
                if (obj == null)
                {
                    if (DesignMode)
                    {
                        return ConfigPropertyValue.FORM_LABELSEPARATOR_DEFAULT;
                    }
                    else
                    {
                        FormBase formBase = ControlUtil.FindParentControl(this, typeof(FormBase), true) as FormBase;
                        if (formBase != null)
                        {
                            return formBase.LabelSeparator;
                        }
                        else
                        {
                            return PageManager.Instance.FormLabelSeparator;
                        }
                    }
                }
                return (String)obj;
            }
            set
            {
                FState["LabelSeparator"] = value;
            }
        }

        /// <summary>
        /// 距离右侧边界的宽度
        /// </summary>
        [Category(CategoryName.LAYOUT)]
        [DefaultValue(typeof(Unit), ConfigPropertyValue.FORM_OFFSETRIGHT_DEFAULT_STRING)]
        [Description("距离右侧边界的宽度")]
        public Unit OffsetRight
        {
            get
            {
                object obj = FState["OffsetRight"];
                if (obj == null)
                {
                    if (DesignMode)
                    {
                        return (Unit)ConfigPropertyValue.FORM_OFFSETRIGHT_DEFAULT;
                    }
                    else
                    {
                        FormBase formBase = ControlUtil.FindParentControl(this, typeof(FormBase), true) as FormBase;
                        if (formBase != null)
                        {
                            return formBase.OffsetRight;
                        }
                        else
                        {
                            return PageManager.Instance.FormOffsetRight;
                        }
                    }
                }
                return (Unit)obj;
            }
            set
            {
                FState["OffsetRight"] = value;
            }
        }

        /// <summary>
        /// 标签的宽度
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(typeof(Unit), ConfigPropertyValue.FORM_LABELWIDTH_DEFAULT_STRING)]
        [Description("标签的宽度")]
        public Unit LabelWidth
        {
            get
            {
                object obj = FState["LabelWidth"];
                if (obj == null)
                {
                    if (DesignMode)
                    {
                        return ConfigPropertyValue.FORM_LABELWIDTH_DEFAULT;
                    }
                    else
                    {
                        FormBase formBase = ControlUtil.FindParentControl(this, typeof(FormBase), true) as FormBase;
                        if (formBase != null)
                        {
                            return formBase.LabelWidth;
                        }
                        else
                        {
                            return PageManager.Instance.FormLabelWidth;
                        }
                    }
                }
                return (Unit)obj;
            }
            set
            {
                FState["LabelWidth"] = value;
            }
        }


        /// <summary>
        /// 表单中标签的位置
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(null)]
        [Description("表单中标签的位置")]
        public LabelAlign? LabelAlign
        {
            get
            {
                object obj = FState["LabelAlign"];
                return obj == null ? null : (LabelAlign?)obj;
            }
            set
            {
                FState["LabelAlign"] = value;
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
            if (PropertyModified("Readonly"))
            {
                sb.AppendFormat("{0}.f_setReadOnly();", XID);
            }

            if (PropertyModified("Label"))
            {
                string newLabel = Label;
                if (ShowRedStar)
                {
                    newLabel += GetRedStarHtml();
                }
                //newLabel += LabelSeparator;
                sb.AppendFormat("{0}.f_setLabel({1});", XID, JsHelper.Enquote(newLabel));
            }

            AddAjaxScript(sb);
        }

        /// <summary>
        /// 渲染 HTML 之前调用（页面第一次加载或者普通回发）
        /// </summary>
        protected override void OnFirstPreRender()
        {
            base.OnFirstPreRender();

            //ResourceManager.Instance.AddJavaScriptComponent("form");

            // 默认隐藏空白标签
            if (ShowEmptyLabel)
            {
                OB.AddProperty("hideEmptyLabel", false);
            }

            // 只有在表单中，有些属性才有效
            //if (ShowLabel)
            //{
            //    if (!String.IsNullOrEmpty(Label))
            //    {
            //        if (ShowRedStar)
            //        {
            //            OB.AddProperty("fieldLabel", Label + GetRedStarHtml());
            //        }
            //        else
            //        {
            //            OB.AddProperty("fieldLabel", Label);
            //        }
            //    }
            //}
            if (!ShowLabel)
            {
                OB.AddProperty("hideLabel", true);
            }


            // 即使ShowLabel=false，也要输出 Label 属性。可能会在标签验证失败对话框中用到[请为 用户名 提供有效值！]。
            if (!String.IsNullOrEmpty(Label))
            {
                if (ShowRedStar)
                {
                    OB.AddProperty("fieldLabel", Label + GetRedStarHtml());
                }
                else
                {
                    OB.AddProperty("fieldLabel", Label);
                }
            }


            if (LabelSeparator != ConfigPropertyValue.FORM_LABELSEPARATOR_DEFAULT)
            {
                OB.AddProperty("labelSeparator", LabelSeparator);
            }

            if (LabelAlign != null)
            {
                OB.AddProperty("labelAlign", LabelAlignHelper.GetName(LabelAlign.Value));
            }

            if (LabelWidth != ConfigPropertyValue.FORM_LABELWIDTH_DEFAULT)
            {
                OB.AddProperty("labelWidth", LabelWidth.Value);
            }

            //if (Width == Unit.Empty)
            ControlBase parentControl = GetParentControl();
            if (parentControl != null)
            {
                // 如果父控件布局是Anchor
                if (parentControl is FormRow || 
                    (parentControl is Container && (parentControl as Container).Layout == Layout.Anchor))
                {
                    // 如果定义了宽度，则不设置anchorValue
                    if (Width == Unit.Empty)
                    {
                        // 这个地方可能会覆盖 BoxComponent 中已经设置的 anchor 属性，不过没关系
                        OB.AddProperty("anchor", GetAnchorValue());
                    }
                }
            }


            // Every Field need a name property, which is used in form submit.
            OB.AddProperty("name", UniqueID);

            // Enabled has been processed in ControlBase.
            //OB.AddProperty(OptionName.Disabled, !Enabled);
            //if (AjaxPropertyChanged("Enabled", Enabled))
            //{
            //    AddAjaxPropertyChangedScript(String.Format("{0}.{1}();", XID, Enabled ? "enable" : "disable"));
            //    //AddAjaxPropertyChangedScript(String.Format("{0}.setDisabled({1});", ClientJavascriptID, !Enabled));
            //}

            if (TabIndex != null)
            {
                OB.AddProperty("tabIndex", TabIndex.Value);
            }

            if (Readonly)
            {
                OB.AddProperty("readOnly", true);
            }

            // We don't need to add this change event to all Field, only SimpleForm and Form has such event.
            // We have enableBubble for Ext.form.Field

            //// Fires just before the field blurs if the field value has changed.
            //string changeScript = "F.util.setPageStateChanged();";
            //OB.Listeners.AddProperty("change", JsHelper.GetFunction(changeScript), true);

        }

        private string GetAnchorValue()
        {
            string anchorValue = AnchorValue;

            if (String.IsNullOrEmpty(anchorValue))
            {
                if (OffsetRight.Value != 0)
                {
                    anchorValue = "-" + OffsetRight.Value + "px";
                }
                else
                {
                    anchorValue = "0";
                }
            }

            return anchorValue;
        }

        private string GetRedStarHtml()
        {
            return "<span style=\"color:red;\">*</span>";
        }

        #endregion

        #region Reset

        /// <summary>
        /// 重置此字段的值（比如用来清空FileUpload的内容）
        /// </summary>
        public void Reset()
        {
            PageContext.RegisterStartupScript(GetResetReference());
        }

        /// <summary>
        /// 获取重置此字段的客户端脚本
        /// </summary>
        /// <returns></returns>
        public virtual string GetResetReference()
        {
            return String.Format("{0}.reset();", ScriptID);
        }

        #endregion

        #region GetValueReference

        /// <summary>
        /// 获取此字段值的客户端脚本（注意返回的脚本不带结束分号）
        /// </summary>
        /// <returns>客户端脚本</returns>
        public virtual string GetValueReference()
        {
            // Don't add ; in the end, because we will invoke this code like this:
            // windowField1.DataIFrameUrlFormatString = "grid_iframe_run_window1.aspx?id={0}&page={1}&param1=<script>" + TextBox1.GetValueReference() + "</script>";
            return String.Format("{0}.getValue()", ScriptID);
        }

        #endregion

        #region GetMarkInvalidReference GetClearInvalidReference

        /// <summary>
        /// 设置字段验证失败的提示信息
        /// </summary>
        /// <param name="message">提示信息</param>
        public void MarkInvalid(string message)
        {
            PageContext.RegisterStartupScript(GetMarkInvalidReference(message));
        }

        /// <summary>
        /// 清除验证失败的提示信息
        /// </summary>
        public void ClearInvalid()
        {
            PageContext.RegisterStartupScript(GetClearInvalidReference());
        }

        /// <summary>
        /// 获取字段验证失败提示信息的客户端脚本
        /// </summary>
        /// <param name="message">提示信息</param>
        /// <returns>客户端脚本</returns>
        public string GetMarkInvalidReference(string message)
        {
            return String.Format("{0}.markInvalid({1});", ScriptID, JsHelper.Enquote(message));
        }

        /// <summary>
        /// 获取清除验证失败提示信息的客户端脚本
        /// </summary>
        /// <returns>客户端脚本</returns>
        public string GetClearInvalidReference()
        {
            return String.Format("{0}.clearInvalid();", ScriptID);
        }

        #endregion

        #region oldcode

        //internal string GetDesignTimeHtml(string content)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    sb.Append("<div style=\"margin:2px;\">");
        //    if (!ShowLabel)
        //    {
        //        sb.AppendFormat("{0}&nbsp;", content);
        //    }
        //    else
        //    {
        //        string redstar = String.Empty;
        //        if (ShowRedStar)
        //        {
        //            redstar = "<span style=\"color:red;\">*</span>";
        //        }
        //        sb.AppendFormat("<table width=\"100%\"><tr><td style=\"width:150px;\">{0}</td><td>{1}&nbsp;</td></tr></table>", Label + redstar, content);
        //    }
        //    sb.Append("</div>");
        //    return sb.ToString();
        //}

        #endregion
    }
}
