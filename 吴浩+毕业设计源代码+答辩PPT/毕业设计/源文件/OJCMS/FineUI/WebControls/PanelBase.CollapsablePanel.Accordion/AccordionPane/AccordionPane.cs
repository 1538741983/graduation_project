﻿
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    AccordionPanel.cs
 * CreatedOn:   2008-06-16
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
    /// 手风琴面板控件
    /// </summary>
    [Designer("FineUI.Design.AccordionPaneDesigner, FineUI.Design")]
    [ToolboxData("<{0}:AccordionPane Title=\"AccordionPane\" runat=\"server\"></{0}:AccordionPane>")]
    [ToolboxBitmap(typeof(AccordionPane), "toolbox.AccordionPane.bmp")]
    [Description("手风琴面板控件")]
    [ParseChildren(true)]
    [PersistChildren(false)]
    [ControlBuilder(typeof(NotAllowWhitespaceLiteralsBuilder))]
    public class AccordionPane : CollapsablePanel
    {
        #region Constructor

        /// <summary>
        /// 构造函数
        /// </summary>
        public AccordionPane()
        {
            AddServerAjaxProperties();
            AddClientAjaxProperties();
        }

        #endregion

        #region static readonly

        //private static readonly string ACCORDION_HEADER_SELECT = "f-accordion-hd-select";
        //private static readonly string ACCORDION_HEADER_HOVER = "f-accordion-hd-hover";

        #endregion

        #region Unsupported Properties

        /// <summary>
        /// 不支持此属性
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override bool EnableCollapse
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// 不支持此属性
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override bool ShowHeader
        {
            get
            {
                return true;
            }
        }

        #endregion

        #region Properties

        ///// <summary>
        ///// [AJAX属性]是否折叠
        ///// </summary>
        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue(true)]
        //[Description("[AJAX属性]是否折叠")]
        //public override bool Collapsed
        //{
        //    get
        //    {
        //        object obj = FState["Collapsed"];
        //        return obj == null ? true : (bool)obj;
        //    }
        //    set
        //    {
        //        FState["Collapsed"] = value;
        //    }
        //}


        /// <summary>
        /// 鼠标移到标题栏是否高亮显示
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("鼠标移到标题栏是否高亮显示")]
        public bool EnableHightlight
        {
            get
            {
                object obj = FState["EnableHightlight"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                FState["EnableHightlight"] = value;
            }
        }


        #endregion

        #region Links

        //private AccordionLinkCollection _links;

        //[Category(CategoryName.OPTIONS)]
        //[NotifyParentProperty(true)]
        //[PersistenceMode(PersistenceMode.InnerProperty)]
        //public virtual AccordionLinkCollection Links
        //{
        //    get
        //    {
        //        if (_links == null)
        //        {
        //            _links = new AccordionLinkCollection(this);
        //        }
        //        return _links;
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



            #region Check Parent
            Accordion parentControl = Parent as Accordion;
            if (parentControl == null)
            {
                throw new Exception("AccordionPane must inside the control Accordion!");
            }

            
            if (parentControl.AutoPostBack)
            {
                //OB.Listeners.AddProperty("expand", JsHelper.GetFunction(parentControl.GetPostBackEventReference("PaneIndexChanged")), true);
                AddListener("expand", parentControl.GetPostBackEventReference("PaneIndexChanged"));
            }

            #endregion


            //#region AutoHeight


            //// 如果要充满整个Accordion，则设置每个AccordionPanel的AutoHeight=false
            //if (parentControl.EnableFill)
            //{
            //    OB.AddProperty("autoHeight", false);
            //}


            //#endregion

            string renderScript = String.Empty;

            #region oldcode


            //// 如果启用高亮显示选中的，则在每个AccordionPanel的折叠展开时都要改变高亮选中的状态
            //if (EnableLargeHeader && EnableHightlight)
            //{
            //    renderScript += String.Format("{0}.header.addClassOnOver('{1}');", XID, ACCORDION_HEADER_HOVER);

            //    // 如果这个AccordionPanel需要高亮显示
            //    if (parentControl.ActiveIndex >= 0 && parentControl.ActiveIndex < parentControl.Panes.Count)
            //    {
            //        if (parentControl.Panes[parentControl.ActiveIndex] == this)
            //        {
            //            //OB.AddProperty(OptionName.Cls, ACCORDION_BIG_HEADER_SELECT_CLASS);
            //            renderScript += String.Format("{0}.header.addClass('{1}');", XID, ACCORDION_HEADER_SELECT);
            //        }
            //    }

            //    OB.Listeners.RemoveProperty("collapse");
            //    OB.Listeners.RemoveProperty("expand");
            //    OB.Listeners.AddProperty("collapse", String.Format("function(panel){{Ext.get('{0}').dom.value=true;X.{1}.header.removeClass('{2}');}}", CollapsedHiddenFieldID, XID, ACCORDION_HEADER_SELECT), true);
            //    OB.Listeners.AddProperty("expand", String.Format("function(panel){{Ext.get('{0}').dom.value=false;X.{1}.header.addClass('{2}');}}", CollapsedHiddenFieldID, XID, ACCORDION_HEADER_SELECT), true);

            //}


            #endregion

            #region Links

            //if (Links.Count > 0)
            //{
            //    OB.RemoveProperty("items");

            //    StringBuilder sb = new StringBuilder();

            //    sb.Append("<ul class=\"f-accrodion-link-ul\">");
            //    foreach (AccordionLink link in Links)
            //    {
            //        #region li

            //        HtmlNodeBuilder nb = new HtmlNodeBuilder("a");

            //        nb.SetProperty("id", link.ClientID);
            //        if (!String.IsNullOrEmpty(link.OnClientClick))
            //        {
            //            nb.SetProperty("onclick", String.Format("javascript:{0}", link.OnClientClick));
            //        }
            //        if (!String.IsNullOrEmpty(link.NavigateUrl))
            //        {
            //            nb.SetProperty("href", ResolveUrl(link.NavigateUrl));
            //            if (!String.IsNullOrEmpty(link.Target))
            //            {
            //                nb.SetProperty("target", link.Target);
            //            }
            //        }
            //        nb.SetProperty("style", "display:block;cursor:pointer;");

            //        string content = String.Empty;
            //        if (!String.IsNullOrEmpty(link.IconUrl))
            //        {
            //            content += String.Format("<img src=\"{0}\" align=\"bottom\" alt=\"\" />", ResolveUrl(link.IconUrl));
            //        }
            //        content += "&nbsp;" + link.Text;
            //        nb.InnerProperty = content;

            //        #endregion

            //        sb.AppendFormat("<li {1}>{0}</li>", nb.ToString(), link.Selected ? "class=\"f-accrodion-link-select\"" : "");
            //    }
            //    sb.Append("</ul>");

            //    OB.AddProperty("html", sb.ToString());





            //    // 注册所有链接的脚本
            //    // 所有的li，鼠标移动上去是一种样式，鼠标移开又是另外一种样式
            //    string hoverScript = "ele = Ext.get(ele);";
            //    hoverScript += "ele.on('mouseover',function(){Ext.get(this.findParentNode('li')).addClass('box-accrodion-link-hover');},ele);";
            //    hoverScript += "ele.on('mouseout',function(){Ext.get(this.findParentNode('li')).removeClass('box-accrodion-link-hover');},ele);";

            //    //string clickScript = String.Empty;
            //    //clickScript += String.Format("Ext.each(X.{0}.el.query('ul.box-accrodion-link-ul li'),function(ele){{Ext.get(ele).removeClass('box-accrodion-link-select');}});", parentControl.ClientJavascriptID);
            //    //clickScript += "Ext.get('{0}').addClass('box-accrodion-link-select');";

            //    string clickScript = String.Format("function(){{X.{0}.box_active(ele.id);}}", parentControl.XID);
            //    hoverScript += "ele.on('click'," + clickScript + ");";

            //    renderScript += String.Format("Ext.each(X.{0}.el.query('ul.box-accrodion-link-ul li a'),function(ele){{{1}}});", XID, hoverScript);
            //}

            #endregion

            if (!String.IsNullOrEmpty(renderScript))
            {
                renderScript = JsHelper.GetDeferScript(renderScript, 100);
                //OB.Listeners.AddProperty("render", JsHelper.GetFunction(renderScript), true);
                AddListener("render", renderScript);
            }

            string jsContent = String.Format("var {0}=Ext.create('Ext.panel.Panel',{1});", XID, OB.ToString());
            AddStartupScript(jsContent);

        }

        #endregion

    }
}
