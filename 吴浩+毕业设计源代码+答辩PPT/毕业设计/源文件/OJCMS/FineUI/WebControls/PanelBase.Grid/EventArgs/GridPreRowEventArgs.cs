
#region Comment

/*
 * Project��    FineUI
 * 
 * FileName:    GridPreRowEventArgs.cs
 * CreatedOn:   2008-06-27
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
    /// �����Ԥ���¼�����
    /// </summary>
    public class GridPreRowEventArgs : EventArgs
    {
        private bool _cancelled = false;

        /// <summary>
        /// �Ƿ�ȡ����ӱ��ڵ�
        /// </summary>
        public bool Cancelled
        {
            get { return _cancelled; }
            set { _cancelled = value; }
        }


        private object _dataItem;

        /// <summary>
        /// ������Դ���������ԴΪDataTable����DataItemΪDataRowView��
        /// </summary>
        public object DataItem
        {
            get { return _dataItem; }
        }


        private int _rowIndex;

        /// <summary>
        /// ������
        /// </summary>
        public int RowIndex
        {
            get { return _rowIndex; }
        }


        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="dataItem">������Դ</param>
        /// <param name="rowIndex">������</param>
        public GridPreRowEventArgs(object dataItem, int rowIndex)
        {
            _dataItem = dataItem;
            _rowIndex = rowIndex;
        }

    }
}



