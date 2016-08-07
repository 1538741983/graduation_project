
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    ContentPanelBuilder.cs
 * CreatedOn:   2012-12-31
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


namespace FineUI
{
    /// <summary>
    /// 支持页分析器生成控件及其包含的子控件
    /// </summary>
    internal class ContentPanelBuilder : ControlBuilder
    {
        /// <summary>
        /// 允许空白字符
        /// </summary>
        /// <returns></returns>
        public override bool AllowWhitespaceLiterals()
        {
            return true;
        }

        /// <summary>
        /// 不忽略游离于标签外的字符串
        /// </summary>
        /// <param name="s"></param>
        public override void AppendLiteralString(string s)
        {
            base.AppendLiteralString(s);
        }

        public override Type GetChildControlType(string tagName, System.Collections.IDictionary attribs)
        {
            return base.GetChildControlType(tagName, attribs);
        }

        public override Type DeclareType
        {
            get
            {
                return base.DeclareType;
            }
        }
    }
}
