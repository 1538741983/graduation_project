
#region Comment

/*
 * Project��    FineUI
 * 
 * FileName:    CheckedEventArgs.cs
 * CreatedOn:   2013-10-22
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
    /// ��ѡ��/��ѡ��/��ѡ��˵���ť���¼�����
    /// </summary>
    public class CheckedEventArgs : EventArgs
    {

        private bool _checked;

        /// <summary>
        /// �Ƿ�ѡ��
        /// </summary>
        public bool Checked
        {
            get { return _checked; }
            set { _checked = value; }
        }


        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="isChecked">�Ƿ�ѡ��</param>
        public CheckedEventArgs(bool isChecked)
        {
            _checked = isChecked;
        }

    }
}



