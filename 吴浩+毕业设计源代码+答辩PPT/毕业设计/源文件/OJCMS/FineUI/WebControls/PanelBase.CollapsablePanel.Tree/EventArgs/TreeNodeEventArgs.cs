
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    TreeNodeEventArgs.cs
 * CreatedOn:   2014-03-28
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
using System.Xml;


namespace FineUI
{
    /// <summary>
    /// 树节点展开事件参数
    /// </summary>
    public class TreeNodeEventArgs : EventArgs
    {
        private TreeNode _node;

        /// <summary>
        /// 树实例
        /// </summary>
        public TreeNode Node
        {
            get { return _node; }
            set { _node = value; }
        }


        private string _nodeID;

        /// <summary>
        /// 树节点ID
        /// </summary>
        public string NodeID
        {
            get { return _nodeID; }
            set { _nodeID = value; }
        }

        private XmlNode _xmlNode;

        /// <summary>
        /// 树节点的数据源
        /// </summary>
        public XmlNode XmlNode
        {
            get { return _xmlNode; }
            set { _xmlNode = value; }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="node">树节点</param>
        public TreeNodeEventArgs(TreeNode node)
        {
            _node = node;
            _nodeID = node.NodeID;
        }


        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="node">树节点</param>
        /// <param name="xmlNode">树节点的数据源</param>
        public TreeNodeEventArgs(TreeNode node, XmlNode xmlNode)
        {
            _node = node;
            _nodeID = node.NodeID;
            _xmlNode = xmlNode;
        }

    }
}



