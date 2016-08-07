
#region Comment

/*
 * Project��    FineUI
 * 
 * FileName:    TreeNodeEventArgs.cs
 * CreatedOn:   2014-03-28
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
    /// ���ڵ�չ���¼�����
    /// </summary>
    public class TreeNodeEventArgs : EventArgs
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
        /// <param name="node">���ڵ�</param>
        public TreeNodeEventArgs(TreeNode node)
        {
            _node = node;
            _nodeID = node.NodeID;
        }


        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="node">���ڵ�</param>
        /// <param name="xmlNode">���ڵ������Դ</param>
        public TreeNodeEventArgs(TreeNode node, XmlNode xmlNode)
        {
            _node = node;
            _nodeID = node.NodeID;
            _xmlNode = xmlNode;
        }

    }
}



