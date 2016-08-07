
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    Label.cs
 * CreatedOn:   2008-04-23
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
    /// 文本控件
    /// </summary>
    [Designer("FineUI.Design.LabelDesigner, FineUI.Design")]
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:Label Text=\"Label\" Label=\"Label\" runat=server></{0}:Label>")]
    [ToolboxBitmap(typeof(Label), "toolbox.Label.bmp")]
    [Description("文本控件")]
    [ControlBuilder(typeof(NotAllowWhitespaceLiteralsBuilder))]
    public class Label : TooltipField
    {
        #region Constructor

        /// <summary>
        /// 构造函数
        /// </summary>
        public Label()
        {
            AddServerAjaxProperties("Text");
            AddClientAjaxProperties();
        }

        #endregion

        #region Unsupported Properties

        ///// <summary>
        ///// 不支持此属性
        ///// </summary>
        //[Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public override bool Enabled
        //{
        //    get
        //    {
        //        return base.Enabled;
        //    }
        //}

        /// <summary>
        /// 不支持此属性
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override short? TabIndex
        {
            get
            {
                return base.TabIndex;
            }
        }

        /// <summary>
        /// 不支持此属性
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override bool FocusOnPageLoad
        {
            get
            {
                return false;
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// 是否对文本编码
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("是否对文本编码")]
        public virtual bool EncodeText
        {
            get
            {
                object obj = FState["EncodeText"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                FState["EncodeText"] = value;
            }
        }

        /// <summary>
        /// [AJAX属性]文本
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("[AJAX属性]文本")]
        public virtual string Text
        {
            get
            {
                object obj = FState["Text"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                FState["Text"] = value;
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
            if (PropertyModified("Text", "ToolTip", "ToolTipTitle", "ToolTipAutoHide", "Enabled"))
            {
                sb.AppendFormat("{0}.setValue({1});", XID, JsHelper.Enquote(GetInnerHtml()));
            }

            AddAjaxScript(sb);
        }

        /// <summary>
        /// 渲染 HTML 之前调用（页面第一次加载或者普通回发）
        /// </summary>
        protected override void OnFirstPreRender()
        {
            base.OnFirstPreRender();


            //OB.AddProperty("htmlEncode", false);

            //OB.RemoveProperty(OptionName.Value);
            OB.AddProperty("value", GetInnerHtml());

            //AddExtraStyle("display", "inline");


            string jsContent = String.Format("var {0}=Ext.create('Ext.form.field.Display',{1});", XID, OB.ToString());
            AddStartupScript(jsContent);
        }


        private string GetInnerHtml()
        {
            string text = Text;
            if (EncodeText)
            {
                text = HttpUtility.HtmlEncode(text);
            }

            HtmlNodeBuilder htmlBuilder = new HtmlNodeBuilder("span");

            if (!String.IsNullOrEmpty(ToolTip))
            {
                ResolveTooltip(htmlBuilder);
            }

            ResolveAttribuites(htmlBuilder);

            if (!Enabled)
            {
                htmlBuilder.SetProperty("class", "x-item-disabled");
                htmlBuilder.SetProperty("disabled", "disabled");
            }

            htmlBuilder.InnerProperty = text;

            string html = htmlBuilder.ToString();

            if (html == "<span></span>")
            {
                html = String.Empty;
            }

            return html;
        }

        #endregion
    }
}
