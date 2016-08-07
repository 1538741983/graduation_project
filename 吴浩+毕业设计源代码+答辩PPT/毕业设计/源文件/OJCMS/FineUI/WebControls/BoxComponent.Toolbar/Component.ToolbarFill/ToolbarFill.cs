
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    ToolbarFill.cs
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

namespace FineUI
{
    /// <summary>
    /// 工具栏左右分隔符控件
    /// </summary>
    [Designer("FineUI.Design.ToolbarFillDesigner, FineUI.Design")]
    [ToolboxData("<{0}:ToolbarFill runat=server></{0}:ToolbarFill>")]
    [ToolboxBitmap(typeof(ToolbarFill), "toolbox.ToolbarFill.bmp")]
    [Description("工具栏左右分隔符控件")]
    [ControlBuilder(typeof(NotAllowWhitespaceLiteralsBuilder))]
    public class ToolbarFill : Component
    {

        #region Properties



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

            

            //OB.RemoveProperty("stateful");
            //OB.RemoveProperty("id");


            //string hideScript = String.Empty;
            //// Ext.Toolbar.Separator 没有 "hidden"/"hideMode" 参数
            //if (Hidden)
            //{
            //    OB.RemoveProperty("hidden");
            //    OB.RemoveProperty("hideMode");

            //    hideScript = String.Format("{0}.hide();", ClientJavascriptID);
            //}
            //AddPageFirstLoadAbsoluteScript(hideScript);


            string jsContent = String.Format("var {0}=Ext.create('Ext.toolbar.Fill',{1});", XID, OB.ToString());
            AddStartupScript(jsContent);
        }

        #endregion

    }
}
