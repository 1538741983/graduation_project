
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    Panel.cs
 * CreatedOn:   2008-04-21
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
    /// 面板控件
    /// </summary>
    [Designer("FineUI.Design.PanelDesigner, FineUI.Design")]
    [ToolboxData("<{0}:Panel Title=\"Panel\" BodyPadding=\"5px\" ShowHeader=\"true\" ShowBorder=\"true\" runat=\"server\"><Items></Items></{0}:Panel>")]
    [ToolboxBitmap(typeof(Panel), "toolbox.Panel.bmp")]
    [Description("面板控件")]
    [ParseChildren(true)]
    [PersistChildren(false)]
    [ControlBuilder(typeof(NotAllowWhitespaceLiteralsBuilder))]
    public class Panel : CollapsablePanel
    {

        #region Properties


        //private HtmlGenericControl _contentControl;
        ///// <summary>
        ///// 创建的Content控件
        ///// </summary>
        //protected HtmlGenericControl ContentControl
        //{
        //    get
        //    {
        //        if (_contentControl == null)
        //        {
        //            _contentControl = new HtmlGenericControl("div");
        //            _contentControl.ID = "content";
        //        }

        //        return _contentControl;
        //    }
        //} 

        #endregion

        #region oldcodes

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


            
            //OB.AddProperty(OptionName.Layout, LayoutTypeName.GetName(LayoutType.Fit));

            string jsContent = String.Format("var {0}=Ext.create('Ext.panel.Panel',{1});", XID, OB.ToString());
            AddStartupScript(jsContent);

        }

        #endregion

        #region old code

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
