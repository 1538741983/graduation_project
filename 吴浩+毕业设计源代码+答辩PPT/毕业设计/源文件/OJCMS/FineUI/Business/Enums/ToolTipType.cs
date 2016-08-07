
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    js_css_resource.cs
 * CreatedOn:   2008-04-07
 * CreatedBy:   30372245@qq.com
 * 
 * 
 * Description：
 *      ->
 *   
 * History：
 *       
 * 
 * 
 * 
 * 
 */

#endregion

using System;
using System.Collections.Generic;
using System.Text;

namespace FineUI
{
    /// <summary>
    /// 提示框的类型
    /// </summary>
    public enum ToolTipType
    {
        /// <summary>
        /// Extjs的浮动提示框（默认值）
        /// </summary>
        Qtip,
        /// <summary>
        /// HTML标签的title属性
        /// </summary>
        Title
    }

    /// <summary>
    /// 提示框的类型名称
    /// </summary>
    internal static class ToolTipTypeName
    {
        public static string GetName(ToolTipType type)
        {
            string result = String.Empty;

            switch (type)
            {
                case ToolTipType.Qtip:
                    result = "qtip";
                    break;
                case ToolTipType.Title:
                    result = "title";
                    break;
            }

            return result;
        }
    }
}