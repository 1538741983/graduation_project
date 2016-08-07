
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    ToolbarCollection.cs
 * CreatedOn:   2009-08-31
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
    /// 工具条控件集合
    /// </summary>
    public class ToolbarCollection : BaseCollection<Toolbar>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="parent">父控件实例</param>
        public ToolbarCollection(PanelBase parent)
            : base(parent)
        {
        }

        /*
        protected override void InsertItem(int index, Toolbar item)
        {
            item.RenderWrapperNode = false;
            panelBase.Controls.AddAt(GetStartIndex() + index, item);

            base.InsertItem(index, item);
        }

        protected override void RemoveItem(int index)
        {
            panelBase.Controls.RemoveAt(GetStartIndex() + index);

            base.RemoveItem(index);
        }

        protected override void ClearItems()
        {
            // We should only remove this collection related controls
            // Note we must loop from the last element(startIndex + Count - 1) to the first one(startIndex)
            int startIndex = GetStartIndex();
            for (int i = startIndex + Count - 1; i >= startIndex; i--)
            {
                panelBase.Controls.RemoveAt(i);
            }

            base.ClearItems();
        }

        /// <summary>
        /// Calculate the start index of Toolbars in base.Controls collection.
        /// </summary>
        /// <returns></returns>
        private int GetStartIndex()
        {
            if (panelBase is TabStrip)
            {
                return (panelBase as TabStrip).Tabs.Count;
            }
            else
            {
                return panelBase.Items.Count;
            }
        }
         * */
    }
}
