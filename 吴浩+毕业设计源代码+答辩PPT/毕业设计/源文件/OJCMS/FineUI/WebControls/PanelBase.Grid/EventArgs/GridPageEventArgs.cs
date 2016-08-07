
#region Comment

/*
 * Project��    FineUI
 * 
 * FileName:    GridPageEventArgs.cs
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
    /// ����ҳ�¼�����
    /// </summary>
    public class GridPageEventArgs : EventArgs
    {

        private int _newPageIndex;

        /// <summary>
        /// ��ҳ�������
        /// </summary>
        public int NewPageIndex
        {
            get { return _newPageIndex; }
            set { _newPageIndex = value; }
        }


        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="newPageIndex">��ҳ�������</param>
        public GridPageEventArgs(int newPageIndex)
        {
            _newPageIndex = newPageIndex;
        }

    }
}



