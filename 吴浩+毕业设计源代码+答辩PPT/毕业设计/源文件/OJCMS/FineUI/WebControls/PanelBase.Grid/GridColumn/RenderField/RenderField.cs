
#region Comment

/*
 * Project��    FineUI
 * 
 * FileName:    RenderField.cs
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
    /// ���ɱ༭��
    /// </summary>
    [ToolboxItem(false)]
    [ParseChildren(true)]
    [PersistChildren(false)]
    public class RenderField : RenderBaseField
    {
        #region Editor

        private GridColumnEditorCollection _editor;

        /// <summary>
        /// ��Ԫ��༭�ؼ�
        /// </summary>
        [Browsable(false)]
        [Category(CategoryName.OPTIONS)]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("��Ԫ��༭�ؼ�")]
        [Editor(typeof(GridColumnEditorEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public virtual GridColumnEditorCollection Editor
        {
            get
            {
                if (_editor == null)
                {
                    _editor = new GridColumnEditorCollection(this);
                }
                return _editor;
            }
        }


        #endregion

        #region Properties

        private FieldType _fieldType = FieldType.Auto;

        /// <summary>
        /// �ֶ�����
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(FieldType.Auto)]
        [Description("�ֶ�����")]
        public FieldType FieldType
        {
            get
            {
                return _fieldType;
            }
            set
            {
                _fieldType = value;
            }
        }


        private Renderer _renderer = Renderer.None;

        /// <summary>
        /// ��Ⱦ��
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(Renderer.None)]
        [Description("��Ⱦ������")]
        public Renderer Renderer
        {
            get
            {
                return _renderer;
            }
            set
            {
                _renderer = value;
            }
        }

        private string _rendererArgument = String.Empty;

        /// <summary>
        /// ��Ⱦ���Ĳ���
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("��Ⱦ���Ĳ���")]
        public string RendererArgument
        {
            get
            {
                return _rendererArgument;
            }
            set
            {
                _rendererArgument = value;
            }
        }


        private string _rendererFunction = String.Empty;

        /// <summary>
        /// �Զ�����Ⱦ��������JavaScript������
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("�Զ�����Ⱦ��������JavaScript������")]
        public string RendererFunction
        {
            get
            {
                return _rendererFunction;
            }
            set
            {
                _rendererFunction = value;
            }
        }


        //private string _dateFormat = String.Empty;

        ///// <summary>
        ///// �����ֶεĸ�ʽ���ַ���
        ///// </summary>
        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue("")]
        //[Description("�����ֶεĸ�ʽ���ַ���")]
        //public string DateFormat
        //{
        //    get
        //    {
        //        return _dateFormat;
        //    }
        //    set
        //    {
        //        _dateFormat = value;
        //    }
        //}


        private string _nullDisplayText = String.Empty;

        /// <summary>
        /// �������ݿ���nullֵ��Ĭ��Ϊ���ַ���
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("�������ݿ���nullֵ��Ĭ��Ϊ���ַ���")]
        public string NullDisplayText
        {
            get
            {
                return _nullDisplayText;
            }
            set
            {
                _nullDisplayText = value;
            }
        }


        private bool _htmlEncode = true;

        /// <summary>
        /// ��ʾ֮ǰ����HTML���루Ĭ��Ϊtrue��
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("��ʾ֮ǰ����HTML���루Ĭ��Ϊtrue��")]
        public bool HtmlEncode
        {
            get
            {
                return _htmlEncode;
            }
            set
            {
                _htmlEncode = value;
            }
        }

        /// <summary>
        /// ���ñ��еĵ�Ԫ��༭���ܣ����δ����Editor���������Ϊfalse��
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("���ñ��еĵ�Ԫ��༭���ܣ����δ����Editor���������Ϊfalse��")]
        public override bool EnableColumnEdit
        {
            get
            {
                if (Editor.Count > 0)
                {
                    object obj = FState["EnableColumnEdit"];
                    return obj == null ? true : (bool)obj;
                }
                else
                {
                    // ���δ���� Editor���������Ϊfalse
                    return false;
                }
            }
            set
            {
                FState["EnableColumnEdit"] = value;
            }
        }

        #endregion

        #region GetColumnValue

        internal override object GetColumnValue(GridRow row)
        {
            object result = String.Empty;

            if (!String.IsNullOrEmpty(DataField))
            {
                object value = row.GetPropertyValue(DataField);

                if (value == null || value == DBNull.Value || (value is String && String.IsNullOrEmpty(value.ToString())))
                {
                    result = NullDisplayText;
                }
                else
                {
                    if (FieldType == FieldType.Boolean)
                    {
                        result = Convert.ToBoolean(value);
                    }
                    else if (FieldType == FieldType.Int)
                    {
                        result = Convert.ToInt32(value);
                    }
                    else if (FieldType == FieldType.Float)
                    {
                        result = Convert.ToSingle(value);
                    }
                    else if (FieldType == FieldType.Double)
                    {
                        result = Convert.ToDouble(value);
                    }
                    else if (FieldType == FieldType.Date)
                    {
                        // http://www.dotnetperls.com/datetime-format
                        DateTime date = DateTime.Now;
                        if (value.GetType() == typeof(DateTime))
                        {
                            date = (DateTime)value;
                        }
                        else
                        {
                            date = DateTime.Parse(value.ToString());
                        }

                        //// 2009-02-27T12:12:22
                        //text = date.ToString("s");
                        //int tIndex = text.IndexOf("T");
                        //if (tIndex >= 0)
                        //{
                        //    text = text.Substring(0, tIndex) + "T00:00:00";
                        //}

                        result = date.ToString(RendererArgument);
                    }
                    else
                    {
                        result = value.ToString();

                        if (HtmlEncode)
                        {
                            result = HttpUtility.HtmlEncode(result.ToString());
                        }
                    }
                }
            }

            return result;
        }

        #endregion

        #region GetRenderer

        private string GetRenderer()
        {
            if (!String.IsNullOrEmpty(RendererFunction))
            {
                return RendererFunction;
            }

            if (Renderer == Renderer.None)
            {
                return String.Empty;
            }

            if (Renderer == Renderer.Date)
            {
                string argument = "yyyy-MM-dd";
                if (!String.IsNullOrEmpty(RendererArgument))
                {
                    argument = RendererArgument;
                }
                return String.Format("F.format.dateRenderer('{0}')", DateUtil.ConvertToClientDateFormat(argument));
            }
            else if (Renderer == Renderer.Ellipsis)
            {
                string argument = "10";
                if (!String.IsNullOrEmpty(RendererArgument))
                {
                    argument = RendererArgument;
                }
                return String.Format("F.format.ellipsisRenderer({0})", argument);
            }
            //else if (Renderer == Renderer.Number)
            //{
            //    string argument = "0.00";
            //    if (!String.IsNullOrEmpty(RendererArgument))
            //    {
            //        argument = RendererArgument;
            //    }
            //    return String.Format("F.format.number('{0}')", argument);
            //}
            else
            {
                return String.Format("F.format.{0}", RendererName.GetName(Renderer));
            }

        } 

        #endregion

        #region OnFirstPreRender

        /// <summary>
        /// ��Ⱦ HTML ֮ǰ���ã�ҳ���һ�μ��ػ�����ͨ�ط���
        /// </summary>
        protected override void OnFirstPreRender()
        {
            base.OnFirstPreRender();

            OB.AddProperty("f_columnType", "renderfield");


            string renderer = GetRenderer();
            if (!String.IsNullOrEmpty(renderer))
            {
                OB.AddProperty("renderer", renderer, true);
            }


            if (Grid.AllowCellEditing)
            {
                if (Editor.Count > 0)
                {
                    OB.AddProperty("editor", Editor[0].XID, true);
                }

                //if (FieldType == FieldType.Boolean)
                //{
                //    OB.AddProperty("xtype", "booleancolumn");
                //}
            }

            string jsContent = String.Format("var {0}={1};", XID, OB.ToString());
            AddGridColumnScript(jsContent);
            
        }


        #endregion

    }
}



