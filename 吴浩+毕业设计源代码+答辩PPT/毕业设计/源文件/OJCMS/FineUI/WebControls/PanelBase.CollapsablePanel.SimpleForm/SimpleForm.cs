
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    SimpleForm.cs
 * CreatedOn:   2008-04-22
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
    /// 简单的表单容器控件
    /// </summary>
    [Designer("FineUI.Design.SimpleFormDesigner, FineUI.Design")]
    [ToolboxData("<{0}:SimpleForm Title=\"SimpleForm\" BodyPadding=\"5px\" runat=server><Items></Items></{0}:SimpleForm>")]
    [ToolboxBitmap(typeof(SimpleForm), "toolbox.SimpleForm.bmp")]
    [Description("简单的表单容器控件")]
    [ParseChildren(true)]
    [PersistChildren(false)]
    [ControlBuilder(typeof(NotAllowWhitespaceLiteralsBuilder))]
    public class SimpleForm : FormBase
    {
        #region Constructor

        /// <summary>
        /// 构造函数
        /// </summary>
        public SimpleForm()
        {
            AddServerAjaxProperties();
            AddClientAjaxProperties();
        }

        #endregion

        #region Unsupported Properties



        #endregion

        #region Properties

        ///// <summary>
        ///// 表单字段上按回车键触发的提交按钮
        ///// </summary>
        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue("")]
        //[Description("表单字段上按回车键触发的提交按钮")]
        //public string SubmitButton
        //{
        //    get
        //    {
        //        object obj = FState["SubmitButton"];
        //        return obj == null ? String.Empty : (string)obj;
        //    }
        //    set
        //    {
        //        FState["SubmitButton"] = value;
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

            //ResourceManager.Instance.AddJavaScriptComponent("form");

            #region Options




            #endregion

            //OptionBuilder defaultsOB = new OptionBuilder();
            //defaultsOB.Listeners.AddProperty("click", JsHelper.GetFunction("alert('ss');F.util.setPageStateChanged();"), true);
            //OB.AddProperty("defaults", defaultsOB);

            //OB.Listeners.AddProperty("dirtychange", JsHelper.GetFunction("F.util.setPageStateChanged(dirty);", "form", "dirty"), true);
            AddListener("dirtychange", "F.util.setPageStateChanged(dirty);", "form", "dirty");

            //if (!String.IsNullOrEmpty(SubmitButton))
            //{
            //    Control control = ControlUtil.FindControl(SubmitButton);
            //    if (control != null && control is ControlBase)
            //    {
            //        OB.Listeners.AddProperty("render", JsHelper.GetFunction("F.util.formEnterKey(form,'" + control.ClientID + "');", "form"), true);
            //    }
            //}

            /*
            Ext.override(Ext.form.Panel, {
                listeners: {
                    render: function () {
                        Ext.create('Ext.util.KeyNav', this.el, {
                            "enter": function (e) {
                                var el = Ext.Element.getActiveElement();
                                if (el.type != 'textarea') {
                                    var b = Ext.DomQuery.select('div[id=' + this.getId() + ']');
                                    var a = Ext.DomQuery.select('*[type=submit]', b[0]);
                                    if (a[0]) {
                                        a[0].click();
                                    }
                                } else {
                                    // The user is in a textarea in the form so this feature
                                    // is diabled to allow for character returns
                                    // in field data.
                                }
                            },
                            scope: this
                        });
                    }
                }
            });
            */


            string jsContent = String.Format("var {0}=Ext.create('Ext.form.Panel',{1});", XID, OB.ToString());
            AddStartupScript(jsContent);

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
        //        }
        //        return _items;
        //    }
        //}

        //#endregion

        //#region CreateChildControls

        //protected override void CreateChildControls()
        //{
        //    base.CreateChildControls();


        //    //// 添加子控件
        //    //foreach (ControlBase item in Items)
        //    //{
        //    //    item.RenderWrapperDiv = false;
        //    //    Controls.Add(item);
        //    //}
        //}

        #endregion

        #region oldcode

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

        //#region Fields

        //private FieldCollection _fields;

        //[Category(CategoryName.OPTIONS)]
        //[NotifyParentProperty(true)]
        //[PersistenceMode(PersistenceMode.InnerDefaultProperty)]
        //[Browsable(false)]
        //[Description("表单字段集合")]
        //public virtual FieldCollection Fields
        //{
        //    get
        //    {
        //        if (_fields == null)
        //        {
        //            _fields = new FieldCollection();

        //            if (base.IsTrackingViewState)
        //            {
        //                ((IStateManager)_fields).TrackViewState();
        //            }
        //        }
        //        return _fields;
        //    }
        //}
        //#endregion 

        //#region SaveViewState/LoadViewState/TrackViewState

        //protected override object SaveViewState()
        //{
        //    object[] states = new object[] { base.SaveViewState(), ((IStateManager)Fields).SaveViewState() };

        //    return states;
        //}

        //protected override void LoadViewState(object savedState)
        //{
        //    if (savedState != null)
        //    {
        //        object[] states = (object[])savedState;

        //        base.LoadViewState(states[0]);

        //        ((IStateManager)Fields).LoadViewState(states[1]);
        //    }
        //}

        //protected override void TrackViewState()
        //{
        //    base.TrackViewState();

        //    ((IStateManager)Fields).TrackViewState();
        //}

        //#endregion

        #endregion

    }
}
