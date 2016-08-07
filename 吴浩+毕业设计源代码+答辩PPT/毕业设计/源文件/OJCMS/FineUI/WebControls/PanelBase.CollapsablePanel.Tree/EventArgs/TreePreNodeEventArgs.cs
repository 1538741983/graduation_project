
#region Comment

/*
 * Project：    FineUIPro
 * 
 * FileName:    TreePreNodeEventArgs.cs
 * CreatedOn:   2014-09-13
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
    /// 树节点预绑定事件参数
    /// </summary>
    public class TreePreNodeEventArgs : EventArgs
    {
        private bool _cancelled = false;

        /// <summary>
        /// 是否取消添加本节点
        /// </summary>
        public bool Cancelled
        {
            get { return _cancelled; }
            set { _cancelled = value; }
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
        /// <param name="xmlNode">树节点的数据源</param>
        public TreePreNodeEventArgs(XmlNode xmlNode)
        {
            _xmlNode = xmlNode;
        }

    }
}



