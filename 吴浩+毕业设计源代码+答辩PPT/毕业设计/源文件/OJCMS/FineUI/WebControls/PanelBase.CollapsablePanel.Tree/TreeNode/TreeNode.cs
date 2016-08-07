
#region Comment

/*
 * Project��    FineUI
 * 
 * FileName:    TreeNode.cs
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
using System.Data;
using System.Reflection;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.Design;
using System.Drawing.Design;
using System.Xml;
using System.Web.UI.WebControls;


namespace FineUI
{
    /// <summary>
    /// ���ڵ�
    /// </summary>
    [ToolboxItem(false)]
    [ParseChildren(true, DefaultProperty = "Nodes")]
    [PersistChildren(false)]
    public class TreeNode
    {
        #region TreeInstance

        private Tree _tree;

        /// <summary>
        /// ��ʵ��
        /// </summary>
        public Tree TreeInstance
        {
            get
            {
                return _tree;
            }
            set
            {
                _tree = value;
            }
        }

        private TreeNode _parentNode;

        /// <summary>
        /// ���ڵ�
        /// </summary>
        public TreeNode ParentNode
        {
            get
            {
                return _parentNode;
            }
            set
            {
                _parentNode = value;
            }
        }


        #endregion

        #region Nodes

        private TreeNodeCollection _nodes;

        /// <summary>
        /// ���ڵ㼯��
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerDefaultProperty)]
        public TreeNodeCollection Nodes
        {
            get
            {
                if (_nodes == null)
                {
                    // ��������� TreeInstance == null ���жϣ��������ʱ�������´���
                    // �޷����� ParentNode ���Ե��ַ�����ʾ��ʽ FineUI.TreeNode ���� FineUI.TreeNode ���͵Ķ���
                    if (TreeInstance == null)
                    {
                        _nodes = new TreeNodeCollection(null, null);
                    }
                    else
                    {
                        // ��ʱTreeInstanceΪnull��������ASPX����Nodes�ڵ�ʱ
                        // ��ʱTreeInstance��Ϊnull������ͨ����̵��ֶΣ�����Ӹ��ڵ㣬Ȼ������ӽڵ�
                        _nodes = new TreeNodeCollection(TreeInstance, this);
                    }
                }
                return _nodes;
            }
        }

        #endregion

        #region EnableExpandEvent

        private bool _enableExpandEvent = false;
        /// <summary>
        /// չ�����ڵ��Ƿ�ط�
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("չ�����ڵ��Ƿ�ط�")]
        public bool EnableExpandEvent
        {
            get
            {
                return _enableExpandEvent;
            }
            set
            {
                _enableExpandEvent = value;
            }
        }

        private bool _enableCollapseEvent = false;
        /// <summary>
        /// �۵����ڵ��Ƿ�ط�
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("�۵����ڵ��Ƿ�ط�")]
        public bool EnableCollapseEvent
        {
            get
            {
                return _enableCollapseEvent;
            }
            set
            {
                _enableCollapseEvent = value;
            }
        } 

        #endregion

        #region EnableClickEvent|OnClientClick

        private bool _enablePostBack = false;
        /// <summary>
        /// �������ڵ��Ƿ�ط�
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("�������ڵ��Ƿ�ط�")]
        public bool EnableClickEvent
        {
            get
            {
                return _enablePostBack;
            }
            set
            {
                _enablePostBack = value;
            }
        }

        private string _onClientClick = String.Empty;
        /// <summary>
        /// �����ťʱ��Ҫִ�еĿͻ��˽ű�
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("�����ťʱ��Ҫִ�еĿͻ��˽ű�")]
        public string OnClientClick
        {
            get
            {
                return _onClientClick;
            }
            set
            {
                _onClientClick = value;
            }
        }

        #endregion

        #region CommandName|CommandArgument

        private string _commandName = String.Empty;
        /// <summary>
        /// ��������
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("��������")]
        public string CommandName
        {
            get
            {
                return _commandName;
            }
            set
            {
                _commandName = value;
            }
        }

        private string _commandArgument = String.Empty;
        /// <summary>
        /// �������
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("�������")]
        public string CommandArgument
        {
            get
            {
                return _commandArgument;
            }
            set
            {
                _commandArgument = value;
            }
        }


        #endregion

        #region EnableCheckBox|Checked|EnableCheckEvent

        private bool _checked = false;
        /// <summary>
        /// �Ƿ�ѡ��
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("�Ƿ�ѡ��")]
        public bool Checked
        {
            get
            {
                return _checked;
            }
            set
            {
                _checked = value;
            }
        }

        private bool _enableCheckBox = false;
        /// <summary>
        /// �Ƿ����ø�ѡ��
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("�Ƿ����ø�ѡ��")]
        public bool EnableCheckBox
        {
            get
            {
                return _enableCheckBox;
            }
            set
            {
                _enableCheckBox = value;
            }
        }

        private bool _enableCheckEvent = false;

        /// <summary>
        /// �ı临ѡ��״̬�Ƿ��Զ��ط�
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("�ı临ѡ��״̬�Ƿ��Զ��ط�")]
        public bool EnableCheckEvent
        {
            get
            {
                return _enableCheckEvent;
            }
            set
            {
                _enableCheckEvent = value;
            }
        }


        #endregion

        #region Properties

        private string _cssClass = String.Empty;
        /// <summary>
        /// �ڵ���ʽ��
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("�ڵ���ʽ��")]
        public string CssClass
        {
            get
            {
                return _cssClass;
            }
            set
            {
                _cssClass = value;
            }
        }



        private string _text = String.Empty;
        /// <summary>
        /// �ı�
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("�ı�")]
        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
            }
        }

        private string _nodeID = String.Empty;
        /// <summary>
        /// ���ڵ�ID
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("���ڵ�ID")]
        public string NodeID
        {
            get
            {
                if (String.IsNullOrEmpty(_nodeID))
                {
                    //_nodeID = String.Format("f_{0}", TreeInstance.NodeIDIncrement++); // ClientJavascriptIDManager.Instance.GetNextJavascriptID();
                    _nodeID = TreeNodeIDManager.Instance.GetNextTreeNodeID();
                }
                return _nodeID;

                #region old code

                //object obj = ViewState["NodeID"];
                //if (obj == null)
                //{
                //    // ����GUID�ķ�ʽ̫ռViewState
                //    //obj = ViewState["NodeID"] = Guid.NewGuid().ToString();
                //    //obj = ViewState["NodeID"] = String.Format("{0}_n{1}", TreeInstance.ClientJavascriptID, _nextNodeIndex++);

                //    obj = ViewState["NodeID"] = ClientJavascriptIDManager.Instance.GetNextJavascriptID();
                //}
                //return (string)obj;

                #endregion
            }
            set
            {
                _nodeID = value;
            }
        }

        private bool _leaf = false;
        /// <summary>
        /// �Ƿ�Ҷ�ӽڵ�
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("�Ƿ�Ҷ�ӽڵ�")]
        public bool Leaf
        {
            get
            {
                return _leaf;
            }
            set
            {
                _leaf = value;
            }
        }

        private bool _enabled = true;
        /// <summary>
        /// �Ƿ����
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("�Ƿ����")]
        public bool Enabled
        {
            get
            {
                return _enabled;
            }
            set
            {
                _enabled = value;
            }
        }


        private bool _expanded = false;
        /// <summary>
        /// �Ƿ�չ��
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("�Ƿ�չ��")]
        public bool Expanded
        {
            get
            {
                return _expanded;
            }
            set
            {
                _expanded = value;
            }
        }

        private string _target = String.Empty;
        /// <summary>
        /// ����Ŀ��
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("����Ŀ��")]
        public string Target
        {
            get
            {
                return _target;
            }
            set
            {
                _target = value;
            }
        }


        private string _navigateUrl = String.Empty;
        /// <summary>
        /// ���ӵ�ַ
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("���ӵ�ַ")]
        public string NavigateUrl
        {
            get
            {
                return _navigateUrl;
            }
            set
            {
                _navigateUrl = value;
            }
        }


        //private string _iconUrl = String.Empty;
        ///// <summary>
        ///// ͼ���ַ
        ///// </summary>
        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue("")]
        //[Description("ͼ���ַ")]
        //[Editor(typeof(ImageUrlEditor), typeof(UITypeEditor))]
        //public string IconUrl
        //{
        //    get
        //    {
        //        if (String.IsNullOrEmpty(_iconUrl))
        //        {
        //            if (Icon != Icon.None)
        //            {
        //                _iconUrl = IconHelper.GetIconUrl(Icon);
        //            }
        //        }
        //        return _iconUrl;
        //    }
        //    set
        //    {
        //        _iconUrl = value;
        //    }
        //}

        private string _iconUrl = String.Empty;
        /// <summary>
        /// ͼ���ַ
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("ͼ���ַ")]
        [Editor(typeof(ImageUrlEditor), typeof(UITypeEditor))]
        public string IconUrl
        {
            get
            {
                return _iconUrl;
            }
            set
            {
                _iconUrl = value;
            }
        }


        private Icon _icon = Icon.None;
        /// <summary>
        /// Ԥ����ͼ��
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(Icon.None)]
        [Description("Ԥ����ͼ��")]
        public virtual Icon Icon
        {
            get
            {
                return _icon;
            }
            set
            {
                _icon = value;
            }
        }

        private string _toolTip = String.Empty;
        /// <summary>
        /// ��ʾ�ı�
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("��ʾ�ı�")]
        public string ToolTip
        {
            get
            {
                return _toolTip;
            }
            set
            {
                _toolTip = value;
            }
        }

        //private bool _singleClickExpand = false;
        ///// <summary>
        ///// �������л��ڵ���۵�չ��״̬
        ///// </summary>
        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue(false)]
        //[Description("�������л��ڵ���۵�չ��״̬")]
        //public bool SingleClickExpand
        //{
        //    get
        //    {
        //        return _singleClickExpand;
        //    }
        //    set
        //    {
        //        _singleClickExpand = value;
        //    }
        //}


        #endregion

        #region private DataBindRow

        ///// <summary>
        ///// ���е�ֵ
        ///// </summary>
        //public void DataBindRow()
        //{
        //    #region old code
        //    //// ���û�г�ʼ��Values�����ʼ��
        //    //if (Values == null)
        //    //{
        //    //    GridColumnCollection columns = _grid.Columns;

        //    //    // ����ÿ�е�ֵ
        //    //    Values = new object[columns.Count];
        //    //    ExtraValues = new object[columns.Count];
        //    //    for (int i = 0, count = columns.Count; i < count; i++)
        //    //    {
        //    //        Values[i] = columns[i].GetColumnValue(this);
        //    //    }

        //    //    // ����DataKeys��ֵ
        //    //    if (_grid.DataKeyNames != null)
        //    //    {
        //    //        string[] keyNames = _grid.DataKeyNames;
        //    //        DataKeys = new object[keyNames.Length];
        //    //        for (int i = 0, count = keyNames.Length; i < count; i++)
        //    //        {
        //    //            DataKeys[i] = GetPropertyValue(keyNames[i]);
        //    //        }
        //    //    }

        //    //    //// CheckBoxField��Ҫ���⴦��
        //    //    //for (int i = 0, count = columns.Count; i < count; i++)
        //    //    //{
        //    //    //    CheckBoxField cbField = columns[i] as CheckBoxField;
        //    //    //    if (cbField != null)
        //    //    //    {
        //    //    //        cbField.IniValues();
        //    //    //    }
        //    //    //}
        //    //} 
        //    #endregion
        //}

        #endregion

        #region GetPropertyValue

        ///// <summary>
        ///// ȡ�����Ե�ֵ
        ///// </summary>
        ///// <param name="rowObj"></param>
        ///// <param name="propertyName"></param>
        ///// <returns></returns>
        //public object GetPropertyValue(string propertyName)
        //{
        //    //return ObjectUtil.GetPropertyValue(_dataItem, propertyName);
        //}


        #endregion

        #region old code

        //internal TreeNode AddNode()
        //{
        //    TreeNode node = new TreeNode();
        //    Nodes.Add(node);

        //    return node;
        //}

        #endregion

        #region ReadXmlAttributes

        internal void ReadXmlAttributes(XmlAttributeCollection attributes, Tree tree)
        {
            foreach (XmlAttribute attribute in attributes)
            {
                string name = attribute.Name;

                if (tree != null && tree.Mappings.Count > 0)
                {
                    name = tree.GetXmlAttributeMappingTo(name);
                }

                SetPropertyValue(name, attribute.Value);
            }
        }

        /// <summary>
        /// �������Ե�ֵ
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        private void SetPropertyValue(string name, string value)
        {
            PropertyInfo pInfo = GetType().GetProperty(name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            if (pInfo != null)
            {
                object objValue = null;

                if (pInfo.PropertyType == typeof(System.String))
                {
                    objValue = value;
                }
                else if (pInfo.PropertyType == typeof(System.Boolean))
                {
                    objValue = Convert.ToBoolean(value);
                }
                else if (pInfo.PropertyType == typeof(System.Int32))
                {
                    objValue = Convert.ToInt32(value);
                }
                else if (pInfo.PropertyType == typeof(Icon))
                {
                    objValue = (Icon)Enum.Parse(typeof(Icon), value, true);
                }

                pInfo.SetValue(this, objValue, null);
            }
        }

        #endregion

        #region oldcode

        //public override object SaveViewState()
        //{
        //    object[] states = new object[] { 
        //        base.SaveViewState(), 
        //        ((IStateManager)Nodes).SaveViewState()
        //    };

        //    return states;
        //}

        //public override void LoadViewState(object savedState)
        //{
        //    if (savedState != null)
        //    {
        //        object[] states = (object[])savedState;

        //        base.LoadViewState(states[0]);

        //        ((IStateManager)Nodes).LoadViewState(states[1]);
        //    }
        //}

        //public override void TrackViewState()
        //{
        //    base.TrackViewState();

        //    ((IStateManager)Nodes).TrackViewState();
        //}

        #endregion
    }
}



