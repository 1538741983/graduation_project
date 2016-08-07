
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
    /// 支持提示的表单字段基类（抽象类）
    /// </summary>
    public abstract class TooltipField : Field
    {
        #region Constructor

        /// <summary>
        /// 构造函数
        /// </summary>
        public TooltipField()
        {
            AddServerAjaxProperties("ToolTip", "ToolTipTitle", "ToolTipAutoHide");
            AddClientAjaxProperties();
        }

        #endregion

        #region Unsupported Properties


        #endregion

        #region Properties

        /// <summary>
        /// [AJAX属性]提示文本
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("[AJAX属性]提示文本")]
        public string ToolTip
        {
            get
            {
                object obj = FState["ToolTip"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                FState["ToolTip"] = value;
            }
        }

        /// <summary>
        /// [AJAX属性]提示文本的标题
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("[AJAX属性]提示文本的标题")]
        public string ToolTipTitle
        {
            get
            {
                object obj = FState["ToolTipTitle"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                FState["ToolTipTitle"] = value;
            }
        }

        /// <summary>
        /// [AJAX属性]是否自动隐藏提示信息
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("[AJAX属性]是否自动隐藏提示信息")]
        public bool ToolTipAutoHide
        {
            get
            {
                object obj = FState["ToolTipAutoHide"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                FState["ToolTipAutoHide"] = value;
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

        }

        /// <summary>
        /// 渲染 HTML 之前调用（页面第一次加载或者普通回发）
        /// </summary>
        protected override void OnFirstPreRender()
        {
            base.OnFirstPreRender();

        }

        /// <summary>
        /// 添加提示信息
        /// </summary>
        /// <param name="htmlBuilder">HtmlNodeBuilder实例</param>
        protected void ResolveTooltip(HtmlNodeBuilder htmlBuilder)
        {
            if (!String.IsNullOrEmpty(ToolTip))
            {
                htmlBuilder.SetProperty("data-qtip", ToolTip);

                if (!String.IsNullOrEmpty(ToolTipTitle))
                {
                    htmlBuilder.SetProperty("data-qtitle", ToolTipTitle);
                }
                if (!ToolTipAutoHide)
                {
                    htmlBuilder.SetProperty("data-hide", "user");
                }
            }
        }

        #endregion
    }
}
