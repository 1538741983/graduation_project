
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    ThemeType.cs
 * CreatedOn:   2008-08-20
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
    /// 样式
    /// </summary>
    public enum Theme
    {
        /// <summary>
        /// 蓝色
        /// </summary>
        Blue,
        /// <summary>
        /// 银灰色
        /// </summary>
        Gray,
        /// <summary>
        /// 高对比度
        /// </summary>
        Access,
        /// <summary>
        /// 海王星（默认值）
        /// </summary>
        Neptune
    }

    /// <summary>
    /// 样式的类型名称
    /// </summary>
    internal static class ThemeHelper
    {
        public static string GetName(Theme type)
        {
            string result = String.Empty;

            switch (type)
            {
                case Theme.Blue:
                    result = "blue";
                    break;
                case Theme.Gray:
                    result = "gray";
                    break;
                case Theme.Access:
                    result = "access";
                    break;
                case Theme.Neptune:
                    result = "neptune";
                    break;
            }

            return result;
        }
    }
}