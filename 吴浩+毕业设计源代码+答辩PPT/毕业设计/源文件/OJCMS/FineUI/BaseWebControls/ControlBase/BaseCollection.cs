
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    BaseCollection.cs
 * CreatedOn:   2012-11-24
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
    public class BaseCollection<T> : Collection<T> where T : ControlBase
    {
        internal delegate void ItemsChangeHandler();
        internal event ItemsChangeHandler ItemsChange;


        private ControlBase _parent;
        private string _groupName;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="parentControl">父控件实例</param>
        public BaseCollection(ControlBase parentControl)
        {
            _parent = parentControl;
            _groupName = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// 向集合中插入一个元素
        /// </summary>
        /// <param name="index"></param>
        /// <param name="item"></param>
        protected override void InsertItem(int index, T item)
        {
            item.CollectionGroupName = _groupName;
            item.RenderWrapperNode = false;

            int startIndex = GetStartIndex();
            _parent.Controls.AddAt(startIndex + index, item);

            base.InsertItem(index, item);

            if (this.ItemsChange != null)
            {
                this.ItemsChange();
            }
        }

        /// <summary>
        /// 删除集合中的一个元素
        /// </summary>
        /// <param name="index"></param>
        protected override void RemoveItem(int index)
        {
            int startIndex = GetStartIndex();
            _parent.Controls.RemoveAt(startIndex + index);

            base.RemoveItem(index);

            if (this.ItemsChange != null)
            {
                this.ItemsChange();
            }
        }

        /// <summary>
        /// 清空集合
        /// </summary>
        protected override void ClearItems()
        {
            int startIndex = GetStartIndex();
            // We should only remove this collection related controls
            // Note we must loop from the last element(Count-1) to the first one(0)
            for (int i = startIndex + Count - 1; i >= startIndex; i--)
            {
                _parent.Controls.RemoveAt(i);
            }

            base.ClearItems();

            if (this.ItemsChange != null)
            {
                this.ItemsChange();
            }
        }


        /// <summary>
        /// 获取类型 T 在父控件子集中的开始位置
        /// </summary>
        /// <returns></returns>
        private int GetStartIndex()
        {
            int startIndex = 0;

            foreach (Control control in _parent.Controls)
            {
                if (control is ControlBase && (control as ControlBase).CollectionGroupName == _groupName)
                {
                    break;
                }
                startIndex++;
            }

            return startIndex;
        }

    }
}
