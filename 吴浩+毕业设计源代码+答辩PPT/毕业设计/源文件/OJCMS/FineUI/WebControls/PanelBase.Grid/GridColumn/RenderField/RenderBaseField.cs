
#region Comment

/*
 * Project��    FineUI
 * 
 * FileName:    RenderBaseField.cs
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
    /// ���ɱ༭�еĻ���
    /// </summary>
    [ToolboxItem(false)]
    [ParseChildren(true)]
    [PersistChildren(false)]
    public abstract class RenderBaseField : GridColumn
    {
        #region Properties


        private string _dataField = String.Empty;

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

        /// <summary>
        /// ���ñ��еĵ�Ԫ��༭����
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("���ñ��еĵ�Ԫ��༭����")]
        public virtual bool EnableColumnEdit
        {
            get
            {
                object obj = FState["EnableColumnEdit"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                FState["EnableColumnEdit"] = value;
            }
        }

        #endregion

        #region OnAjaxPreRender

        /// <summary>
        /// ��Ⱦ HTML ֮ǰ���ã�AJAX�ط���
        /// </summary>
        protected override void OnAjaxPreRender()
        {
            // ���� base.OnAjaxPreRender ���������� Hidden �����Ըı�ͼ�¼�� GridColumn �У������� Grid �е�AJAX���� HiddenColumns
            base.OnAjaxPreRender();


            //// ����пؼ����Ӳ��������Եĸı�
            //StringBuilder sb = new StringBuilder();

            //if (PropertyModified("EnableColumnEdit"))
            //{
            //    sb.AppendFormat("{0}.f_setEditable();", XID);
            //}

            //AddAjaxScript(sb);



            //if (sb.Length > 0)
            //{
            //    // ������Ķ����ƣ��������� f_loadData
            //    ResourceManager.Instance.AddAjaxShortName(Grid.ClientID, Grid.XID);

            //    // ���� ResponseFilter��Ҫ���� f_loadData����Ϊ��������Ըı���
            //    PageManager.Instance.AddAjaxGridColumnChangedGridClientID(Grid.ClientID);
            //}

        }

        #endregion

        #region OnFirstPreRender

        /// <summary>
        /// ��Ⱦ HTML ֮ǰ���ã�ҳ���һ�μ��ػ�����ͨ�ط���
        /// </summary>
        protected override void OnFirstPreRender()
        {
            base.OnFirstPreRender();

            OB.AddProperty("f_editable", EnableColumnEdit);
            
        }


        #endregion
    }
}



