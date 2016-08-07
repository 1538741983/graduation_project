
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    Form.cs
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
using System.ComponentModel.Design;

namespace FineUI
{
    /// <summary>
    /// 表单面板控件
    /// </summary>
    [Designer("FineUI.Design.FormDesigner, FineUI.Design")]
    [ToolboxData("<{0}:Form Title=\"Form\" BodyPadding=\"5px\" runat=\"server\"><Rows><{0}:FormRow runat=\"server\"></{0}:FormRow><{0}:FormRow runat=\"server\"></{0}:FormRow></Rows></{0}:Form>")]
    [ToolboxBitmap(typeof(Form), "toolbox.Form.bmp")]
    [Description("表单面板控件")]
    [ParseChildren(true)]
    [PersistChildren(false)]
    [ControlBuilder(typeof(NotAllowWhitespaceLiteralsBuilder))]
    public class Form : FormBase
    {
        #region Constructor

        /// <summary>
        /// 构造函数
        /// </summary>
        public Form()
        {
            AddServerAjaxProperties();
            AddClientAjaxProperties();
        }

        #endregion

        #region Unsupported Properties

        /// <summary>
        /// 不支持此属性
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override ITemplate Content
        {
            get
            {
                return base.Content;
            }
        }

        ///// <summary>
        ///// 不支持此属性
        ///// </summary>
        //[Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public override ControlBaseCollection Items
        //{
        //    get
        //    {
        //        return base.Items;
        //    }
        //}

        

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

        #region FormRowItemsSpace

        /// <summary>
        /// 表单行子项之间的间距
        /// </summary>
        [Category(CategoryName.LAYOUT)]
        [DefaultValue(typeof(Unit), ConfigPropertyValue.FORMROW_ITEMSSPACE_DEFAULT_STRING)]
        [Description("表单行子项之间的间距")]
        public Unit FormRowItemsSpace
        {
            get
            {
                object obj = FState["FormRowItemsSpace"];
                if (obj == null)
                {
                    if (DesignMode)
                    {
                        return ConfigPropertyValue.FORMROW_ITEMSSPACE_DEFAULT;
                    }
                    else
                    {
                        return PageManager.Instance.FormRowItemsSpace;
                    }
                }
                return (Unit)obj;
            }
            set
            {
                FState["FormRowItemsSpace"] = value;
            }
        }

        #endregion

        #region Rows

        private FormRowCollection _rows;

        /// <summary>
        /// 表单行控件集合
        /// </summary>
        [Browsable(false)]
        [Category(CategoryName.OPTIONS)]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Editor(typeof(CollectionEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public virtual FormRowCollection Rows
        {
            get
            {
                if (_rows == null)
                {
                    _rows = new FormRowCollection(this);
                }
                return _rows;
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

            #region Options

            

            #endregion

            #region ResolveRows

            //// 包含行的列脚本
            //string rowScriptStr = String.Empty;
            //// 行的集合
            //string rowItemScriptStr = String.Empty;

            //// 如果存在Rows集合
            //if (Rows.Count > 0)
            //{
            //    // rowScriptStr
            //    // rowItemScriptStr: [X.__Panel1_UpdatePanelConnector1_Panel7_Form5_row0,X.__Panel1_UpdatePanelConnector1_Panel7_Form5_row2]
            //    ResolveRows(ref rowScriptStr, ref rowItemScriptStr);

            //    // 添加Items
            //    OB.RemoveProperty("items");
            //    OB.AddProperty("items", rowItemScriptStr, true);
            //}

            ////rowScriptStr += "\r\n";


            #endregion

            #region Rows

            if (Rows.Count > 0)
            {
                JsArrayBuilder ab = new JsArrayBuilder();
                foreach (FormRow row in Rows)
                {
                    if (row.Visible)
                    {
                        ab.AddProperty(String.Format("{0}", row.XID), true);
                    }
                }

                OB.AddProperty("items", ab.ToString(), true);
            }

            #endregion


            AddListener("dirtychange", "F.util.setPageStateChanged(dirty);", "form", "dirty");
            


            string formPanelScript = String.Format("var {0}=Ext.create('Ext.form.Panel',{1});", XID, OB.ToString());
            
            //string jsContent = rowScriptStr + formPanelScript;
            AddStartupScript(formPanelScript);
        }

        #region oldcode
        ///// <summary>
        ///// 处理列
        ///// </summary>
        ///// <returns></returns>
        //private void ResolveRows(ref string rowScriptsStr, ref string rowIdsStr)
        //{
        //    JsArrayBuilder rowIdsBuilder = new JsArrayBuilder();

        //    // 上一行的列数
        //    int lastRowColumnCount = 1;
        //    // 上一行的列数
        //    string lastRowColumnWidths = String.Empty;
        //    // 是否已经开始多列
        //    bool isMultiColumnStarted = false;
        //    // 多列的开始行的序号
        //    int multiColumnStartLineIndex = 0;

        //    for (int i = 0, rowCount = Rows.Count; i < rowCount; i++)
        //    {
        //        FormRow currentRow = Rows[i];
        //        int currentRowColumnCount = GetRowColumnCount(currentRow);
        //        string currentRowColumnWidths = currentRow.ColumnWidths;

        //        if (currentRowColumnCount == 0)
        //        {
        //            // 如果当前行为空，则跳过此行
        //            continue;
        //        }
        //        else if (currentRowColumnCount == 1)
        //        {
        //            if (isMultiColumnStarted)
        //            {
        //                // 如果上一行是多列行，则添加本行之上的所有行
        //                rowScriptsStr += AddColumnScript(rowIdsBuilder, multiColumnStartLineIndex, i - 1, lastRowColumnCount);
        //                //rowScriptsStr += "\r\n";

        //                // 开始重置记录本行为多列的开始
        //                isMultiColumnStarted = false;
        //                multiColumnStartLineIndex = 0;
        //            }

        //            // 如果当前行的列数为1，则直接添加Field元素
        //            //AddItemScript(ab, currentRow.Fields[0].ClientID);
        //            ControlBase component = GetRowColumnControl(currentRow, 0);
        //            if (component != null)
        //            {
        //                rowIdsBuilder.AddProperty(String.Format("{0}", component.XID), true);
        //            }
        //        }
        //        else
        //        {
        //            // 如果本行是多列
        //            if (!isMultiColumnStarted)
        //            {
        //                // 如果上一行还是单列的话，则开始多列
        //                isMultiColumnStarted = true;
        //                multiColumnStartLineIndex = i;
        //            }
        //            else
        //            {
        //                if (lastRowColumnCount == currentRowColumnCount && lastRowColumnWidths == currentRowColumnWidths)
        //                {
        //                    // 如果上一行的列数和本行的列数相同（并且上一行每列的宽度和本行的每列宽度也一样），则继续下一行
        //                }
        //                else
        //                {
        //                    // 如果上一行的列数和本行的列数不相同，则添加本行之上的所有行
        //                    rowScriptsStr += AddColumnScript(rowIdsBuilder, multiColumnStartLineIndex, i - 1, lastRowColumnCount);
        //                    //rowScriptsStr += "\r\n";

        //                    // 开始重新记录本行为多列的开始
        //                    isMultiColumnStarted = true;
        //                    multiColumnStartLineIndex = i;
        //                }
        //            }
        //        }


        //        lastRowColumnCount = currentRowColumnCount;
        //        lastRowColumnWidths = currentRowColumnWidths;
        //    }


        //    // 还要判断一下（如果最后一行是两列的情况）
        //    if (isMultiColumnStarted)
        //    {
        //        rowScriptsStr += AddColumnScript(rowIdsBuilder, multiColumnStartLineIndex, Rows.Count - 1, lastRowColumnCount);
        //        //rowScriptsStr += "\r\n";
        //    }

        //    rowIdsStr = rowIdsBuilder.ToString();
        //}

        ///// <summary>
        ///// 添加列
        ///// </summary>
        ///// <param name="rowIdsBuilder">行ID集合</param>
        ///// <param name="startLineIndex">开始行的索引（包含）</param>
        ///// <param name="endLineIndex">结束行的索引（包含）</param>
        ///// <param name="columnCount">行的列数</param>
        //private string AddColumnScript(JsArrayBuilder rowIdsBuilder, int startLineIndex, int endLineIndex, int columnCount)
        //{
        //    // 注意，注册脚本的控件应该是最后一个 Row
        //    // 假如有从上之下这些控件： Row1(Field1,Field2), Row2(Field3,Field4),Row3(Field5)
        //    // 则渲染时，JS脚本的执行顺序为：Field1,Field2,Row1,Field3,Field4,Row2,Field5,Row3
        //    // 所以，如果column Panel的脚本注册为控件 Row3，则能保证所有的子控件已经初始化
        //    // 需要注意的是：在此设置脚本内容到 Row3 控件
        //    // 现在已经不是这样的了！！！，Row不在是一个控件

        //    #region examples


        //    //            {
        //    //                    layout: 'column',
        //    //                    border:false,
        //    //                    items:[{
        //    //                        columnWidth: .5,
        //    //                        layout: 'form',
        //    //                        border:false,
        //    //                        items:[{
        //    //                            xtype:'combo',
        //    //                            store: nextStepStore,
        //    //                            displayField:'text',
        //    //                            valueField:'value',
        //    //                            typeAhead: true,
        //    //                            mode: 'local',
        //    //                            triggerAction: 'all',
        //    //                            value:'1',
        //    //                            emptyText:'请选择下一步',
        //    //                            selectOnFocus:true,
        //    //                            allowBlank:false,
        //    //                            fieldLabel: '下一步',
        //    //                            labelSeparator:'&nbsp;<span style="color:red;vertical-align:text-bottom;">*</span>',
        //    //                            name: 'nextStep',
        //    //                            anchor:'95%'
        //    //                        }]
        //    //                    },{
        //    //                        columnWidth: .5,
        //    //                        layout: 'form',
        //    //                        border:false,
        //    //                        items:[{
        //    //                            xtype:'combo',
        //    //                            store: executePersonStore,
        //    //                            displayField:'text',
        //    //                            valueField:'value',
        //    //                            typeAhead: true,
        //    //                            mode: 'local',
        //    //                            triggerAction: 'all',
        //    //                            value:'1',
        //    //                            emptyText:'请选择执行人',
        //    //                            selectOnFocus:true,
        //    //                            allowBlank:false,
        //    //                            fieldLabel: '执行人',
        //    //                            labelSeparator:'&nbsp;<span style="color:red;vertical-align:text-bottom;">*</span>',
        //    //                            name: 'executePerson',
        //    //                            anchor:'95%'
        //    //                        }]
        //    //                    }]
        //    //          }


        //    #endregion


        //    // 最后一行
        //    FormRow endLineRow = Rows[endLineIndex];
        //    string rowId = String.Format("{0}_row{1}", XID, endLineIndex);



        //    string defaultColumnWidthStr = (1.0 / columnCount).ToString("F2", System.Globalization.CultureInfo.InvariantCulture);
        //    string[] columnWidths = ResolveColumnWidths(columnCount, Rows[startLineIndex].ColumnWidths, defaultColumnWidthStr);

        //    // row_column
        //    JsArrayBuilder rowColumnScriptsBuilder = new JsArrayBuilder();
        //    for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
        //    {
        //        #region 计算每一列的值

        //        // 循环每一列
        //        JsArrayBuilder fieldsAB = new JsArrayBuilder();
        //        for (int rowIndex = startLineIndex; rowIndex <= endLineIndex; rowIndex++)
        //        {
        //            FormRow currentRow = Rows[rowIndex];

        //            if (columnIndex <= GetRowColumnCount(currentRow) - 1)
        //            {
        //                ControlBase component = GetRowColumnControl(currentRow, columnIndex);
        //                if (component != null)
        //                {
        //                    fieldsAB.AddProperty(String.Format("{0}", component.XID), true);
        //                }
        //            }
        //        }

        //        // 当前列的创建JS
        //        JsObjectBuilder columnOB = new JsObjectBuilder();
        //        string columnWidth = columnWidths[columnIndex];
        //        if (Convert.ToDouble(columnWidth) <= 1.0)
        //        {
        //            columnOB.AddProperty("columnWidth", columnWidths[columnIndex], true);
        //        }
        //        else
        //        {
        //            columnOB.AddProperty("width", columnWidths[columnIndex], true);
        //        }

        //        columnOB.AddProperty("layout", "anchor");
        //        columnOB.AddProperty("border", false);
        //        columnOB.AddProperty("id", rowId + "_column" + columnIndex.ToString());

        //        // 如果不是最后一列，则默认距离右侧 5px 
        //        if (columnIndex != columnCount - 1)
        //        {
        //            columnOB.AddProperty("margin", "0 5 0 0");
        //        }

        //        // 有可能为空
        //        if (fieldsAB.Count > 0)
        //        {
        //            columnOB.AddProperty("items", fieldsAB.ToString(), true);
        //        }


        //        rowColumnScriptsBuilder.AddProperty(columnOB.ToString(), true);

        //        // 现在采取的是安全的ajax，不会出现下面的情况
        //        //// 所有Layout=form的地方必须用Ext.FormPanel，否则删除时不会把FieldLabek删除掉
        //        //rowColumnScriptsBuilder.AddProperty(String.Format("new Ext.FormPanel({0})", columnOB.ToString()), true);

        //        #endregion
        //    }

        //    // 外面的JS（X.__Panel1_UpdatePanelConnector1_Panel7_Form5_row0）
        //    JsObjectBuilder rowBuilder = new JsObjectBuilder();
        //    rowBuilder.AddProperty("layout", "column");
        //    rowBuilder.AddProperty("border", false);



        //    // 有可能为空
        //    if (rowColumnScriptsBuilder.Count > 0)
        //    {
        //        rowBuilder.AddProperty("items", rowColumnScriptsBuilder.ToString(), true);
        //    }


        //    // 把当前节点添加到结果集合中
        //    rowIdsBuilder.AddProperty(String.Format("{0}", rowId), true);
        //    rowBuilder.AddProperty("id", rowId);

        //    // 注意要注册 最后 一个 Row的脚本
        //    return String.Format("var {0}=Ext.create('Ext.panel.Panel',{1});", rowId, rowBuilder.ToString());
        //}

        ///// <summary>
        ///// 添加Items变量
        ///// </summary>
        ///// <param name="ab"></param>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //private void AddItemScript(JsArrayBuilder ab, string id)
        //{
        //    ab.AddProperty(String.Format("{0}", id), true);
        //}

        ///// <summary>
        ///// 取得当前行的列数
        ///// </summary>
        ///// <param name="row"></param>
        ///// <returns></returns>
        //private int GetRowColumnCount(FormRow row)
        //{
        //    int fieldCount = 0;

        //    foreach (Control c in row.Controls)
        //    {
        //        if (c is ControlBase)
        //        {
        //            fieldCount++;
        //        }
        //    }

        //    #region old code
        //    //if (row.ColumnCount == null)
        //    //{
        //    //    return fieldCount;
        //    //}
        //    //else
        //    //{
        //    //    if (row.ColumnCount.Value > fieldCount)
        //    //    {
        //    //        return row.ColumnCount.Value;
        //    //    }
        //    //    else
        //    //    {
        //    //        return fieldCount;
        //    //    }
        //    //} 
        //    #endregion

        //    return fieldCount;
        //}

        ///// <summary>
        ///// 取得当前行 columnIndex 列的控件
        ///// </summary>
        ///// <param name="row"></param>
        ///// <param name="columnIndex"></param>
        ///// <returns></returns>
        //private ControlBase GetRowColumnControl(FormRow row, int columnIndex)
        //{
        //    int index = 0;
        //    foreach (Control c in row.Controls)
        //    {
        //        if (c is ControlBase)
        //        {
        //            if (columnIndex == index)
        //            {
        //                return c as ControlBase;
        //            }

        //            index++;
        //        }
        //    }

        //    return null;
        //}

        //private string[] ResolveColumnWidths(int columnCount, string columnWidths, string defaultColumnWidthStr)
        //{
        //    string[] results = null;
        //    if (!String.IsNullOrEmpty(columnWidths))
        //    {
        //        string[] columnWidthArray = columnWidths.Split(' ');
        //        if (columnWidthArray.Length == columnCount)
        //        {
        //            results = columnWidthArray;
        //        }
        //    }

        //    if (results == null)
        //    {
        //        results = new string[columnCount];
        //        for (int i = 0; i < columnCount; i++)
        //        {
        //            results[i] = defaultColumnWidthStr;
        //        }
        //    }

        //    return results;
        //} 
        #endregion

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
