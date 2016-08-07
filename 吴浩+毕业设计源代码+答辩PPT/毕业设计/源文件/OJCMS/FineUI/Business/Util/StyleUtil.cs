
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    StyleUtil.cs
 * CreatedOn:   2008-05-22
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
using System.Web.UI.WebControls;
using System.Web.UI;

namespace FineUI
{
    /// <summary>
    /// 样式帮助类
    /// </summary>
    public class StyleUtil
    {
        /// <summary>
        /// 提取样式字符串
        /// </summary>
        /// <param name="css">CSS字符串</param>
        /// <param name="styleName">样式名称</param>
        /// <returns>样式字符串</returns>
        public static string GetSingleStyleFormCSS(string css, string styleName)
        {
            // 从字符串padding:5px;background-color:#DFE8F6;中提取background-color:#DFE8F6;
            styleName = styleName.ToLower();
            css = css.ToLower().Replace(" ", "");

            if (css.Contains(styleName))
            {
                int styleStartIndex = css.IndexOf(styleName);
                int styleEndIndex = css.IndexOf(";", styleStartIndex);

                return css.Substring(styleStartIndex, styleEndIndex - styleStartIndex + 1);
            }

            return String.Empty;
        }

        /// <summary>
        /// 获取背景图片样式
        /// </summary>
        /// <param name="selector">选择符</param>
        /// <param name="imageUrl">图片地址</param>
        /// <returns>CSS样式</returns>
        public static string GetBackgroundStyle(string selector, string imageUrl)
        {
            return String.Format("{0}{{background: url({1}) !important;}}", selector, imageUrl);
        }

        /// <summary>
        /// 获取背景图片样式（no-repeat）
        /// </summary>
        /// <param name="selector">选择符</param>
        /// <param name="imageUrl">图片地址</param>
        /// <returns>CSS样式</returns>
        public static string GetNoRepeatBackgroundStyle(string selector, string imageUrl)
        {
            return String.Format("{0}{{background: url({1}) no-repeat;}}", selector, imageUrl);
        }

        /// <summary>
        /// 获取适合CSS的Margin或者Padding定义
        /// </summary>
        /// <param name="source">源字符串</param>
        /// <returns>CSS样式</returns>
        public static string GetMarginPaddingStyle(string source) {

            List<string> result = new List<string>();
            foreach (string item in source.Split(' '))
            {
                if (item.Contains("px") || item.Contains("pt") || item.Contains("em"))
                {
                    result.Add(item);
                }
                else
                {
                    result.Add(Convert.ToInt32(item) + "px");
                }
            }

            return String.Join(" ", result.ToArray());
	    }
    }

}
