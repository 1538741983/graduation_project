
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    PanelBase.cs
 * CreatedOn:   2008-05-07
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
using System.Web.UI.HtmlControls;
using System.Web.UI.Design;

namespace FineUI
{
    /// <summary>
    /// 面板控件基类（抽象类）
    /// </summary>
    public abstract class PanelBase : Container
    {
        #region Constructor

        /// <summary>
        /// 构造函数
        /// </summary>
        public PanelBase()
        {
            AddServerAjaxProperties("IFrameUrl");
            AddClientAjaxProperties();
        }

        #endregion

        #region virtual properties

        ///// <summary>
        ///// 是否自动高度
        ///// </summary>
        //[Category(CategoryName.LAYOUT)]
        //[DefaultValue(false)]
        //[Description("是否自动高度")]
        //public virtual bool AutoHeight
        //{
        //    get
        //    {
        //        object obj = FState["AutoHeight"];
        //        return obj == null ? false : (bool)obj;
        //    }
        //    set
        //    {
        //        FState["AutoHeight"] = value;
        //    }
        //}


        ///// <summary>
        ///// 是否启用自动宽度，通过设置CSS属性height:auto来实现
        ///// </summary>
        //[Category(CategoryName.LAYOUT)]
        //[DefaultValue(false)]
        //[Description("是否自动宽度，通过设置CSS属性height:auto来实现")]
        //public virtual bool AutoWidth
        //{
        //    get
        //    {
        //        object obj = FState["AutoWidth"];
        //        return obj == null ? false : (bool)obj;
        //    }
        //    set
        //    {
        //        FState["AutoWidth"] = value;
        //    }
        //}


        /// <summary>
        /// 是否自动滚动
        /// </summary>
        [Category(CategoryName.LAYOUT)]
        [DefaultValue(false)]
        [Description("是否自动滚动")]
        public bool AutoScroll
        {
            get
            {
                object obj = FState["AutoScroll"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                FState["AutoScroll"] = value;
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// 最小高度
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(typeof(Unit), "")]
        [Description("最小高度")]
        public Unit MinHeight
        {
            get
            {
                object obj = FState["MinHeight"];
                return obj == null ? Unit.Empty : (Unit)obj;
            }
            set
            {
                FState["MinHeight"] = value;
            }
        }


        /// <summary>
        /// 最小宽度
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(typeof(Unit), "")]
        [Description("最小宽度")]
        public Unit MinWidth
        {
            get
            {
                object obj = FState["MinWidth"];
                return obj == null ? Unit.Empty : (Unit)obj;
            }
            set
            {
                FState["MinWidth"] = value;
            }
        }



        /// <summary>
        /// 最大高度
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(typeof(Unit), "")]
        [Description("最大高度")]
        public Unit MaxHeight
        {
            get
            {
                object obj = FState["MaxHeight"];
                return obj == null ? Unit.Empty : (Unit)obj;
            }
            set
            {
                FState["MaxHeight"] = value;
            }
        }


        /// <summary>
        /// 最大宽度
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(typeof(Unit), "")]
        [Description("最大宽度")]
        public Unit MaxWidth
        {
            get
            {
                object obj = FState["MaxWidth"];
                return obj == null ? Unit.Empty : (Unit)obj;
            }
            set
            {
                FState["MaxWidth"] = value;
            }
        }


        /// <summary>
        /// 启用自定义的圆角边框
        /// </summary>
        [Category(CategoryName.BASEOPTIONS)]
        [DefaultValue(false)]
        [Description("启用自定义的圆角边框")]
        public bool EnableFrame
        {
            get
            {
                object obj = FState["EnableFrame"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                FState["EnableFrame"] = value;
            }
        }

        ///// <summary>
        ///// 使用大的标题栏
        ///// </summary>
        //[Category(CategoryName.BASEOPTIONS)]
        //[DefaultValue(false)]
        //[Description("使用大的标题栏")]
        //public bool EnableLargeHeader
        //{
        //    get
        //    {
        //        object obj = FState["EnableLargeHeader"];
        //        return obj == null ? false : (bool)obj;
        //    }
        //    set
        //    {
        //        FState["EnableLargeHeader"] = value;
        //    }
        //}


        ///// <summary>
        ///// 是否显示浅色的背景色
        ///// </summary>
        //[Category(CategoryName.BASEOPTIONS)]
        //[DefaultValue(false)]
        //[Description("是否显示浅色的背景色")]
        //public virtual bool EnableLightBackgroundColor
        //{
        //    get
        //    {
        //        object obj = FState["EnableLightBackgroundColor"];
        //        return obj == null ? false : (bool)obj;
        //    }
        //    set
        //    {
        //        FState["EnableLightBackgroundColor"] = value;
        //    }
        //}


        ///// <summary>
        ///// 废弃EnableBackgroundColor属性，以便和ExtJS保持一致。
        ///// </summary>
        //[Category(CategoryName.BASEOPTIONS)]
        //[DefaultValue(false)]
        //[Description("废弃EnableBackgroundColor属性，以便和ExtJS保持一致。")]
        //[Obsolete("此属性已废除，可以使用BodyStyle来达到想要的效果")]
        //public virtual bool EnableBackgroundColor
        //{
        //    get
        //    {
        //        object obj = FState["EnableBackgroundColor"];
        //        return obj == null ? false : (bool)obj;
        //    }
        //    set
        //    {
        //        FState["EnableBackgroundColor"] = value;
        //    }
        //}

        //private bool RoundBorder_Default = false;

        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue(false)]
        //[Description("是否圆角边框并")]
        //public virtual bool RoundBorder
        //{
        //    get
        //    {
        //        object obj = BoxState["RoundBorder"];
        //        return obj == null ? RoundBorder_Default : (bool)obj;
        //    }
        //    set
        //    {
        //        BoxState["RoundBorder"] = value;
        //    }
        //}


        /// <summary>
        /// 内容区域的样式
        /// </summary>
        [Category(CategoryName.BASEOPTIONS)]
        [DefaultValue("")]
        [Description("内容区域的样式")]
        public string BodyStyle
        {
            get
            {
                object obj = FState["BodyStyle"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                FState["BodyStyle"] = value;
            }
        }


        /// <summary>
        /// 内容区域的内边距，字符串类型，可以设置上下左右的内边距，比如'0px 5px'或'5px 10px 2px 2px'
        /// </summary>
        [Category(CategoryName.LAYOUT)]
        [DefaultValue(typeof(String), "")]
        [Description("内容区域的内边距，字符串类型，可以设置上下左右的内边距，比如'0px 5px'或'5px 10px 2px 2px'")]
        public virtual string BodyPadding
        {
            get
            {
                object obj = FState["BodyPadding"];
                return obj == null ? String.Empty : (string)obj;
            }
            set
            {
                FState["BodyPadding"] = value;
            }
        }


        /// <summary>
        /// 是否显示边框
        /// </summary>
        [Category(CategoryName.BASEOPTIONS)]
        [DefaultValue(true)]
        [Description("是否显示边框")]
        public virtual bool ShowBorder
        {
            get
            {
                object obj = FState["ShowBorder"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                FState["ShowBorder"] = value;
            }
        }



        #endregion

        #region old code
        //protected virtual bool IsIFramePanel
        //{
        //    get
        //    {
        //        return false;
        //    }
        //} 
        #endregion

        #region Toolbars

        private ToolbarCollection _toolbars;

        /// <summary>
        /// 工具栏控件
        /// </summary>
        [Browsable(false)]
        [Category(CategoryName.OPTIONS)]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("工具栏控件")]
        public virtual ToolbarCollection Toolbars
        {
            get
            {
                if (_toolbars == null)
                {
                    _toolbars = new ToolbarCollection(this);
                }
                return _toolbars;
            }
        }
        #endregion

        #region Items

        private ControlBaseCollection items;

        /// <summary>
        /// 子控件
        /// </summary>
        [Browsable(false)]
        [Category(CategoryName.OPTIONS)]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("子控件")]
        [Editor(typeof(ControlBaseItemsEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public virtual ControlBaseCollection Items
        {
            get
            {
                if (items == null)
                {
                    items = new ControlBaseCollection(this);
                }
                return items;
            }
        }
        #endregion

        #region internal RenderChildrenAsContent

        private ITemplate content = null;

        /// <summary>
        /// 子控件
        /// </summary>
        [Browsable(false)]
        [DefaultValue(null)]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("子控件")]
        public virtual ITemplate Content
        {
            get
            {
                return content;
            }
            set
            {
                content = value;
            }
        }


        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("渲染子控件为容器内容")]
        internal virtual bool RenderChildrenAsContent
        {
            get
            {
                object obj = FState["RenderChildrenAsContent"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                FState["RenderChildrenAsContent"] = value;
            }
        }
        #endregion

        #region IFrameUrl/IFrameName/EnableIFrame


        /// <summary>
        /// [AJAX属性]IFrame的地址
        /// </summary>
        [Category(CategoryName.BASEOPTIONS)]
        [DefaultValue("")]
        [Description("[AJAX属性]IFrame的地址")]
        public virtual string IFrameUrl
        {
            get
            {
                object obj = FState["IFrameUrl"];
                if (obj == null)
                {
                    return String.Empty;
                }
                else
                {
                    string url = (string)obj;
                    return ResolveIFrameUrl(url);
                }
            }
            set
            {
                FState["IFrameUrl"] = value;
            }
        }


        /// <summary>
        /// IFrame的名称
        /// </summary>
        [Category(CategoryName.BASEOPTIONS)]
        [DefaultValue("")]
        [Description("IFrame的名称")]
        public virtual string IFrameName
        {
            get
            {
                object obj = FState["IFrameName"];
                if (obj == null)
                {
                    if (DesignMode)
                    {
                        return String.Empty;
                    }
                    else
                    {
                        return String.Format("{0}_iframe", XID);
                    }
                }
                return (string)obj;
            }
            set
            {
                FState["IFrameName"] = value;
            }
        }


        /// <summary>
        /// 是否启用IFrame
        /// </summary>
        [Category(CategoryName.BASEOPTIONS)]
        [DefaultValue(false)]
        [Description("是否启用IFrame")]
        public virtual bool EnableIFrame
        {
            get
            {
                object obj = FState["EnableIFrame"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                FState["EnableIFrame"] = value;
            }
        }

        #endregion

        #region ContentID

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal string ContentID
        {
            get
            {
                return String.Format("{0}_Content", ClientID);
            }
        }

        //protected string _childrenContentClass = String.Empty;

        //[Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //[Description("子控件的容器的样式类（Tab用到了）")]
        //protected virtual string ChildrenContentClass
        //{
        //    get
        //    {
        //        return _childrenContentClass;
        //    }
        //    set
        //    {
        //        _childrenContentClass = value;
        //    }
        //}

        #endregion

        #region RenderBeginTag/RenderEndTag

        // 现在不需要这样处理Iframe了，用html属性
        ///// <summary>
        ///// 是否向页面写iframe
        ///// </summary>
        //private bool _writeIframeToHtmlDocument = false;
        /// <summary>
        /// 渲染控件的开始标签
        /// </summary>
        /// <param name="writer">输出流</param>
        protected override void RenderBeginTag(HtmlTextWriter writer)
        {
            base.RenderBeginTag(writer);

            if (RenderChildrenAsContent)
            {
                #region old code
                //HtmlNodeBuilder nodeBuilder = new HtmlNodeBuilder("div");
                //nodeBuilder.SetProperty("id", ChildrenContentID);
                //nodeBuilder.SetProperty("style", "display:none;");

                //if (!String.IsNullOrEmpty(ChildrenContentClass))
                //{
                //    nodeBuilder.SetProperty("class", ChildrenContentClass);
                //}

                //string startDivHtml = nodeBuilder.ToString();
                //if (startDivHtml.EndsWith("</div>"))
                //{
                //    startDivHtml = startDivHtml.Substring(0, startDivHtml.Length - "</div>".Length);
                //}
                //writer.Write(startDivHtml); 
                #endregion

                #region ChildrenContentID

                StringBuilder sb = new StringBuilder();
                sb.Append("<div");
                sb.AppendFormat(" id=\"{0}\" ", ContentID);
                //sb.Append(" class=\"x-hide-display\" ");

                // 注意，这里不能用 display=none（ContentPanel中的其他FineUI控件的渲染就会有问题）
                // 一定要用visibility:hidden，The shape is not visible, but is still part of the flow of the objects in the browser. Mouse events are not processed. 
                if (EnableIFrame)
                {
                    sb.Append("style=\"width:100%;height:100%;\" ");
                }
                else
                {
                    //sb.Append("style=\"visibility:hidden;\" ");

                    //if (!String.IsNullOrEmpty(ChildrenContentClass))
                    //{
                    //    sb.AppendFormat("class=\"{0}\" ", ChildrenContentClass);
                    //}
                }

                sb.Append(">");

                writer.Write(sb.ToString());

                #endregion

                #region old code

                //if (EnableIFrame && _writeIframeToHtmlDocument)
                //{
                //    writer.Write(String.Format("<iframe src=\"{0}\" name=\"{1}\" frameborder=\"0\" style=\"height:100%;width:100%;overflow:auto;\"></iframe>", IFrameUrl, IFrameName));
                //}

                #endregion

            }

        }

        /// <summary>
        /// 渲染控件的结束标签
        /// </summary>
        /// <param name="writer">输出流</param>
        protected override void RenderEndTag(HtmlTextWriter writer)
        {

            if (RenderChildrenAsContent)
            {
                writer.Write("</div>");
            }


            base.RenderEndTag(writer);
        }
        #endregion

        #region CreateChildControls

        /// <summary>
        /// 创建子控件
        /// </summary>
        protected override void CreateChildControls()
        {
            base.CreateChildControls();

            if (Content != null)
            {
                WebControl ctrl = new WebControl(HtmlTextWriterTag.Div);
                ctrl.ID = "Content";
                Content.InstantiateIn(ctrl);

                Controls.Add(ctrl);
            }
        }


        #endregion

        #region OnPreRender

        /// <summary>
        /// 渲染 HTML 之前调用（AJAX回发）
        /// </summary>
        protected override void OnAjaxPreRender()
        {
            base.OnAjaxPreRender();

            StringBuilder sb = new StringBuilder();
            if (EnableIFrame)
            {
                if (PropertyModified("IFrameUrl"))
                {
                    sb.AppendFormat("F.wnd.updateIFrameNode({0},{1});", XID, JsHelper.Enquote(IFrameUrl));
                }
            }

            AddAjaxScript(sb);
        }

        /// <summary>
        /// 渲染 HTML 之前调用（页面第一次加载或者普通回发）
        /// </summary>
        protected override void OnFirstPreRender()
        {
            base.OnFirstPreRender();

            if (EnableFrame)
            {
                OB.AddProperty("frame", true);
            }


            #region Items

            // 如果是 ContentPanel, 启用 IFrame 或者包含 Content, 则不生成 items
            if (RenderChildrenAsContent || EnableIFrame || (Content != null))
            {
                if (RenderChildrenAsContent || (Content != null))
                {
                    OB.AddProperty("contentEl", String.Format("{0}", ContentID));

                }
            }
            else
            {
                if (Items.Count > 0)
                {
                    JsArrayBuilder ab = new JsArrayBuilder();
                    foreach (ControlBase item in Items)
                    {
                        if (item.Visible)
                        {
                            ab.AddProperty(String.Format("{0}", item.XID), true);
                        }
                    }

                    OB.AddProperty("items", ab.ToString(), true);
                }
            }

            #endregion

            #region Toolbars

            //JsArrayBuilder dockItems = new JsArrayBuilder();
            //foreach (Toolbar bar in Toolbars)
            //{
            //    dockItems.AddProperty(bar.XID, true);
            //}

            //if (this is Grid)
            //{
            //    Grid grid = this as Grid;
            //    if (grid.AllowPaging)
            //    {
            //        dockItems.AddProperty(grid.Render_PagingID, true);
            //    }
            //}

            Dictionary<string, JsArrayBuilder> bars = new Dictionary<string, JsArrayBuilder>();
            foreach (Toolbar bar in Toolbars)
            {
                string barPosition = ToolbarPositionHelper.GetExtName(bar.Position);

                if (!bars.ContainsKey(barPosition))
                {
                    bars[barPosition] = new JsArrayBuilder();
                }
                bars[barPosition].AddProperty(bar.XID, true);
            }

            // 将底部工具栏的顺序反转
            if (bars.ContainsKey("bottom"))
            {
                bars["bottom"].Reverse();
            }
            // 表格的分页工具栏
            if (this is Grid)
            {
                Grid grid = this as Grid;
                if (grid.AllowPaging)
                {
                    if (!bars.ContainsKey("bottom"))
                    {
                        bars["bottom"] = new JsArrayBuilder();
                    }

                    bars["bottom"].AddProperty(grid.Render_PagingID, true);
                }
            }


            JsArrayBuilder dockItems = new JsArrayBuilder();
            foreach (string barPosition in bars.Keys)
            {
                foreach (string barItem in bars[barPosition].Properties)
                {
                    dockItems.AddProperty(barItem, true);
                }
            }
            OB.AddProperty("dockedItems", dockItems);


            #endregion

            #region BodyStyle/ShowBorder

            string bodyStyleStr = BodyStyle;
            if (!bodyStyleStr.Contains("padding"))
            {
                if (!String.IsNullOrEmpty(BodyPadding))
                {
                    bodyStyleStr += String.Format("padding:{0};", StyleUtil.GetMarginPaddingStyle(BodyPadding));
                }
            }

            //if (EnableBackgroundColor)
            //{
            //    if (!bodyStyleStr.Contains("background-color"))
            //    {
            //        string backgroundColorStyleStr = GlobalConfig.GetDefaultBackgroundColor();
            //        if (!String.IsNullOrEmpty(backgroundColorStyleStr))
            //        {
            //            bodyStyleStr += String.Format("background-color:{0};", backgroundColorStyleStr);
            //        }
            //    }
            //}

            OB.AddProperty("bodyStyle", bodyStyleStr);

            OB.AddProperty("border", ShowBorder);


            #endregion

            #region MinHeight/MinHeight

            if (MinHeight != Unit.Empty)
            {
                OB.AddProperty("minHeight", MinHeight.Value);
            }
            if (MinWidth != Unit.Empty)
            {
                OB.AddProperty("minWidth", MinWidth.Value);
            }
            if (MaxHeight != Unit.Empty)
            {
                OB.AddProperty("maxHeight", MaxHeight.Value);
            }
            if (MaxWidth != Unit.Empty)
            {
                OB.AddProperty("maxWidth", MaxWidth.Value);
            }


            //// 对于Panel，如果宽度/高度没有定义
            //if (Width == Unit.Empty && AutoWidth)
            //{
            //    OB.AddProperty("autoWidth", true);
            //}

            //if (Height == Unit.Empty && AutoHeight)
            //{
            //    OB.AddProperty("autoHeight", true);
            //}


            //// 如果父控件是容器控件（不是ContentPanel），并且Layout != LayoutType.Container，
            //// 则设置AutoWidth/AutoHeight都为false
            //if (Parent is PanelBase)
            //{
            //    PanelBase parent = Parent as PanelBase;
            //    if (!(parent is ContentPanel) && parent.Layout != Layout.Container)
            //    {
            //        OB.RemoveProperty("autoHeight");
            //        OB.RemoveProperty("autoWidth");
            //    }
            //}



            if (AutoScroll)
            {
                OB.AddProperty("autoScroll", true);
            }


            #region old code
            //// 如果是 PageLayout 中的Panel，不能设置AutoWidth
            //if (Parent is PageLayout)
            //{
            //    // region
            //    if (Region != Region_Default) OB.AddProperty(OptionName.Region, RegionTypeName.GetName(Region.Value));
            //}
            //else
            //{
            //    // 对于Panel，如果宽度/高度没有定义，则使用自动宽度和高度
            //    if (Width == Unit.Empty)
            //    {
            //        OB.AddProperty(OptionName.AutoWidth, true);
            //    }

            //    if (Height == Unit.Empty)
            //    {
            //        OB.AddProperty(OptionName.AutoHeight, true);
            //    }

            //} 

            //// 如果父控件是容器控件，并且Layout=Fit，则设置AutoWidth/AutoHeight都为false
            //if (Parent is PanelBase)
            //{
            //    PanelBase parentPanel = Parent as PanelBase;
            //    if (parentPanel.Layout == LayoutType.Fit
            //        || parentPanel.Layout == LayoutType.Anchor
            //        || parentPanel.Layout == LayoutType.Border)
            //    {
            //        OB.RemoveProperty(OptionName.AutoHeight);
            //        OB.RemoveProperty(OptionName.AutoWidth);
            //    }

            //}

            #endregion

            #endregion

            #region EnableIFrame

            if (EnableIFrame)
            {
                #region old code

                //string iframeJsContent = String.Empty;

                //string frameUrl = ResolveUrl(IFrameUrl);
                //JsObjectBuilder iframeBuilder = new JsObjectBuilder();
                //if (IFrameDelayLoad)
                //{
                //    iframeBuilder.AddProperty(OptionName.Src, "#");
                //}
                //else
                //{
                //    iframeBuilder.AddProperty(OptionName.Src, frameUrl);
                //}
                //iframeBuilder.AddProperty(OptionName.LoadMask, false);
                //iframeJsContent += String.Format("var {0}=new Ext.ux.ManagedIFrame('{0}',{1});", IFrameID, iframeBuilder.ToString());

                //if (IFrameDelayLoad)
                //{
                //    iframeJsContent += String.Format("{0}_url='{1}';", IFrameID, frameUrl);
                //}

                //iframeJsContent += "\r\n";

                //AddStartupScript(this, iframeJsContent); 

                #endregion

                // 注意：
                // 如下依附于现有对象的属性名称的定义规则：x_property1
                // 存储于当前对象实例中
                OB.AddProperty("f_iframe", true);
                OB.AddProperty("f_iframe_url", IFrameUrl);
                OB.AddProperty("f_iframe_name", IFrameName);

                // 如果定义了IFrameUrl，则直接写到页面中，否则先缓存到此对象中
                if (!String.IsNullOrEmpty(IFrameUrl))
                {
                    //_writeIframeToHtmlDocument = true;
                    OB.AddProperty("f_iframe_loaded", true);
                    // 直接添加iframe属性
                    OB.AddProperty("html", String.Format("<iframe src=\"{0}\" name=\"{1}\" frameborder=\"0\" style=\"height:100%;width:100%;overflow:auto;\"></iframe>", IFrameUrl, IFrameName));
                }
                else
                {
                    //_writeIframeToHtmlDocument = false;
                    OB.AddProperty("f_iframe_loaded", false);
                }

                #region old code

                //// If current panel is Tab, then process the IFrameDelayLoad property.
                //Tab tab = this as Tab;
                //if (tab != null && tab.IFrameDelayLoad)
                //{
                //    // 如果是Tab，并且此Tab不是激活的，则不添加iframe
                //    //_writeIframeToHtmlDocument = false;
                //    OB.AddProperty("box_property_iframe_loaded", false);
                //}
                //else
                //{
                //    // 如果定义了IFrameUrl，则直接写到页面中，否则先缓存到此对象中
                //    if (!String.IsNullOrEmpty(IFrameUrl))
                //    {
                //        //_writeIframeToHtmlDocument = true;
                //        OB.AddProperty("box_property_iframe_loaded", true);
                //        // 直接添加iframe属性
                //        OB.AddProperty("html", String.Format("<iframe src=\"{0}\" name=\"{1}\" frameborder=\"0\" style=\"height:100%;width:100%;overflow:auto;\"></iframe>", IFrameUrl, IFrameName));
                //    }
                //    else
                //    {
                //        //_writeIframeToHtmlDocument = false;
                //        OB.AddProperty("box_property_iframe_loaded", false);
                //    }
                //} 

                #endregion
            }

            #endregion

            #region RoundBorder

            //if (RoundBorder) OB.AddProperty(OptionName.Frame, true);

            #endregion

            #region oldcode

            //if (EnableLargeHeader)
            //{
            //    OB.AddProperty("cls", "f-panel-big-header");
            //}


            //OB.AddProperty("animCollapse", false);

            #endregion

            #region ContentEl

            //string finallyScript = String.Empty;

            if (RenderChildrenAsContent)
            {
                OB.AddProperty("contentEl", ContentID);

                // 在页面元素渲染完成后，才显示容器控件的内容
                //string renderScript = String.Format("Ext.get('{0}').show();", ContentID);
                //OB.Listeners.AddProperty("render", JsHelper.GetFunction(renderScript), true);

                //string beforerenderScript = String.Format("Ext.get('{0}').setStyle('display','');", ChildrenContentID);
                //OB.Listeners.AddProperty("beforerender", "function(component){" + beforerenderScript + "}", true);


                // 这一段的逻辑（2008-9-1）：
                // 如果是页面第一次加载 + 此Panel在Tab中 + 此Tab不是当前激活Tab + 此Tab的TabStrip启用了延迟加载
                // 那么在页面加载完毕后，把此Panel给隐藏掉，等此Panel渲染到页面中时再显示出来

                //Tab tab = ControlUtil.FindParentControl(this, typeof(Tab)) as Tab;
                //if (tab != null)
                //{
                //    TabStrip tabStrip = tab.Parent as TabStrip;
                //    if (tabStrip.EnableDeferredRender && tabStrip.Tabs[tabStrip.ActiveTabIndex] != tab)
                //    {
                //        // 页面第一次加载时，在显示（控件的render事件）之前要先隐藏
                //        AddStartupAbsoluteScript(String.Format("Ext.get('{0}').setStyle('display','none');", ContentID));
                //    }
                //}

            }

            #endregion
        }

        #region oldcode

        //protected void AddItemsToOB()
        //{
        //    AddItemsToOB(Controls);
        //}



        ///// <summary>
        ///// 将controls添加到此控件的Items属性
        ///// </summary>
        ///// <param name="controls"></param>
        //protected void AddItemsToOB(ControlCollection controls)
        //{
        //    // 运行到这里，Controls里全部是ControlBase类型了（在AddParsedSubObject中过滤的）。
        //    if (controls.Count > 0)
        //    {
        //        JsArrayBuilder ab = new JsArrayBuilder();
        //        foreach (Control item in controls)
        //        {
        //            // 再次检查是否ControlBase，并且只有Visible时才添加
        //            // 还有一个例外情况，Window控件不作为任何控件的子控件，Window的RenderImmediately一定为true
        //            if (item is ControlBase && item.Visible && !(item is Window))
        //            {
        //                string itemJSId = String.Format("{0}", (item as ControlBase).ClientJavascriptID);
        //                if (item is Toolbar)
        //                {
        //                    Toolbar bar = item as Toolbar;
        //                    if (bar.Position == ToolbarPosition.Top)
        //                    {
        //                        OB.AddProperty(OptionName.Tbar, itemJSId, true);
        //                    }
        //                    else
        //                    {
        //                        OB.AddProperty(OptionName.Bbar, itemJSId, true);
        //                    }
        //                }
        //                else
        //                {
        //                    ab.AddProperty(itemJSId, true);
        //                }
        //            }
        //        }

        //        // 有内容时才添加items集合
        //        if (ab.Count > 0)
        //        {
        //            OB.AddProperty(OptionName.Items, ab.ToString(), true);
        //        }
        //    }
        //}



        #endregion

        #endregion

        #region ResolveIFrameUrl

        internal string ResolveIFrameUrl(string url)
        {
            if (String.IsNullOrEmpty(url))
            {
                return String.Empty;
            }

            if (url == "#" || url == "about:blank")
            {
                return url;
            }

            //&& IFrameUrl != "#" && IFrameUrl != "about:blank"

            // 可能会通过<script></script>的方式传递js参数
            if (url.Contains("<"))
            {
                url = url.Replace("<", "&lt;");
            }
            if (url.Contains(">"))
            {
                url = url.Replace(">", "&gt;");
            }


            // 这个在 v1.2.9 以后就不需要了
            //// 加上后缀
            //if (this is Window)
            //{
            //    if (!url.Contains("box_parent_client_id="))
            //    {
            //        if (!url.Contains("?"))
            //        {
            //            url += "?";
            //        }
            //        else
            //        {
            //            url += "&";
            //        }
            //        url += "box_parent_client_id=" + ClientID;
            //    }
            //}


            // 转换为客户端Url
            url = ResolveUrl(url);

            return url;
        }

        #endregion

        #region RefreshIFrame GetRefreshIFrameReference

        /// <summary>
        /// 刷新面板中的IFrame页面
        /// </summary>
        public void RefreshIFrame()
        {
            PageContext.RegisterStartupScript(GetRefreshIFrameReference());
        }

        /// <summary>
        /// 获取刷新面板中IFrame页面的客户端脚本
        /// </summary>
        /// <returns>客户端脚本</returns>
        public string GetRefreshIFrameReference()
        {
            return String.Format("{0}.body.query('iframe')[0].contentWindow.location.reload();", ScriptID);
        }

        #endregion

        #region Reset

        /// <summary>
        /// 重置面板中所有字段
        /// </summary>
        public virtual void Reset()
        {
            PageContext.RegisterStartupScript(GetResetReference());
        }

        /// <summary>
        /// 获取重置面板中所有字段的客户端脚本
        /// </summary>
        /// <returns></returns>
        public virtual string GetResetReference()
        {
            return String.Format("{0}.f_reset();", ScriptID);
        }

        #endregion

        #region GetClearDirtyReference

        /// <summary>
        /// 清空面板内表单字段的改变状态
        /// </summary>
        /// <returns>客户端脚本</returns>
        public string GetClearDirtyReference()
        {
            return String.Format("{0}.f_clearDirty();", ScriptID);
        } 

        #endregion
    }
}
