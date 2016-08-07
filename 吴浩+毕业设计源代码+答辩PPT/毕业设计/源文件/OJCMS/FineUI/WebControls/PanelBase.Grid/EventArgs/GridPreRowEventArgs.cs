
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    GridPreRowEventArgs.cs
 * CreatedOn:   2008-06-27
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
using System.Data;
using System.Reflection;
using System.ComponentModel;
using System.Web.UI;


namespace FineUI
{
    /// <summary>
    /// 表格行预绑定事件参数
    /// </summary>
    public class GridPreRowEventArgs : EventArgs
    {
        private bool _cancelled = false;

        /// <summary>
        /// 是否取消添加本节点
        /// </summary>
        public bool Cancelled
        {
            get { return _cancelled; }
            set { _cancelled = value; }
        }


        private object _dataItem;

        /// <summary>
        /// 行数据源（如果数据源为DataTable，则DataItem为DataRowView）
        /// </summary>
        public object DataItem
        {
            get { return _dataItem; }
        }


        private int _rowIndex;

        /// <summary>
        /// 行索引
        /// </summary>
        public int RowIndex
        {
            get { return _rowIndex; }
        }


        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataItem">行数据源</param>
        /// <param name="rowIndex">行索引</param>
        public GridPreRowEventArgs(object dataItem, int rowIndex)
        {
            _dataItem = dataItem;
            _rowIndex = rowIndex;
        }

    }
}



