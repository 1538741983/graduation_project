
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    Image.cs
 * CreatedOn:   2008-07-23
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
    /// 图片控件
    /// </summary>
    [Designer("FineUI.Design.ImageDesigner, FineUI.Design")]
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:Image Label=\"Label\" ImageUrl=\"\" runat=server></{0}:Image>")]
    [ToolboxBitmap(typeof(Image), "toolbox.Image.bmp")]
    [Description("图片控件")]
    [ControlBuilder(typeof(NotAllowWhitespaceLiteralsBuilder))]
    public class Image : TooltipField
    {
        #region Constructor

        /// <summary>
        /// 构造函数
        /// </summary>
        public Image()
        {
            AddServerAjaxProperties("ImageUrl", "ImageWidth", "ImageHeight", "ImageCssClass", "ImageCssStyle", "ImageAlt", "Icon");
            AddClientAjaxProperties();
        }

        #endregion

        #region Unsupported Properties

        /// <summary>
        /// 不支持此属性
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override bool Enabled
        {
            get
            {
                return base.Enabled;
            }
        }

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
        /// [AJAX属性]链接地址
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("[AJAX属性]链接地址")]
        public string ImageUrl
        {
            get
            {
                object obj = FState["ImageUrl"];
                if (obj == null)
                {
                    if (!DesignMode)
                    {
                        if (Icon != Icon.None)
                        {
                            obj = IconHelper.GetIconUrl(Icon);
                        }
                    }
                }
                return obj == null ? "" : (string)obj;
            }
            set
            {
                FState["ImageUrl"] = value;
            }
        }


        /// <summary>
        /// [AJAX属性]预定义图标
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(Icon.None)]
        [Description("[AJAX属性]预定义图标")]
        public virtual Icon Icon
        {
            get
            {
                object obj = FState["Icon"];
                return obj == null ? Icon.None : (Icon)obj;
            }
            set
            {
                FState["Icon"] = value;
            }
        }


        /// <summary>
        /// [AJAX属性]图片的宽度
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(typeof(Unit), "")]
        [Description("[AJAX属性]图片的宽度")]
        public Unit ImageWidth
        {
            get
            {
                object obj = FState["ImageWidth"];
                return obj == null ? Unit.Empty : (Unit)obj;
            }
            set
            {
                FState["ImageWidth"] = value;
            }
        }


        /// <summary>
        /// [AJAX属性]图片的高度
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(typeof(Unit), "")]
        [Description("[AJAX属性]图片的高度")]
        public Unit ImageHeight
        {
            get
            {
                object obj = FState["ImageHeight"];
                return obj == null ? Unit.Empty : (Unit)obj;
            }
            set
            {
                FState["ImageHeight"] = value;
            }
        }

        /// <summary>
        /// [AJAX属性]图片的样式类
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("[AJAX属性]图片的样式类")]
        public string ImageCssClass
        {
            get
            {
                object obj = FState["ImageCssClass"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                FState["ImageCssClass"] = value;
            }
        }

        /// <summary>
        /// [AJAX属性]图片的样式
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("[AJAX属性]图片的样式")]
        public string ImageCssStyle
        {
            get
            {
                object obj = FState["ImageCssStyle"];
                return obj == null ? String.Empty : (string)obj;
            }
            set
            {
                FState["ImageCssStyle"] = value;
            }
        }

        /// <summary>
        /// [AJAX属性]图片的Alt
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("[AJAX属性]图片的Alt")]
        public string ImageAlt
        {
            get
            {
                object obj = FState["ImageAlt"];
                return obj == null ? String.Empty : (string)obj;
            }
            set
            {
                FState["ImageAlt"] = value;
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

            if (PropertyModified("ImageUrl", "ImageWidth", "ImageHeight", "ImageCssClass", "ImageCssStyle", "ImageAlt", "ToolTip", "ToolTipTitle", "ToolTipAutoHide", "Icon"))
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

            #region oldcode

            //if (!String.IsNullOrEmpty(ToolTip))
            //{
            //    JsObjectBuilder tooltipBuilder = new JsObjectBuilder();
            //    tooltipBuilder.AddProperty("target", String.Format("Ext.get('{0}').child('img')", ClientID), true);
            //    tooltipBuilder.AddProperty("html", ToolTip);

            //    if (!String.IsNullOrEmpty(ToolTipTitle))
            //    {
            //        tooltipBuilder.AddProperty("title", ToolTipTitle);
            //    }

            //    if (!ToolTipAutoHide)
            //    {
            //        tooltipBuilder.AddProperty("autoHide", false);
            //        tooltipBuilder.AddProperty("closable", true);
            //        tooltipBuilder.AddProperty("draggable", true);
            //    }

            //    string tooltipScript = String.Format("new Ext.ToolTip({0});", tooltipBuilder);

            //    string renderScript = JsHelper.GetDeferScript(tooltipScript, 100); //"(function(){" + tooltipScript + "}).defer(20);";
            //    OB.Listeners.AddProperty("render", JsHelper.GetFunction(renderScript, "component"), true);
            //}

            #endregion

            string jsContent = String.Format("var {0}=Ext.create('Ext.form.field.Display',{1});", XID, OB.ToString());
            AddStartupScript(jsContent);
        }


        private string GetInnerHtml()
        {
            HtmlNodeBuilder htmlBuilder = new HtmlNodeBuilder("img");
            if (!String.IsNullOrEmpty(ImageUrl))
            {
                htmlBuilder.SetProperty("src", ResolveUrl(ImageUrl));
            }

            if (ImageWidth != Unit.Empty)
            {
                htmlBuilder.SetProperty("width", String.Format("{0}px", ImageWidth.Value));
            }
            if (ImageHeight != Unit.Empty)
            {
                htmlBuilder.SetProperty("height", String.Format("{0}px", ImageHeight.Value));
            }

            if (!String.IsNullOrEmpty(ImageCssClass))
            {
                htmlBuilder.SetProperty("class", ImageCssClass);
            }
            if (!String.IsNullOrEmpty(ImageCssStyle))
            {
                htmlBuilder.SetProperty("style", ImageCssStyle);
            }
            if (!String.IsNullOrEmpty(ImageAlt))
            {
                htmlBuilder.SetProperty("alt", ImageAlt);
            }

            ResolveTooltip(htmlBuilder);

            ResolveAttribuites(htmlBuilder);

            return htmlBuilder.ToString();
        }

        #endregion
    }
}
