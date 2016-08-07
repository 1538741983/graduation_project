
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    MenuHyperLink.cs
 * CreatedOn:   2008-07-12
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
    /// 菜单项超链接控件
    /// </summary>
    [Designer("FineUI.Design.MenuHyperLinkDesigner, FineUI.Design")]
    [ToolboxData("<{0}:MenuHyperLink runat=\"server\"></{0}:MenuHyperLink>")]
    [ToolboxBitmap(typeof(MenuHyperLink), "toolbox.MenuHyperLink.bmp")]
    [Description("菜单项超链接控件")]
    [ControlBuilder(typeof(NotAllowWhitespaceLiteralsBuilder))]
    public class MenuHyperLink : MenuItem
    {

        #region Properties

        /// <summary>
        /// 链接地址
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("链接地址")]
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
        /// 链接目标
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("链接目标")]
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

            
            #region options

            if (!String.IsNullOrEmpty(NavigateUrl))
            {
                OB.AddProperty("href", NavigateUrl);
                OB.AddProperty("hrefTarget", Target);
            }


            #endregion

            string jsContent = String.Format("var {0}=Ext.create('Ext.menu.Item',{1});", XID, OB.ToString());

            //if (AjaxForceCompleteUpdate)
            //{
            //    ClearAjaxUpdateScript();
            //    AddAjaxUpdateScript(jsContent);
            //    AjaxForceCompleteUpdate = false;
            //}

            AddStartupScript(jsContent);

        }

        #endregion

    }
}
