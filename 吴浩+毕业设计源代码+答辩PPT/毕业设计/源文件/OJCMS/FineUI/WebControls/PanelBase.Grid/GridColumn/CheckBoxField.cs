
#region Comment

/*
 * Project��    FineUI
 * 
 * FileName:    CheckBoxField.cs
 * CreatedOn:   2008-05-27
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
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Text;
using System.Xml;
using System.Web;
using System.Web.UI;
using System.Globalization;
using System.Reflection;
using System.Collections.Generic;


namespace FineUI
{
    /// <summary>
    /// ���ѡ����
    /// </summary>
    [ToolboxItem(false)]
    [ParseChildren(true)]
    [PersistChildren(false)]
    public class CheckBoxField : BaseField
    {
        #region Properties

        private bool _enabled = true;

        /// <summary>
        /// �Ƿ���ã�ֻ��RenderAsStaticField=falseʱ��Ч��
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("�Ƿ���ã�ֻ��RenderAsStaticField=falseʱ��Ч��")]
        public override bool Enabled
        {
            get
            {
                return _enabled;
            }
            set
            {
                _enabled = value;
            }
        }

        private bool _autoPostBack = false;

        /// <summary>
        /// �Ƿ��Զ��ط���ֻ��RenderAsStaticField=falseʱ��Ч��
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("�Ƿ��Զ��ط���ֻ��RenderAsStaticField=false����ShowHeaderCheckBox=falseʱ��Ч��")]
        public bool AutoPostBack
        {
            get
            {
                return _autoPostBack;
            }
            set
            {
                _autoPostBack = value;
            }
        }


        private string _dataField = "";

        /// <summary>
        /// �ֶ�����
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("�ֶ�����")]
        public string DataField
        {
            get
            {
                return _dataField;
            }
            set
            {
                _dataField = value;
            }
        }


        private bool _renderAsStaticField = true;

        /// <summary>
        /// ��ȾΪ��̬ͼƬ��������ȾΪ�ɱ༭�ĸ�ѡ��
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("��ȾΪ��̬ͼƬ��������ȾΪ�ɱ༭�ĸ�ѡ��")]
        public bool RenderAsStaticField
        {
            get
            {
                return _renderAsStaticField;
            }
            set
            {
                _renderAsStaticField = value;
            }
        }


        private bool _showHeaderCheckBox = false;


        /// <summary>
        /// ��ʾ��ͷ��ѡ��ֻ��RenderAsStaticField=falseʱ��Ч��
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("��ʾ��ͷ��ѡ��ֻ��RenderAsStaticField=falseʱ��Ч��")]
        public bool ShowHeaderCheckBox
        {
            get
            {
                return _showHeaderCheckBox;
            }
            set
            {
                _showHeaderCheckBox = value;
            }
        }

        internal override string InnerCls
        {
            get
            {
                return "f-grid-cell-inner-image";
            }
        }


        

        #endregion

        #region EnableAjax

        private object _enableAjax = null;

        /// <summary>
        /// �Ƿ�����AJAX
        /// </summary>
        [Category(CategoryName.BASEOPTIONS)]
        [DefaultValue(true)]
        [Description("�Ƿ�����AJAX")]
        public override bool EnableAjax
        {
            get
            {
                if (_enableAjax == null)
                {
                    if (DesignMode)
                    {
                        return true;
                    }
                    else
                    {
                        return Grid.EnableAjax;
                    }
                }
                return (bool)_enableAjax;
            }
            set
            {
                _enableAjax = value;
            }
        }

        #endregion

        #region CommandName

        private string _commandName = "";

        /// <summary>
        /// ��������
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("��������")]
        public string CommandName
        {
            get
            {
                return _commandName;
            }
            set
            {
                _commandName = value;
            }
        }

        private string _commandArgument = "";

        /// <summary>
        /// �������
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("�������")]
        public string CommandArgument
        {
            get
            {
                return _commandArgument;
            }
            set
            {
                _commandArgument = value;
            }
        }


        #endregion

        #region GetHeaderValue/GetColumnValue

        internal override string GetHeaderValue()
        {
            if (!RenderAsStaticField && ShowHeaderCheckBox)
            {
                string result = String.Empty;

                //string textAlignClass = String.Empty;
                //if (TextAlign != TextAlign.Left)
                //{
                //    textAlignClass = "align-" + TextAlignName.GetName(TextAlign);
                //}

                string onClickScript = "F.toggle(this,'unchecked');";
                //onClickScript += "F.stop();";

                //string tooltip = String.Empty;
                //if (!String.IsNullOrEmpty(HeaderText))
                //{
                //    tooltip = String.Format(" ext:qtip=\"{0}\" ", HeaderText);
                //}

                result = String.Format("<div class=\"f-grid-checkbox unchecked\" onclick=\"{0}\">{1}</div>", 
                    onClickScript, HeaderText);

                return result;
            }
            else
            {
                return base.GetHeaderValue();
            }
        }


        internal override object GetColumnValue(GridRow row)
        {
            string result = String.Empty;

            bool checkState = Convert.ToBoolean(GetColumnState(row));

            result = GetColumnValue(row, checkState);

            string tooltip = GetTooltipString(row);
            if (!String.IsNullOrEmpty(tooltip))
            {
                result = result.ToString().Insert("<img".Length, tooltip);
            }

            return result;
        }

        /// <summary>
        /// ȡ�õ�Ԫ�������
        /// </summary>
        /// <param name="row"></param>
        /// <param name="checkState"></param>
        /// <returns></returns>
        private string GetColumnValue(GridRow row, bool checkState)
        {
            string result = String.Empty;
            string emptyImageUrl = Grid.ResolveUrl(ResourceHelper.GetEmptyImageUrl());

            if (!String.IsNullOrEmpty(DataField))
            {
                //string textAlignClass = String.Empty;
                //if (TextAlign != TextAlign.Left)
                //{
                //    textAlignClass = "align-" + TextAlignName.GetName(TextAlign);
                //}

                if (RenderAsStaticField)
                {
                    if (checkState)
                    {
                        result = String.Format("<img class=\"f-grid-static-checkbox\" src=\"{0}\"/>", emptyImageUrl);
                    }
                    else
                    {
                        result = String.Format("<img class=\"f-grid-static-checkbox unchecked\" src=\"{0}\"/>", emptyImageUrl);
                    }
                }
                else
                {
                    string paramStr = String.Format("Command${0}${1}${2}${3}", row.RowID, ColumnID, CommandName.Replace("'", "\""), CommandArgument.Replace("'", "\""));
                    
                    // �ӳ�ִ�У�ȷ����ǰ��ѡ���״̬�Ѿ��ı�
                    string postBackReference = JsHelper.GetDeferScript(Grid.GetPostBackEventReference(paramStr, EnableAjax), 0);

                    // string onClickScript = String.Format("{0}_checkbox{1}(event,this,{2});", Grid.XID, ColumnIndex, row.RowIndex);
                    //string onClickScript = "Ext.get(this).toggleClass('unchecked');";
                    string onClickScript = "F.toggle(this,'unchecked');";
                    if (!ShowHeaderCheckBox && AutoPostBack)
                    {
                        onClickScript += postBackReference;
                    }

                    //onClickScript += "F.stop();";

                    if (checkState)
                    {
                        if (Enabled)
                        {
                            result = String.Format("<img class=\"f-grid-checkbox\" src=\"{0}\" onclick=\"{1}\"/>", emptyImageUrl, onClickScript);
                        }
                        else
                        {
                            result = String.Format("<img class=\"f-grid-checkbox disabled\" src=\"{0}\"/>", emptyImageUrl);
                        }
                    }
                    else
                    {
                        if (Enabled)
                        {
                            result = String.Format("<img class=\"f-grid-checkbox unchecked\" src=\"{0}\" onclick=\"{1}\"/>", emptyImageUrl, onClickScript);
                        }
                        else
                        {
                            result = String.Format("<img class=\"f-grid-checkbox unchecked disabled\" src=\"{0}\"/>", emptyImageUrl);
                        }
                    }
                }
            }

            return result;
        }


        //public override string GetFieldType()
        //{
        //    return "string";
        //}

        #endregion

        #region SaveColumnState/LoadColumnState

        internal override bool PersistState
        {
            get
            {
                if (RenderAsStaticField)
                {
                    return false;
                }
                return true;
            }
        }

        internal override object GetColumnState(GridRow row)
        {
            if (row.DataItem == null)
            {
                return row.States[ColumnIndex];
            }
            else
            {
                return row.GetPropertyValue(DataField);
            }
        }

        #endregion

        #region GetCheckedState/SetCheckedState

        /// <summary>
        /// ���еĸ�ѡ���Ƿ���ѡ��״̬
        /// </summary>
        /// <param name="rowIndex">������</param>
        /// <returns>ѡ��״̬</returns>
        public bool GetCheckedState(int rowIndex)
        {
            GridRow row = this.Grid.Rows[rowIndex];

            return Convert.ToBoolean(row.States[ColumnIndex]);
        }

        /// <summary>
        /// ���ñ��и�ѡ���ѡ��״̬
        /// </summary>
        /// <param name="rowIndex">������</param>
        /// <param name="isChecked">�Ƿ�ѡ��</param>
        public void SetCheckedState(int rowIndex, bool isChecked)
        {
            GridRow row = this.Grid.Rows[rowIndex];

            row.States[ColumnIndex] = isChecked;

            // ������״̬��ͬʱ��Ҫ���Ÿ�������Ⱦ���HTML
            row.UpdateValuesAt(ColumnIndex);
        } 

        #endregion

        #region OnFirstPreRender

        /// <summary>
        /// ��Ⱦ HTML ֮ǰ���ã�ҳ���һ�μ��ػ�����ͨ�ط���
        /// </summary>
        protected override void OnFirstPreRender()
        {
            base.OnFirstPreRender();


            string jsContent = String.Format("var {0}={1};", XID, OB.ToString());
            AddGridColumnScript(jsContent);
            
        }

        #endregion
    }
}



