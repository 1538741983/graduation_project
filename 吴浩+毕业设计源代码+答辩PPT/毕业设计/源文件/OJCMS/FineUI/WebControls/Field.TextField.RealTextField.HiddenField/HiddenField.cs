
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    js_css_resource.cs
 * CreatedOn:   2008-07-07
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
    /// 隐藏表单控件
    /// </summary>
    [Designer("FineUI.Design.HiddenFieldDesigner, FineUI.Design")]
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:HiddenField runat=\"server\"></{0}:HiddenField>")]
    [ToolboxBitmap(typeof(HiddenField), "toolbox.HiddenField.bmp")]
    [Description("隐藏表单控件")]
    [ControlBuilder(typeof(NotAllowWhitespaceLiteralsBuilder))]
    public class HiddenField : RealTextField
    {
        #region Properties

        

        #endregion

        #region OnPreRender

        /// <summary>
        /// 渲染 HTML 之前调用（页面第一次加载或者普通回发）
        /// </summary>
        protected override void OnFirstPreRender()
        {
            base.OnFirstPreRender();


            string jsContent = String.Format("var {0}=Ext.create('Ext.form.field.Hidden',{1});", XID, OB.ToString());
            AddStartupScript(jsContent);
        }

        #endregion


    }
}
