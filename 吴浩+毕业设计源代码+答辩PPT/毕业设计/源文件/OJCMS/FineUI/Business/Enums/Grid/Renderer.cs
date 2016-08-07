using System;
using System.Collections.Generic;
using System.Text;

namespace FineUI
{
    /// <summary>
    /// 表格可编辑字段渲染器
    /// </summary>
    public enum Renderer
    {
        /// <summary>
        /// 无（默认值）
        /// </summary>
        None,
        /// <summary>
        /// 首字母大写
        /// </summary>
        Capitalize,
        /// <summary>
        /// 日期（RendererArgument来指定日期格式化字符串）
        /// RendererArgument:
        /// 1. d 月中的某一天。一位数的日期没有前导零。
        /// 2. dd 月中的某一天。一位数的日期有一个前导零。
        /// 3. ddd 周中某天的缩写名称，在 AbbreviatedDayNames 中定义。
        /// 4. dddd 周中某天的完整名称，在 DayNames 中定义。
        /// 5. M 月份数字。一位数的月份没有前导零。
        /// 6. MM 月份数字。一位数的月份有一个前导零。
        /// 7. MMM 月份的缩写名称，在 AbbreviatedMonthNames 中定义。
        /// 8. MMMM 月份的完整名称，在 MonthNames 中定义。
        /// 9. y 不包含纪元的年份。如果不包含纪元的年份小于 10，则显示不具有前导零的年份。
        /// 10. yy 不包含纪元的年份。如果不包含纪元的年份小于 10，则显示具有前导零的年份。
        /// 11. yyyy 包括纪元的四位数的年份。
        /// </summary>
        Date,
        /// <summary>
        /// 截断字符串并添加省略号（RendererArgument来指定最大长度）
        /// </summary>
        Ellipsis,
        /// <summary>
        /// 文件大小
        /// </summary>
        FileSize,
        /// <summary>
        /// HTML编码
        /// </summary>
        HtmlEncode,
        /// <summary>
        /// HTML解码
        /// </summary>
        HtmlDecode,
        /// <summary>
        /// 转化为小写字符
        /// </summary>
        Lowercase,
        /// <summary>
        /// 转化为大写字符
        /// </summary>
        Uppercase,
        /// <summary>
        /// 换行符转换为HTML标签<br/>
        /// </summary>
        NL2BR,
        ///// <summary>
        ///// 格式化为数字（RendererArgument来指定数字的显示格式）
        ///// RendererArgument：
        ///// 1. 0 - (123456) 只显示数字，没有精度
        ///// 2. 0.00 - (123456.78) 只显示数字，两位精度
        ///// 3. 0.0000 - (123456.7890) 只显示数字，四位精度
        ///// 4. 0,000 - (123,456) 显示数字和逗号，没有精度
        ///// 5. 0,000.00 - (123,456.78) 显示数字和逗号，两位精度
        ///// </summary>
        //Number,
        /// <summary>
        /// 删除所有的脚本标签
        /// </summary>
        StripScripts,
        /// <summary>
        /// 删除所有的标签
        /// </summary>
        StripTags,
        /// <summary>
        /// 清除字符串两端的空白字符
        /// </summary>
        Trim
        ///// <summary>
        ///// 美元
        ///// </summary>
        //UsMoney
    }

    /// <summary>
    /// 表格可编辑字段渲染器名称
    /// </summary>
    internal static class RendererName
    {
        public static string GetName(Renderer type)
        {
            string result = String.Empty;

            switch (type)
            {
                case Renderer.None:
                    result = "";
                    break;
                case Renderer.Capitalize:
                    result = "capitalize";
                    break;
                case Renderer.Date:
                    result = "date";
                    break;
                case Renderer.Ellipsis:
                    result = "ellipsis";
                    break;
                case Renderer.FileSize:
                    result = "fileSize";
                    break;
                case Renderer.HtmlDecode:
                    result = "htmlDecode";
                    break;
                case Renderer.HtmlEncode:
                    result = "htmlEncode";
                    break;
                case Renderer.Lowercase:
                    result = "lowercase";
                    break;
                case Renderer.NL2BR:
                    result = "nl2br";
                    break;
                //case Renderer.Number:
                //    result = "number";
                //    break;
                case Renderer.StripScripts:
                    result = "stripScripts";
                    break;
                case Renderer.StripTags:
                    result = "stripTags";
                    break;
                case Renderer.Trim:
                    result = "trim";
                    break;
                case Renderer.Uppercase:
                    result = "uppercase";
                    break;
                //case Renderer.UsMoney:
                //    result = "usMoney";
                //    break;
            }

            return result;
        }
    }
}