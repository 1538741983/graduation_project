
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    AccordionPanelCollection.cs
 * CreatedOn:   2008-06-16
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

namespace FineUI
{
    /// <summary>
    /// 手风琴面板控件集合
    /// </summary>
    public class AccordionPaneCollection : BaseCollection<AccordionPane>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="parent">父控件实例</param>
        public AccordionPaneCollection(Accordion parent)
            : base(parent)
        {

        }

        /*
        private Accordion _accordion;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="accordion">手风琴实例</param>
        public AccordionPaneCollection(Accordion accordion)
        {
            _accordion = accordion;
        }


        protected override void InsertItem(int index, AccordionPane item)
        {
            item.RenderWrapperNode = false;
            _accordion.Controls.AddAt(index, item);

            base.InsertItem(index, item);
        }
        */
    }
}
