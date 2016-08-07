
#region Comment

/*
 * Project��    FineUI
 * 
 * FileName:    GroupField.cs
 * CreatedOn:   2013-10-08
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
    /// ��������
    /// </summary>
    [ToolboxItem(false)]
    [ParseChildren(true)]
    [PersistChildren(false)]
    public class GroupField : GridColumn
    {
        #region Properties


        private GridColumnCollection _columns;

        /// <summary>
        /// ������
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Editor(typeof(GridColumnsEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public virtual GridColumnCollection Columns
        {
            get
            {
                if (_columns == null)
                {
                    _columns = new GridColumnCollection(this);
                }
                return _columns;
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

            JsArrayBuilder columnsBuilder = new JsArrayBuilder();
            foreach (GridColumn column in Columns)
            {
                columnsBuilder.AddProperty(column.XID, true);
            }
            OB.AddProperty("columns", columnsBuilder);


            string jsContent = String.Format("var {0}={1};", XID, OB.ToString());
            AddGridColumnScript(jsContent);
        }

        #endregion

    }
}



