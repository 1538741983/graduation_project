
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    ControlBase.cs
 * CreatedOn:   2008-04-07
 * CreatedBy:   30372245@qq.com
 * 
 * 
 * Description：
 *      ->
 *   
 * History：
 *       
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


using System.Reflection;
using System.Configuration;
using System.IO;
using System.Text.RegularExpressions;
using System.Security.Permissions;
using System.Collections;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO.Compression;
using System.ComponentModel.Design;


namespace FineUI
{
    /// <summary>
    /// 控件基类（抽象类）
    /// </summary>
    [AspNetHostingPermission(SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Minimal)]
    [AspNetHostingPermission(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal)]
    [ParseChildren(true)]
    [PersistChildren(false)]
    public abstract class ControlBase : Control, INamingContainer
    {
        #region Constructor

        /// <summary>
        /// 构造函数
        /// </summary>
        public ControlBase()
        {

            _state = new FState(this);

            AddServerAjaxProperties("Hidden", "Enabled");
            AddClientAjaxProperties();

        }

        private FState _state = null;

        /// <summary>
        /// FState用来在服务器和客户端之间持久化控件状态。
        /// </summary>
        protected FState FState
        {
            get
            {
                return _state;
            }
            set
            {
                _state = value;
            }
        }

        /// <summary>
        /// 添加服务器AJAX属性
        /// </summary>
        /// <param name="props">属性列表</param>
        protected void AddServerAjaxProperties(params string[] props)
        {
            foreach (string prop in props)
            {
                if (!_serverAjaxProperties.Contains(prop))
                {
                    _serverAjaxProperties.Add(prop);
                }
                if (!_ajaxProperties.Contains(prop))
                {
                    _ajaxProperties.Add(prop);
                }
            }

        }

        /// <summary>
        /// 添加客户端AJAX属性
        /// </summary>
        /// <param name="props">属性列表</param>
        protected void AddClientAjaxProperties(params string[] props)
        {
            foreach (string prop in props)
            {
                if (!_clientAjaxProperties.Contains(prop))
                {
                    _clientAjaxProperties.Add(prop);
                }
                if (!_ajaxProperties.Contains(prop))
                {
                    _ajaxProperties.Add(prop);
                }
            }

        }

        /// <summary>
        /// 添加Gzip压缩属性
        /// </summary>
        /// <param name="props">属性列表</param>
        protected void AddGzippedAjaxProperties(params string[] props)
        {
            foreach (string prop in props)
            {
                if (!_gzippedAjaxProperties.Contains(prop))
                {
                    _gzippedAjaxProperties.Add(prop);
                }
            }
        }


        private List<string> _ajaxProperties = new List<string>();

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal List<string> AjaxProperties
        {
            get { return _ajaxProperties; }
            set { _ajaxProperties = value; }
        }

        private List<string> _serverAjaxProperties = new List<string>();

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal List<string> ServerAjaxProperties
        {
            get { return _serverAjaxProperties; }
            set { _serverAjaxProperties = value; }
        }

        private List<string> _clientAjaxProperties = new List<string>();

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal List<string> ClientAjaxProperties
        {
            get { return _clientAjaxProperties; }
            set { _clientAjaxProperties = value; }
        }

        private List<string> _gzippedAjaxProperties = new List<string>();

        /// <summary>
        /// 目前Gzippped的属性支持JObject/JArray/String类型
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal List<string> GzippedAjaxProperties
        {
            get { return _gzippedAjaxProperties; }
            set { _gzippedAjaxProperties = value; }
        }

        /// <summary>
        /// 标示是否初始化完成
        /// </summary>
        internal bool InitialComplete = false;

        #endregion

        #region Internal Properties

        //private ControlBase _virtualParent;

        ///// <summary>
        ///// 虚拟的父控件，为了保证生产JS脚本的顺序（比如在处理按钮的MenuID属性时使用）
        ///// </summary>
        //[Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //internal ControlBase VirtualParent
        //{
        //    get { return _virtualParent; }
        //    set { _virtualParent = value; }
        //}


        private string _xid = String.Empty;

        /// <summary>
        /// JavaScript中使用ID（比如：x0, x1）
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal string XID
        {
            get
            {
                if (String.IsNullOrEmpty(_xid))
                {
                    _xid = ClientJavascriptIDManager.Instance.GetNextJavascriptID();
                }
                return _xid;
            }
        }

        /// <summary>
        /// 获取控件实例的JavaScript代码（比如：F('RegionPanel1_Button1')）
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal string ScriptID
        {
            get
            {
                return String.Format("F('{0}')", ClientID);
            }
        }


        private bool _renderWrapperNode = true;

        /// <summary>
        /// 是否向页面输出控件的外部容器（默认：true）
        /// 否：只创建Javascript对象而不添加到页面中
        /// 是：创建Javascript对象，并添加到页面中，页面上添加占位符
        /// </summary>
        internal virtual bool RenderWrapperNode
        {
            get
            {
                return _renderWrapperNode;
            }
            set
            {
                _renderWrapperNode = value;
            }
        }


        private bool _wrapperNodeInlineBlock = true;

        internal virtual bool WrapperNodeInlineBlock
        {
            get
            {
                return _wrapperNodeInlineBlock;
            }
            set
            {
                _wrapperNodeInlineBlock = value;
            }
        }



        private OptionBuilder _optionBuilder;

        /// <summary>
        /// 参数对象创建器
        /// </summary>
        internal OptionBuilder OB
        {
            get
            {
                if (_optionBuilder == null)
                {
                    _optionBuilder = new OptionBuilder();
                }
                return _optionBuilder;
            }
        }



        private JObject _postBackState = null;

        /// <summary>
        /// 从 HTTP 请求中恢复当前控件的状态
        /// 比如当前请求 Request.Form["F_STATE"] = {"btnClientClick":{"OnClientClick":"F.util.alert(\"This is an alert dialog\",\"\",Ext.MessageBox.INFO,'');"},"btnPressed":{"Pressed":false}}
        /// 并且当前控件的 ClientID 是 "btnPressed"，则返回值为 JObject 对象 {"Pressed":false}
        /// </summary>
        internal JObject PostBackState
        {
            get
            {
                if (_postBackState == null)
                {
                    JObject states = ResourceManager.Instance.PostBackStates;

                    _postBackState = states.Value<JObject>(ClientID);
                    if (_postBackState == null)
                    {
                        _postBackState = new JObject();
                    }

                    // 启用FState压缩
                    if (EnableFStateCompress)
                    {
                        foreach (string property in _gzippedAjaxProperties)
                        {
                            string gzPropertyName = property + "_GZ";
                            JToken gzToken = _postBackState[gzPropertyName];
                            if (gzToken != null)
                            {
                                string gzippedString = gzToken.Value<string>();
                                if (!String.IsNullOrEmpty(gzippedString))
                                {
                                    // 从压缩后的Gzip字符串恢复属性的值（可能为JObject/JArray/String）
                                    PropertyInfo info = this.GetType().GetProperty(property, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                                    if (info != null)
                                    {
                                        string ungzippedString = StringUtil.Ungzip(gzippedString);
                                        if (info.PropertyType == typeof(String))
                                        {
                                            _postBackState[property] = ungzippedString;
                                        }
                                        else if (info.PropertyType == typeof(JObject))
                                        {
                                            _postBackState[property] = JObject.Parse(ungzippedString);
                                        }
                                        else if (info.PropertyType == typeof(JArray))
                                        {
                                            _postBackState[property] = JArray.Parse(ungzippedString);
                                        }
                                    }
                                }

                                // 从回发的PostBackState中删除GZ属性，已经还原了压缩之前的属性
                                _postBackState.Remove(gzPropertyName);
                            }
                        }
                    }
                }
                return _postBackState;
            }
        }


        private string _collectionGroupName;

        /// <summary>
        /// 此控件所在的集合分组，只在BaseCollection中使用
        /// </summary>
        internal string CollectionGroupName
        {
            get { return _collectionGroupName; }
            set { _collectionGroupName = value; }
        }

        #endregion

        #region ReadOnly Properties

        /// <summary>
        /// 不支持此属性（禁用控件默认的ViewState）
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override bool EnableViewState
        {
            get
            {
                return false;
            }
        }


        /// <summary>
        /// 控件的客户端ID（比如：RegionPanel1_Button1）
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override string ClientID
        {
            get
            {
                return base.ClientID;
            }
        }


        // ID是设计的时候所指定的ID。
        // ClientID是当这个控件生成到客户端页面时候，需要在客户端访问时候用的。
        // UniqueID是当需要参与服务端回传的时候用的。
        // 备注：当控件是子控件的时候（例如在用户控件中的Button），ClientID在HTML页面中是作为控件的ID属性，
        // UniqueID是作为控件的Name属性，如果不是子控件，那么ClientID和UniqueID是相同的

        /// <summary>
        /// 控件外部容器的客户端ID（比如：Button1_wrapper）
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string WrapperID
        {
            get
            {
                return String.Format("{0}_wrapper", ClientID);
            }
        }


        /// <summary>
        /// 产品名称
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ProductName
        {
            get
            {
                return GlobalConfig.ProductName;
            }
        }

        /// <summary>
        /// 产品版本
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual string ProductVersion
        {
            get
            {
                return GlobalConfig.ProductVersion;
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// HTML标签属性
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public JObject Attributes
        {
            get
            {
                object obj = FState["Attributes"];
                if (obj == null)
                {
                    FState["Attributes"] = new JObject();
                    obj = FState["Attributes"];
                }
                return (JObject)obj;
            }
            set
            {
                FState["Attributes"] = value;
            }
        }


        /// <summary>
        /// 控件ID
        /// </summary>
        [Category(CategoryName.BASEOPTIONS)]
        [Description("控件ID")]
        public override string ID
        {
            get
            {
                return base.ID;
            }
            set
            {
                base.ID = value;
            }
        }


        /// <summary>
        /// [AJAX属性]是否可用
        /// </summary>
        [Category(CategoryName.BASEOPTIONS)]
        [DefaultValue(true)]
        [Description("[AJAX属性]是否可用")]
        public virtual bool Enabled
        {
            get
            {
                object obj = FState["Enabled"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                FState["Enabled"] = value;
            }
        }

        /// <summary>
        /// 指示控件是否被渲染出来（显示隐藏控件，请使用Hidden属性）
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool RenderToClient
        {
            get
            {
                return base.Visible;
            }
            set
            {
                base.Visible = value;
            }
        }


        /// <summary>
        /// 只读属性，指示控件是否被渲染出来（显示隐藏控件，请使用Hidden属性）
        /// </summary>
        [Category(CategoryName.BASEOPTIONS)]
        [DefaultValue(true)]
        [Description("只读属性，指示控件是否被渲染出来（显示隐藏控件，请使用Hidden属性）")]
        public override bool Visible
        {
            get
            {
                return base.Visible;
            }
        }


        /// <summary>
        /// [AJAX属性]是否隐藏控件
        /// </summary>
        [Category(CategoryName.BASEOPTIONS)]
        [DefaultValue(false)]
        [Description("[AJAX属性]是否隐藏控件")]
        public virtual bool Hidden
        {
            get
            {
                object obj = FState["Hidden"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                FState["Hidden"] = value;
            }
        }

        /// <summary>
        /// 隐藏模式
        /// </summary>
        [Category(CategoryName.BASEOPTIONS)]
        [DefaultValue(HideMode.Display)]
        [Description("隐藏的模式")]
        public virtual HideMode HideMode
        {
            get
            {
                object obj = FState["HideMode"];
                return obj == null ? HideMode.Display : (HideMode)obj;
            }
            set
            {
                FState["HideMode"] = value;
            }
        }


        /// <summary>
        /// 是否启用AJAX
        /// </summary>
        [Category(CategoryName.BASEOPTIONS)]
        [DefaultValue(true)]
        [Description("是否启用AJAX")]
        public virtual bool EnableAjax
        {
            get
            {
                object obj = FState["EnableAjax"];
                if (obj == null)
                {
                    if (DesignMode)
                    {
                        return true;
                    }
                    else
                    {
                        return PageManager.Instance.EnableAjax;
                    }
                }
                return (bool)obj;
            }
            set
            {
                FState["EnableAjax"] = value;
            }
        }


        /// <summary>
        /// 是否启用FState压缩（默认为false）
        /// </summary>
        [Category(CategoryName.BASEOPTIONS)]
        [DefaultValue(false)]
        [Description("是否启用FState压缩（默认为false）")]
        public virtual bool EnableFStateCompress
        {
            get
            {
                object obj = FState["EnableFStateCompress"];
                if (obj == null)
                {
                    if (DesignMode)
                    {
                        return false;
                    }
                    else
                    {
                        return PageManager.Instance.EnableFStateCompress;
                    }
                }
                return (bool)obj;
            }
            set
            {
                FState["EnableFStateCompress"] = value;
            }
        }


        /// <summary>
        /// 是否启用Ajax正在加载提示
        /// </summary>
        [Category(CategoryName.BASEOPTIONS)]
        [DefaultValue(true)]
        [Description("是否启用Ajax正在加载提示")]
        public bool EnableAjaxLoading
        {
            get
            {
                object obj = FState["EnableAjaxLoading"];
                if (obj == null)
                {
                    if (DesignMode)
                    {
                        return true;
                    }
                    else
                    {
                        return PageManager.Instance.EnableAjaxLoading;
                    }
                }
                return (bool)obj;
            }
            set
            {
                FState["EnableAjaxLoading"] = value;
            }
        }


        /// <summary>
        /// Ajax正在加载提示的类型
        /// </summary>
        [Category(CategoryName.BASEOPTIONS)]
        [DefaultValue(AjaxLoadingType.Default)]
        [Description("Ajax正在加载提示的类型")]
        public AjaxLoadingType AjaxLoadingType
        {
            get
            {
                object obj = FState["AjaxLoadingType"];
                if (obj == null)
                {
                    if (DesignMode)
                    {
                        return AjaxLoadingType.Default;
                    }
                    else
                    {
                        return PageManager.Instance.AjaxLoadingType;
                    }
                }
                return (AjaxLoadingType)obj;
            }
            set
            {
                FState["AjaxLoadingType"] = value;
            }
        }


        /// <summary>
        /// 是否处于FineUI的AJAX回发过程
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsFineUIAjaxPostBack
        {
            get
            {
                return ResourceManager.Instance.IsFineUIAjaxPostBack;
            }
        }


        #endregion

        #region Listeners

        private ListenerCollection _listeners;

        /// <summary>
        /// 客户端事件列表
        /// </summary>
        [Description("客户端事件列表")]
        [Category(CategoryName.OPTIONS)]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Editor(typeof(CollectionEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public virtual ListenerCollection Listeners
        {
            get
            {
                if (_listeners == null)
                {
                    _listeners = new ListenerCollection();
                }
                return _listeners;
            }
        }

        #endregion

        #region OnInit

        /// <summary>
        /// 页面初始化事件
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            if (!DesignMode)
            {
                // 确保所有子控件都已经被创建
                EnsureChildControls();

                // 如果控件没有设置 ID，则自动创建一个（比如：ct100）
                base.EnsureID();

                // 确保ResourceManager实例的Page和当前页面一致
                ResourceManager.EnsureResourceManagerInstance(Page);

                // 如果在Page_Init之后创建的控件，则不会触发InitComplete，就需要立即调用。那么就需要判断当前页面是否已经初始化完成
                if (ResourceManager.Instance.IsPageInitCompleted)
                {
                    Page_InitComplete(null, null);
                }
                else
                {
                    // 页面初始化完毕后，再进行FState的相关操作（类似LoadViewState阶段，但LoadViewState并非每个控件都会经历，所以只能注册页面的InitComplete）
                    Page.InitComplete += Page_InitComplete;
                }
            }
        }

        private void Page_InitComplete(object sender, EventArgs e)
        {
            // 如果是页面回发，则恢复FState
            if (Page.IsPostBack)
            {
                RecoverPropertiesFromJObject(PostBackState);
            }


            // 向子控件公开方法，可以在备份初始化属性之前修改属性值
            OnInitControl();

            // 备份初始化属性值
            FState.BackupInitializedProperties();

            // 标识初始化完成
            InitialComplete = true;
    

        }


        /// <summary>
        /// 在备份初始化属性之前修改属性值
        /// 
        /// 此时对控件的属性做修改是安全的：
        ///  1. 页面第一次加载时，运行到这里 ASPX 上面的标签已经初始化完毕
        ///  2. 页面回发时（包括正常回发或者AJAX回发），此时请求表单中 F_STATE 已经恢复完毕
        /// </summary>
        protected virtual void OnInitControl()
        {

        }

        #endregion

        #region RenderBeginTag RenderEndTag

        /// <summary>
        /// 重载 RenderControl，为了向子控件公开 RenderBeginTag 和 RenderEndTag 两个方法
        /// </summary>
        /// <param name="writer">服务器控件输出流</param>
        public override void RenderControl(HtmlTextWriter writer)
        {
            RenderBeginTag(writer);

            base.RenderControl(writer);

            RenderEndTag(writer);
        }


        /// <summary>
        /// 渲染控件的开始标签
        /// </summary>
        /// <param name="writer">输出流</param>
        protected virtual void RenderBeginTag(HtmlTextWriter writer)
        {
            if (RenderWrapperNode)
            {
                if (WrapperNodeInlineBlock)
                {
                    writer.Write(String.Format("<div id=\"{0}\" class=\"f-inline-block\">", WrapperID));
                }
                else
                {
                    writer.Write(String.Format("<div id=\"{0}\">", WrapperID));
                }
            }
        }

        /// <summary>
        /// 渲染控件的结束标签
        /// </summary>
        /// <param name="writer">输出流</param>
        protected virtual void RenderEndTag(HtmlTextWriter writer)
        {
            if (RenderWrapperNode)
            {
                writer.Write("</div>");
            }
        }



        //protected override void Render(HtmlTextWriter writer)
        //{
        //    base.Render(writer);

        //    if (Page != null)
        //    {
        //        Page.VerifyRenderingInServerForm(this);
        //    }
        //}

        #endregion

        #region OnPreRender

        /// <summary>
        /// 渲染 HTML 之前调用
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            // 在页面第一次加载,正常的 PostBack以及 AJAX 都需要执行下面代码 
            if (this is IPostBackDataHandler)
            {
                // 如果当前控件实现了 IPostBackDataHandler 接口，则需要调用 RegisterRequiresPostBack，
                // 以便在 ControlState 中保存这个控件的 ClientID，然后下次回发时会由此调用此控件的 LoadPostData 函数
                // 主要用来处理客户端改变控件属性的情况
                Page.RegisterRequiresPostBack(this);
            }


            OnBothPreRender();

            // 计算被修改的属性列表
            FState.CalculateModifiedProperties();

            if (IsFineUIAjaxPostBack)
            {
                OnAjaxPreRender();

                if (_ajaxScriptBuilder.Length > 0)
                {
                    ResourceManager.Instance.AjaxScriptList.Add(_ajaxScriptBuilder.ToString());

                    // 添加在 JavaScript 中使用的控件变量的短格式（比如 x0=F('RegionPanel1_Button1')）
                    ResourceManager.Instance.AddAjaxShortName(ClientID, XID);
                }
            }
            else
            {
                // 页面第一次加载和正常的回发两种情况
                OnFirstPreRender();
            }
        }

        /// <summary>
        /// 渲染 HTML 之前调用（计算被修改属性列表之前调用，可以在此修改属性）
        /// </summary>
        protected virtual void OnBothPreRender()
        {

        }

        /// <summary>
        /// 渲染 HTML 之前调用（AJAX回发）
        /// </summary>
        protected virtual void OnAjaxPreRender()
        {
            StringBuilder sb = new StringBuilder();
            #region old code
            // There are new properties need to be persisted during the next postback.
            // Re-write the "f_props" property of the component instance.
            //if (FState.TotalModifiedProperties.Count > PostBackState.Count)
            //{
            //    sb.AppendFormat("{0}.f_props={1};", XID, new JArray(FState.TotalModifiedProperties));
            //}

            //foreach (string property in FState.ModifiedProperties)
            //{
            //    string propertyValue = String.Empty;

            //    PropertyInfo info = this.GetType().GetProperty(property);
            //    if (info.PropertyType == typeof(String))
            //    {
            //        propertyValue = JsHelper.Enquote(info.GetValue(this, null).ToString());
            //    }
            //    else if (info.PropertyType == typeof(Boolean))
            //    {
            //        // "true", "false"
            //        propertyValue = info.GetValue(this, null).ToString().ToLower();
            //    }
            //    else if (info.PropertyType.BaseType == typeof(Enum))
            //    {
            //        // ConfirmTarget -> "Self", "Parent", "Top"
            //        propertyValue = JsHelper.Enquote(StringUtil.GetEnumName((Enum)info.GetValue(this, null)));
            //    }

            //    sb.AppendFormat("{0}.f_p_{1}={2};", XID, property, propertyValue);
            //} 
            #endregion

            List<string> currentModifiedProperties = FState.ModifiedProperties;
            if (currentModifiedProperties.Count > 0)
            {
                // 更新当前控件的 F_STATE 状态
                sb.AppendFormat("F.f_state({0},{1});", XID, ConvertPropertiesToJObject(currentModifiedProperties).ToString(Formatting.None));
            }

            sb.Append(GetHiddenPropertyChangedScript());

            sb.Append(GetEnabledPropertyChangedScript());

            AddAjaxScript(sb);
        }

        /// <summary>
        /// 渲染 HTML 之前调用（页面第一次加载或者普通回发）
        /// </summary>
        protected virtual void OnFirstPreRender()
        {
            #region old code
            //foreach (string property in FState.TotalModifiedProperties)
            //{
            //    object propertyValue = null;

            //    PropertyInfo info = this.GetType().GetProperty(property);
            //    if (info.PropertyType == typeof(String))
            //    {
            //        propertyValue = info.GetValue(this, null).ToString();
            //    }
            //    else if (info.PropertyType == typeof(Boolean))
            //    {
            //        propertyValue = Convert.ToBoolean(info.GetValue(this, null));
            //    }
            //    else if (info.PropertyType.BaseType == typeof(Enum))
            //    {
            //        propertyValue = StringUtil.GetEnumName((Enum)info.GetValue(this, null));
            //    }

            //    OB.AddProperty("f_p_" + property, propertyValue);

            //}

            //// These properties has been modified in the past postbacks.
            //// Every FineUI control should has this property.
            //OB.AddProperty("f_props", new JArray(FState.TotalModifiedProperties), true);

            #endregion

            List<string> totalModifiedProperties = FState.GetTotalModifiedProperties();
            if (totalModifiedProperties.Count > 0)
            {
                string xstate = ConvertPropertiesToJObject(totalModifiedProperties).ToString(Formatting.None);
                AddStartupScript(String.Format("var {0}={1};", GetFStateScriptID(), xstate));
                OB.AddProperty("f_state", GetFStateScriptID(), true);
            }
            else
            {
                OB.AddProperty("f_state", "{}", true);
            }



            // Every component need this property.
            OB.AddProperty("id", ClientID);

            if (RenderWrapperNode)
            {
                OB.AddProperty("renderTo", WrapperID);
            }

            if (Hidden)
            {
                OB.AddProperty("hidden", true);
            }
            if (HideMode != HideMode.Display)
            {
                OB.AddProperty("hideMode", HideModeName.GetName(HideMode));
            }

            if (!Enabled)
            {
                OB.AddProperty("disabled", true);
            }

			foreach (Listener listener in Listeners)
            {
                OB.Listeners.AddProperty(listener.Event, listener.Handler, true);
            }
			
            #region old code

            //if (AjaxPropertyChanged("Hidden", Hidden))
            //{
            //    HiddenPropertyChanged();
            //}

            //// 渲染到客户端时的JavascriptId
            //OB.AddProperty("id", ClientJavascriptID);

            // 不需要这样做，
            //// 判断父控件是否用户控件（UserControl）
            //if (Parent is UserControl || Parent is ContentPlaceHolder)
            //{
            //    if (!ResourceManagerInstance.IsStartupScriptExist(Parent as Control))
            //    {
            //        AddStartupScript(Parent, String.Empty);
            //    }
            //} 

            #endregion
        }


        /// <summary>
        /// 获取FState的JS变量
        /// </summary>
        /// <returns></returns>
        protected string GetFStateScriptID()
        {
            return String.Format("{0}_state", XID);
        }

        #endregion

        #region PropertyModified

        /// <summary>
        /// 回发过程中此属性是否被改变
        /// 如果是客户端可以改变的属性，仅在服务器端改变时才返回 true，
        /// （如果仅是客户端改变，则返回 false，因为客户端改变的属性不需要再输出相应的 JavaScript 脚本）
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        protected bool PropertyModified(string propertyName)
        {
            bool modified = FState.ModifiedProperties.Contains(propertyName);
            if (modified)
            {
                if (ClientAjaxProperties.Contains(propertyName))
                {
                    if (FState.ClientPropertiesModifiedInServer.Contains(propertyName))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 回发过程中这些属性是否被改变
        /// 只要任何属性被改变，就返回 true
        /// </summary>
        /// <param name="propertyNames"></param>
        /// <returns></returns>
        protected bool PropertyModified(params string[] propertyNames)
        {
            foreach (string property in propertyNames)
            {
                if (PropertyModified(property))
                {
                    return true;
                }
            }
            return false;
        }

        //protected bool ClientPropertyModifiedInServer(string propertyName)
        //{
        //    return FState.ClientPropertiesModifiedInServer.Contains(propertyName);
        //}


        #region old code
        ///// <summary>
        ///// Whether the property has been changed in the past postbacks.
        ///// </summary>
        ///// <param name="propertyName"></param>
        ///// <returns></returns>
        //protected bool TotalPropertyModified(string propertyName)
        //{
        //    return FState.TotalModifiedProperties.Contains(propertyName);
        //}

        ///// <summary>
        ///// Get client value of a property in the postback state(F_STATE).
        ///// </summary>
        ///// <param name="propertyName"></param>
        ///// <returns></returns>
        //protected object GetPostBackClientValue(string propertyName)
        //{
        //    return PostBackState["X_" + propertyName];
        //} 
        #endregion

        #endregion

        #region RecoverPropertiesFromFState ConvertPropertiesToFState

        /// <summary>
        /// 从JObject恢复控件的属性
        /// </summary>
        /// <param name="state">对象属性的JObject形式</param>
        public void RecoverPropertiesFromJObject(JObject state)
        {
            foreach (JProperty propertyObj in state.Properties())
            {
                string property = propertyObj.Name;
                PropertyInfo info = this.GetType().GetProperty(property, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                if (info != null)
                {
                    if (info.PropertyType.BaseType == typeof(Enum))
                    {
                        info.SetValue(this, Enum.Parse(info.PropertyType, state.Value<string>(property)), null);
                    }
                    else if (info.PropertyType == typeof(Unit))
                    {
                        info.SetValue(this, Unit.Parse(state.Value<string>(property)), null);
                    }
                    else if (info.PropertyType.BaseType == typeof(Array))
                    {
                        if (info.PropertyType == typeof(Int32[]))
                        {
                            info.SetValue(this, JSONUtil.IntArrayFromJArray(state.Value<JArray>(property)), null);
                        }
                        else if (info.PropertyType == typeof(String[]))
                        {
                            info.SetValue(this, JSONUtil.StringArrayFromJArray(state.Value<JArray>(property)), null);
                        }
                    }
                    else
                    {
                        JToken jtoken = state.Property(property).Value;
                        if (jtoken is JContainer)
                        {
                            info.SetValue(this, jtoken, null);
                        }
                        else
                        {
                            object propertyValue = ((JValue)jtoken).Value;

                            // 类型“System.Int64”的对象无法转换为类型“System.Int32”。
                            // 类型“System.Int64”的对象无法转换为类型“System.Nullable`1[System.Int32]”。
                            // 类型“System.Int64”的对象无法转换为类型“System.Int16”。
                            // 类型“System.Int64”的对象无法转换为类型“System.Nullable`1[System.Int16]”。
                            if (propertyValue != null && propertyValue.GetType() == typeof(Int64))
                            {
                                if (info.PropertyType == typeof(Int32) || info.PropertyType == typeof(Int32?))
                                {
                                    propertyValue = Convert.ToInt32(propertyValue);
                                }

                                if (info.PropertyType == typeof(Int16) || info.PropertyType == typeof(Int16?))
                                {
                                    propertyValue = Convert.ToInt16(propertyValue);
                                }

                                // 类型“System.Int64”的对象无法转换为类型“System.Nullable`1[System.Double]”。
                                // 注意：“2.0”会被解析为Int64，而“2.1”会被解析为Double，所以有可能会进入这个分支
                                if (info.PropertyType == typeof(Double) || info.PropertyType == typeof(Double?))
                                {
                                    propertyValue = Convert.ToDouble(propertyValue);
                                }

                                if (info.PropertyType == typeof(float) || info.PropertyType == typeof(float?))
                                {
                                    propertyValue = Convert.ToSingle(propertyValue);
                                }
                            }

                            info.SetValue(this, propertyValue, null);
                        }

                    }
                }

            }
        }


        /// <summary>
        /// 将控件的属性列表转化为JObject对象
        /// </summary>
        /// <param name="propertyList">属性列表</param>
        /// <returns>属性列表的JObject形式</returns>
        public JObject ConvertPropertiesToJObject(List<string> propertyList)
        {
            JObject jo = new JObject();
            foreach (string property in propertyList)
            {
                // 如果包含压缩后的属性，则忽略
                if (property.EndsWith("_GZ"))
                {
                    continue;
                }

                string propertyStringValueUsedInGzipped = String.Empty;
                bool propertyGzippped = false;
                if (EnableFStateCompress)
                {
                    propertyGzippped = _gzippedAjaxProperties.Contains(property);
                }

                object propertyValue = GetPropertyJSONValue(property);


                if (propertyValue is JToken)
                {
                    JToken tokenValue = propertyValue as JToken;
                    jo.Add(property, tokenValue);


                    // 此属性启用Gzip压缩，则先计算字符串值
                    if (propertyGzippped)
                    {
                        propertyStringValueUsedInGzipped = tokenValue.ToString(Newtonsoft.Json.Formatting.None);
                    }

                }
                else
                {
                    if (propertyValue is String)
                    {
                        // The browser HTML parser will see the </script> within the string and it will interpret it as the end of the script element.
                        // http://www.xiaoxiaozi.com/2010/02/24/1708/
                        // http://stackoverflow.com/questions/1659749/script-tag-in-javascript-string
                        string propertyValueStr = propertyValue.ToString().Replace("</script>", @"<\/script>");
                        jo.Add(property, propertyValueStr);

                        // 此属性启用Gzip压缩，则先计算字符串值
                        if (propertyGzippped)
                        {
                            propertyStringValueUsedInGzipped = propertyValueStr;
                        }

                    }
                    else if (propertyValue is Unit)
                    {
                        int intValue = (Int32)((Unit)propertyValue).Value;
                        jo.Add(property, intValue);
                    }
                    else
                    {
                        jo.Add(property, new JValue(propertyValue));
                    }
                }



                if (propertyGzippped && !String.IsNullOrEmpty(propertyStringValueUsedInGzipped))
                {
                    string propertyGzippedValue = String.Empty;

                    // 1. 小于500个字符，不启用Gzipped压缩
                    if (propertyStringValueUsedInGzipped.Length > 500)
                    {
                        propertyGzippedValue = StringUtil.Gzip(propertyStringValueUsedInGzipped);

                        // 2. 压缩效果太差（不到原始大小的50%），则不启用Gzipped压缩
                        if (propertyGzippedValue.Length > (propertyStringValueUsedInGzipped.Length / 2))
                        {
                            propertyGzippedValue = String.Empty;
                        }
                    }


                    // 无论 propertyGzippedValue 是否为空字符串，都要输出来覆盖上次的结果（因为并非每一次的GZipped都有值）
                    jo.Add(property + "_GZ", propertyGzippedValue);

                }


            }
            return jo; //.ToString(Formatting.None);
        }


        // 获取属性的 JSON 对象值
        internal object GetPropertyJSONValue(string prop)
        {
            object propValue = null;

            PropertyInfo info = this.GetType().GetProperty(prop, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (info != null)
            {
                propValue = info.GetValue(this, null);

                if (info.PropertyType.BaseType == typeof(Enum))
                {
                    propValue = StringUtil.EnumToName((Enum)propValue);
                }
                else if (info.PropertyType.BaseType == typeof(Array))
                {
                    if (propValue == null)
                    {
                        propValue = new JArray();
                    }
                    else
                    {
                        propValue = new JArray((Array)propValue);
                    }
                }
            }

            return propValue;
        }

        #endregion

        #region AddAjaxScript

        private StringBuilder _ajaxScriptBuilder = new StringBuilder();

        /// <summary>
        /// AJAX 回发阶段，添加反映属性改变的 JavaScript 脚本
        /// </summary>
        /// <param name="script"></param>
        internal void AddAjaxScript(string script)
        {
            if (!String.IsNullOrEmpty(script))
            {
                _ajaxScriptBuilder.Append(script);
            }
        }

        /// <summary>
        /// AJAX 回发阶段，添加反映属性改变的 JavaScript 脚本
        /// </summary>
        /// <param name="sb"></param>
        internal void AddAjaxScript(StringBuilder sb)
        {
            if (sb.Length > 0)
            {
                _ajaxScriptBuilder.Append(sb);
            }
        }


        #endregion

        #region AddStartupCSS

        /// <summary>
        /// 添加CSS样式
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="cssContent">CSS内容</param>
        protected void AddStartupCSS(string key, string cssContent)
        {
            if (!IsFineUIAjaxPostBack)
            {
                ResourceManager.Instance.AddStartupCSS(key, cssContent);
            }
        }

        /// <summary>
        /// 删除CSS样式
        /// </summary>
        /// <param name="key">键</param>
        protected void RemoveStartupCSS(string key)
        {
            if (!IsFineUIAjaxPostBack)
            {
                ResourceManager.Instance.RemoveStartupCSS(key);
            }
        }

        #endregion

        #region AddStartupScript AddStartupAbsoluteScript

        /// <summary>
        /// 向页面添加控件无关脚本
        /// </summary>
        /// <param name="script">客户端脚本</param>
        protected void AddStartupAbsoluteScript(string script)
        {
            if (!IsFineUIAjaxPostBack)
            {
                ResourceManager.Instance.AddAbsoluteStartupScript(script);
            }
        }

        /// <summary>
        /// 向页面添加控件无关脚本
        /// </summary>
        /// <param name="script">客户端脚本</param>
        /// <param name="level">脚本层级</param>
        protected void AddStartupAbsoluteScript(string script, int level)
        {
            if (!IsFineUIAjaxPostBack)
            {
                ResourceManager.Instance.AddAbsoluteStartupScript(script, level);
            }
        }

        /// <summary>
        /// 添加控件相关脚本
        /// </summary>
        /// <param name="scriptContent">客户端脚本</param>
        protected void AddStartupScript(string scriptContent)
        {
            if (!IsFineUIAjaxPostBack)
            {
                // 合并在基类中注册的脚本，然后整体注册
                if (ResourceManager.Instance.IsStartupScriptExist(this))
                {
                    scriptContent = ResourceManager.Instance.GetStartupScript(this).Script + scriptContent;
                    ResourceManager.Instance.RemoveStartupScript(this);
                }

                if (Visible)
                {
                    ResourceManager.Instance.AddStartupScript(this, scriptContent);
                }
            }

            #region old code

            //if (!IsFineUIAjaxPostBack)
            //{
            //    // 如果是页面第一次加载，或者不是FineUIAjax（比如是普通的PostBack或者是Asp.netAjax回发）
            //    AddStartupScript(this, scriptContent);

            //    if (AjaxForceCompleteUpdate)
            //    {
            //        BoxState["__AllScript__"] = scriptContent.GetHashCode().ToString("X8");
            //    }
            //    //SaveAjaxProperty("AllScript", scriptContent, true);
            //}
            //else
            //{
            //    if (AjaxForceCompleteUpdate)
            //    {
            //        // 如果强制更新控件的整个内容，并且内容变化了，则更新
            //        if (BoxState["__AllScript__"].ToString() != scriptContent.GetHashCode().ToString("X8"))
            //        {
            //            AjaxCompleteUpdateControl(scriptContent);
            //        }
            //    }
            //    else
            //    {
            //        AjaxPartialUpdateControl();
            //    }
            //} 

            #endregion
        }

        #endregion

        #region GetHiddenPropertyChangedScript GetEnabledPropertyChangedScript

        /// <summary>
        /// 获取 Hidden 属性改变的 JavaScript 脚本
        /// 有些控件可能需要特别的逻辑，因此这里为虚函数（比如 Window 控件、Tab 控件）
        /// </summary>
        /// <returns>客户端脚本</returns>
        protected virtual string GetHiddenPropertyChangedScript()
        {
            if (PropertyModified("Hidden"))
            {
                return String.Format("{0}.f_setVisible();", XID);
            }
            return String.Empty;
        }

        /// <summary>
        /// 获取 Enabled 属性改变的 JavaScript 脚本
        /// 有些控件可能需要特别的逻辑，因此这里为虚函数
        /// </summary>
        /// <returns>客户端脚本</returns>
        protected virtual string GetEnabledPropertyChangedScript()
        {
            if (PropertyModified("Enabled"))
            {
                return String.Format("{0}.f_setDisabled();", XID);
            }
            return String.Empty;
        }

        #endregion

        #region GetPostBackEventReference

        /// <summary>
        /// 获取回发页面的客户端脚本（比如：__doPostBack('btnChangeEnable','');)
        /// </summary>
        /// <returns>客户端脚本</returns>
        public string GetPostBackEventReference()
        {
            return GetPostBackEventReference(String.Empty);
        }

        /// <summary>
        /// 获取回发页面的客户端脚本（比如：__doPostBack('btnChangeEnable','true');)
        /// </summary>
        /// <param name="eventArgument">事件参数</param>
        /// <returns>客户端脚本</returns>
        public string GetPostBackEventReference(string eventArgument)
        {
            return GetPostBackEventReference(eventArgument, EnableAjax);
        }

        /// <summary>
        /// 获取回发页面的客户端脚本（比如：__doPostBack('btnChangeEnable','true');)
        /// </summary>
        /// <param name="eventArgument">事件参数</param>
        /// <param name="enableAjax">是否启用AJAX</param>
        /// <returns>客户端脚本</returns>
        public string GetPostBackEventReference(string eventArgument, bool enableAjax)
        {
            StringBuilder sb = new StringBuilder();

            if (enableAjax != PageManager.Instance.EnableAjax)
            {
                sb.AppendFormat("F.controlEnableAjax={0};", enableAjax ? "true" : "false");
            }


            if (EnableAjaxLoading != PageManager.Instance.EnableAjaxLoading)
            {
                sb.AppendFormat("F.controlEnableAjaxLoading={0};", EnableAjaxLoading ? "true" : "false");
            }

            if (AjaxLoadingType != PageManager.Instance.AjaxLoadingType)
            {
                sb.AppendFormat("F.controlAjaxLoadingType='{0}';", AjaxLoadingTypeName.GetName(AjaxLoadingType));
            }

            sb.Append(Page.ClientScript.GetPostBackEventReference(this, eventArgument));
            sb.Append(";");

            return sb.ToString();
        }

        // This is the same as UniqueID
        // Get PostBackID that can be used in postback event.
        //internal string GetPostBackID()
        //{
        //    string postbackscript = Page.ClientScript.GetPostBackEventReference(this, String.Empty);
        //    // __doPostBack('regionPanel$leftRegion$Button1','')
        //    int start = postbackscript.IndexOf("'"),
        //        end = postbackscript.LastIndexOf("','')");
        //    return postbackscript.Substring(start + 1, end - start - 1);
        //}

        #endregion

        #region GetSetHiddenFieldValueScript

        /// <summary>
        /// 获取修改隐藏表单字段值的脚本（如果此隐藏表单字段不存在，则添加）
        /// </summary>
        /// <param name="id">隐藏字段ID</param>
        /// <param name="value">隐藏字段值</param>
        /// <returns></returns>
        protected string GetSetHiddenFieldValueScript(string id, string value)
        {
            return String.Format("F.setHidden('{0}','{1}');", id, value);
        }


        /// <summary>
        /// 获取修改隐藏表单字段值的脚本（如果此隐藏表单字段不存在，则添加）
        /// </summary>
        /// <param name="id">隐藏字段ID</param>
        /// <param name="value">隐藏字段值</param>
        /// <param name="windowObj">隐藏字段所在的页面对象（JavaScript实例window）</param>
        /// <returns>客户端脚本</returns>
        protected string GetSetHiddenFieldValueScript(string id, string value, string windowObj)
        {
            if (String.IsNullOrEmpty(windowObj) || windowObj == "window")
            {
                return GetSetHiddenFieldValueScript(id, value);
            }
            return String.Format("{2}.F.setHidden('{0}','{1}');", id, value, windowObj);
        }

        #endregion

        #region ResolveAttribuites

        /// <summary>
        /// 添加Attributes中的属性值
        /// </summary>
        /// <param name="htmlBuilder">HtmlNodeBuilder对象</param>
        protected void ResolveAttribuites(HtmlNodeBuilder htmlBuilder)
        {
            foreach (JProperty propertyObj in Attributes.Properties())
            {
                string propName = propertyObj.Name;
                string propValue = Attributes.Value<string>(propName);
                htmlBuilder.SetProperty(propName, propValue);
            }
        }

        #endregion

        #region protected GetListenerFunction AddListener

        /// <summary>
        /// 获取客户端事件处理函数
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="jsContent"></param>
        /// <param name="funParameters"></param>
        /// <returns></returns>
        protected string GetListenerFunction(string eventName, string jsContent, params string[] funParameters)
        {
            var handler = Listeners.GetEventHandler(eventName);
            if (!String.IsNullOrEmpty(handler))
            {
                jsContent += String.Format("return {0}.apply(this,arguments);", handler);
            }

            return JsHelper.GetFunction(jsContent, funParameters);
        }

        /// <summary>
        /// 向 OB 中添加客户端事件处理函数
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="jsContent"></param>
        /// <param name="funParameters"></param>
        protected void AddListener(string eventName, string jsContent, params string[] funParameters)
        {
            OB.Listeners.AddProperty(eventName, GetListenerFunction(eventName, jsContent, funParameters), true);
        }

        #endregion

        #region oldcode

        //// 获取客户端可用的图标 URL 地址
        //protected string GetResolvedIconUrl(Icon icon, string iconUrl)
        //{
        //    /*
        //    string url = iconUrl;
        //    if (String.IsNullOrEmpty(url))
        //    {
        //        if (icon != Icon.None)
        //        {
        //            url = IconHelper.GetIconUrl(icon);
        //        }
        //    }

        //    return ResolveUrl(url);
        //     * */
        //    return IconHelper.GetResolvedIconUrl(icon, iconUrl);
        //}

        #endregion

        #region oldcode


        //private Dictionary<string, string> _xProperties = new Dictionary<string, string>();

        //internal void SaveXProperty(string key, string value)
        //{
        //    _xProperties[key] = value;
        //}

        //internal bool XPropertyModified(string key, string currentValue)
        //{
        //    if (_xProperties.ContainsKey(key))
        //    {
        //        string lastValue = _xProperties[key];
        //        if (lastValue != currentValue)
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}




        //private Dictionary<string, string> _ajaxProperties__ = new Dictionary<string, string>();

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="key"></param>
        ///// <param name="objSource"></param>
        ///// <returns></returns>
        //internal bool AjaxPropertyChanged(string key, object objSource)
        //{
        //    // 如果不是FineUIAjax回发，则不执行此逻辑
        //    if (!IsFineUIAjaxPostBack)
        //    {
        //        return false;
        //    }

        //    if (!_ajaxProperties__.ContainsKey(key))
        //    {
        //        // 对于在Page_Load之后动态添加的控件，肯定会运行到这里，对这些属性不做处理
        //        // 所以动态添加控件，一定要在 Page_Init 中进行
        //        // throw new Exception(String.Format("Please set the property [{0}] in Page_OnPreLoad.", key));
        //        return false;
        //    }

        //    string objStr = String.Empty;
        //    if (objSource != null)
        //    {
        //        objStr = objSource.ToString();
        //    }

        //    if (_ajaxProperties__[key] == objStr)
        //    {
        //        return false;
        //    }
        //    return true;
        //}

        //internal void SaveAjaxProperty(string key, object objSource)
        //{
        //    string saveValue = String.Empty;
        //    if (objSource != null)
        //    {
        //        saveValue = objSource.ToString();
        //    }

        //    _ajaxProperties__[key] = saveValue;
        //}




        #endregion

        #region oldcode

        ///// <summary>
        ///// 如果不是FineUIAjax回发，则保存值的改变到ViewState，同时返回false
        ///// 如果是FineUIAjax回发，则判断此key存储在ViewState的值是否改变，如果改变则返回true
        ///// </summary>
        ///// <param name="key"></param>
        ///// <param name="objSource"></param>
        ///// <returns></returns>
        //internal bool AjaxPropertyChanged(string key, object objSource)
        //{
        //    string hashCode = CreateAjaxPropertyValue(objSource);

        //    // 如果不是FineUIAjax回发，则保存值的改变到ViewState，同时返回false
        //    if (!IsFineUIAjaxPostBack)
        //    {
        //        SaveAjaxProperty(key, hashCode);
        //        return false;
        //    }

        //    if (GetAjaxProperty(key) != hashCode)
        //    {
        //        SaveAjaxProperty(key, hashCode);
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}


        ///// <summary>
        ///// 保存HashCode到ViewState
        ///// </summary>
        ///// <param name="key"></param>
        ///// <param name="hashCode"></param>
        ///// <param name="source"></param>
        //internal void SaveAjaxProperty(string key, object hashCode, bool source)
        //{
        //    string hashCodeStr = String.Empty;
        //    if (hashCode != null)
        //    {
        //        hashCodeStr = hashCode.ToString();
        //        if (source)
        //        {
        //            hashCodeStr = CreateAjaxPropertyValue(hashCode);
        //        }
        //    }

        //    SaveAjaxProperty(key, hashCodeStr);
        //}

        ///// <summary>
        ///// 生成需要保存的Ajax属性的值
        ///// 对于Boolean型的，直接返回"0"或者"1"
        ///// 对于其他类型，返回其ToString后的HashCode
        ///// </summary>
        ///// <param name="strSource"></param>
        ///// <returns></returns>
        //private string CreateAjaxPropertyValue(object objSource)
        //{
        //    if (objSource is Boolean)
        //    {
        //        return (Boolean)objSource ? "1" : "0";
        //    }

        //    string strSource = objSource.ToString();
        //    return String.IsNullOrEmpty(strSource) ? "" : strSource.GetHashCode().ToString("X8");
        //}

        ///// <summary>
        ///// 保存HashCode到ViewState
        ///// </summary>
        ///// <param name="key"></param>
        ///// <param name="strSource"></param>
        //private void SaveAjaxProperty(string key, string hashCode)
        //{
        //    key = String.Format("{0}", key);
        //    ViewState[key] = hashCode;
        //}


        ///// <summary>
        ///// 从ViewState读取HashCode
        ///// </summary>
        ///// <param name="key"></param>
        ///// <returns></returns>
        //private string GetAjaxProperty(string key)
        //{
        //    key = String.Format("{0}", key);

        //    object obj = ViewState[key];
        //    return obj == null ? String.Empty : (string)obj;
        //}

        #endregion

        #region oldcode

        //private void RenderAjaxUpdateScript()
        //{
        //    if (_ajaxUpdateScriptList.Count > 0)
        //    {
        //        StringBuilder sb = new StringBuilder();
        //        foreach (string script in _ajaxUpdateScriptList)
        //        {
        //            sb.Append(script);
        //        }

        //        AddStartupScript(this, sb.ToString());
        //    }
        //}


        ///// <summary>
        ///// 全部更新不适用于所有控件
        ///// </summary>
        ///// <param name="scriptContent"></param>
        //private void AjaxCompleteUpdateControl(string scriptContent)
        //{
        //    if (this.Controls.Count > 0)
        //    {
        //        // 如果是容器控件，则目前不支持Ajax更新
        //        // TODO
        //    }
        //    else
        //    {

        //        #region 重要说明

        //        // 这是一个复杂的过程，有两种情况需要考虑：
        //        // 1.直接渲染的控件，先销毁，在重新渲染
        //        // 2.依赖父容器渲染的的控件，首先取得父容器，本控件在父容器的位置，然后从父容器中销毁此控件，创建新的控件，将新的控件添加到删除的位置，父容器重新布局。
        //        // 第二种情况的整体结构如下
        //        ////// 1.取得父容器
        //        ////// var owner=X.i3.ownerCt;
        //        ////// 2.本控件在父容器的位置
        //        ////// var insertIndex=owner.items.indexOf(X.i3);
        //        ////// 3.从父容器中销毁此控件
        //        ////// owner.remove(X.i3);
        //        ////// 4.创建新的控件
        //        ////// X.i3=new Ext.form.TextField({id:"SimpleForm1_tbxUserName",stateful:false,fieldLabel:"用户名2",labelSeparator:"&nbsp;<span style=\"color:red;\"\>*</span\>",anchor:"-25px",name:"SimpleForm1$tbxUserName",disabled:false,allowBlank:false,listeners:{change:function(){box_pageStateChange();}}});
        //        ////// 5.将新的控件添加到删除的位置
        //        ////// owner.insert(insertIndex,X.i3);
        //        ////// 6.父容器重新布局
        //        ////// owner.doLayout();


        //        #endregion

        //        string startupScript = String.Empty;

        //        // 如果是Panel，并且不使用布局，则需要把内容先移出来，否则会在Panel被重建时被清空
        //        if (this is PanelBase && (this as PanelBase).RenderChildrenAsContent)
        //        {
        //            startupScript += String.Format("Ext.get(X.{0}.contentEl).hide();Ext.get(X.{0}.contentEl).appendTo(document.forms[0]);", ClientJavascriptID);
        //        }

        //        // 更新Javascript对象和UI重新布局
        //        startupScript += String.Format("F.ajax.updateObject(X.{0},{1},{2});",
        //            ClientJavascriptID,
        //            String.Format("function(){{{0}}}", scriptContent),
        //            RenderWrapperDiv.ToString().ToLower());

        //        AddStartupScript(this, startupScript);
        //    }
        //}


        //[Category(CategoryName.BASEOPTIONS)]
        //[DefaultValue(false)]
        //[Description("Ajax回发时强制更新此控件全部内容")]
        //internal virtual bool AjaxForceCompleteUpdate
        //{
        //    get
        //    {
        //        object obj = BoxState["AjaxForceCompleteUpdate"];
        //        return obj == null ? false : (bool)obj;
        //    }
        //    set
        //    {
        //        BoxState["AjaxForceCompleteUpdate"] = value;
        //    }
        //}

        #endregion

        #region oldcode


        //public override void RenderBeginTag(HtmlTextWriter writer)
        //{
        //    if (RenderImmediately)
        //    {
        //        //writer.AddAttribute(HtmlTextWriterAttribute.Id, ContainerID);
        //        //writer.AddStyleAttribute(HtmlTextWriterStyle.Display, "inline");
        //        //writer.RenderBeginTag(HtmlTextWriterTag.Div);

        //        // 用上面的语句，div中间有很大的空白，看着不爽
        //        writer.Write(String.Format("<div id=\"{0}\" style=\"display:inline;\">", ContainerID));
        //    }
        //}

        //public override void RenderEndTag(HtmlTextWriter writer)
        //{
        //    if (RenderImmediately)
        //    {
        //        //writer.RenderEndTag();
        //        writer.Write("</div>");
        //    }
        //} 


        //private string _beforeOnPreRenderScript = String.Empty;

        ///// <summary>
        ///// 此控件预渲染之前需要执行的脚本
        ///// </summary>
        //internal string BeforeOnPreRenderScript
        //{
        //    get
        //    {
        //        return _beforeOnPreRenderScript;
        //    }
        //    set
        //    {
        //        _beforeOnPreRenderScript = value;
        //    }
        //}

        //#region IsInUpdatePanel

        ///// <summary>
        ///// 此控件是否在UpdatePanel中
        ///// 注意：在局部回发时，只要在 UpdatePanel 中的控件都要更新，但有例外情况（如果UpdatePanel属性 UpdateMode="Conditional"）
        ///// </summary>
        ///// <param name="control"></param>
        ///// <returns></returns>
        //public bool IsInPartialRendering()
        //{
        //    if (HttpContext.Current != null && HttpContext.Current.Request != null)
        //    {
        //        for (Control control = this.Parent; control != null; control = control.Parent)
        //        {
        //            if (control.GetType().FullName.Contains("System.Web.UI.UpdatePanel"))
        //            {
        //                if ((control as UpdatePanel).IsInPartialRendering)
        //                {
        //                    return true;
        //                }
        //            } 
        //        }
        //    }
        //    return false;
        //}

        //#endregion

        //#region RefParentControl

        //private ControlBase _refParentControl;

        ///// <summary>
        ///// 需要指定父控件，以便保持控件的JS的渲染顺序是正确的（目前只在MasterPage中使用过一次）
        ///// </summary>
        //internal ControlBase RefParentControl
        //{
        //    get { return _refParentControl; }
        //    set { _refParentControl = value; }
        //}

        //#endregion 


        ///// <summary>
        ///// 添加启动脚本
        ///// 这个方法容易让人误解，去除不用
        ///// </summary>
        ///// <param name="scriptContent"></param>
        //protected void AddStartupScript(string script)
        //{
        //    #region old code
        //    //// 如果是局部回发，并且此控件不在UpdatePanel中，则不重新创建此控件
        //    //if (ResourceHelper.IsPartialPostBack() && ResourceHelper.IsContainScriptManager(Page) && !IsInUpdatePanel())
        //    //{
        //    //    return;
        //    //}

        //    //if (ResourceHelper.IsPartialPostBack(Page) && !IsInPartialRendering())
        //    //{
        //    //    return;
        //    //}

        //    //string addOnScript = "";
        //    //if (AddOnJavaScript != "" && AddOnJavaScript.Contains("{0}"))
        //    //{
        //    //    addOnScript = String.Format(AddOnJavaScript, ClientID);
        //    //}
        //    //_rm.AddStartupScript(this, scriptContent +  addOnScript); 
        //    #endregion

        //    AddStartupScript(this, script);
        //} 



        //protected void AddStartupScript(Control control, string script)
        //{
        //    AddStartupScript(control, script, String.Empty);
        //}

        ///// <summary>
        ///// 添加启动脚本
        ///// </summary>
        ///// <param name="control"></param>
        ///// <param name="scriptContent"></param>
        //protected void AddStartupScript(Control control, string script, string extraScript)
        //{
        //    // 如果控件 可见， 才渲染 javascript 到页面中
        //    if (Visible)
        //    {
        //        ResourceManager.Instance.AddStartupScript(control, script, extraScript);
        //    }
        //}



        //protected virtual void SetDirty()
        //{
        //    //ViewState.SetDirty(true);
        //}



        ////bool IStateManager.IsTrackingViewState
        ////{
        ////    get
        ////    {
        ////        return IsTrackingViewState;
        ////    }
        ////}

        ////void IStateManager.LoadViewState(object state)
        ////{
        ////    LoadViewState(state);
        ////}

        ////object IStateManager.SaveViewState()
        ////{
        ////    return SaveViewState();
        ////}

        ////void IStateManager.TrackViewState()
        ////{
        ////    TrackViewState();
        ////}


        //void ISetDirty.SetDirty()
        //{
        //    //SetDirty();
        //}

        #endregion

        #region oldcode

        ///// <summary>
        ///// 在页面的Page_Load之前执行
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected virtual void OnPreLoad(object sender, EventArgs e)
        //{
        //    //SaveAjaxProperty("Hidden", Hidden);
        //}

        #endregion
    }
}
