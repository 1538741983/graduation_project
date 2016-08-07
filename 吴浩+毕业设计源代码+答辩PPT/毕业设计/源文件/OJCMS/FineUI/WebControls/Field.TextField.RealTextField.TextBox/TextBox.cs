
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    TextBox.cs
 * CreatedOn:   2008-04-07
 * CreatedBy:   30372245@qq.com
 * 
 * 
 * Description：
 *      ->
 *   
 * History：
 *       
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
    /// 文本框控件
    /// </summary>
    [Designer("FineUI.Design.TextBoxDesigner, FineUI.Design")]
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:TextBox Label=\"Label\" Text=\"\" runat=\"server\"></{0}:TextBox>")]
    [ToolboxBitmap(typeof(TextBox), "toolbox.TextBox.bmp")]
    [Description("文本框控件")]
    [ControlBuilder(typeof(NotAllowWhitespaceLiteralsBuilder))]
    public class TextBox : RealTextField
    {
        #region Constructor

        /// <summary>
        /// 构造函数
        /// </summary>
        public TextBox()
        {
            AddServerAjaxProperties();
            AddClientAjaxProperties();

        }

        #endregion

        #region Properties

        
        /// <summary>
        /// 文本框类型
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(TextMode.Text)]
        [Description("文本框类型")]
        public virtual TextMode TextMode
        {
            get
            {
                object obj = FState["TextMode"];
                return obj == null ? TextMode.Text : (TextMode)obj;
            }
            set
            {
                FState["TextMode"] = value;
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
            //if (PropertyModified("Text"))
            //{
            //    sb.AppendFormat("{0}.setValue({1});", XID, JsHelper.Enquote(Text));
            //}

            AddAjaxScript(sb);
        }

        /// <summary>
        /// 渲染 HTML 之前调用（页面第一次加载或者普通回发）
        /// </summary>
        protected override void OnFirstPreRender()
        {
            base.OnFirstPreRender();




            if (TextMode != TextMode.Text)
            {
                OB.AddProperty("inputType", TextModeHelper.GetName(TextMode));
            }


            // 如果Text属性存在于FState中，则不要重复设置value属性，而是在render事件中使用FState的值
            if (FState.ModifiedProperties.Contains("Text"))
            {
                //OB.RemoveProperty("value");
                //OB.Listeners.AddProperty("render", JsHelper.GetFunction("cmp.f_setValue();", "cmp"), true);
                OB.AddProperty("value", String.Format("{0}.Text", GetFStateScriptID()), true);
            }


            string jsContent = String.Format("var {0}=Ext.create('Ext.form.field.Text',{1});", XID, OB.ToString());
            AddStartupScript(jsContent);
        }

        #endregion


    }
}
