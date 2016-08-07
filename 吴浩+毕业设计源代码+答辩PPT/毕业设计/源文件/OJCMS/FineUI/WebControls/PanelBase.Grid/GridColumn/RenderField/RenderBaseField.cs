
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    RenderBaseField.cs
 * CreatedOn:   2013-05-18
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
    /// 表格可编辑列的基类
    /// </summary>
    [ToolboxItem(false)]
    [ParseChildren(true)]
    [PersistChildren(false)]
    public abstract class RenderBaseField : GridColumn
    {
        #region Properties


        private string _dataField = String.Empty;

        /// <summary>
        /// 字段名称
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("字段名称")]
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
        /// 启用本列的单元格编辑功能
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("启用本列的单元格编辑功能")]
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
        /// 渲染 HTML 之前调用（AJAX回发）
        /// </summary>
        protected override void OnAjaxPreRender()
        {
            // 调用 base.OnAjaxPreRender 方法，这样 Hidden 等属性改变就记录在 GridColumn 中，而无需 Grid 中的AJAX属性 HiddenColumns
            base.OnAjaxPreRender();


            //// 表格列控件监视部分列属性的改变
            //StringBuilder sb = new StringBuilder();

            //if (PropertyModified("EnableColumnEdit"))
            //{
            //    sb.AppendFormat("{0}.f_setEditable();", XID);
            //}

            //AddAjaxScript(sb);



            //if (sb.Length > 0)
            //{
            //    // 输出表格的短名称，后面会调用 f_loadData
            //    ResourceManager.Instance.AddAjaxShortName(Grid.ClientID, Grid.XID);

            //    // 告诉 ResponseFilter，要调用 f_loadData，因为表格列属性改变了
            //    PageManager.Instance.AddAjaxGridColumnChangedGridClientID(Grid.ClientID);
            //}

        }

        #endregion

        #region OnFirstPreRender

        /// <summary>
        /// 渲染 HTML 之前调用（页面第一次加载或者普通回发）
        /// </summary>
        protected override void OnFirstPreRender()
        {
            base.OnFirstPreRender();

            OB.AddProperty("f_editable", EnableColumnEdit);
            
        }


        #endregion
    }
}



