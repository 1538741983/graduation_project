
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    GridColumn.cs
 * CreatedOn:   2008-05-19
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
using System.Xml;
using System.Text;
using System.Collections;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Web.UI;


namespace FineUI
{
    /// <summary>
    /// 表格列集合
    /// </summary>
    public class GridColumnCollection : BaseCollection<GridColumn>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="parent">父控件实例</param>
        public GridColumnCollection(ControlBase parent)
            : base(parent)
        {

        }

        /*
        private Grid _grid;
        
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="grid">表格实例</param>
        public GridColumnCollection(Grid grid)
        {
            _grid = grid;

        }

        /// <summary>
        /// 插入列
        /// </summary>
        /// <param name="index">索引</param>
        /// <param name="item">列</param>
        protected override void InsertItem(int index, GridColumn item)
        {
            item.ColumnIndex = index;
            item.Grid = _grid;

            base.InsertItem(index, item);
        }
        */
    }
}



