
#region Comment

/*
 * Project��    FineUI
 * 
 * FileName:    WindowCloseEventArgs.cs
 * CreatedOn:   2008-06-27
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
using System.Data;
using System.Reflection;
using System.ComponentModel;
using System.Web.UI;


namespace FineUI
{
    /// <summary>
    /// ����ر��¼�����
    /// </summary>
    public class WindowCloseEventArgs : EventArgs
    {

        private string _closeArgument;

        /// <summary>
        /// �رղ���
        /// </summary>
        public string CloseArgument
        {
            get { return _closeArgument; }
            set { _closeArgument = value; }
        }


        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="closeArgument">�رղ���</param>
        public WindowCloseEventArgs(string closeArgument)
        {
            _closeArgument = closeArgument;
        }

    }
}



