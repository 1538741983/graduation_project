
#region Comment

/*
 * Project��    FineUI
 * 
 * FileName:    TreeCheckEventArgs.cs
 * CreatedOn:   2008-09-14
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
    /// ���ڵ�ѡ���¼�����
    /// </summary>
    public class TreeCheckEventArgs : EventArgs
    {
        private TreeNode _node;

        /// <summary>
        /// ���ڵ�
        /// </summary>
        public TreeNode Node
        {
            get { return _node; }
            set { _node = value; }
        }


        private string _nodeID;

        /// <summary>
        /// �ڵ�ID
        /// </summary>
        public string NodeID
        {
            get { return _nodeID; }
            set { _nodeID = value; }
        }

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
        /// <param name="node">���ڵ�</param>
        /// <param name="isChecked">�Ƿ�ѡ��</param>
        public TreeCheckEventArgs(TreeNode node, bool isChecked)
        {
            _node = node;
            _nodeID = node.NodeID;
            _checked = isChecked;
        }

    }
}



