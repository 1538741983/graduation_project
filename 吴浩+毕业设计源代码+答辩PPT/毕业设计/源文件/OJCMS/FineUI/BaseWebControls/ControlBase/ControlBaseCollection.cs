
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    ControlBaseCollection.cs
 * CreatedOn:   2008-06-08
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
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Web.UI;
using System.Collections;

namespace FineUI
{
    /// <summary>
    /// 控件集合
    /// </summary>
    public class ControlBaseCollection : BaseCollection<ControlBase>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="parent">父控件实例</param>
        public ControlBaseCollection(ControlBase parent)
            : base(parent)
        {

        }

        /*
        protected override void InsertItem(int index, ControlBase item)
        {
            item.RenderWrapperNode = false;
            _parent.Controls.AddAt(index, item);

            base.InsertItem(index, item);
        }

        protected override void RemoveItem(int index)
        {
            _parent.Controls.RemoveAt(index);

            base.RemoveItem(index);
        }

        protected override void ClearItems()
        {
            // We should only remove this collection related controls
            // Note we must loop from the last element(Count-1) to the first one(0)
            for (int i = Count - 1; i >= 0; i--)
            {
                _parent.Controls.RemoveAt(i);
            }

            base.ClearItems();
        }
        */
    }
}
