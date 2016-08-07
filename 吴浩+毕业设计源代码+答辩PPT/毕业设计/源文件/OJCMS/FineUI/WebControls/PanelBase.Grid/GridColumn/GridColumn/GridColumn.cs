
#region Comment

/*
 * Project��    FineUI
 * 
 * FileName:    GridColumn.cs
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
    [DefaultProperty("HeaderText")]
    public abstract class GridColumn : ControlBase
    {
        #region Grid/ColumnIndex

        private Grid _grid;

        /// <summary>
        /// ������
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("������")]
        public Grid Grid
        {
            get
            {
                if (_grid == null)
                {
                    _grid = GetParentGrid();
                }
                return _grid;
            }
        }

        private Grid GetParentGrid()
        {
            if (Parent is Grid)
            {
                return (Grid)Parent;
            }
            else
            {
                return ResolveParentGrid(Parent as GridColumn);
            }
        }

        private Grid ResolveParentGrid(GridColumn column)
        {
            if (column != null)
            {
                if (column.Parent is Grid)
                {
                    return (Grid)column.Parent;
                }
                else
                {
                    return ResolveParentGrid(column.Parent as GridColumn);
                }
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// ������
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("������")]
        public int ColumnIndex
        {
            get
            {
                return Grid.AllColumns.IndexOf(this);
            }
        }

        #endregion

        #region Properties

        ///// <summary>
        ///// ��ǰ�е�������ʽ
        ///// </summary>
        //[Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public string SortExpression
        //{
        //    get
        //    {
        //        return String.Format("{0} {1}", SortField, SortDirection);
        //    }
        //}

        //public string _sortDirection = "ASC";

        ///// <summary>
        ///// ������
        ///// </summary>
        //[Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public string SortDirection
        //{
        //    get
        //    {
        //        return _sortDirection;
        //    }
        //    set
        //    {
        //        _sortDirection = value;
        //    }
        //}

        private string _sortField = String.Empty;

        /// <summary>
        /// �����ֶ�
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("�����ֶ�")]
        public string SortField
        {
            get
            {
                return _sortField;
            }
            set
            {
                _sortField = value;
            }
        }


        private bool _enableLock = false;

        /// <summary>
        /// ��������
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("��������")]
        public bool EnableLock
        {
            get
            {
                return _enableLock;
            }
            set
            {
                _enableLock = value;
            }
        }


        private bool _locked = false;

        /// <summary>
        /// �Ƿ�������״̬
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("�Ƿ�������״̬")]
        public bool Locked
        {
            get
            {
                return _locked;
            }
            set
            {
                _locked = value;
            }
        }


        private bool _hidden = false;

        /// <summary>
        /// �Ƿ�������
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("�Ƿ�������")]
        public override bool Hidden
        {
            get
            {
                return _hidden;
            }
            set
            {
                _hidden = value;
            }
        }



        private string _columnID = String.Empty;

        /// <summary>
        /// ��ID�����û�����ã���ΪClientID��
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("��ID�����û�����ã���ΪClientID��")]
        public string ColumnID
        {
            get
            {
                if (String.IsNullOrEmpty(_columnID))
                {
                    return ClientID;
                }
                return _columnID;
            }
            set
            {
                _columnID = value;
            }
        }


        private string _headerText = String.Empty;
        /// <summary>
        /// ��������ʾ������
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("��������ʾ������")]
        public string HeaderText
        {
            get
            {
                return _headerText;
            }
            set
            {
                _headerText = value;
            }
        }

        private string _headerToolTip = String.Empty;
        /// <summary>
        /// ���������ֵ���ʾ�ı�
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("���������ֵ���ʾ�ı�")]
        public string HeaderToolTip
        {
            get
            {
                return _headerToolTip;
            }
            set
            {
                _headerToolTip = value;
            }
        }

        private ToolTipType _headerTooltipType = ToolTipType.Qtip;
        /// <summary>
        /// ���������ֵ���ʾ�ı�����
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(ToolTipType.Qtip)]
        [Description("���������ֵ���ʾ�ı�����")]
        public ToolTipType HeaderToolTipType
        {
            get
            {
                return _headerTooltipType;
            }
            set
            {
                _headerTooltipType = value;
            }
        }


        private Unit _width = Unit.Empty;
        /// <summary>
        /// �п��
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(typeof(Unit), "")]
        [Description("�п��")]
        public virtual Unit Width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
            }
        }

        private Unit _minWidth = Unit.Empty;
        /// <summary>
        /// ��С�п��
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(typeof(Unit), "")]
        [Description("��С�п��")]
        public virtual Unit MinWidth
        {
            get
            {
                return _minWidth;
            }
            set
            {
                _minWidth = value;
            }
        }


        private int _boxFlex = 0;
        /// <summary>
        /// �����ӿؼ��ĳߴ磨�����ʹ��HBox���֣�
        /// </summary>
        [Category(CategoryName.LAYOUT)]
        [DefaultValue(0)]
        [Description("�����ӿؼ��ĳߴ磨�����ʹ��HBox���֣�")]
        public int BoxFlex
        {
            get
            {
                return _boxFlex;
            }
            set
            {
                _boxFlex = value;
            }
        }


        private bool _expandUnusedSpace = false;
        /// <summary>
        /// ���л���չ����δʹ�õĿ��
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("���л���չ����δʹ�õĿ��")]
        public bool ExpandUnusedSpace
        {
            get
            {
                return _expandUnusedSpace;
            }
            set
            {
                _expandUnusedSpace = value;
            }
        }


        /*
        private TextAlign _textalign = TextAlign.Left;

        /// <summary>
        /// �ı�������λ��
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(TextAlign.Left)]
        [Description("�ı�������λ��")]
        public TextAlign TextAlign
        {
            get
            {
                return _textalign;
            }
            set
            {
                _textalign = value;
            }
        }
        */

        private TextAlign? _textalign = null;

        /// <summary>
        /// �ı�������λ��
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(null)]
        [Description("�ı�������λ��")]
        public TextAlign? TextAlign
        {
            get
            {
                return _textalign;
            }
            set
            {
                _textalign = value;
            }
        }


        private bool _enableHeaderMenu = true;
        /// <summary>
        /// ���ñ�ͷ�˵�
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("���ñ�ͷ�˵�")]
        public virtual bool EnableHeaderMenu
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


        private bool _enableColumnHide = true;
        /// <summary>
        /// ���������й���
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("���������й���")]
        public virtual bool EnableColumnHide
        {
            get
            {
                return _enableColumnHide;
            }
            set
            {
                _enableColumnHide = value;
            }
        }


        /// <summary>
        /// ���Ԫ��������ʽ��
        /// </summary>
        internal virtual string InnerCls
        {
            get
            {
                return String.Empty;
            }
        }


        #endregion

        #region virtual GetColumnValue/GetColumnState/PersistState

        /// <summary>
        /// ȡ����ͷ��Ⱦ���HTML
        /// </summary>
        /// <returns>��Ⱦ���HTML</returns>
        internal virtual string GetHeaderValue()
        {
            return String.IsNullOrEmpty(HeaderText) ? "&nbsp;" : HeaderText;
        }

        /// <summary>
        /// ȡ������Ⱦ���HTML
        /// </summary>
        /// <param name="row">�����ʵ��</param>
        /// <returns>��Ⱦ���HTML</returns>
        internal virtual object GetColumnValue(GridRow row)
        {
            return String.Empty;
        }


        /// <summary>
        /// �����Ƿ���Ҫ����״̬��Ŀǰֻ��CheckBoxFieldʵ����������壩
        /// </summary>
        internal virtual bool PersistState
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// ��ȡ�е�״̬
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        internal virtual object GetColumnState(GridRow row)
        {
            return null;
        }

        #endregion

        #region OnPreRender

        /// <summary>
        /// ��Ⱦ HTML ֮ǰ���ã�AJAX�ط���
        /// </summary>
        protected override void OnAjaxPreRender()
        {
            // ����пؼ������������Եĸı�
        }

        /// <summary>
        /// ��Ⱦ HTML ֮ǰ���ã�ҳ���һ�μ��ػ�����ͨ�ط���
        /// </summary>
        protected override void OnFirstPreRender()
        {
            base.OnFirstPreRender();

            
            if (this is TemplateField && (this as TemplateField).RenderAsRowExpander)
            {
                // ����չ����Ҫ���⴦��
            }
            else
            {
                //JsObjectBuilder columnBuilder = new JsObjectBuilder();

                // �еĽ��ûᷴӳ��ÿ����Ԫ���ϣ�����������ͷ
                OB.RemoveProperty("disabled");

                if (this is RowNumberField)
                {
                    OB.AddProperty("xtype", "rownumberer");
                }

                OB.AddProperty("text", GetHeaderValue());

                if (!String.IsNullOrEmpty(HeaderToolTip))
                {
                    OB.AddProperty("tooltip", HeaderToolTip);
                    OB.AddProperty("tooltipType", ToolTipTypeName.GetName(HeaderToolTipType));
                }

                if (Hidden)
                {
                    OB.AddProperty("hidden", true);
                }

                if (!String.IsNullOrEmpty(InnerCls))
                {
                    OB.AddProperty("innerCls", InnerCls);
                }

                if (Grid.AllowSorting)
                {
                    if (String.IsNullOrEmpty(SortField))
                    {
                        OB.AddProperty("sortable", false);
                    }
                    else
                    {
                        OB.AddProperty("sortable", true);
                    }
                }
                else
                {
                    OB.AddProperty("sortable", false);
                }


                // ����������
                if (Grid.AllowColumnLocking)
                {
                    if (EnableLock)
                    {
                        OB.AddProperty("lockable", true);
                    }
                    else
                    {
                        OB.AddProperty("lockable", false);
                    }

                    if (Locked)
                    {
                        OB.AddProperty("lockable", true);
                        OB.AddProperty("locked", true);
                    }
                }


                if (PersistState)
                {
                    OB.AddProperty("f_persistState", true);
                    OB.AddProperty("f_persistStateType", "checkbox");
                }



                //If not specified, the column's index is used as an index into the Record's data Array.
                OB.AddProperty("dataIndex", ColumnID);
                OB.AddProperty("id", ColumnID);

                // ��������ʹ�õ�ColumnIndex
                OB.AddProperty("f_columnIndex", ColumnIndex);


                /*
                if (TextAlign != TextAlign.Left)
                {
                    OB.AddProperty("align", TextAlignName.GetName(TextAlign));
                }
                */
                if (TextAlign != null)
                {
                    // �������Ĭ�Ͽ�����ʾ������������ʾ������ֻҪ������ TextAlign�������
                    OB.AddProperty("align", TextAlignName.GetName(TextAlign.Value));
                }

                if (Width != Unit.Empty)
                {
                    OB.AddProperty("width", Width.Value);
                }
                else if (BoxFlex != 0)
                {
                    OB.AddProperty("flex", BoxFlex);
                }

                if (MinWidth != Unit.Empty)
                {
                    OB.AddProperty("minWidth", MinWidth.Value);
                }

                if (ExpandUnusedSpace)
                {
                    OB.AddProperty("flex", 1);
                }

                if (Grid.EnableHeaderMenu)
                {
                    if (EnableHeaderMenu)
                    {
                        OB.AddProperty("menuDisabled", false);
                    }
                    else
                    {
                        OB.AddProperty("menuDisabled", true);
                    }
                }
                else
                {
                    OB.AddProperty("menuDisabled", true);
                }

                if (EnableColumnHide)
                {
                    OB.AddProperty("hideable", true);
                }
                else
                {
                    OB.AddProperty("hideable", false);
                }


                if (Grid.EnableSummary)
                {
                    if (this is RowNumberField)
                    {
                        // ����� û�кϼ�
                    }
                    else
                    {
                        OB.AddProperty("summaryType", String.Format("F.util.summaryType('{0}')", Grid.ClientID), true);
                    }
                }







            }
        }

        #endregion

        #region AddGridColumnScript
        
        /// <summary>
        /// ��ӱ���е���Ⱦ�ű�
        /// </summary>
        /// <param name="jsContent"></param>
        protected void AddGridColumnScript(string jsContent)
        {
            AddStartupScript(jsContent);
        } 

        #endregion

    }
}



