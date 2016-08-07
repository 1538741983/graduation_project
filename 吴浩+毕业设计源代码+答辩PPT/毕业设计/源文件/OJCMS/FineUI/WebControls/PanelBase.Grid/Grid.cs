
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    Grid.cs
 * CreatedOn:   2008-05-19
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
using Newtonsoft.Json.Linq;

using System.Web.UI.HtmlControls;
using System.Data;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel.Design;
using System.Collections.ObjectModel;

namespace FineUI
{
    /// <summary>
    /// 表格控件
    /// </summary>
    [Designer("FineUI.Design.GridDesigner, FineUI.Design")]
    [ToolboxData("<{0}:Grid Title=\"Grid\" runat=\"server\"><Columns></Columns></{0}:Grid>")]
    [ToolboxBitmap(typeof(Grid), "toolbox.Grid.bmp")]
    [Description("表格控件")]
    [ParseChildren(true)]
    [PersistChildren(false)]
    [ControlBuilder(typeof(NotAllowWhitespaceLiteralsBuilder))]
    public class Grid : CollapsablePanel, IPostBackDataHandler, IPostBackEventHandler
    {
        #region static readonly

        /// <summary>
        /// 模板列占位符前缀
        /// </summary>
        public static readonly string TEMPLATE_PLACEHOLDER_PREFIX = "#@TPL@#";

        #endregion

        #region Constructor

        /// <summary>
        /// 构造函数
        /// </summary>
        public Grid()
        {
            // 严格的说，PageIndex、SortField、SortDirection这三个属性不可能在客户端被改变，而是向服务器发出改变的请求，然后服务器处理。
            // 因为这些属性的改变不会影响客户端的UI，必须服务器端发出UI改变的指令才行，所以它们算是服务器端属性。
            AddServerAjaxProperties("PageIndex", "PageSize", "RecordCount", "SortField", "SortDirection", "SummaryData", "SummaryHidden");
            AddClientAjaxProperties("F_Rows", "HiddenColumns", "SelectedRowIDArray", "SelectedCell", "ExpandAllRowExpanders");

            AddGzippedAjaxProperties("F_Rows");
        }

        // AJAX回发时注册展开或者折叠行扩展列的脚本
        private bool _registerScriptRowExpanders = false;

        // AJAX回发回发时调用了 DataBind 函数
        private bool _databindInFineUIAjaxPostBack = false;

        #endregion

        #region Unsupported Properties

        /// <summary>
        /// 不支持此属性
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override ITemplate Content
        {
            get
            {
                return base.Content;
            }
        }

        /// <summary>
        /// 不支持此属性
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override ControlBaseCollection Items
        {
            get
            {
                return base.Items;
            }
        }

        /// <summary>
        /// 不支持此属性
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override bool EnableIFrame
        {
            get
            {
                return base.EnableIFrame;
            }
        }


        /// <summary>
        /// 不支持此属性
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override string IFrameUrl
        {
            get
            {
                return base.IFrameUrl;
            }
        }


        /// <summary>
        /// 不支持此属性
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override string IFrameName
        {
            get
            {
                return base.IFrameName;
            }
        }

        /// <summary>
        /// 布局类型
        /// </summary>
        [ReadOnly(true)]
        [Category(CategoryName.LAYOUT)]
        [DefaultValue(Layout.Container)]
        [Description("布局类型")]
        public override Layout Layout
        {
            get
            {
                return Layout.Container;
            }
        }

        #endregion

        #region AllowCellEditing

        /// <summary>
        /// 行数据标识字段名
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("行数据标识字段名")]
        public string DataIDField
        {
            get
            {
                object obj = FState["DataIDField"];
                return obj == null ? String.Empty : (string)obj;
            }
            set
            {
                FState["DataIDField"] = value;
            }
        }


        /// <summary>
        /// 允许单元格编辑
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("允许单元格编辑")]
        public bool AllowCellEditing
        {
            get
            {
                object obj = FState["AllowCellEditing"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                FState["AllowCellEditing"] = value;
            }
        }


        /// <summary>
        /// 编辑单元格时点击单元格的次数（默认为2次）
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(2)]
        [Description("编辑单元格时点击单元格的次数（默认为2次）")]
        public int ClicksToEdit
        {
            get
            {
                object obj = FState["ClicksToEdit"];
                return obj == null ? 2 : (int)obj;
            }
            set
            {
                FState["ClicksToEdit"] = value;
            }
        }

        /// <summary>
        /// 允许列锁定
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("允许列锁定")]
        public bool AllowColumnLocking
        {
            get
            {
                object obj = FState["AllowColumnLocking"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                FState["AllowColumnLocking"] = value;
            }
        }

        #endregion

        #region AllowPaging/IsDatabasePaging/PageSize/PageCount/PageIndex/RecordCount


        /// <summary>
        /// 允许服务器端分页
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("允许服务器端分页")]
        public bool AllowPaging
        {
            get
            {
                object obj = FState["AllowPaging"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                FState["AllowPaging"] = value;
            }
        }

        /// <summary>
        /// 是否数据库分页
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("是否数据库分页")]
        public bool IsDatabasePaging
        {
            get
            {
                object obj = FState["IsDatabasePaging"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                FState["IsDatabasePaging"] = value;
            }
        }


        /// <summary>
        /// 服务器端分页后清空选中的行
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("服务器端分页后清空选中的行")]
        public bool ClearSelectedRowsAfterPaging
        {
            get
            {
                object obj = FState["ClearSelectedRowsAfterPaging"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                FState["ClearSelectedRowsAfterPaging"] = value;
            }
        }


        /// <summary>
        /// 每页显示项数
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(20)]
        [Description("每页显示项数")]
        public int PageSize
        {
            get
            {
                object obj = FState["PageSize"];
                return obj == null ? 20 : (int)obj;
            }
            set
            {
                FState["PageSize"] = value;
            }
        }


        /// <summary>
        /// [AJAX属性]当前显示页索引
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(0)]
        [Description("[AJAX属性]当前显示页索引")]
        public int PageIndex
        {
            get
            {
                //object obj = FState["PageIndex"];
                //int pageIndex = (obj == null) ? 0 : (int)obj;

                //int resolvedPageIndex = pageIndex;
                //if (resolvedPageIndex < 0)
                //{
                //    resolvedPageIndex = 0;
                //}
                //else if (resolvedPageIndex > PageCount - 1)
                //{
                //    resolvedPageIndex = PageCount - 1;
                //}

                //if (resolvedPageIndex != pageIndex)
                //{
                //    // 如果PageIndex越界，则重新设置PageIndex
                //    PageIndex = resolvedPageIndex;
                //}

                //return resolvedPageIndex;

                object obj = FState["PageIndex"];
                int pageIndex = (obj == null) ? 0 : (int)obj;

                int resolvedPageIndex = pageIndex;

                // 只有定义了RecordCount之后，才检查是否越界（PageIndex - PageCount）
                if (RecordCount > 0)
                {
                    if (resolvedPageIndex > PageCount - 1)
                    {
                        resolvedPageIndex = PageCount - 1;
                    }
                }

                // 每次都需要做不能为负数的检查
                if (resolvedPageIndex < 0)
                {
                    resolvedPageIndex = 0;
                }

                // 如果PageIndex越界，则重新设置PageIndex
                if (resolvedPageIndex != pageIndex)
                {
                    PageIndex = resolvedPageIndex;
                }

                return resolvedPageIndex;
            }
            set
            {
                FState["PageIndex"] = value;
            }
        }


        /// <summary>
        /// [AJAX属性]总页数
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int PageCount
        {
            get
            {
                int pageCount = RecordCount / PageSize;
                if (RecordCount % PageSize != 0)
                {
                    pageCount += 1;
                }
                return pageCount;
            }
        }


        /// <summary>
        /// [AJAX属性]记录的总个数
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int RecordCount
        {
            get
            {
                object obj = FState["RecordCount"];
                return obj == null ? 0 : (int)obj;
            }
            set
            {
                FState["RecordCount"] = value;
            }
        }

        #endregion

        #region AllowSorting/SortDirection/SortField

        /// <summary>
        /// 允许服务器端排序
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("允许服务器端排序")]
        public bool AllowSorting
        {
            get
            {
                object obj = FState["AllowSorting"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                FState["AllowSorting"] = value;
            }
        }


        /// <summary>
        /// 排序方向("ASC", "DESC")
        /// </summary>
        //[Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("ASC")]
        [Description("排序方向（ASC、DESC）")]
        public string SortDirection
        {
            get
            {
                object obj = FState["SortDirection"];
                return obj == null ? "ASC" : (string)obj;
            }
            set
            {
                FState["SortDirection"] = value;
            }
        }




        /// <summary>
        /// 当前排序字段（只读）
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("[AJAX属性]当前排序字段")]
        public string SortField
        {
            get
            {
                object obj = FState["SortField"];
                return obj == null ? "" : (string)obj;

                //object obj = FState["SortField"];
                //if (obj == null)
                //{
                //    if (SortColumnIndex >= 0 && SortColumnIndex < AllColumns.Count)
                //    {
                //        obj = AllColumns[SortColumnIndex].SortField;
                //    }
                //    else
                //    {
                //        obj = String.Empty;
                //    }
                //}
                //return (string)obj;
            }
            set
            {
                FState["SortField"] = value;
            }
        }


        ///// <summary>
        ///// [AJAX属性]当前按照第几列排序（从零算起）
        ///// </summary>
        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue(-1)]
        //[Description("[AJAX属性]当前按照第几列排序（从零算起）")]
        //[Obsolete("此属性已废除，请使用SortField属性")]
        //public int SortColumnIndex
        //{
        //    get
        //    {
        //        if (DesignMode)
        //        {
        //            return -1;
        //        }
        //        else
        //        {
        //            object obj = FState["SortColumnIndex"];
        //            if (obj == null)
        //            {
        //                if (!String.IsNullOrEmpty(SortColumn))
        //                {
        //                    return FindColumn(SortColumn).ColumnIndex;
        //                }
        //                else
        //                {
        //                    return -1;
        //                }
        //            }
        //            else
        //            {
        //                return (int)obj;
        //            }
        //        }
        //    }
        //    set
        //    {
        //        FState["SortColumnIndex"] = value;
        //    }
        //}

        ///// <summary>
        ///// [AJAX属性]排序列（ColumnID）
        ///// </summary>
        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue("")]
        //[Description("[AJAX属性]排序列（ColumnID）")]
        //[Obsolete("此属性已废除，请使用SortField属性")]
        //public string SortColumn
        //{
        //    get
        //    {
        //        object obj = FState["SortColumn"];
        //        return obj == null ? "" : (string)obj;
        //    }
        //    set
        //    {
        //        FState["SortColumn"] = value;
        //    }
        //}

        #endregion

        #region EnableSummary

        /// <summary>
        /// 启用合计行
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("启用合计行")]
        public bool EnableSummary
        {
            get
            {
                object obj = FState["EnableSummary"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                FState["EnableSummary"] = value;
            }
        }

        /// <summary>
        /// [AJAX属性]合计行数据
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public JObject SummaryData
        {
            get
            {
                object obj = FState["SummaryData"];
                return obj == null ? null : (JObject)obj;
            }
            set
            {
                FState["SummaryData"] = value;
            }
        }

        /// <summary>
        /// 合计行的位置
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(SummaryPosition.Flow)]
        [Description("合计行的位置")]
        public SummaryPosition SummaryPosition
        {
            get
            {
                object obj = FState["SummaryPosition"];
                return obj == null ? SummaryPosition.Flow : (SummaryPosition)obj;
            }
            set
            {
                FState["SummaryPosition"] = value;
            }
        }

        ///// <summary>
        ///// 是否隐藏合计行
        ///// </summary>
        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue(false)]
        //[Description("是否隐藏合计行")]
        //public bool SummaryHidden
        //{
        //    get
        //    {
        //        object obj = FState["SummaryHidden"];
        //        return obj == null ? false : (bool)obj;
        //    }
        //    set
        //    {
        //        FState["SummaryHidden"] = value;
        //    }
        //}

        #endregion

        #region Properties

        /// <summary>
        /// 多选时保持当前已选中行
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("多选时保持当前已选中行")]
        public bool KeepCurrentSelection
        {
            get
            {
                object obj = FState["KeepCurrentSelection"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                FState["KeepCurrentSelection"] = value;
            }
        }

        /// <summary>
        /// 数据为空时显示在内容区域的文本，可以是HTML标签
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("数据为空时显示在内容区域的文本，可以是HTML标签")]
        public string EmptyText
        {
            get
            {
                object obj = FState["EmptyText"];
                return obj == null ? String.Empty : (string)obj;
            }
            set
            {
                FState["EmptyText"] = value;
            }
        }


        /// <summary>
        /// 行中文字的垂直排列位置（默认为Middle）
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(VerticalAlign.Middle)]
        [Description("行中文字的垂直排列位置（默认为Middle）")]
        public VerticalAlign RowVerticalAlign
        {
            get
            {
                object obj = FState["RowVerticalAlign"];
                return obj == null ? VerticalAlign.Middle : (VerticalAlign)obj;
            }
            set
            {
                FState["RowVerticalAlign"] = value;
            }
        }


        ///// <summary>
        ///// 序号列的宽度（默认为23px）
        ///// </summary>
        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue(typeof(Unit), "")]
        //[Description("序号列的宽度（默认为23px）")]
        //public Unit RowNumberWidth
        //{
        //    get
        //    {
        //        object obj = FState["RowNumberWidth"];
        //        return obj == null ? Unit.Empty : (Unit)obj;
        //    }
        //    set
        //    {
        //        FState["RowNumberWidth"] = value;
        //    }
        //}


        /// <summary>
        /// 是否延迟渲染
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("是否延迟渲染")]
        public bool EnableDelayRender
        {
            get
            {
                object obj = FState["EnableDelayRender"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                FState["EnableDelayRender"] = value;
            }
        }


        /// <summary>
        /// 展开所有的行扩展列
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("展开所有的行扩展列")]
        public bool ExpandAllRowExpanders
        {
            get
            {
                object obj = FState["ExpandAllRowExpanders"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                FState["ExpandAllRowExpanders"] = value;
            }
        }


        /// <summary>
        /// 启用表格中的文字选择
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("启用表格中的文字选择")]
        public bool EnableTextSelection
        {
            get
            {
                object obj = FState["EnableTextSelection"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                FState["EnableTextSelection"] = value;
            }
        }


        #region old code

        //private bool EnableClientPaging_Default = false;

        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue(false)]
        //[Description("启用客户端分页")]
        //public bool EnableClientPaging
        //{
        //    get
        //    {
        //        object obj = BoxState["EnableClientPaging"];
        //        return obj == null ? EnableClientPaging_Default : (bool)obj;
        //    }
        //    set
        //    {
        //        BoxState["EnableClientPaging"] = value;
        //    }
        //}


        //private bool EnableClientSort_Default = false;

        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue(false)]
        //[Description("启用客户端排序")]
        //public bool EnableClientSort
        //{
        //    get
        //    {
        //        object obj = BoxState["EnableClientSort"];
        //        return obj == null ? EnableClientSort_Default : (bool)obj;
        //    }
        //    set
        //    {
        //        BoxState["EnableClientSort"] = value;
        //    }
        //}  


        //private string AutoExpandColumnID_Default = "";

        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue("")]
        //[Description("自动扩展的列ID")]
        //public string AutoExpandColumnID
        //{
        //    get
        //    {
        //        object obj = BoxState["AutoExpandColumnID"];
        //        return obj == null ? AutoExpandColumnID_Default : (string)obj;
        //    }
        //    set
        //    {
        //        BoxState["AutoExpandColumnID"] = value;
        //    }
        //}

        #endregion

        ///// <summary>
        ///// 启用行序号列
        ///// </summary>
        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue(false)]
        //[Description("启用行序号列")]
        //public bool EnableRowNumber
        //{
        //    get
        //    {
        //        object obj = FState["EnableRowNumber"];
        //        return obj == null ? false : (bool)obj;
        //    }
        //    set
        //    {
        //        FState["EnableRowNumber"] = value;
        //    }
        //}


        ///// <summary>
        ///// 行序号列是否支持分页（默认为false，也即是每页都从1开始）
        ///// </summary>
        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue(false)]
        //[Description("行序号列是否支持分页（默认为false，也即是每页都从1开始）")]
        //public bool EnableRowNumberPaging
        //{
        //    get
        //    {
        //        object obj = FState["EnableRowNumberPaging"];
        //        return obj == null ? false : (bool)obj;
        //    }
        //    set
        //    {
        //        FState["EnableRowNumberPaging"] = value;
        //    }
        //}

        /// <summary>
        /// 显示表格表头
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("显示表格表头")]
        public bool ShowGridHeader
        {
            get
            {
                object obj = FState["ShowGridHeader"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                FState["ShowGridHeader"] = value;
            }
        }

        /// <summary>
        /// 显示分页工具条右侧的分页信息
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("显示分页工具条右侧的分页信息")]
        public bool ShowPagingMessage
        {
            get
            {
                object obj = FState["ShowPagingMessage"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                FState["ShowPagingMessage"] = value;
            }
        }

        /// <summary>
        /// 启用表头菜单
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("启用表头菜单")]
        public bool EnableHeaderMenu
        {
            get
            {
                object obj = FState["EnableHeaderMenu"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                FState["EnableHeaderMenu"] = value;
            }
        }

        ///// <summary>
        ///// 启用标题栏菜单中的隐藏列功能（默认为true，仅在EnableHeaderMenu=true时有效）
        ///// </summary>
        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue(true)]
        //[Description("启用标题栏菜单中的隐藏列功能（默认为true，仅在EnableHeaderMenu=true时有效）")]
        //public bool EnableColumnHide
        //{
        //    get
        //    {
        //        object obj = FState["EnableColumnHide"];
        //        return obj == null ? true : (bool)obj;
        //    }
        //    set
        //    {
        //        FState["EnableColumnHide"] = value;
        //    }
        //}

        /// <summary>
        /// 是否启用列宽度调整
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("是否启用列宽度调整")]
        public bool EnableColumnResize
        {
            get
            {
                object obj = FState["EnableColumnResize"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                FState["EnableColumnResize"] = value;
            }
        }


        ///// <summary>
        ///// 是否启用列移动
        ///// </summary>
        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue(false)]
        //[Description("是否启用列移动")]
        //public bool EnableColumnMove
        //{
        //    get
        //    {
        //        object obj = FState["EnableColumnMove"];
        //        return obj == null ? false : (bool)obj;
        //    }
        //    set
        //    {
        //        FState["EnableColumnMove"] = value;
        //    }
        //}


        /// <summary>
        /// 启用表格列分隔线（默认为false）
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("启用表格列分隔线（默认为false）")]
        public bool EnableColumnLines
        {
            get
            {
                object obj = FState["EnableColumnLines"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                FState["EnableColumnLines"] = value;
            }
        }


        /// <summary>
        /// 启用表格行分隔线（默认为true）
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("启用表格行分隔线（默认为true）")]
        public bool EnableRowLines
        {
            get
            {
                object obj = FState["EnableRowLines"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                FState["EnableRowLines"] = value;
            }
        }


        /// <summary>
        /// 启用交替行显示不同的颜色
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("启用交替行显示不同的颜色")]
        public bool EnableAlternateRowColor
        {
            get
            {
                object obj = FState["EnableAlternateRowStyle"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                FState["EnableAlternateRowStyle"] = value;
            }
        }

        /// <summary>
        /// 启用鼠标移动到行的颜色
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("启用鼠标移动到行的颜色")]
        public bool EnableMouseOverColor
        {
            get
            {
                object obj = FState["EnableMouseOverColor"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                FState["EnableMouseOverColor"] = value;
            }
        }

        #endregion

        #region EnableRowClickEvent/EnableRowClickEvent

        ///// <summary>
        ///// 点击行是否自动回发
        ///// </summary>
        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue(false)]
        //[Description("点击行是否自动回发")]
        //[Obsolete("此属性已废除，请使用EnableRowClickEvent属性")]
        //public bool AutoPostBack
        //{
        //    get
        //    {
        //        return EnableRowClickEvent;
        //    }
        //    set
        //    {
        //        EnableRowClickEvent = value;
        //    }
        //}

        ///// <summary>
        ///// 选中行是否自动回发
        ///// </summary>
        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue(false)]
        //[Description("选中行是否自动回发")]
        //[Obsolete("此属性已废除，请使用EnableRowSelectEvent属性")]
        //public bool EnableRowSelect
        //{
        //    get
        //    {
        //        return EnableRowSelectEvent;
        //    }
        //    set
        //    {
        //        EnableRowSelectEvent = value;
        //    }
        //}

        ///// <summary>
        ///// 双击行是否自动回发
        ///// </summary>
        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue(false)]
        //[Description("双击行是否自动回发")]
        //[Obsolete("此属性已废除，请使用EnableRowDoubleClickEvent属性")]
        //public bool EnableRowDoubleClick
        //{
        //    get
        //    {
        //        return EnableRowDoubleClickEvent;
        //    }
        //    set
        //    {
        //        EnableRowDoubleClickEvent = value;
        //    }
        //}


        ///// <summary>
        ///// 点击行是否自动回发
        ///// </summary>
        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue(false)]
        //[Description("点击行是否自动回发")]
        //[Obsolete("此属性已废除，请使用EnableRowClickEvent属性")]
        //public bool EnableRowClick
        //{
        //    get
        //    {
        //        return EnableRowClickEvent;
        //    }
        //    set
        //    {
        //        EnableRowClickEvent = value;
        //    }
        //}



        /// <summary>
        /// 选中行是否自动回发
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("选中行是否自动回发")]
        public bool EnableRowSelectEvent
        {
            get
            {
                object obj = FState["EnableRowSelectEvent"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                FState["EnableRowSelectEvent"] = value;
            }
        }

        /// <summary>
        /// 取消选中行是否自动回发
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("取消选中行是否自动回发")]
        public bool EnableRowDeselectEvent
        {
            get
            {
                object obj = FState["EnableRowDeselectEvent"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                FState["EnableRowDeselectEvent"] = value;
            }
        }


        /// <summary>
        /// 点击行是否自动回发
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("点击行是否自动回发")]
        public bool EnableRowClickEvent
        {
            get
            {
                object obj = FState["EnableRowClickEvent"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                FState["EnableRowClickEvent"] = value;
            }
        }


        /// <summary>
        /// 双击行是否自动回发
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("双击行是否自动回发")]
        public bool EnableRowDoubleClickEvent
        {
            get
            {
                object obj = FState["EnableRowDoubleClickEvent"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                FState["EnableRowDoubleClickEvent"] = value;
            }
        }

        /// <summary>
        /// 结束编辑是否自动回发（需要启用AllowCellEditing）
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("结束编辑是否自动回发（需要启用AllowCellEditing）")]
        public bool EnableAfterEditEvent
        {
            get
            {
                object obj = FState["EnableAfterEditEvent"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                FState["EnableAfterEditEvent"] = value;
            }
        }

        #endregion

        #region ForceFitAllTime/AutoExpandColumn

        ///// <summary>
        ///// 列的最小宽度
        ///// </summary>
        //[Category(CategoryName.LAYOUT)]
        //[DefaultValue(typeof(Unit), "")]
        //[Description("列的最小宽度")]
        //public Unit MinColumnWidth
        //{
        //    get
        //    {
        //        object obj = FState["MinColumnWidth"];
        //        return obj == null ? Unit.Empty : (Unit)obj;
        //    }
        //    set
        //    {
        //        FState["MinColumnWidth"] = value;
        //    }
        //}

        /// <summary>
        /// 自动扩展宽度以填充剩余空间的列（ColumnID）
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("自动扩展宽度以填充剩余空间的列（ColumnID）")]
        public string AutoExpandColumn
        {
            get
            {
                object obj = FState["AutoExpandColumn"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                FState["AutoExpandColumn"] = value;
            }
        }

        ///// <summary>
        ///// 自动扩展列的最大宽度
        ///// </summary>
        //[Category(CategoryName.LAYOUT)]
        //[DefaultValue(typeof(Unit), "")]
        //[Description("自动扩展列的最大宽度")]
        //public Unit AutoExpandColumnMax
        //{
        //    get
        //    {
        //        object obj = FState["AutoExpandColumnMax"];
        //        return obj == null ? Unit.Empty : (Unit)obj;
        //    }
        //    set
        //    {
        //        FState["AutoExpandColumnMax"] = value;
        //    }
        //}

        ///// <summary>
        ///// 自动扩展列的最小宽度
        ///// </summary>
        //[Category(CategoryName.LAYOUT)]
        //[DefaultValue(typeof(Unit), "")]
        //[Description("自动扩展列的最小宽度")]
        //public Unit AutoExpandColumnMin
        //{
        //    get
        //    {
        //        object obj = FState["AutoExpandColumnMin"];
        //        return obj == null ? Unit.Empty : (Unit)obj;
        //    }
        //    set
        //    {
        //        FState["AutoExpandColumnMin"] = value;
        //    }
        //}

        ///// <summary>
        ///// 成比例改变表格各列的宽度，以防止出现水平滚动条（仅在第一次加载表格时有效）
        ///// </summary>
        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue(false)]
        //[Description("成比例改变表格各列的宽度，以防止出现水平滚动条（仅在第一次加载表格时有效）")]
        //public bool ForceFitFirstTime
        //{
        //    get
        //    {
        //        object obj = FState["ForceFitFirstTime"];
        //        return obj == null ? false : (bool)obj;
        //    }
        //    set
        //    {
        //        FState["ForceFitFirstTime"] = value;
        //    }
        //}

        /// <summary>
        /// 成比例改变表格各列的宽度，以防止出现水平滚动条（第一次加载和之后改变表格宽度时都有效）
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("成比例改变表格各列的宽度，以防止出现水平滚动条（第一次加载和之后改变表格宽度时都有效）")]
        public bool ForceFit
        {
            get
            {
                object obj = FState["ForceFit"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                FState["ForceFit"] = value;
            }
        }

        ///// <summary>
        ///// 垂直滚动条的宽度（不设置则自动计算宽度，0则消除右侧预留的滚动条宽度）
        ///// </summary>
        //[Category(CategoryName.LAYOUT)]
        //[DefaultValue(typeof(Unit), "")]
        //[Description("垂直滚动条的宽度（不设置则自动计算宽度，0则消除右侧预留的滚动条宽度）")]
        //public Unit VerticalScrollWidth
        //{
        //    get
        //    {
        //        object obj = FState["VerticalScrollWidth"];
        //        return obj == null ? Unit.Empty : (Unit)obj;
        //    }
        //    set
        //    {
        //        FState["VerticalScrollWidth"] = value;
        //    }
        //}

        #endregion

        #region old code

        //private GridRowExpander _rowExpander;

        //[Category(CategoryName.OPTIONS)]
        //[NotifyParentProperty(true)]
        //[PersistenceMode(PersistenceMode.InnerProperty)]
        //public GridRowExpander RowExpander
        //{
        //    get
        //    {
        //        if (_rowExpander == null)
        //        {
        //            _rowExpander = new GridRowExpander();
        //        }
        //        return _rowExpander;
        //    }
        //}


        #endregion

        #region EnableCheckBoxSelect/EnableMultiSelect/SelectedRowIndexArray

        /// <summary>
        /// 启用多选框
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("启用多选框")]
        public bool EnableCheckBoxSelect
        {
            get
            {
                object obj = FState["EnableCheckBoxSelect"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                FState["EnableCheckBoxSelect"] = value;
            }
        }

        /// <summary>
        /// 只能通过多选框选中行（仅在启用EnableCheckBoxSelect属性时有效）
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("只能通过多选框选中行（仅在启用EnableCheckBoxSelect属性时有效）")]
        public bool CheckBoxSelectOnly
        {
            get
            {
                object obj = FState["CheckBoxSelectOnly"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                FState["CheckBoxSelectOnly"] = value;
            }
        }


        /// <summary>
        /// 启用多行选择
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("启用多行选择")]
        public bool EnableMultiSelect
        {
            get
            {
                object obj = FState["EnableMultiSelect"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                FState["EnableMultiSelect"] = value;
            }
        }


        /// <summary>
        /// [AJAX属性]选中的单元格（[行ID,列ID]）
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string[] SelectedCell
        {
            get
            {
                object obj = FState["SelectedCell"];
                return obj == null ? null : (string[])obj;
            }
            set
            {
                if (value == null || value.Length != 2)
                {
                    FState["SelectedCell"] = null;
                }
                else
                {
                    FState["SelectedCell"] = value;
                }
            }
        }


        /*
        /// <summary>
        /// [AJAX属性]选中行的索引（列表中的第一项）
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SelectedRowIndex
        {
            get
            {
                if (SelectedRowIndexArray.Length > 0)
                {
                    return SelectedRowIndexArray[0];
                }
                else
                {
                    return -1;
                }
            }
            set
            {
                SelectedRowIndexArray = new int[] { value };
            }
        }


        /// <summary>
        /// [AJAX属性]选中行的索引列表
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int[] SelectedRowIndexArray
        {
            get
            {
                object obj = FState["SelectedRowIndexArray"];
                return obj == null ? new int[] { } : (int[])obj;
            }
            set
            {
                FState["SelectedRowIndexArray"] = GetSortedArray(value).ToArray();
            }
        }

        private List<int> GetSortedArray(int[] value)
        {
            List<int> list = new List<int>();
            if (value != null)
            {
                list.AddRange(value);
                list.Sort();
            }
            return list;
        }
         * */

        ///// <summary>
        ///// Whether this property changed.
        ///// </summary>
        ///// <param name="newValue"></param>
        ///// <returns></returns>
        //private bool SelectedRowIndexArrayChanged(int[] newValue)
        //{
        //    if (newValue == null)
        //    {
        //        newValue = new int[] { };
        //    }
        //    if (newValue.Length > 0)
        //    {
        //        // Make sure this list order ASC [1, 2, 6, 8]
        //        List<int> intList = new List<int>(newValue);
        //        intList.Sort();
        //        newValue = intList.ToArray();
        //    }

        //    return new JArray(SelectedRowIndexArray).ToString() != new JArray(newValue).ToString();
        //}

        ///// <summary>
        ///// [AJAX属性]隐藏的列
        ///// </summary>
        //[Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public int[] HiddenColumnIndexArray
        //{
        //    get
        //    {
        //        List<int> hiddens = new List<int>();
        //        if (AllColumns.Count > 0)
        //        {
        //            int prefix = GetPrefixColumnNumber();
        //            for (int i = 0; i < AllColumns.Count; i++)
        //            {
        //                if (AllColumns[i].Hidden)
        //                {
        //                    hiddens.Add(i + prefix);
        //                }
        //            }
        //        }
        //        return hiddens.ToArray();
        //    }
        //    set
        //    {
        //        List<int> hiddens = GetSortedArray(value);
        //        int prefix = GetPrefixColumnNumber();
        //        for (int i = 0; i < AllColumns.Count; i++)
        //        {
        //            if (hiddens.Contains(i + prefix))
        //            {
        //                AllColumns[i].Hidden = true;
        //            }
        //            else
        //            {
        //                AllColumns[i].Hidden = false;
        //            }
        //        }
        //    }
        //}

        /// <summary>
        /// [AJAX属性]隐藏的列名称列表（逗号分隔）
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string[] HiddenColumns
        {
            get
            {
                List<string> hiddens = new List<string>();
                if (AllColumns.Count > 0)
                {
                    for (int i = 0; i < AllColumns.Count; i++)
                    {
                        GridColumn column = AllColumns[i];
                        if (column.Hidden)
                        {
                            hiddens.Add(column.ColumnID);
                        }
                    }
                }
                return hiddens.ToArray();
            }
            set
            {
                List<string> hiddens = new List<string>(value);
                for (int i = 0; i < AllColumns.Count; i++)
                {
                    GridColumn column = AllColumns[i];
                    if (hiddens.Contains(column.ColumnID))
                    {
                        column.Hidden = true;
                    }
                    else
                    {
                        column.Hidden = false;
                    }
                }
            }
        }

        #endregion

        #region SelectedRowIDArray


        /// <summary>
        /// [AJAX属性]选中行的索引（列表中的第一项）
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SelectedRowIndex
        {
            get
            {
                if (SelectedRowIndexArray.Length > 0)
                {
                    return SelectedRowIndexArray[0];
                }
                else
                {
                    return -1;
                }
            }
            set
            {
                SelectedRowIndexArray = new int[] { value };
            }
        }


        /// <summary>
        /// [AJAX属性]选中行的索引列表
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int[] SelectedRowIndexArray
        {
            get
            {
                if (SelectedRowIDArray == null || SelectedRowIDArray.Length == 0)
                {
                    return new int[] { };
                }

                // 如果是内存分页，当前是第2页，每页5条数据，则这个值是 startRowIndex == 5 
                int startRowIndex = GetStartRowIndex();

                List<string> selectedRowIds = new List<string>(SelectedRowIDArray);
                List<int> selectedRowIndexs = new List<int>();
                foreach (GridRow row in Rows)
                {
                    if (selectedRowIds.Contains(row.RowID))
                    {
                        selectedRowIndexs.Add(row.RowIndex - startRowIndex);
                    }
                }

                return selectedRowIndexs.ToArray();
            }
            set
            {
                if (value == null || value.Length == 0)
                {
                    SelectedRowIDArray = new string[0];
                    return;
                }

                // 如果是内存分页，当前是第2页，每页5条数据，则这个值是 startRowIndex == 5 
                int startRowIndex = GetStartRowIndex();

                List<string> selectedRowIds = new List<string>();
                List<int> selectedRowIndexs = new List<int>(value);
                foreach (GridRow row in Rows)
                {
                    if (selectedRowIndexs.Contains(row.RowIndex - startRowIndex))
                    {
                        selectedRowIds.Add(row.RowID);
                    }
                }

                SelectedRowIDArray = selectedRowIds.ToArray();
            }
        }

        /// <summary>
        /// 选中的行
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public GridRow SelectedRow
        {
            get
            {
                return FindRow(SelectedRowID);
            }
        }

        /// <summary>
        /// [AJAX属性]选中的行ID
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("[AJAX属性]选中的行ID")]
        public string SelectedRowID
        {
            get
            {
                if (SelectedRowIDArray != null && SelectedRowIDArray.Length > 0)
                {
                    return SelectedRowIDArray[0];
                }
                else
                {
                    return String.Empty;
                }
            }
            set
            {
                SelectedRowIDArray = new string[] { value };
            }
        }

        /// <summary>
        /// [AJAX属性]选中的行ID列表
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [Description("[AJAX属性]选中的行节点ID列表")]
        [TypeConverter(typeof(StringArrayConverter))]
        public string[] SelectedRowIDArray
        {
            get
            {
                object obj = FState["SelectedRowIDArray"];
                return obj == null ? new string[0] : (string[])obj;
            }
            set
            {
                FState["SelectedRowIDArray"] = value;
            }
        }

        #endregion

        #region DataSource/DataKeyNames/DataKeys

        private object _dataSource = null;

        /// <summary>
        /// 数据源
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object DataSource
        {
            set
            {
                _dataSource = value;
            }
            get
            {
                return _dataSource;
            }
        }


        /// <summary>
        /// 行关键字段
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(null)]
        [Description("行关键字段")]
        [TypeConverter(typeof(StringArrayConverter))]
        public string[] DataKeyNames
        {
            get
            {
                object obj = FState["DataKeyNames"];
                return obj == null ? null : (string[])obj;
            }
            set
            {
                FState["DataKeyNames"] = value;
            }
        }


        private List<object[]> _dataKeys = null;

        /// <summary>
        /// 行关键字段的值
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<object[]> DataKeys
        {
            get
            {
                if (_dataKeys == null)
                {
                    _dataKeys = new List<object[]>();

                    for (int i = 0, count = _rows.Count; i < count; i++)
                    {
                        _dataKeys.Add(_rows[i].DataKeys);
                    }
                }
                else
                {
                    for (int i = _dataKeys.Count, count = _rows.Count; i < count; i++)
                    {
                        _dataKeys.Add(_rows[i].DataKeys);
                    }

                }

                return _dataKeys;
            }
        }


        #endregion

        #region GroupColumns/Columns/Rows

        private ControlBaseCollection _pageItems;

        /// <summary>
        /// 分页工具条项集合
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Editor(typeof(ControlBaseItemsEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public virtual ControlBaseCollection PageItems
        {
            get
            {
                if (_pageItems == null)
                {
                    _pageItems = new ControlBaseCollection(this);
                }
                return _pageItems;
            }
        }



        //private GridGroupColumnCollection _groupColumns;

        ///// <summary>
        ///// 分组列数据
        ///// </summary>
        //[Category(CategoryName.OPTIONS)]
        //[NotifyParentProperty(true)]
        //[PersistenceMode(PersistenceMode.InnerProperty)]
        //[Editor(typeof(CollectionEditor), typeof(System.Drawing.Design.UITypeEditor))]
        //public virtual GridGroupColumnCollection GroupColumns
        //{
        //    get
        //    {
        //        if (_groupColumns == null)
        //        {
        //            _groupColumns = new GridGroupColumnCollection(this);
        //        }
        //        return _groupColumns;
        //    }
        //}

        //private GridColumnCollection _allColumnsInternal;
        ///// <summary>
        ///// 全部的列
        ///// </summary>
        //internal virtual GridColumnCollection AllColumnsInternal
        //{
        //    get
        //    {
        //        if (_allColumnsInternal == null)
        //        {
        //            _allColumnsInternal = new GridColumnCollection(this);
        //        }
        //        return _allColumnsInternal;
        //    }
        //}

        internal Collection<GridColumn> _allColumns;

        /// <summary>
        /// 全部的列
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual Collection<GridColumn> AllColumns
        {
            get
            {
                if (_allColumns == null)
                {
                    ResolveAllColumns();
                }

                return _allColumns;
            }
        }

        private void ResolveAllColumns()
        {
            _allColumns = new Collection<GridColumn>();

            foreach (GridColumn column in Columns)
            {
                _allColumns.Add(column);
                if (column is GroupField)
                {
                    ResolveAllColumns(column as GroupField);
                }
            }
        }

        private void ResolveAllColumns(GroupField column)
        {
            foreach (GridColumn subColumn in column.Columns)
            {
                _allColumns.Add(subColumn);
                if (subColumn is GroupField)
                {
                    ResolveAllColumns(subColumn as GroupField);
                }
            }
        }


        private GridColumnCollection _columns;

        /// <summary>
        /// 列数据
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Editor(typeof(GridColumnsEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public virtual GridColumnCollection Columns
        {
            get
            {
                if (_columns == null)
                {
                    _columns = new GridColumnCollection(this);

                    // Columns改变后，要更新AllColumns
                    _columns.ItemsChange += _columns_ItemsChange;
                }
                return _columns;
            }
        }

        private void _columns_ItemsChange()
        {
            _allColumns = null;
        }


        private GridRowCollection _rows;

        /// <summary>
        /// 行数据
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual GridRowCollection Rows
        {
            get
            {
                if (_rows == null)
                {
                    _rows = new GridRowCollection();
                }
                return _rows;
            }
        }
        #endregion

        #region F_Rows

        /// <summary>
        /// 保存的行数据（内部使用）
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public JArray F_Rows
        {
            get
            {
                //JObject jo = new JObject();

                //JArray valuesJA = new JArray();
                //JArray datakeysJA = new JArray();
                //JArray statesJA = new JArray();
                //foreach (GridRow row in Rows)
                //{
                //    valuesJA.Add(new JArray(row.Values));
                //    datakeysJA.Add(new JArray(row.DataKeys));
                //    statesJA.Add(new JArray(row.ToShortStates()));
                //}
                //jo.Add("Values", valuesJA);
                //jo.Add("DataKeys", datakeysJA);
                //jo.Add("States", statesJA);

                //return jo;

                JArray ja = new JArray();

                foreach (GridRow row in Rows)
                {
                    JObject jo = new JObject();

                    jo.Add("0", new JArray(row.Values));
                    jo.Add("1", new JArray(row.DataKeys));

                    if (row.HasStates())
                    {
                        jo.Add("2", new JArray(row.States));
                    }


                    jo.Add("6", new JValue(row.RowID));


                    //if (!String.IsNullOrEmpty(DataTextField))
                    //{
                    //    jo.Add("7", new JValue(row.RowText));
                    //}

                    ja.Add(jo);
                }

                return ja;
            }
            set
            {
                //// 注意，此时不能清空 SelectedRowIndexArray 
                //// 现在只是从FState中恢复数据，如果清空 SelectedRowIndexArray ，可能会导致 SelectedRowIndexArray 状态不对
                //ClearRows();

                //JArray valuesArray = value.Value<JArray>("Values"); // value.getJArray("Values");
                //JArray dataKeysArray = value.Value<JArray>("DataKeys"); //value.getJArray("DataKeys");
                //JArray statesArray = value.Value<JArray>("States");  //value.getJArray("States");
                //for (int i = 0, length = valuesArray.Count; i < length; i++)
                //{
                //    GridRow row = new GridRow(this, null, i);

                //    // row.Values
                //    row.Values = JSONUtil.ObjectArrayFromJArray(valuesArray[i].Value<JArray>()); // .getJArray(i));

                //    // row.DataKeys
                //    row.DataKeys = JSONUtil.ObjectArrayFromJArray(dataKeysArray[i].Value<JArray>()); //.getJArray(i));

                //    // row.States
                //    row.FromShortStates(JSONUtil.ObjectArrayFromJArray(statesArray[i].Value<JArray>()));

                //    Rows.Add(row);
                //    //Controls.Add(row);

                //    //row.InitTemplateContainers();
                //}

                // 注意，此时不能清空 SelectedRowIndexArray 
                // 现在只是从FState中恢复数据，如果清空 SelectedRowIndexArray ，可能会导致 SelectedRowIndexArray 状态不对c
                ClearRows();

                for (int i = 0, length = value.Count; i < length; i++)
                {
                    JObject rowValue = value[i] as JObject;

                    GridRow row = new GridRow(this, null, i);

                    // row.Values
                    row.Values = JSONUtil.ObjectArrayFromJArray(rowValue["0"] as JArray);


                    // row.DataKeys
                    row.DataKeys = JSONUtil.ObjectArrayFromJArray(rowValue["1"] as JArray);


                    // row.States
                    row.RecoverStates(JSONUtil.ObjectArrayFromJArray(rowValue["2"] as JArray));


                    var dataID = rowValue["6"];
                    if (dataID != null)
                    {
                        row.RowID = dataID.Value<string>();
                    }

                    //var dataText = rowValue["7"];
                    //if (dataText != null)
                    //{
                    //    row.RowText = dataText.Value<string>();
                    //}


                    Rows.Add(row);
                }

            }
        }

        #endregion

        #region oldcode

        //protected override void LoadFState(JObject state, string property)
        //{
        //    base.LoadFState(state, property);

        //    if (property == "F_Rows")
        //    {
        //        XRowsFromJSON(state.getJObject(property));
        //    }
        //}

        //protected override void OnInit(EventArgs e)
        //{
        //    base.OnInit(e);

        //    // Init Columns property.
        //    int columnIndex = 0;
        //    foreach (GridColumn column in Columns)
        //    {
        //        column.Grid = this;
        //        column.ColumnIndex = columnIndex;
        //        columnIndex++;
        //    }

        //    SaveXProperty("F_Rows", XRowsToJSON().ToString());
        //    //SaveXProperty("SelectedRowIndexArray", new JArray(SelectedRowIndexArray).ToString());
        //}

        //protected override void OnBothPreRender()
        //{
        //    base.OnBothPreRender();

        //    // Rows has been changed in server-side code after onInit.
        //    if (XPropertyModified("F_Rows", XRowsToJSON().ToString()))
        //    {
        //        FState.AddModifiedProperty("F_Rows");
        //    }

        //    // Make sure SelectedRowIndexArray property exist in F_STATE during page's first load.
        //    if (!Page.IsPostBack)
        //    {
        //        FState.AddModifiedProperty("SelectedRowIndexArray");
        //    }

        //    //if (XPropertyModified("SelectedRowIndexArray", new JArray(SelectedRowIndexArray).ToString()))
        //    //{
        //    //    FState.AddModifiedProperties("SelectedRowIndexArray");
        //    //}
        //    //else
        //    //{
        //    //    FState.RemoveModifiedProperties("SelectedRowIndexArray");
        //    //}
        //}

        //protected override void SaveFState(JObject state, string property)
        //{
        //    if (property == "F_Rows")
        //    {
        //        state.put(property, XRowsToJSON());
        //    }
        //}

        //private JObject XRowsToJSON()
        //{
        //    JObject jo = new JObject();

        //    JArray valuesJA = new JArray();
        //    JArray datakeysJA = new JArray();
        //    foreach (GridRow row in Rows)
        //    {
        //        valuesja.Add(new JArray(row.Values));
        //        datakeysja.Add(new JArray(row.DataKeys));
        //    }
        //    jo.Add("Values", valuesJA);
        //    jo.Add("DataKeys", datakeysJA);

        //    return jo;
        //}

        //private void XRowsFromJSON(JObject jo)
        //{
        //    JArray valuesArray = jo.getJArray("Values");
        //    JArray dataKeysArray = jo.getJArray("DataKeys");
        //    for (int i = 0, length = valuesArray.Count; i < length; i++)
        //    {
        //        GridRow row = new GridRow();

        //        // row.Values
        //        row.Values = JSONUtil.StringArrayFromJArray(valuesArray.getJArray(i));

        //        // row.DataKeys
        //        row.DataKeys = JSONUtil.ObjectArrayFromJArray(dataKeysArray.getJArray(i));

        //        Rows.Add(row);
        //    }
        //}

        #endregion

        #region SelectedRowsHiddenFieldID

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        private string SelectedCellHiddenFieldID
        {
            get
            {
                return String.Format("{0}_SelectedCell", ClientID);
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        private string SelectedRowsHiddenFieldID
        {
            get
            {
                return String.Format("{0}_SelectedRows", ClientID);
            }
        }

        //[Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //private string SelectedRowIndexArrayHiddenFieldID
        //{
        //    get
        //    {
        //        return String.Format("{0}_SelectedRowIndexArray", ClientID);
        //    }
        //}

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        private string HiddenColumnsHiddenFieldID
        {
            get
            {
                return String.Format("{0}_HiddenColumns", ClientID);
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        private string StatesHiddenFieldID
        {
            get
            {
                return String.Format("{0}_States", ClientID);
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        private string ModifiedDataHiddenFieldID
        {
            get
            {
                return String.Format("{0}_ModifiedData", ClientID);
            }
        }

        //[Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //private string NewAddedRowsHiddenFieldID
        //{
        //    get
        //    {
        //        return String.Format("{0}_NewAddedRows", ClientID);
        //    }
        //}

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        private string DeletedRowsHiddenFieldID
        {
            get
            {
                return String.Format("{0}_DeletedRows", ClientID);
            }
        }

        ///// <summary>
        ///// 实际绑定到页面上的值
        ///// </summary>
        //[Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //internal int[] NeedPersistStateColumnIndexArray
        //{
        //    get
        //    {
        //        object obj = FState["NeedPersistStateColumnIndexArray"];
        //        return obj == null ? null : (int[])obj;
        //    }
        //    set
        //    {
        //        FState["NeedPersistStateColumnIndexArray"] = value;
        //    }
        //}

        //private string GetNeedPersistStateColumnIndexID(int columnIndex)
        //{
        //    return String.Format("{0}_columnIndex{1}", ClientID, columnIndex);
        //}


        #region old code
        //[Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //[Description("客户端分页时，开始行的序号")]
        //private string EnableClientPagingStartRowIndexID
        //{
        //    get
        //    {
        //        return String.Format("{0}_startRowIndex", ClientID);
        //    }
        //}

        //[Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //[Description("客户端分页时，开始行的序号")]
        //internal int EnableClientPagingStartRowIndex
        //{
        //    get
        //    {
        //        object obj = BoxState["EnableClientPagingStartRowIndex"];
        //        return obj == null ? 0 : (int)obj;
        //    }
        //    set
        //    {
        //        BoxState["EnableClientPagingStartRowIndex"] = value;
        //    }
        //} 
        #endregion

        #endregion

        #region OnFirstPreRender/OnAjaxPreRender

        #region Render_IDS

        private string Render_SelectModelID
        {
            get
            {
                return String.Format("{0}_selModel", XID);
            }
        }

        private string Render_GridStoreID
        {
            get
            {
                return String.Format("{0}_store", XID);
            }
        }

        private string Render_GridFieldsID
        {
            get
            {
                return String.Format("{0}_fields", XID);
            }
        }

        private string Render_GridColumnsID
        {
            get
            {
                return String.Format("{0}_columns", XID);
            }
        }

        //private string Render_GridRowExpanderID
        //{
        //    get
        //    {
        //        return String.Format("{0}_expander", XID);
        //    }
        //}

        private string Render_GridGroupColumnID
        {
            get
            {
                return String.Format("{0}_groupcolumn", XID);
            }
        }

        internal string Render_PagingID
        {
            get
            {
                return String.Format("{0}_paging", XID);
            }
        }

        //// FineUIAjax回发时，列是否发生变化
        //private bool _FineUIAjaxColumnsChanged = false;

        #endregion

        #region OnAjaxPreRender OnFirstPreRender

        /// <summary>
        /// 渲染 HTML 之前调用（AJAX回发）
        /// </summary>
        protected override void OnAjaxPreRender()
        {
            base.OnAjaxPreRender();

            StringBuilder sb = new StringBuilder();

            //bool needUpdateSortIcon = false;

            bool dataReloaded = false;
            if (AllowPaging)
            {
                // 不论这三个属性是在客户端还是在服务器端被改变，都需要执行grid.getBottomToolbar().load函数
                // 如果不是数据库分页，则F_Rows不会变化，但是必须执行x_loadData
                if (PropertyModified("PageIndex", "PageSize", "RecordCount"))
                {
                    sb.AppendFormat("{0}.f_getPaging().f_update({1});", XID, GetPagingBuilder());
                    //sb.AppendFormat("{0}.f_loadData();", XID);

                    //needUpdateSortIcon = true;

                    dataReloaded = true;
                }
            }

            if (PropertyModified("F_Rows"))
            {
                dataReloaded = true;

                ////if (ClientPropertyModifiedInServer("F_Rows"))
                //if (!dataReloaded)
                //{
                //    sb.AppendFormat("{0}.f_loadData();", XID);

                //    //needUpdateSortIcon = true;

                //    dataReloaded = true;
                //}

                //// 如果F_Rows改变了，则每行的模版列内容应该也要变化
                //PageManager.Instance.AddAjaxGridClientID(ClientID);
            }

            // 如果需要更新 模板列，则简单的重新加载表格即可
            if (_needUpdateTemplateFields)
            {
                dataReloaded = true;
            }

            // 本次AJAX请求重新加载的表格
            if (dataReloaded)
            {
                sb.AppendFormat("{0}.f_loadData();", XID);

                PageManager.Instance.AddAjaxGridReloadedClientID(ClientID);
            }
            else
            {
                // 如果不重新加载客户端数据，但是调用了 DataBind 函数，则提交更改
                if (AllowCellEditing && _databindInFineUIAjaxPostBack)
                {
                    CommitChanges();
                }
            }


            //bool selectRowsScriptRegistered = false;
            //if (AllowCellEditing)
            //{
            //    if (PropertyModified("SelectedCell"))
            //    {
            //        sb.AppendFormat("{0}.f_selectCell();", XID);
            //    }
            //}
            //else
            //{
            //    if (PropertyModified("SelectedRowIndexArray"))
            //    {
            //        sb.AppendFormat("{0}.f_selectRows();", XID);
            //        selectRowsScriptRegistered = true;
            //    }
            //}


            if (PropertyModified("HiddenColumns"))
            {
                sb.AppendFormat("{0}.f_updateColumnsHiddenStatus();", XID);
            }


            // 如果 SelectedCell 属性改变 或者 数据重新加载了
            if (PropertyModified("SelectedCell") || dataReloaded)
            {
                sb.AppendFormat("{0}.f_selectCell();", XID);
            }

            // 如果 SelectedRowIndexArray 属性改变 或者 数据重新加载了
            if (PropertyModified("SelectedRowIDArray") || dataReloaded)
            {
                sb.AppendFormat("{0}.f_selectRows();", XID);
            }

            // 如果 ExpandAllRowExpanders 属性改变 或者 数据重新加载了 或者 在后台手工操作了展开折叠属性
            if (PropertyModified("ExpandAllRowExpanders") || dataReloaded || _registerScriptRowExpanders)
            {
                RegisterRowExpanderScript(sb);
            }

            //bool rowExpandersScriptRegistered = false;
            //if (PropertyModified("ExpandAllRowExpanders") || _registerScriptRowExpanders)
            //{
            //    if (ExpandAllRowExpanders)
            //    {
            //        sb.AppendFormat("{0}.f_expandAllRows();", XID);
            //    }
            //    else
            //    {
            //        sb.AppendFormat("{0}.f_collapseAllRows();", XID);
            //    }
            //    rowExpandersScriptRegistered = true;
            //}

            //// 如果数据重新加载了，即每行的数据都更新了
            //if (dataReloaded)
            //{
            //    if (!rowExpandersScriptRegistered)
            //    {
            //        // 数据重新加载了，如果没有注册行扩展列的脚本，需要注册展开所有行扩展列的脚本
            //        if (ExpandAllRowExpanders)
            //        {
            //            sb.AppendFormat("{0}.f_expandAllRows();", XID);
            //        }
            //        else
            //        {
            //            sb.AppendFormat("{0}.f_collapseAllRows();", XID);
            //        }
            //    }


            //    if (!AllowCellEditing)
            //    {
            //        // 数据重新加载了，如果没有注册选中行的脚本，需要注册重新选中行的脚本
            //        if (!selectRowsScriptRegistered)
            //        {
            //            sb.AppendFormat("{0}.f_selectRows();", XID);
            //        }
            //    }

            //}

            AddAjaxScript(sb);
        }

        private void RegisterRowExpanderScript(StringBuilder sb)
        {
            GridColumn rowExpanderColumn = GetRowExpanderColumn();
            if (rowExpanderColumn != null)
            {
                if (ExpandAllRowExpanders)
                {
                    sb.AppendFormat("{0}.f_expandAllRows();", XID);
                }
                else
                {
                    sb.AppendFormat("{0}.f_collapseAllRows();", XID);
                }
            }
        }

        /// <summary>
        /// 获取行扩展列
        /// </summary>
        /// <returns></returns>
        internal GridColumn GetRowExpanderColumn()
        {
            GridColumn expanderColumn = null;
            foreach (GridColumn column in Columns)
            {
                if (column is TemplateField && (column as TemplateField).RenderAsRowExpander)
                {
                    expanderColumn = column;
                    break;
                }
            }
            return expanderColumn;
        }

        /// <summary>
        /// 渲染 HTML 之前调用（页面第一次加载或者普通回发）
        /// </summary>
        protected override void OnFirstPreRender()
        {
            // 确保 F_Rows 在页面第一次加载时都存在于f_state中
            FState.AddModifiedProperty("F_Rows");
            if (EnableSummary)
            {
                FState.AddModifiedProperty("SummaryData");
            }
            if (SelectedRowIDArray.Length > 0)
            {
                FState.AddModifiedProperty("SelectedRowIDArray");
            }

            // 不需要手工添加 SelectedRowIndexArray 属性，是因为只能通过代码设置此属性
            // 只要通过代码设置了 SelectedRowIndexArray 属性，则一定会存在于 F_States


            base.OnFirstPreRender();


            //ResourceManager.Instance.AddJavaScriptComponent("grid");
            JsArrayBuilder pluginBuilder = new JsArrayBuilder();

            #region selectModel/gridStore/gridColumn

            #region old code
            //string dataScript = "var grid_data=[['My_Item1The id of a column in this grid that should expand to fill unused space. This id can not be 0.','1','2008'],['My_Item2','2','2007']];";
            //string storeScript = "var grid_store = new Ext.data.SimpleStore({fields:[{name:'name1'},{name:'value'},{name:'year'}]});\r\ngrid_store.loadData(grid_data);";
            //string storeScript = "var grid_store = new Ext.data.SimpleStore({fields:['name1','value1','year1'],data:[['My_Item1The id of a column in this grid that should expand to fill unused space. This id can not be 0.','1','2008'],['My_Item2','2','2007']]});";
            //OB.AddProperty(OptionName.Columns, "[{id:'name2', header: 'Price', sortable: true},{header: 'Price2', sortable: true},{header: 'Price3', sortable: true}]", true);

            #endregion

            string gridSelectModelScript = GetGridSelectModel();
            OB.AddProperty("selModel", Render_SelectModelID, true);


            string gridColumnsScript = GetGridColumnScript(pluginBuilder);
            OB.AddProperty("columns", Render_GridColumnsID, true);

            string gridStoreScript = GetGridStore();
            OB.AddProperty("store", Render_GridStoreID, true);

            OB.AddProperty("f_fields", Render_GridFieldsID, true);
            //Console.WriteLine(RowExpander.DataFields);

            #endregion

            #region Width

            //if (MinColumnWidth != Unit.Empty)
            //{
            //    OB.AddProperty("minColumnWidth", MinColumnWidth.Value);
            //}

            //string autoExpandColumnID = AutoExpandColumn; // GetAutoExpandColumnID();
            //if (String.IsNullOrEmpty(autoExpandColumnID))
            //{
            //    autoExpandColumnID = GetAutoExpandColumnID();
            //}

            //if (!String.IsNullOrEmpty(autoExpandColumnID))
            //{
            //    OB.AddProperty("autoExpandColumn", autoExpandColumnID);

            //    if (AutoExpandColumnMax != Unit.Empty)
            //    {
            //        OB.AddProperty("autoExpandMax", AutoExpandColumnMax.Value);
            //    }

            //    if (AutoExpandColumnMin != Unit.Empty)
            //    {
            //        OB.AddProperty("autoExpandMin", AutoExpandColumnMin.Value);
            //    }
            //}



            #endregion

            #region viewConfig

            JsObjectBuilder viewBuilder = new JsObjectBuilder();
            if (!String.IsNullOrEmpty(EmptyText))
            {
                viewBuilder.AddProperty("deferEmptyText", false);
                viewBuilder.AddProperty("emptyText", EmptyText);
            }

            if (!EnableAlternateRowColor)
            {
                viewBuilder.AddProperty("stripeRows", false);
            }

            if (EnableTextSelection)
            {
                viewBuilder.AddProperty("enableTextSelection", true);
            }

            viewBuilder.AddProperty("getRowClass", JsHelper.GetFunction("return 'f-grid-row';"), true);
            //viewBuilder.AddProperty("selectedItemCls", "x-grid-row-selected f-grid-row-selected");

            if (viewBuilder.Count > 0)
            {
                OB.AddProperty("viewConfig", viewBuilder);
            }


            #endregion

            #region Properties

            if (!String.IsNullOrEmpty(DataIDField))
            {
                OB.AddProperty("f_idField", DataIDField);
            }



            if (EnableColumnLines)
            {
                OB.AddProperty("columnLines", true);
            }

            if (!EnableRowLines)
            {
                OB.AddProperty("rowLines", false);
            }



            if (ForceFit)
            {
                OB.AddProperty("forceFit", true);
            }

            //OB.AddProperty("enableHdMenu", EnableHeaderMenu);

            //if (EnableHeaderMenu)
            //{
            //    // 启用标题栏菜单，但是不启用标题栏菜单中的隐藏列功能
            //    if (!EnableColumnHide)
            //    {
            //        OB.AddProperty("enableColumnHide", false);
            //    }
            //}



            if (!ShowGridHeader)
            {
                OB.AddProperty("hideHeaders", true);
            }

            if (!EnableMouseOverColor)
            {
                OB.AddProperty("trackMouseOver", false);
            }

            // 延迟渲染
            if (!EnableDelayRender)
            {
                OB.AddProperty("deferRowRender", false);
            }



            #endregion

            #region EnableRowClickEvent

            if (EnableRowClickEvent)
            {
                string validateScript = "var args='RowClick$'+record.getId();";
                validateScript += GetPostBackEventReference("#RowClick#").Replace("'#RowClick#'", "args");

                //string rowClickScript = JsHelper.GetFunction(validateScript, "grid", "record", "item", "index"); // String.Format("function(grid,rowIndex,e){{{0}}}", validateScript);

                //OB.Listeners.AddProperty("itemclick", rowClickScript, true);
                AddListener("itemclick", validateScript, "grid", "record", "item", "index");
            }

            if (EnableRowDoubleClickEvent)
            {
                string validateScript = "var args='RowDoubleClick$'+record.getId();";
                validateScript += GetPostBackEventReference("#RowDoubleClick#").Replace("'#RowDoubleClick#'", "args");

                //string rowClickScript = JsHelper.GetFunction(validateScript, "grid", "record", "item", "index"); //String.Format("function(grid,rowIndex,e){{{0}}}", validateScript);

                //OB.Listeners.AddProperty("itemdblclick", rowClickScript, true);
                AddListener("itemdblclick", validateScript, "grid", "record", "item", "index");
            }

            #endregion

            #region AllowPaging

            string pagingScript = String.Empty;

            if (AllowPaging)
            {
                OptionBuilder pagingBuilder = GetPagingBuilder();

                if (!ShowPagingMessage)
                {
                    pagingBuilder.AddProperty("displayInfo", false);
                }
                else
                {
                    pagingBuilder.AddProperty("displayInfo", true);
                }

                pagingBuilder.AddProperty("store", Render_GridStoreID, true);
                //// Hide refresh button, we don't implement this logic now.
                //pagingBuilder.Listeners.AddProperty("beforerender", JsHelper.GetFunction("this.f_hideRefresh();"), true);

                string postbackScript = String.Empty;
                postbackScript = GetPostBackEventReference("#PLACEHOLDER#");
                string loadPageScript = JsHelper.GetFunction(postbackScript.Replace("'#PLACEHOLDER#'", "'Page$'+(pageNum-1)") + "return false;", "bar", "pageNum");

                pagingBuilder.Listeners.AddProperty("beforechange", loadPageScript, true);


                if (PageItems.Count > 0)
                {
                    JsArrayBuilder ab = new JsArrayBuilder();
                    foreach (ControlBase item in PageItems)
                    {
                        if (item.Visible)
                        {
                            ab.AddProperty(String.Format("{0}", item.XID), true);
                        }
                    }

                    pagingBuilder.AddProperty("items", ab.ToString(), true);
                }

                pagingBuilder.AddProperty("xtype", "simplepagingtoolbar");
                pagingBuilder.AddProperty("dock", "bottom");

                pagingScript = String.Format("var {0}={1};", Render_PagingID, pagingBuilder);

                //OB.AddProperty("bbar", Render_PagingID, true);
            }

            #endregion

            #region remove fx

            OB.AddProperty("draggable", false);
            //OB.AddProperty("enableColumnMove", false);
            OB.AddProperty("enableDragDrop", false);

            if (!EnableColumnResize)
            {
                OB.AddProperty("enableColumnResize", false);
            }

            #endregion

            #region AllowSorting


            //// 如果启用服务器端排序，则需要注册headerclick事件处理
            //if (AllowSorting)
            //{
            //    string headerClickScript = "if(!cmp.getColumnModel().config[columnIndex].sortable){return false;}";
            //    headerClickScript += "var args='Sort$'+columnIndex;";
            //    headerClickScript += GetPostBackEventReference("#SORT#").Replace("'#SORT#'", "args");

            //    // 告诉 store 本次排序已经处理了，不要重复处理了
            //    headerClickScript += "cmp.getStore().headerclickprocessed=true;";

            //    //string headerClickScript = String.Format("function(grid,columnIndex){{{0}}}", validateScript);
            //    OB.Listeners.AddProperty("headerclick", JsHelper.GetFunction(headerClickScript, "cmp", "columnIndex"), true);
            //}

            #endregion

            #region EnableSummary

            JsArrayBuilder features = new JsArrayBuilder();

            if (EnableSummary)
            {
                JsObjectBuilder summaryFeature = new JsObjectBuilder();
                summaryFeature.AddProperty("ftype", "summary");
                summaryFeature.AddProperty("id", "summary");

                if (SummaryPosition != SummaryPosition.Flow)
                {
                    summaryFeature.AddProperty("dock", SummaryPositionHelper.GetName(SummaryPosition));
                }

                //if (SummaryHidden)
                //{
                //    summaryFeature.AddProperty("showSummaryRow", false);
                //}

                features.AddProperty(summaryFeature);
            }


            if (features.Count > 0)
            {
                OB.AddProperty("features", features);
            }

            #endregion

            #region Listeners - afterrender

            StringBuilder viewreadySB = new StringBuilder();

            // Note: this.f_state['F_Rows']['Values'] will always rendered to the client side.
            //viewreadySB.Append("cmp.f_updateTpls();");

            if (AllowSorting)
            {
                viewreadySB.AppendFormat("cmp.f_initSortHeaders();");
            }

            if (!AllowCellEditing)
            {
                viewreadySB.Append("cmp.f_selectRows();");
            }


            //if (EnableTextSelection)
            //{
            //    cls += " x-grid-selectable";

            //    viewreadySB.Append("cmp.f_enableTextSelection();");
            //}

            // 展开所有的行扩展列
            if (ExpandAllRowExpanders)
            {
                viewreadySB.Append("cmp.f_expandAllRows();");
            }

            if (AllowColumnLocking)
            {
                // 必须延时调用 doLayout，否则显示不正常
                viewreadySB.Append("cmp.doLayout();");
            }

            string viewreadyScript = viewreadySB.ToString();

            if (!String.IsNullOrEmpty(viewreadyScript))
            {
                viewreadyScript = "window.setTimeout(function(){" + viewreadyScript + "},200);";

                // viewready在enableLocking时不会触发，只好改成afterrender
                //OB.Listeners.AddProperty("afterrender", JsHelper.GetFunction(viewreadyScript, "cmp"), true);
                AddListener("afterrender", viewreadyScript, "cmp");
            }

            #endregion

            #region cls

            string cls = CssClass;

            if (RowVerticalAlign != VerticalAlign.Middle)
            {
                cls += String.Format("row-align-{0}", VerticalAlignName.GetName(RowVerticalAlign));
            }

            cls = cls.Trim();
            if (!String.IsNullOrEmpty(cls))
            {
                OB.AddProperty("cls", cls);
            }

            #endregion

            #region Listeners - render

            StringBuilder renderSB = new StringBuilder();

            // 加载表格数据
            renderSB.Append("cmp.f_loadData();");

            //// 隐藏列
            //if (HiddenColumnIndexArray != null && HiddenColumnIndexArray.Length > 0)
            //{
            //    renderSB.Append("cmp.f_updateColumnsHiddenStatus();");
            //}

            //OB.Listeners.AddProperty("render", JsHelper.GetFunction(renderSB.ToString(), "cmp"), true);
            AddListener("render", renderSB.ToString(), "cmp");

            #endregion

            #region AllowCellEditing

            string cellEditScript = String.Empty;

            if (AllowCellEditing)
            {
                string pluginId = String.Format("{0}_cellEditing", XID);

                JsObjectBuilder cellEditBuilder = new JsObjectBuilder();
                cellEditBuilder.AddProperty("pluginId", pluginId);
                cellEditBuilder.AddProperty("clicksToEdit", ClicksToEdit);

                cellEditScript = String.Format("var {0}=Ext.create('Ext.grid.plugin.CellEditing',{1});", pluginId, cellEditBuilder);

                pluginBuilder.AddProperty(pluginId, true);

                if (EnableAfterEditEvent)
                {
                    string validateScript = "var args='AfterEdit$'+e.record.getId()+'$'+e.column.id;";
                    validateScript += GetPostBackEventReference("#AfterEdit#").Replace("'#AfterEdit#'", "args");

                    //string rowClickScript = String.Format("function(editor,e){{{0}}}", validateScript);
                    //OB.Listeners.AddProperty("edit", rowClickScript, true);
                    AddListener("edit", validateScript, "editor", "e");
                }

                OB.AddProperty("f_cellEditing", pluginId, true);
            }


            if (AllowColumnLocking)
            {
                OB.AddProperty("enableLocking", true);
            }
            else
            {
                OB.AddProperty("enableLocking", false);
            }

            #endregion

            #region pluginBuilder

            if (pluginBuilder.Count > 0)
            {
                OB.AddProperty("plugins", pluginBuilder.ToString(), true);
            }

            #endregion

            StringBuilder sb = new StringBuilder();
            sb.Append(gridSelectModelScript + gridStoreScript + pagingScript + gridColumnsScript + cellEditScript);
            sb.AppendFormat("var {0}=Ext.create('Ext.grid.Panel',{1});", XID, OB);

            AddStartupScript(sb.ToString());

            #region old code

            ////List<string> totalModifiedProperties = FState.GetTotalModifiedProperties();
            ////if (SelectedRowIndexArray.Length > 0)
            ////{
            ////    string selectScript = String.Empty;
            ////    if (totalModifiedProperties.Contains("SelectedRowIndexArray"))
            ////    {
            ////        selectScript = String.Format("{0}.f_selectRows();", XID);
            ////    }
            ////    else
            ////    {
            ////        selectScript = String.Format("{0}.selectRows({1});", Render_SelectModelID, new JArray(SelectedRowIndexArray));
            ////    }
            ////    sb.Append(JsHelper.GetDeferScript(selectScript, 200));
            ////}

            //// Make sure SelectedRowIndexArray property exist in F_STATE during page's first load.
            //sb.Append(JsHelper.GetDeferScript(String.Format("{0}.f_selectRows();", XID), 200));

            #endregion
        }


        private string GetSortColummID()
        {
            string columnID = String.Empty;
            foreach (GridColumn column in AllColumns)
            {
                if (column.SortField == SortField)
                {
                    columnID = column.ColumnID;
                    break;
                }
            }
            return columnID;
        }

        private OptionBuilder GetPagingBuilder()
        {
            OptionBuilder pagingBuilder = new OptionBuilder();
            pagingBuilder.AddProperty("f_pageSize", PageSize);
            pagingBuilder.AddProperty("f_pageIndex", PageIndex);
            pagingBuilder.AddProperty("f_recordCount", RecordCount);
            pagingBuilder.AddProperty("f_pageCount", PageCount);

            int startRowIndex, endRowIndex;
            ResolveStartEndRowIndex(out startRowIndex, out endRowIndex);
            if (IsDatabasePaging)
            {
                pagingBuilder.AddProperty("f_databasePaging", true);
            }
            else
            {
                pagingBuilder.AddProperty("f_startRowIndex", startRowIndex);
                pagingBuilder.AddProperty("f_endRowIndex", endRowIndex);
            }

            return pagingBuilder;
        }

        #endregion

        #region GetGridColumnScript

        //private string GetAutoExpandColumnID()
        //{
        //    string result = String.Empty;

        //    int columnIndex = 0;
        //    foreach (GridColumn column in AllColumns)
        //    {
        //        if (column.ExpandUnusedSpace)
        //        {
        //            result = column.ColumnID;
        //            break;
        //        }

        //        columnIndex++;
        //    }

        //    return result;
        //}


        private string GetGridColumnScript(JsArrayBuilder pluginBuilder)
        {
            string selectModelID = Render_SelectModelID;

            // columns
            JsArrayBuilder columnsBuilder = new JsArrayBuilder();

            //// 如果启用行序号，则放在第一列
            //if (EnableRowNumber)
            //{
            //    JsObjectBuilder rowNumberBuilder = new JsObjectBuilder();
            //    if (RowNumberWidth != Unit.Empty)
            //    {
            //        rowNumberBuilder.AddProperty("width", RowNumberWidth.Value);
            //    }
            //    if (AllowPaging)
            //    {
            //        rowNumberBuilder.AddProperty("f_paging", Render_PagingID, true);
            //    }
            //    if (EnableRowNumberPaging)
            //    {
            //        rowNumberBuilder.AddProperty("f_paging_enabled", EnableRowNumberPaging);
            //    }

            //    columnsBuilder.AddProperty(String.Format("Ext.create('Ext.grid.column.RowNumberer',{0})", rowNumberBuilder.ToString()), true);

            //}

            //// 如果启用CheckBox，则放在第二列
            //// 如果启用单元格编辑，则EnableCheckBoxSelect属性失效
            //if (EnableCheckBoxSelect && !AllowCellEditing)
            //{
            //    columnsBuilder.AddProperty(selectModelID, true);
            //}


            //string groupColumnScript = GetGroupColumnScript();

            string expanderXID = String.Empty;
            foreach (GridColumn column in Columns)
            {
                if (column is TemplateField && (column as TemplateField).RenderAsRowExpander)
                {
                    expanderXID = column.XID;
                }
                else
                {
                    columnsBuilder.AddProperty(column.XID, true);
                }
            }

            // 为Grid添加plugin属性
            //JsArrayBuilder pluginBuilder = new JsArrayBuilder();

            if (!String.IsNullOrEmpty(expanderXID))
            {
                pluginBuilder.AddProperty(expanderXID, true);
            }

            //if (!String.IsNullOrEmpty(groupColumnScript))
            //{
            //    pluginBuilder.AddProperty(Render_GridGroupColumnID, true);
            //}



            //JsObjectBuilder defaultsBuilder = new JsObjectBuilder();
            //// 这是Extjs默认的客户端排序
            ////defaultsBuilder.AddProperty("sortable", false);
            ////defaultsBuilder.AddProperty("menuDisabled", true);
            //defaultsBuilder.AddProperty("width", 100);

            //string columnModelScript = String.Format("var {0}=new Ext.grid.ColumnModel({{columns:{1},defaults:{2}}});", gridColumnID, columnsBuilder, defaultsBuilder);
            string columnsScript = String.Format("var {0}={1};", Render_GridColumnsID, columnsBuilder);

            return columnsScript;
        }

        #endregion

        #region GetGroupColumnScript/ResolveGroupColumns

        //private string GetGroupColumnScript()
        //{
        //    if (Columns.Count > 0)
        //    {
        //        return String.Empty;
        //    }

        //    List<List<GridGroupColumn>> resolvedGroups = new List<List<GridGroupColumn>>();
        //    ResolveGroupColumns(GroupColumns, 0, resolvedGroups);

        //    JsArrayBuilder groupHeaderBuilder = new JsArrayBuilder();

        //    foreach (List<GridGroupColumn> groups in resolvedGroups)
        //    {
        //        JsArrayBuilder groupsBuilder = new JsArrayBuilder();
        //        foreach (GridGroupColumn group in groups)
        //        {
        //            JsObjectBuilder groupBuilder = new JsObjectBuilder();
        //            groupBuilder.AddProperty("header", group.HeaderText);
        //            if (group.TextAlign != TextAlign.Left)
        //            {
        //                groupBuilder.AddProperty("align", TextAlignName.GetName(group.TextAlign));
        //            }

        //            int groupColumnCount = 0;
        //            ResolveColumnCount(group, ref groupColumnCount);
        //            groupBuilder.AddProperty("colspan", groupColumnCount);

        //            groupsBuilder.AddProperty(groupBuilder);
        //        }

        //        groupHeaderBuilder.AddProperty(groupsBuilder);
        //    }

        //    return String.Format("var {0}=new Ext.ux.grid.ColumnHeaderGroup({{rows:{1}}});", Render_GridGroupColumnID, groupHeaderBuilder.ToString());

        //}

        //// 递归获得每个分组头中包含的列数
        //private void ResolveColumnCount(GridGroupColumn group, ref int columnCount)
        //{
        //    if (group.Columns.Count > 0)
        //    {
        //        columnCount += group.Columns.Count;
        //    }
        //    else if (group.GroupColumns.Count > 0)
        //    {
        //        foreach (GridGroupColumn subGroup in group.GroupColumns)
        //        {
        //            ResolveColumnCount(subGroup, ref columnCount);
        //        }
        //    }
        //}

        //// 将表头的树状分组转换为数组形式
        //private void ResolveGroupColumns(GridGroupColumnCollection groups, int level, List<List<GridGroupColumn>> resolvedGroups)
        //{
        //    foreach (GridGroupColumn group in groups)
        //    {
        //        if (resolvedGroups.Count <= level)
        //        {
        //            resolvedGroups.Add(new List<GridGroupColumn>());
        //        }
        //        resolvedGroups[level].Add(group);

        //        if (group.GroupColumns.Count > 0)
        //        {
        //            ResolveGroupColumns(group.GroupColumns, ++level, resolvedGroups);
        //            level--;
        //        }
        //    }
        //}

        #endregion

        #region GetGridSelectModel

        private string GetGridSelectModel()
        {
            //JsObjectBuilder selectOB = new JsObjectBuilder();
            OptionBuilder selectOB = new OptionBuilder();

            if (AllowCellEditing)
            {
                return String.Format("var {0}=Ext.create('Ext.selection.CellModel',{1});", Render_SelectModelID, selectOB);
            }
            else
            {
                //selectOB.AddProperty("singleSelect", !EnableMultiSelect);

                if (EnableMultiSelect)
                {
                    if (KeepCurrentSelection)
                    {
                        selectOB.AddProperty("mode", "SIMPLE");
                    }
                    else
                    {
                        selectOB.AddProperty("mode", "MULTI");
                    }
                }
                else
                {
                    selectOB.AddProperty("mode", "SINGLE");
                }


                if (EnableCheckBoxSelect && CheckBoxSelectOnly)
                {
                    selectOB.AddProperty("checkOnly", true);
                }

                //selectOB.AddProperty("listeners", "{beforerowselect:function(){return false;}}", true);

                if (EnableRowSelectEvent)
                {
                    string validateScript = "var args='RowSelect$'+record.getId();";
                    validateScript += GetPostBackEventReference("#RowSelect#").Replace("'#RowSelect#'", "args");

                    string rowSelectScript = JsHelper.GetFunction(validateScript, "model", "record", "index"); //String.Format("function(model,rowIndex){{{0}}}", validateScript);

                    selectOB.Listeners.AddProperty("select", rowSelectScript, true);
                }
                if (EnableRowDeselectEvent)
                {
                    string validateScript = "var args='RowDeselect$'+record.getId();";
                    validateScript += GetPostBackEventReference("#RowDeselect#").Replace("'#RowDeselect#'", "args");

                    string rowSelectScript = JsHelper.GetFunction(validateScript, "model", "record", "index"); //String.Format("function(model,rowIndex){{{0}}}", validateScript);

                    selectOB.Listeners.AddProperty("deselect", rowSelectScript, true);
                }

                if (EnableCheckBoxSelect)
                {
                    return String.Format("var {0}=Ext.create('Ext.selection.CheckboxModel',{1});", Render_SelectModelID, selectOB);
                }
                else
                {
                    return String.Format("var {0}=Ext.create('Ext.selection.RowModel',{1});", Render_SelectModelID, selectOB);
                }
            }
        }
        #endregion

        #region GetGridStore

        private string GetGridStore()
        {
            OptionBuilder storeBuilder = new OptionBuilder();

            // store - fields
            JsArrayBuilder fieldsBuidler = new JsArrayBuilder();
            foreach (GridColumn column in AllColumns)
            {
                JsObjectBuilder fieldBuilder = new JsObjectBuilder();
                fieldBuilder.AddProperty("name", column.ColumnID);

                if (AllowCellEditing)
                {
                    RenderBaseField field = column as RenderBaseField;
                    if (field != null)
                    {
                        if (field is RenderField)
                        {
                            RenderField renderFiled = field as RenderField;
                            if (renderFiled.FieldType != FieldType.Auto)
                            {
                                fieldBuilder.AddProperty("type", FieldTypeName.GetName(renderFiled.FieldType));
                                // 日期类型的，必须要设置这个 dateFormat 属性
                                if (renderFiled.FieldType == FieldType.Date)
                                {
                                    fieldBuilder.AddProperty("dateFormat", DateUtil.ConvertToClientDateFormat(renderFiled.RendererArgument));
                                }
                            }
                        }
                        else if (field is RenderCheckField)
                        {
                            fieldBuilder.AddProperty("type", "boolean");
                        }
                    }
                }
                fieldsBuidler.AddProperty(fieldBuilder);
            }

            // 增加 idProperty
            //JsObjectBuilder idFieldBuilder = new JsObjectBuilder();
            //idFieldBuilder.AddProperty("name", "__id");
            fieldsBuidler.AddProperty("__id");

            string fieldsScript = String.Format("var {0}={1};", Render_GridFieldsID, fieldsBuidler);


            // 自定义Model
            JsObjectBuilder modelOB = new JsObjectBuilder();
            modelOB.AddProperty("extend", "Ext.data.Model");
            modelOB.AddProperty("idProperty", "__id");
            modelOB.AddProperty("fields", Render_GridFieldsID, true);
            storeBuilder.AddProperty("model", String.Format("Ext.define(null,{0})", modelOB), true);

            //storeBuilder.AddProperty("fields", Render_GridFieldsID, true);

            storeBuilder.AddProperty("remoteSort", true);

            // 设置初始排序列
            if (AllowSorting)
            {
                string sortColumnID = GetSortColummID();
                if (!String.IsNullOrEmpty(sortColumnID))
                {
                    JsObjectBuilder sorterBuilder = new JsObjectBuilder();
                    sorterBuilder.AddProperty("property", GetSortColummID());
                    sorterBuilder.AddProperty("direction", SortDirection.ToString());
                    storeBuilder.AddProperty("sorters", sorterBuilder);
                }
            }


            string postbackScript = GetPostBackEventReference("#SORT#").Replace("'#SORT#'", "'Sort$'+sorter.property+'$'+sorter.direction");
            postbackScript = "var sorter=operation.sorters[0];if(sorter){" + postbackScript + "}return false;";

            storeBuilder.Listeners.AddProperty("beforeload", JsHelper.GetFunction(postbackScript, "store", "operation"), true);

            return fieldsScript + String.Format("var {0}=Ext.create('Ext.data.ArrayStore',{1});", Render_GridStoreID, storeBuilder.ToString());

            #region old code

            //storeBuilder.AddProperty("remoteSort", true);
            //storeBuilder.AddProperty("proxy", String.Format("new Ext.ux.AspNetProxy('{0}')", ClientID), true);

            //storeBuilder.AddProperty("autoLoad", "{params:{start:0,limit:" + PageSize + "}}", true);
            //storeBuilder.AddProperty("data", GetDatas());

            //if (AllowSorting)
            //{
            //    // Default sort info
            //    if (SortColumnIndex >= 0 && SortColumnIndex < Columns.Count)
            //    {
            //        JsObjectBuilder sortInfoBuilder = new JsObjectBuilder();
            //        sortInfoBuilder.AddProperty("field", Columns[SortColumnIndex].ColumnID);
            //        sortInfoBuilder.AddProperty("direction", SortDirection);

            //        storeBuilder.AddProperty("sortInfo", sortInfoBuilder);
            //    }
            //}


            //return String.Format("var {0}=new Ext.data.ArrayStore({1});", Render_GridStoreID, storeBuilder.ToString());


            //#region store - data
            ////string dataArrayString = GetDataArrayString(startEndRowIndex[0], startEndRowIndex[1]);



            //int[] startEndRowIndex = GetStartEndRowIndex();
            //// 计算完要渲染到前台的数据的条数，就要检查当前选中的项是不是有越界的
            //ResolveSelectedRowIndexArray(startEndRowIndex[1] - startEndRowIndex[0]);

            //#endregion 
            #endregion

            #region old code

            //JsArrayBuilder rowIndexBuilder = new JsArrayBuilder();

            //if (SelectedRowIndexArray != null && SelectedRowIndexArray.Length > 0)
            //{
            //    foreach (int rowIndex in SelectedRowIndexArray)
            //    {
            //        rowIndexBuilder.AddProperty(rowIndex);
            //    }
            //}
            //string selectRowScript = String.Format("{0}.selectRows({1});", Render_SelectModelID, rowIndexBuilder);
            //// 选中哪些行，这个必须要defer(100)，否则选不中，晕（10ms就不行）
            //selectRowScript = String.Format("(function(){{{0}}}).defer(100);", selectRowScript);

            //storeBuilder.AddProperty("listeners", String.Format("{{load:{0}}}", String.Format("function(){{{0}}}", selectRowScript)), true);

            #endregion

            #region old code

            // TODO
            //string selectedRowIndexArrayString = StringUtil.GetStringFromIntArray(SelectedRowIndexArray);
            //// FineUIAjax回发并且Columns发生变化，需要重新
            //if (_FineUIAjaxColumnsChanged)
            //{
            //    string reconfigScript = String.Empty;
            //    reconfigScript += gridStoreScript;
            //    reconfigScript += String.Format("{0}.reconfigure({1},{2});", XID, Render_GridStoreID, Render_GridColumnModelID);
            //    reconfigScript += String.Format("{0}.load();", Render_GridStoreID);
            //    // 重新加载数据后要更新input选中哪些项（因为可能选中项也会变化）
            //    reconfigScript += GetSetHiddenFieldValueScript(SelectedRowIndexArrayHiddenFieldID, selectedRowIndexArrayString);

            //    AddAjaxPropertyChangedScript(reconfigScript);
            //}
            //else
            //{
            //    bool reloadData = false;
            //    string updateSelectRowScript = selectRowScript + GetSetHiddenFieldValueScript(SelectedRowIndexArrayHiddenFieldID, selectedRowIndexArrayString);
            //    if (AjaxPropertyChanged("DataArrayString", dataArrayString))
            //    {
            //        string reloadDataScript = String.Format("{0}.loadData({1});", Render_GridStoreID, dataArrayString);
            //        // 虽然有可能“不需要修改隐藏字段的值，因为SelectedRowIndexArray其实并没有变化，只是重新加载数据（reloadData）导致选中项丢失了”
            //        // 但是我们还是修改了input的值，这没有什么影响
            //        reloadDataScript += updateSelectRowScript;

            //        AddAjaxPropertyChangedScript(reloadDataScript);

            //        reloadData = true;
            //    }

            //    // 不管SelectedRowIndexArray==null或者是不为空，都要做这一步
            //    // 在Ajax回发中，selectedRowIndexArrayString改变了，并且没有重新加载数据
            //    if (AjaxPropertyChanged("SelectedRowIndexArrayString", selectedRowIndexArrayString) && !reloadData)
            //    {
            //        AddAjaxPropertyChangedScript(updateSelectRowScript);
            //    }

            //} 
            #endregion

            #region old code

            //gridStoreScript += "\r\n";
            //if (EnableClientPaging)
            //{

            //    // 进行分页时，改变隐藏input的值，以在回发时保持状态
            //    // 同时注意：客户端分页时，清空选中的值
            //    JsObjectBuilder listenersBuilder = new JsObjectBuilder();
            //    listenersBuilder.AddProperty(OptionName.Load, String.Format("function(store,records,options){{Ext.get('{0}').dom.value=options.params.start;Ext.get('{1}').dom.value='';}}", EnableClientPagingStartRowIndexID, SelectedRowsHiddenFieldID), true);
            //    storeBuilder.AddProperty("listeners", listenersBuilder);
            //}

            // 每次都是加载全部
            //loadStoreScript = String.Format("{0}.load({1});", gridStoreId, "{params:{start:0,limit:" + (endRowIndex - startRowIndex + 1) + "}}");


            //// load store
            ////string loadStoreScript = String.Empty;
            //if (EnableClientPaging)
            //{
            //    loadStoreScript = String.Format("{0}.load({1});", gridStoreId, "{params:{start:" + EnableClientPagingStartRowIndex + ",limit:" + PageSize + "}}");
            //}
            //else
            //{
            //    loadStoreScript = String.Format("{0}.load({1});", gridStoreId, "{params:{start:0,limit:" + Rows.Count + "}}");
            //}

            //gridStoreScript += loadStoreScript; 
            #endregion
        }

        #region old code

        //private string GetDataArrayString(int startRowIndex, int endRowIndex)
        //{
        //    // store - data
        //    JsArrayBuilder dataBuidler = new JsArrayBuilder();

        //    for (int i = startRowIndex; i <= endRowIndex; i++)
        //    {
        //        // 当前行
        //        GridRow row = Rows[i];

        //        JsArrayBuilder cellBuilder = new JsArrayBuilder();
        //        foreach (object obj in row.Values)
        //        {
        //            cellBuilder.AddProperty(obj.ToString());
        //        }
        //        dataBuidler.AddProperty(cellBuilder);
        //    }

        //    // 二维数组
        //    return dataBuidler.ToString();
        //} 

        #endregion

        /// <summary>
        /// 当前分页的开始行和结束行
        /// </summary>
        /// <returns></returns>
        internal void ResolveStartEndRowIndex(out int startRowIndex, out int endRowIndex)
        {
            startRowIndex = GetStartRowIndex();
            endRowIndex = Rows.Count - 1;

            // 内存分页
            if (AllowPaging && !IsDatabasePaging)
            {
                endRowIndex = (PageIndex + 1) * PageSize - 1;
                endRowIndex = (endRowIndex < RecordCount - 1) ? endRowIndex : RecordCount - 1;
            }
            /*
            startRowIndex = 0;
            endRowIndex = Rows.Count - 1;

            if (AllowPaging)
            {
                if (IsDatabasePaging)
                {
                    // 数据库分页
                    startRowIndex = 0;
                    endRowIndex = Rows.Count - 1;
                }
                else
                {
                    // 简单的服务器端分页
                    startRowIndex = PageSize * PageIndex;
                    endRowIndex = (PageIndex + 1) * PageSize - 1;
                    endRowIndex = endRowIndex < RecordCount - 1 ? endRowIndex : RecordCount - 1;
                }
            }
             * */
        }

        /// <summary>
        /// 获取当前分页的起始行序号（不分页或者数据库分页时，返回零）
        /// </summary>
        /// <returns></returns>
        public int GetStartRowIndex()
        {
            int startRowIndex = 0;

            // 如果是内存分页
            if (AllowPaging && !IsDatabasePaging)
            {
                startRowIndex = PageSize * PageIndex;
            }

            return startRowIndex;
        }

        /// <summary>
        /// 通过行ID获取行对象
        /// </summary>
        /// <param name="rowID">行ID</param>
        /// <returns>行对象</returns>
        public GridRow FindRow(string rowID)
        {
            GridRow result = null;

            foreach (GridRow row in Rows)
            {
                if (rowID == row.RowID)
                {
                    result = row;
                    break;
                }
            }

            return result;
        }


        /// <summary>
        /// 通过行序号获取行对象
        /// </summary>
        /// <param name="rowIndex">行序号</param>
        /// <returns>行对象</returns>
        public GridRow FindRow(int rowIndex)
        {
            GridRow row = null;

            int startRowIndex = GetStartRowIndex();

            int currentRowIndex = rowIndex + startRowIndex;

            if (currentRowIndex >= 0 && currentRowIndex < Rows.Count)
            {
                row = Rows[currentRowIndex];
            }

            return row;
        }



        #endregion

        #endregion

        #region RenderBeginTag/RenderEndTag

        /// <summary>
        /// 渲染开始标签
        /// </summary>
        /// <param name="writer">输出流</param>
        protected override void RenderBeginTag(HtmlTextWriter writer)
        {
            base.RenderBeginTag(writer);

            writer.Write(String.Format("<div id=\"{0}_tpls\" class=\"f-grid-tpls f-hidden x-grid-tpls\">", ClientID));
        }

        /// <summary>
        /// 渲染结束标签
        /// </summary>
        /// <param name="writer">输出流</param>
        protected override void RenderEndTag(HtmlTextWriter writer)
        {
            writer.Write("</div>");

            base.RenderEndTag(writer);
        }

        #endregion

        #region UpdateTemplateFields

        private bool _needUpdateTemplateFields = false;


        /// <summary>
        /// 当在客户端修改了模板列中的值，调用此函数来告诉表格控件需要更新这些值；
        /// 如果对表格重新进行了数据绑定，则不需要调用此函数，因为重新绑定后会更新表格的全部内容
        /// </summary>
        public void UpdateTemplateFields()
        {
            _needUpdateTemplateFields = true;
            //PageManager.Instance.AddAjaxGridClientID(ClientID);
        }

        #endregion

        #region DataBind

        // 当前表格是否调用了 DataBind() 函数
        private bool _dataBinded = false;

        internal Dictionary<string, GridColumn> cellEditingDataKeyNameField = new Dictionary<string, GridColumn>();

        /// <summary>
        /// 绑定到数据源
        /// </summary>
        public override void DataBind()
        {
            //base.DataBind();

            // 调用了本函数
            _dataBinded = true;

            // 重新绑定数据后，GetMergedData要重新计算了，并且清空已更改数据记录
            _mergedData = null;

            // 如果重新绑定数据，则每行的模版列内容有可能发生变化，就需要更新
            // 因为目前，没有判断模板列是否改变的机制，所以只要可能导致模板列的动作都要更新模板列
            //PageManager.Instance.AddAjaxGridClientID(ClientID);
            _needUpdateTemplateFields = true;


            // 如果重新绑定数据，则取消之前的编辑状态提示
            if (IsFineUIAjaxPostBack && AllowCellEditing)
            {
                _databindInFineUIAjaxPostBack = true;
            }


            // 如果允许单元格编辑，记录 DataKeyNames 对应的列序号，可能需要用列定义的FieldType
            if (AllowCellEditing)
            {
                cellEditingDataKeyNameField.Clear();

                if (DataKeyNames != null)
                {
                    List<string> dataKeyNames = new List<string>(DataKeyNames);
                    foreach (GridColumn field in AllColumns)
                    {
                        if (field is RenderBaseField)
                        {
                            string dataField = (field as RenderBaseField).DataField;
                            if (dataKeyNames.Contains(dataField))
                            {
                                if (!cellEditingDataKeyNameField.ContainsKey(dataField))
                                {
                                    cellEditingDataKeyNameField.Add(dataField, field);
                                }
                            }
                        }
                    }
                }
            }

            // 数据绑定之前要先清空 _dataKeys
            _dataKeys = null;

            // 重新绑定数据前清空选中的值
            SelectedRowIndexArray = null;
            SelectedCell = null;

            // 数据绑定之前要先清空现有的数据
            ClearRows();

            int recordCount = 0;

            if (_dataSource != null)
            {
                if (_dataSource is IDataReader)
                {
                    DataTable dataTable = new DataTable();
                    dataTable.Load(_dataSource as IDataReader);

                    recordCount = DataBindToDataTable(dataTable);
                }
                else if (_dataSource is DataView || _dataSource is DataSet || _dataSource is DataTable)
                {
                    DataTable dataTable = null;

                    if (_dataSource is DataView)
                    {
                        dataTable = ((DataView)_dataSource).ToTable();
                    }
                    else if (_dataSource is DataSet)
                    {
                        dataTable = ((DataSet)_dataSource).Tables[0];
                    }
                    else
                    {
                        dataTable = ((DataTable)_dataSource);
                    }

                    recordCount = DataBindToDataTable(dataTable);
                }
                else if (_dataSource is IEnumerable)
                {
                    recordCount = DataBindToEnumerable((IEnumerable)_dataSource);
                }
                else
                {
                    throw new Exception("DataSource doesn't support data type: " + _dataSource.GetType().ToString());
                }
            }

            AfterDataBind(recordCount);
        }


        private int DataBindToDataTable(DataTable dataTable)
        {
            BeforeDataBind();

            int rowIndex = 0, count = dataTable.DefaultView.Count;
            for (; rowIndex < count; rowIndex++)
            {
                DataBindRow(rowIndex, dataTable.DefaultView[rowIndex]);
            }

            return rowIndex;
        }

        private int DataBindToEnumerable(IEnumerable list)
        {
            BeforeDataBind();

            int rowIndex = 0;

            foreach (object rowObj in list)
            {
                DataBindRow(rowIndex, rowObj);

                rowIndex++;
            }

            return rowIndex;
        }

        private void DataBindRow(int rowIndex, object rowObj)
        {
            GridPreRowEventArgs preArgs = new GridPreRowEventArgs(rowObj, rowIndex);
            OnPreRowDataBound(preArgs);

            // 事件处理函数要求取消添加本节点
            if (!preArgs.Cancelled)
            {

                GridRow row = new GridRow(this, rowObj, rowIndex);
                Rows.Add(row);
                //Controls.Add(row);
                row.InitTemplateContainers();

                //row.DataBindRow();
                row.DataBindRow();

                OnRowDataBound(new GridRowEventArgs(row));
            }
        }

        private void BeforeDataBind()
        {
            OnPreDataBound(EventArgs.Empty);
        }

        #region AfterDataBind

        private void AfterDataBind(int recordCount)
        {
            if (!IsDatabasePaging)
            {
                // 如果不是数据库分页，则每次DataBind都要更新RecordCount的值
                // 数据库分页的话，RecordCount需要用户显式的赋值
                RecordCount = recordCount;
            }


            // 在所有行都绑定结束后，需要检查模拟树显示的列，并重新计算当前列的内容（在列内容前加上树分隔符）
            // 1.查找需要模拟树显示的列
            BaseField simulateTreeColumn = null;
            foreach (GridColumn gridColumn in AllColumns)
            {
                BaseField column = gridColumn as BaseField;
                if (column != null && !String.IsNullOrEmpty(column.DataSimulateTreeLevelField))
                {
                    simulateTreeColumn = column;
                    break;
                }
            }

            // 2.如果找到这样的列
            if (simulateTreeColumn != null)
            {
                List<SimulateTreeNode> silumateTree = new List<SimulateTreeNode>();

                // 存在需要模拟树显示的列
                for (int rowIndex = 0, rowCount = Rows.Count; rowIndex < rowCount; rowIndex++)
                {
                    GridRow row = Rows[rowIndex];
                    int level = 0;
                    object treeLevelObj = row.GetPropertyValue(simulateTreeColumn.DataSimulateTreeLevelField);
                    if (treeLevelObj != null && treeLevelObj != DBNull.Value)
                    {
                        level = Convert.ToInt32(treeLevelObj);
                    }

                    object content = row.Values[simulateTreeColumn.ColumnIndex];

                    SimulateTreeNode node = new SimulateTreeNode();
                    node.Text = content.ToString();
                    node.Level = level;
                    node.HasLittleBrother = false;
                    node.ParentNode = null;
                    silumateTree.Add(node);
                }

                // 计算树
                SimulateTreeHeper treeHelper = new SimulateTreeHeper();
                treeHelper.ResolveSimulateTree(silumateTree, true);

                // 赋值
                for (int rowIndex = 0, rowCount = Rows.Count; rowIndex < rowCount; rowIndex++)
                {
                    Rows[rowIndex].Values[simulateTreeColumn.ColumnIndex] = silumateTree[rowIndex].Text;
                }
            }

        }
        #endregion


        #region ClearRows

        /// <summary>
        /// 清空Rows，同时清除所有子控件中的GridRow控件
        /// </summary>
        private void ClearRows()
        {
            // 清空现有的行
            Rows.Clear();

            // Grid.Controls 下面包含全部列控件（列控件里面又包含Editor）和全部模板列控件
            // 注意：Editor控件是属于列控件的，而模板列中的控件是输入每一行的模板列控件的！

            // 会重新创建这些控件，所以要先删除之前存在的GridRowControl
            for (int i = Controls.Count - 1; i >= 0; i--)
            {
                if (Controls[i] is GridTemplateContainer)
                {
                    Controls.RemoveAt(i);
                }
            }
        }

        #endregion

        #endregion

        #region GetModifiedCells

        private JArray _mergedData;

        /// <summary>
        /// 获取合并后的表格数据（包含修改和未修改的数据，不包含已经删除的行数据）
        /// </summary>
        /// <returns>合并后的表格数据</returns>
        public JArray GetMergedData()
        {
            // 不允许单元格编辑，则返回null
            if (!AllowCellEditing)
            {
                return null;
            }


            // 已经计算过了
            if (_mergedData != null)
            {
                return _mergedData;
            }


            _mergedData = new JArray();

            // 当前处理的原始索引
            int currentOriginalIndex = GetStartRowIndex();

            // 没有调用 DataBind 函数，并且前台改变的数据不为空
            if (!_dataBinded && _modifiedData != null)
            {
                foreach (JObject modifiedItem in _modifiedData)
                {
                    // 修改的数据在新集合中的行索引
                    int rowIndex = modifiedItem.Value<int>("index"); // modifiedItem[0].ToObject<int>();
                    // 修改的数据在原始集合中的行索引，如果是新增行则小于0
                    int originalRowIndex = modifiedItem.Value<int>("originalIndex"); //modifiedItem[1].ToObject<int>();
                    string status = modifiedItem.Value<string>("status");


                    if (status == "newadded")
                    {
                        // 新增的行
                        _mergedData.Add(modifiedItem.DeepClone());
                    }
                    else
                    {
                        // 中间一些原始数据没有变化，这里要添加进来
                        if (originalRowIndex > currentOriginalIndex)
                        {
                            AddUnchangedData(_mergedData, currentOriginalIndex, originalRowIndex);
                        }


                        // 删除的行，原始数据行被删除了
                        if (status == "deleted")
                        {
                            // nothing
                        }
                        else
                        {
                            // 修改的行
                            var currentModifiedItem = modifiedItem.DeepClone();
                            JObject currentModifiedValues = currentModifiedItem.Value<JObject>("values");
                            var originalValues = Rows[originalRowIndex].Values;

                            foreach (GridColumn column in AllColumns)
                            {
                                if (column is RenderBaseField)
                                {
                                    RenderBaseField field = column as RenderBaseField;
                                    if (currentModifiedValues.Property(field.ColumnID) == null)
                                    {
                                        currentModifiedValues.Add(field.ColumnID, JToken.FromObject(originalValues[field.ColumnIndex]));
                                    }
                                }
                            }
                            _mergedData.Add(currentModifiedItem);
                        }


                        // 原始索引向下移动一位
                        currentOriginalIndex = originalRowIndex + 1;
                    }
                }
            }

            if (currentOriginalIndex < Rows.Count)
            {
                AddUnchangedData(_mergedData, currentOriginalIndex, Rows.Count);
            }

            return _mergedData;
        }

        private void AddUnchangedData(JArray mergedData, int currentOriginalIndex, int originalRowIndex)
        {
            for (int i = currentOriginalIndex; i < originalRowIndex; i++)
            {
                // 未改变的行
                var iModifiedItem = new JObject();
                JObject iModifiedValues = new JObject();
                var iRow = Rows[i];
                var iOriginalValues = iRow.Values;

                foreach (GridColumn column in AllColumns)
                {
                    if (column is RenderBaseField)
                    {
                        RenderBaseField field = column as RenderBaseField;
                        iModifiedValues.Add(field.ColumnID, JToken.FromObject(iOriginalValues[field.ColumnIndex]));
                    }
                }
                iModifiedItem.Add("values", iModifiedValues);
                iModifiedItem.Add("status", "unchanged");
                iModifiedItem.Add("originalIndex", i);
                iModifiedItem.Add("index", mergedData.Count);
                iModifiedItem.Add("id", iRow.RowID);
                mergedData.Add(iModifiedItem);
            }
        }


        private JArray _modifiedData = new JArray();

        /// <summary>
        /// 获取用户修改的数据
        /// </summary>
        /// <returns></returns>
        public JArray GetModifiedData()
        {
            return _modifiedData;
        }


        //private List<ModifiedCell> _modifiedCells = new List<ModifiedCell>();

        ///// <summary>
        ///// 获取用户修改的单元格，包含新增的数据
        ///// </summary>
        ///// <returns></returns>
        //internal List<ModifiedCell> GetModifiedCells()
        //{
        //    return _modifiedCells;
        //}


        private List<int> _deletedList;

        /// <summary>
        /// 获取删除的行索引列表
        /// </summary>
        /// <returns></returns>
        public List<int> GetDeletedList()
        {
            return _deletedList;
        }


        private List<Dictionary<string, object>> _newAddedList;

        /// <summary>
        /// 获取新增的行数据
        /// </summary>
        /// <returns></returns>
        public List<Dictionary<string, object>> GetNewAddedList()
        {
            return _newAddedList;
        }


        private Dictionary<int, Dictionary<string, object>> _modifiedDict;

        /// <summary>
        /// 获取用户修改的行数据
        /// </summary>
        /// <returns></returns>
        public Dictionary<int, Dictionary<string, object>> GetModifiedDict()
        {
            return _modifiedDict;
        }

        #endregion

        #region IPostBackDataHandler Members

        /// <summary>
        /// 处理回发数据
        /// </summary>
        /// <param name="postDataKey">回发数据键</param>
        /// <param name="postCollection">回发数据集</param>
        /// <returns>回发数据是否改变</returns>
        public override bool LoadPostData(string postDataKey, System.Collections.Specialized.NameValueCollection postCollection)
        {
            base.LoadPostData(postDataKey, postCollection);


            string paramHiddenColumns = postCollection[HiddenColumnsHiddenFieldID];
            List<string> hiddenColumnsList = new List<string>();
            if (!String.IsNullOrEmpty(paramHiddenColumns))
            {
                hiddenColumnsList = StringUtil.GetStringListFromString(paramHiddenColumns, true);
            }
            string[] hiddenColumns = hiddenColumnsList.ToArray();
            if (!StringUtil.CompareStringArray(HiddenColumns, hiddenColumns))
            {
                HiddenColumns = hiddenColumns;
                FState.BackupPostDataProperty("HiddenColumns");
            }


            // 列状态（目前只有CheckBoxField用到）
            String statesStr = postCollection[StatesHiddenFieldID];
            if (!String.IsNullOrEmpty(statesStr))
            {
                JArray states = JArray.Parse(statesStr);
                if (states.Count > 0)
                {
                    int startRowIndex, endRowIndex;
                    ResolveStartEndRowIndex(out startRowIndex, out endRowIndex);
                    for (int i = startRowIndex; i <= endRowIndex; i++)
                    {
                        int index = i - startRowIndex;

                        Rows[i].FromShortStates(states[index].ToObject<List<object>>().ToArray());
                    }
                    FState.BackupPostDataProperty("F_Rows");
                }
            }


            // 启用单元格编辑
            if (AllowCellEditing)
            {
                //// 删除的行索引列表
                //string paramDeletedRows = postCollection[DeletedRowsHiddenFieldID];
                //_deletedList = new List<int>();
                //if (!String.IsNullOrEmpty(paramDeletedRows))
                //{
                //    _deletedList = StringUtil.GetIntListFromString(paramDeletedRows, true);
                //}

                //// 新增的行索引列表
                //string paramNewAddedRows = postCollection[NewAddedRowsHiddenFieldID];
                //List<int> newAddedRows = new List<int>();
                //if (!String.IsNullOrEmpty(paramNewAddedRows))
                //{
                //    newAddedRows = StringUtil.GetIntListFromString(paramNewAddedRows, true);
                //}

                List<string> dataKeyNames = null;
                if (DataKeyNames != null)
                {
                    dataKeyNames = new List<string>(DataKeyNames);
                }

                // 修改的单元格
                _deletedList = new List<int>();
                _modifiedDict = new Dictionary<int, Dictionary<string, object>>();
                _newAddedList = new List<Dictionary<string, object>>();
                _modifiedData = new JArray();
                String editorDataStr = postCollection[ModifiedDataHiddenFieldID];
                if (!String.IsNullOrEmpty(editorDataStr))
                {
                    _modifiedData = JArray.Parse(editorDataStr);

                    foreach (JObject modifiedItem in _modifiedData)
                    {
                        // 修改的数据在新集合中的行索引
                        int rowIndex = modifiedItem.Value<int>("index"); // modifiedItem[0].ToObject<int>();
                        // 修改的数据在原始集合中的行索引，如果是新增行则小于0
                        int originalRowIndex = modifiedItem.Value<int>("originalIndex"); //modifiedItem[1].ToObject<int>();
                        string status = modifiedItem.Value<string>("status");

                        if (status == "deleted")
                        {
                            // 删除的行
                            _deletedList.Add(originalRowIndex);
                            continue;
                        }


                        // 获取本行（Record）中所有修改的记录（Field），并保存到字典中（rowModifiedDic）
                        Dictionary<string, object> rowModifiedDic = new Dictionary<string, object>();

                        JObject rowModifiedData = modifiedItem.Value<JObject>("values"); //modifiedItem[2].ToObject<JObject>();
                        foreach (JProperty propertyObj in rowModifiedData.Properties())
                        {
                            string columnID = propertyObj.Name;
                            object cellValue = rowModifiedData.Value<JValue>(columnID).Value;
                            // 启用单元格编辑，所以这里的列一定是RenderBaseField
                            GridColumn column = FindColumn(columnID);
                            int columnIndex = column.ColumnIndex;

                            if (column is RenderField)
                            {
                                RenderField renderColumn = column as RenderField;

                                // 数字类型的列，如果值为 空字符串，则更新为 null
                                if (renderColumn.FieldType == FieldType.Int ||
                                    renderColumn.FieldType == FieldType.Float ||
                                    renderColumn.FieldType == FieldType.Double)
                                {
                                    if (cellValue.Equals(String.Empty))
                                    {
                                        cellValue = DBNull.Value;
                                    }
                                }
                            }

                            rowModifiedDic.Add(columnID, cellValue);

                            // 更新Values和DataKeys - 虽然本次回发可能不保存单元格的值，但是通过到服务器端也没什么错
                            // 注意：删除行和新增行都无法同步到Values和DataKeys，必须重新DataBind才行
                            // 如果本行已经存在，还需要更新行的Values属性
                            if (status == "modified")
                            {
                                // 更新行的Values
                                Rows[originalRowIndex].Values[columnIndex] = cellValue;

                                // 更新行的DataKeys
                                if (dataKeyNames != null)
                                {
                                    RenderBaseField renderField = column as RenderBaseField;
                                    if (renderField != null)
                                    {
                                        int dataKeyIndex = dataKeyNames.IndexOf(renderField.DataField);
                                        if (dataKeyIndex >= 0)
                                        {
                                            Rows[originalRowIndex].DataKeys[dataKeyIndex] = cellValue;
                                        }
                                    }
                                }
                            }


                        }

                        if (status == "modified")
                        {
                            // 已经存在的行
                            _modifiedDict.Add(originalRowIndex, rowModifiedDic);
                        }
                        else
                        {
                            // 新增行
                            _newAddedList.Add(rowModifiedDic);
                        }
                    }


                    //// 删除行或者新增行，都无法将客户端F_Rows的更改同步到服务器端控件，需要在服务器端重新加载数据
                    FState.BackupPostDataProperty("F_Rows");
                    /*
                    foreach (JArray modifiedItem in _modifiedData)
                    {
                        // 修改的数据在新集合中的行索引
                        int rowIndex = modifiedItem[0].ToObject<int>();
                        // 修改的数据在原始集合中的行索引，如果是新增行则为-1
                        int originalRowIndex = modifiedItem[1].ToObject<int>();


                        // 获取本行（Record）中所有修改的记录（Field），并保存到字典中（rowModifiedDic）
                        Dictionary<string, object> rowModifiedDic = new Dictionary<string, object>();
                        JObject rowModifiedData = modifiedItem[2].ToObject<JObject>();
                        foreach (JProperty propertyObj in rowModifiedData.Properties())
                        {
                            string columnID = propertyObj.Name;
                            object cellValue = rowModifiedData.Value<JValue>(columnID).Value;
                            GridColumn column = FindColumn(columnID);
                            int columnIndex = column.ColumnIndex;

                            //string newCellValue = cellValue.ToString();

                            rowModifiedDic.Add(columnID, cellValue);

                            // 如果本行不是新增的，还需要更新行的Values属性
                            if (originalRowIndex >= 0)
                            {
                                // 更新行的Values
                                Rows[originalRowIndex].Values[columnIndex] = cellValue;

                                // 更新行的DataKeys
                                if (dataKeyNames != null)
                                {
                                    RenderBaseField renderField = column as RenderBaseField;
                                    if (renderField != null)
                                    {
                                        int dataKeyIndex = dataKeyNames.IndexOf(renderField.DataField);
                                        if (dataKeyIndex >= 0)
                                        {
                                            Rows[originalRowIndex].DataKeys[dataKeyIndex] = cellValue;
                                        }
                                    }
                                }
                            }
                        }

                        if (originalRowIndex >= 0)
                        {
                            // 已经存在的行
                            _modifiedDict.Add(originalRowIndex, rowModifiedDic);
                        }
                        else
                        {
                            // 新增行
                            _newAddedList.Add(rowModifiedDic);
                        }

                    }

                    FState.BackupPostDataProperty("F_Rows");
                    */
                }


                //// 选中的单元格（数组中元素的顺序是固定的，不能排序）
                //int[] selectedCell = StringUtil.GetIntListFromString(postCollection[SelectedCellHiddenFieldID], false).ToArray();
                //if (!StringUtil.CompareIntArray(SelectedCell, selectedCell))
                //{
                //    SelectedCell = selectedCell;
                //    FState.BackupPostDataProperty("SelectedCell");
                //}

                // 客户端传入的是 [rowid, columnid]
                string[] selectedCell = null;
                string selectedCellPostValue = postCollection[SelectedCellHiddenFieldID];
                if (!String.IsNullOrEmpty(selectedCellPostValue))
                {
                    selectedCell = JSONUtil.StringArrayFromJArray(JArray.Parse(selectedCellPostValue));
                }
                // 比较时要保持顺序
                if (!StringUtil.CompareStringArray(SelectedCell, selectedCell, true))
                {
                    SelectedCell = selectedCell;
                    FState.BackupPostDataProperty("SelectedCell");
                }

            }
            else
            {

                // 选中的行
                //int[] selectedRowIndexArray = StringUtil.GetIntListFromString(postCollection[SelectedRowIndexArrayHiddenFieldID], true).ToArray();
                //if (!StringUtil.CompareIntArray(SelectedRowIndexArray, selectedRowIndexArray))
                //{
                //    SelectedRowIndexArray = selectedRowIndexArray;
                //    FState.BackupPostDataProperty("SelectedRowIndexArray");
                //}

                string[] selectedRows = null;
                string selectedRowsPostValue = postCollection[SelectedRowsHiddenFieldID];
                if (!String.IsNullOrEmpty(selectedRowsPostValue))
                {
                    selectedRows = JSONUtil.StringArrayFromJArray(JArray.Parse(selectedRowsPostValue));
                }
                if (!StringUtil.CompareStringArray(SelectedRowIDArray, selectedRows))
                {
                    SelectedRowIDArray = selectedRows;
                    FState.BackupPostDataProperty("SelectedRowIDArray");
                }

            }



            return false;
        }



        //public override void RaisePostDataChangedEvent()
        //{
        //    //OnCollapsedChanged(EventArgs.Empty);
        //}

        #endregion

        #region CommitChanges/RejectChanges/ClearSelections/AddNewRecord

        /// <summary>
        /// 接受用户编辑单元格（同时消除编辑单元格左上方的红色提示图标）
        /// </summary>
        public void CommitChanges()
        {
            PageContext.RegisterStartupScript(GetCommitChangesReference());
        }

        /// <summary>
        /// 获取接受用户编辑单元格的客户端脚本（同时消除编辑单元格左上方的红色提示图标）
        /// </summary>
        /// <returns>客户端脚本</returns>
        public string GetCommitChangesReference()
        {
            return String.Format("{0}.f_commitChanges();", ScriptID);
        }


        /// <summary>
        /// 拒绝用户编辑单元格（同时消除编辑单元格左上方的红色提示图标）
        /// </summary>
        public void RejectChanges()
        {
            PageContext.RegisterStartupScript(GetRejectChangesReference());
        }

        /// <summary>
        /// 获取拒绝用户编辑单元格的客户端脚本（同时消除编辑单元格左上方的红色提示图标）
        /// </summary>
        public string GetRejectChangesReference()
        {
            return String.Format("{0}.getStore().rejectChanges();", ScriptID);
        }


        /// <summary>
        /// 清空表格选中项
        /// </summary>
        public void ClearSelections()
        {
            PageContext.RegisterStartupScript(GetClearSelectionsReference());
        }

        /// <summary>
        /// 获取清空表格选中项的客户端脚本
        /// </summary>
        /// <returns>客户端脚本</returns>
        public string GetClearSelectionsReference()
        {
            return String.Format("{0}.getSelectionModel().clearSelections();", ScriptID);
        }

        /// <summary>
        /// 添加一条新纪录
        /// </summary>
        /// <param name="defaultObject">缺省值</param>
        public void AddNewRecord(JObject defaultObject)
        {
            PageContext.RegisterStartupScript(GetAddNewRecordReference(defaultObject));
        }

        /// <summary>
        /// 添加一条新纪录
        /// </summary>
        /// <param name="defaultObject">缺省值</param>
        /// <param name="appendToEnd">是否添加到末尾</param>
        public void AddNewRecord(JObject defaultObject, bool appendToEnd)
        {
            PageContext.RegisterStartupScript(GetAddNewRecordReference(defaultObject, appendToEnd));
        }


        /// <summary>
        /// 添加一条新纪录
        /// </summary>
        /// <param name="defaultObject">缺省值</param>
        /// <param name="appendToEnd">是否添加到末尾</param>
        /// <param name="editColumnID">添加后使某列处于编辑状态</param>
        public void AddNewRecord(JObject defaultObject, bool appendToEnd, string editColumnID)
        {
            PageContext.RegisterStartupScript(GetAddNewRecordReference(defaultObject, appendToEnd, editColumnID));
        }


        /// <summary>
        /// 获取添加一条新纪录的客户端脚本
        /// </summary>
        /// <param name="defaultObject">缺省值</param>
        /// <returns>客户端脚本</returns>
        public string GetAddNewRecordReference(JObject defaultObject)
        {
            return GetAddNewRecordReference(defaultObject, false);
        }


        /// <summary>
        /// 获取添加一条新纪录的客户端脚本
        /// </summary>
        /// <param name="defaultObject">缺省值</param>
        /// <param name="appendToEnd">是否添加到末尾</param>
        /// <returns>客户端脚本</returns>
        public string GetAddNewRecordReference(JObject defaultObject, bool appendToEnd)
        {
            return GetAddNewRecordReference(defaultObject, appendToEnd, null);
        }


        /// <summary>
        /// 获取添加一条新纪录的客户端脚本
        /// </summary>
        /// <param name="defaultObject">缺省值</param>
        /// <param name="appendToEnd">是否添加到末尾</param>
        /// <param name="editColumnID">添加后使某列处于编辑状态</param>
        /// <returns>客户端脚本</returns>
        public string GetAddNewRecordReference(JObject defaultObject, bool appendToEnd, string editColumnID)
        {
            string objstr = defaultObject.ToString(Formatting.None);
            string appendstr = appendToEnd.ToString().ToLower();

            if (String.IsNullOrEmpty(editColumnID))
            {
                return String.Format("{0}.f_addNewRecord({1},{2});", ScriptID, objstr, appendstr);
            }
            else
            {
                return String.Format("{0}.f_addNewRecord({1},{2},{3});", ScriptID, objstr, appendstr, JsHelper.Enquote(editColumnID));
            }
        }

        ///// <summary>
        ///// 获取添加一条新纪录的客户端脚本
        ///// </summary>
        ///// <param name="defaultObject">缺省值</param>
        ///// <param name="appendToEnd">是否添加到末尾</param>
        ///// <returns>客户端脚本</returns>
        //public string GetAddNewRecordReference(JObject defaultObject, bool appendToEnd)
        //{
        //    return String.Format("{0}.f_addNewRecord({1},{2});", ScriptID, defaultObject.ToString(Formatting.None), appendToEnd.ToString().ToLower());
        //}


        ///// <summary>
        ///// 删除选中行（或者单元格）
        ///// </summary>
        //public void DeleteSelected()
        //{
        //    PageContext.RegisterStartupScript(GetDeleteSelectedReference());
        //}

        ///// <summary>
        ///// 获取删除选中行（或者单元格）的客户端脚本
        ///// </summary>
        ///// <returns>客户端脚本</returns>
        //public string GetDeleteSelectedReference()
        //{
        //    return String.Format("{0}.f_deleteSelected();", ScriptID);
        //}


        /// <summary>
        /// 删除选中行（或者单元格）
        /// </summary>
        [Obsolete("请使用DeleteSelectedRows")]
        public void DeleteSelected()
        {
            PageContext.RegisterStartupScript(GetDeleteSelectedRowsReference());
        }


        /// <summary>
        /// 获取删除选中行（或者单元格）的客户端脚本
        /// </summary>
        /// <returns>客户端脚本</returns>
        [Obsolete("请使用GetDeleteSelectedRowsReference")]
        public string GetDeleteSelectedReference()
        {
            return GetDeleteSelectedRowsReference();
        }


        /// <summary>
        /// 删除选中行（或者单元格）
        /// </summary>
        public void DeleteSelectedRows()
        {
            PageContext.RegisterStartupScript(GetDeleteSelectedRowsReference());
        }

        /// <summary>
        /// 获取删除选中行（或者单元格）的客户端脚本
        /// </summary>
        /// <returns>客户端脚本</returns>
        public string GetDeleteSelectedRowsReference()
        {
            return String.Format("{0}.f_deleteSelectedRows();", ScriptID);
        }


        #endregion

        #region GetHasSelectionReference GetSelectCountReference



        /// <summary>
        /// 获取表格是否有选中项的客户端脚本
        /// </summary>
        /// <returns>客户端脚本</returns>
        public string GetHasSelectionReference()
        {
            return String.Format("{0}.getSelectionModel().hasSelection()", ScriptID);
        }

        ///// <summary>
        ///// 获取表格选中项数的客户端脚本
        ///// </summary>
        ///// <returns>客户端脚本</returns>
        //[Obsolete("此方法已废除，请使用GetSelectedCountReference方法")]
        //public string GetSelectCountReference()
        //{
        //    return GetSelectedCountReference();
        //}

        /// <summary>
        /// 获取表格选中项数的客户端脚本
        /// </summary>
        /// <returns>客户端脚本</returns>
        public string GetSelectedCountReference()
        {
            return String.Format("{0}.f_getSelectedCount()", ScriptID);
        }

        /// <summary>
        /// 获取表格选中单元格的客户端脚本（仅用于AllowCellEditing模式）
        /// </summary>
        /// <returns>客户端脚本</returns>
        public string GetSelectedCellReference()
        {
            return String.Format("{0}.f_getSelectedCell()", ScriptID);
        }



        #endregion

        #region GetNoSelectionAlertReference GetNoSelectionAlertInParentReference

        /// <summary>
        /// 获取表格没有任何选中项时在本窗口弹出提示对话框的客户端脚本
        /// </summary>
        /// <returns>客户端脚本</returns>
        public string GetNoSelectionAlertReference(string message)
        {
            return GetNoSelectionAlertReference(message, String.Empty, Alert.DefaultMessageBoxIcon);
        }

        /// <summary>
        /// 获取表格没有任何选中项时在本窗口弹出提示对话框的客户端脚本
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <param name="title">对话框标题</param>
        /// <returns>客户端脚本</returns>
        public string GetNoSelectionAlertReference(string message, string title)
        {
            return GetNoSelectionAlertReference(message, title, Alert.DefaultMessageBoxIcon);
        }

        /// <summary>
        /// 获取表格没有任何选中项时在本窗口弹出提示对话框的客户端脚本
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <param name="title">对话框标题</param>
        /// <param name="icon">对话框图标</param>
        /// <returns>客户端脚本</returns>
        public string GetNoSelectionAlertReference(string message, string title, MessageBoxIcon icon)
        {
            return String.Format("if(!{0}){{{1}return false;}}", GetHasSelectionReference(), Alert.GetShowReference(message, title, icon));
        }


        /// <summary>
        /// 获取表格没有任何选中项时在父级窗口弹出提示对话框的客户端脚本
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <returns>客户端脚本</returns>
        public string GetNoSelectionAlertInParentReference(string message)
        {
            return GetNoSelectionAlertInParentReference(message, String.Empty, Alert.DefaultMessageBoxIcon);
        }

        /// <summary>
        /// 获取表格没有任何选中项时在父级窗口弹出提示对话框的客户端脚本
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <param name="title">对话框标题</param>
        /// <returns>客户端脚本</returns>
        public string GetNoSelectionAlertInParentReference(string message, string title)
        {
            return GetNoSelectionAlertInParentReference(message, title, Alert.DefaultMessageBoxIcon);
        }

        /// <summary>
        /// 获取表格没有任何选中项时在父级窗口弹出提示对话框的客户端脚本
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <param name="title">对话框标题</param>
        /// <param name="icon">对话框图标</param>
        /// <returns>客户端脚本</returns>
        public string GetNoSelectionAlertInParentReference(string message, string title, MessageBoxIcon icon)
        {
            return String.Format("if(!{0}){{{1}return false;}}", GetHasSelectionReference(), Alert.GetShowInParentReference(message, title, icon));
        }

        /// <summary>
        /// 获取表格没有任何选中项时在顶级窗口弹出提示对话框的客户端脚本
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <returns>客户端脚本</returns>
        public string GetNoSelectionAlertInTopReference(string message)
        {
            return GetNoSelectionAlertInTopReference(message, String.Empty, Alert.DefaultMessageBoxIcon);
        }

        /// <summary>
        /// 获取表格没有任何选中项时在顶级窗口弹出提示对话框的客户端脚本
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <param name="title">对话框标题</param>
        /// <returns>客户端脚本</returns>
        public string GetNoSelectionAlertInTopReference(string message, string title)
        {
            return GetNoSelectionAlertInTopReference(message, title, Alert.DefaultMessageBoxIcon);
        }

        /// <summary>
        /// 获取表格没有任何选中项时在顶级窗口弹出提示对话框的客户端脚本
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <param name="title">对话框标题</param>
        /// <param name="icon">对话框图标</param>
        /// <returns>客户端脚本</returns>
        public string GetNoSelectionAlertInTopReference(string message, string title, MessageBoxIcon icon)
        {
            return String.Format("if(!{0}){{{1}return false;}}", GetHasSelectionReference(), Alert.GetShowInTopReference(message, title, icon));
        }
        #endregion

        #region FindColumn/SelectAllRows

        /// <summary>
        /// 通过列ID获取列实例
        /// </summary>
        /// <param name="columnID">列ID</param>
        /// <returns>列实例</returns>
        public GridColumn FindColumn(string columnID)
        {
            foreach (GridColumn column in AllColumns)
            {
                if (column.ColumnID == columnID)
                {
                    return column;
                }
            }

            return null;
        }

        /// <summary>
        /// 通过列索引获取列实例
        /// </summary>
        /// <param name="columnIndex">列索引</param>
        /// <returns>列实例</returns>
        public GridColumn FindColumn(int columnIndex)
        {
            return AllColumns[columnIndex];
        }


        /// <summary>
        /// 选中所有行（设置SelectedRowIndexArray属性）
        /// </summary>
        public void SelectAllRows()
        {
            /*
            List<int> rowIndexs = new List<int>();
            for (int i = 0; i < Rows.Count; i++)
            {
                rowIndexs.Add(i);
            }
            SelectedRowIndexArray = rowIndexs.ToArray();
            */

            PageContext.RegisterStartupScript(String.Format("{0}.f_selectAllRows();", ScriptID));
        }

        /// <summary>
        /// 展开全部的行扩展列
        /// </summary>
        public void ExpandRowExpanders()
        {
            _registerScriptRowExpanders = true;

            ExpandAllRowExpanders = true;
            //PageContext.RegisterStartupScript(String.Format("{0}.f_expandAllRows();", ScriptID));
        }

        /// <summary>
        /// 折叠全部的行扩展列
        /// </summary>
        public void CollapseRowExpanders()
        {
            _registerScriptRowExpanders = true;

            ExpandAllRowExpanders = false;
            //PageContext.RegisterStartupScript(String.Format("{0}.f_collapseAllRows();", ScriptID));
        }

        #endregion

        #region IPostBackEventHandler

        /// <summary>
        /// 处理回发事件
        /// </summary>
        /// <param name="eventArgument">事件参数</param>
        public override void RaisePostBackEvent(string eventArgument)
        {
            base.RaisePostBackEvent(eventArgument);

            //if (eventArgument.StartsWith("Sort$"))
            //{
            //    string[] sortArgs = eventArgument.Split('$');
            //    if (sortArgs.Length == 3)
            //    {
            //        // 格式为 "Sort$Grid1_ctl03$ASC"
            //        string sortDir = sortArgs[2];
            //        string columnId = sortArgs[1];

            //        int columnIndex = 0;
            //        foreach (GridColumn column in AllColumns)
            //        {
            //            if (column.ColumnID == columnId)
            //            {
            //                break;
            //            }
            //            columnIndex++;
            //        }

            //        // 当前列的排序字段和排序方向
            //        string sortField = AllColumns[columnIndex].SortField;
            //        string sortDirection = sortDir.ToUpper() == "ASC" ? "ASC" : "DESC";

            //        SortDirection = sortDirection;
            //        SortField = sortField;

            //        OnSort(new GridSortEventArgs(sortField, sortDirection, columnIndex));
            //    }

            //}
            if (eventArgument.StartsWith("Sort$"))
            {
                string[] sortArgs = eventArgument.Split('$');

                if (sortArgs.Length == 3)
                {
                    // 格式为 "Sort$Grid1_ctl03$ASC"
                    string sortDirection = sortArgs[2];
                    string columnID = sortArgs[1];

                    GridColumn column = FindColumn(columnID);
                    if (column != null)
                    {
                        // 当前列的排序字段和排序方向
                        string sortField = column.SortField;

                        SortDirection = sortDirection;
                        SortField = sortField;

                        OnSort(new GridSortEventArgs(sortField, sortDirection, column.ColumnIndex, columnID));
                    }
                }

            }
            //else if (eventArgument.StartsWith("Command$"))
            //{
            //    string[] commandArgs = eventArgument.Split('$');
            //    if (commandArgs.Length == 5)
            //    {
            //        OnRowCommand(new GridCommandEventArgs(Convert.ToInt32(commandArgs[1]), Convert.ToInt32(commandArgs[2]), commandArgs[3], commandArgs[4]));
            //    }
            //}
            else if (eventArgument.StartsWith("Command$"))
            {
                string[] commandArgs = eventArgument.Split('$');
                if (commandArgs.Length == 5)
                {
                    string rowID = commandArgs[1];
                    GridRow row = FindRow(rowID);

                    int rowIndex = -1; // -1 表示新增行
                    if (row != null)
                    {
                        rowIndex = row.RowIndex; // -GetStartRowIndex();
                    }

                    string columnID = commandArgs[2];
                    GridColumn column = FindColumn(columnID);

                    OnRowCommand(new GridCommandEventArgs(rowIndex, rowID, column.ColumnIndex, columnID, commandArgs[3], commandArgs[4]));

                }
            }
            else if (eventArgument.StartsWith("Page$"))
            {
                string[] commandArgs = eventArgument.Split('$');
                if (commandArgs.Length == 2)
                {
                    OnPageIndexChange(new GridPageEventArgs(Convert.ToInt32(commandArgs[1])));

                    if (ClearSelectedRowsAfterPaging)
                    {
                        // 分页后清空选中的值
                        // 因为服务器端分页时不会重新绑定数据（数据库分页才会重新绑定数据，所以数据库分页时自然会清空选中的行）
                        // 所以需要一个设置，在分页结束后自动清空选中的行
                        SelectedRowIndexArray = null;
                    }
                    SelectedCell = null;
                }
            }
            //else if (eventArgument.StartsWith("RowClick$"))
            //{
            //    string[] commandArgs = eventArgument.Split('$');
            //    if (commandArgs.Length == 2)
            //    {
            //        int rowIndex = Convert.ToInt32(commandArgs[1]);

            //        // 内存分页
            //        if (AllowPaging && !IsDatabasePaging)
            //        {
            //            rowIndex += PageSize * PageIndex;
            //        }

            //        OnRowClick(new GridRowClickEventArgs(rowIndex));
            //    }
            //}
            //else if (eventArgument.StartsWith("RowDoubleClick$"))
            //{
            //    string[] commandArgs = eventArgument.Split('$');
            //    if (commandArgs.Length == 2)
            //    {
            //        int rowIndex = Convert.ToInt32(commandArgs[1]);

            //        // 内存分页
            //        if (AllowPaging && !IsDatabasePaging)
            //        {
            //            rowIndex += PageSize * PageIndex;
            //        }

            //        OnRowDoubleClick(new GridRowClickEventArgs(rowIndex));
            //    }
            //}
            else if (eventArgument.StartsWith("RowClick$"))
            {
                string[] commandArgs = eventArgument.Split('$');
                if (commandArgs.Length == 2)
                {
                    string rowID = commandArgs[1];
                    GridRow row = FindRow(rowID);
                    int rowIndex = -1; // -1 表示新增行
                    if (row != null)
                    {
                        rowIndex = row.RowIndex; // -GetStartRowIndex();
                    }

                    OnRowClick(new GridRowClickEventArgs(rowIndex, rowID));

                }
            }
            else if (eventArgument.StartsWith("RowDoubleClick$"))
            {
                string[] commandArgs = eventArgument.Split('$');
                if (commandArgs.Length == 2)
                {
                    string rowID = commandArgs[1];
                    GridRow row = FindRow(rowID);
                    int rowIndex = -1; // -1 表示新增行
                    if (row != null)
                    {
                        rowIndex = row.RowIndex; // -GetStartRowIndex();
                    }

                    OnRowDoubleClick(new GridRowClickEventArgs(rowIndex, rowID));

                }
            }
            else if (eventArgument.StartsWith("RowSelect$"))
            {
                string[] commandArgs = eventArgument.Split('$');
                if (commandArgs.Length == 2)
                {
                    string rowID = commandArgs[1];
                    GridRow row = FindRow(rowID);
                    int rowIndex = -1; // -1 表示新增行
                    if (row != null)
                    {
                        rowIndex = row.RowIndex; // -GetStartRowIndex();
                    }

                    OnRowSelect(new GridRowSelectEventArgs(rowIndex, rowID));
                }
            }
            else if (eventArgument.StartsWith("RowDeselect$"))
            {
                string[] commandArgs = eventArgument.Split('$');
                if (commandArgs.Length == 2)
                {
                    string rowID = commandArgs[1];
                    GridRow row = FindRow(rowID);
                    int rowIndex = -1; // -1 表示新增行
                    if (row != null)
                    {
                        rowIndex = row.RowIndex; // -GetStartRowIndex();
                    }

                    OnRowDeselect(new GridRowSelectEventArgs(rowIndex, rowID));
                }
            }
            else if (eventArgument.StartsWith("AfterEdit$"))
            {
                //string[] commandArgs = eventArgument.Split('$');
                //if (commandArgs.Length == 3)
                //{
                //    int rowIndex = Convert.ToInt32(commandArgs[1]);

                //    // 内存分页
                //    if (AllowPaging && !IsDatabasePaging)
                //    {
                //        rowIndex += PageSize * PageIndex;
                //    }

                //    OnAfterEdit(new GridAfterEditEventArgs(rowIndex, commandArgs[2].ToString()));
                //}
                string[] commandArgs = eventArgument.Split('$');
                if (commandArgs.Length == 3)
                {
                    string rowID = commandArgs[1];
                    GridRow row = FindRow(rowID);
                    int rowIndex = -1; // -1 表示新增行
                    if (row != null)
                    {
                        rowIndex = row.RowIndex; // -GetStartRowIndex();
                    }

                    string columnID = commandArgs[2];
                    GridColumn column = FindColumn(columnID);

                    OnAfterEdit(new GridAfterEditEventArgs(rowIndex, rowID, column.ColumnIndex, columnID));
                }
            }
        }

        /// <summary>
        /// 获取Columns前面的列（比如索引列，选择框列）
        /// </summary>
        /// <returns></returns>
        private int GetPrefixColumnNumber()
        {
            int prefix = 0;
            //if (EnableRowNumber)
            //{
            //    prefix++;
            //}

            //if (EnableCheckBoxSelect && !AllowCellEditing)
            //{
            //    prefix++;
            //}
            return prefix;
        }

        #endregion

        #region OnSort

        private static readonly object _sortHandlerKey = new object();

        /// <summary>
        /// 排序事件
        /// </summary>
        [Category(CategoryName.ACTION)]
        [Description("排序事件")]
        public event EventHandler<GridSortEventArgs> Sort
        {
            add
            {
                Events.AddHandler(_sortHandlerKey, value);
            }
            remove
            {
                Events.RemoveHandler(_sortHandlerKey, value);
            }
        }

        /// <summary>
        /// 触发排序事件
        /// </summary>
        /// <param name="e">事件参数</param>
        protected virtual void OnSort(GridSortEventArgs e)
        {
            EventHandler<GridSortEventArgs> handler = Events[_sortHandlerKey] as EventHandler<GridSortEventArgs>;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion

        #region OnPreDataBound

        private static readonly object _preDataBoundHandlerKey = new object();

        /// <summary>
        /// 绑定前事件
        /// </summary>
        [Category(CategoryName.ACTION)]
        [Description("绑定前事件")]
        public event EventHandler<EventArgs> PreDataBound
        {
            add
            {
                Events.AddHandler(_preDataBoundHandlerKey, value);
            }
            remove
            {
                Events.RemoveHandler(_preDataBoundHandlerKey, value);
            }
        }

        /// <summary>
        /// 触发绑定前事件
        /// </summary>
        /// <param name="e">事件参数</param>
        protected virtual void OnPreDataBound(EventArgs e)
        {
            EventHandler<EventArgs> handler = Events[_preDataBoundHandlerKey] as EventHandler<EventArgs>;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion

        #region OnPreRowDataBound

        private static readonly object _preRowDataBoundHandlerKey = new object();

        /// <summary>
        /// 行绑定前事件
        /// </summary>
        [Category(CategoryName.ACTION)]
        [Description("行绑定前事件")]
        public event EventHandler<GridPreRowEventArgs> PreRowDataBound
        {
            add
            {
                Events.AddHandler(_preRowDataBoundHandlerKey, value);
            }
            remove
            {
                Events.RemoveHandler(_preRowDataBoundHandlerKey, value);
            }
        }

        /// <summary>
        /// 触发行绑定前事件
        /// </summary>
        /// <param name="e">事件参数</param>
        protected virtual void OnPreRowDataBound(GridPreRowEventArgs e)
        {
            EventHandler<GridPreRowEventArgs> handler = Events[_preRowDataBoundHandlerKey] as EventHandler<GridPreRowEventArgs>;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion

        #region OnRowDataBound

        private static readonly object _rowDataBoundHandlerKey = new object();

        /// <summary>
        /// 行绑定后事件
        /// </summary>
        [Category(CategoryName.ACTION)]
        [Description("行绑定后事件")]
        public event EventHandler<GridRowEventArgs> RowDataBound
        {
            add
            {
                Events.AddHandler(_rowDataBoundHandlerKey, value);
            }
            remove
            {
                Events.RemoveHandler(_rowDataBoundHandlerKey, value);
            }
        }

        /// <summary>
        /// 触发行绑定后事件
        /// </summary>
        /// <param name="e">事件参数</param>
        protected virtual void OnRowDataBound(GridRowEventArgs e)
        {
            EventHandler<GridRowEventArgs> handler = Events[_rowDataBoundHandlerKey] as EventHandler<GridRowEventArgs>;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion

        #region OnRowCommand

        private static readonly object _rowCommandHandlerKey = new object();

        /// <summary>
        /// 行内事件
        /// </summary>
        [Category(CategoryName.ACTION)]
        [Description("行内事件")]
        public event EventHandler<GridCommandEventArgs> RowCommand
        {
            add
            {
                Events.AddHandler(_rowCommandHandlerKey, value);
            }
            remove
            {
                Events.RemoveHandler(_rowCommandHandlerKey, value);
            }
        }

        /// <summary>
        /// 触发行内事件
        /// </summary>
        /// <param name="e">事件参数</param>
        protected virtual void OnRowCommand(GridCommandEventArgs e)
        {
            EventHandler<GridCommandEventArgs> handler = Events[_rowCommandHandlerKey] as EventHandler<GridCommandEventArgs>;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion

        #region OnPageIndexChange

        private static readonly object _pageIndexChangeHandlerKey = new object();

        /// <summary>
        /// 页索引改变事件
        /// </summary>
        [Category(CategoryName.ACTION)]
        [Description("页索引改变事件")]
        public event EventHandler<GridPageEventArgs> PageIndexChange
        {
            add
            {
                Events.AddHandler(_pageIndexChangeHandlerKey, value);
            }
            remove
            {
                Events.RemoveHandler(_pageIndexChangeHandlerKey, value);
            }
        }

        /// <summary>
        /// 触发页索引改变事件
        /// </summary>
        /// <param name="e">事件参数</param>
        protected virtual void OnPageIndexChange(GridPageEventArgs e)
        {
            EventHandler<GridPageEventArgs> handler = Events[_pageIndexChangeHandlerKey] as EventHandler<GridPageEventArgs>;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion

        #region OnRowClick

        private static readonly object _rowClickHandlerKey = new object();

        /// <summary>
        /// 行点击事件（需要启用EnableRowClick）
        /// </summary>
        [Category(CategoryName.ACTION)]
        [Description("行点击事件（需要启用EnableRowClick）")]
        public event EventHandler<GridRowClickEventArgs> RowClick
        {
            add
            {
                Events.AddHandler(_rowClickHandlerKey, value);
            }
            remove
            {
                Events.RemoveHandler(_rowClickHandlerKey, value);
            }
        }

        /// <summary>
        /// 触发行点击事件
        /// </summary>
        /// <param name="e">事件参数</param>
        protected virtual void OnRowClick(GridRowClickEventArgs e)
        {
            EventHandler<GridRowClickEventArgs> handler = Events[_rowClickHandlerKey] as EventHandler<GridRowClickEventArgs>;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion

        #region OnRowDoubleClick

        private static readonly object _rowDoubleClickHandlerKey = new object();

        /// <summary>
        /// 行双击事件（需要启用EnableRowDoubleClick）
        /// </summary>
        [Category(CategoryName.ACTION)]
        [Description("行双击事件（需要启用EnableRowDoubleClick）")]
        public event EventHandler<GridRowClickEventArgs> RowDoubleClick
        {
            add
            {
                Events.AddHandler(_rowDoubleClickHandlerKey, value);
            }
            remove
            {
                Events.RemoveHandler(_rowDoubleClickHandlerKey, value);
            }
        }

        /// <summary>
        /// 触发行双击事件
        /// </summary>
        /// <param name="e">事件参数</param>
        protected virtual void OnRowDoubleClick(GridRowClickEventArgs e)
        {
            EventHandler<GridRowClickEventArgs> handler = Events[_rowDoubleClickHandlerKey] as EventHandler<GridRowClickEventArgs>;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion

        #region OnRowSelect

        private static readonly object _rowSelectHandlerKey = new object();

        /// <summary>
        /// 行选中事件（需要启用EnableRowSelect）
        /// </summary>
        [Category(CategoryName.ACTION)]
        [Description("行选中事件（需要启用EnableRowSelect）")]
        public event EventHandler<GridRowSelectEventArgs> RowSelect
        {
            add
            {
                Events.AddHandler(_rowSelectHandlerKey, value);
            }
            remove
            {
                Events.RemoveHandler(_rowSelectHandlerKey, value);
            }
        }

        /// <summary>
        /// 触发行选中事件
        /// </summary>
        /// <param name="e">事件参数</param>
        protected virtual void OnRowSelect(GridRowSelectEventArgs e)
        {
            EventHandler<GridRowSelectEventArgs> handler = Events[_rowSelectHandlerKey] as EventHandler<GridRowSelectEventArgs>;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion

        #region OnRowDeselect

        private static readonly object _rowDeselectHandlerKey = new object();

        /// <summary>
        /// 行取消选中事件（需要启用EnableRowDeselect）
        /// </summary>
        [Category(CategoryName.ACTION)]
        [Description("行取消选中事件（需要启用EnableRowDeselect）")]
        public event EventHandler<GridRowSelectEventArgs> RowDeselect
        {
            add
            {
                Events.AddHandler(_rowDeselectHandlerKey, value);
            }
            remove
            {
                Events.RemoveHandler(_rowDeselectHandlerKey, value);
            }
        }

        /// <summary>
        /// 触发行取消选中事件
        /// </summary>
        /// <param name="e">事件参数</param>
        protected virtual void OnRowDeselect(GridRowSelectEventArgs e)
        {
            EventHandler<GridRowSelectEventArgs> handler = Events[_rowDeselectHandlerKey] as EventHandler<GridRowSelectEventArgs>;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion

        #region OnAfterEdit

        private static readonly object _afterEditHandlerKey = new object();

        /// <summary>
        /// 结束编辑事件（需要启用EnableAfterEditEvent）
        /// </summary>
        [Category(CategoryName.ACTION)]
        [Description("结束编辑事件（需要启用EnableAfterEditEvent）")]
        public event EventHandler<GridAfterEditEventArgs> AfterEdit
        {
            add
            {
                Events.AddHandler(_afterEditHandlerKey, value);
            }
            remove
            {
                Events.RemoveHandler(_afterEditHandlerKey, value);
            }
        }

        /// <summary>
        /// 触发结束编辑事件
        /// </summary>
        /// <param name="e">事件参数</param>
        protected virtual void OnAfterEdit(GridAfterEditEventArgs e)
        {
            EventHandler<GridAfterEditEventArgs> handler = Events[_afterEditHandlerKey] as EventHandler<GridAfterEditEventArgs>;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion

        #region LoadControlState/SaveControlState

        // LoadControlState 处于 Page_Init 之后，控件的 LoadPostData 之前
        // 1. Page_Init 之后，才能保证动态添加的 Columns 存在
        // 2. LoadPostData 之前，才能保证模板列中的输入控件得到用户输入的值
        /// <summary>
        /// 装载控件状态
        /// </summary>
        /// <param name="savedState"></param>
        protected override void LoadControlState(object savedState)
        {
            base.LoadControlState(((Pair)savedState).First);

            // 页面回发时，重新初始化每行中的模板列控件
            if (Page.IsPostBack)
            {
                foreach (GridRow row in Rows)
                {
                    row.InitTemplateContainers();
                }
            }
        }

        // 必须添加值之后，才会在回发时走到 LoadViewState
        // 使用ControlState而不是ViewState还有一个好处是，ControlState不可被用户关闭
        /// <summary>
        /// 保存控件状态
        /// </summary>
        /// <returns></returns>
        protected override object SaveControlState()
        {
            return new Pair(base.SaveControlState(), "");

        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            Page.RegisterRequiresControlState(this);
        }



        #endregion

        #region old code

        //protected override void OnPreLoad(object sender, EventArgs e)
        //{
        //    base.OnPreLoad(sender, e);

        //    SaveAjaxProperty("GridColumnScript", GetGridColumnScript());
        //    if (AllowSorting)
        //    {
        //        SaveAjaxProperty("SortIconScript", GetSortIconScript());
        //    }

        //    if (AllowPaging)
        //    {
        //        JsObjectBuilder pagingBuilder;
        //        SaveAjaxProperty("TempPagingString", GetTempPagingString(out pagingBuilder));
        //    }

        //    int startRowIndex;
        //    int endRowIndex;
        //    SaveAjaxProperty("DataArrayString", GetDataArrayString(out startRowIndex, out endRowIndex));

        //    SelectedRowIndexArray = ResolveSelectedRowIndexArray(SelectedRowIndexArray, endRowIndex - startRowIndex);
        //    SaveAjaxProperty("SelectedRowIndexArrayString", StringUtil.GetStringFromIntArray(SelectedRowIndexArray));

        //}

        #endregion

        #region old code

        //protected override object SaveViewState()
        //{
        //    object[] states = new object[] { base.SaveViewState(), 
        //        ((IStateManager)Columns).SaveViewState(), 
        //        ((IStateManager)Rows).SaveViewState(),
        //        //((IStateManager)Toolbar).SaveViewState()
        //    };

        //    return states;
        //}

        //protected override void LoadViewState(object savedState)
        //{
        //    if (savedState != null)
        //    {
        //        object[] states = (object[])savedState;

        //        base.LoadViewState(states[0]);

        //        ((IStateManager)Columns).LoadViewState(states[1]);

        //        ((IStateManager)Rows).LoadViewState(states[2]);

        //        //((IStateManager)Toolbar).LoadViewState(states[3]);
        //    }
        //}

        //protected override void TrackViewState()
        //{
        //    base.TrackViewState();

        //    ((IStateManager)Columns).TrackViewState();

        //    ((IStateManager)Rows).TrackViewState();

        //    //((IStateManager)Toolbar).TrackViewState();
        //}

        #endregion

        #region old code

        //public override void RenderBeginTag(HtmlTextWriter writer)
        //{
        //    base.RenderBeginTag(writer);

        //    //// 当前选中的哪些行的数据
        //    //writer.Write(String.Format("<input type=\"hidden\" value=\"{1}\" id=\"{0}\" name=\"{0}\"/>",
        //    //    SelectedRowsHiddenFieldID, GetSelectedRowIndexArrayHTML()));

        //    ////// 如果启用客户端排序，需要在回发时记录当前所在的第几页
        //    ////if (EnableClientPaging)
        //    ////{
        //    ////    writer.Write(String.Format("<input type=\"hidden\" value=\"{1}\" id=\"{0}\" name=\"{0}\"/>",
        //    ////        EnableClientPagingStartRowIndexID, EnableClientPagingStartRowIndex));
        //    ////}

        //    //// 有这些列需要保存状态
        //    //if (NeedPersistStateColumnIndexArray != null && NeedPersistStateColumnIndexArray.Length > 0)
        //    //{
        //    //    foreach (int columnIndex in NeedPersistStateColumnIndexArray)
        //    //    {
        //    //        writer.Write(String.Format("<input type=\"hidden\" value=\"{1}\" id=\"{0}\" name=\"{0}\"/>",
        //    //            GetNeedPersistStateColumnIndexID(columnIndex), Columns[columnIndex].SaveColumnState()));
        //    //    }
        //    //}
        //}



        //public override void RenderEndTag(HtmlTextWriter writer)
        //{
        //    base.RenderEndTag(writer);
        //}

        #endregion


    }
}
