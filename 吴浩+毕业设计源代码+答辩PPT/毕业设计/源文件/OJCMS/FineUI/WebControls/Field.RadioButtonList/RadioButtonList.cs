
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    RadioButtonList.cs
 * CreatedOn:   2008-06-20
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
using System.Data;
using System.Collections;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel.Design;

namespace FineUI
{
    /// <summary>
    /// 单选框列表控件
    /// </summary>
    [Designer("FineUI.Design.RadioButtonListDesigner, FineUI.Design")]
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:RadioButtonList runat=server></{0}:RadioButtonList>")]
    [ToolboxBitmap(typeof(RadioButtonList), "toolbox.RadioButtonList.bmp")]
    [Description("单选框列表控件")]
    [ParseChildren(true, DefaultProperty = "Items")]
    [PersistChildren(false)]
    [DefaultEvent("SelectedIndexChanged")]
    public class RadioButtonList : Field, IPostBackDataHandler
    {
        #region Constructor

        /// <summary>
        /// 构造函数
        /// </summary>
        public RadioButtonList()
        {
            AddServerAjaxProperties("F_Items");
            AddClientAjaxProperties("SelectedValue");

            AddGzippedAjaxProperties("F_Items");
        }

        #endregion

        #region Properties

        #region old code

        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue(false)]
        //[Description("是否显示浅色的背景色")]
        //public virtual bool EnableLightBackgroundColor
        //{
        //    get
        //    {
        //        object obj = BoxState["EnableLightBackgroundColor"];
        //        return obj == null ? false : (bool)obj;
        //    }
        //    set
        //    {
        //        BoxState["EnableLightBackgroundColor"] = value;
        //    }
        //}

        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue(false)]
        //[Description("是否显示背景色")]
        //public virtual bool EnableBackgroundColor
        //{
        //    get
        //    {
        //        object obj = BoxState["EnableBackgroundColor"];
        //        return obj == null ? false : (bool)obj;
        //    }
        //    set
        //    {
        //        BoxState["EnableBackgroundColor"] = value;
        //    }
        //}


        #endregion

        /// <summary>
        /// 是否必填项
        /// </summary>
        [Category(CategoryName.VALIDATION)]
        [DefaultValue(false)]
        [Description("是否必填项")]
        public bool Required
        {
            get
            {
                object obj = FState["Required"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                FState["Required"] = value;
            }
        }

        /// <summary>
        /// 为空时提示信息
        /// </summary>
        [Category(CategoryName.VALIDATION)]
        [DefaultValue("")]
        [Description("为空时提示信息")]
        public string RequiredMessage
        {
            get
            {
                object obj = FState["RequiredMessage"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                FState["RequiredMessage"] = value;
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
        ///// 是否选中
        ///// </summary>
        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue(false)]
        //[Description("是否选中")]
        //public bool Checked
        //{
        //    get
        //    {
        //        object obj = FState["Checked"];
        //        return obj == null ? false : (bool)obj;
        //    }
        //    set
        //    {
        //        FState["Checked"] = value;
        //    }
        //}

        /// <summary>
        /// 渲染成几列
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(0)]
        [Description("渲染成几列")]
        public int ColumnNumber
        {
            get
            {
                object obj = FState["ColumnNumber"];
                return obj == null ? 0 : (int)obj;
            }
            set
            {
                FState["ColumnNumber"] = value;
            }
        }

        /// <summary>
        /// 是否按照纵向顺序渲染
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("是否按照纵向顺序渲染")]
        public bool ColumnVertical
        {
            get
            {
                object obj = FState["ColumnVertical"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                FState["ColumnVertical"] = value;
            }
        }

        #endregion

        #region Data Properties

        /// <summary>
        /// 显示文本的数据字段
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("显示文本的数据字段")]
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
        /// 显示值的数据字段
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("显示值的数据字段")]
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

        #region SelectedIndex/SelectedValue/SelectedItem

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
                string value = String.Empty;
                if (SelectedItem != null)
                {
                    value = SelectedItem.Value;
                }
                return value;
            }
            set
            {
                for (int i = 0, count = Items.Count; i < count; i++)
                {
                    RadioItem item = Items[i];
                    if (item.Value == value)
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
        public int SelectedIndex
        {
            get
            {
                int _selectedIndex = -1;
                for (int i = 0, count = Items.Count; i < count; i++)
                {
                    if (Items[i].Selected)
                    {
                        _selectedIndex = i;
                        break;
                    }
                }
                return _selectedIndex;
            }
            set
            {
                if (value >= 0 && value < Items.Count)
                {
                    foreach (RadioItem item in Items)
                    {
                        item.Selected = false;
                    }

                    Items[value].Selected = true;
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
        public RadioItem SelectedItem
        {
            get
            {
                int selectedIndex = SelectedIndex;
                if (SelectedIndex >= 0 && SelectedIndex < Items.Count)
                {
                    return Items[SelectedIndex];
                }
                return null;
            }
        }

        #endregion

        #region Items

        private RadioItemCollection _items;

        /// <summary>
        /// 单选项集合
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerDefaultProperty)]
        [Editor(typeof(CollectionEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public virtual RadioItemCollection Items
        {
            get
            {
                if (_items == null)
                {
                    _items = new RadioItemCollection();
                }
                return _items;
            }
        }

        #endregion

        #region HiddenFieldID

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal string SelectedValueArrayHiddenFieldID
        {
            get
            {
                return String.Format("{0}_SelectedValueArray", ClientID);
            }
        }

        #endregion

        #region X Properties

        /// <summary>
        /// 保存的单选项数据（内部使用）
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public JArray F_Items
        {
            get
            {
                JArray ja = new JArray();
                foreach (RadioItem item in Items)
                {
                    JArray ja2 = new JArray();
                    ja2.Add(item.Text);
                    ja2.Add(item.Value);
                    ja.Add(ja2);
                }
                return ja;
            }
            set
            {
                // 和DropDownList的情况相同，清空前备份选中项
                string selectedValue = SelectedValue;
                Items.Clear();

                foreach (JArray ja2 in value)
                {
                    RadioItem item = new RadioItem();
                    item.Text = ja2[0].Value<string>(); //ja2.getString(0);
                    item.Value = ja2[1].Value<string>(); //ja2.getString(1);
                    Items.Add(item);
                }

                // 恢复选中项
                SelectedValue = selectedValue;
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

            bool dataReloaded = false;

            StringBuilder sb = new StringBuilder();

            if (PropertyModified("F_Items"))
            {
                sb.AppendFormat("{0}.f_reloadData('{1}',true);", XID, UniqueID); //, GetItemsJArray().ToString(Formatting.None));

                // 注意，在x_reloadData中重新创建了列表实例，所以要重新赋值
                sb.AppendFormat("{0}=F('{1}');", XID, ClientID);

                //if (Items.Count == 0)
                //{
                //    sb.AppendFormat("{0}.f_toBeDeleted();", XID);
                //}

                dataReloaded = true;
            }


            // 基于 extjs 的实现，如果数据重新加载了，则客户端会重新初始化控件示例
            if (!dataReloaded)
            {
                if (PropertyModified("SelectedValue"))
                {
                    sb.AppendFormat("{0}.f_setValue();", XID);

                }
            }

            AddAjaxScript(sb);
        }

        /// <summary>
        /// 渲染 HTML 之前调用（页面第一次加载或者普通回发）
        /// </summary>
        protected override void OnFirstPreRender()
        {
            // 确保 F_Items 和 SelectedValue 在页面第一次加载时都存在于f_state中
            FState.AddModifiedProperty("F_Items");
            FState.AddModifiedProperty("SelectedValue");


            base.OnFirstPreRender();

            #region options

            if (Required)
            {
                OB.AddProperty("allowBlank", false);
                if (!String.IsNullOrEmpty(RequiredMessage))
                {
                    OB.AddProperty("blankText", RequiredMessage);
                }
            }


            OB.RemoveProperty("name");

            if (ColumnNumber <= 0)
            {
                OB.AddProperty("columns", "auto");
            }
            else
            {
                OB.AddProperty("columns", ColumnNumber);
            }

            if (ColumnVertical)
            {
                OB.AddProperty("vertical", true);
            }

            #endregion

            #region Items
            /*
            string xstateName = String.Format("{0}_xstate", XID);
            string xitemsName = String.Format("{0}_xitems", XID);
            string hasDataName = xstateName;

            string xstate = OB.GetProperty("f_state");
            OB.AddProperty("f_state", xstateName, true);

            string jsState = String.Format("var {0}={1};", xstateName, xstate);

            if (!FState.ModifiedProperties.Contains("F_Items"))
            {
                xstate = ConvertPropertiesToJObject(new List<string> { "F_Items", "SelectedValue" }).ToString(Formatting.None);
                jsState += String.Format("var {0}={1};", xitemsName, xstate);
                hasDataName = xitemsName;
            }

            OB.AddProperty("name", UniqueID);
            OB.AddProperty("items", String.Format("F.util.resolveCheckBoxGroup('{0}',{1},true)", UniqueID, hasDataName), true);
            */

            OB.AddProperty("name", UniqueID);
            OB.AddProperty("items", String.Format("F.util.resolveCheckBoxGroup('{0}',{1},true)", UniqueID, GetFStateScriptID()), true);

            #endregion

            #region AutoPostBack

            if (AutoPostBack)
            {
                // This event will be triggered twice, so we must filter the actually change.
                // If the current checked radio is losing focus, this function will alse be called and the radio parameter is true.
                // 改变选中项时，这个事件会被触发两次。
                // 当前选中项失去焦点时，这个回调函数也会被触发并设置radio为true。
                //OB.Listeners.AddProperty("change", String.Format("function(group,radio){{if(typeof(radio)!=='boolean'){{{0}}}}}", GetPostBackEventReference()), true);
                AddListener("change", String.Format("if(typeof(radio)!=='boolean'){{{0}}}", GetPostBackEventReference()), "group", "radio");
            }

            //if (!String.IsNullOrEmpty(SelectedValue))
            //{
            //    OB.AddProperty("value", SelectedValue);
            //} 

            #region old code
            //string autoPostBackScript = String.Empty;
            //if (AutoPostBack)
            //{
            //    //// change 事件只有在失去焦点时才触发，是不及时的
            //    //OB.Listeners.RemoveProperty(OptionName.Change);
            //    //OB.Listeners.AddProperty(OptionName.Check, String.Format("function(newValue,oldValue){{\r\nbox_pageStateChange();alert(newValue+':'+oldValue);\r\n}}"), true);

            //    string selectScript = String.Format("function(newValue,oldValue){{\r\nalert(newValue+':'+oldValue);\r\n}}");
            //    selectScript = String.Format("{0}.on('{1}',{2},box,{{delay:0}});", ClientID, OptionName.Check, selectScript);

            //    autoPostBackScript += selectScript;
            //} 

            //string backgroundColorStyle = String.Empty;
            //if (EnableBackgroundColor)
            //{
            //    backgroundColorStyle = AboutConfig.GetDefaultBackgroundColor(PageManagerInstance.Theme.ToString());
            //}
            //else if (EnableLightBackgroundColor)
            //{
            //    backgroundColorStyle = AboutConfig.GetLightBackgroundColor(PageManagerInstance.Theme.ToString());
            //}

            //if (!String.IsNullOrEmpty(backgroundColorStyle))
            //{
            //    string backgroundColorScript = String.Format("Ext.each(X.{0}.el.query('.x-panel-body'),function(item,index){{Ext.get(item).setStyle('background-color','{1}');}});", ClientJavascriptID, backgroundColorStyle);

            //    string renderScript = "(function(){" + backgroundColorScript + "}).defer(20);";
            //    OB.Listeners.AddProperty("render", "function(component){" + renderScript + "}", true);
            //}

            #endregion

            #endregion

            // EXTJS的BUG，不支持默认Readonly=true的情况，需要自己修正
            if (Readonly)
            {
                //OB.Listeners.AddProperty("render", JsHelper.GetFunction("cmp.setReadOnly(true);", "cmp"), true);
                AddListener("render", "cmp.setReadOnly(true);", "cmp");
            }

            string jsContent = String.Format("var {0}=Ext.create('Ext.form.RadioGroup',{1});", XID, OB.ToString());
            AddStartupScript(jsContent);
        }

        #region old code

        //private JArray GetItemsJArray()
        //{
        //    JArray ja = new JArray();
        //    int itemIndex = 0;
        //    foreach (RadioItem item in Items)
        //    {
        //        JObject jo = new JObject();
        //        jo.Add("inputValue", item.Value);
        //        jo.Add("boxLabel", item.Text);
        //        jo.Add("name", UniqueID);
        //        if (item.Selected)
        //        {
        //            jo.Add("checked", true);
        //        }

        //        ja.Add(jo);

        //        itemIndex++;
        //    }

        //    return ja;
        //} 

        #endregion

        #endregion

        #region DataBind

        /// <summary>
        /// 绑定到数据源
        /// </summary>
        public override void DataBind()
        {
            // 1. 首先清空 Items 属性
            Items.Clear();

            if (_dataSource != null)
            {
                
                // 2. 绑定到数据源
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

                //// F_Items属性不是ServerAjaxProperty，所以只在页面第一次加载时判断是否改变
                //if (!Page.IsPostBack)
                //{
                //    FState.AddModifiedProperty("F_Items");
                //}
            }

            base.DataBind();
        }

        /// <summary>
        /// 绑定到数据表
        /// </summary>
        /// <param name="dataTable"></param>
        private void DataBindToDataTable(DataTable dataTable)
        {
            int startIndex = 0;
            int endIndex = Int32.MaxValue;
            for (int i = startIndex; i < Math.Min(endIndex, dataTable.Rows.Count); i++)
            {
                DataRow row = dataTable.Rows[i];
                Items.Add(CreateRadioItem(row));
            }
        }

        /// <summary>
        /// 绑定到可枚举列表
        /// </summary>
        /// <param name="enumerable"></param>
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

            //    RadioItem item = new RadioItem();

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
                Items.Add(CreateRadioItem(currentObject));
            }
        }

        private RadioItem CreateRadioItem(Object obj)
        {
            RadioItem item = new RadioItem();
            if (obj is string)
            {
                item.Text = obj.ToString();
                item.Value = obj.ToString();
            }
            else
            {
                if (!String.IsNullOrEmpty(DataTextField))
                {
                    if (!String.IsNullOrEmpty(DataTextFormatString))
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

                if (!String.IsNullOrEmpty(DataValueField))
                {
                    item.Value = GetPropertyValue(obj, DataValueField);
                }
                else
                {
                    item.Value = obj.ToString();
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

            return result == null ? String.Empty : result.ToString();
        }

        #endregion

        #region IPostBackDataHandler Members

        /// <summary>
        /// 处理回发数据
        /// </summary>
        /// <param name="postDataKey">回发数据键</param>
        /// <param name="postCollection">回发数据集</param>
        /// <returns>回发数据是否改变</returns>
        public virtual bool LoadPostData(string postDataKey, System.Collections.Specialized.NameValueCollection postCollection)
        {
            //string postValue = postCollection[postDataKey];
            string[] selectedValueArray = StringUtil.GetStringListFromString(postCollection[SelectedValueArrayHiddenFieldID]).ToArray();
            string postValue = selectedValueArray.Length > 0 ? selectedValueArray[0] : String.Empty;
            if (SelectedValue != postValue)
            {
                SelectedValue = postValue;
                FState.BackupPostDataProperty("SelectedValue");
                return true;
            }
            return false;
        }
        
        
        /// <summary>
        /// 触发回发数据改变事件
        /// </summary>
        public virtual void RaisePostDataChangedEvent()
        {
            OnSelectedIndexChanged(EventArgs.Empty);
        }



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
    }
}
