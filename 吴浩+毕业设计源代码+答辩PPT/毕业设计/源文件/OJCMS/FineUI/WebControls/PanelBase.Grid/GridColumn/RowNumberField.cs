
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    RowNumberField.cs
 * CreatedOn:   2013-09-23
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
using System.Reflection;


namespace FineUI
{
    /// <summary>
    /// 表格数据绑定列
    /// </summary>
    [ToolboxItem(false)]
    [ParseChildren(true)]
    [PersistChildren(false)]
    public class RowNumberField : BaseField
    {
        #region Properties

        private bool _enableHeaderMenu = false;
        /// <summary>
        /// 启用表头菜单
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("启用表头菜单")]
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
        /// 是否允许隐藏列
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("是否允许隐藏列")]
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
        /// 是否启用分页行号
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("是否启用分页行号")]
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
        /// 渲染 HTML 之前调用（页面第一次加载或者普通回发）
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



