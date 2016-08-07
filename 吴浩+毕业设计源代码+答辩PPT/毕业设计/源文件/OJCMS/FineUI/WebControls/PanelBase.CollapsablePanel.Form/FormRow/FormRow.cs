
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    FormRow.cs
 * CreatedOn:   2008-04-23
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
    /// 表单行控件
    /// </summary>
    [Designer("FineUI.Design.FormRowDesigner, FineUI.Design")]
    //[ToolboxData("<{0}:FormRow runat=\"server\"></{0}:FormRow>")]
    //[ToolboxBitmap(typeof(FormRow), "toolbox.FormRow.bmp")]
    //[Description("表单行控件")]
    [ToolboxItem(false)]
    [ParseChildren(true)]
    [PersistChildren(false)]
    [ControlBuilder(typeof(NotAllowWhitespaceLiteralsBuilder))]
    public class FormRow : Container
    {
        #region Unsupported Properties

        /// <summary>
        /// 不支持此属性
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Layout Layout
        {
            get
            {
                return Layout.Column;
            }
        }


        #endregion

        #region Properties

        ///// <summary>
        ///// 各列的宽度，空格分割
        ///// </summary>
        //[Category(CategoryName.OPTIONS)]
        //[NotifyParentProperty(true)]
        //[DefaultValue("")]
        //[Description("各列的宽度，空格分割")]
        //public string ColumnWidths
        //{
        //    get
        //    {
        //        object obj = FState["ColumnWidths"];
        //        return obj == null ? "" : (string)obj;
        //    }
        //    set
        //    {
        //        FState["ColumnWidths"] = ResolveColumnWidths(value);
        //    }
        //}

        /// <summary>
        /// 以空格分开的各列宽度（可以是像素数或者百分比，比如200px 50% 50%）
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [NotifyParentProperty(true)]
        [DefaultValue("")]
        [Description("以空格分开的各列宽度（可以是像素数或者百分比，比如200px 50% 50%）")]
        public string ColumnWidths
        {
            get
            {
                object obj = FState["ColumnWidths"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                FState["ColumnWidths"] = value;
            }
        }

        #endregion

        #region Items

        private ControlBaseCollection _items;

        /// <summary>
        /// 子控件集合
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Editor(typeof(ControlBaseItemsEditor), typeof(System.Drawing.Design.UITypeEditor))]
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


            OB.AddProperty("border", false);
            OB.AddProperty("header", false);

            Form parentForm = Parent as Form;
            if (parentForm == null)
            {
                return;
            }

            int formrowItemsSpace = Convert.ToInt32(parentForm.FormRowItemsSpace.Value);


            if (Items.Count > 0)
            {
                #region oldcode
                /*
                 * 增加中间的分割面板，会对显示隐藏表单字段造成影响
                int currentItemCount = 0;
                JsArrayBuilder ab = new JsArrayBuilder();
                foreach (ControlBase item in Items)
                {
                    if (item.Visible)
                    {
                        if (currentItemCount > 0)
                        {
                            OptionBuilder separatorOB = new OptionBuilder();
                            separatorOB.AddProperty("type", "panelbase");
                            separatorOB.AddProperty("width", 8);
                            ab.AddProperty(String.Format("{0}", separatorOB), true);
                        }
                        ab.AddProperty(String.Format("{0}", item.XID), true);
                        currentItemCount++;
                    }
                }
                OB.AddProperty("items", ab.ToString(), true);
                */

                #endregion

                // 为子项添加布局属性
                int columnCount = Items.Count;
                string defaultColumnWidthStr = (1.0 / columnCount).ToString("F2", System.Globalization.CultureInfo.InvariantCulture);
                List<string> columnWidths = GetTrimedColumnWidths();

                // 用户自定义ColumnWidths是否和Items的个数匹配
                bool isColumnWidthsMatch = false;
                if (columnWidths.Count == columnCount)
                {
                    isColumnWidthsMatch = true;
                }

                Dictionary<string, JsObjectBuilder> buttonOptions = new Dictionary<string, JsObjectBuilder>();
                for (int i = 0; i < columnCount; i++)
                {
                    var comp = Items[i] as Component;

                    // 如果FormRow的子项是 Button，则用一个面板将其包裹起来，否则按钮的宽度会很长
                    bool isbutton = false;
                    JsObjectBuilder buttonPanelOB = new JsObjectBuilder();
                    if (comp is Button)
                    {
                        isbutton = true;

                        buttonPanelOB.AddProperty("xtype", "panel");
                        buttonPanelOB.AddProperty("header", false);
                        buttonPanelOB.AddProperty("border", false);

                        buttonPanelOB.AddProperty("items", String.Format("[{0}]", comp.XID), true);
                    }

                    #region Component
                    if (comp != null)
                    {
                        // 不是最后一列的话，加上空白间隔
                        if (columnCount > 1 && i != columnCount - 1)
                        {
                            if (isbutton)
                            {
                                //buttonOB.AddProperty("marginRight", formrowItemsSpace);
                                buttonPanelOB.AddProperty("style", String.Format("margin-right:{0}px;", formrowItemsSpace));
                            }
                            else
                            {
                                //// 如果尚未设置 MarginRight
                                //if (comp.MarginRight == Unit.Empty)
                                //{
                                //    comp.MarginRight = Unit.Pixel(formrowItemsSpace);
                                //}
                                //if (String.IsNullOrEmpty(comp.Margin))
                                //{
                                //    comp.Margin = String.Format("0 {0} 0 0", formrowItemsSpace);
                                //}
                                comp.CssStyle += String.Format("margin-right:{0}px;", formrowItemsSpace);
                            }
                        }
                    }
                    #endregion

                    #region BoxComponent
                    var boxcomp = comp as BoxComponent;
                    if (boxcomp != null)
                    {
                        if (isColumnWidthsMatch)
                        {
                            string columnWidth = StringUtil.ConvertPercentageToDecimalString(columnWidths[i]);
                            if (Convert.ToDouble(columnWidth) <= 1.0)
                            {
                                if (isbutton)
                                {
                                    buttonPanelOB.AddProperty("columnWidth", columnWidth, true);
                                }
                                else
                                {
                                    boxcomp.ColumnWidth = columnWidth;
                                }
                            }
                            else
                            {
                                Unit unitColumnWidth = Unit.Parse(columnWidth);

                                if (isbutton)
                                {
                                    buttonPanelOB.AddProperty("width", unitColumnWidth.Value);
                                }
                                else
                                {
                                    boxcomp.Width = unitColumnWidth;
                                }
                            }
                        }
                        else
                        {
                            if (isbutton)
                            {
                                buttonPanelOB.AddProperty("columnWidth", defaultColumnWidthStr, true);
                            }
                            else
                            {
                                boxcomp.ColumnWidth = defaultColumnWidthStr;
                            }
                        }
                    }
                    #endregion

                    if (isbutton)
                    {
                        buttonOptions.Add(comp.XID, buttonPanelOB);
                    }
                }


                JsArrayBuilder ab = new JsArrayBuilder();
                foreach (ControlBase item in Items)
                {
                    if (item.Visible)
                    {
                        string itemXID = item.XID;
                        if (buttonOptions.ContainsKey(itemXID))
                        {
                            itemXID = buttonOptions[itemXID].ToString();
                        }

                        ab.AddProperty(itemXID, true);
                    }
                }
                OB.AddProperty("items", ab.ToString(), true);
            }

            // 自定义样式
            OB.AddProperty("cls", "f-formrow");

            string jsContent = String.Format("var {0}=Ext.create('Ext.panel.Panel',{1});", XID, OB.ToString());
            AddStartupScript(jsContent);
            
            ////// 目的：子控件的JS代码在父控件的前面
            ////AddStartupScript(this, String.Empty);
            //AddStartupScript(String.Empty);
        }


        private List<string> GetTrimedColumnWidths()
        {
            List<string> widths = new List<string>();
            foreach (string width in ColumnWidths.Split(' '))
            {
                string trimedWith = width.Trim();
                if (!String.IsNullOrEmpty(trimedWith))
                {
                    widths.Add(trimedWith);
                }
            }
            return widths;
        }

        #endregion

        #region private ResolveColumnWidths

        ///// <summary>
        ///// 格式化widths
        ///// </summary>
        ///// <param name="widths"></param>
        ///// <returns></returns>
        //private string ResolveColumnWidths(string widths)
        //{
        //    List<string> widthList = new List<string>();

        //    string[] widthArray = widths.Split(' ');
        //    foreach (string s in widthArray)
        //    {
        //        string tmp = s.Trim();
        //        if (!String.IsNullOrEmpty(tmp))
        //        {
        //            widthList.Add(ResolveColumnWidth(tmp));
        //        }
        //    }

        //    StringBuilder sb = new StringBuilder();
        //    foreach (string s in widthList)
        //    {
        //        sb.AppendFormat("{0} ", s);
        //    }

        //    return sb.ToString().TrimEnd();
        //}

        //private string ResolveColumnWidth(string width)
        //{
        //    string result = width;
        //    if (result.EndsWith("%"))
        //    {
        //        result = (Convert.ToInt32(width.TrimEnd('%')) * 0.01).ToString("F2", System.Globalization.CultureInfo.InvariantCulture);
        //    }
        //    else if (result.ToLower().EndsWith("px"))
        //    {
        //        result = result.ToLower().Substring(0, result.Length - 2);
        //    }

        //    return result;
        //}

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

        //#region readonly Items

        //private List<ControlBase> _items;

        ///// <summary>
        ///// 从AddParsedSubObject解析出来的内容
        ///// </summary>
        //internal List<ControlBase> Items
        //{
        //    get
        //    {
        //        if (_items == null)
        //        {
        //            _items = new List<ControlBase>();
        //        }

        //        return _items;
        //    }
        //}

        //#endregion

        // #region AddParsedSubObject

        //protected override void AddParsedSubObject(object obj)
        //{
        //    ControlBase c = obj as ControlBase;
        //    if (c != null)
        //    {
        //        c.RenderImmediately = false;
        //        base.AddParsedSubObject(c);

        //        Items.Add(c);
        //    }

        //}

        //  #endregion

        //#region override LoadViewState/SaveViewState

        //protected override void LoadViewState(object state)
        //{
        //    object[] states = (object[])state;

        //    base.LoadViewState(states[0]);

        //    for (int i = 0, count = Items.Count; i < count; i++)
        //    {
        //        ((IStateManager)Items[i]).LoadViewState(states[i + 1]);
        //    }
        //}

        //protected override object SaveViewState()
        //{
        //    object[] states = new object[Items.Count + 1];

        //    states[0] = base.SaveViewState();

        //    for (int i = 0, count = Items.Count; i < count; i++)
        //    {
        //        states[i + 1] = ((IStateManager)Items[i]).SaveViewState();
        //    }

        //    return states;
        //}

        //protected override void TrackViewState()
        //{
        //    base.TrackViewState();

        //    for (int i = 0, count = Items.Count; i < count; i++)
        //    {
        //        ((IStateManager)Items[i]).TrackViewState();
        //    }
        //}

        //#endregion

        //#region SetDirty

        //protected override void SetDirty()
        //{
        //    base.SetDirty();

        //    for (int i = 0, count = Items.Count; i < count; i++)
        //    {
        //        ((ISetDirty)Items[i]).SetDirty();
        //    }
        //}

        //#endregion 

        #endregion

        #region old code
        //#region Controls

        //private List<ControlBase> _controls;

        //public List<ControlBase> Controls
        //{
        //    get
        //    {
        //        if (_controls == null)
        //        {
        //            _controls = new List<ControlBase>();
        //        }
        //        return _controls;
        //    }
        //    set
        //    {
        //        _controls = value;
        //    }
        //}

        //#endregion

        //#region IParserAccessor Members

        //public void AddParsedSubObject(object obj)
        //{
        //    ControlBase control = obj as ControlBase;

        //    if (control != null)
        //    {
        //        Controls.Add(control);
        //    }
        //}

        //#endregion

        //#region override ViewState

        //public override void TrackViewState()
        //{
        //    base.TrackViewState();

        //    foreach (ControlBase control in Controls)
        //    {
        //        ((IStateManager)control).TrackViewState();
        //    }
        //}

        //public override object SaveViewState()
        //{
        //    int index = 0;
        //    foreach (ControlBase control in Controls)
        //    {
        //        BoxState["control" + index] = ((IStateManager)control).SaveViewState();

        //        index++;
        //    }

        //    return base.SaveViewState();
        //}

        //public override void LoadViewState(object state)
        //{
        //    base.LoadViewState(state);

        //    int index = 0;
        //    foreach (ControlBase control in Controls)
        //    {
        //        ((IStateManager)control).LoadViewState(BoxState["control" + index]);

        //        index++;
        //    }
        //}


        //#endregion 
        #endregion

        #region old code

        #region Properties

        //private int? ColumnCount_Default = null;

        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue(null)]
        //[Description("本行有几列")]
        //public int? ColumnCount
        //{
        //    get
        //    {
        //        object obj = BoxState["ColumnCount"];
        //        return obj == null ? ColumnCount_Default : (int?)obj;
        //    }
        //    set
        //    {
        //        BoxState["ColumnCount"] = value;
        //    }
        //}

        #endregion

        #region old code

        //#region AddParsedSubObject

        //protected override void AddParsedSubObject(object obj)
        //{
        //    ControlBase c = obj as ControlBase;
        //    if (c != null)
        //    {
        //        c.RenderImmediately = false;
        //        base.AddParsedSubObject(c);
        //    }
        //}

        //#endregion

        //#region OnPreRender

        //protected override void OnPreRender(EventArgs e)
        //{
        //    base.OnPreRender(e);

        //    AddStartupScript(this, String.Empty);
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

        #endregion

        #region old code

        //#region Fields

        //private FieldCollection _fields;

        //[Category(CategoryName.OPTIONS)]
        //[NotifyParentProperty(true)]
        //[PersistenceMode(PersistenceMode.InnerDefaultProperty)]
        //public virtual FieldCollection Fields
        //{
        //    get
        //    {
        //        if (_fields == null)
        //        {
        //            _fields = new FieldCollection();
        //        }
        //        return _fields;
        //    }
        //}
        //#endregion



        #endregion

        #endregion



    }
}
