using System;
using System.Collections.Generic;
using System.Text;

namespace FineUI
{
    /// <summary>
    /// 页脚工具栏的排列位置
    /// </summary>
    public enum FooterBarAlign
    {
        /// <summary>
        /// 靠右（默认值）
        /// </summary>
        Right,
        /// <summary>
        /// 靠左
        /// </summary>
        Left,
        /// <summary>
        /// 居中
        /// </summary>
        Center
    }

    /// <summary>
    /// 页脚工具栏的排列位置名称
    /// </summary>
    internal static class FooterBarAlignHelper
    {
        public static string GetName(FooterBarAlign type)
        {
            string result = String.Empty;

            switch (type)
            {
                case FooterBarAlign.Left:
                    result = "left";
                    break;
                case FooterBarAlign.Right:
                    result = "right";
                    break;
                case FooterBarAlign.Center:
                    result = "center";
                    break;
            }

            return result;
        }
    }
}