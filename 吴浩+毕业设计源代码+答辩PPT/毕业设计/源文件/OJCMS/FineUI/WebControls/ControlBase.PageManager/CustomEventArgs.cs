
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    CustomEventArgs.cs
 * CreatedOn:   2014-01-18
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

namespace FineUI
{
    /// <summary>
    /// 自定义事件参数
    /// </summary>
    public class CustomEventArgs : EventArgs
    {
        private string _eventArgument;

        /// <summary>
        /// 事件参数
        /// </summary>
        public string EventArgument
        {
            get { return _eventArgument; }
            set { _eventArgument = value; }
        }


        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="eventArgument">事件参数</param>
        public CustomEventArgs(string eventArgument)
        {
            _eventArgument = eventArgument;
        }

    }
}
