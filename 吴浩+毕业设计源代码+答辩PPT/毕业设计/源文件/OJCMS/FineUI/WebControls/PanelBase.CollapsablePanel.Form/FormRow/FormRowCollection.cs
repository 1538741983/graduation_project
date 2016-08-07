
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    FormRowCollection.cs
 * CreatedOn:   2008-04-23
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
    /// 表单行控件集合
    /// </summary>
    public class FormRowCollection : BaseCollection<FormRow>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="parent">父控件实例</param>
        public FormRowCollection(Form parent)
            : base(parent)
        {

        }
        /*
        private Form form;
        private Control _control;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="form">表单实例</param>
        public FormRowCollection(Form form)
        {
            this.form = form;
            _control = new Control();
            form.Controls.Add(_control);
        }

        protected override void InsertItem(int index, FormRow item)
        {
            item.RenderWrapperNode = false;
            _control.Controls.AddAt(index, item);

            base.InsertItem(index, item);
        }

        protected override void RemoveItem(int index)
        {
            _control.Controls.RemoveAt(index);

            base.RemoveItem(index);
        }

        protected override void ClearItems()
        {
            _control.Controls.Clear();

            base.ClearItems();
        }
        */

        /*
        protected override void InsertItem(int index, FormRow item)
        {
            item.RenderWrapperNode = false;
            form.Controls.AddAt(index, item);

            base.InsertItem(index, item);
        }

        protected override void RemoveItem(int index)
        {
            form.Controls.RemoveAt(index);

            base.RemoveItem(index);
        }

        protected override void ClearItems()
        {
            // We should only remove this collection related controls
            // Note we must loop from the last element(Count-1) to the first one(0)
            for (int i = Count - 1; i >= 0; i--)
            {
                form.Controls.RemoveAt(i);
            }

            base.ClearItems();
        }
        */
    }
}
