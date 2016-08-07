
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    Accordion.cs
 * CreatedOn:   2008-06-12
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

namespace FineUI
{
    /// <summary>
    /// 手风琴控件
    /// </summary>
    [Designer("FineUI.Design.AccordionDesigner, FineUI.Design")]
    [ToolboxData("<{0}:Accordion Title=\"Accordion\" ShowCollapseTool=\"false\" ShowBorder=\"false\" ShowHeader=\"false\" runat=\"server\"><Panes><{0}:AccordionPane runat=\"server\" Title=\"AccordionPane1\" BodyPadding=\"5px\" ShowBorder=\"false\"></{0}:AccordionPane><{0}:AccordionPane runat=\"server\" Title=\"AccordionPane2\" BodyPadding=\"5px\" ShowBorder=\"false\"></{0}:AccordionPane></Panes></{0}:Accordion>")]
    [ToolboxBitmap(typeof(Accordion), "toolbox.Accordion.bmp")]
    [Description("手风琴控件")]
    [ParseChildren(true)]
    [PersistChildren(false)]
    [ControlBuilder(typeof(NotAllowWhitespaceLiteralsBuilder))]
    public class Accordion : CollapsablePanel, IPostBackDataHandler, IPostBackEventHandler
    {
        #region Constructor

        /// <summary>
        /// 
        /// </summary>
        public Accordion()
        {
            AddServerAjaxProperties();
            AddClientAjaxProperties("ActivePaneIndex");
        }

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
        [DefaultValue(Layout.Accordion)]
        [Description("布局类型")]
        public override Layout Layout
        {
            get
            {
                return Layout.Accordion;
            }
        }


        #endregion

        #region Properties

        /// <summary>
        /// 是否启用折叠按钮
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("是否启用折叠按钮")]
        public bool ShowCollapseTool
        {
            get
            {
                object obj = FState["ShowCollapseTool"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                FState["ShowCollapseTool"] = value;
            }
        }


        /// <summary>
        /// 是否启用激活在最上面
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("是否启用激活在最上面")]
        public bool EnableActiveOnTop
        {
            get
            {
                object obj = FState["EnableActiveOnTop"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                FState["EnableActiveOnTop"] = value;
            }
        }

        /// <summary>
        /// 是否启用填充整个区域
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("是否启用填充整个区域")]
        public bool EnableFill
        {
            get
            {
                object obj = FState["EnableFill"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                FState["EnableFill"] = value;
            }
        }


        //private bool EnableAnimate_Default = false;

        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue(false)]
        //[Description("是否启用动画")]
        //public bool EnableAnimate
        //{
        //    get
        //    {
        //        object obj = BoxState["EnableAnimate"];
        //        return obj == null ? EnableAnimate_Default : (bool)obj;
        //    }
        //    set
        //    {
        //        BoxState["EnableAnimate"] = value;
        //    }
        //}


        //private bool PersistActiveIndexInCookie_Default = false;

        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue(false)]
        //[Description("将ActiveIndex保持在Cookie中，以便在页面跳转过程中位置状态")]
        //public bool PersistActiveIndexInCookie
        //{
        //    get
        //    {
        //        object obj = BoxState["PersistActiveIndexInCookie"];
        //        return obj == null ? PersistActiveIndexInCookie_Default : (bool)obj;
        //    }
        //    set
        //    {
        //        BoxState["PersistActiveIndexInCookie"] = value;
        //    }
        //}


        #endregion

        #region ActivePaneIndex

        /// <summary>
        /// 切换面板时是否自动回发
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("切换面板时是否自动回发")]
        public bool AutoPostBack
        {
            get
            {
                object obj = FState["AutoPostBack"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                FState["AutoPostBack"] = value;
            }
        }

        /// <summary>
        /// [AJAX属性]激活面板的索引
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(0)]
        [Description("[AJAX属性]激活面板的索引")]
        public int ActivePaneIndex
        {
            get
            {
                object obj = FState["ActivePaneIndex"];
                return obj == null ? 0 : (int)obj;
            }
            set
            {
                FState["ActivePaneIndex"] = value;
            }
        }

        /// <summary>
        /// 当前激活的面板
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AccordionPane ActivePane
        {
            get
            {
                if (ActivePaneIndex >= 0 && ActivePaneIndex < Panes.Count)
                {
                    return Panes[ActivePaneIndex];
                }
                return null;
            }
        }

        /*
        
        private int _activePaneIndex = -1;
        
        /// <summary>
        /// 激活面板的索引
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(0)]
        [Description("激活面板的索引")]
        public int ActivePaneIndex
        {
            get
            {
                int activeIndex = 0;
                for (int i = 0, count = Panes.Count; i < count; i++)
                {
                    if (!Panes[i].Collapsed)
                    {
                        activeIndex = i;
                        break;
                    }
                }
                return activeIndex;
            }
            set
            {
                // We cann't set children AccordionPane's Collapsed property now, because they may not been loaded yet.
                _activePaneIndex = value;
            }
        }
        */


        #endregion

        #region Panes

        private AccordionPaneCollection _panes;

        /// <summary>
        /// 手风琴面板集合
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public AccordionPaneCollection Panes
        {
            get
            {
                if (_panes == null)
                {
                    _panes = new AccordionPaneCollection(this);
                }
                return _panes;
            }
        }

        #endregion

        #region old code

        //protected override void CreateChildControls()
        //{
        //    base.CreateChildControls();


        //    //foreach (AccordionPanel row in Items)
        //    //{
        //    //    row.RenderWrapperDiv = false;
        //    //    Controls.Add(row);
        //    //}
        //}

        #endregion

        #region ActivePaneIndexHiddenFieldID

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        private string ActivePaneIndexHiddenFieldID
        {
            get
            {
                return String.Format("{0}_ActivePaneIndex", ClientID);
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
            if (PropertyModified("ActivePaneIndex"))
            {
                if (ActivePane != null)
                {
                    ActivePane.AddAjaxScript(String.Format("{0}.expand();", ActivePane.XID));
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

            #region Reset ActiveIndex

            // 重置面板的 Collapsed 属性
            if (ActivePane != null)
            {
                foreach (AccordionPane pane in Panes)
                {
                    pane.Collapsed = true;
                }

                ActivePane.Collapsed = false;
            }

            #endregion

            #region Panes

            if (Panes.Count > 0)
            {
                JsArrayBuilder ab = new JsArrayBuilder();
                foreach (AccordionPane item in Panes)
                {
                    if (item.Visible)
                    {
                        ab.AddProperty(String.Format("{0}", item.XID), true);
                    }
                }
                OB.AddProperty("items", ab.ToString(), true);
            }

            #endregion

            #region LayoutConfig

            OB.RemoveProperty("layout");

            JsObjectBuilder configBuilder = new JsObjectBuilder();
            configBuilder.AddProperty("animate", false);
            configBuilder.AddProperty("activeOnTop", EnableActiveOnTop);
            configBuilder.AddProperty("fill", EnableFill);
            configBuilder.AddProperty("hideCollapseTool", !ShowCollapseTool);
            configBuilder.AddProperty("type", "accordion");

            //configBuilder.AddProperty("multi", true);

            OB.AddProperty("layout", configBuilder);

            #endregion


            string jsContent = String.Format("var {0}=Ext.create('Ext.panel.Panel',{1});", XID, OB.ToString());
            AddStartupScript(jsContent);
        }

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

            string postValue = postCollection[ActivePaneIndexHiddenFieldID];

            int postActivePaneIndex = Convert.ToInt32(postValue);
            if (ActivePaneIndex != postActivePaneIndex)
            {
                ActivePaneIndex = postActivePaneIndex;
                FState.BackupPostDataProperty("ActivePaneIndex");
            }

            return false;
        }

        
        #endregion

        #region IPostBackEventHandler

        /// <summary>
        /// 处理回发事件
        /// </summary>
        /// <param name="eventArgument">事件参数</param>
        public override void RaisePostBackEvent(string eventArgument)
        {
            base.RaisePostBackEvent(eventArgument);

            if (eventArgument == "PaneIndexChanged")
            {
                OnPaneIndexChanged(EventArgs.Empty);
            }
        }

        #endregion

        #region OnPaneIndexChanged

        private static readonly object _handlerKey = new object();

        /// <summary>
        /// 面板改变事件
        /// </summary>
        [Category(CategoryName.ACTION)]
        [Description("面板改变事件")]
        public event EventHandler PaneIndexChanged
        {
            add
            {
                Events.AddHandler(_handlerKey, value);
            }
            remove
            {
                Events.RemoveHandler(_handlerKey, value);
            }
        }

        /// <summary>
        /// 触发面板改变事件
        /// </summary>
        /// <param name="e">事件参数</param>
        protected virtual void OnPaneIndexChanged(EventArgs e)
        {
            EventHandler handler = Events[_handlerKey] as EventHandler;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion

    }
}
