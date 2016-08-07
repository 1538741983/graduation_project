
#region Comment

/*
 * Project��    FineUI
 * 
 * FileName:    BaseField.cs
 * CreatedOn:   2013-05-05
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
using System.Data;
using System.Reflection;
using System.Web.UI.WebControls;


namespace FineUI
{
    /// <summary>
    /// ����л��ࣨ�����ࣩ
    /// </summary>
    [ToolboxItem(false)]
    [ParseChildren(true)]
    [PersistChildren(false)]
    public abstract class BaseField : GridColumn
    {
        #region Properties

        private string _dataSimulateTreeLevelField = String.Empty;

        /// <summary>
        /// ����ģ������ʾʱ�Ĳ���ֶ�
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("����ģ������ʾʱ�Ĳ���ֶ�")]
        public string DataSimulateTreeLevelField
        {
            get
            {
                return _dataSimulateTreeLevelField;
            }
            set
            {
                _dataSimulateTreeLevelField = value;
            }
        }

        
        #endregion

        #region DataTooltipField/DataTooltipFormatString

        private string _tooltip = String.Empty;

        /// <summary>
        /// ��ʾ�ı�
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("��ʾ�ı�")]
        public string ToolTip
        {
            get
            {
                return _tooltip;
            }
            set
            {
                _tooltip = value;
            }
        }



        private string _dataToolTipField = String.Empty;

        /// <summary>
        /// ��ʾ�ֶ�����
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("��ʾ�ֶ�����")]
        public string DataToolTipField
        {
            get
            {
                return _dataToolTipField;
            }
            set
            {
                _dataToolTipField = value;
            }
        }

        private string _dataToolTipFormatString = String.Empty;

        /// <summary>
        /// ��ʾ�ֶθ�ʽ���ַ���
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("��ʾ�ֶθ�ʽ���ַ���")]
        public string DataToolTipFormatString
        {
            get
            {
                return _dataToolTipFormatString;
            }
            set
            {
                _dataToolTipFormatString = value;
            }
        }

        #endregion

        #region GetTooltipString

        /// <summary>
        /// ȡ����ʾ�ַ���
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        protected string GetTooltipString(GridRow row)
        {
            string result = null;

            if (!String.IsNullOrEmpty(DataToolTipField))
            {
                object value = row.GetPropertyValue(DataToolTipField);
				
				if (value == null)
                {
                    result = null;
                }
                else
                {
					if (!String.IsNullOrEmpty(DataToolTipFormatString))
					{
						result = String.Format(DataToolTipFormatString, value);
					}
					else
					{
						result = value.ToString();
					}
				}
            }
            else if(!String.IsNullOrEmpty(ToolTip))
            {
                result = ToolTip;
            }

            return result == null ? "" : String.Format(" data-qtip=\"{0}\" ", result);
        }

        #endregion

        #region OnFirstPreRender

        ///// <summary>
        ///// ��Ⱦ HTML ֮ǰ���ã�ҳ���һ�μ��ػ�����ͨ�ط���
        ///// </summary>
        //protected override void OnFirstPreRender()
        //{
        //    base.OnFirstPreRender();

        //    if (this is TemplateField && (this as TemplateField).RenderAsRowExpander)
        //    {
        //        // GridColumn���Ѿ��������
        //    }
        //    else
        //    {

        //        string jsContent = String.Format("var {0}={1};", XID, OB.ToString());
        //        AddStartupScript(jsContent);
        //    }


        //} 

        #endregion
        
    }
}



