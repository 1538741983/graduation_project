using System;
using System.Collections.Generic;
using System.Text;

namespace FineUI
{
    /// <summary>
    /// 垂直排列位置
    /// </summary>
    public enum VerticalAlign
    {
        /// <summary>
        /// 居中排列（默认值）
        /// </summary>
        Middle,
        /// <summary>
        /// 靠上排列
        /// </summary>
        Top,
        /// <summary>
        /// 靠下排列
        /// </summary>
        Bottom
    }

    /// <summary>
    /// 垂直排列位置名称
    /// </summary>
    internal static class VerticalAlignName
    {
        public static string GetName(VerticalAlign type)
        {
            string result = String.Empty;

            switch (type)
            {
                case VerticalAlign.Middle:
                    result = "middle";
                    break;
                case VerticalAlign.Top:
                    result = "top";
                    break;
                case VerticalAlign.Bottom:
                    result = "bottom";
                    break;
            }

            return result;
        }
    }
}