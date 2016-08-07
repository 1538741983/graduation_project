
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    js_css_resource.cs
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
    /// 数字输入框控件
    /// </summary>
    [Designer("FineUI.Design.NumberBoxDesigner, FineUI.Design")]
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:NumberBox Label=\"Label\" runat=\"server\"></{0}:NumberBox>")]
    [ToolboxBitmap(typeof(NumberBox), "toolbox.NumberBox.bmp")]
    [Description("数字输入框控件")]
    [ControlBuilder(typeof(NotAllowWhitespaceLiteralsBuilder))]
    public class NumberBox : RealTextField
    {
        #region Properties



        /// <summary>
        /// 不允许小数
        /// </summary>
        [Category(CategoryName.VALIDATION)]
        [DefaultValue(false)]
        [Description("不允许小数")]
        public bool NoDecimal
        {
            get
            {
                object obj = FState["NoDecimal"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                FState["NoDecimal"] = value;
            }
        }


        /// <summary>
        /// 不允许负数
        /// </summary>
        [Category(CategoryName.VALIDATION)]
        [DefaultValue(false)]
        [Description("不允许负数")]
        public bool NoNegative
        {
            get
            {
                object obj = FState["NoNegative"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                FState["NoNegative"] = value;
            }
        }

        /// <summary>
        /// 最大值
        /// </summary>
        [Category(CategoryName.VALIDATION)]
        [DefaultValue(null)]
        [Description("最大值")]
        public double? MaxValue
        {
            get
            {
                object obj = FState["MaxValue"];
                return obj == null ? null : (double?)obj;
            }
            set
            {
                FState["MaxValue"] = value;
            }
        }

        /// <summary>
        /// 最小值
        /// </summary>
        [Category(CategoryName.VALIDATION)]
        [DefaultValue(null)]
        [Description("最小值")]
        public double? MinValue
        {
            get
            {
                object obj = FState["MinValue"];
                return obj == null ? null : (double?)obj;
            }
            set
            {
                FState["MinValue"] = value;
            }
        }


        /// <summary>
        /// 小数点后的位数（默认为2）
        /// </summary>
        [Category(CategoryName.VALIDATION)]
        [DefaultValue(2)]
        [Description("小数点后的位数（默认为2）")]
        public int DecimalPrecision
        {
            get
            {
                object obj = FState["DecimalPrecision"];
                return obj == null ? 2 : (int)obj;
            }
            set
            {
                FState["DecimalPrecision"] = value;
            }
        }


        #endregion

        #region OnPreRender

        /// <summary>
        /// 渲染 HTML 之前调用（页面第一次加载或者普通回发）
        /// </summary>
        protected override void OnFirstPreRender()
        {
            base.OnFirstPreRender();


            OB.AddProperty("allowDecimals", !NoDecimal);
            //OB.AddProperty("allowNegative", !NoNegative);
            if (MaxValue != null)
            {
                OB.AddProperty("maxValue", MaxValue.Value);
            }

            if (MinValue != null)
            {
                OB.AddProperty("minValue", MinValue.Value);
            }
            else if (NoNegative)
            {
                // 未定义 MinValue，但定义了 NoNegative
                OB.AddProperty("minValue", 0);
            }

            if (DecimalPrecision != 2)
            {
                OB.AddProperty("decimalPrecision", DecimalPrecision);
            }


            string jsContent = String.Format("var {0}=Ext.create('Ext.form.field.Number',{1});", XID, OB.ToString());

            AddStartupScript(jsContent);
        }

        #endregion



    }
}
