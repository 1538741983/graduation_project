
#region Comment

/*
 * Project��    FineUI
 * 
 * FileName:    TreeNodeCollection.cs
 * CreatedOn:   2008-07-21
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
using System.Collections;
using System.Data;
using System.Collections.ObjectModel;
using System.Web.UI;


namespace FineUI
{
    /// <summary>
    /// ���ڵ�ؼ�����
    /// </summary>
    public class TreeNodeCollection : Collection<TreeNode>
    {
        private Tree _treeInstance;
        private TreeNode _parentNode;

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="tree">��ʵ��</param>
        /// <param name="parentNode">���ڵ�</param>
        public TreeNodeCollection(Tree tree, TreeNode parentNode)
        {
            _treeInstance = tree;
            _parentNode = parentNode;
        }


        // ע��1:
        // ���������������
        // TreeNodeCollection nodes = new TreeNodeCollection();
        // TreeNode node = new TreeNode();
        // ע���ʱnode��û�й���tree1���κ���Ϣ��֮���ں������tree1.Nodes.Addʱ��֪����ǰ����ʵ��
        // nodes.Add(node);
        // tree1.Nodes.Add(nodes);

        // ע��2:
        // ������������Ľڵ㶨�壨��ASPX�ж���ģ�
        //    -China
	    //          -Zhumadian
		//              -Suiping
		//              -Xiping
        // ע�� InsertItem ��һ�ε����������Suiping����ڵ�ʱ���еģ�
        // Ҳ����˵�����Suipingʱ������֪����ǰ����ʵ������ֻ�������China��tree1.Nodesʱ��֪����ʵ��
        // ������Ҫ�� _treeInstance ��Ϊ��ʱ��Ҳ������Ӹ��ڵ�ʱ�ݹ����е��ӽڵ㣬������ʵ��
        
        /// <summary>
        /// �������ڵ�
        /// </summary>
        /// <param name="index">��������λ��</param>
        /// <param name="item">���ڵ�ʵ��</param>
        protected override void InsertItem(int index, TreeNode item)
        {
            if (_treeInstance != null)
            {
                ResolveTreeNode(item);
            }

            item.ParentNode = _parentNode;

            base.InsertItem(index, item);
        }


        /// <summary>
        /// ����ÿ���ڵ��Treeʵ��
        /// </summary>
        /// <param name="node"></param>
        private void ResolveTreeNode(TreeNode node)
        {
            node.TreeInstance = _treeInstance;
            if (node.Nodes.Count > 0)
            {
                foreach (TreeNode subNode in node.Nodes)
                {
                    ResolveTreeNode(subNode);
                }
            }
        }

    }

}



