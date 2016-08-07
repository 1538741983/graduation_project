
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    GridSortEventArgs.cs
 * CreatedOn:   2008-05-28
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
using System.Text;

namespace FineUI
{
    /// <summary>
    /// 表格排序事件参数
    /// </summary>
    public class GridSortEventArgs : EventArgs
    {
        private string _sortField;

        /// <summary>
        /// 排序字段
        /// </summary>
        public string SortField
        {
            get { return _sortField; }
        }


        private string _sortDirection;

        /// <summary>
        /// 排序方向
        /// </summary>
        public string SortDirection
        {
            get { return _sortDirection; }
        }

        private int _columnIndex;

        /// <summary>
        /// 列索引
        /// </summary>
        public int ColumnIndex
        {
            get { return _columnIndex; }
        }


        private string _columnID;

        /// <summary>
        /// 列ID
        /// </summary>
        public string ColumnID
        {
            get { return _columnID; }
        }



        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="sortField">排序字段</param>
        /// <param name="sortDirection">排序方向</param>
        /// <param name="columnIndex">列索引</param>
        /// <param name="columnID">列</param>
        public GridSortEventArgs(string sortField, string sortDirection, int columnIndex, string columnID)
        {
            _sortField = sortField;
            _sortDirection = sortDirection;
            _columnIndex = columnIndex;
            _columnID = columnID;
        }

    }
}
