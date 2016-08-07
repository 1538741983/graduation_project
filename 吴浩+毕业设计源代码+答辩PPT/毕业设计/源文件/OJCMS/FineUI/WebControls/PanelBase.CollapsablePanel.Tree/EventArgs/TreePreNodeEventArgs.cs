
#region Comment

/*
 * Project��    FineUIPro
 * 
 * FileName:    TreePreNodeEventArgs.cs
 * CreatedOn:   2014-09-13
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
using System.Xml;


namespace FineUI
{
    /// <summary>
    /// ���ڵ�Ԥ���¼�����
    /// </summary>
    public class TreePreNodeEventArgs : EventArgs
    {
        private bool _cancelled = false;

        /// <summary>
        /// �Ƿ�ȡ����ӱ��ڵ�
        /// </summary>
        public bool Cancelled
        {
            get { return _cancelled; }
            set { _cancelled = value; }
        }



        private XmlNode _xmlNode;

        /// <summary>
        /// ���ڵ������Դ
        /// </summary>
        public XmlNode XmlNode
        {
            get { return _xmlNode; }
            set { _xmlNode = value; }
        }

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="xmlNode">���ڵ������Դ</param>
        public TreePreNodeEventArgs(XmlNode xmlNode)
        {
            _xmlNode = xmlNode;
        }

    }
}



