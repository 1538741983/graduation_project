
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    GridRowEventArgs.cs
 * CreatedOn:   2008-06-23
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
    /// 表格行绑定事件参数
    /// </summary>
    public class GridRowEventArgs : EventArgs
    {

        private GridRow _row;

        /// <summary>
        /// 当前行
        /// </summary>
        public GridRow Row
        {
            get { return _row; }
        }

        /// <summary>
        /// 本行各列的值（渲染后的HTML片段）
        /// </summary>
        public object[] Values
        {
            get { return _row.Values; }
        }


        /// <summary>
        /// 行数据源
        /// </summary>
        public object DataItem
        {
            get { return _row.DataItem; }
        }


        /// <summary>
        /// 行索引
        /// </summary>
        public int RowIndex
        {
            get { return _row.RowIndex; }
        }

        /// <summary>
        /// 行ID
        /// </summary>
        public string RowID
        {
            get { return _row.RowID; }
        }


        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="row">行</param>
        public GridRowEventArgs(GridRow row)
        {
            _row = row;
        }

    }
}



