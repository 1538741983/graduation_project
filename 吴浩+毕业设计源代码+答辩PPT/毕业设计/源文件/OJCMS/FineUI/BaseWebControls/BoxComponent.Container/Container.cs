
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    Container.cs
 * CreatedOn:   2008-04-14
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


namespace FineUI
{
    /// <summary>
    /// 容器控件基类（抽象类）
    /// </summary>
    public abstract class Container : BoxComponent
    {
        #region Constructor

        /// <summary>
        /// 构造函数
        /// </summary>
        public Container()
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
        public override bool FocusOnPageLoad
        {
            get
            {
                return false;
            }
        }

        #endregion

        #region Layout

        internal override bool WrapperNodeInlineBlock
        {
            get
            {
                return false;
            }
        }


        /// <summary>
        /// 布局类型
        /// </summary>
        [Category(CategoryName.LAYOUT)]
        [DefaultValue(Layout.Container)]
        [Description("布局类型")]
        public virtual Layout Layout
        {
            get
            {
                object obj = FState["Layout"];
                return obj == null ? Layout.Container : (Layout)obj;
            }
            set
            {
                FState["Layout"] = value;
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

            if (Layout != Layout.Container)
            {
                //OB.AddProperty("layout", LayoutHelper.GetName(Layout));
                string layoutName = LayoutHelper.GetName(Layout);
                
                JsObjectBuilder layoutConfigOB = new JsObjectBuilder();
                if (Layout == Layout.Table)
                {
                    layoutConfigOB.AddProperty("columns", TableConfigColumns);

                }
                else if (Layout == Layout.HBox || Layout == Layout.VBox)
                {
                    layoutConfigOB.AddProperty("align", BoxLayoutAlignHelper.GetName(BoxConfigAlign, Layout));

                    layoutConfigOB.AddProperty("pack", BoxLayoutPositionHelper.GetName(BoxConfigPosition));

                    if (BoxConfigPadding != "0")
                    {
                        layoutConfigOB.AddProperty("padding", BoxConfigPadding);
                    }

                    if (BoxConfigChildMargin != "0")
                    {
                        layoutConfigOB.AddProperty("defaultMargins", BoxConfigChildMargin);
                    }
                }

                if (layoutConfigOB.Count > 0)
                {
                    layoutConfigOB.AddProperty("type", layoutName);

                    OB.AddProperty("layout", layoutConfigOB);
                }
                else
                {
                    OB.AddProperty("layout", layoutName);
                }

            }

        }

        #endregion

    }
}
