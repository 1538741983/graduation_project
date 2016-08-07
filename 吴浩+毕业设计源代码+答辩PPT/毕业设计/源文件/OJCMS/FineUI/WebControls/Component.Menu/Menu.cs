﻿
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    Menu.cs
 * CreatedOn:   2008-07-11
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
    /// 菜单控件
    /// </summary>
    [Designer("FineUI.Design.MenuDesigner, FineUI.Design")]
    [ToolboxData("<{0}:Menu runat=\"server\"></{0}:Menu>")]
    [ToolboxBitmap(typeof(Menu), "toolbox.Menu.bmp")]
    [Description("菜单控件")]
    [ParseChildren(true, "Items")]
    [PersistChildren(false)]
    [ControlBuilder(typeof(NotAllowWhitespaceLiteralsBuilder))]
    public class Menu : Component
    {
        #region Properties

        /// <summary>
        /// 不向页面输出控件的外部容器
        /// </summary>
        internal override bool RenderWrapperNode
        {
            get
            {
                return false;
            }
        }


        #endregion

        #region Items

        private MenuItemCollection _items;

        /// <summary>
        /// 菜单项集合
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerDefaultProperty)]
        [Editor(typeof(MenuItemsEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public virtual MenuItemCollection Items
        {
            get
            {
                if (_items == null)
                {
                    _items = new MenuItemCollection(this);
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

            //if (Items.Count > 0)
            //{
            //    ResourceManager.Instance.AddJavaScriptComponent("menu");
            //}

            #region Items

            if (Items.Count > 0)
            {
                JsArrayBuilder ab = new JsArrayBuilder();
                foreach (BaseMenuItem item in Items)
                {
                    if (item.Visible)
                    {
                        ab.AddProperty(String.Format("{0}", item.XID), true);
                    }

                    //if (item.Visible)
                    //{
                    //    ab.AddProperty(String.Format("{0}", item.ClientJavascriptID), true);
                    //}

                    //// 如果Item是否显示隐藏发生变化
                    //if (HashCodeChanged(item.ID + "", item.Visible))
                    //{
                    //    if (item.Visible)
                    //    {
                    //        item.AjaxForceCompleteUpdate = true;

                    //        AddAjaxPartialUpdateScript(String.Format("{0}.insert({1},X.{2});", ClientJavascriptID, ab.Count - 1, item.ClientJavascriptID));
                    //    }
                    //    else
                    //    {
                    //        AddAjaxPartialUpdateScript(String.Format("{0}.remove(X.{1});", ClientJavascriptID, item.ClientJavascriptID));
                    //    }
                    //}
                }

                if (ab.Count > 0)
                {
                    OB.AddProperty("items", ab.ToString(), true);
                }
            }

            #region old code

            //if (HashCodeChanged("Items", itemsString))
            //{
            //    StringBuilder ajaxUpdateBuilder = new StringBuilder();

            //    StringBuilder preUpdateBuilder = new StringBuilder();
            //    ajaxUpdateBuilder.AppendFormat("{0}.removeAll();", ClientJavascriptID);
            //    foreach (BaseMenuItem item in Items)
            //    {
            //        if (item.Visible)
            //        {
            //            if (item is MenuSeparator)
            //            {
            //                ajaxUpdateBuilder.AppendFormat("{0}.addSeparator();", ClientJavascriptID);
            //            }
            //            else if (item is MenuText)
            //            {
            //                ajaxUpdateBuilder.AppendFormat("{0}.addText({1});", ClientJavascriptID, JsHelper.Enquote((item as MenuText).Text));
            //            }
            //            else
            //            {
            //                preUpdateBuilder.AppendFormat("{0}_config=X.{0}.cloneConfig();", item.ClientJavascriptID);
            //                ajaxUpdateBuilder.AppendFormat("{1}=new Ext.menu.Item(X.{1}_config);X.{0}.addItem(X.{1});", ClientJavascriptID, item.ClientJavascriptID);
            //            }
            //        }
            //    }

            //    AddAjaxPartialUpdateScript(preUpdateBuilder.ToString() + ajaxUpdateBuilder.ToString());
            //} 
            #endregion

            #endregion


            if (Items.Count > 0)
            {
                string jsContent = String.Format("var {0}=Ext.create('Ext.menu.Menu',{1});", XID, OB.ToString());
                AddStartupScript(jsContent);
            }

        }

        #endregion

    }
}
