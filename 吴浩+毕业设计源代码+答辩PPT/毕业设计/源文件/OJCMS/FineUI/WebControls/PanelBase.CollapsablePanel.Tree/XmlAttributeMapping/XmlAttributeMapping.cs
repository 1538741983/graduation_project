
#region Comment

/*
 * Project��    FineUI
 * 
 * FileName:    XmlAttributeMapping.cs
 * CreatedOn:   2008-07-21
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
using System.Web.UI.Design;
using System.Drawing.Design;
using System.Xml;


namespace FineUI
{
    /// <summary>
    /// ���ڵ������ӳ��
    /// </summary>
    [ToolboxItem(false)]
    public class XmlAttributeMapping
    {

        #region Properties

        private string _from = String.Empty;

        /// <summary>
        /// ӳ��Դ
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("ӳ��Դ")]
        public string From
        {
            get
            {
                return _from;
            }
            set
            {
                _from = value;
            }
        }

        private string _to = String.Empty;


        /// <summary>
        /// ӳ��Ŀ��
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("ӳ��Ŀ��")]
        public string To
        {
            get
            {
                return _to;
            }
            set
            {
                _to = value;
            }
        }



        #endregion

    }
}



