
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    Component.cs
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
    /// 控件基类（抽象类）
    /// </summary>
    public abstract class BoxComponent : Component
    {
        #region Constructor

        /// <summary>
        /// 构造函数
        /// </summary>
        public BoxComponent()
        {
            AddServerAjaxProperties("Width", "Height");
            AddClientAjaxProperties();

        }

        #endregion

        #region Properties

        /// <summary>
        /// 宽度
        /// </summary>
        [Category(CategoryName.LAYOUT)]
        [DefaultValue(typeof(Unit), "")]
        [Description("宽度")]
        public Unit Width
        {
            get
            {
                object obj = FState["Width"];
                return obj == null ? Unit.Empty : (Unit)obj;
            }
            set
            {
                FState["Width"] = value;
            }
        }


        /// <summary>
        /// 高度
        /// </summary>
        [Category(CategoryName.LAYOUT)]
        [DefaultValue(typeof(Unit), "")]
        [Description("高度")]
        public Unit Height
        {
            get
            {
                object obj = FState["Height"];
                return obj == null ? Unit.Empty : (Unit)obj;
            }
            set
            {
                FState["Height"] = value;
            }
        }


        #endregion

        #region Layout Properties

        /// <summary>
        /// 锚点值（当父容器的Layout=Anchor时有效）
        /// </summary>
        [Category(CategoryName.LAYOUT)]
        [DefaultValue("")]
        [Description("锚点值（当父容器的Layout=Anchor时有效）")]
        public string AnchorValue
        {
            get
            {
                object obj = FState["AnchorValue"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                FState["AnchorValue"] = value;
            }
        }


        /// <summary>
        /// 列的宽度（当父容器的Layout=Column时有效）
        /// </summary>
        [Category(CategoryName.LAYOUT)]
        [DefaultValue("")]
        [Description("列的宽度（当父容器的Layout=Column时有效）")]
        public string ColumnWidth
        {
            get
            {
                object obj = FState["ColumnWidth"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                FState["ColumnWidth"] = value;
            }
        }


        /// <summary>
        /// 行的宽度（当父容器的Layout=Row时有效）
        /// </summary>
        [Category(CategoryName.LAYOUT)]
        [DefaultValue("")]
        [Description("行的宽度（当父容器的Layout=Row时有效）")]
        public string RowHeight
        {
            get
            {
                object obj = FState["RowHeight"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                FState["RowHeight"] = value;
            }
        }


        /// <summary>
        /// 绝对定位的X坐标（当父容器的Layout=Absolute时有效）
        /// </summary>
        [Category(CategoryName.LAYOUT)]
        [DefaultValue(typeof(Unit), "")]
        [Description("绝对定位的X坐标（当父容器的Layout=Absolute时有效）")]
        public Unit AbsoluteX
        {
            get
            {
                object obj = FState["AbsoluteX"];
                return obj == null ? Unit.Empty : (Unit)obj;
            }
            set
            {
                FState["AbsoluteX"] = value;
            }
        }


        /// <summary>
        /// 绝对定位的Y坐标（当父容器的Layout=Absolute时有效）
        /// </summary>
        [Category(CategoryName.LAYOUT)]
        [DefaultValue(typeof(Unit), "")]
        [Description("绝对定位的Y坐标（当父容器的Layout=Absolute时有效）")]
        public Unit AbsoluteY
        {
            get
            {
                object obj = FState["AbsoluteY"];
                return obj == null ? Unit.Empty : (Unit)obj;
            }
            set
            {
                FState["AbsoluteY"] = value;
            }
        }


        /// <summary>
        /// 表格列数（当父容器的Layout=Table时有效）
        /// </summary>
        [Category(CategoryName.LAYOUT)]
        [DefaultValue(3)]
        [Description("表格列数（当父容器的Layout=Table时有效）")]
        public int TableConfigColumns
        {
            get
            {
                object obj = FState["TableConfigColumns"];
                return obj == null ? 3 : (int)obj;
            }
            set
            {
                FState["TableConfigColumns"] = value;
            }
        }

        /// <summary>
        /// 表格合并行（当父容器的Layout=Table时有效）
        /// </summary>
        [Category(CategoryName.LAYOUT)]
        [DefaultValue(1)]
        [Description("表格合并行（当父容器的Layout=Table时有效）")]
        public int TableRowspan
        {
            get
            {
                object obj = FState["TableRowspan"];
                return obj == null ? 1 : (int)obj;
            }
            set
            {
                FState["TableRowspan"] = value;
            }
        }

        /// <summary>
        /// 表格合并列（当父容器的Layout=Table时有效）
        /// </summary>
        [Category(CategoryName.LAYOUT)]
        [DefaultValue(1)]
        [Description("表格合并列（当父容器的Layout=Table时有效）")]
        public int TableColspan
        {
            get
            {
                object obj = FState["TableColspan"];
                return obj == null ? 1 : (int)obj;
            }
            set
            {
                FState["TableColspan"] = value;
            }
        }

        /// <summary>
        /// 控制子控件的位置（当本容器的Layout=VBox或者HBox时有效）
        /// </summary>
        [Category(CategoryName.LAYOUT)]
        [DefaultValue(BoxLayoutAlign.Stretch)]
        [Description("控制子控件的位置（当本容器的Layout=VBox或者HBox时有效）")]
        public BoxLayoutAlign BoxConfigAlign
        {
            get
            {
                object obj = FState["BoxConfigAlign"];
                return obj == null ? BoxLayoutAlign.Stretch : (BoxLayoutAlign)obj;
            }
            set
            {
                FState["BoxConfigAlign"] = value;
            }
        }

        /// <summary>
        /// 控制子控件的位置（当本容器的Layout=VBox或者HBox时有效）
        /// </summary>
        [Category(CategoryName.LAYOUT)]
        [DefaultValue(BoxLayoutPosition.Start)]
        [Description("控制子控件的位置（当本容器的Layout=VBox或者HBox时有效）")]
        public BoxLayoutPosition BoxConfigPosition
        {
            get
            {
                object obj = FState["BoxConfigPosition"];
                return obj == null ? BoxLayoutPosition.Start : (BoxLayoutPosition)obj;
            }
            set
            {
                FState["BoxConfigPosition"] = value;
            }
        }

        /// <summary>
        /// 内边距（当本容器的Layout=VBox或者HBox时有效）
        /// </summary>
        [Category(CategoryName.LAYOUT)]
        [DefaultValue("0")]
        [Description("内边距（当本容器的Layout=VBox或者HBox时有效）")]
        public string BoxConfigPadding
        {
            get
            {
                object obj = FState["BoxConfigPadding"];
                return obj == null ? "0" : (string)obj;
            }
            set
            {
                FState["BoxConfigPadding"] = value;
            }
        }

        /// <summary>
        /// 子控件的外边距（当本容器的Layout=VBox或者HBox时有效）
        /// </summary>
        [Category(CategoryName.LAYOUT)]
        [DefaultValue("0")]
        [Description("子控件的外边距（当本容器的Layout=VBox或者HBox时有效）")]
        public string BoxConfigChildMargin
        {
            get
            {
                object obj = FState["BoxConfigChildMargin"];
                return obj == null ? "0" : (string)obj;
            }
            set
            {
                FState["BoxConfigChildMargin"] = value;
            }
        }

        /// <summary>
        /// 控制子控件的尺寸（当父容器的Layout=VBox或者HBox时有效）
        /// </summary>
        [Category(CategoryName.LAYOUT)]
        [DefaultValue(0)]
        [Description("控制子控件的尺寸（当父容器的Layout=VBox或者HBox时有效）")]
        public int BoxFlex
        {
            get
            {
                object obj = FState["BoxFlex"];
                return obj == null ? 0 : (int)obj;
            }
            set
            {
                FState["BoxFlex"] = value;
            }
        }


        ///// <summary>
        ///// 外边距
        ///// </summary>
        //[Category(CategoryName.LAYOUT)]
        //[DefaultValue("")]
        //[Description("外边距")]
        //[Obsolete("已废除，请使用Margin属性")]
        //public string BoxMargin
        //{
        //    get
        //    {
        //        return Margin;
        //    }
        //    set
        //    {
        //        Margin = value;
        //    }
        //}


        /// <summary>
        /// 是否显示分隔条
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("是否显示分隔条")]
        public bool RegionSplit
        {
            get
            {
                object obj = FState["RegionSplit"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                FState["RegionSplit"] = value;
            }
        }


        /// <summary>
        /// 区域所在的位置
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(Position.Center)]
        [Description("区域所在的位置")]
        public Position RegionPosition
        {
            get
            {
                object obj = FState["RegionPosition"];
                return obj == null ? Position.Center : (Position)obj;
            }
            set
            {
                FState["RegionPosition"] = value;
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

            if (PropertyModified("Width"))
            {
                sb.AppendFormat("{0}.f_setWidth();", XID);
            }

            if (PropertyModified("Height"))
            {
                sb.AppendFormat("{0}.f_setHeight();", XID);
            }


            AddAjaxScript(sb);

        }

        /// <summary>
        /// 渲染 HTML 之前调用（页面第一次加载或者普通回发）
        /// </summary>
        protected override void OnFirstPreRender()
        {
            base.OnFirstPreRender();


            if (Width != Unit.Empty)
            {
                OB.AddProperty("width", Width.Value);
            }
            if (Height != Unit.Empty)
            {
                OB.AddProperty("height", Height.Value);
            }


            #region Controls in Layout


            Container parentControl = GetParentControl() as Container;

            if (parentControl != null)
            {
                if (parentControl.Layout == Layout.Anchor)
                {
                    // 如果父节点是Anchor布局
                    if (!String.IsNullOrEmpty(AnchorValue))
                    {
                        OB.AddProperty("anchor", AnchorValue);
                    }
                }
                else if (parentControl.Layout == Layout.Column)
                {
                    if (!String.IsNullOrEmpty(ColumnWidth))
                    {
                        string columnWidth = StringUtil.ConvertPercentageToDecimalString(ColumnWidth);

                        // 1.00 在IE下会有BUG，把1.00转换为0.999
                        if (columnWidth == "1.00")
                        {
                            columnWidth = "0.999";
                        }
                        OB.AddProperty("columnWidth", columnWidth, true);
                    }
                }
                else if (parentControl.Layout == Layout.Absolute)
                {
                    if (AbsoluteX != Unit.Empty)
                    {
                        OB.AddProperty("x", AbsoluteX.Value);
                    }
                    if (AbsoluteY != Unit.Empty)
                    {
                        OB.AddProperty("y", AbsoluteY.Value);
                    }
                }
                else if (parentControl.Layout == Layout.Table)
                {
                    if (TableRowspan != 1)
                    {
                        OB.AddProperty("rowspan", TableRowspan);
                    }

                    if (TableColspan != 1)
                    {
                        OB.AddProperty("colspan", TableColspan);
                    }
                }
                else if (parentControl.Layout == Layout.HBox || parentControl.Layout == Layout.VBox)
                {
                    if (BoxFlex != 0)
                    {
                        OB.AddProperty("flex", BoxFlex);
                    }

                    //// 用户可能会设置 BoxMargin="0" 来覆盖 BoxConfigChildMargin 属性。
                    //if (BoxMargin != "")
                    //{
                    //    OB.AddProperty("margins", BoxMargin);
                    //}

                }
                else if (parentControl.Layout == Layout.Region)
                {
                    OB.AddProperty("region", PositionHelper.GetName(RegionPosition));

                    if (RegionSplit)
                    {
                        OB.AddProperty("split", true);
                    }

                }
            }

            #endregion

        }

        /// <summary>
        /// 获取当前控件的父容器
        /// </summary>
        /// <returns></returns>
        protected ControlBase GetParentControl()
        {
            ControlBase parentControl = null;

            // 此面板放在用户控件中的情况
            if (Parent is UserControl || Parent is ContentPlaceHolder)
            {
                if (Parent.Parent is UserControlConnector || Parent.Parent is CPHConnector)
                {
                    parentControl = Parent.Parent.Parent as ControlBase;
                }
            }
            else
            {
                parentControl = Parent as ControlBase;
            }

            return parentControl;
        }

        #endregion

    }
}
