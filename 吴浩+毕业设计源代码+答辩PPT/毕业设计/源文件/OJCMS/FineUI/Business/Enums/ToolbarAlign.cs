#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    ToolbarAlign.cs
 * CreatedOn:   2013-12-12
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
    /// 工具栏的排列位置
    /// </summary>
    public enum ToolbarAlign
    {
        /// <summary>
        /// 靠右
        /// </summary>
        Right,
        /// <summary>
        /// 靠左（默认值）
        /// </summary>
        Left,
        /// <summary>
        /// 居中
        /// </summary>
        Center
    }

    /// <summary>
    /// 工具栏的排列位置名称
    /// </summary>
    internal static class ToolbarAlignHelper
    {
        public static string GetName(ToolbarAlign type)
        {
            string result = String.Empty;

            switch (type)
            {
                case ToolbarAlign.Left:
                    result = "start";
                    break;
                case ToolbarAlign.Right:
                    result = "end";
                    break;
                case ToolbarAlign.Center:
                    result = "center";
                    break;
            }

            return result;
        }
    }
}