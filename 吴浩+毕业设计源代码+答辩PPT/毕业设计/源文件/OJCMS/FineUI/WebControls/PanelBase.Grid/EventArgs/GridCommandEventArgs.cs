
#region Comment

/*
 * Project��    FineUI
 * 
 * FileName:    GridCommandEventArgs.cs
 * CreatedOn:   2008-06-23
 * CreatedBy:   30372245@qq.com
 * 
 * 
 * Description��
 *      ->
 *   
 * History��
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
    /// ����������¼�����
    /// </summary>
    public class GridCommandEventArgs : EventArgs
    {

        private int _rowIndex;

        /// <summary>
        /// ������
        /// </summary>
        public int RowIndex
        {
            get { return _rowIndex; }
        }

        private string _rowID;

        /// <summary>
        /// ��ID
        /// </summary>
        public string RowID
        {
            get { return _rowID; }
        }



        private int _columnIndex;

        /// <summary>
        /// ������
        /// </summary>
        public int ColumnIndex
        {
            get { return _columnIndex; }
        }



        private string _columnID;

        /// <summary>
        /// ��ID
        /// </summary>
        public string ColumnID
        {
            get { return _columnID; }
        }



        private string _commandName;

        /// <summary>
        /// ��������
        /// </summary>
        public string CommandName
        {
            get { return _commandName; }
        }


        private string _commandArgument;

        /// <summary>
        /// �������
        /// </summary>
        public string CommandArgument
        {
            get { return _commandArgument; }
        }


        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="rowIndex">������</param>
        /// <param name="rowID">��ID</param>
        /// <param name="columnIndex">������</param>
        /// <param name="columnID">��ID</param>
        /// <param name="commandName">��������</param>
        /// <param name="commandArgument">�������</param>
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



