
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    CheckedEventArgs.cs
 * CreatedOn:   2013-10-22
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
using System.Data;
using System.Reflection;
using System.ComponentModel;
using System.Web.UI;


namespace FineUI
{
    /// <summary>
    /// 复选框/单选框/复选框菜单按钮的事件参数
    /// </summary>
    public class CheckedEventArgs : EventArgs
    {

        private bool _checked;

        /// <summary>
        /// 是否选中
        /// </summary>
        public bool Checked
        {
            get { return _checked; }
            set { _checked = value; }
        }


        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="isChecked">是否选中</param>
        public CheckedEventArgs(bool isChecked)
        {
            _checked = isChecked;
        }

    }
}



