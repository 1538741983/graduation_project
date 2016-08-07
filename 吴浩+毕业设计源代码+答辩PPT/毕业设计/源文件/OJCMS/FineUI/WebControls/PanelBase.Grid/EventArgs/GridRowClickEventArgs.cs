
#region Comment

/*
 * Project��    FineUI
 * 
 * FileName:    GridRowClickEventArgs.cs
 * CreatedOn:   2008-06-25
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
    /// ����е���¼�����
    /// </summary>
    public class GridRowClickEventArgs : EventArgs
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


        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="rowIndex">������</param>
        /// <param name="rowID">��ID</param>
        public GridRowClickEventArgs(int rowIndex, string rowID)
        {
            _rowIndex = rowIndex;
            _rowID = rowID;
        }

    }
}



