
#region Comment

/*
 * Project��    FineUI
 * 
 * FileName:    GridRowEventArgs.cs
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
    /// ����а��¼�����
    /// </summary>
    public class GridRowEventArgs : EventArgs
    {

        private GridRow _row;

        /// <summary>
        /// ��ǰ��
        /// </summary>
        public GridRow Row
        {
            get { return _row; }
        }

        /// <summary>
        /// ���и��е�ֵ����Ⱦ���HTMLƬ�Σ�
        /// </summary>
        public object[] Values
        {
            get { return _row.Values; }
        }


        /// <summary>
        /// ������Դ
        /// </summary>
        public object DataItem
        {
            get { return _row.DataItem; }
        }


        /// <summary>
        /// ������
        /// </summary>
        public int RowIndex
        {
            get { return _row.RowIndex; }
        }

        /// <summary>
        /// ��ID
        /// </summary>
        public string RowID
        {
            get { return _row.RowID; }
        }


        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="row">��</param>
        public GridRowEventArgs(GridRow row)
        {
            _row = row;
        }

    }
}



