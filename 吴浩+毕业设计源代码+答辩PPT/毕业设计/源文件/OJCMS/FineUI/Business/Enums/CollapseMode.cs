
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    HideMode.cs
 * CreatedOn:   2008-09-16
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
using System.Text;

namespace FineUI
{
    /// <summary>
    /// 折叠模式（用于Region控件）
    /// </summary>
    public enum CollapseMode
    {
        
        /// <summary>
        /// 通过点击工具栏上的按钮来折叠展开面板（默认值）
        /// </summary>
        Default,
        
        /// <summary>
        /// 通过点击面板分隔条上的迷你按钮来折叠展开面板
        /// </summary>
        Mini
    }

    /// <summary>
    /// 折叠模式（用于Region控件）的名称
    /// </summary>
    internal static class CollapseModeName
    {
        public static string GetName(CollapseMode type)
        {
            string result = String.Empty;

            switch (type)
            {
                case CollapseMode.Default:
                    result = "default";
                    break;
                case CollapseMode.Mini:
                    result = "mini";
                    break;
            }

            return result;
        }
    }
}