
#region Comment

/*
 * Project��    FineUI
 * 
 * FileName:    TreeCommandEventArgs.cs
 * CreatedOn:   2008-07-22
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
    /// ���ڵ������¼�����
    /// </summary>
    public class TreeCommandEventArgs : EventArgs
    {
        private TreeNode _node;

        /// <summary>
        /// ��ʵ��
        /// </summary>
        public TreeNode Node
        {
            get { return _node; }
            set { _node = value; }
        }

        private string _nodeID;

        /// <summary>
        /// ���ڵ�ID
        /// </summary>
        public string NodeID
        {
            get { return _nodeID; }
            set { _nodeID = value; }
        }


        private string _commandName;

        /// <summary>
        /// ��������
        /// </summary>
        public string CommandName
        {
            get { return _commandName; }
            set { _commandName = value; }
        }


        private string _commandArgument;

        /// <summary>
        /// �������
        /// </summary>
        public string CommandArgument
        {
            get { return _commandArgument; }
            set { _commandArgument = value; }
        }


        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="node">���ڵ�</param>
        /// <param name="commandName">��������</param>
        /// <param name="commandArgument">�������</param>
        public TreeCommandEventArgs(TreeNode node, string commandName, string commandArgument)
        {
            _node = node;
            _nodeID = node.NodeID;
            _commandName = commandName;
            _commandArgument = commandArgument;
        }

    }
}



