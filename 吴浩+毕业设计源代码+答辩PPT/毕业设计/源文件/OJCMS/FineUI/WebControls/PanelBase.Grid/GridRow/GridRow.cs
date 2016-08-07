#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    GridRow.cs
 * CreatedOn:   2008-05-19
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
using System.Data;
using System.Reflection;
using System.ComponentModel;
using System.Web.UI;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;

using Newtonsoft.Json.Linq;
using System.Collections.ObjectModel;

namespace FineUI
{
    /// <summary>
    /// 表格行
    /// </summary>
    [ToolboxItem(false)]
    public class GridRow // : WebControl
    {
        #region Constructor

        /// <summary>
        /// 构造函数
        /// </summary>
        public GridRow()
        {

        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="grid">表格实例</param>
        /// <param name="dataItem">行对应的数据源（在回发时为null）</param>
        /// <param name="rowIndex">行序号</param>
        public GridRow(Grid grid, object dataItem, int rowIndex)
        {
            _grid = grid;
            _dataItem = dataItem;
            _rowIndex = rowIndex;
        }

        #endregion

        #region Grid/DataItem/RowIndex

        private Grid _grid;

        /// <summary>
        /// 表格实例
        /// </summary>
        public Grid Grid
        {
            get
            {
                return _grid;
            }
        }

        private object _dataItem = null;

        /// <summary>
        /// 本行对应的数据源（不维护状态）
        /// </summary>
        public object DataItem
        {
            get { return _dataItem; }
            set { _dataItem = value; }
        }


        private int _rowIndex = 0;

        /// <summary>
        /// 第几行
        /// </summary>
        public int RowIndex
        {
            get
            {
                return _rowIndex;
            }
            set
            {
                _rowIndex = value;
            }
        }


        #endregion

        #region Properties

        private object[] _values = null;

        /// <summary>
        /// 此行的状态信息
        /// </summary>
        public object[] Values
        {
            get
            {
                return _values;
            }
            set
            {
                _values = value;
            }
        }

        private object[] _dataKeys = null;

        /// <summary>
        /// 此行DataKeyNames字段的值
        /// </summary>
        public object[] DataKeys
        {
            get
            {
                return _dataKeys;
            }
            set
            {
                _dataKeys = value;
            }
        }

        private string _rowID = String.Empty;

        /// <summary>
        /// 此行DataIDField字段的值
        /// </summary>
        public string RowID
        {
            get
            {
                return _rowID;
            }
            internal set
            {
                _rowID = value;
            }
        }

        private object[] _states = null;

        /// <summary>
        /// 非公开属性，对于CheckBoxField可以通过GetCheckedState访问
        /// </summary>
        internal object[] States
        {
            get
            {
                return _states;
            }
            set
            {
                _states = value;
            }
        }

        //private object[] _extraValues = null;
        ///// <summary>
        ///// 附加要保存的值（比如CheckBoxField需要保存是否选中的状态）
        ///// </summary>
        //internal object[] ExtraValues
        //{
        //    get
        //    {
        //        return _extraValues;
        //    }
        //    set
        //    {
        //        _extraValues = value;
        //    }
        //}

        #endregion

        #region ToShortStates/FromShortStates

        /// <summary>
        /// 是否定义了行列状态列表
        /// </summary>
        /// <returns></returns>
        internal bool HasStates()
        {
            bool defined = false;

            foreach (object state in _states)
            {
                if (state != null)
                {
                    defined = true;
                    break;
                }
            }

            return defined;
        }


        /// <summary>
        /// 恢复当前行列状态列表
        /// </summary>
        /// <param name="states"></param>
        internal void RecoverStates(object[] states)
        {
            if (states == null || states.Length == 0)
            {
                Collection<GridColumn> columns = _grid.AllColumns;
                _states = new object[columns.Count];
            }
            else
            {
                _states = states;

                // 已经更新了当前行的States，下面从States恢复相应单元格的Value，比如CheckBoxField的GetColumnValue就是从States读取的值
                int columnIndex = 0;
                foreach (object state in _states)
                {
                    if (state != null)
                    {
                        UpdateValuesAt(columnIndex);
                    }

                    columnIndex++;
                }
            }
        }

        ///// <summary>
        ///// 当前行列状态列表
        ///// </summary>
        ///// <returns></returns>
        //internal object[] ToShortStates()
        //{
        //    List<object> shortStates = new List<object>();
        //    Collection<GridColumn> columns = _grid.AllColumns;
        //    for (int i = 0, count = columns.Count; i < count; i++)
        //    {
        //        if (columns[i].PersistState)
        //        {
        //            shortStates.Add(States[i]);
        //        }
        //    }
        //    return shortStates.ToArray();
        //}

        /// <summary>
        /// 恢复当前行列状态列表（同时更新相应的Values值）
        /// </summary>
        /// <param name="shortStates"></param>
        internal void FromShortStates(object[] shortStates)
        {
            if (shortStates == null || shortStates.Length == 0)
            {
                return;
            }

            Collection<GridColumn> columns = _grid.AllColumns;
            States = new object[columns.Count];
            int shortStateIndex = 0;
            for (int i = 0, count = columns.Count; i < count; i++)
            {
                GridColumn column = columns[i];
                if (column.PersistState)
                {
                    object state = shortStates[shortStateIndex++];
                    if (state is JValue)
                    {
                        States[i] = (state as JValue).Value;
                    }
                    else
                    {
                        States[i] = state;
                    }


                    UpdateValuesAt(i);
                }
            }
        }


        /// <summary>
        /// 更新当前行某列的渲染后的HTML
        /// </summary>
        /// <param name="columnIndex"></param>
        internal void UpdateValuesAt(int columnIndex)
        {
            Values[columnIndex] = _grid.AllColumns[columnIndex].GetColumnValue(this);
        }

        #endregion

        #region TemplateContainers


        private GridTemplateContainer[] _templateContainers = null;
        
        /// <summary>
        /// 表格行中模板列控件列表，一个典型的例子为：[GridRowControl, null, null, GridRowControl, null, null, null, null, null]
        /// </summary>
        public GridTemplateContainer[] TemplateContainers
        {
            get
            {
                return _templateContainers;
            }
            set
            {
                _templateContainers = value;
            }
        }

        /// <summary>
        /// 表格行中模板列控件列表（数据绑定时自动生成每个模板列控件ID，回发时从FState中回发模板列控件ID）
        /// </summary>
        public void InitTemplateContainers()
        {
            Collection<GridColumn> columns = _grid.AllColumns;
            TemplateContainers = new GridTemplateContainer[columns.Count];

            for (int i = 0, count = columns.Count; i < count; i++)
            {
                GridColumn column = columns[i];
                if (column is TemplateField)
                {
                    TemplateField field = column as TemplateField;
                    GridTemplateContainer control = new GridTemplateContainer(DataItem, RowIndex);
                    

                    // 不用指定ID，会自动生成类似 ct123 的唯一ID
                    //control.ID = String.Format("c{0}r{1}", column.ColumnIndex, RowIndex);

                    if (DataItem == null)
                    {
                        // 回发时恢复FState阶段（非数据绑定阶段），从Values中读取模板列的服务器ID（在第一次加载时自动生成的）
                        string fieldValue = Values[i].ToString();
                        if (fieldValue.StartsWith(Grid.TEMPLATE_PLACEHOLDER_PREFIX))
                        {
                            control.ID = fieldValue.Substring(Grid.TEMPLATE_PLACEHOLDER_PREFIX.Length);
                        }
                    }

                    

                    field.ItemTemplate.InstantiateIn(control);

                    _grid.Controls.Add(control);
                    TemplateContainers[column.ColumnIndex] = control;


                }

            }
        }

        #endregion

        #region DataBindRow

        ///// <summary>
        ///// 绑定子控件
        ///// </summary>
        //protected override void DataBindChildren()
        //{
        //    base.DataBindChildren();

        //    DataBindRow();
        //}

        /// <summary>
        /// 绑定行的值
        /// </summary>
        internal void DataBindRow()
        {
            // DataIDField
            if (!String.IsNullOrEmpty(Grid.DataIDField))
            {
                RowID = GetPropertyValue(Grid.DataIDField).ToString();
            }
            else
            {
                // 如果表格未定义 DataIDField，则自动生成一个 RowId
                //RowID = GridRowIDManager.Instance.GetNextGridRowID();

                // 如果表格未定义 DataIDField，则自动生成一个 RowId
                // 使用 rowIndex 来组装 RowId，在页面回发过程中相对比较稳定
                RowID = String.Format("frow{0}", RowIndex);
            }




            foreach (GridTemplateContainer tplCtrl in TemplateContainers)
            {
                if (tplCtrl != null)
                {
                    tplCtrl.DataBind();
                }
            }


            Collection<GridColumn> columns = _grid.AllColumns;

            // 计算每列的值
            Values = new object[columns.Count];
            States = new object[columns.Count];

            for (int i = 0, count = columns.Count; i < count; i++)
            {
                GridColumn column = columns[i];
                Values[i] = column.GetColumnValue(this);

                if (column.PersistState)
                {
                    States[i] = column.GetColumnState(this);
                }
            }

            // 计算DataKeys的值
            if (_grid.DataKeyNames != null)
            {
                string[] keyNames = _grid.DataKeyNames;
                DataKeys = new object[keyNames.Length];
                for (int j = 0, count = keyNames.Length; j < count; j++)
                {
                    string keyName = keyNames[j];

                    if (_grid.AllowCellEditing)
                    {
                        // 如果允许单元格编辑，则DataKeys的值类型尝试使用列定义的FieldType
                        // 确保用户在客户端修改了DataKeyNames中定义的值后，同时在Grid的LoadPostData中更新这个值
                        if (_grid.cellEditingDataKeyNameField.ContainsKey(keyName))
                        {
                            DataKeys[j] = _grid.cellEditingDataKeyNameField[keyName].GetColumnValue(this);
                        }
                    }

                    if (DataKeys[j] == null)
                    {
                        DataKeys[j] = GetPropertyValue(keyName);
                    }
                }
            }
        }


        internal object GetPropertyValue(string propertyName)
        {
            return ObjectUtil.GetPropertyValue(DataItem, propertyName);
        }

        private string RemoveNewLine(string columnValue)
        {
            // 删除生成HTML中的 "\r\n     "
            return Regex.Replace(columnValue, "\r?\n\\s*", "");
        }

        #endregion

        #region FindControl

        /// <summary>
        /// 查找表格行内的控件
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Control FindControl(string id)
        {
            foreach (GridTemplateContainer control in TemplateContainers)
            {
                if (control != null)
                {
                    Control found;
                    if (control.ID == id)
                    {
                        found = control;
                    }
                    else
                    {
                        found = control.FindControl(id);
                    }

                    if (found != null)
                    {
                        return found;
                    }
                }
            }

            return null;
        }

        #endregion

        
    }
}



