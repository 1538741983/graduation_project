
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
    /// 表单客户端验证提示消息的类型
    /// </summary>
    public enum MessageTarget
    {
        /// <summary>
        /// 浮动提示（默认值）
        /// </summary>
        Qtip,
        /// <summary>
        /// 使用HTML标签的title属性
        /// </summary>
        Title,
        /// <summary>
        /// 在字段下面通过一个div层来显示消息
        /// </summary>
        Under,
        /// <summary>
        /// 在字段右侧显示一个错误图标
        /// </summary>
        Side,
        /// <summary>
        /// 不显示错误信息
        /// </summary>
        None
    }

    /// <summary>
    /// 提示消息的类型名称
    /// </summary>
    internal static class MessageTargetHelper
    {
        public static string GetName(MessageTarget type)
        {
            string result = String.Empty;

            switch (type)
            {
                case MessageTarget.Qtip:
                    result = "qtip";
                    break;
                case MessageTarget.Title:
                    result = "title";
                    break;
                case MessageTarget.Under:
                    result = "under";
                    break;
                case MessageTarget.Side:
                    result = "side";
                    break;
                case MessageTarget.None:
                    result = "none";
                    break;
            }

            return result;
        }
    }
}