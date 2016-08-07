#region Comment

/*
 * Project��    FineUI
 * 
 * FileName:    GridTemplateContainer.cs
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
    /// ������Ϊģ���е����ݰ�������ʵ����IDataItemContainer�ӿ�
    /// </summary>
    [ToolboxItem(false)]
    public class GridTemplateContainer : WebControl, IDataItemContainer, INamingContainer
    {
        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="dataItem">����Դ</param>
        /// <param name="rowIndex">������</param>
        public GridTemplateContainer(object dataItem, int rowIndex)
        {
            _dataItem = dataItem;
            _dataItemIndex = _displayIndex = rowIndex;
            
        }

        /// <summary>
        /// �ؼ���ʼ���¼�
        /// </summary>
        /// <param name="e">�¼�����</param>
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            if (!DesignMode)
            {
                // ȷ�������ӿؼ����Ѿ�������
                EnsureChildControls();

                // ����ؼ�û������ ID�����Զ�����һ�������磺ct100��
                base.EnsureID();
            }

        }

        #region RenderBeginTag

        /// <summary>
        /// ��Ⱦ��ʼ��ǩ
        /// </summary>
        /// <param name="writer">ASP.NET�������ؼ������</param>
        public override void RenderBeginTag(HtmlTextWriter writer)
        {
            //base.RenderBeginTag(writer);

            writer.Write(String.Format("<div class=\"f-grid-tpl x-grid-tpl\" id=\"{0}\">", ClientID));
        }

        /// <summary>
        /// ��Ⱦ������ǩ
        /// </summary>
        /// <param name="writer">ASP.NET�������ؼ������</param>
        public override void RenderEndTag(HtmlTextWriter writer)
        {
            //base.RenderEndTag(writer);

            writer.Write("</div>");
        } 

        #endregion

        #region IDataItemContainer Members

        private object _dataItem;

        /// <summary>
        /// ����Դ��IDataItemContainer��Ա��
        /// </summary>
        public object DataItem
        {
            get { return _dataItem; }
        }

        private int _dataItemIndex;

        /// <summary>
        /// ������������IDataItemContainer��Ա��
        /// </summary>
        public int DataItemIndex
        {
            get { return _dataItemIndex; }
        }

        private int _displayIndex;

        /// <summary>
        /// �������ڿؼ�����ʾλ�õ�������IDataItemContainer��Ա��
        /// </summary>
        public int DisplayIndex
        {
            get { return _displayIndex; }
        }

        #endregion

    }
}



