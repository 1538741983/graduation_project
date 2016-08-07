
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    DropDownList.cs
 * CreatedOn:   2008-04-24
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
using System.Collections;
using System.Data;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel.Design;

namespace FineUI
{
    /// <summary>
    /// 下拉列表控件
    /// </summary>
    [Designer("FineUI.Design.DropDownListDesigner, FineUI.Design")]
    [ToolboxData("<{0}:DropDownList Label=\"Label\" runat=\"server\"></{0}:DropDownList>")]
    [ToolboxBitmap(typeof(DropDownList), "toolbox.DropDownList.bmp")]
    [Description("下拉列表控件")]
    [ParseChildren(true, DefaultProperty = "Items")]
    [PersistChildren(false)]
    [DefaultEvent("SelectedIndexChanged")]
    [ControlBuilder(typeof(NotAllowWhitespaceLiteralsBuilder))]
    public class DropDownList : TextField, IPostBackDataHandler
    {
        #region Constructor

        /// <summary>
        /// 构造函数
        /// </summary>
        public DropDownList()
        {
            AddServerAjaxProperties("F_Items");
            AddClientAjaxProperties("SelectedValue", "SelectedValueArray", "Text");

            AddGzippedAjaxProperties("F_Items");
        }

        #endregion

        #region SelectedIndex/SelectedValue/SelectedItem


        /// <summary>
        /// 文本框为空时显示的文本
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("文本框为空时显示的文本")]
        public virtual string EmptyText
        {
            get
            {
                object obj = FState["EmptyText"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                FState["EmptyText"] = value;
            }
        }


        /// <summary>
        /// [AJAX属性]用户输入的文本（只有在允许编辑和不强制选择的情况下才有效）
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("[AJAX属性]用户输入的文本（只有在允许编辑和不强制选择的情况下才有效）")]
        public string Text
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


        /// <summary>
        /// [AJAX属性]选中项的值
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [Description("[AJAX属性]选中项的值")]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string SelectedValue
        {
            get
            {
                string value = null;
                if (SelectedItem == null)
                {
                    /*
                    // 如果强制选择一项，我们可能需要选中第一项
                    if (AutoSelectFirstItem)
                    {
                        if (Items.Count > 0)
                        {
                            SelectedIndex = 0;
                            // If SelectedValue is null, then we select the first item of the list.
                            value = Items[0].Value;
                        }
                    }
                    */
                }
                else
                {
                    value = SelectedItem.Value;
                }
                return value;
            }
            set
            {
                foreach (ListItem item2 in Items)
                {
                    item2.Selected = false;
                }

                if (value != null)
                {
                    ListItem item = Items.FindByValue(value);
                    if (item != null)
                    {
                        item.Selected = true;
                    }
                }
            }
        }

        /// <summary>
        /// [AJAX属性]选中项的索引
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [Description("[AJAX属性]选中项的索引")]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SelectedIndex
        {
            get
            {
                //if (!Page.IsPostBack)
                //{
                //    // 获取参数前先尝试修正数据
                //    ProcessAutoSelectFirstItem();
                //}


                int selectedIndex = -1;
                for (int i = 0, count = Items.Count; i < count; i++)
                {
                    if (Items[i].Selected)
                    {
                        selectedIndex = i;
                        break;
                    }
                }

                //// 自动修正（仅在页面第一次加载时有效）
                //if (selectedIndex == -1 && AutoSelectFirstItem && !Page.IsPostBack && Items.Count > 0)
                //{
                //    selectedIndex = 0;
                //}
                // 自动修正（仅在页面第一次加载时有效），但是不改变Items属性
                if (selectedIndex == -1 && AutoSelectFirstItem && !Page.IsPostBack && Items.Count > 0)
                {
                    selectedIndex = 0;
                }

                return selectedIndex;
            }
            set
            {
                if (value >= 0 && value < Items.Count)
                {
                    foreach (ListItem item in Items)
                    {
                        item.Selected = false;
                    }

                    Items[value].Selected = true;
                }
            }
        }

        /// <summary>
        /// 选中项的文本
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [Description("选中项的文本")]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string SelectedText
        {
            get
            {
                if (SelectedItem != null)
                {
                    return SelectedItem.Text;
                }
                return null;
            }
        }

        /// <summary>
        /// 选中项
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [Description("选中项")]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ListItem SelectedItem
        {
            get
            {
                int selectedIndex = SelectedIndex;
                if (selectedIndex >= 0 && selectedIndex < Items.Count)
                {
                    return Items[selectedIndex];
                }
                return null;
            }
        }

        #endregion

        #region SelectedIndexArray/SelectedValueArray/SelectedItemArray

        /// <summary>
        /// [AJAX属性]选中项的值
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [Description("[AJAX属性]选中项的值")]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string[] SelectedValueArray
        {
            get
            {
                //if (!Page.IsPostBack)
                //{
                //    // 获取参数前先尝试修正数据
                //    ProcessAutoSelectFirstItem();
                //}

                List<string> selectedValues = new List<string>();
                for (int i = 0, count = Items.Count; i < count; i++)
                {
                    ListItem item = Items[i];
                    if (item.Selected)
                    {
                        selectedValues.Add(item.Value);
                    }
                }

                /*
                // 如果强制选择一项，我们可能需要选中第一项
                if (selectedValues.Count == 0 && AutoSelectFirstItem)
                {
                    if (Items.Count > 0)
                    {
                        SelectedIndex = 0;
                        selectedValues.Add(Items[0].Value);
                    }
                }
                */
                // 自动修正（仅在页面第一次加载时有效），但是不改变Items属性
                if (selectedValues.Count == 0 && AutoSelectFirstItem && !Page.IsPostBack && Items.Count > 0)
                {
                    selectedValues.Add(Items[0].Value);
                }

                return selectedValues.ToArray();
            }
            set
            {
                List<string> selectedValues = new List<string>(value);
                for (int i = 0, count = Items.Count; i < count; i++)
                {
                    ListItem item = Items[i];
                    if (selectedValues.Contains(item.Value))
                    {
                        item.Selected = true;
                    }
                    else
                    {
                        item.Selected = false;
                    }
                }
            }
        }


        /// <summary>
        /// [AJAX属性]选中项的索引
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [Description("[AJAX属性]选中项的索引")]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int[] SelectedIndexArray
        {
            get
            {
                //if (!Page.IsPostBack)
                //{
                //    // 获取参数前先尝试修正数据
                //    ProcessAutoSelectFirstItem();
                //}

                List<int> selectedIndexs = new List<int>();
                for (int i = 0, count = Items.Count; i < count; i++)
                {
                    if (Items[i].Selected)
                    {
                        selectedIndexs.Add(i);
                    }
                }

                // 自动修正（仅在页面第一次加载时有效），但是不改变Items属性
                if (selectedIndexs.Count == 0 && AutoSelectFirstItem && !Page.IsPostBack && Items.Count > 0)
                {
                    selectedIndexs.Add(0);
                }

                return selectedIndexs.ToArray();
            }
            set
            {
                List<int> selectedIndexs = new List<int>(value);
                for (int i = 0, count = Items.Count; i < count; i++)
                {
                    if (selectedIndexs.Contains(i))
                    {
                        Items[i].Selected = true;
                    }
                    else
                    {
                        Items[i].Selected = false;
                    }
                }
            }
        }

        /// <summary>
        /// 选中项
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [Description("选中项")]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ListItem[] SelectedItemArray
        {
            get
            {
                //if (!Page.IsPostBack)
                //{
                //    // 获取参数前先尝试修正数据
                //    ProcessAutoSelectFirstItem();
                //}

                List<ListItem> selectedItems = new List<ListItem>();
                for (int i = 0, count = Items.Count; i < count; i++)
                {
                    ListItem item = Items[i];
                    if (item.Selected)
                    {
                        selectedItems.Add(item);
                    }
                }

                // 自动修正（仅在页面第一次加载时有效），但是不改变Items属性
                if (selectedItems.Count == 0 && AutoSelectFirstItem && !Page.IsPostBack && Items.Count > 0)
                {
                    selectedItems.Add(Items[0]);
                }

                return selectedItems.ToArray();
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// 下拉列表和字段的宽度相匹配
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("下拉列表和字段的宽度相匹配")]
        public bool MatchFieldWidth
        {
            get
            {
                object obj = FState["MatchFieldWidth"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                FState["MatchFieldWidth"] = value;
            }
        }




        /// <summary>
        /// 如果未定义选中项，则自动选中第一个子项（默认为true）
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("如果未定义选中项，则自动选中第一个子项（默认为true）")]
        public bool AutoSelectFirstItem
        {
            get
            {
                object obj = FState["AutoSelectFirstItem"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                FState["AutoSelectFirstItem"] = value;
            }
        }


        /// <summary>
        /// 是否可以选择多项
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("是否可以选择多项")]
        public bool EnableMultiSelect
        {
            get
            {
                object obj = FState["EnableMultiSelect"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                FState["EnableMultiSelect"] = value;
            }
        }


        private const string MULTISELECT_SEPARATOR_DEFAULT = ", ";

        /// <summary>
        /// 选择多项的分隔符
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(typeof(string), MULTISELECT_SEPARATOR_DEFAULT)]
        [Description("选择多项的分隔符")]
        public string MultiSelectSeparator
        {
            get
            {
                object obj = FState["MultiSelectSeparator"];
                return obj == null ? MULTISELECT_SEPARATOR_DEFAULT : (string)obj;
            }
            set
            {
                FState["MultiSelectSeparator"] = value;
            }
        }


        /// <summary>
        /// 是否强制选中下拉列表中的项（启用编辑的情况下）
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("是否强制选中下拉列表中的项（启用编辑的情况下）")]
        public bool ForceSelection
        {
            get
            {
                object obj = FState["ForceSelection"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                FState["ForceSelection"] = value;
            }
        }


        /// <summary>
        /// 是否可编辑，以便在录入时自动过滤下拉框中的值
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("是否可编辑，以便在录入时自动过滤下拉框中的值")]
        public bool EnableEdit
        {
            get
            {
                object obj = FState["EnableEdit"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                FState["EnableEdit"] = value;
            }
        }


        /// <summary>
        /// 是否启用模拟树显示
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("是否启用模拟树显示")]
        public bool EnableSimulateTree
        {
            get
            {
                object obj = FState["EnableSimulateTree"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                FState["EnableSimulateTree"] = value;
            }
        }

        /// <summary>
        /// 模拟树显示时指示所在层次的数据字段
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("模拟树显示时指示所在层次的数据字段")]
        public string DataSimulateTreeLevelField
        {
            get
            {
                object obj = FState["DataSimulateTreeLevelField"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                FState["DataSimulateTreeLevelField"] = value;
                //// 如果设置了DataSimulateTreeLevelField，则设置EnableSimulateTree=true
                //if (!String.IsNullOrEmpty(value))
                //{
                //    EnableSimulateTree = true;
                //}
            }
        }

        /// <summary>
        /// 是否可选择的字段
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("是否可选择的字段")]
        public string DataEnableSelectField
        {
            get
            {
                object obj = FState["DataEnableSelectField"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                FState["DataEnableSelectField"] = value;
            }
        }

        /// <summary>
        /// 是否自动回发
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("是否自动回发")]
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


        ///// <summary>
        ///// 是否可以改变下拉列表的宽度
        ///// </summary>
        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue(false)]
        //[Description("是否可以改变下拉列表的宽度")]
        //public bool Resizable
        //{
        //    get
        //    {
        //        object obj = FState["Resizable"];
        //        return obj == null ? false : (bool)obj;
        //    }
        //    set
        //    {
        //        FState["Resizable"] = value;
        //    }
        //}

        #region old code

        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue("")]
        //[Description("文本框为空时显示的文本")]
        //public string EmptyText
        //{
        //    get
        //    {
        //        object obj = BoxState["EmptyText"];
        //        return obj == null ? "" : (string)obj;
        //    }
        //    set
        //    {
        //        BoxState["EmptyText"] = value;
        //    }
        //}

        //private bool Traditional_Default = true;

        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue(true)]
        //[Description("是否渲染为传统的下拉列表")]
        //public bool Traditional
        //{
        //    get
        //    {
        //        object obj = BoxState["Editable"];
        //        return obj == null ? Traditional_Default : (bool)obj;
        //    }
        //    set
        //    {
        //        BoxState["Editable"] = value;
        //    }
        //}

        //private bool TypeAhead_Default = false;

        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue(false)]
        //[Description("是否提前输入")]
        //public bool TypeAhead
        //{
        //    get
        //    {
        //        object obj = BoxState["TypeAhead"];
        //        return obj == null ? TypeAhead_Default : (bool)obj;
        //    }
        //    set
        //    {
        //        BoxState["TypeAhead"] = value;
        //    }
        //} 


        //private bool EnableFirstItem_Default = false;

        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue(false)]
        //[Description("是否启用“全部”项")]
        //public bool EnableFirstItem
        //{
        //    get
        //    {
        //        object obj = BoxState["EnableFirstItem"];
        //        return obj == null ? EnableFirstItem_Default : (bool)obj;
        //    }
        //    set
        //    {
        //        BoxState["EnableFirstItem"] = value;
        //    }
        //}

        //private string FirstItemText_Default = "全部";

        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue("全部")]
        //[Description("“全部”的名称")]
        //public string FirstItemText
        //{
        //    get
        //    {
        //        object obj = BoxState["FirstItemText"];
        //        return obj == null ? FirstItemText_Default : (string)obj;
        //    }
        //    set
        //    {
        //        BoxState["FirstItemText"] = value;
        //    }
        //}

        //private string FirstItemValue_Default = "-1";

        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue("-1")]
        //[Description("“全部”的值")]
        //public string FirstItemValue
        //{
        //    get
        //    {
        //        object obj = BoxState["FirstItemValue"];
        //        return obj == null ? FirstItemValue_Default : (string)obj;
        //    }
        //    set
        //    {
        //        BoxState["FirstItemValue"] = value;
        //    }
        //}

        #endregion

        #endregion

        #region Data Properties

        /// <summary>
        /// 显示文本字段
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("显示文本字段")]
        public string DataTextField
        {
            get
            {
                object obj = FState["DataTextField"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                FState["DataTextField"] = value;
            }
        }


        /// <summary>
        /// 显示文本的格式化字符串
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("显示文本的格式化字符串")]
        public string DataTextFormatString
        {
            get
            {
                object obj = FState["DataTextFormatString"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                FState["DataTextFormatString"] = value;
            }
        }

        /// <summary>
        /// 显示值字段
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("显示值字段")]
        public string DataValueField
        {
            get
            {
                object obj = FState["DataValueField"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                FState["DataValueField"] = value;
            }
        }

        private object _dataSource;

        /// <summary>
        /// 数据源
        /// </summary>
        [DefaultValue(null)]
        [Description("数据源")]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object DataSource
        {
            set
            {
                _dataSource = value;
            }
            get
            {
                return _dataSource;
            }
        }

        #endregion

        #region X Properties

        /// <summary>
        /// 保存的列表项数据（内部使用）
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public JArray F_Items
        {
            get
            {
                JArray ja = new JArray();
                foreach (ListItem item in Items)
                {
                    JArray ja2 = new JArray();
                    ja2.Add(item.Value);
                    ja2.Add(item.Text);
                    ja2.Add(item.EnableSelect ? 1 : 0);
                    if (EnableSimulateTree)
                    {
                        ja2.Add(item.SimulateTreeLevel);
                    }
                    ja.Add(ja2);
                }
                return ja;
            }
            set
            {
                // 由于SelectedValue是单独保存的，所以在清空之前的数据之前要先备份
                string selectedValue = SelectedValue;
                Items.Clear();

                foreach (JArray ja2 in value)
                {
                    ListItem item = new ListItem();
                    item.Value = ja2[0].Value<string>(); // ja2.getString(0);
                    item.Text = ja2[1].Value<string>();  //ja2.getString(1);
                    item.EnableSelect = ja2[2].Value<int>() == 1 ? true : false;
                    if (EnableSimulateTree)
                    {
                        item.SimulateTreeLevel = ja2[3].Value<int>();
                    }
                    Items.Add(item);
                }

                // 恢复选中项
                SelectedValue = selectedValue;
            }
        }

        #endregion

        #region Items

        private ListItemCollection items;

        /// <summary>
        /// 列表项集合
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerDefaultProperty)]
        [Editor(typeof(CollectionEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public virtual ListItemCollection Items
        {
            get
            {
                if (items == null)
                {
                    items = new ListItemCollection();
                }
                return items;
            }
        }
        #endregion

        #region LoadFState/SaveFState
        //private string lastSelectedValue = null;
        //protected override void LoadFState(JObject state, string property)
        //{
        //    base.LoadFState(state, property);

        //    if (property == "F_Items")
        //    {
        //        XItemsFromJSON(state.getJArray(property));
        //        // After recover Items property, we should recover SelectedValue according to Items.
        //        SelectedValue = lastSelectedValue;
        //    }
        //    else if (property == "X_SelectedValue")
        //    {
        //        lastSelectedValue = state.getString(property);
        //        SaveXProperty("X_SelectedValue", lastSelectedValue);
        //        SelectedValue = lastSelectedValue;
        //    }
        //}

        //protected override void OnInit(EventArgs e)
        //{
        //    base.OnInit(e);

        //    SaveXProperty("F_Items", XItemsToJSON().ToString());
        //    SaveXProperty("X_SelectedValue", SelectedValue);
        //}

        //protected override void OnBothPreRender()
        //{
        //    base.OnBothPreRender();

        //    // Items has been changed in server-side code after onInit.
        //    if (XPropertyModified("F_Items", XItemsToJSON().ToString()))
        //    {
        //        FState.AddModifiedProperty("F_Items");
        //        // If Items have been changed, then we must reset the SelectedValue.
        //        FState.AddModifiedProperty("X_SelectedValue");
        //    }

        //    if (XPropertyModified("X_SelectedValue", SelectedValue))
        //    {
        //        FState.AddModifiedProperty("X_SelectedValue");
        //    }

        //}

        //protected override void SaveFState(JObject state, string property)
        //{
        //    if (property == "F_Items")
        //    {
        //        state.put(property, XItemsToJSON());
        //    }
        //    else if (property == "X_SelectedValue")
        //    {
        //        state.put(property, SelectedValue);
        //    }
        //}

        //private JArray XItemsToJSON()
        //{
        //    JArray ja = new JArray();
        //    foreach (ListItem item in Items)
        //    {
        //        JArray ja2 = new JArray();
        //        ja2.Add(item.Value);
        //        ja2.Add(item.Text);
        //        ja2.Add(item.EnableSelect ? 1 : 0);
        //        if (EnableSimulateTree)
        //        {
        //            ja2.Add(item.SimulateTreeLevel);
        //        }
        //        ja.Add(ja2);
        //    }
        //    return ja;
        //}

        //private void XItemsFromJSON(JArray ja)
        //{
        //    foreach (JArray ja2 in ja.getArrayList())
        //    {
        //        ListItem item = new ListItem();
        //        item.Value = ja2.getString(0);
        //        item.Text = ja2.getString(1);
        //        item.EnableSelect = ja2.getInt(2) == 1 ? true : false;
        //        if (EnableSimulateTree)
        //        {
        //            item.SimulateTreeLevel = ja2.getInt(3);
        //        }
        //        Items.Add(item);
        //    }
        //}

        #endregion

        #region SelectedValueHiddenFieldID

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        private string SelectedValueHiddenFieldID
        {
            get
            {
                return String.Format("{0}$Value", UniqueID);
            }
        }

        #endregion

        #region OnPreRender

        private string Render_AutoPostBackID
        {
            get
            {
                return String.Format("{0}_autopostback", XID);
            }
        }


        /// <summary>
        /// 渲染 HTML 之前调用（AJAX回发）
        /// </summary>
        protected override void OnAjaxPreRender()
        {
            base.OnAjaxPreRender();

            StringBuilder sb = new StringBuilder();

            bool dataReloaded = false;
            if (PropertyModified("F_Items"))
            {
                dataReloaded = true;
                sb.AppendFormat("{0}.f_loadData();", XID);
            }


            bool selectedValueChanged = false;
            if (EnableMultiSelect)
            {
                if (PropertyModified("SelectedValueArray"))
                {
                    selectedValueChanged = true;
                }
            }
            else
            {
                if (PropertyModified("SelectedValue"))
                {
                    selectedValueChanged = true;
                }
            }

            // 修改Items记录后要更新SelectedValue
            if (dataReloaded || selectedValueChanged)
            {
                sb.AppendFormat("{0}.f_setValue();", XID);
            }

            AddAjaxScript(sb);
        }

        private void ProcessAutoSelectFirstItem()
        {
            //// 如果强制选择一项，我们可能需要选中第一项
            //if (SelectedItem == null && AutoSelectFirstItem)
            //{
            //    if (Items.Count > 0)
            //    {
            //        SelectedIndex = 0;
            //    }
            //}

            // 自动修正
            if (AutoSelectFirstItem && Items.Count > 0)
            {
                bool hasSelection = false;
                foreach (ListItem item in Items)
                {
                    if (item.Selected)
                    {
                        hasSelection = true;
                        break;
                    }
                }

                // 没有选中任何一项，则选中第一项
                if (!hasSelection)
                {
                    Items[0].Selected = true;
                }
            }
        }


        /// <summary>
        /// 渲染 HTML 之前调用（页面第一次加载或者普通回发）
        /// </summary>
        protected override void OnFirstPreRender()
        {
            ProcessAutoSelectFirstItem();

            // 确保 F_Items 和 SelectedValue 在页面第一次加载时都存在于f_state中
            FState.AddModifiedProperty("F_Items");
            FState.AddModifiedProperty("SelectedValue");
            FState.AddModifiedProperty("SelectedValueArray");

            base.OnFirstPreRender();


            #region examples

            //var nextStepList = [
            //    ['审核', '1'],
            //    ['不审核', '2']
            //];
            //var nextStepStore = new Ext.data.SimpleStore({
            //    fields: ['text', 'value'],
            //    data: nextStepList
            //});
            //{
            //    xtype:'combo',
            //    store: nextStepStore,
            //    displayField:'text',
            //    valueField:'value',
            //    typeAhead: true,
            //    mode: 'local',
            //    triggerAction: 'all',
            //    value:'1',
            //    emptyText:'请选择下一步',
            //    selectOnFocus:true,
            //    allowBlank:false,
            //    fieldLabel: '下一步',
            //    labelSeparator:'&nbsp;<span style="color:red;vertical-align:text-bottom;">*</span>',
            //    name: 'nextStep',
            //    anchor:'95%'
            //}

            #endregion



            #region Properties

            if (!MatchFieldWidth)
            {
                OB.AddProperty("matchFieldWidth", false);
            }


            if (EnableEdit)
            {
                OB.AddProperty("editable", true);
            }
            else
            {
                OB.AddProperty("editable", false);
            }


            if (ForceSelection)
            {
                OB.AddProperty("forceSelection", true);
            }
            else
            {
                OB.AddProperty("forceSelection", false);
            }

            //if (Resizable)
            //{
            //    OB.AddProperty("resizable", true);
            //}

            OB.AddProperty("hiddenName", SelectedValueHiddenFieldID);


            if (!String.IsNullOrEmpty(EmptyText))
            {
                OB.AddProperty("emptyText", EmptyText);
            }



            JsObjectBuilder storeBuilder = new JsObjectBuilder();
            storeBuilder.AddProperty("fields", "['value','text','enabled','prefix']", true);
            storeBuilder.AddProperty("data", String.Format("F.simulateTree.transform({0}.F_Items)", GetFStateScriptID()), true);
            OB.AddProperty("store", String.Format("Ext.create('Ext.data.ArrayStore',{0})", storeBuilder), true);

            OB.AddProperty("value", String.Format("{0}.{1}", GetFStateScriptID(), EnableMultiSelect ? "SelectedValueArray" : "SelectedValue"), true);

            //OB.AddProperty("value", "['Value1','Value4']", true);

            OB.AddProperty("tpl", "F.util.ddlTPL", true);

            OB.AddProperty("queryMode", "local");
            OB.AddProperty("triggerAction", "all");

            if (EnableMultiSelect)
            {
                OB.AddProperty("multiSelect", true);


                if (MultiSelectSeparator != MULTISELECT_SEPARATOR_DEFAULT)
                {
                    OB.AddProperty("delimiter", MultiSelectSeparator);
                }

            }

           



            #region old code
            //OB.AddProperty("mode", "local");
            //// 点击下拉按钮时显示全部内容
            //OB.AddProperty("triggerAction", "all");
            //// 必须选中一个值，不能自己输入内容
            //OB.AddProperty("forceSelection", true);
            //// 此下拉列表控件不可以编辑
            //OB.AddProperty("editable", false);

            //OB.AddProperty(OptionName.Title, "Title");
            //if (TypeAhead) OB.AddProperty(OptionName.TypeAhead, true);
            //OB.AddProperty(OptionName.SelectOnFocus, true);

            //// SelectedValue可以为空
            //if (!String.IsNullOrEmpty(SelectedValue))
            //{
            //    OB.AddProperty("value", SelectedValue);
            //} 
            #endregion

            #endregion

            #region old code

            //string hiddenFieldsScript = String.Empty;
            //if (AutoPostBack)
            //{
            //    hiddenFieldsScript += GetSetHiddenFieldValueScript(LastSelectedValueHiddenID, SelectedValue);
            //}

            //string disableSelectRowIndexsString = GetDisableSelectRowIndexsString();
            //string disableSelectRowIndexsScript = GetSetHiddenFieldValueScript(DisableRowIndexsHiddenID, disableSelectRowIndexsString);

            //// TODO:
            //// 这个要放在加载数据的前面，因为加载数据时需要渲染UI，渲染UI时需要用到这个隐藏字段的值
            //if (AjaxPropertyChanged("DisableSelectRowIndexsString", disableSelectRowIndexsString))
            //{
            //    AddAjaxPropertyChangedScript(disableSelectRowIndexsScript);
            //}


            // 不管是不是disableSelectFields.Count > 0，都要执行下面的语句，因为可能页面加载时为0，在Ajax后不为零
            //if (disableSelectFields.Count > 0)
            //OB.AddProperty(OptionName.Tpl, String.Format("'<tpl for=\".\"><div class=\"x-combo-list-item {{[F.util.isHiddenFieldContains(\"{0}\",xindex-1) ? \"f-combo-list-item-disable-select\" : \"\"]}}\">{{text}}</div></tpl>'", DisableSelectRowIndexsHiddenID), true);
            //var tplStr = "'<tpl for=\".\"><div class=\"x-combo-list-item\">{text}</div></tpl>'";
            //var tplStr = "new Ext.XTemplate('<tpl for=\".\"><div class=\"x-combo-list-item\">{text}</div></tpl>')";

            //var tplStr = "<tpl for=\".\"><div class=\"x-combo-list-item <tpl if=\"!enabled\">x-combo-list-item-disable</tpl>\">{prefix}{text}</div></tpl>";
            //OB.AddProperty("tpl", tplStr);
            //OB.AddProperty("tpl", tplStr.Replace("#DisableRowIndexsHiddenID#", DisableRowIndexsHiddenID), true);


            //string setSimulateTreeTextFunctionScript = String.Empty;
            //string setSimulateTreeTextScript = String.Empty;
            //if (EnableSimulateTree)
            //{
            //    string setSimulateTextScript = String.Format("var text=Ext.get('{0}').dom.value;if(text.lastIndexOf('<img')>=0){{Ext.get('{0}').dom.value=F.util.stripHtmlTags(text);}}", ClientID);
            //    setSimulateTreeTextFunctionScript = String.Format("{0}_setSimulateText=function(){{{1}}};", ClientJavascriptID, setSimulateTextScript);

            //    // 加载完毕后，显示选中的值
            //    //AddAbsoluteStartupScript(String.Format("{0}_setSimulateText();", ClientJavascriptID));
            //    // 下拉列表加载完毕后，立即去掉前面图片的HTML标签
            //    string renderScript = JsHelper.GetDeferScript(String.Format("{0}_setSimulateText();", ClientJavascriptID), 20); // "(function(){" + String.Format("{0}_setSimulateText();", ClientJavascriptID) + "}).defer(20);";
            //    OB.Listeners.AddProperty(OptionName.EVENT_RENDER, "function(component){" + renderScript + "}", true);
            //}


            //string simulateTreeAllScript = String.Empty;
            //if (EnableSimulateTree)
            //{
            //    // 在选中一项后，立即去掉前面图片的HTML标签
            //    simulateTreeAllScript += "\r\n";
            //    //string simulateTreeScript = String.Format("function(ddl,record,index){{var text=record.data.text;var startDivIndex=text.lastIndexOf('</div>');text=text.substr(startDivIndex+6);Ext.get('{0}').dom.value=text;}}", ClientID);
            //    string simulateTreeScript = String.Format("function(ddl,record,index){{X.{0}_setSimulateText();}}", ClientJavascriptID);
            //    simulateTreeScript = String.Format("{0}.on('{1}',{2},box,{{delay:0}});", ClientJavascriptID, OptionName.Select, simulateTreeScript);
            //    //AddAbsoluteStartupScript( simulateTreeScript);
            //    simulateTreeAllScript += simulateTreeScript;

            //    simulateTreeAllScript += "\r\n";
            //    string simulateTreeBlurScript = String.Format("function(ddl){{X.{0}_setSimulateText();}}", ClientJavascriptID);
            //    simulateTreeBlurScript = String.Format("{0}.on('{1}',{2},box,{{delay:10}});", ClientJavascriptID, OptionName.Blur, simulateTreeBlurScript);
            //    //AddAbsoluteStartupScript( simulateTreeBlurScript);
            //    simulateTreeAllScript += simulateTreeBlurScript;
            //}




            // These are default values, which are assignment in extender.js.
            //OB.AddProperty("displayField", "text");
            //OB.AddProperty("valueField", "value");
            //OB.AddProperty("store", "new Ext.data.ArrayStore({fields:['value','text','enabled','prefix']})", true);

            //string dataScript = String.Empty;
            //string fields = "['value','text','enabled','prefix']";
            //string storeScript = "new Ext.data.ArrayStore({fields:['value','text','enabled','prefix']})";//", fields, GetDataArrayString()); // GetDataArrayString()

            //OB.AddProperty(OptionName.Store, String.Format("new Ext.data.ArrayStore({{fields:['value','text'],data:{0}}})", dataArrayString), true);
            //OB.AddProperty("store", String.Format("{0}_data", XID), true);
            //string dataScript = String.Format("{0}_data=new Ext.data.ArrayStore({{fields:['value','text'],data:{1}}});", ClientJavascriptID, dataArrayString);
            //sb.AppendFormat("this.{0}_store=new Ext.data.SimpleStore({{fields:['text', 'value'],data:this.{0}_data}});", ClientJavascriptID);
            #endregion

            #region AutoPostBack

            string autoPostBackScript = String.Empty;

            if (AutoPostBack)
            {
                autoPostBackScript = String.Format("var {0}={1};", Render_AutoPostBackID, JsHelper.GetFunction("if(cmp.f_tmp_lastvalue!==cmp.getValue()){" + GetPostBackEventReference() + "}", "cmp"));
            }
            StringBuilder beforeselectSB = new StringBuilder();
            // 是否能选中一项（如果此项不能选中，则点击没用）
            //beforeselectSB.AppendFormat("if(F.util.isHiddenFieldContains('{0}',index)){{return false;}}", DisableRowIndexsHiddenID);
            beforeselectSB.Append("if(!record.data.enabled){return false;}");

            if (AutoPostBack)
            {
                beforeselectSB.Append("cmp.f_tmp_lastvalue=cmp.getValue();");

                //string selectScript = "if(cmp.f_tmp_lastvalue!==cmp.getValue()){" + GetPostBackEventReference() + "}";
                beforeselectSB.AppendFormat("window.setTimeout(function(){{{0}(cmp);}},100);", Render_AutoPostBackID);
                //AddListener("select", selectScript, "cmp");
            }

            AddListener("beforeselect", beforeselectSB.ToString(), "cmp", "record", "index");

            //if (EnableMultiSelect)
            //{
            //    StringBuilder beforedeselectSB = new StringBuilder();
            //    beforedeselectSB.AppendFormat("window.setTimeout(function(){{{0}(cmp);}},100);", Render_AutoPostBackID);
            //    AddListener("beforedeselect", beforedeselectSB.ToString(), "cmp", "record", "index");
            //}

            #region old code
            //if (AutoPostBack)
            //{
            //    // Note: we can't use change event, because it get triggered when the combox lost focus, which is not in time.
            //    // Beforeselect - If current select item is not changed, don't PostBack.
            //    string beforeselectScript = String.Format("function(ddl,record,index){{Ext.get('{0}').dom.value=Ext.get('{1}').dom.value;}}", LastSelectedValueHiddenID, SelectedValueHiddenID);
            //    beforeselectScript = String.Format("{0}.on('{1}',{2},X,{{delay:0}});", XID, "beforeselect", beforeselectScript);
            //    //AddAbsoluteStartupScript( beforeselectScript);
            //    autoPostBackScript += beforeselectScript;

            //    // Select
            //    string selectScript = String.Format("function(ddl,record,index){{if(record.data.value!=Ext.get('{0}').dom.value){{{1}}}}}", LastSelectedValueHiddenID, GetPostBackEventReference());
            //    selectScript = String.Format("{0}.on('{1}',{2},X,{{delay:0}});", XID, "select", selectScript);
            //    //AddAbsoluteStartupScript( selectScript);
            //    autoPostBackScript += selectScript;


            //    //OB.Listeners.RemoveProperty(OptionName.Change);
            //    //OB.Listeners.AddProperty(OptionName.Change, String.Format("function(ddl,newValue,oldValue){{box_pageStateChange();alert(newValue+':'+oldValue);}}"), true);
            //} 
            #endregion

            #endregion

            #region Listeners - render

            //string renderScript = "cmp.f_loadData();cmp.f_setValue();";

            //OB.Listeners.AddProperty("render", JsHelper.GetFunction(renderScript, "cmp"), true);

            string renderScript = String.Empty;
            if (!MatchFieldWidth)
            {
                renderScript = String.Format("cmp.getPicker().addCls('f-field-ddlpop-autowidth')");
            }

            if (!String.IsNullOrEmpty(renderScript))
            {
                AddListener("render", renderScript, "cmp");
            }

            #endregion

            #region AddStartupScript

            string contentScript = String.Format("var {0}=Ext.create('Ext.form.field.ComboBox',{1});", XID, OB.ToString());

            AddStartupScript(autoPostBackScript + contentScript);

            #region old code
            //List<string> totalModifiedProperties = FState.GetTotalModifiedProperties();
            //StringBuilder loadDataSB = new StringBuilder();
            //if (totalModifiedProperties.Contains("F_Items"))
            //{
            //    loadDataSB.AppendFormat("{0}.f_loadData();", XID);
            //}
            //else
            //{
            //    loadDataSB.AppendFormat("{0}.store.loadData({1});", XID, F_Items.ToString());
            //}

            //if (totalModifiedProperties.Contains("SelectedValue"))
            //{
            //    loadDataSB.AppendFormat("{0}.f_setValue();", XID);
            //}
            //else
            //{
            //    loadDataSB.AppendFormat("{0}.f_setValue({1});", XID, JsHelper.Enquote(SelectedValue));
            //} 
            #endregion

            #endregion

        }

        #region old code

        //private string GetDataArrayString()
        //{
        //    if (Items.Count == 0)
        //    {
        //        return "[[]]";
        //    }
        //    else
        //    {
        //        if (EnableSimulateTree)
        //        {
        //            List<SimulateTreeNode> silumateTreeNodes = new List<SimulateTreeNode>();
        //            // Set up a list for calculate(mainly the front images).
        //            for (int rowIndex = 0; rowIndex < Items.Count; rowIndex++)
        //            {
        //                ListItem item = Items[rowIndex];
        //                SimulateTreeNode node = new SimulateTreeNode();
        //                node.Text = item.Text;
        //                node.Value = item.Value;
        //                node.Level = item.SimulateTreeLevel;
        //                node.EnableSelect = item.EnableSelect;
        //                node.HasLittleBrother = false;
        //                node.ParentNode = null;
        //                silumateTreeNodes.Add(node);
        //            }
        //            // Use a helper class to calculate tree.
        //            SimulateTreeHeper treeHelper = new SimulateTreeHeper();
        //            treeHelper.ResolveSimulateTree(silumateTreeNodes, false);


        //            JArray ja = new JArray();
        //            foreach (SimulateTreeNode node in silumateTreeNodes)
        //            {
        //                JArray ja2 = new JArray();
        //                ja2.Add(node.Value);
        //                ja2.Add(node.Text);
        //                ja2.Add(node.EnableSelect ? 1 : 0);
        //                ja2.Add(node.SimulateTreeText);

        //                ja.Add(ja2);
        //            }
        //            return ja.ToString();
        //        }
        //        else
        //        {
        //            JArray ja = new JArray();
        //            foreach (ListItem item in Items)
        //            {
        //                JArray ja2 = new JArray();
        //                ja2.Add(item.Value);
        //                ja2.Add(item.Text);
        //                ja2.Add(item.EnableSelect ? 1 : 0);

        //                ja.Add(ja2);
        //            }
        //            return ja.ToString();
        //        }
        //    }
        //}

        ///// <summary>
        ///// Return values: "0,1,2,10"
        ///// </summary>
        ///// <returns></returns>
        //private string GetDisableSelectRowIndexsString()
        //{
        //    List<int> disableSelectRows = new List<int>();
        //    for (int rowIndex = 0, rowCount = Items.Count; rowIndex < rowCount; rowIndex++)
        //    {
        //        if (!Items[rowIndex].EnableSelect)
        //        {
        //            disableSelectRows.Add(rowIndex);
        //        }
        //    }

        //    #region old code
        //    // 下面的条件判断不能加，因为如果页面第一次加载时没有不能选择的项，则以后回发时都不会有不能选择的项
        //    //if (disableSelectFields.Count > 0)
        //    //{
        //    // 把这个状态保存在隐藏字段中，因为可能在Ajax中改变
        //    //disableSelectScript = String.Format("{0}_disableSelect={1};", ClientJavascriptID, JsHelper.GetJsIntArray(disableSelectFields.ToArray()));
        //    //disableSelectScript += "\r\n"; 
        //    #endregion
        //    return StringUtil.GetStringFromIntArray(disableSelectRows.ToArray());
        //}


        #endregion

        #endregion

        #region DataBind
        /// <summary>
        /// 绑定到数据源
        /// </summary>
        public override void DataBind()
        {
            // Clear all items
            Items.Clear();

            if (_dataSource != null)
            {
                if (_dataSource is IDataReader)
                {
                    DataTable dataTable = new DataTable();
                    dataTable.Load(_dataSource as IDataReader);

                    DataBindToDataTable(dataTable);
                }
                else if (_dataSource is DataView || _dataSource is DataSet || _dataSource is DataTable)
                {
                    DataTable dataTable = null;

                    if (_dataSource is DataView)
                    {
                        dataTable = ((DataView)_dataSource).ToTable();
                    }
                    else if (_dataSource is DataSet)
                    {
                        dataTable = ((DataSet)_dataSource).Tables[0];
                    }
                    else
                    {
                        dataTable = ((DataTable)_dataSource);
                    }

                    DataBindToDataTable(dataTable);
                }
                else if (_dataSource is IEnumerable)
                {
                    DataBindToEnumerable((IEnumerable)_dataSource);
                }
                else
                {
                    throw new Exception("DataSource doesn't support data type: " + _dataSource.GetType().ToString());
                }
            }

            //// 重新绑定数据后，判断是否自动选择第一项
            //ProcessAutoSelectFirstItem();

            base.DataBind();
        }

        #endregion

        #region private DataBind


        /// <summary>
        /// 绑定到数据表格
        /// </summary>
        /// <param name="dataTable">数据表格</param>
        private void DataBindToDataTable(DataTable dataTable)
        {
            int startIndex = 0;
            int endIndex = Int32.MaxValue;
            for (int i = startIndex; i < Math.Min(endIndex, dataTable.Rows.Count); i++)
            {
                DataRow row = dataTable.Rows[i];

                Items.Add(CreateListItem(row));
            }
        }


        /// <summary>
        /// 绑定到可枚举类型
        /// </summary>
        /// <param name="enumerable">可枚举类型</param>
        private void DataBindToEnumerable(IEnumerable enumerable)
        {
            #region old code
            //int startIndex = 0;
            //int endIndex = Int32.MaxValue;

            //IEnumerator enumerator = enumerable.GetEnumerator();

            //// 定位开始位置
            //enumerator.Reset();
            //enumerator.MoveNext();

            //int count = 0;

            //// skip some items?
            //while (count < startIndex)
            //{
            //    enumerator.MoveNext();
            //    count++;
            //}

            //try
            //{
            //    if (enumerator.Current == null)
            //    {
            //        return;
            //    }
            //}
            //catch
            //{
            //    return;
            //}

            //while (enumerator.Current != null && count < endIndex)
            //{
            //    object currentObject = enumerator.Current;

            //    ListItem item = new ListItem();

            //    if (currentObject is string)
            //    {
            //        item.Text = currentObject.ToString();
            //        item.Value = currentObject.ToString();
            //    }
            //    else
            //    {
            //        // Load item
            //        if (DataTextField != "")
            //        {
            //            item.Text = GetPropertyValue(currentObject, DataTextField);
            //        }
            //        else
            //        {
            //            item.Text = currentObject.ToString();
            //        }

            //        if (DataValueField != "")
            //        {
            //            item.Value = GetPropertyValue(currentObject, DataValueField);
            //        }
            //        else
            //        {
            //            item.Value = currentObject.ToString();
            //        }

            //        // 如果需要模拟树
            //        if (!String.IsNullOrEmpty(DataSimulateTreeLevelField))
            //        {
            //            item.SimulateTreeLevel = Convert.ToInt32(GetPropertyValue(currentObject, DataSimulateTreeLevelField));
            //        }

            //        // 是否选择
            //        item.EnableSelect = true;
            //        if (!String.IsNullOrEmpty(DataEnableSelectField))
            //        {
            //            item.EnableSelect = Convert.ToBoolean(GetPropertyValue(currentObject, DataEnableSelectField));
            //        }

            //    }

            //    Items.Add(item);

            //    if (!enumerator.MoveNext())
            //    {
            //        break;
            //    }

            //    count++;
            //} 
            #endregion

            IEnumerator enumerator = enumerable.GetEnumerator();
            while (enumerator.MoveNext())
            {
                object currentObject = enumerator.Current;
                Items.Add(CreateListItem(currentObject));
            }
        }

        private ListItem CreateListItem(Object obj)
        {
            ListItem item = new ListItem();

            if (obj is string)
            {
                item.Text = obj.ToString();
                item.Value = obj.ToString();
            }
            else
            {
                if (DataTextField != "")
                {
                    if (DataTextFormatString != "")
                    {
                        item.Text = String.Format(DataTextFormatString, GetPropertyValue(obj, DataTextField));
                    }
                    else
                    {
                        item.Text = GetPropertyValue(obj, DataTextField);
                    }
                }
                else
                {
                    item.Text = obj.ToString();
                }

                if (DataValueField != "")
                {
                    item.Value = GetPropertyValue(obj, DataValueField);
                }
                else
                {
                    item.Value = obj.ToString();
                }

                // 如果需要模拟树
                if (!String.IsNullOrEmpty(DataSimulateTreeLevelField))
                {
                    string treeLevelStr = GetPropertyValue(obj, DataSimulateTreeLevelField);
                    if (String.IsNullOrEmpty(treeLevelStr))
                    {
                        item.SimulateTreeLevel = 0;
                    }
                    else
                    {
                        item.SimulateTreeLevel = Convert.ToInt32(treeLevelStr);
                    }
                }

                // 是否可以选择
                item.EnableSelect = true;
                if (!String.IsNullOrEmpty(DataEnableSelectField))
                {
                    item.EnableSelect = Convert.ToBoolean(GetPropertyValue(obj, DataEnableSelectField));
                }
            }
            return item;
        }

        /// <summary>
        /// 取得属性值
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="propertyName"></param>
        private string GetPropertyValue(object obj, string propertyName)
        {
            object result = null;

            result = ObjectUtil.GetPropertyValue(obj, propertyName);

            // DBNull.Value.ToString() == ""
            return result == null ? String.Empty : result.ToString();
        }

        //private void AfterDataBind()
        //{
        //    //// 必须重新计算模拟数的数据
        //    //mustReCalculateSimulateTreeData = true;
        //}

        #endregion

        #region IPostBackDataHandler Members

        /// <summary>
        /// 处理回发数据
        /// </summary>
        /// <param name="postDataKey">回发数据键</param>
        /// <param name="postCollection">回发数据集</param>
        /// <returns>回发数据是否改变</returns>
        public bool LoadPostData(string postDataKey, System.Collections.Specialized.NameValueCollection postCollection)
        {
            // 如果下拉列表被禁用，则postText为null。由于Enabled只能在服务器端被改变，所以被禁用时，不处理回发数据即可
            if (!Enabled)
            {
                return false;
            }

            // 如果下拉列表没有任何项，则不会触发数据改变事件
            if (Items.Count == 0)
            {
                return false;
            }


            string postText = postCollection[postDataKey];

            if (EnableMultiSelect)
            {
                string[] postValues = postCollection.GetValues(SelectedValueHiddenFieldID);
                if (postValues == null)
                {
                    postValues = new string[0];
                }
                if (!StringUtil.CompareStringArray(postValues, SelectedValueArray))
                {
                    SelectedValueArray = postValues;
                    FState.BackupPostDataProperty("SelectedValueArray");
                    return true;
                }

            }
            else
            {
                string postValue = postCollection[SelectedValueHiddenFieldID];

                ListItem item = Items.FindByValue(postValue);
                if (item != null && item.Text == postText)
                {
                    // 本次选中的是下拉项
                    if (SelectedValue != postValue)
                    {
                        SelectedValue = postValue;
                        FState.BackupPostDataProperty("SelectedValue");
                        return true;
                    }
                }
                else
                {
                    //// 本次是用户输入的值
                    //if (Text != postText)
                    //{
                    SelectedValue = null;
                    FState.BackupPostDataProperty("SelectedValue");

                    Text = postText;
                    FState.BackupPostDataProperty("Text");
                    return true;
                    //}
                }
            }


            return false;
        }

        /// <summary>
        /// 触发回发数据改变事件
        /// </summary>
        public void RaisePostDataChangedEvent()
        {
            OnSelectedIndexChanged(EventArgs.Empty);
        }

        #endregion

        #region SelectedIndexChanged

        private object _handlerKey = new object();

        /// <summary>
        /// 选中项改变事件（需要启用AutoPostBack）
        /// </summary>
        [Category(CategoryName.ACTION)]
        [Description("选中项改变事件（需要启用AutoPostBack）")]
        public event EventHandler SelectedIndexChanged
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
        /// 触发选中项改变事件
        /// </summary>
        /// <param name="e">事件参数</param>
        protected virtual void OnSelectedIndexChanged(EventArgs e)
        {
            EventHandler handler = Events[_handlerKey] as EventHandler;

            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion

        #region old code

        //protected override object SaveViewState()
        //{
        //    object[] states = new object[2];

        //    states[0] = base.SaveViewState();
        //    states[1] = ((IStateManager)Items).SaveViewState();


        //    return states;
        //}

        //protected override void LoadViewState(object savedState)
        //{
        //    if (savedState != null)
        //    {
        //        object[] states = (object[])savedState;

        //        base.LoadViewState(states[0]);

        //        ((IStateManager)Items).LoadViewState(states[1]);
        //    }
        //}

        //protected override void TrackViewState()
        //{
        //    base.TrackViewState();

        //    ((IStateManager)Items).TrackViewState();
        //}

        //protected override void SetDirty()
        //{
        //    base.SetDirty();

        //    ((ISetDirty)Items).SetDirty();
        //}



        ///// <summary>
        ///// 保存上次选中值的Input
        ///// </summary>
        //private string LastSelectedValueHiddenID
        //{
        //    get
        //    {
        //        return String.Format("{0}_last_value", XID);
        //    }
        //}

        ///// <summary>
        ///// 保存当前选中值的Input
        ///// </summary>
        //private string SelectedValueHiddenID
        //{
        //    get
        //    {
        //        return UniqueID;
        //    }
        //}


        ///// <summary>
        ///// 不可用的行Index列表
        ///// </summary>
        //private string DisableRowIndexsHiddenID
        //{
        //    get
        //    {
        //        return String.Format("{0}_disable_rows", ClientID);
        //    }
        //}


        //protected override void OnPreLoad(object sender, EventArgs e)
        //{
        //    base.OnPreLoad(sender, e);

        //    SaveAjaxProperty("DisableSelectRowIndexsString", GetDisableSelectRowIndexsString());
        //    SaveAjaxProperty("DataArrayString", GetDataArrayString());
        //    SaveAjaxProperty("SelectedValue", SelectedValue);
        //}

        #endregion
    }
}
