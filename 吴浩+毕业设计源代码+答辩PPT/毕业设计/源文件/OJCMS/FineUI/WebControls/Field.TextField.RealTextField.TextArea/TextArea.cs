
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    TextArea.cs
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
    /// 多行文本框控件
    /// </summary>
    [Designer("FineUI.Design.TextAreaDesigner, FineUI.Design")]
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:TextArea Label=\"Label\" Text=\"\" Height=\"50px\" runat=\"server\"></{0}:TextArea>")]
    [ToolboxBitmap(typeof(TextArea), "toolbox.TextArea.bmp")]
    [Description("多行文本框控件")]
    [ControlBuilder(typeof(NotAllowWhitespaceLiteralsBuilder))]
    public class TextArea : RealTextField
    {
        #region Constructor

        /// <summary>
        /// 构造函数
        /// </summary>
        public TextArea()
        {
            AddServerAjaxProperties();
            AddClientAjaxProperties();

        }

        #endregion

        #region Unsupported Properties

        /// <summary>
        /// 不支持此属性
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override string NextFocusControl
        {
            get
            {
                return base.NextFocusControl;
            }
        }



        #endregion

        #region Properties

        /// <summary>
        /// 是否自动增长高度
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("是否自动增长高度")]
        public bool AutoGrowHeight
        {
            get
            {
                object obj = FState["AutoGrowHeight"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                FState["AutoGrowHeight"] = value;
            }
        }


        /// <summary>
        /// 自动增长的最大高度
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(typeof(Unit), "1000")]
        [Description("自动增长的最大高度")]
        public Unit AutoGrowHeightMax
        {
            get
            {
                object obj = FState["AutoGrowHeightMax"];
                return obj == null ? (Unit)1000 : (Unit)obj;
            }
            set
            {
                FState["AutoGrowHeightMax"] = value;
            }
        }

        /// <summary>
        /// 自动增长的最小高度
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(typeof(Unit), "60")]
        [Description("自动增长的最小高度")]
        public Unit AutoGrowHeightMin
        {
            get
            {
                object obj = FState["AutoGrowHeightMin"];
                return obj == null ? (Unit)60 : (Unit)obj;
            }
            set
            {
                FState["AutoGrowHeightMin"] = value;
            }
        }


        /// <summary>
        /// 是否总是隐藏滚动条
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("是否总是隐藏滚动条")]
        public bool HideScrollbars
        {
            get
            {
                object obj = FState["HideScrollbars"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                FState["HideScrollbars"] = value;
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


            if (AutoGrowHeight)
            {
                OB.AddProperty("grow", AutoGrowHeight);

                if (AutoGrowHeightMax.Value != 1000)
                {
                    OB.AddProperty("growMax", AutoGrowHeightMax.Value);
                }

                if (AutoGrowHeightMin.Value != 60)
                {
                    OB.AddProperty("growMin", AutoGrowHeightMin.Value);
                }

                if (HideScrollbars)
                {
                    OB.AddProperty("preventScrollbars", true);
                }
            }


            // 如果Text属性存在于FState中，则不要重复设置value属性，而是在render事件中使用FState的值
            if (FState.ModifiedProperties.Contains("Text"))
            {
                //OB.RemoveProperty("value");
                //OB.Listeners.AddProperty("render", JsHelper.GetFunction("cmp.f_setValue();", "cmp"), true);
                OB.AddProperty("value", String.Format("{0}.Text", GetFStateScriptID()), true);
            }


            //// 自动增长的最小高度要么等于高度，要么等于50（最小值）
            //if (AutoGrowHeight)
            //{
            //    Unit height = (Unit)50;
            //    if (Height != Unit.Empty)
            //    {
            //        height = Height;
            //    }

            //    OB.AddProperty("growMin", height.Value);
            //}

            string jsContent = String.Format("var {0}=Ext.create('Ext.form.field.TextArea',{1});", XID, OB.ToString());
            AddStartupScript(jsContent);
        }

        #endregion

    }
}
