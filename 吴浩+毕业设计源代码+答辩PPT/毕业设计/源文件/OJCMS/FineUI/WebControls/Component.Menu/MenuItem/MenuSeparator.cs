
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    MenuSeparator.cs
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
    /// 菜单项分隔符控件
    /// </summary>
    [Designer("FineUI.Design.MenuSeparatorDesigner, FineUI.Design")]
    [ToolboxData("<{0}:MenuSeparator runat=\"server\"></{0}:MenuSeparator>")]
    [ToolboxBitmap(typeof(MenuSeparator), "toolbox.MenuSeparator.bmp")]
    [Description("菜单项分隔符控件")]
    [ControlBuilder(typeof(NotAllowWhitespaceLiteralsBuilder))]
    public class MenuSeparator : BaseMenuItem
    {


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


            string jsContent = String.Format("var {0}=Ext.create('Ext.menu.Separator',{1});", XID, OB.ToString());


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
