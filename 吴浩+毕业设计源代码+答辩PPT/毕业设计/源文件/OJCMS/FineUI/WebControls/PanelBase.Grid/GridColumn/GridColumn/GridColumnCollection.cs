
#region Comment

/*
 * Project��    FineUI
 * 
 * FileName:    GridColumn.cs
 * CreatedOn:   2008-05-19
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
using System.Xml;
using System.Text;
using System.Collections;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Web.UI;


namespace FineUI
{
    /// <summary>
    /// ����м���
    /// </summary>
    public class GridColumnCollection : BaseCollection<GridColumn>
    {
        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="parent">���ؼ�ʵ��</param>
        public GridColumnCollection(ControlBase parent)
            : base(parent)
        {

        }

        /*
        private Grid _grid;
        
        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="grid">���ʵ��</param>
        public GridColumnCollection(Grid grid)
        {
            _grid = grid;

        }

        /// <summary>
        /// ������
        /// </summary>
        /// <param name="index">����</param>
        /// <param name="item">��</param>
        protected override void InsertItem(int index, GridColumn item)
        {
            item.ColumnIndex = index;
            item.Grid = _grid;

            base.InsertItem(index, item);
        }
        */
    }
}



