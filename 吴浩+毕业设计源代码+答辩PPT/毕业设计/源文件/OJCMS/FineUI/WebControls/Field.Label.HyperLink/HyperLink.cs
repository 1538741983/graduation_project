
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    HyperLink.cs
 * CreatedOn:   2008-06-09
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
    /// 链接控件
    /// </summary>
    [Designer("FineUI.Design.HyperLinkDesigner, FineUI.Design")]
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:HyperLink Text=\"HyperLink\" Label=\"Label\" NavigateUrl=\"\" Target=\"_blank\" runat=server></{0}:HyperLink>")]
    [ToolboxBitmap(typeof(HyperLink), "toolbox.HyperLink.bmp")]
    [Description("链接控件")]
    [ControlBuilder(typeof(NotAllowWhitespaceLiteralsBuilder))]
    public class HyperLink : TooltipField
    {
        #region Constructor

        /// <summary>
        /// 构造函数
        /// </summary>
        public HyperLink()
        {
            AddServerAjaxProperties("NavigateUrl", "Target", "OnClientClick", "Text");
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

        #endregion

        #region Properties

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


        /// <summary>
        /// [AJAX属性]点击链接时需要执行的客户端脚本
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("[AJAX属性]点击链接时需要执行的客户端脚本")]
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
        /// [AJAX属性]链接地址
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("[AJAX属性]链接地址")]
        public string NavigateUrl
        {
            get
            {
                object obj = FState["NavigateUrl"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                FState["NavigateUrl"] = value;
            }
        }

        /// <summary>
        /// [AJAX属性]链接目标
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("[AJAX属性]链接目标")]
        public string Target
        {
            get
            {
                object obj = FState["Target"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                FState["Target"] = value;
            }
        }

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

        #endregion

        #region OnPreRender

        /// <summary>
        /// 渲染 HTML 之前调用（AJAX回发）
        /// </summary>
        protected override void OnAjaxPreRender()
        {
            base.OnAjaxPreRender();

            StringBuilder sb = new StringBuilder();

            if (PropertyModified("NavigateUrl", "Target", "OnClientClick", "Text", "ToolTip", "ToolTipTitle", "ToolTipAutoHide", "Enabled"))
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


            OB.AddProperty("htmlEncode", false);

            OB.AddProperty("value", GetInnerHtml());

            //AddExtraStyle("display", "inline");

            string jsContent = String.Format("var {0}=Ext.create('Ext.form.field.Display',{1});", XID, OB.ToString());
            AddStartupScript(jsContent);
        }

        private string GetInnerHtml()
        {
            HtmlNodeBuilder htmlBuilder = new HtmlNodeBuilder("a");

            if (Enabled)
            {
                if (!String.IsNullOrEmpty(NavigateUrl))
                {
                    if (NavigateUrl == "#")
                    {
                        htmlBuilder.SetProperty("href", "#");
                    }
                    else
                    {
                        htmlBuilder.SetProperty("href", ResolveUrl(NavigateUrl));
                    }
                }

                if (!String.IsNullOrEmpty(Target))
                {
                    htmlBuilder.SetProperty("target", Target);
                }

                if (!String.IsNullOrEmpty(OnClientClick))
                {
                    htmlBuilder.SetProperty("onclick", "javascript:" + OnClientClick);
                }
            }
            else
            {
                htmlBuilder.SetProperty("class", "x-item-disabled");
                htmlBuilder.SetProperty("disabled", "disabled");
            }

            ResolveTooltip(htmlBuilder);

            ResolveAttribuites(htmlBuilder);

            string text = Text;
            if (EncodeText)
            {
                text = HttpUtility.HtmlEncode(text);
            }
            htmlBuilder.InnerProperty = text;

            return htmlBuilder.ToString();
        }

        #endregion
    }
}
