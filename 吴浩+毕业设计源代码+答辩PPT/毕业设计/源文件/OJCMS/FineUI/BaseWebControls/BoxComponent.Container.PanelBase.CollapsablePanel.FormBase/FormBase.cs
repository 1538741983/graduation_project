
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    SimpleForm.cs
 * CreatedOn:   2008-04-22
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
    /// 表单容器控件基类
    /// </summary>
    public abstract class FormBase : CollapsablePanel
    {
        #region Constructor

        /// <summary>
        /// 构造函数
        /// </summary>
        public FormBase()
        {
            AddServerAjaxProperties();
            AddClientAjaxProperties();
        }

        #endregion

        #region Unsupported Properties

        /// <summary>
        /// 不支持此属性
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override bool EnableIFrame
        {
            get
            {
                return base.EnableIFrame;
            }
        }


        /// <summary>
        /// 不支持此属性
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override string IFrameUrl
        {
            get
            {
                return base.IFrameUrl;
            }
        }


        /// <summary>
        /// 不支持此属性
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override string IFrameName
        {
            get
            {
                return base.IFrameName;
            }
        }

        ///// <summary>
        ///// [只读]布局类型
        ///// </summary>
        //[ReadOnly(true)]
        //[Category(CategoryName.LAYOUT)]
        //[DefaultValue(Layout.Anchor)]
        //[Description("布局类型")]
        //public override Layout Layout
        //{
        //    get
        //    {
        //        return Layout.Anchor;
        //    }
        //}

        /// <summary>
        /// 布局类型
        /// </summary>
        [Category(CategoryName.LAYOUT)]
        [DefaultValue(Layout.Anchor)]
        [Description("布局类型")]
        public override Layout Layout
        {
            get
            {
                object obj = FState["Layout"];
                return obj == null ? Layout.Anchor : (Layout)obj;
            }
            set
            {
                FState["Layout"] = value;
            }
        }

        #endregion

        #region Properties

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
                        return PageManager.Instance.FormLabelWidth;
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
        /// 标签与字段的分隔符
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(typeof(String), ConfigPropertyValue.FORM_LABELSEPARATOR_DEFAULT)]
        [Description("标签与字段的分隔符")]
        public String LabelSeparator
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
                        return PageManager.Instance.FormLabelSeparator;
                    }
                }
                return obj.ToString();
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
                        return ConfigPropertyValue.FORM_OFFSETRIGHT_DEFAULT;
                    }
                    else
                    {
                        return (Unit)PageManager.Instance.FormOffsetRight;
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
        /// 标签的位置
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(typeof(LabelAlign), ConfigPropertyValue.FORM_LABELALIGN_DEFAULT_STRING)]
        [Description("标签的位置")]
        public LabelAlign LabelAlign
        {
            get
            {
                object obj = FState["LabelAlign"];
                if (obj == null)
                {
                    if (DesignMode)
                    {
                        return ConfigPropertyValue.FORM_LABELALIGN_DEFAULT;
                    }
                    else
                    {
                        return PageManager.Instance.FormLabelAlign;
                    }
                }
                return (LabelAlign)obj;
            }
            set
            {
                FState["LabelAlign"] = value;
            }
        }

        /// <summary>
        /// 表单中消息的位置
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(typeof(MessageTarget), ConfigPropertyValue.FORM_MESSAGETARGET_DEFAULT_STRING)]
        [Description("提示消息的位置")]
        public MessageTarget MessageTarget
        {
            get
            {
                object obj = FState["MessageTarget"];
                if (obj == null)
                {
                    if (DesignMode)
                    {
                        return ConfigPropertyValue.FORM_MESSAGETARGET_DEFAULT;
                    }
                    else
                    {
                        return PageManager.Instance.FormMessageTarget;
                    }
                }
                return (MessageTarget)obj;
            }
            set
            {
                FState["MessageTarget"] = value;
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

            #region Options

            JsObjectBuilder fieldDefaults = new JsObjectBuilder();
            if (LabelWidth.Value != ConfigPropertyValue.FORM_LABELWIDTH_DEFAULT)
            {
                fieldDefaults.AddProperty("labelWidth", LabelWidth.Value);
            }
            if (LabelSeparator != ConfigPropertyValue.FORM_LABELSEPARATOR_DEFAULT)
            {
                fieldDefaults.AddProperty("labelSeparator", LabelSeparator);
            }
            if (LabelAlign != ConfigPropertyValue.FORM_LABELALIGN_DEFAULT)
            {
                fieldDefaults.AddProperty("labelAlign", LabelAlignHelper.GetName(LabelAlign));
            }
            if (MessageTarget != ConfigPropertyValue.FORM_MESSAGETARGET_DEFAULT)
            {
                fieldDefaults.AddProperty("msgTarget", MessageTargetHelper.GetName(MessageTarget));
            }

            if (fieldDefaults.Count > 0)
            {
                OB.AddProperty("fieldDefaults", fieldDefaults);
            }


            #endregion

            
        }

        #endregion

    }
}
