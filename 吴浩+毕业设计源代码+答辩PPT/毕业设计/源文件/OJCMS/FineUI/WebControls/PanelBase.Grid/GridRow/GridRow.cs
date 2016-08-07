#region Comment

/*
 * Project��    FineUI
 * 
 * FileName:    GridRow.cs
 * CreatedOn:   2008-05-19
 * CreatedBy:   30372245@qq.com
 * 
 * 
 * Description��
 *      ->
 *   
 * History��
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
    /// �����
    /// </summary>
    [ToolboxItem(false)]
    public class GridRow // : WebControl
    {
        #region Constructor

        /// <summary>
        /// ���캯��
        /// </summary>
        public GridRow()
        {

        }

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="grid">���ʵ��</param>
        /// <param name="dataItem">�ж�Ӧ������Դ���ڻط�ʱΪnull��</param>
        /// <param name="rowIndex">�����</param>
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
        /// ���ʵ��
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
        /// ���ж�Ӧ������Դ����ά��״̬��
        /// </summary>
        public object DataItem
        {
            get { return _dataItem; }
            set { _dataItem = value; }
        }


        private int _rowIndex = 0;

        /// <summary>
        /// �ڼ���
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
        /// ���е�״̬��Ϣ
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
        /// ����DataKeyNames�ֶε�ֵ
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
        /// ����DataIDField�ֶε�ֵ
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
        /// �ǹ������ԣ�����CheckBoxField����ͨ��GetCheckedState����
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
        ///// ����Ҫ�����ֵ������CheckBoxField��Ҫ�����Ƿ�ѡ�е�״̬��
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
        /// �Ƿ���������״̬�б�
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
        /// �ָ���ǰ����״̬�б�
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

                // �Ѿ������˵�ǰ�е�States�������States�ָ���Ӧ��Ԫ���Value������CheckBoxField��GetColumnValue���Ǵ�States��ȡ��ֵ
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
        ///// ��ǰ����״̬�б�
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
        /// �ָ���ǰ����״̬�б�ͬʱ������Ӧ��Valuesֵ��
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
        /// ���µ�ǰ��ĳ�е���Ⱦ���HTML
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
        /// �������ģ���пؼ��б�һ�����͵�����Ϊ��[GridRowControl, null, null, GridRowControl, null, null, null, null, null]
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
        /// �������ģ���пؼ��б����ݰ�ʱ�Զ�����ÿ��ģ���пؼ�ID���ط�ʱ��FState�лط�ģ���пؼ�ID��
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
                    

                    // ����ָ��ID�����Զ��������� ct123 ��ΨһID
                    //control.ID = String.Format("c{0}r{1}", column.ColumnIndex, RowIndex);

                    if (DataItem == null)
                    {
                        // �ط�ʱ�ָ�FState�׶Σ������ݰ󶨽׶Σ�����Values�ж�ȡģ���еķ�����ID���ڵ�һ�μ���ʱ�Զ����ɵģ�
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
        ///// ���ӿؼ�
        ///// </summary>
        //protected override void DataBindChildren()
        //{
        //    base.DataBindChildren();

        //    DataBindRow();
        //}

        /// <summary>
        /// ���е�ֵ
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
                // ������δ���� DataIDField�����Զ�����һ�� RowId
                //RowID = GridRowIDManager.Instance.GetNextGridRowID();

                // ������δ���� DataIDField�����Զ�����һ�� RowId
                // ʹ�� rowIndex ����װ RowId����ҳ��ط���������ԱȽ��ȶ�
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

            // ����ÿ�е�ֵ
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

            // ����DataKeys��ֵ
            if (_grid.DataKeyNames != null)
            {
                string[] keyNames = _grid.DataKeyNames;
                DataKeys = new object[keyNames.Length];
                for (int j = 0, count = keyNames.Length; j < count; j++)
                {
                    string keyName = keyNames[j];

                    if (_grid.AllowCellEditing)
                    {
                        // �������Ԫ��༭����DataKeys��ֵ���ͳ���ʹ���ж����FieldType
                        // ȷ���û��ڿͻ����޸���DataKeyNames�ж����ֵ��ͬʱ��Grid��LoadPostData�и������ֵ
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
            // ɾ������HTML�е� "\r\n     "
            return Regex.Replace(columnValue, "\r?\n\\s*", "");
        }

        #endregion

        #region FindControl

        /// <summary>
        /// ���ұ�����ڵĿؼ�
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



