
#region Comment

/*
 * Project��    FineUI
 * 
 * FileName:    RowNumberField.cs
 * CreatedOn:   2013-09-23
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


namespace FineUI
{
    /// <summary>
    /// ������ݰ���
    /// </summary>
    [ToolboxItem(false)]
    [ParseChildren(true)]
    [PersistChildren(false)]
    public class RowNumberField : BaseField
    {
        #region Properties

        private bool _enableHeaderMenu = false;
        /// <summary>
        /// ���ñ�ͷ�˵�
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("���ñ�ͷ�˵�")]
        public override bool EnableHeaderMenu
        {
            get
            {
                return _enableHeaderMenu;
            }
            set
            {
                _enableHeaderMenu = value;
            }
        }


        private bool _allowHideColumn = false;
        /// <summary>
        /// �Ƿ�����������
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("�Ƿ�����������")]
        public override bool EnableColumnHide
        {
            get
            {
                return _allowHideColumn;
            }
            set
            {
                _allowHideColumn = value;
            }
        }


        private bool _enablePagingNumber = false;
        /// <summary>
        /// �Ƿ����÷�ҳ�к�
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("�Ƿ����÷�ҳ�к�")]
        public bool EnablePagingNumber
        {
            get
            {
                return _enablePagingNumber;
            }
            set
            {
                _enablePagingNumber = value;
            }
        }

        #endregion

        #region Methods

        internal override object GetColumnValue(GridRow row)
        {
            return String.Empty;
        }

        #endregion

        #region OnFirstPreRender

        /// <summary>
        /// ��Ⱦ HTML ֮ǰ���ã�ҳ���һ�μ��ػ�����ͨ�ط���
        /// </summary>
        protected override void OnFirstPreRender()
        {
            base.OnFirstPreRender();

            if (EnablePagingNumber)
            {
                OB.AddProperty("f_paging", true);
                OB.AddProperty("f_paging_grid", Grid.ClientID);
            }

            string jsContent = String.Format("var {0}={1};", XID, OB.ToString());
            AddGridColumnScript(jsContent);
            
        }

        #endregion

    }
}



