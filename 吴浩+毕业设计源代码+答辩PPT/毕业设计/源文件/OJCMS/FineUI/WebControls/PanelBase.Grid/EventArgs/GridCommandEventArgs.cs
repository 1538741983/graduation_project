
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    GridCommandEventArgs.cs
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
    /// 表格行命令事件参数
    /// </summary>
    public class GridCommandEventArgs : EventArgs
    {

        private int _rowIndex;

        /// <summary>
        /// 行索引
        /// </summary>
        public int RowIndex
        {
            get { return _rowIndex; }
        }

        private string _rowID;

        /// <summary>
        /// 行ID
        /// </summary>
        public string RowID
        {
            get { return _rowID; }
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



        private string _commandName;

        /// <summary>
        /// 命令名称
        /// </summary>
        public string CommandName
        {
            get { return _commandName; }
        }


        private string _commandArgument;

        /// <summary>
        /// 命令参数
        /// </summary>
        public string CommandArgument
        {
            get { return _commandArgument; }
        }


        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="rowIndex">行索引</param>
        /// <param name="rowID">行ID</param>
        /// <param name="columnIndex">列索引</param>
        /// <param name="columnID">列ID</param>
        /// <param name="commandName">命令名称</param>
        /// <param name="commandArgument">命令参数</param>
        public GridCommandEventArgs(int rowIndex, string rowID, int columnIndex, string columnID, string commandName, string commandArgument)
        {
            _rowIndex = rowIndex;
            _rowID = rowID;
            _columnIndex = columnIndex;
            _columnID = columnID;
            _commandName = commandName;
            _commandArgument = commandArgument;
        }

    }
}



