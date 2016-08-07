#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    GridTemplateContainer.cs
 * CreatedOn:   2008-05-27
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
using System.Data;
using System.Reflection;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;
using System.Globalization;


namespace FineUI
{
    /// <summary>
    /// 用来作为模板列的数据绑定容器，实现了IDataItemContainer接口
    /// </summary>
    [ToolboxItem(false)]
    public class GridTemplateContainer : WebControl, IDataItemContainer, INamingContainer
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataItem">数据源</param>
        /// <param name="rowIndex">行索引</param>
        public GridTemplateContainer(object dataItem, int rowIndex)
        {
            _dataItem = dataItem;
            _dataItemIndex = _displayIndex = rowIndex;
            
        }

        /// <summary>
        /// 控件初始化事件
        /// </summary>
        /// <param name="e">事件参数</param>
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            if (!DesignMode)
            {
                // 确保所有子控件都已经被创建
                EnsureChildControls();

                // 如果控件没有设置 ID，则自动创建一个（比如：ct100）
                base.EnsureID();
            }

        }

        #region RenderBeginTag

        /// <summary>
        /// 渲染开始标签
        /// </summary>
        /// <param name="writer">ASP.NET服务器控件输出流</param>
        public override void RenderBeginTag(HtmlTextWriter writer)
        {
            //base.RenderBeginTag(writer);

            writer.Write(String.Format("<div class=\"f-grid-tpl x-grid-tpl\" id=\"{0}\">", ClientID));
        }

        /// <summary>
        /// 渲染结束标签
        /// </summary>
        /// <param name="writer">ASP.NET服务器控件输出流</param>
        public override void RenderEndTag(HtmlTextWriter writer)
        {
            //base.RenderEndTag(writer);

            writer.Write("</div>");
        } 

        #endregion

        #region IDataItemContainer Members

        private object _dataItem;

        /// <summary>
        /// 数据源（IDataItemContainer成员）
        /// </summary>
        public object DataItem
        {
            get { return _dataItem; }
        }

        private int _dataItemIndex;

        /// <summary>
        /// 数据项索引（IDataItemContainer成员）
        /// </summary>
        public int DataItemIndex
        {
            get { return _dataItemIndex; }
        }

        private int _displayIndex;

        /// <summary>
        /// 数据项在控件中显示位置的索引（IDataItemContainer成员）
        /// </summary>
        public int DisplayIndex
        {
            get { return _displayIndex; }
        }

        #endregion

    }
}



