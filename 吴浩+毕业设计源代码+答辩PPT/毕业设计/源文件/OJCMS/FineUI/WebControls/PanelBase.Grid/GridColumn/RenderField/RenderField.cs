
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    RenderField.cs
 * CreatedOn:   2013-05-05
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
    /// 表格可编辑列
    /// </summary>
    [ToolboxItem(false)]
    [ParseChildren(true)]
    [PersistChildren(false)]
    public class RenderField : RenderBaseField
    {
        #region Editor

        private GridColumnEditorCollection _editor;

        /// <summary>
        /// 单元格编辑控件
        /// </summary>
        [Browsable(false)]
        [Category(CategoryName.OPTIONS)]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("单元格编辑控件")]
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
        /// 字段类型
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(FieldType.Auto)]
        [Description("字段类型")]
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
        /// 渲染器
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(Renderer.None)]
        [Description("渲染器类型")]
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
        /// 渲染器的参数
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("渲染器的参数")]
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
        /// 自定义渲染器函数（JavaScript函数）
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("自定义渲染器函数（JavaScript函数）")]
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
        ///// 日期字段的格式化字符串
        ///// </summary>
        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue("")]
        //[Description("日期字段的格式化字符串")]
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
        /// 处理数据库中null值，默认为空字符串
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("处理数据库中null值，默认为空字符串")]
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
        /// 显示之前进行HTML编码（默认为true）
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("显示之前进行HTML编码（默认为true）")]
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
        /// 启用本列的单元格编辑功能（如果未定义Editor，则此属性为false）
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("启用本列的单元格编辑功能（如果未定义Editor，则此属性为false）")]
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
                    // 如果未定义 Editor，则此属性为false
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
        /// 渲染 HTML 之前调用（页面第一次加载或者普通回发）
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



