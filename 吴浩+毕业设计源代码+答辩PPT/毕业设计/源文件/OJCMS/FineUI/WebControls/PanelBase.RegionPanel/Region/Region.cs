
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    RegionCollection.cs
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
    /// 区域控件
    /// </summary>
    [Designer("FineUI.Design.RegionDesigner, FineUI.Design")]
    [ToolboxData("<{0}:Region Position=\"Center\" runat=\"server\"></{0}:Region>")]
    [ToolboxBitmap(typeof(Region), "toolbox.Region.bmp")]
    [Description("区域控件")]
    [ParseChildren(true)]
    [PersistChildren(false)]
    [ControlBuilder(typeof(NotAllowWhitespaceLiteralsBuilder))]
    public class Region : CollapsablePanel
    {
        #region Unsupported Properties

        //[Category(CategoryName.OPTIONS)]
        //[Description("布局类型")]
        //[Browsable(false)]
        //public override LayoutType Layout
        //{
        //    get
        //    {
        //        return LayoutType.Fit;
        //    }
        //}


        #endregion

        #region Properties

        //private string ContentPlaceHolderId_Default = "";

        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue("")]
        //[Description("ContentPlaceHolderId")]
        //public string ContentPlaceHolderId
        //{
        //    get
        //    {
        //        object obj = BoxState["ContentPlaceHolderId"];
        //        return obj == null ? ContentPlaceHolderId_Default : (string)obj;
        //    }
        //    set
        //    {
        //        BoxState["ContentPlaceHolderId"] = value;
        //    }
        //}

        /// <summary>
        /// 是否可以拖动分隔条
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("是否可以拖动分隔条")]
        [Obsolete("已废除，请使用RegionSplit属性")]
        public bool Split
        {
            get
            {
                //object obj = FState["Split"];
                //return obj == null ? false : (bool)obj;
                return RegionSplit;
            }
            set
            {
                RegionSplit = value;
            }
        }


        /// <summary>
        /// 位置
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(Position.Center)]
        [Description("位置")]
        [Obsolete("已废除，请使用RegionPosition属性")]
        public Position Position
        {
            get
            {
                //object obj = FState["PositionType"];
                //return obj == null ? Position.Center : (Position)obj;
                return RegionPosition;
            }
            set
            {
                RegionPosition = value;
            }
        }


        ///// <summary>
        ///// 是否启用分隔条提示
        ///// </summary>
        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue(false)]
        //[Description("是否启用分隔条提示")]
        //public bool EnableSplitTip
        //{
        //    get
        //    {
        //        object obj = FState["EnableSplitTip"];
        //        return obj == null ? false : (bool)obj;
        //    }
        //    set
        //    {
        //        FState["EnableSplitTip"] = value;
        //    }
        //}


        ///// <summary>
        ///// 分隔条提示信息
        ///// </summary>
        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue("")]
        //[Description("分隔条提示信息")]
        //public string SplitTip
        //{
        //    get
        //    {
        //        object obj = FState["SplitTip"];
        //        return obj == null ? "" : (string)obj;
        //    }
        //    set
        //    {
        //        FState["SplitTip"] = value;
        //    }
        //}

        ///// <summary>
        ///// 可折叠区域的分隔条提示信息
        ///// </summary>
        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue("")]
        //[Description("可折叠区域的分隔条提示信息")]
        //public string CollapsibleSplitTip
        //{
        //    get
        //    {
        //        object obj = FState["CollapsibleSplitTip"];
        //        return obj == null ? "" : (string)obj;
        //    }
        //    set
        //    {
        //        FState["CollapsibleSplitTip"] = value;
        //    }
        //}


        ///// <summary>
        ///// 外边距
        ///// </summary>
        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue("")]
        //[Description("外边距")]
        //[Obsolete("已废除，请使用Margin属性")]
        //public string Margins
        //{
        //    get
        //    {
        //        return Margin;
        //    }
        //    set
        //    {
        //        Margin = value;
        //    }
        //}

        ///// <summary>
        ///// 折叠后的边距
        ///// </summary>
        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue("")]
        //[Description("折叠后的边距")]
        //public string CMargins
        //{
        //    get
        //    {
        //        object obj = FState["CMargins"];
        //        return obj == null ? "" : (string)obj;
        //    }
        //    set
        //    {
        //        FState["CMargins"] = value;
        //    }
        //}


        ///// <summary>
        ///// 折叠模式（通过点击工具栏上的按钮还是点击分隔条上的按钮来展开折叠面板）
        ///// </summary>
        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue(CollapseMode.Default)]
        //[Description("折叠模式（通过点击工具栏上的按钮还是点击分隔条上的按钮来展开折叠面板）")]
        //public CollapseMode CollapseMode
        //{
        //    get
        //    {
        //        object obj = FState["CollapseMode"];
        //        return obj == null ? CollapseMode.Default : (CollapseMode)obj;
        //    }
        //    set
        //    {
        //        FState["CollapseMode"] = value;
        //    }
        //}


        #endregion

        #region OnInit

        /// <summary>
        /// Tab 控件必须包含在 TabStrip 中
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            if (!DesignMode)
            {
                if (!(Parent is RegionPanel))
                {
                    throw new Exception("Region control must be included in RegionPanel control.");
                }
            }

        }

        #endregion

        #region oldcode

        //private ControlBaseCollection _items;

        //[Category(CategoryName.OPTIONS)]
        //[NotifyParentProperty(true)]
        //[PersistenceMode(PersistenceMode.InnerDefaultProperty)]
        //public virtual ControlBaseCollection Items
        //{
        //    get
        //    {
        //        if (_items == null)
        //        {
        //            _items = new ControlBaseCollection(this);

        //            //if (base.IsTrackingViewState)
        //            //{
        //            //    ((IStateManager)_rows).TrackViewState();
        //            //}
        //        }
        //        return _items;
        //    }
        //}
        #endregion

        #region OnPreRender

        /// <summary>
        /// 渲染 HTML 之前调用（AJAX回发）
        /// </summary>
        protected override void OnAjaxPreRender()
        {
            base.OnAjaxPreRender();

            StringBuilder sb = new StringBuilder();
            //if (PropertyModified("Text"))
            //{
            //    sb.AppendFormat("{0}.setValue({1});", XID, JsHelper.Enquote(Text));
            //}

            AddAjaxScript(sb);
        }

        /// <summary>
        /// 渲染 HTML 之前调用（页面第一次加载或者普通回发）
        /// </summary>
        protected override void OnFirstPreRender()
        {
            base.OnFirstPreRender();


            #region Options

            //// 默认Layout
            //OB.AddProperty(OptionName.Layout, LayoutTypeName.GetName(Layout));

            //// 必须设置位置
            //OB.AddProperty("region", PositionHelper.GetName(Position));

            ////if (!String.IsNullOrEmpty(Margins))
            ////{
            ////    OB.AddProperty("margins", Margins);
            ////}

            //if (Split)
            //{
            //    OB.AddProperty("split", true);
            //}

            //if (EnableSplitTip)
            //{
            //    OB.AddProperty("useSplitTips", true);
            //    if (EnableCollapse)
            //    {
            //        if (!String.IsNullOrEmpty(CollapsibleSplitTip))
            //        {
            //            OB.AddProperty("collapsibleSplitTip", CollapsibleSplitTip);
            //        }
            //    }
            //    else
            //    {
            //        if (!String.IsNullOrEmpty(SplitTip))
            //        {
            //            OB.AddProperty("splitTip", SplitTip);
            //        }
            //    }
            //}

            //if (CollapseMode == CollapseMode.Mini)
            //{
            //    OB.AddProperty("collapseMode", CollapseModeName.GetName(CollapseMode));

            //}

            //if (!String.IsNullOrEmpty(CMargins))
            //{
            //    OB.AddProperty("cmargins", CMargins);
            //}

            
            #endregion

            #region oldcode

            //if (!String.IsNullOrEmpty(ContentPlaceHolderId))
            //{
            //    // 取得ContentPlaceHolder
            //    Control hoderControl = ControlUtil.FindControl(Page, ContentPlaceHolderId);

            //    // Clear Items
            //    OB.RemoveProperty(OptionName.Items);

            //    // 内容页面的控件列表
            //    foreach (Control c in hoderControl.Controls)
            //    {
            //        ControlBase component = c as ControlBase;
            //        if (component != null)
            //        {
            //            component.RenderImmediately = false;
            //            component.RefParentControl = this;

            //            FineUI.PanelBase panel = component as FineUI.PanelBase;
            //            if (panel != null)
            //            {
            //                panel.AutoHeight = false;
            //                panel.AutoWidth = false;
            //            }
            //        }
            //    }

            //    AddItemsToOB(hoderControl.Controls);

            //    #region old code
            //    //// 这中改变控件层级的做法不对
            //    //// 取得 ContentPlaceHolder 下面的所有控件
            //    //List<ControlBase> componentList = new List<ControlBase>();
            //    //for (int i = 0, count = hoderControl.Controls.Count; i < count; i++)
            //    //{
            //    //    ControlBase component = hoderControl.Controls[i] as ControlBase;
            //    //    if (component != null)
            //    //    {
            //    //        componentList.Add(component);
            //    //    }
            //    //}

            //    //// 把这些控件添加到 本控件的子控件
            //    //foreach (ControlBase c in componentList)
            //    //{
            //    //    c.RenderImmediately = false;

            //    //    Controls.Add(c);
            //    //}

            //    //// Add Items
            //    //AddItemsToOB();

            //    #endregion
            //}

            #endregion

            #region oldcode

            //if (!String.IsNullOrEmpty(SplitColor))
            //{
            //    AddPageFirstLoadAbsoluteScript(String.Format("Ext.get('{0}-xsplit').setStyle('background-color','{1}');", ClientID, SplitColor), 1000);
            //}

            //string renderScript = String.Empty;

            //if (!String.IsNullOrEmpty(SplitColor))
            //{
            //    renderScript += String.Format("Ext.get('{0}-xsplit').setStyle('background-color','{1}');", ClientID, SplitColor);
            //}

            //OB.Listeners.AddProperty("render", "function(component){" + renderScript + "}", true);

            #endregion

            string jsContent = String.Format("var {0}=Ext.create('Ext.panel.Panel',{1});", XID, OB.ToString());
            AddStartupScript(jsContent);


        }

        #endregion

        #region old code


        //#region ChildrenContentID

        //[Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //[Description("子控件的容器的样式类（Tab用到了）")]
        //protected override string ChildrenContentClass
        //{
        //    get
        //    {
        //        return "x-hide-display";
        //    }
        //}

        //#endregion

        //#region internal RenderChildrenAsContent

        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue(true)]
        //[Description("渲染子控件为容器内容")]
        //internal override bool RenderChildrenAsContent
        //{
        //    get
        //    {
        //        return true;
        //    }
        //}
        //#endregion

        //#region IStateManager Members

        //bool IStateManager.IsTrackingViewState
        //{
        //    get { return base.IsTrackingViewState; }
        //}

        //void IStateManager.LoadViewState(object state)
        //{
        //    base.LoadViewState(state);
        //}

        //object IStateManager.SaveViewState()
        //{
        //    return base.SaveViewState();
        //}

        //void IStateManager.TrackViewState()
        //{
        //    base.TrackViewState();
        //}

        //#endregion


        //#region SaveViewState/LoadViewState/TrackViewState

        //protected override object SaveViewState()
        //{
        //    object[] states = new object[2];

        //    states[0] = base.SaveViewState();

        //    states[1] = ((IStateManager)Rows).SaveViewState();

        //    return states;
        //}

        //protected override void LoadViewState(object savedState)
        //{
        //    if (savedState != null)
        //    {
        //        object[] states = (object[])savedState;

        //        base.LoadViewState(states[0]);

        //        ((IStateManager)Rows).LoadViewState(states[1]);
        //    }
        //}

        //protected override void TrackViewState()
        //{
        //    base.TrackViewState();

        //    ((IStateManager)Rows).TrackViewState();
        //}

        //#endregion 

        #endregion
    }
}
