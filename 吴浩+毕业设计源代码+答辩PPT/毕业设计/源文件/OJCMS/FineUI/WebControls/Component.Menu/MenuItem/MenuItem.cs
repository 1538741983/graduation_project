﻿
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    MenuItem.cs
 * CreatedOn:   2008-07-12
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
    /// 菜单项控件基类（抽象类）
    /// </summary>
    [ToolboxData("<{0}:MenuItem runat=\"server\"></{0}:MenuItem>")]
    [ToolboxBitmap(typeof(MenuItem), "toolbox.MenuItem.bmp")]
    [Description("菜单项控件基类")]
    [ControlBuilder(typeof(NotAllowWhitespaceLiteralsBuilder))]
    [ParseChildren(true)]
    [PersistChildren(false)]
    public abstract class MenuItem : BaseMenuItem
    {
        #region Properties

        /// <summary>
        /// 点击时隐藏菜单，可以配合使用CssStyle=cursor:default;
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("点击时隐藏菜单，可以配合使用CssStyle=cursor:default;")]
        public bool HideOnClick
        {
            get
            {
                object obj = FState["HideOnClick"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                FState["HideOnClick"] = value;
            }
        }


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
        /// 预定义图标
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(Icon.None)]
        [Description("预定义图标")]
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

        /// <summary>
        /// 文本
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("文本")]
        public virtual string Text
        {
            get
            {
                object obj = FState["Text"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                FState["Text"] = value;
            }
        }

        #endregion

        #region Menu

        private Menu _menu;

        /// <summary>
        /// 上下文菜单
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("上下文菜单")]
        public Menu Menu
        {
            get
            {
                if (_menu == null)
                {
                    _menu = new Menu();
                }
                return _menu;
            }
        }

        //private MenuCollection _menus;

        //[Category(CategoryName.OPTIONS)]
        //[NotifyParentProperty(true)]
        //[PersistenceMode(PersistenceMode.InnerProperty)]
        //public virtual MenuCollection Menus
        //{
        //    get
        //    {
        //        if (_menus == null)
        //        {
        //            _menus = new MenuCollection(this);
        //        }
        //        return _menus;
        //    }
        //}

        //private Menu _menu;

        //[Category(CategoryName.OPTIONS)]
        //[NotifyParentProperty(true)]
        //[PersistenceMode(PersistenceMode.InnerDefaultProperty)]
        //public virtual Menu Menu
        //{
        //    get
        //    {
        //        if (_menu == null)
        //        {
        //            _menu = new Menu();

        //            _menu.RenderWrapperDiv = false;
        //            Controls.Add(_menu);
        //        }
        //        return _menu;
        //    }
        //}
        #endregion

        #region CreateChildControls

        /// <summary>
        /// 添加子控件
        /// </summary>
        protected override void CreateChildControls()
        {
            base.CreateChildControls();

            //Menu.RenderWrapperNode = false;
            Controls.Add(Menu);
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

            
            #region options

            OB.AddProperty("text", Text);

            if (!String.IsNullOrEmpty(IconUrl))
            {
                OB.AddProperty("icon", ResolveUrl(IconUrl));
            }


            // 默认是点击就隐藏
            if (!HideOnClick) OB.AddProperty("hideOnClick", false);


            #endregion

            #region Menu

            //if (Menus.Count > 0)
            //{
            //    // 一个Button只能有一个Menu
            //    OB.AddProperty("menu", String.Format("{0}", Menus[0].XID), true);
            //}

            if (Menu.Items.Count > 0)
            {
                OB.AddProperty("menu", String.Format("{0}", Menu.XID), true);
            }

            //if (Menu != null && Menu.Items.Count > 0)
            //{
            //    OB.AddProperty(OptionName.Menu, String.Format("{0}", Menu.ClientJavascriptID), true);
            //}

            #endregion

        }

        #endregion
    }
}
