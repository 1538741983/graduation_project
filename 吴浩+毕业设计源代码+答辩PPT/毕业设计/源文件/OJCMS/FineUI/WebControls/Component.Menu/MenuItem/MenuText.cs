
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    MenuText.cs
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
    /// 菜单项文本控件
    /// </summary>
    [Designer("FineUI.Design.MenuTextDesigner, FineUI.Design")]
    [ToolboxData("<{0}:MenuText runat=\"server\"></{0}:MenuText>")]
    [ToolboxBitmap(typeof(MenuText), "toolbox.MenuText.bmp")]
    [Description("菜单项文本控件")]
    [ControlBuilder(typeof(NotAllowWhitespaceLiteralsBuilder))]
    public class MenuText : MenuItem
    {

        #region Properties

        ///// <summary>
        ///// 文本
        ///// </summary>
        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue("")]
        //[Description("文本")]
        //public virtual string Text
        //{
        //    get
        //    {
        //        object obj = FState["Text"];
        //        return obj == null ? "" : (string)obj;
        //    }
        //    set
        //    {
        //        FState["Text"] = value;
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


            //OB.AddProperty("text", Text);


            string jsContent = String.Format("var {0}=Ext.create('Ext.menu.Item',{1});", XID, OB.ToString());
            AddStartupScript(jsContent);

        }

        #endregion

    }
}
