
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    Toolbar.cs
 * CreatedOn:   2008-05-30
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
    /// 工具条控件
    /// </summary>
    [Designer("FineUI.Design.ToolbarDesigner, FineUI.Design")]
    [ToolboxData("<{0}:Toolbar runat=\"server\"><Items></Items></{0}:Toolbar>")]
    [ToolboxBitmap(typeof(Toolbar), "toolbox.Toolbar.bmp")]
    [Description("工具条控件")]
    [ParseChildren(true)]
    [PersistChildren(false)]
    [ControlBuilder(typeof(NotAllowWhitespaceLiteralsBuilder))]
    public class Toolbar : BoxComponent
    {

        #region Properties


        //private bool IsPageMenu_Default = false;

        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue(false)]
        //[Description("是否页面菜单")]
        //public bool IsPageMenu
        //{
        //    get
        //    {
        //        object obj = BoxState["IsPageMenu"];
        //        return obj == null ? IsPageMenu_Default : (bool)obj;
        //    }
        //    set
        //    {
        //        BoxState["IsPageMenu"] = value;
        //    }
        //}

        /// <summary>
        /// 页脚工具栏的排列位置
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(ToolbarAlign.Left)]
        [Description("工具栏的排列位置")]
        public ToolbarAlign ToolbarAlign
        {
            get
            {
                object obj = FState["ToolbarAlign"];
                return obj == null ? ToolbarAlign.Left : (ToolbarAlign)obj;
            }
            set
            {
                FState["ToolbarAlign"] = value;
            }
        }



        /// <summary>
        /// 工具条的位置
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(ToolbarPosition.Top)]
        [Description("工具条的位置")]
        public virtual ToolbarPosition Position
        {
            get
            {
                object obj = FState["Position"];
                return obj == null ? ToolbarPosition.Top : (ToolbarPosition)obj;
            }
            set
            {
                FState["Position"] = value;
            }
        }


        #endregion

        #region Items

        private ControlBaseCollection _items;

        /// <summary>
        /// 工具条项集合
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Editor(typeof(ToolbarItemsEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public virtual ControlBaseCollection Items
        {
            get
            {
                if (_items == null)
                {
                    _items = new ControlBaseCollection(this);
                }
                return _items;
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
            //if (PropertyModified("Readonly"))
            //{
            //    sb.AppendFormat("{0}.setReadOnly({1});", XID, Readonly.ToString().ToLower());
            //}

            AddAjaxScript(sb);
        }

        /// <summary>
        /// 渲染 HTML 之前调用（页面第一次加载或者普通回发）
        /// </summary>
        protected override void OnFirstPreRender()
        {
            base.OnFirstPreRender();

            //ResourceManager.Instance.AddJavaScriptComponent("toolbar");

            #region Items

            // 重新设置Items
            if (Controls.Count > 0)
            {
                JsArrayBuilder ab = new JsArrayBuilder();
                foreach (Control item in Controls)
                {
                    if (item is ControlBase && item.Visible)
                    {
                        #region old code

                        //// 如果是分隔符
                        //if (item is ToolbarSeparator)
                        //{
                        //    ab.AddProperty("'-'", true);
                        //}
                        //else if (item is ToolbarText)
                        //{
                        //    ab.AddProperty(String.Format("'{0}'", (item as ToolbarText).Text), true);
                        //}
                        //if (item is ToolbarFill)
                        //{
                        //    ab.AddProperty("'->'", true);
                        //}
                        //else
                        //{
                        //ab.AddProperty(String.Format("{0}", (item as ControlBase).ClientJavascriptID), true);
                        //} 

                        #endregion

                        ab.AddProperty(String.Format("{0}", (item as ControlBase).XID), true);
                    }
                }

                if (ab.Count > 0)
                {
                    OB.AddProperty("items", ab.ToString(), true);
                }
            }


            #endregion


            JsObjectBuilder layoutOB = new JsObjectBuilder();
            layoutOB.AddProperty("pack", ToolbarAlignHelper.GetName(ToolbarAlign));

            OB.AddProperty("layout", layoutOB, true);

            OB.AddProperty("xtype", "toolbar");

            OB.AddProperty("dock", ToolbarPositionHelper.GetExtName(Position));

            //string jsContent = String.Format("var {0}=Ext.create('Ext.toolbar.Toolbar',{1});", XID, OB.ToString());

            //string jsContent = String.Format("var {0}={1};", XID, OB.GetProperty("items"));
            string jsContent = String.Format("var {0}={1};", XID, OB.ToString());

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
