
#region Comment

/*
 * Project��    FineUI
 * 
 * FileName:    RenderCheckField.cs
 * CreatedOn:   2013-05-18
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
    /// ���ɱ༭��ѡ����
    /// </summary>
    [ToolboxItem(false)]
    [ParseChildren(true)]
    [PersistChildren(false)]
    public class RenderCheckField : RenderBaseField
    {
        #region Properties


        #endregion

        #region GetColumnValue

        internal override object GetColumnValue(GridRow row)
        {
            bool isChecked = false;

            if (!String.IsNullOrEmpty(DataField))
            {
                object value = row.GetPropertyValue(DataField);

                if (value == null || value == DBNull.Value || (value is String && String.IsNullOrEmpty(value.ToString())))
                {
                    // ��������
                }
                else
                {
                    isChecked = Convert.ToBoolean(value);
                }
            }

            return isChecked;
        }

        #endregion

        #region OnFirstPreRender

        /// <summary>
        /// ��Ⱦ HTML ֮ǰ���ã�ҳ���һ�μ��ػ�����ͨ�ط���
        /// </summary>
        protected override void OnFirstPreRender()
        {
            base.OnFirstPreRender();

            OB.AddProperty("f_columnType", "rendercheckfield");


            if (Grid.AllowCellEditing)
            {
                OB.AddProperty("xtype", "checkcolumn");

                if (Grid.EnableAfterEditEvent)
                {
                    string rowIdScript = String.Format("var rowId=F('{0}').getStore().getAt(rowIndex).getId();", Grid.ClientID);
                    string validateScript = "var args='AfterEdit$'+rowId+'$" + ColumnID + "';";
                    validateScript += Grid.GetPostBackEventReference("#AfterEdit#").Replace("'#AfterEdit#'", "args");

                    //string checkchangeScript = String.Format("function(checkcolumn,rowIndex,checked){{{0}}}", validateScript);
                    //OB.Listeners.AddProperty("checkchange", checkchangeScript, true);
                    AddListener("checkchange", rowIdScript + validateScript, "checkcolumn", "rowIndex", "checked");
                }
            }

            string jsContent = String.Format("var {0}={1};", XID, OB.ToString());
            AddGridColumnScript(jsContent);

        }



        #endregion

    }
}



