
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    GridRowSelectEventArgs.cs
 * CreatedOn:   2013-02-27
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
    /// 表格行选中事件参数
    /// </summary>
    public class GridRowSelectEventArgs : EventArgs
    {

        private int _rowIndex;

        /// <summary>
        /// 行索引
        /// </summary>
        public int RowIndex
        {
            get { return _rowIndex; }
            //set { _rowIndex = value; }
        }

        private string _rowID;

        /// <summary>
        /// 行ID
        /// </summary>
        public string RowID
        {
            get { return _rowID; }
        }


        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="rowIndex">行索引</param>
        /// <param name="rowID">行ID</param>
        public GridRowSelectEventArgs(int rowIndex, string rowID)
        {
            _rowIndex = rowIndex;
            _rowID = rowID;
        }

    }
}



