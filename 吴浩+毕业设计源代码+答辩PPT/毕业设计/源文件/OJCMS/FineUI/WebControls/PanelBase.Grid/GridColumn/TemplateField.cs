
#region Comment

/*
 * Project��    FineUI
 * 
 * FileName:    TemplateField.cs
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
using System.Web.UI.HtmlControls;
using System.IO;


namespace FineUI
{
    /// <summary>
    /// ���ģ����
    /// </summary>
    [ToolboxItem(false)]
    [ParseChildren(true)]
    [PersistChildren(false)]
    public class TemplateField : BaseField
    {
        #region Properties

        private ITemplate _itemTemplate;

        /// <summary>
        /// ģ������
        /// </summary>
        [Browsable(false)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TemplateInstance(TemplateInstance.Single)]
        [TemplateContainer(typeof(GridTemplateContainer))]
        [Description("ģ������")]
        public virtual ITemplate ItemTemplate
        {
            get
            {
                return _itemTemplate;
            }
            set
            {
                _itemTemplate = value;
            }
        }


        private bool _renderAsRowExpander = false;

        /// <summary>
        /// �Ƿ���ȾΪ����չ��
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("�Ƿ���ȾΪ����չ��")]
        public bool RenderAsRowExpander
        {
            get
            {
                return _renderAsRowExpander;
            }
            set
            {
                _renderAsRowExpander = value;
            }
        }


        private bool _expandOnDoubleClick = true;
        /// <summary>
        /// ˫��չ���۵�����չ��
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("˫��չ���۵�����չ��")]
        public bool ExpandOnDoubleClick
        {
            get
            {
                return _expandOnDoubleClick;
            }
            set
            {
                _expandOnDoubleClick = value;
            }
        }

        private bool _expandOnEnter = true;
        /// <summary>
        /// �س�����չ���۵�����չ��
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("�س�����չ���۵�����չ��")]
        public bool ExpandOnEnter
        {
            get
            {
                return _expandOnEnter;
            }
            set
            {
                _expandOnEnter = value;
            }
        }

        private bool _expandToSelectRow = false;
        /// <summary>
        /// ���ͼ��չ���۵�����չ��ʱѡ����
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("���ͼ��չ���۵�����չ��ʱѡ����")]
        public bool ExpandToSelectRow
        {
            get
            {
                return _expandToSelectRow;
            }
            set
            {
                _expandToSelectRow = value;
            }
        }


        #endregion

        #region GetColumnValue

        internal override object GetColumnValue(GridRow row)
        {
            GridTemplateContainer control = row.TemplateContainers[ColumnIndex];
            
            return String.Format("{0}{1}", Grid.TEMPLATE_PLACEHOLDER_PREFIX, control.ID);
        }

        //public override string GetFieldType()
        //{
        //    return "string";
        //}

        #endregion

        #region OnFirstPreRender

        /// <summary>
        /// ��Ⱦ HTML ֮ǰ���ã�ҳ���һ�μ��ػ�����ͨ�ط���
        /// </summary>
        protected override void OnFirstPreRender()
        {
            base.OnFirstPreRender();

            if (this is TemplateField && (this as TemplateField).RenderAsRowExpander)
            {
                JsObjectBuilder rowExpanderBuilder = new JsObjectBuilder();
                rowExpanderBuilder.AddProperty("rowBodyTpl", String.Format("Ext.create('Ext.XTemplate','{{{0}}}')", ColumnID), true);
                rowExpanderBuilder.AddProperty("pluginId", String.Format("{0}_rowexpander", Grid.ClientID));

                if (!ExpandOnDoubleClick)
                {
                    rowExpanderBuilder.AddProperty("expandOnDblClick", false);
                }

                if (!ExpandOnEnter)
                {
                    rowExpanderBuilder.AddProperty("expandOnEnter", false);
                }

                if (ExpandToSelectRow)
                {
                    rowExpanderBuilder.AddProperty("selectRowOnExpand", true);
                }


                string jsContent = String.Format("var {0}=Ext.create('Ext.grid.plugin.RowExpander',{1});", XID, rowExpanderBuilder);
                AddGridColumnScript(jsContent);
                
            }
            else
            {
                string jsContent = String.Format("var {0}={1};", XID, OB.ToString());
                AddGridColumnScript(jsContent);
                
            }
        }

        #endregion
    }
}



