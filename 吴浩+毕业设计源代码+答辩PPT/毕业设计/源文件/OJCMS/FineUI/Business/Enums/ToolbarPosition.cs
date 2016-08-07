

#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    ToolbarPosition.cs
 * CreatedOn:   2008-05-30
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
    /// 工具条的位置
    /// </summary>
    public enum ToolbarPosition
    {
        /// <summary>
        /// 顶部（默认值）
        /// </summary>
        Top,
        /// <summary>
        /// 底部
        /// </summary>
        Bottom,
        ///// <summary>
        ///// 页脚
        ///// </summary>
        //Footer,
        /// <summary>
        /// 左侧
        /// </summary>
        Left,
        /// <summary>
        /// 右侧
        /// </summary>
        Right
        ///// <summary>
        ///// 底部按钮
        ///// </summary>
        //Buttons
    }

    /// <summary>
    /// 工具条的位置名称
    /// </summary>
    internal static class ToolbarPositionHelper
    {
        public static string GetName(ToolbarPosition type)
        {
            string result = String.Empty;

            switch (type)
            {
                case ToolbarPosition.Top:
                    result = "tbar";
                    break;
                case ToolbarPosition.Bottom:
                    result = "bbar";
                    break;
                //case ToolbarPosition.Footer:
                //    result = "fbar";
                //    break;
                case ToolbarPosition.Left:
                    result = "lbar";
                    break;
                case ToolbarPosition.Right:
                    result = "rbar";
                    break;
                //case ToolbarPosition.Buttons:
                //    result = "buttons";
                //    break;
            }

            return result;
        }


        public static string GetExtName(ToolbarPosition type)
        {
            string result = String.Empty;

            switch (type)
            {
                case ToolbarPosition.Top:
                    result = "top";
                    break;
                case ToolbarPosition.Bottom:
                    result = "bottom";
                    break;
                case ToolbarPosition.Left:
                    result = "left";
                    break;
                case ToolbarPosition.Right:
                    result = "right";
                    break;
            }

            return result;
        }
    }

}