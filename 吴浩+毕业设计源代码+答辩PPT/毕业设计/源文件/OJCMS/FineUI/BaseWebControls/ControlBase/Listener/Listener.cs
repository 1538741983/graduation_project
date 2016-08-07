
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    Listener.cs
 * CreatedOn:   2014-09-03
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Design;
using System.Web.UI.Design.WebControls;

using Newtonsoft.Json;
using System.Web.UI.HtmlControls;
using System.Collections;


namespace FineUI
{
    /// <summary>
    /// 客户端事件
    /// </summary>
    [ToolboxItem(false)]
    [ParseChildren(true, DefaultProperty = "Event")]
    [PersistChildren(false)]
    [ControlBuilder(typeof(NotAllowWhitespaceLiteralsBuilder))]
    public class Listener
    {
        #region Constructor

        /// <summary>
        /// 构造函数
        /// </summary>
        public Listener()
        {

        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="__event">客户端事件名称</param>
        /// <param name="handler">客户端事件处理函数名称</param>
        public Listener(string __event, string handler)
        {
            Event = __event;
            Handler = handler;
        }

        #endregion

        #region Properties

        private string _event = String.Empty;
        /// <summary>
        /// 客户端事件名称
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("客户端事件名称")]
        [NotifyParentProperty(true)]
        public string Event
        {
            get
            {
                return _event;
            }
            set
            {
                _event = value;
            }
        }

        private string _handler = String.Empty;
        /// <summary>
        /// 客户端事件处理函数名称
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("客户端事件处理函数名称")]
        [NotifyParentProperty(true)]
        public string Handler
        {
            get
            {
                return _handler;
            }
            set
            {
                _handler = value;
            }
        }

        #endregion

    }
}
