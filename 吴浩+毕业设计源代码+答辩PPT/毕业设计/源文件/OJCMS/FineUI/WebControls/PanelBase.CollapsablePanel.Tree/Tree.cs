
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    Tree.cs
 * CreatedOn:   2008-07-21
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Design;
using System.Web.UI.Design.WebControls;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using System.Web.UI.HtmlControls;
using System.Data;
using System.Xml;

namespace FineUI
{
    /// <summary>
    /// 树控件
    /// </summary>
    [Designer("FineUI.Design.TreeDesigner, FineUI.Design")]
    [ToolboxData("<{0}:Tree Title=\"Tree\" AutoScroll=\"true\" runat=\"server\"></{0}:Tree>")]
    [ToolboxBitmap(typeof(Tree), "toolbox.Tree.bmp")]
    [Description("树控件")]
    [ParseChildren(true)]
    [PersistChildren(false)]
    [ControlBuilder(typeof(NotAllowWhitespaceLiteralsBuilder))]
    public class Tree : CollapsablePanel, IPostBackDataHandler, IPostBackEventHandler
    {
        #region Constructor

        /// <summary>
        /// 构造函数
        /// </summary>
        public Tree()
        {
            AddServerAjaxProperties();
            AddClientAjaxProperties("F_Nodes", "SelectedNodeIDArray");

            AddGzippedAjaxProperties("F_Nodes");
        }

        //internal int NodeIDIncrement = 0;

        #endregion

        #region Unsupported Properties

        /// <summary>
        /// 不支持此属性
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override ITemplate Content
        {
            get
            {
                return base.Content;
            }
        }

        /// <summary>
        /// 不支持此属性
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override ControlBaseCollection Items
        {
            get
            {
                return base.Items;
            }
        }

        /// <summary>
        /// 不支持此属性
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override bool EnableIFrame
        {
            get
            {
                return base.EnableIFrame;
            }
        }


        /// <summary>
        /// 不支持此属性
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override string IFrameUrl
        {
            get
            {
                return base.IFrameUrl;
            }
        }


        /// <summary>
        /// 不支持此属性
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override string IFrameName
        {
            get
            {
                return base.IFrameName;
            }
        }

        /// <summary>
        /// 布局类型
        /// </summary>
        [ReadOnly(true)]
        [Category(CategoryName.LAYOUT)]
        [DefaultValue(Layout.Container)]
        [Description("布局类型")]
        public override Layout Layout
        {
            get
            {
                return Layout.Container;
            }
        }

        #endregion

        #region Properties

        
        /// <summary>
        /// 单击切换节点的折叠展开状态
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("单击切换节点的折叠展开状态")]
        public bool EnableSingleClickExpand
        {
            get
            {
                object obj = FState["EnableSingleClickExpand"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                FState["EnableSingleClickExpand"] = value;
            }
        }

        /// <summary>
        /// 启用箭头
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("启用箭头")]
        public bool EnableArrows
        {
            get
            {
                object obj = FState["EnableArrows"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                FState["EnableArrows"] = value;
            }
        }

        /// <summary>
        /// 启用节点之间连线
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("启用节点之间连线")]
        public bool EnableLines
        {
            get
            {
                object obj = FState["EnableLines"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                FState["EnableLines"] = value;
            }
        }

        /// <summary>
        /// 启用动画
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("启用动画")]
        public bool EnableAnimate
        {
            get
            {
                object obj = FState["EnableAnimate"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                FState["EnableAnimate"] = value;
            }
        }

        /// <summary>
        /// 每次只能展开一个
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("每次只能展开一个")]
        public bool EnableSingleExpand
        {
            get
            {
                object obj = FState["EnableSingleExpand"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                FState["EnableSingleExpand"] = value;
            }
        }


       

        /// <summary>
        /// 启用图标
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("启用图标")]
        public bool EnableIcons
        {
            get
            {
                object obj = FState["EnableIcons"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                FState["EnableIcons"] = value;
            }
        }

        /// <summary>
        /// 自动标识没有子节点的节点为叶子节点，而不必为每个设置设置 Leaf 属性（默认：true）
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("自动标识没有子节点的节点为叶子节点，而不必为每个设置设置 Leaf 属性")]
        public bool AutoLeafIdentification
        {
            get
            {
                object obj = FState["AutoLeafIdentification"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                FState["AutoLeafIdentification"] = value;
            }
        }


        /// <summary>
        /// 启用多行选择
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("启用多行选择")]
        public bool EnableMultiSelect
        {
            get
            {
                object obj = FState["EnableMultiSelect"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                FState["EnableMultiSelect"] = value;
            }
        }

        /// <summary>
        /// 启用树中的文字选择
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("启用树中的文字选择")]
        public bool EnableTextSelection
        {
            get
            {
                object obj = FState["EnableTextSelection"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                FState["EnableTextSelection"] = value;
            }
        }


        #endregion

        #region DataSource

        private object _dataSource;

        /// <summary>
        /// 数据源
        /// </summary>
        [DefaultValue(null)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object DataSource
        {
            set
            {
                _dataSource = value;
            }
            get
            {
                return _dataSource;
            }
        }

        #endregion

        #region Nodes

        private TreeNodeCollection _nodes;

        /// <summary>
        /// 树节点集合
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("树节点集合")]
        public virtual TreeNodeCollection Nodes
        {
            get
            {
                if (_nodes == null)
                {
                    // 如果不加上 DesignMode 的判断，则在设计时出现如下错误
                    // 无法从TreeInstance属性的字符串表示形式创建FineUI.Tree类型的对象
                    if (DesignMode)
                    {
                        _nodes = new TreeNodeCollection(null, null);
                    }
                    else
                    {
                        _nodes = new TreeNodeCollection(this, null);
                    }
                }
                return _nodes;
            }
        }
        #endregion

        #region SelectedNodeIDArray

        /// <summary>
        /// 选中的树节点
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TreeNode SelectedNode
        {
            get
            {
                return FindNode(SelectedNodeID);
            }
        }

        /// <summary>
        /// [AJAX属性]选中的树节点ID
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("[AJAX属性]选中的行节点ID")]
        public string SelectedNodeID
        {
            get
            {
                if (SelectedNodeIDArray.Length > 0)
                {
                    return SelectedNodeIDArray[0];
                }
                else
                {
                    return String.Empty;
                }
            }
            set
            {
                SelectedNodeIDArray = new string[] { value };
            }
        }

        /// <summary>
        /// [AJAX属性]选中的树节点ID列表
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [Description("[AJAX属性]选中的行节点ID列表")]
        [TypeConverter(typeof(StringArrayConverter))]
        public string[] SelectedNodeIDArray
        {
            get
            {
                object obj = FState["SelectedNodeIDArray"];
                return obj == null ? new string[] { } : (string[])obj;
            }
            set
            {
                // 排序主要是为了拿两次的值做比较
                FState["SelectedNodeIDArray"] = GetSortedArray(value).ToArray();
            }
        }

        private List<string> GetSortedArray(string[] value)
        {
            List<string> list = new List<string>();
            if (value != null)
            {
                list.AddRange(value);
                list.Sort();
            }
            return list;
        }

        #endregion

        #region Mappings

        private XmlAttributeMappingCollection _mappings;

        /// <summary>
        /// 树控件属性与数据源节点的映射关系
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("树控件属性与数据源节点的映射关系")]
        public virtual XmlAttributeMappingCollection Mappings
        {
            get
            {
                if (_mappings == null)
                {
                    _mappings = new XmlAttributeMappingCollection();
                }
                return _mappings;
            }
        }
        #endregion

        #region HiddenFieldID

        /// <summary>
        /// 选中行
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        private string SelectedNodeIDArrayHiddenFieldID
        {
            get
            {
                return String.Format("{0}_SelectedNodeIDArray", ClientID);
            }
        }

        /// <summary>
        /// 展开的节点列表
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        private string ExpandedNodesHiddenFieldID
        {
            get
            {
                return String.Format("{0}_ExpandedNodes", ClientID);
            }
        }

        /// <summary>
        /// 选中的节点列表
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        private string CheckedNodesHiddenFieldID
        {
            get
            {
                return String.Format("{0}_CheckedNodes", ClientID);
            }
        }


        #endregion

        #region F_Nodes

        /// <summary>
        /// 树节点集合的 JSON 表示（内部使用）
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public JArray F_Nodes
        {
            get
            {
                return GetNodesJArray(Nodes);
            }
            set
            {
                // 从请求中恢复 Nodes 属性，这个 set 方法在 OnInit 中被调用
                Nodes.Clear();
                FromNodesJArray(value, Nodes);
            }
        }

        #region FromNodesJArray GetNodesJArray

        private void FromNodesJArray(JArray ja, TreeNodeCollection nodes)
        {
            foreach (JArray ja2 in ja)
            {
                TreeNode treeNode = new TreeNode();
                nodes.Add(treeNode);

                // 0 - Text
                // 1 - Leaf
                // 2 - NodeID
                // 3 - Enabled
                // 4 - EnableCheckBox
                // 5 - Checked
                // 6 - Expanded
                // 7 - NavigateUrl
                // 8 - Target
                // 9 - href
                // 10 - Icon
                // 11 - IconUrl
                // 12 - iconUrl - 这个是客户端用来生成图标的
                // 13 - ToolTip
                // 14 - OnClientClick
                // 15 - EnableClickEvent
                // 16 - CommandName
                // 17 - CommandArgument

                // 18 - EnableCheckEvent
                // 19 - EnableExpandEvent
                // 20 - EnableCollapseEvent

                // 21 - Nodes
                treeNode.Text = ja2[0].Value<string>(); //ja2.getString(0);
                treeNode.Leaf = ja2[1].Value<int>() == 1 ? true : false;
                treeNode.NodeID = ja2[2].Value<string>(); ;
                treeNode.Enabled = ja2[3].Value<int>() == 1 ? true : false;
                treeNode.EnableCheckBox = ja2[4].Value<int>() == 1 ? true : false;
                treeNode.Checked = ja2[5].Value<int>() == 1 ? true : false;
                treeNode.Expanded = ja2[6].Value<int>() == 1 ? true : false;
                treeNode.NavigateUrl = ja2[7].Value<string>();
                treeNode.Target = ja2[8].Value<string>();
                string iconName = ja2[10].Value<string>();
                if (String.IsNullOrEmpty(iconName))
                {
                    iconName = StringUtil.EnumToName(Icon.None);
                }
                treeNode.Icon = (Icon)StringUtil.EnumFromName(typeof(Icon), iconName);
                treeNode.IconUrl = ja2[11].Value<string>();
                treeNode.ToolTip = ja2[13].Value<string>(); 

                treeNode.OnClientClick = ja2[14].Value<string>();
                treeNode.EnableClickEvent = ja2[15].Value<int>() == 1 ? true : false;
                treeNode.CommandName = ja2[16].Value<string>();
                treeNode.CommandArgument = ja2[17].Value<string>();
                

                treeNode.EnableCheckEvent = ja2[18].Value<int>() == 1 ? true : false;

                treeNode.EnableExpandEvent = ja2[19].Value<int>() == 1 ? true : false;
                treeNode.EnableCollapseEvent = ja2[20].Value<int>() == 1 ? true : false;

                treeNode.CssClass = ja2[21].Value<string>();

                JArray childNodes = ja2[22].Value<JArray>();
                if (childNodes != null && childNodes.Count > 0)
                {
                    FromNodesJArray(childNodes, treeNode.Nodes);
                }
            }
        }

        private JArray GetNodesJArray(TreeNodeCollection nodes)
        {
            JArray ja = new JArray();
            foreach (TreeNode node in nodes)
            {
                JArray ja2 = new JArray();

                // 0 - Text
                // 1 - Leaf
                // 2 - NodeID
                // 3 - Enabled
                // 4 - EnableCheckBox
                // 5 - Checked
                // 6 - Expanded
                // 7 - NavigateUrl
                // 8 - Target
                // 9 - href
                // 10 - Icon
                // 11 - IconUrl
                // 12 - iconUrl - 这个是客户端用来生成图标的
                // 13 - ToolTip
                // 14 - OnClientClick
                // 15 - EnableClickEvent
                // 16 - CommandName
                // 17 - CommandArgument

                // 18 - EnableCheckEvent
                // 19 - EnableExpandEvent
                // 20 - EnableCollapseEvent

                // 21 - CssClass

                // 22 - Nodes
                ja2.Add(node.Text);
                ja2.Add(node.Leaf ? 1 : 0);
                ja2.Add(node.NodeID);
                ja2.Add(node.Enabled ? 1 : 0);
                ja2.Add(node.EnableCheckBox ? 1 : 0);
                ja2.Add(node.Checked ? 1 : 0);
                ja2.Add(node.Expanded ? 1 : 0);

                ja2.Add(node.NavigateUrl);
                ja2.Add(node.Target);
                ja2.Add(ResolveUrl(node.NavigateUrl));

                ja2.Add(node.Icon == Icon.None ? "" : StringUtil.EnumToName(node.Icon));
                ja2.Add(String.IsNullOrEmpty(node.IconUrl) ? "" : node.IconUrl);
                ja2.Add(IconHelper.GetResolvedIconUrl(node.Icon, node.IconUrl));

                ja2.Add(String.IsNullOrEmpty(node.ToolTip) ? "" : node.ToolTip);

                ja2.Add(node.OnClientClick);
                ja2.Add(node.EnableClickEvent ? 1 : 0);
                ja2.Add(node.CommandName);
                ja2.Add(node.CommandArgument);


                ja2.Add(node.EnableCheckEvent ? 1 : 0);

                ja2.Add(node.EnableExpandEvent ? 1 : 0);
                ja2.Add(node.EnableCollapseEvent ? 1 : 0);

                ja2.Add(node.CssClass);

                if (node.Nodes != null && node.Nodes.Count > 0)
                {
                    ja2.Add(GetNodesJArray(node.Nodes));
                }
                else
                {
                    ja2.Add(new JArray());
                }

                ja.Add(ja2);

                #region old code - JObject

                //JObject jo = new JObject();

                //jo.Add("Text", node.Text);
                //jo.Add("Leaf", node.Leaf);
                //jo.Add("NodeID", node.NodeID);
                //jo.Add("Enabled", node.Enabled);
                //jo.Add("EnableCheckBox", node.EnableCheckBox);
                //jo.Add("Checked", node.Checked);
                //jo.Add("Expanded", node.Expanded);

                //jo.Add("NavigateUrl", node.NavigateUrl);
                //jo.Add("Target", node.Target);
                //jo.Add("href", ResolveUrl(node.NavigateUrl));

                //jo.Add("Icon", StringUtil.EnumToName(node.Icon));
                //jo.Add("IconUrl", node.IconUrl);
                //jo.Add("iconUrl", GetResolvedIconUrl(node.Icon, IconUrl));

                //jo.Add("ToolTip", node.ToolTip);

                //jo.Add("SingleClickExpand", node.SingleClickExpand);

                //jo.Add("OnClientClick", node.OnClientClick);
                //jo.Add("EnablePostBack", node.EnablePostBack);

                //jo.Add("AutoPostBack", node.AutoPostBack);
                //jo.Add("CommandName", node.CommandName);
                //jo.Add("CommandArgument", node.CommandArgument);

                //if (node.Nodes != null && node.Nodes.Count > 0)
                //{
                //    jo.Add("Nodes", GetNodesJArray(node.Nodes));
                //}

                //ja.Add(jo);

                #endregion

                #region old code
                //#region options

                //jo.Add("text", node.Text);
                //jo.Add("leaf", node.Leaf);
                //jo.Add("id", node.NodeID);
                //if (!node.Enabled)
                //{
                //    jo.Add("disabled", true);
                //}
                //if (node.EnableCheckBox)
                //{
                //    jo.Add("checked", node.Checked);
                //}
                //// Leaf doesn't has expanded property.
                //if (!node.Leaf)
                //{
                //    jo.Add("expanded", node.Expanded);
                //}

                //#endregion

                //#region href

                //if (!String.IsNullOrEmpty(node.NavigateUrl))
                //{
                //    jo.Add("href", ResolveUrl(node.NavigateUrl));

                //    if (!String.IsNullOrEmpty(node.Target))
                //    {
                //        jo.Add("hrefTarget", node.Target);
                //    }
                //}

                //#endregion

                //#region IconUrl

                //if (!String.IsNullOrEmpty(node.IconUrl))
                //{
                //    jo.Add("icon", ResolveUrl(node.IconUrl));

                //    #region old code
                //    // 添加CSS样式，这种方法添加的图片位置靠上
                //    // string className = AddStartupCSS(String.Format("{0}-button-icon-image", ClientID),
                //    //    GetBackgroundStyleCss(ResolveUrl(IconUrl)));

                //    //OB.AddProperty(OptionName.IconCls, className); 
                //    #endregion
                //}

                //#endregion

                //#region qtip

                //if (!String.IsNullOrEmpty(node.ToolTip))
                //{
                //    jo.Add("qtip", node.ToolTip);
                //}

                //#endregion

                //#region SingleClickExpand

                //if (node.SingleClickExpand)
                //{
                //    jo.Add("singleClickExpand", true);
                //}

                //#endregion

                //#region old code

                ////JsObjectBuilder listenersBuilder = new JsObjectBuilder();

                ////#region old code

                //////// 展开时判断是否需要到后台取数据
                ////////listenersBuilder.AddProperty("beforeappend", String.Format("function(node,deep,anim){{\r\nif(!node.loaded){{alert(node.id);\r\n}}}}"), true);

                //////// 折叠/展开
                ////////listenersBuilder.AddProperty(OptionName.Expand, String.Format("function(node){{F.util.addValueToHiddenField('{0}',node.id);}}", ExpandedNodesHiddenFieldID), true);
                ////////listenersBuilder.AddProperty(OptionName.Collapse, String.Format("function(node){{F.util.removeValueFromHiddenField('{0}',node.id);}}", ExpandedNodesHiddenFieldID), true);
                //////listenersBuilder.AddProperty("expand", Render_NodeExpandScriptID, true);
                //////listenersBuilder.AddProperty("collapse", Render_NodeCollapseScriptID, true);


                ////#endregion

                ////#region Click Event

                ////// 如果禁用此节点，则不响应点击事件（不可选中）
                ////// Added by sanshi.ustc#gmail.com 2009-8-24
                ////if (!node.Enabled)
                ////{
                ////    listenersBuilder.AddProperty("beforeclick", "function(){return false;}", true);
                ////}

                ////string clickScript = node.OnClientClick;
                ////if (!String.IsNullOrEmpty(clickScript) && !clickScript.EndsWith(";"))
                ////{
                ////    clickScript += ";";
                ////}
                ////if (node.EnablePostBack)
                ////{
                ////    string paramStr = String.Format("Command${0}${1}${2}", node.NodeID, node.CommandName.Replace("'", "\""), node.CommandArgument.Replace("'", "\""));
                ////    clickScript += GetPostBackEventReference(paramStr);
                ////}
                ////if (!String.IsNullOrEmpty(clickScript))
                ////{
                ////    listenersBuilder.AddProperty("click", JsHelper.GetFunction(clickScript, "node"), true);
                ////}

                ////#endregion

                ////#region CheckBox - AutoPostback

                ////// CheckBox选中
                ////if (node.EnableCheckBox)
                ////{
                ////    string checkchangeScript = String.Empty;

                ////    // 自动回发到服务器
                ////    checkchangeScript += String.Format("var args='Check${0}$'+checked;", node.NodeID);
                ////    checkchangeScript += GetPostBackEventReference("#CHECK#").Replace("'#CHECK#'", "args");

                ////    listenersBuilder.AddProperty("checkchange", JsHelper.GetFunction(checkchangeScript, "node", "checked"), true);

                ////    #region old code
                ////    //if (!node.AutoPostBack)
                ////    //{
                ////    //    // 改变CheckBox，不需要自动回发，则将checkchange指向预定义的函数，这有助于减少代码量
                ////    //    //listenersBuilder.AddProperty("checkchange", String.Format("function(node,checked){{if(checked){{F.util.addValueToHiddenField('{0}',node.id);}}else{{F.util.removeValueFromHiddenField('{0}',node.id);}}}}", CheckedNodesHiddenFieldID), true);
                ////    //    listenersBuilder.AddProperty("checkchange", Render_NodeCheckChangeScriptID, true);
                ////    //}
                ////    //else
                ////    //{
                ////    //    string checkchangeScript = String.Empty;

                ////    //    // 改变页面中隐藏字段的值
                ////    //    checkchangeScript += String.Format("{0}.apply(window, [node, checked]);", Render_NodeCheckChangeScriptID);

                ////    //    // 自动回发到服务器
                ////    //    checkchangeScript += String.Format("var args='Check${0}$'+checked;", node.NodeID);
                ////    //    checkchangeScript += GetPostBackEventReference("#CHECK#").Replace("'#CHECK#'", "args");

                ////    //    listenersBuilder.AddProperty("checkchange", String.Format("function(node,checked){{{0}}}", checkchangeScript), true);
                ////    //} 
                ////    #endregion
                ////}

                ////#endregion

                ////jo.Add("listeners", listenersBuilder);

                //#endregion 
                #endregion
            }

            return ja;
        }

        #endregion

        #endregion

        #region OnPreRender

        #region Render_StoreID

        private string Render_StoreID
        {
            get
            {
                return String.Format("{0}_store", XID);
            }
        }

        #region oldcode

        //private string Render_NodesID
        //{
        //    get
        //    {
        //        return String.Format("{0}_nodes", XID);
        //    }
        //}


        //private string Render_RootId
        //{
        //    get
        //    {
        //        return String.Format("{0}_root", ClientJavascriptID);
        //    }
        //}

        //private string Render_SelectModelID
        //{
        //    get
        //    {
        //        return String.Format("{0}_select_model", XID);
        //    }
        //}

        //private string Render_NodeExpandScriptID
        //{
        //    get
        //    {
        //        return String.Format("{0}_node_expand", XID);
        //    }
        //}

        //private string Render_NodeCollapseScriptID
        //{
        //    get
        //    {
        //        return String.Format("{0}_node_collapse", XID);
        //    }
        //}

        //private string Render_NodeClickScriptID
        //{
        //    get
        //    {
        //        return String.Format("{0}_node_click", XID);
        //    }
        //}

        //private string Render_NodeCheckChangeScriptID
        //{
        //    get
        //    {
        //        return String.Format("{0}_node_checkchange", XID);
        //    }
        //} 
        #endregion

        #endregion

        #region OnPreRender

        /// <summary>
        /// 初始化控件
        /// </summary>
        protected override void OnInitControl()
        {
            base.OnInitControl();

            // 修复Tree的节点，这里可能会修改树节点的属性，从而影响 F_Nodes 的计算结果
            // 在这个地方调用是安全的：
            //      -> 页面第一次加载时，运行到这里 ASPX 上面的标签已经初始化完毕
            //      -> 页面回发时（包括正常回发或者AJAX回发），此时请求表单中 F_STATE 已经恢复完毕
            FixTreeNodes();
        }

        /// <summary>
        /// 渲染 HTML 之前调用
        /// </summary>
        protected override void OnBothPreRender()
        {
            base.OnBothPreRender();

            // Nodes 属性有可能在页面加载后被用户修改，比如绑定数据，所以在输出之前应该调用此函数
            FixTreeNodes();
        }

        /// <summary>
        /// 渲染 HTML 之前调用（AJAX回发）
        /// </summary>
        protected override void OnAjaxPreRender()
        {
            base.OnAjaxPreRender();

            StringBuilder sb = new StringBuilder();

            bool reloaded = false;
            if (PropertyModified("F_Nodes"))
            {
                sb.AppendFormat("{0}.f_loadData();", XID);
                reloaded = true;
            }

            if (reloaded)
            {
                // 如果重新加载了数据，则要重新设置选中项
                sb.AppendFormat("{0}.f_selectNodes();", XID);
            }
            else
            {
                if (PropertyModified("SelectedNodeIDArray"))
                {
                    sb.AppendFormat("{0}.f_selectNodes();", XID);
                }
            }

            AddAjaxScript(sb);
        }


        /// <summary>
        /// 渲染 HTML 之前调用（页面第一次加载或者普通回发）
        /// </summary>
        protected override void OnFirstPreRender()
        {
            // 确保 F_Nodes 在页面第一次加载时都存在于 F_STATE 中，因为客户端需要这个数据来渲染树控件
            // 并且这个代码要放在 base.OnFirstPreRender(); 之前，因为在那里面会生成 F_STATE
            FState.AddModifiedProperty("F_Nodes");

            base.OnFirstPreRender();

            //ResourceManager.Instance.AddJavaScriptComponent("tree");

            #region viewConfig

            JsObjectBuilder viewBuilder = new JsObjectBuilder();

            if (EnableTextSelection)
            {
                viewBuilder.AddProperty("enableTextSelection", true);
            }

            if (viewBuilder.Count > 0)
            {
                OB.AddProperty("viewConfig", viewBuilder);
            }
            
            #endregion

            #region options

            OB.AddProperty("useArrows", EnableArrows);
            OB.AddProperty("lines", EnableLines);

            OB.AddProperty("animate", EnableAnimate);

            OB.AddProperty("singleExpand", EnableSingleExpand);
            

            if (!EnableIcons)
            {
                OB.AddProperty("bodyCls", "x-tree-noicon");
            }


            // 这个为了在客户端生成 PostBack 脚本，比如 __doPostBack('RegionPanel1$TreePanel1','')
            OB.AddProperty("name", UniqueID);

            #endregion

            #region oldcode

            //string hiddenFieldsScript = String.Empty;

            //// 选中的行
            //hiddenFieldsScript += GetSetHiddenFieldValueScript(SelectedNodeHiddenFieldID, SelectedNode == null ? "" : SelectedNode.NodeID);

            //// 展开的行
            //hiddenFieldsScript += GetSetHiddenFieldValueScript(ExpandedNodesHiddenFieldID, StringUtil.GetStringFromStringArray(GetExpandedNodeIDs()));

            //// 选中的行
            //hiddenFieldsScript += GetSetHiddenFieldValueScript(CheckedNodesHiddenFieldID, StringUtil.GetStringFromStringArray(GetCheckedNodeIDs()));


            #endregion

            #region Loader

            string loaderScript = String.Empty;

            JsObjectBuilder loaderBuilder = new JsObjectBuilder();


            JsObjectBuilder listenersBuilder = new JsObjectBuilder();

            string paramStr = String.Format("LazyLoad${0}", "#ID#");
            string postBackScript = GetPostBackEventReference(paramStr);
            postBackScript = postBackScript.Replace("#ID#'", "'+op.id");
            listenersBuilder.AddProperty("beforeload", String.Format("function(store,op){{if(op.action==='read'&&op.id!=='root'){{{0}}}return false;}}", postBackScript), true);

            //listenersBuilder.AddProperty(OptionName.Scope, "box", true);
            loaderBuilder.AddProperty("listeners", listenersBuilder);
            // 必须添加dataUrl，才会引发beforeload事件
            //loaderBuilder.AddProperty("dataUrl", "about:blank");
            //loaderBuilder.AddProperty("preloadChildren", true);
            //loaderBuilder.AddProperty("clearOnLoad", false);

            loaderScript = String.Format("var {0}=Ext.create('Ext.data.TreeStore',{1});", Render_StoreID, loaderBuilder);

            OB.AddProperty("store", Render_StoreID, true);
            #endregion

            #region Listeners

            string beforeclickScript = "if(node.disabled){return false;}";
            //OB.Listeners.AddProperty("beforeitemclick", JsHelper.GetFunction(beforeclickScript, "view", "node", "item", "index"), true);
            AddListener("beforeitemclick", beforeclickScript, "view", "node", "item", "index");


            string singleclickexpandScript = "";
            if (EnableSingleClickExpand)
            {
                //singleclickexpandScript = "if(!node.isLeaf()){if(node.isExpanded()){node.collapse();}else{node.expand();}}";
                singleclickexpandScript = "if(node.isExpandable()&&!node.isLeaf()){if(node.isExpanded()){this.collapseNode(node);}else{this.expandNode(node);}}";
            }

            string itemclickScript = "var args='Command$'+node.getId()+'$'+node.raw.f_commandname+'$'+node.raw.f_commandargument;";
            itemclickScript += GetPostBackEventReference("#Click#").Replace("'#Click#'", "args");
            itemclickScript = String.Format("if(node.raw.f_enableclickevent){{{0}}}", itemclickScript);
            itemclickScript = "if(node.raw.f_clientclick){if(new Function(node.raw.f_clientclick)()===false){return;}}" + itemclickScript;
            //itemclickScript = "if(node.raw.f_clientclick){eval(node.raw.f_clientclick);}" + itemclickScript; // new Function(node.raw.f_clientclick)();
            //OB.Listeners.AddProperty("itemclick", JsHelper.GetFunction(singleclickexpandScript + itemclickScript, "view", "node", "item", "index"), true);
            AddListener("itemclick", singleclickexpandScript + itemclickScript, "view", "node", "item", "index");



            string checkchangeScript = "var args='Check$'+node.getId()+'$'+checked;";
            checkchangeScript += GetPostBackEventReference("#CheckChange#").Replace("'#CheckChange#'", "args");
            checkchangeScript = String.Format("if(node.raw.f_enablecheckevent){{{0}}}", checkchangeScript);
            //OB.Listeners.AddProperty("checkchange", JsHelper.GetFunction(checkchangeScript, "node", "checked"), true);
            AddListener("checkchange", checkchangeScript, "node", "checked");


            string expandScript = "var args='Expand$'+node.getId();";
            expandScript += GetPostBackEventReference("#Expand#").Replace("'#Expand#'", "args");
            expandScript = String.Format("if(node.raw.f_enableexpandevent){{{0}}}", expandScript);
            //OB.Listeners.AddProperty("itemexpand", JsHelper.GetFunction(expandScript, "node"), true);
            AddListener("itemexpand", expandScript, "node");


            string collapseScript = "var args='Collapse$'+node.getId();";
            collapseScript += GetPostBackEventReference("#Collapse#").Replace("'#Collapse#'", "args");
            collapseScript = String.Format("if(node.raw.f_enablecollapseevent){{{0}}}", collapseScript);
            //OB.Listeners.AddProperty("itemcollapse", JsHelper.GetFunction(collapseScript, "node"), true);
            AddListener("itemcollapse", collapseScript, "node");

            #endregion

            #region selectModel

            string selectModelScript = String.Empty;
            if (EnableMultiSelect)
            {
                selectModelScript = "Ext.create('Ext.selection.TreeModel',{mode:'MULTI'})";
            }
            else
            {
                selectModelScript = "Ext.create('Ext.selection.TreeModel',{mode:'SINGLE'})";
            }
            OB.AddProperty("selModel", selectModelScript, true);

            #endregion

            #region old code

            // nodes
            //string nodesScript = Render_NodesId + "=[{'text':'Audi','id':100,'leaf':false,'cls':'folder','children':[{'text':'A3','id':1000,'leaf':false,'cls':'folder','children':[{'text':'FuelEconomy','id':'100000','leaf':true,'cls':'file'},{'text':'Invoice','id':'100001','leaf':true,'cls':'file'},{'text':'MSRP','id':'100002','leaf':true,'cls':'file'},{'text':'Options','id':'100003','leaf':true,'cls':'file'},{'text':'Specifications','id':'100004','leaf':true,'cls':'file'}]},{'text':'TT','id':1000,'leaf':false,'cls':'folder','children':[{'text':'FuelEconomy','id':'100000','leaf':true,'cls':'file'},{'text':'Invoice','id':'100001','leaf':true,'cls':'file'},{'text':'MSRP','id':'100002','leaf':true,'cls':'file'},{'text':'Options','id':'100003','leaf':true,'cls':'file'},{'text':'Specifications','id':'100004','leaf':true,'cls':'file'}]}]},{'text':'Cadillac','id':300,'leaf':false,'cls':'folder','children':[{'text':'CTS','id':1000,'leaf':false,'cls':'folder','children':[{'text':'FuelEconomy','id':'100000','leaf':true,'cls':'file'},{'text':'Invoice','id':'100001','leaf':true,'cls':'file'},{'text':'MSRP','id':'100002','leaf':true,'cls':'file'},{'text':'Options','id':'100003','leaf':true,'cls':'file'},{'text':'Specifications','id':'100004','leaf':true,'cls':'file'}]},{'text':'CTS-V','id':1000,'leaf':false,'cls':'folder','children':[{'text':'FuelEconomy','id':'100000','leaf':true,'cls':'file'},{'text':'Invoice','id':'100001','leaf':true,'cls':'file'},{'text':'MSRP','id':'100002','leaf':true,'cls':'file'},{'text':'Options','id':'100003','leaf':true,'cls':'file'},{'text':'Specifications','id':'100004','leaf':true,'cls':'file'}]}]}];";
            //string nodesJsArray = GetNodesJsArray2(Nodes).ToString();
            //string nodesScript = String.Format("{0}={1};", Render_NodesID, nodesJsArray);

            #endregion

            #region Root

            //JsObjectBuilder rootBuilder = new JsObjectBuilder();
            ////rootBuilder.AddProperty(OptionName.Id, "root");
            ////rootBuilder.AddProperty(OptionName.Text, "root");
            ////rootBuilder.AddProperty("loaded", false);
            //rootBuilder.AddProperty(OptionName.Children, Render_NodesId, true);

            //string rootNodeScript = String.Format("var {0}=new Ext.tree.AsyncTreeNode({1});", Render_RootId, rootBuilder.ToString());
            //rootNodeScript += "\r\n";


            //OB.AddProperty("root", "new Ext.tree.AsyncTreeNode()", true);
            OB.AddProperty("rootVisible", false);

            #endregion

            #region renderScript

            //string renderScript = String.Empty;
            ////renderScript += "cmp.f_loadData();";
            //if (SelectedNodeIDArray.Length > 0)
            //{
            //    renderScript += "var model=cmp.getSelectionModel();";
            //    foreach (string nodeId in SelectedNodeIDArray)
            //    {
            //        renderScript += String.Format("model.select(cmp.getNodeById('{0}'),null,true);", nodeId);
            //    }
            //}

            ////renderScript = "function(cmp){window.setTimeout(function(){ cmp.f_loadData(); },1000);}";

            //OB.Listeners.AddProperty("render", JsHelper.GetFunction("cmp.f_loadData();", "cmp"), true);
            AddListener("render", "cmp.f_loadData();", "cmp");


            //OB.Listeners.AddProperty("viewready", JsHelper.GetFunction("cmp.f_selectNodes();", "cmp"), true);
            AddListener("viewready", "cmp.f_selectNodes();", "cmp");

            #endregion

            #region AddStartupScript
            //// 展开,折叠,点击,选中CheckBox事件处理函数，
            //// 因为这些函数会被几乎每个节点使用，所以提取出公共的方法来
            //scripts.AppendFormat("{0}=function(node){{F.util.addValueToHiddenField('{1}',node.id);}};", Render_NodeExpandScriptID, ExpandedNodesHiddenFieldID);
            //scripts.AppendFormat("{0}=function(node){{F.util.removeValueFromHiddenField('{1}',node.id);}};", Render_NodeCollapseScriptID, ExpandedNodesHiddenFieldID);
            //scripts.AppendFormat("{0}=function(node,checked){{if(checked){{F.util.addValueToHiddenField('{1}',node.id);}}else{{F.util.removeValueFromHiddenField('{1}',node.id);}}}};", Render_NodeCheckChangeScriptID, CheckedNodesHiddenFieldID);
            //scripts.AppendFormat("{0}=function(node){{Ext.get('{1}').dom.value=node.id;}};", Render_NodeClickScriptID, SelectedNodeHiddenFieldID);

            //scripts.AppendLine(hiddenFieldsScript);

            //OB.AddProperty("store", "Ext.create('Ext.data.TreeStore')", true);


            //StringBuilder sb = new StringBuilder();

            //scripts.AppendLine(loaderScript);
            string startupScript = String.Format("var {0}=Ext.create('Ext.tree.Panel',{1});", XID, OB);

            AddStartupScript(loaderScript + startupScript);

            #endregion
        }

        #endregion

        #region old code

        //private void ResolveTreeSelectModel(ref string selectModelScript)
        //{
        //    JsObjectBuilder selectOptionBuilder = new JsObjectBuilder();

        //    //// 选中行，不选中行
        //    //JsObjectBuilder selectListenersBuilder = new JsObjectBuilder();
        //    //selectListenersBuilder.AddProperty("selectionchange", String.Format("function(sm,node){{Ext.get('{0}').dom.value=node.id;}}", SelectedNodeHiddenFieldID), true);
        //    //selectListenersBuilder.AddProperty(OptionName.Scope, "box", true);

        //    //selectOptionBuilder.AddProperty("listeners", selectListenersBuilder);

        //    if (EnableMultiSelect)
        //    {
        //        selectModelScript = String.Format("var {0}=new Ext.tree.MultiSelectionModel({1});", Render_SelectModelID, selectOptionBuilder);
        //    }
        //    else
        //    {
        //        selectModelScript = String.Format("var {0}=new Ext.tree.DefaultSelectionModel({1});", Render_SelectModelID, selectOptionBuilder);
        //    }

        //}

        #endregion

        #region old code

        //internal JsArrayBuilder GetNodesJsArray()
        //{
        //    return GetNodesJsArray(Nodes);
        //}

        /*
        internal JsArrayBuilder GetNodesJsArray(TreeNodeCollection nodes, bool includeListeners)
        {
            JsArrayBuilder nodesBuilder = new JsArrayBuilder();
            foreach (TreeNode node in nodes)
            {
                JsObjectBuilder nodeBuilder = new JsObjectBuilder();

                #region options

                nodeBuilder.AddProperty("text", node.Text);
                nodeBuilder.AddProperty("leaf", node.Leaf);
                if (!String.IsNullOrEmpty(node.NodeID))
                {
                    nodeBuilder.AddProperty("id", node.NodeID);
                }
                nodeBuilder.AddProperty("disabled", !node.Enabled);
                if (node.EnableCheckBox)
                {
                    nodeBuilder.AddProperty("checked", node.Checked);
                }

                // Leaf doesn't has expanded property.
                if (!node.Leaf)
                {
                    nodeBuilder.AddProperty("expanded", node.Expanded);
                }

                #endregion

                #region href

                if (!String.IsNullOrEmpty(node.NavigateUrl))
                {
                    nodeBuilder.AddProperty("href", ResolveUrl(node.NavigateUrl));

                    if (!String.IsNullOrEmpty(node.Target))
                    {
                        nodeBuilder.AddProperty("hrefTarget", node.Target);
                    }
                }

                #endregion

                #region IconUrl

                if (!String.IsNullOrEmpty(node.IconUrl))
                {
                    nodeBuilder.AddProperty("icon", ResolveUrl(node.IconUrl));

                    #region old code
                    // 添加CSS样式，这种方法添加的图片位置靠上
                    // string className = AddStartupCSS(String.Format("{0}-button-icon-image", ClientID),
                    //    GetBackgroundStyleCss(ResolveUrl(IconUrl)));

                    //OB.AddProperty(OptionName.IconCls, className); 
                    #endregion
                }

                #endregion

                #region qtip

                if (!String.IsNullOrEmpty(node.ToolTip))
                {
                    nodeBuilder.AddProperty("qtip", node.ToolTip);
                }

                #endregion

                #region Listeners

                if (includeListeners)
                {
                    JsObjectBuilder listenersBuilder = new JsObjectBuilder();

                    #region old code

                    //// 展开时判断是否需要到后台取数据
                    ////listenersBuilder.AddProperty("beforeappend", String.Format("function(node,deep,anim){{\r\nif(!node.loaded){{alert(node.id);\r\n}}}}"), true);

                    //// 折叠/展开
                    ////listenersBuilder.AddProperty(OptionName.Expand, String.Format("function(node){{F.util.addValueToHiddenField('{0}',node.id);}}", ExpandedNodesHiddenFieldID), true);
                    ////listenersBuilder.AddProperty(OptionName.Collapse, String.Format("function(node){{F.util.removeValueFromHiddenField('{0}',node.id);}}", ExpandedNodesHiddenFieldID), true);
                    //listenersBuilder.AddProperty("expand", Render_NodeExpandScriptID, true);
                    //listenersBuilder.AddProperty("collapse", Render_NodeCollapseScriptID, true);


                    #endregion

                    #region 点击

                    // 如果禁用此节点，则不响应点击事件（不可选中）
                    // Added by sanshi.ustc#gmail.com 2009-8-24
                    if (!node.Enabled)
                    {
                        //clientScript += "e.stopEvent();";
                        listenersBuilder.AddProperty("beforeclick", "function(){return false;}", true);
                    }


                    if (String.IsNullOrEmpty(node.OnClientClick) && !node.EnablePostBack)
                    {
                        // 这段代码主要是为了减少代码体积，避免为每个节点添加重复的代码
                        listenersBuilder.AddProperty("click", Render_NodeClickScriptID, true);
                    }
                    else
                    {
                        // 点击的脚本
                        string clientScript = String.Empty;

                        // 用户自定义脚本
                        string clientClickScript = node.OnClientClick;
                        if (!String.IsNullOrEmpty(clientClickScript) && !clientClickScript.EndsWith(";"))
                        {
                            clientClickScript += ";";
                        }
                        clientScript += clientClickScript;


                        // 选中此项
                        //clientScript += String.Format("Ext.get('{0}').dom.value=node.id;", SelectedNodeHiddenFieldID);
                        clientScript += String.Format("{0}.apply(window, [node]);", Render_NodeClickScriptID);

                        // 回发脚本
                        if (node.EnablePostBack)
                        {
                            string paramStr = String.Format("Command${0}${1}${2}", node.NodeID, node.CommandName.Replace("'", "\""), node.CommandArgument.Replace("'", "\""));
                            clientScript += GetPostBackEventReference(paramStr);
                        }


                        listenersBuilder.AddProperty("click", String.Format("function(node,e){{{0}}}", clientScript), true);

                    }

                    #endregion

                    #region CheckBox - AutoPostback

                    // CheckBox选中
                    if (node.EnableCheckBox)
                    {
                        if (!node.AutoPostBack)
                        {
                            // 改变CheckBox，不需要自动回发，则将checkchange指向预定义的函数，这有助于减少代码量
                            //listenersBuilder.AddProperty("checkchange", String.Format("function(node,checked){{if(checked){{F.util.addValueToHiddenField('{0}',node.id);}}else{{F.util.removeValueFromHiddenField('{0}',node.id);}}}}", CheckedNodesHiddenFieldID), true);
                            listenersBuilder.AddProperty("checkchange", Render_NodeCheckChangeScriptID, true);
                        }
                        else
                        {
                            string checkchangeScript = String.Empty;

                            // 改变页面中隐藏字段的值
                            checkchangeScript += String.Format("{0}.apply(window, [node, checked]);", Render_NodeCheckChangeScriptID);

                            // 自动回发到服务器
                            checkchangeScript += String.Format("var args='Check${0}$'+checked;", node.NodeID);
                            checkchangeScript += GetPostBackEventReference("#CHECK#").Replace("'#CHECK#'", "args");

                            listenersBuilder.AddProperty("checkchange", String.Format("function(node,checked){{{0}}}", checkchangeScript), true);
                        }
                    }

                    #endregion

                    nodeBuilder.AddProperty("listeners", listenersBuilder);
                }

                #endregion

                #region children

                if (node.Nodes != null && node.Nodes.Count > 0)
                {
                    nodeBuilder.AddProperty("children", GetNodesJsArray(node.Nodes, includeListeners));
                }

                #endregion

                #region SingleClickExpand

                if (node.SingleClickExpand)
                {
                    nodeBuilder.AddProperty("singleClickExpand", true);
                }

                #endregion

                nodesBuilder.AddProperty(nodeBuilder);
            }

            return nodesBuilder;
        }

        */
        #endregion

        #endregion

        #region DataBind

        /// <summary>
        /// 绑定数据源
        /// </summary>
        /// <seealso cref="DataSource" />
        public override void DataBind()
        {
            // 重新绑定数据前清空选中的值
            SelectedNodeIDArray = null;

            // 清空所有节点
            Nodes.Clear();

            if (_dataSource != null)
            {
                if (DataSource is DataSet)
                {
                    DataSet ds = DataSource as DataSet;

                    DataBindToXml(ds.GetXml());
                }
                else if (DataSource is XmlDataSource)
                {
                    XmlDataSource xds = DataSource as XmlDataSource;
                    XmlDocument xdoc = xds.GetXmlDocument();

                    DataBindToXml(xdoc.OuterXml);
                }
                else if (DataSource is XmlDocument)
                {
                    XmlDocument xdoc = DataSource as XmlDocument;

                    DataBindToXml(xdoc.OuterXml);
                }
                //else if (this.DataSource is IHierarchicalDataSource)
                //{
                //    IHierarchicalDataSource oDS = (IHierarchicalDataSource)(this.DataSource);

                //    this.LoadFromHierarchy(oDS.GetHierarchicalView("").Select(), null);
                //}
                else
                {
                    throw new Exception("不支持的数据源类型：" + _dataSource.GetType().ToString());
                }
            }

            base.DataBind();
        }

        #endregion

        #region internal methods

        #region FixTreeNodes

        /// <summary>
        /// 如果一个节点不是叶子节点并且没有子节点，则应把它的Expanded设置为false，否则会引起页面死循环回发
        /// 同时处理 AutoLeafIdentification 属性
        /// </summary>
        internal void FixTreeNodes()
        {
            FixTreeNodes(Nodes);
        }

        private void FixTreeNodes(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                if (!node.Leaf)
                {
                    if (node.Nodes.Count == 0)
                    {
                        if (node.Expanded)
                        {
                            node.Expanded = false;
                        }
                        // If this node has no child and it's not a leaf node
                        // And AutoLeafIdentification is enabled, then make this node a leaf node.
                        if (AutoLeafIdentification)
                        {
                            node.Leaf = true;
                        }
                    }

                    if (node.Nodes.Count > 0)
                    {
                        FixTreeNodes(node.Nodes);
                    }

                }
            }
        }

        #endregion

        #region DataBindToXml

        private void DataBindToXml(string xml)
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml(xml);

            DataBindToXml(null, xdoc.DocumentElement.ChildNodes);
        }

        //private void DataBindToXml(XmlDocument xdoc)
        //{
        //    XmlNodeList nodes = xdoc.DocumentElement.ChildNodes;

        //    foreach (XmlNode node in nodes)
        //    {
        //        if (node.NodeType == XmlNodeType.Element)
        //        {
        //            TreeNode treeNode = new TreeNode();
        //            Nodes.Add(treeNode);

        //            LoadXmlNode(treeNode, node);


        //        }
        //    }
        //}

        private void DataBindToXml(TreeNode treeNode, XmlNodeList nodes)
        {
            foreach (XmlNode node in nodes)
            {
                // Only process Xml elements (ignore comments, etc)
                if (node.NodeType == XmlNodeType.Element)
                {
                    TreePreNodeEventArgs preArgs = new TreePreNodeEventArgs(node);

                    OnPreNodeDataBound(preArgs);

                    // 事件处理函数要求取消添加本节点
                    if (!preArgs.Cancelled)
                    {
                        TreeNode childNode = new TreeNode();
                        if (treeNode == null)
                        {
                            Nodes.Add(childNode);
                        }
                        else
                        {
                            treeNode.Nodes.Add(childNode);
                        }

                        childNode.ReadXmlAttributes(node.Attributes, this);

                        OnNodeDataBound(new TreeNodeEventArgs(childNode, node));


                        DataBindToXml(childNode, node.ChildNodes);
                    }
                }
            }
        }

        //private void LoadXmlNode(TreeNode treeNode, XmlNode xmlNode)
        //{
        //    treeNode.ReadXmlAttributes(xmlNode.Attributes, this);

        //    OnNodeDataBound(new TreeNodeEventArgs(treeNode, xmlNode));

        //    foreach (XmlNode node in xmlNode.ChildNodes)
        //    {
        //        // Only process Xml elements (ignore comments, etc)
        //        if (node.NodeType == XmlNodeType.Element)
        //        {
        //            TreePreNodeEventArgs preArgs = new TreePreNodeEventArgs(node);

        //            OnPreNodeDataBound(preArgs);

        //            // 事件处理函数要求取消添加本节点
        //            if (!preArgs.Cancelled)
        //            {
        //                TreeNode childNode = new TreeNode();
        //                treeNode.Nodes.Add(childNode);

        //                LoadXmlNode(childNode, node);
        //            }
        //        }
        //    }

        //}

        #endregion

        #region GetXmlAttributeMappingFrom

        internal string GetXmlAttributeMappingFrom(string toValue)
        {
            if (Mappings.Count > 0)
            {
                for (int i = 0; i < Mappings.Count; i++)
                {
                    XmlAttributeMapping mapping = Mappings[i];

                    if (mapping.To == toValue)
                    {
                        return mapping.From;
                    }
                }
            }

            return toValue;
        }

        internal string GetXmlAttributeMappingTo(string fromValue)
        {
            if (Mappings.Count > 0)
            {
                for (int i = 0; i < Mappings.Count; i++)
                {
                    XmlAttributeMapping mapping = Mappings[i];

                    if (mapping.From == fromValue)
                    {
                        return mapping.To;
                    }
                }
            }

            return fromValue;
        }

        #endregion


        #endregion

        #region IPostBackDataHandler Members

        /// <summary>
        /// 处理回发数据
        /// </summary>
        /// <param name="postDataKey">回发数据键</param>
        /// <param name="postCollection">回发数据集</param>
        /// <returns>回发数据是否改变</returns>
        public override bool LoadPostData(string postDataKey, System.Collections.Specialized.NameValueCollection postCollection)
        {
            base.LoadPostData(postDataKey, postCollection);

            // 选中的行
            string[] selectedNodeIDArray = StringUtil.GetStringListFromString(postCollection[SelectedNodeIDArrayHiddenFieldID], true).ToArray();
            if (!StringUtil.CompareStringArray(SelectedNodeIDArray, selectedNodeIDArray))
            {
                SelectedNodeIDArray = selectedNodeIDArray;
                FState.BackupPostDataProperty("SelectedNodeIDArray");
            }


            // Expanded Nodes
            string expandedNodesPostValue = postCollection[ExpandedNodesHiddenFieldID];
            List<string> expandedNodeListPostValue = StringUtil.GetStringListFromString(expandedNodesPostValue, true);
            // 1. Collapse some nodes that have been expanded.
            TreeNode[] originalExpandedNodes = GetExpandedNodes();
            foreach (TreeNode node in originalExpandedNodes)
            {
                if (!expandedNodeListPostValue.Contains(node.NodeID))
                {
                    node.Expanded = false;
                }
            }
            // 2. Expand the post nodes.
            foreach (string nodeID in expandedNodeListPostValue)
            {
                FindNode(nodeID).Expanded = true;
            }


            // Checked Nodes
            string checkedNodesPostValue = postCollection[CheckedNodesHiddenFieldID];
            List<string> checkedNodeListPostValue = StringUtil.GetStringListFromString(checkedNodesPostValue, true);
            // 1. Uncheck some nodes that have been checked.
            TreeNode[] originalCheckedNodes = GetCheckedNodes();
            foreach (TreeNode node in originalCheckedNodes)
            {
                if (!checkedNodeListPostValue.Contains(node.NodeID))
                {
                    node.Checked = false;
                }
            }
            // 2. Check the post nodes.
            foreach (string nodeID in checkedNodeListPostValue)
            {
                FindNode(nodeID).Checked = true;
            }

            FState.BackupPostDataProperty("F_Nodes");


            return false;
        }

        //public override void RaisePostDataChangedEvent()
        //{
        //    //OnCollapsedChanged(EventArgs.Empty);
        //}

        #endregion

        #region IPostBackEventHandler

        /// <summary>
        /// 处理回发事件
        /// </summary>
        /// <param name="eventArgument">事件参数</param>
        public override void RaisePostBackEvent(string eventArgument)
        {
            base.RaisePostBackEvent(eventArgument);

            if (eventArgument.StartsWith("Command$"))
            {
                string[] commandArgs = eventArgument.Split('$');
                if (commandArgs.Length == 4)
                {
                    OnNodeCommand(new TreeCommandEventArgs(FindNode(commandArgs[1]), commandArgs[2], commandArgs[3]));
                }
            }
            else if (eventArgument.StartsWith("LazyLoad$"))
            {
                string[] commandArgs = eventArgument.Split('$');
                if (commandArgs.Length == 2)
                {
                    OnNodeLazyLoad(new TreeNodeEventArgs(FindNode(commandArgs[1])));
                }
            }
            else if (eventArgument.StartsWith("Expand$"))
            {
                string[] commandArgs = eventArgument.Split('$');
                if (commandArgs.Length == 2)
                {
                    OnNodeExpand(new TreeNodeEventArgs(FindNode(commandArgs[1])));
                }
            }
            else if (eventArgument.StartsWith("Collapse$"))
            {
                string[] commandArgs = eventArgument.Split('$');
                if (commandArgs.Length == 2)
                {
                    OnNodeCollapse(new TreeNodeEventArgs(FindNode(commandArgs[1])));
                }
            }
            else if (eventArgument.StartsWith("Check$"))
            {
                string[] commandArgs = eventArgument.Split('$');
                if (commandArgs.Length == 3)
                {
                    OnNodeCheck(new TreeCheckEventArgs(FindNode(commandArgs[1]), Convert.ToBoolean(commandArgs[2])));
                }
            }

        }

        #endregion

        #region OnNodeDataBound

        private static readonly object _nodeDataBoundHandlerKey = new object();

        /// <summary>
        /// 节点绑定后事件
        /// </summary>
        [Category(CategoryName.ACTION)]
        [Description("节点绑定后事件")]
        public event EventHandler<TreeNodeEventArgs> NodeDataBound
        {
            add
            {
                Events.AddHandler(_nodeDataBoundHandlerKey, value);
            }
            remove
            {
                Events.RemoveHandler(_nodeDataBoundHandlerKey, value);
            }
        }

        /// <summary>
        /// 触发节点绑定后事件
        /// </summary>
        /// <param name="e">事件参数</param>
        protected virtual void OnNodeDataBound(TreeNodeEventArgs e)
        {
            EventHandler<TreeNodeEventArgs> handler = Events[_nodeDataBoundHandlerKey] as EventHandler<TreeNodeEventArgs>;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion

        #region OnPreNodeDataBound

        private static readonly object _preNodeDataBoundHandlerKey = new object();

        /// <summary>
        /// 节点预绑定事件
        /// </summary>
        [Category(CategoryName.ACTION)]
        [Description("节点预绑定事件")]
        public event EventHandler<TreePreNodeEventArgs> PreNodeDataBound
        {
            add
            {
                Events.AddHandler(_preNodeDataBoundHandlerKey, value);
            }
            remove
            {
                Events.RemoveHandler(_preNodeDataBoundHandlerKey, value);
            }
        }

        /// <summary>
        /// 触发节点预绑定事件
        /// </summary>
        /// <param name="e">事件参数</param>
        protected virtual void OnPreNodeDataBound(TreePreNodeEventArgs e)
        {
            EventHandler<TreePreNodeEventArgs> handler = Events[_preNodeDataBoundHandlerKey] as EventHandler<TreePreNodeEventArgs>;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion

        #region OnNodeCheck

        private static readonly object _nodeCheckHandlerKey = new object();

        /// <summary>
        /// 节点选中事件
        /// </summary>
        [Category(CategoryName.ACTION)]
        [Description("节点选中事件")]
        public event EventHandler<TreeCheckEventArgs> NodeCheck
        {
            add
            {
                Events.AddHandler(_nodeCheckHandlerKey, value);
            }
            remove
            {
                Events.RemoveHandler(_nodeCheckHandlerKey, value);
            }
        }

        /// <summary>
        /// 触发节点选中事件
        /// </summary>
        /// <param name="e">事件参数</param>
        protected virtual void OnNodeCheck(TreeCheckEventArgs e)
        {
            EventHandler<TreeCheckEventArgs> handler = Events[_nodeCheckHandlerKey] as EventHandler<TreeCheckEventArgs>;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion

        #region OnNodeCommand

        private static readonly object _nodeCommandHandlerKey = new object();

        /// <summary>
        /// 节点点击事件
        /// </summary>
        [Category(CategoryName.ACTION)]
        [Description("节点点击事件")]
        public event EventHandler<TreeCommandEventArgs> NodeCommand
        {
            add
            {
                Events.AddHandler(_nodeCommandHandlerKey, value);
            }
            remove
            {
                Events.RemoveHandler(_nodeCommandHandlerKey, value);
            }
        }

        /// <summary>
        /// 触发节点点击事件
        /// </summary>
        /// <param name="e">事件参数</param>
        protected virtual void OnNodeCommand(TreeCommandEventArgs e)
        {
            EventHandler<TreeCommandEventArgs> handler = Events[_nodeCommandHandlerKey] as EventHandler<TreeCommandEventArgs>;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion

        #region OnNodeExpand

        private static readonly object _nodeExpandHandlerKey = new object();

        /// <summary>
        /// 节点展开事件
        /// </summary>
        [Category(CategoryName.ACTION)]
        [Description("节点展开事件")]
        public event EventHandler<TreeNodeEventArgs> NodeExpand
        {
            add
            {
                Events.AddHandler(_nodeExpandHandlerKey, value);
            }
            remove
            {
                Events.RemoveHandler(_nodeExpandHandlerKey, value);
            }
        }

        /// <summary>
        /// 触发节点展开事件
        /// </summary>
        /// <param name="e">事件参数</param>
        protected virtual void OnNodeExpand(TreeNodeEventArgs e)
        {
            EventHandler<TreeNodeEventArgs> handler = Events[_nodeExpandHandlerKey] as EventHandler<TreeNodeEventArgs>;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion

        #region OnNodeCollapse

        private static readonly object _nodeCollapseHandlerKey = new object();

        /// <summary>
        /// 节点展开事件
        /// </summary>
        [Category(CategoryName.ACTION)]
        [Description("节点展开事件")]
        public event EventHandler<TreeNodeEventArgs> NodeCollapse
        {
            add
            {
                Events.AddHandler(_nodeCollapseHandlerKey, value);
            }
            remove
            {
                Events.RemoveHandler(_nodeCollapseHandlerKey, value);
            }
        }

        /// <summary>
        /// 触发节点展开事件
        /// </summary>
        /// <param name="e">事件参数</param>
        protected virtual void OnNodeCollapse(TreeNodeEventArgs e)
        {
            EventHandler<TreeNodeEventArgs> handler = Events[_nodeCollapseHandlerKey] as EventHandler<TreeNodeEventArgs>;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion

        #region OnNodeLazyLoad

        private static readonly object _nodeLazyLoadHandlerKey = new object();

        /// <summary>
        /// 节点延迟加载事件
        /// </summary>
        [Category(CategoryName.ACTION)]
        [Description("节点延迟加载事件")]
        public event EventHandler<TreeNodeEventArgs> NodeLazyLoad
        {
            add
            {
                Events.AddHandler(_nodeLazyLoadHandlerKey, value);
            }
            remove
            {
                Events.RemoveHandler(_nodeLazyLoadHandlerKey, value);
            }
        }

        /// <summary>
        /// 触发节点延迟加载事件
        /// </summary>
        /// <param name="e">事件参数</param>
        protected virtual void OnNodeLazyLoad(TreeNodeEventArgs e)
        {
            EventHandler<TreeNodeEventArgs> handler = Events[_nodeLazyLoadHandlerKey] as EventHandler<TreeNodeEventArgs>;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion

        #region Public Methods

        #region GetExpandedNodes

        /// <summary>
        /// 获取所有展开节点的ID数组
        /// </summary>
        /// <returns>节点的ID数组</returns>
        public string[] GetExpandedNodeIDs()
        {
            return GetExpandedNodeIDs(Nodes);
        }

        /// <summary>
        /// 获取指定节点集合中所有展开节点的ID数组
        /// </summary>
        /// <param name="nodes">指定的节点集合</param>
        /// <returns>节点的ID数组</returns>
        public string[] GetExpandedNodeIDs(TreeNodeCollection nodes)
        {
            List<string> expandedNodeIDs = new List<string>();
            TreeNode[] expandedNodes = GetExpandedNodes(nodes);
            foreach (TreeNode node in expandedNodes)
            {
                expandedNodeIDs.Add(node.NodeID);
            }
            return expandedNodeIDs.ToArray();
        }

        /// <summary>
        /// 获取所有展开节点的数组
        /// </summary>
        /// <returns>节点的数组</returns>
        public TreeNode[] GetExpandedNodes()
        {
            return GetExpandedNodes(Nodes);
        }

        /// <summary>
        /// 获取指定节点集合中所有展开节点的数组
        /// </summary>
        /// <param name="nodes">指定的节点集合</param>
        /// <returns>节点的数组</returns>
        public TreeNode[] GetExpandedNodes(TreeNodeCollection nodes)
        {
            List<TreeNode> returnNodes = new List<TreeNode>();
            ResolveExpandedNodes(returnNodes, nodes);
            return returnNodes.ToArray();
        }

        private void ResolveExpandedNodes(List<TreeNode> returnNodes, TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                if (!node.Leaf && node.Expanded)
                {
                    returnNodes.Add(node);
                }

                if (node.Nodes != null && node.Nodes.Count > 0)
                {
                    ResolveExpandedNodes(returnNodes, node.Nodes);
                }
            }
        }

        #endregion

        #region CollapseAllNodes/ExpandAllNodes

        /// <summary>
        /// 折叠所有节点
        /// </summary>
        public void CollapseAllNodes()
        {
            CollapseAllNodes(Nodes);
        }

        /// <summary>
        /// 折叠指定节点集合中的所有节点
        /// </summary>
        /// <param name="nodes">指定的节点集合</param>
        public void CollapseAllNodes(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                if (!node.Leaf)
                {
                    node.Expanded = false;

                    if (node.Nodes != null && node.Nodes.Count > 0)
                    {
                        CollapseAllNodes(node.Nodes);
                    }
                }
            }
        }

        /// <summary>
        /// 展开所有节点
        /// </summary>
        public void ExpandAllNodes()
        {
            ExpandAllNodes(Nodes);
        }

        /// <summary>
        /// 展开指定节点集合中的所有节点
        /// </summary>
        /// <param name="nodes">指定的节点集合</param>
        public void ExpandAllNodes(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                if (!node.Leaf)
                {
                    node.Expanded = true;

                    if (node.Nodes != null && node.Nodes.Count > 0)
                    {
                        ExpandAllNodes(node.Nodes);
                    }
                }
            }
        }

        #endregion

        #region GetCheckedNodes

        /// <summary>
        /// 获取选中节点的ID数组
        /// </summary>
        /// <returns>节点的ID数组</returns>
        public string[] GetCheckedNodeIDs()
        {
            return GetCheckedNodeIDs(Nodes);
        }

        /// <summary>
        /// 获取指定节点集合中选中节点的ID数组
        /// </summary>
        /// <param name="nodes">指定的节点集合</param>
        /// <returns>节点的ID数组</returns>
        public string[] GetCheckedNodeIDs(TreeNodeCollection nodes)
        {
            List<string> checkedNodeIDs = new List<string>();
            TreeNode[] checkedNodes = GetCheckedNodes(nodes);
            foreach (TreeNode node in checkedNodes)
            {
                checkedNodeIDs.Add(node.NodeID);
            }
            return checkedNodeIDs.ToArray();
        }

        /// <summary>
        /// 获取选中节点的数组
        /// </summary>
        /// <returns>节点的数组</returns>
        public TreeNode[] GetCheckedNodes()
        {
            return GetCheckedNodes(Nodes);
        }

        /// <summary>
        /// 获取指定节点集合中选中节点的数组
        /// </summary>
        /// <param name="nodes">指定的节点集合</param>
        /// <returns>节点的数组</returns>
        public TreeNode[] GetCheckedNodes(TreeNodeCollection nodes)
        {
            List<TreeNode> rtList = new List<TreeNode>();
            ResolveCheckedNodes(rtList, nodes);
            return rtList.ToArray();
        }


        private void ResolveCheckedNodes(List<TreeNode> rtList, TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.EnableCheckBox && node.Checked)
                {
                    rtList.Add(node);
                }

                if (node.Nodes != null && node.Nodes.Count > 0)
                {
                    ResolveCheckedNodes(rtList, node.Nodes);
                }
            }
        }

        #endregion

        #region CheckAllNodes UncheckAllNodes

        /// <summary>
        /// 选中所有节点的复选框
        /// </summary>
        public void CheckAllNodes()
        {
            CheckAllNodes(Nodes);
        }

        /// <summary>
        /// 选中指定节点的复选框
        /// </summary>
        /// <param name="nodes">指定的节点集合</param>
        public void CheckAllNodes(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.EnableCheckBox)
                {
                    node.Checked = true;
                }

                if (!node.Leaf && node.Nodes != null && node.Nodes.Count > 0)
                {
                    CheckAllNodes(node.Nodes);
                }

            }
        }

        /// <summary>
        /// 反选所有节点的复选框
        /// </summary>
        public void UncheckAllNodes()
        {
            UncheckAllNodes(Nodes);
        }

        /// <summary>
        /// 反选指定节点的复选框
        /// </summary>
        /// <param name="nodes">指定的节点集合</param>
        public void UncheckAllNodes(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.EnableCheckBox)
                {
                    node.Checked = false;
                }

                if (!node.Leaf && node.Nodes != null && node.Nodes.Count > 0)
                {
                    UncheckAllNodes(node.Nodes);
                }
            }
        }

        #endregion

        #region FindNode

        /// <summary>
        /// 查找树节点
        /// </summary>
        /// <param name="nodeId">节点ID</param>
        /// <returns>树节点</returns>
        public TreeNode FindNode(string nodeId)
        {
            return FindNode(nodeId, Nodes);
        }

        /// <summary>
        /// 在指定的节点集合中查找树节点
        /// </summary>
        /// <param name="nodeId">节点ID</param>
        /// <param name="nodes">指定的节点集合</param>
        /// <returns>树节点</returns>
        public TreeNode FindNode(string nodeId, TreeNodeCollection nodes)
        {
            if (nodes.Count == 0)
            {
                return null;
            }

            foreach (TreeNode node in nodes)
            {
                if (node.NodeID == nodeId)
                {
                    return node;
                }

                if (node.Nodes.Count > 0)
                {
                    TreeNode childNode = FindNode(nodeId, node.Nodes);

                    if (childNode != null)
                    {
                        return childNode;
                    }
                }
            }

            return null;
        }

        #endregion

        #region GetExpandAllNodesReference GetCollapseAllNodesReference

        /// <summary>
        /// 获取展开全部节点的的客户端脚本
        /// </summary>
        /// <returns>客户端脚本</returns>
        public string GetExpandAllNodesReference()
        {
            return String.Format("{0}.expandAll();", ScriptID);
        }

        /// <summary>
        /// 获取折叠全部节点的的客户端脚本
        /// </summary>
        /// <returns>客户端脚本</returns>
        public string GetCollapseAllNodesReference()
        {
            return String.Format("{0}.collapseAll();", ScriptID);
        }

        #endregion

        #region oldcode

        //public void ClearNodes()
        //{
        //    CheckedNodeIDArray = null;
        //    SelectedNodeID = null;
        //    ExpandedNodeIDArray = null;
        //    Nodes.Clear();
        //}

        //public TreeNode AddNode()
        //{
        //    TreeNode node = new TreeNode();
        //    Nodes.Add(node);

        //    return node;
        //}

        #endregion

        #endregion

        #region oldcode

        //[Description("Ajax回发时强制更新此控件全部内容")]
        //internal override bool AjaxForceCompleteUpdate
        //{
        //    get
        //    {
        //        return true;
        //    }
        //}

        #endregion

        #region oldcode

        //private int _nextNodeIndex = 0;

        ///// <summary>
        ///// 获取下一个节点的ID，为那些没有设置NodeId的节点自定设置NodeId
        ///// </summary>
        ///// <returns></returns>
        //internal string GetNextNodeId()
        //{
        //    return String.Format("{0}_n{1}", ClientJavascriptID, _nextNodeIndex++);
        //}

        #endregion

        #region oldcode

        //protected override object SaveViewState()
        //{
        //    object[] states = new object[] { 
        //        base.SaveViewState(), 
        //        ((IStateManager)Nodes).SaveViewState(),
        //        ((IStateManager)Mappings).SaveViewState()
        //    };

        //    return states;
        //}

        //protected override void LoadViewState(object savedState)
        //{
        //    if (savedState != null)
        //    {
        //        object[] states = (object[])savedState;

        //        base.LoadViewState(states[0]);

        //        ((IStateManager)Nodes).LoadViewState(states[1]);

        //        ((IStateManager)Mappings).LoadViewState(states[2]);
        //    }
        //}

        //protected override void TrackViewState()
        //{
        //    base.TrackViewState();

        //    ((IStateManager)Nodes).TrackViewState();

        //    ((IStateManager)Mappings).TrackViewState();
        //}

        #endregion

        #region oldcode

        ///// <summary>
        ///// 展开的行
        ///// </summary>
        //[DefaultValue(null)]
        //[Description("展开的行")]
        //[Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public string[] ExpandedNodeIDArray
        //{
        //    get
        //    {
        //        //// We don't need to save this state in ViewState, because TreeNode has it's state persistance.
        //        //object obj = BoxState["ExpandedNodeIDArray"];

        //        //if (obj == null)
        //        //{
        //        //    obj = BoxState["ExpandedNodeIDArray"] = GetExpandedNodeIDArray();
        //        //}

        //        //return (string[])obj;
        //        return GetExpandedNodeIDArray();
        //    }
        //    set
        //    {
        //        if (value != null)
        //        {
        //            List<string> strList = new List<string>(value);

        //            // 折叠所有节点，只展开value中的节点
        //            CollapseAllNodes();
        //            foreach (string nodeId in strList)
        //            {
        //                FindNode(nodeId).Expanded = true;
        //            }

        //            BoxState["ExpandedNodeIDArray"] = strList.ToArray();
        //        }
        //        else
        //        {
        //            BoxState["ExpandedNodeIDArray"] = new string[0] { };
        //        }
        //    }
        //}

        ///// <summary>
        ///// 选中的行
        ///// </summary>
        //[DefaultValue(null)]
        //[Description("选中的行")]
        //[Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public string[] CheckedNodeIDArray
        //{
        //    get
        //    {
        //        object obj = BoxState["CheckedNodeIDArray"];

        //        if (obj == null)
        //        {
        //            obj = BoxState["CheckedNodeIDArray"] = GetCheckedNodeIDArray();
        //        }

        //        return (string[])obj;
        //    }
        //    set
        //    {
        //        if (value != null)
        //        {
        //            List<string> strList = new List<string>(value);

        //            // 不选中所有节点，只选中value中的节点
        //            UncheckAllNodes();
        //            foreach (string nodeId in strList)
        //            {
        //                TreeNode node = FindNode(nodeId);
        //                if (node.EnableCheckBox)
        //                {
        //                    node.Checked = true;
        //                }
        //            }

        //            BoxState["CheckedNodeIDArray"] = strList.ToArray();
        //        }
        //        else
        //        {
        //            BoxState["CheckedNodeIDArray"] = new string[0] { };
        //        }
        //    }
        //}

        #endregion
    }
}
