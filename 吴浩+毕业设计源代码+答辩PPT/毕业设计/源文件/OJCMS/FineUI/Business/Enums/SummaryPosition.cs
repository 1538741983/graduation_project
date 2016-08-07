
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    SummaryPosition.cs
 * CreatedOn:   2013-10-30
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
    /// 表格合计行的位置
    /// </summary>
    public enum SummaryPosition
    {
        /// <summary>
        /// 紧跟数据行（默认值）
        /// </summary>
        Flow,
        /// <summary>
        /// 表格顶部
        /// </summary>
        Top,
        /// <summary>
        /// 表格底部
        /// </summary>
        Bottom
    }

    /// <summary>
    /// 表格合计行的位置名称
    /// </summary>
    internal static class SummaryPositionHelper
    {
        public static string GetName(SummaryPosition type)
        {
            string result = String.Empty;

            switch (type)
            {
                case SummaryPosition.Flow:
                    result = "";
                    break;
                case SummaryPosition.Top:
                    result = "top";
                    break;
                case SummaryPosition.Bottom:
                    result = "bottom";
                    break;
            }

            return result;
        }
    }

}