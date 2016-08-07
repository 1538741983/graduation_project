
#region Comment

/*
 * Project��    FineUI
 * 
 * FileName:    HyperLinkField.cs
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
using System.Web.UI.WebControls;

namespace FineUI
{
    /// <summary>
    /// ���������
    /// </summary>
    [ToolboxItem(false)]
    [ParseChildren(true)]
    [PersistChildren(false)]
    public class HyperLinkField : BaseField
    {

        #region Properties

        private bool _enabled = true;

        /// <summary>
        /// �Ƿ����
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("�Ƿ����")]
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

        private string _dataTextField = String.Empty;

        /// <summary>
        /// �ֶ�����
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("�ֶ�����")]
        public string DataTextField
        {
            get
            {
                return _dataTextField;
            }
            set
            {
                _dataTextField = value;
            }
        }

        private string _dataTextFormatString = String.Empty;
        
        /// <summary>
        /// �ֶθ�ʽ���ַ���
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("�ֶθ�ʽ���ַ���")]
        public string DataTextFormatString
        {
            get
            {
                return _dataTextFormatString;
            }
            set
            {
                _dataTextFormatString = value;
            }
        }

        private string[] _dataNavigateUrlFields = null;

        /// <summary>
        /// �󶨵������ӵ�ַ���ֶ������б�
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(null)]
        [Description("�󶨵������ӵ�ַ���ֶ������б�")]
        [TypeConverter(typeof(StringArrayConverter))]
        public string[] DataNavigateUrlFields
        {
            get
            {
                return _dataNavigateUrlFields;
            }
            set
            {
                _dataNavigateUrlFields = value;
            }
        }

        //private bool _dataNavigateUrlFieldsEncode = false;

        /// <summary>
        /// ��ÿ���󶨵������ӵ�ַ���ֶν���URL���루�����Է�������ʹ��UrlEncode���ԣ�
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("��ÿ���󶨵������ӵ�ַ���ֶν���URL���루�����Է�������ʹ��UrlEncode���ԣ�")]
        public bool DataNavigateUrlFieldsEncode
        {
            get
            {
                return _urlEncode;
            }
            set
            {
                _urlEncode = value;
            }
        }


        private bool _urlEncode = true;

        /// <summary>
        /// ��ÿ���󶨵������ӵ�ַ���ֶν���URL���루Ĭ��Ϊtrue��
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("��ÿ���󶨵������ӵ�ַ���ֶν���URL����")]
        public bool UrlEncode
        {
            get
            {
                return _urlEncode;
            }
            set
            {
                _urlEncode = value;
            }
        }


        private string _dataNavigateUrlFormatString = String.Empty;

        /// <summary>
        /// �󶨵������ӵ�ַ���ֶθ�ʽ���ַ���
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("�󶨵������ӵ�ַ���ֶθ�ʽ���ַ���")]
        public string DataNavigateUrlFormatString
        {
            get
            {
                return _dataNavigateUrlFormatString;
            }
            set
            {
                _dataNavigateUrlFormatString = value;
            }
        }

        private string _target = String.Empty;

        /// <summary>
        /// �򿪳����ӵ�Ŀ����
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("�򿪳����ӵ�Ŀ����")]
        public string Target
        {
            get
            {
                return _target;
            }
            set
            {
                _target = value;
            }
        }


        private string _navigateUrl = String.Empty;

        /// <summary>
        /// �����ӵ�ַ
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("�����ӵ�ַ")]
        public string NavigateUrl
        {
            get
            {
                return _navigateUrl;
            }
            set
            {
                _navigateUrl = value;
            }
        }

        private string _text = String.Empty;

        /// <summary>
        /// �������ı�
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("�������ı�")]
        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
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


        private bool _htmlEncodeFormatString = true;

        /// <summary>
        /// �Ƿ���Ӧ��DataFormatString����֮�����HTML���루Ĭ��Ϊtrue��
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("�Ƿ���Ӧ��DataFormatString����֮�����HTML���루Ĭ��Ϊtrue��")]
        public bool HtmlEncodeFormatString
        {
            get
            {
                return _htmlEncodeFormatString;
            }
            set
            {
                _htmlEncodeFormatString = value;
            }
        }

        #endregion

        #region Methods

        internal override object GetColumnValue(GridRow row)
        {
            HtmlNodeBuilder nb = new HtmlNodeBuilder("a");

            #region DataTextField

            if (!String.IsNullOrEmpty(DataTextField))
            {
                object value = row.GetPropertyValue(DataTextField);

                string text = String.Empty;
                if (value != null)
                {
                    if (!String.IsNullOrEmpty(DataTextFormatString))
                    {
                        text = String.Format(DataTextFormatString, value);
                        if (HtmlEncodeFormatString)
                        {
                            text = HttpUtility.HtmlEncode(text);
                        }
                    }
                    else
                    {
                        text = value.ToString();
                        if (HtmlEncode)
                        {
                            text = HttpUtility.HtmlEncode(text);
                        }
                    }
                }

                nb.InnerProperty = text;
            }
            else
            {
                nb.InnerProperty = Text;
            }

            #endregion

            if (Enabled)
            {
                #region DataNavigateUrlFields

                string hrefOriginal = String.Empty;

                if (DataNavigateUrlFields != null && DataNavigateUrlFields.Length > 0)
                {
                    //string[] fields = DataNavigateUrlFields.Trim().TrimEnd(',').Split(',');
                    string[] fields = DataNavigateUrlFields;

                    List<object> fieldValues = new List<object>();
                    foreach (string field in fields)
                    {
                        if (!String.IsNullOrEmpty(field))
                        {
                            object fieldObj = row.GetPropertyValue(field);

                            string fieldValue = String.Empty;
                            if (fieldObj != null)
                            {
								fieldValue = fieldObj.ToString();
                                if (UrlEncode)
                                {
                                    fieldValue = HttpUtility.UrlEncode(fieldValue);
                                }
                            }
                            fieldValues.Add(fieldValue);
                        }
                    }

                    if (!String.IsNullOrEmpty(DataNavigateUrlFormatString))
                    {
                        hrefOriginal = String.Format(DataNavigateUrlFormatString, fieldValues.ToArray());
                    }
                    else
                    {
                        if (fieldValues.Count > 0)
                        {
                            hrefOriginal = fieldValues[0].ToString();
                        }
                    }
                }
                else
                {
                    hrefOriginal = NavigateUrl;
                }

                nb.SetProperty("href", Grid.ResolveUrl(hrefOriginal));

                #endregion

                #region Target

                if (!String.IsNullOrEmpty(Target))
                {
                    nb.SetProperty("target", Target);
                }
                else
                {
                    nb.SetProperty("target", "_blank");
                }

                #endregion
            }
            else
            {
                nb.SetProperty("class", "x-item-disabled");
                nb.SetProperty("disabled", "disabled");
            }

            //string result2 = nb.ToString();

            //string tooltip = GetTooltipString(row);
            //if (!String.IsNullOrEmpty(tooltip))
            //{
            //    result2 = result2.ToString().Insert(2, tooltip);
            //}


            //return result2;

            string result = nb.ToString();

            string tooltip = GetTooltipString(row);
            if (!String.IsNullOrEmpty(tooltip))
            {
                result = result.ToString().Insert("<a".Length, tooltip);
            }

            return result;
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


            string jsContent = String.Format("var {0}={1};", XID, OB.ToString());
            AddGridColumnScript(jsContent);
            
        }

        #endregion
    }
}



