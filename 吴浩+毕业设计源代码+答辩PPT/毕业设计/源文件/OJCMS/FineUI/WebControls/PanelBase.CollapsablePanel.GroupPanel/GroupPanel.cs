
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    GroupPanel.cs
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
    /// 分组面板控件
    /// </summary>
    [Designer("FineUI.Design.GroupPanelDesigner, FineUI.Design")]
    [ToolboxData("<{0}:GroupPanel Title=\"GroupPanel\" EnableCollapse=\"True\" runat=server><Items></Items></{0}:GroupPanel>")]
    [ToolboxBitmap(typeof(GroupPanel), "toolbox.GroupPanel.bmp")]
    [Description("分组面板控件")]
    [ParseChildren(true)]
    [PersistChildren(false)]
    [ControlBuilder(typeof(NotAllowWhitespaceLiteralsBuilder))]
    public class GroupPanel : CollapsablePanel
    {
        #region Unsupported Properties

        /// <summary>
        /// 不支持此属性
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override bool ShowHeader
        {
            get
            {
                return base.ShowHeader;
            }
        }

        /// <summary>
        /// 不支持此属性
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override bool ShowBorder
        {
            get
            {
                return base.ShowBorder;
            }
        }

        #endregion

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

        /// <summary>
        /// 布局类型
        /// </summary>
        [Category(CategoryName.LAYOUT)]
        [DefaultValue(Layout.Anchor)]
        [Description("布局类型")]
        public override Layout Layout
        {
            get
            {
                object obj = FState["Layout"];
                return obj == null ? Layout.Anchor : (Layout)obj;
            }
            set
            {
                FState["Layout"] = value;
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

            //ResourceManager.Instance.AddJavaScriptComponent("form");


            string jsContent = String.Format("var {0}=Ext.create('Ext.form.FieldSet',{1});", XID, OB.ToString());
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
