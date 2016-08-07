
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    WindowCloseEventArgs.cs
 * CreatedOn:   2008-06-27
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
    /// 窗体关闭事件参数
    /// </summary>
    public class WindowCloseEventArgs : EventArgs
    {

        private string _closeArgument;

        /// <summary>
        /// 关闭参数
        /// </summary>
        public string CloseArgument
        {
            get { return _closeArgument; }
            set { _closeArgument = value; }
        }


        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="closeArgument">关闭参数</param>
        public WindowCloseEventArgs(string closeArgument)
        {
            _closeArgument = closeArgument;
        }

    }
}



