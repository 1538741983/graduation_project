
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    PageLoading.cs
 * CreatedOn:   2008-05-15
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
    /// 页面加载提示控件
    /// </summary>
    [Designer("FineUI.Design.PageLoadingDesigner, FineUI.Design")]
    [ToolboxData("<{0}:PageLoading runat=server></{0}:PageLoading>")]
    [ToolboxBitmap(typeof(PageLoading), "toolbox.PageLoading.bmp")]
    [Description("")]
    [ControlBuilder(typeof(NotAllowWhitespaceLiteralsBuilder))]
    public class PageLoading : ControlBase
    {
        #region static readonly

        internal static readonly string LOADING_TEMLATE = "<div id='loading-mask'></div><div id='loading'><div class='loading-indicator'><img align='absmiddle' src='#LOADING_IMAGE_SRC#'/></div></div>";

        internal static readonly string LOADING_IMAGE_PATH = "/res/images/loading_32.gif";

        #endregion

        #region Properties


        /// <summary>
        /// 自定义的加载图片
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("自定义的加载图片")]
        [Editor(typeof(ImageUrlEditor), typeof(UITypeEditor))]
        public string ImageUrl
        {
            get
            {
                object obj = FState["ImageUrl"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                FState["ImageUrl"] = value;
            }
        }



        ///// <summary>
        ///// 回发时是否显示
        ///// </summary>
        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue(false)]
        //[Description("回发时是否显示")]
        //public bool ShowOnPostBack
        //{
        //    get
        //    {
        //        object obj = FState["ShowOnPostBack"];
        //        return obj == null ? false : (bool)obj;
        //    }
        //    set
        //    {
        //        FState["ShowOnPostBack"] = value;
        //    }
        //}


        ///// <summary>
        ///// 是否启用淡出效果
        ///// </summary>
        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue(false)]
        //[Description("是否启用淡出效果")]
        //public bool EnableFadeOut
        //{
        //    get
        //    {
        //        object obj = FState["EnableFadeOut"];
        //        return obj == null ? false : (bool)obj;
        //    }
        //    set
        //    {
        //        FState["EnableFadeOut"] = value;
        //    }
        //}


        #endregion

        #region RenderBeginTag/RenderEndTag

        /// <summary>
        /// 渲染控件的开始标签
        /// </summary>
        /// <param name="writer">输出流</param>
        protected override void RenderBeginTag(HtmlTextWriter writer)
        {
            //base.RenderBeginTag(writer);

            if (!Page.IsPostBack || (Page.IsPostBack && ShowOnPostBack))
            {
                string content = LOADING_TEMLATE;

                string imageUrl = String.Empty;
                if (String.IsNullOrEmpty(ImageUrl))
                {
                    imageUrl = ResolveUrl(GlobalConfig.GetJSBasePath() + LOADING_IMAGE_PATH); //ResourceHelper.GetWebResourceUrl(Page, LOADING_IMAGE_NAME);
                }
                else
                {
                    imageUrl = ResolveUrl(ImageUrl);
                }

                content = content.Replace("#LOADING_IMAGE_SRC#", imageUrl);

                writer.Write(content);

            }


        }

        /// <summary>
        /// 渲染控件的结束标签（不生成结束标签）
        /// </summary>
        /// <param name="writer">输出流</param>
        protected override void RenderEndTag(HtmlTextWriter writer)
        {

            //base.RenderEndTag(writer);
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

            if (!Page.IsPostBack || (Page.IsPostBack && ShowOnPostBack))
            {
                string jsContent = String.Empty;

                jsContent = String.Format("F.util.removePageLoading();"); //, EnableFadeOut.ToString().ToLower());
                
                AddStartupAbsoluteScript(jsContent, 50);
            }
        }

        #endregion
    }
}
