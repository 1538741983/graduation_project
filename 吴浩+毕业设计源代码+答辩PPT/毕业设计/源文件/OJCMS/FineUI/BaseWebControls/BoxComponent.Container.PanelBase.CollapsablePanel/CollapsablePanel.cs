
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    CollapsablePanel.cs
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
    /// 可折叠面板控件基类（抽象类）
    /// </summary>
    public abstract class CollapsablePanel : PanelBase, IPostBackDataHandler, IPostBackEventHandler
    {
        #region Constructor

        /// <summary>
        /// 构造函数
        /// </summary>
        public CollapsablePanel()
        {
            AddServerAjaxProperties("Title");
            AddClientAjaxProperties("Collapsed");
        }

        #endregion

        #region Properties

        /// <summary>
        /// 是否启用折叠事件
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("是否启用折叠事件")]
        public bool EnableCollapseEvent
        {
            get
            {
                object obj = FState["EnableCollapseEvent"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                FState["EnableCollapseEvent"] = value;
            }
        }

        /// <summary>
        /// 是否启用展开事件
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("是否启用展开事件")]
        public bool EnableExpandEvent
        {
            get
            {
                object obj = FState["EnableExpandEvent"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                FState["EnableExpandEvent"] = value;
            }
        }

        /// <summary>
        /// 是否展开
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("是否展开")]
        public virtual bool Expanded
        {
            get
            {
                return !Collapsed;
            }
            set
            {
                Collapsed = !value;
            }
        }


        /// <summary>
        /// [AJAX属性]是否折叠
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("[AJAX属性]是否折叠")]
        public virtual bool Collapsed
        {
            get
            {
                object obj = FState["Collapsed"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                FState["Collapsed"] = value;
            }
        }


        /// <summary>
        /// 是否允许折叠
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("是否允许折叠")]
        public virtual bool EnableCollapse
        {
            get
            {
                object obj = FState["EnableCollapse"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                FState["EnableCollapse"] = value;
            }
        }

        /// <summary>
        /// [AJAX属性]标题
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("[AJAX属性]标题")]
        public string Title
        {
            get
            {
                object obj = FState["Title"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                FState["Title"] = value;
            }
        }

        /// <summary>
        /// 是否显示标题栏
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("是否显示标题栏")]
        public virtual bool ShowHeader
        {
            get
            {
                object obj = FState["ShowHeader"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                FState["ShowHeader"] = value;
            }
        }

        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue("")]
        //[Description("图标样式类")]
        //public string IconClassName
        //{
        //    get
        //    {
        //        object obj = BoxState["IconClassName"];
        //        return obj == null ? "" : (string)obj;
        //    }
        //    set
        //    {
        //        BoxState["IconClassName"] = value;
        //    }
        //}

        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue(false)]
        //[Description("是否自动回发")]
        //public bool AutoPostBack
        //{
        //    get
        //    {
        //        object obj = BoxState["AutoPostBack"];
        //        return obj == null ? false : (bool)obj;
        //    }
        //    set
        //    {
        //        BoxState["AutoPostBack"] = value;
        //    }
        //}




        /// <summary>
        /// 图标地址
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("图标地址")]
        [Editor(typeof(ImageUrlEditor), typeof(UITypeEditor))]
        public string IconUrl
        {
            get
            {
                object obj = FState["IconUrl"];
                if (obj == null)
                {
                    if (!DesignMode)
                    {
                        if (Icon != Icon.None)
                        {
                            obj = IconHelper.GetIconUrl(Icon);
                        }
                    }
                }
                return obj == null ? "" : (string)obj;
            }
            set
            {
                FState["IconUrl"] = value;
            }
        }


        /// <summary>
        /// 图标
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(Icon.None)]
        [Description("图标")]
        public virtual Icon Icon
        {
            get
            {
                object obj = FState["Icon"];
                return obj == null ? Icon.None : (Icon)obj;
            }
            set
            {
                FState["Icon"] = value;
            }
        }

        #endregion

        #region CollapsedHiddenFieldID

        #region old code

        //private System.Web.UI.WebControls.HiddenField _collapsedHiddenField;

        //private System.Web.UI.WebControls.HiddenField CollapsedHiddenField
        //{
        //    get
        //    {
        //        if (_collapsedHiddenField == null)
        //        {
        //            _collapsedHiddenField = new HiddenField();
        //            _collapsedHiddenField.ID = "collapsed";
        //        }
        //        return _collapsedHiddenField;
        //    }
        //}

        #endregion

        // 这个值在 X.ajax.js 中和 getFStateViaCmp 函数相呼应
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal string CollapsedHiddenFieldID
        {
            get
            {
                return String.Format("{0}_Collapsed", ClientID);
            }
        }

        #endregion

        #region OnPreRender|OnFirstPreRender

        /// <summary>
        /// 渲染 HTML 之前调用（AJAX回发）
        /// </summary>
        protected override void OnAjaxPreRender()
        {
            base.OnAjaxPreRender();

            StringBuilder sb = new StringBuilder();
            if (PropertyModified("Collapsed"))
            {
                sb.AppendFormat("{0}.f_setCollapse();", XID);
            }
            if (ShowHeader && PropertyModified("Title"))
            {
                sb.AppendFormat("{0}.f_setTitle();", XID);
            }

            AddAjaxScript(sb);
        }

        /// <summary>
        /// 渲染 HTML 之前调用（页面第一次加载或者普通回发）
        /// </summary>
        protected override void OnFirstPreRender()
        {
            base.OnFirstPreRender();

            #region options

            OB.AddProperty("animCollapse", false);
            OB.AddProperty("collapsible", EnableCollapse);
            OB.AddProperty("collapsed", Collapsed);

            #endregion

            #region ShowHeader

            if (ShowHeader)
            {
                //OB.AddProperty("title", String.IsNullOrEmpty(Title) ? String.Format("[{0}]", ID) : Title);

                OB.AddProperty("title", Title);

            }
            else
            {
                OB.AddProperty("header", false);
            }

            #endregion

            #region IconUrl

            if (!String.IsNullOrEmpty(IconUrl))
            {
                // Window控件的特殊处理在Window控件中
                // 添加CSS样式
                string className = String.Format("f-{0}-panelbase-icon", XID);
                AddStartupCSS(className, StyleUtil.GetNoRepeatBackgroundStyle("." + className, ResolveUrl(IconUrl)));

                OB.AddProperty("iconCls", className);

                //// 下面这种方式不行，这个样式是要添加到Head中的，而不是最外层的DIV
                //AddExtraStyle("background", StyleUtil.GetNoRepeatBackgroundStyleValue(ResolveUrl(IconUrl)));
            }

            #endregion

            #region old code

            //if (IconClassName != "") OB.AddProperty(OptionName.IconCls, IconClassName);

            // Listeners, 折叠展开
            //JsObjectBuilder listenersBuilder = new JsObjectBuilder();
            //listenersBuilder.AddProperty("collapse", String.Format("function(panel){{Ext.get('{0}').dom.value=true;}}", CollapsedHiddenField.ClientID), true);
            //listenersBuilder.AddProperty("expand", String.Format("function(panel){{Ext.get('{0}').dom.value=false;}}", CollapsedHiddenField.ClientID), true);
            //OBuilder.AddProperty("listeners", listenersBuilder.ToString(), true);


            //if (EnableCollapse)
            //{
            //    OB.Listeners.AddProperty("collapse", String.Format("function(panel){{Ext.get('{0}').dom.value=true;}}", CollapsedHiddenFieldID), true);
            //    OB.Listeners.AddProperty("expand", String.Format("function(panel){{Ext.get('{0}').dom.value=false;}}", CollapsedHiddenFieldID), true);
            //}



            //string hiddenFieldsScript = String.Empty;

            //if (EnableCollapse)
            //{
            //    hiddenFieldsScript += GetSetHiddenFieldValueScript(CollapsedHiddenFieldID, Collapsed.ToString().ToLower());
            //}

            //hiddenFieldsScript += "\r\n";

            //// 在ControlBase的RegisterControlStartupScript函数中做过处理，会把在基类中注册的脚本合并后再整体注册
            ////AddStartupScript(this, hiddenFieldsScript);
            //AddPageFirstLoadScript(hiddenFieldsScript);

            #endregion

            #region EnableCollapseEvent

            if (EnableCollapseEvent)
            {
                //string collapseScript = JsHelper.GetFunction(GetPostBackEventReference("Collapse"));
                //OB.Listeners.AddProperty("collapse", collapseScript, true);
                AddListener("collapse", GetPostBackEventReference("Collapse"));
            }

            if (EnableExpandEvent)
            {
                //string expandScript = JsHelper.GetFunction(GetPostBackEventReference("Expand"));
                //OB.Listeners.AddProperty("expand", expandScript, true);
                AddListener("expand", GetPostBackEventReference("Expand"));
            } 

            #endregion
        }

        #endregion

        #region IPostBackDataHandler Members

        /// <summary>
        /// 处理回发数据
        /// </summary>
        /// <param name="postDataKey">回发数据键</param>
        /// <param name="postCollection">回发数据集</param>
        /// <returns>回发数据是否改变</returns>
        public virtual bool LoadPostData(string postDataKey, System.Collections.Specialized.NameValueCollection postCollection)
        {
            bool postCollapsed = Convert.ToBoolean(postCollection[CollapsedHiddenFieldID]);
            if (Collapsed != postCollapsed)
            {
                Collapsed = postCollapsed;
                FState.BackupPostDataProperty("Collapsed");
            }

            return false;
        }

        /// <summary>
        /// 触发回发数据改变事件
        /// </summary>
        public virtual void RaisePostDataChangedEvent()
        {
            //OnCollapsedChanged(EventArgs.Empty);
        }

        ///// <summary>
        ///// 是否折叠变化
        ///// </summary>
        //public event EventHandler CollapsedChanged
        //{
        //    add
        //    {
        //        Events.AddHandler(_handlerKey, value);
        //    }
        //    remove
        //    {
        //        Events.RemoveHandler(_handlerKey, value);
        //    }
        //}

        //public object _handlerKey = new object();

        //public virtual void OnCollapsedChanged(EventArgs e)
        //{
        //    EventHandler handler = Events[_handlerKey] as EventHandler;

        //    if (handler != null)
        //    {
        //        handler(this, e);
        //    }
        //}

        #endregion

        #region IPostBackEventHandler

        /// <summary>
        /// 处理回发事件
        /// </summary>
        /// <param name="eventArgument">事件参数</param>
        public virtual void RaisePostBackEvent(string eventArgument)
        {
            if (eventArgument == "Collapse")
            {
                OnCollapse(EventArgs.Empty);
            }
            else if (eventArgument == "Expand")
            {
                OnExpand(EventArgs.Empty);
            } 

        }

        #endregion

        #region OnCollapse

        private static readonly object _collapseHandlerKey = new object();

        /// <summary>
        /// 折叠事件
        /// </summary>
        [Category(CategoryName.ACTION)]
        [Description("折叠事件")]
        public event EventHandler Collapse
        {
            add
            {
                Events.AddHandler(_collapseHandlerKey, value);
            }
            remove
            {
                Events.RemoveHandler(_collapseHandlerKey, value);
            }
        }

        /// <summary>
        /// 触发折叠事件
        /// </summary>
        /// <param name="e">事件参数</param>
        protected virtual void OnCollapse(EventArgs e)
        {
            EventHandler handler = Events[_collapseHandlerKey] as EventHandler;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion

        #region OnExpand

        private static readonly object _expandHandlerKey = new object();

        /// <summary>
        /// 展开事件
        /// </summary>
        [Category(CategoryName.ACTION)]
        [Description("展开事件")]
        public event EventHandler Expand
        {
            add
            {
                Events.AddHandler(_expandHandlerKey, value);
            }
            remove
            {
                Events.RemoveHandler(_expandHandlerKey, value);
            }
        }

        /// <summary>
        /// 触发展开事件
        /// </summary>
        /// <param name="e">事件参数</param>
        protected virtual void OnExpand(EventArgs e)
        {
            EventHandler handler = Events[_expandHandlerKey] as EventHandler;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion

    }
}
