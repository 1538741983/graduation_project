
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    ImageField.cs
 * CreatedOn:   2008-05-28
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
using System.Web.UI.WebControls;
using System.Globalization;
using System.Reflection;


namespace FineUI
{
    /// <summary>
    /// 表格图片列
    /// </summary>
    [ToolboxItem(false)]
    [ParseChildren(true)]
    [PersistChildren(false)]
    public class ImageField : BaseField
    {
        #region Properties


        private string _dataImageUrlField = String.Empty;

        /// <summary>
        /// 图片地址字段
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("图片地址字段")]
        public string DataImageUrlField
        {
            get
            {
                return _dataImageUrlField;
            }
            set
            {
                _dataImageUrlField = value;
            }
        }



        private string _dataImageUrlFormatString = String.Empty;

        /// <summary>
        /// 图片地址字段格式化字符串
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("图片地址字段格式化字符串")]
        public string DataImageUrlFormatString
        {
            get
            {
                return _dataImageUrlFormatString;
            }
            set
            {
                _dataImageUrlFormatString = value;
            }
        }


        private Unit _imageWidth = Unit.Empty;

        /// <summary>
        /// 图片的宽度
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(typeof(Unit), "")]
        [Description("图片的宽度")]
        public Unit ImageWidth
        {
            get
            {
                return _imageWidth;
            }
            set
            {
                _imageWidth = value;
            }
        }

        private Unit _imageHeight = Unit.Empty;

        /// <summary>
        /// 图片的高度
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(typeof(Unit), "")]
        [Description("图片的高度")]
        public Unit ImageHeight
        {
            get
            {
                return _imageHeight;
            }
            set
            {
                _imageHeight = value;
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

        #region Methods

        internal override object GetColumnValue(GridRow row)
        {
            string result = String.Empty;

            if (!String.IsNullOrEmpty(DataImageUrlField))
            {
                object value = row.GetPropertyValue(DataImageUrlField);
                string imageUrl = String.Empty;

                if (value != null)
                {
                    if (!String.IsNullOrEmpty(DataImageUrlFormatString))
                    {
                        imageUrl = String.Format(DataImageUrlFormatString, value);
                    }
                    else
                    {
                        imageUrl = value.ToString();
                    }
                }

                string cssStyle = String.Empty;

                if (ImageWidth != Unit.Empty)
                {
                    cssStyle += String.Format("width:{0}px;", ImageWidth.Value);
                }
                if (ImageHeight != Unit.Empty)
                {
                    cssStyle += String.Format("height:{0}px;", ImageHeight.Value);
                }

                if (!String.IsNullOrEmpty(cssStyle))
                {
                    cssStyle = String.Format(" style=\"{0}\"", cssStyle);
                }



                result = String.Format("<img src=\"{0}\" class=\"f-grid-imagefield\"{1}/>",
                    Grid.ResolveUrl(imageUrl),
                    cssStyle);
            }

            string tooltip = GetTooltipString(row);
            if (!String.IsNullOrEmpty(tooltip))
            {
                result = result.ToString().Insert(4, tooltip);
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
        /// 渲染 HTML 之前调用（页面第一次加载或者普通回发）
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



