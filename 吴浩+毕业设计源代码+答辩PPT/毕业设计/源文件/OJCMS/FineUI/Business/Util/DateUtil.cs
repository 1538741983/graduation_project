﻿
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    DateUtil.cs
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
    /// Extjs和.Net之间的日期格式转换
    /// </summary>
    public class DateUtil
    {
        /// <summary>
        /// 创建Javascript的Date对象字符串
        /// </summary>
        /// <param name="date">日期对象</param>
        /// <returns>日期的客户端脚本形式</returns>
        public static string GetClientDateObject(DateTime date)
        {
            // 注意：这个地方有一个bug，要把月份减一才正确，晕
            return String.Format("new Date({0},{1},{2})",
                date.Year.ToString("D4"), (date.Month - 1).ToString(), date.Day.ToString());
        }

        /// <summary>
        /// 将.Net日期格式字符串转换为ExtJS的日期格式字符串
        /// </summary>
        /// <param name="dotnetFormat">.Net日期格式字符串</param>
        /// <returns>ExtJS的日期格式字符串</returns>
        public static string ConvertToClientDateFormat(string dotnetFormat)
        {
            // DotNet - 年月日
            //d 月中的某一天。一位数的日期没有前导零。
            //dd 月中的某一天。一位数的日期有一个前导零。
            //ddd 周中某天的缩写名称，在 AbbreviatedDayNames 中定义。
            //dddd 周中某天的完整名称，在 DayNames 中定义。
            //M 月份数字。一位数的月份没有前导零。
            //MM 月份数字。一位数的月份有一个前导零。
            //MMM 月份的缩写名称，在 AbbreviatedMonthNames 中定义。
            //MMMM 月份的完整名称，在 MonthNames 中定义。
            //y 不包含纪元的年份。如果不包含纪元的年份小于 10，则显示不具有前导零的年份。
            //yy 不包含纪元的年份。如果不包含纪元的年份小于 10，则显示具有前导零的年份。
            //yyyy 包括纪元的四位数的年份。


            // DotNet - 时分秒
            //h 12 小时制的小时。一位数的小时数没有前导零。
            //hh 12 小时制的小时。一位数的小时数有前导零。
            //H 24 小时制的小时。一位数的小时数没有前导零。
            //HH 24 小时制的小时。一位数的小时数有前导零。
            //m 分钟。一位数的分钟数没有前导零。
            //mm 分钟。一位数的分钟数有一个前导零。
            //s 秒。一位数的秒数没有前导零。
            //ss 秒。一位数的秒数有一个前导零。

            // DotNet - AM/PM 时区
            //t 在 AMDesignator 或 PMDesignator 中定义的 AM/PM 指示项的第一个字符（如果存在）。
            //tt 在 AMDesignator 或 PMDesignator 中定义的 AM/PM 指示项（如果存在）。
            //z 时区偏移量（“+”或“-”后面仅跟小时）。一位数的小时数没有前导零。
            //zz 时区偏移量（“+”或“-”后面仅跟小时）。一位数的小时数有前导零。例如，太平洋标准时间是“-08”。
            //zzz 完整时区偏移量（“+”或“-”后面跟有小时和分钟）。一位数的小时数和分钟数有前导零。例如，太平洋标准时间是“-08:00”。


            // ExtJS 
            //d     Day of the month, 2 digits with leading zeros                             01 to 31
            //D     A short textual representation of the day of the week                     Mon to Sun
            //j     Day of the month without leading zeros                                    1 to 31
            //l     A full textual representation of the day of the week                      Sunday to Saturday
            //N     ISO-8601 numeric representation of the day of the week                    1 (for Monday) through 7 (for Sunday)
            //S     English ordinal suffix for the day of the month, 2 characters             st, nd, rd or th. Works well with j
            //w     Numeric representation of the day of the week                             0 (for Sunday) to 6 (for Saturday)
            //z     The day of the year (starting from 0)                                     0 to 364 (365 in leap years)
            //W     ISO-8601 week number of year, weeks starting on Monday                    01 to 53
            //F     A full textual representation of a month, such as January or March        January to December
            //m     Numeric representation of a month, with leading zeros                     01 to 12
            //M     A short textual representation of a month                                 Jan to Dec
            //n     Numeric representation of a month, without leading zeros                  1 to 12
            //t     Number of days in the given month                                         28 to 31
            //L     Whether it's a leap year                                                  1 if it is a leap year, 0 otherwise.
            //o     ISO-8601 year number (identical to (Y), but if the ISO week number (W)    Examples: 1998 or 2004
            //      belongs to the previous or next year, that year is used instead)
            //Y     A full numeric representation of a year, 4 digits                         Examples: 1999 or 2003
            //y     A two digit representation of a year                                      Examples: 99 or 03

            // ExtJS - 时分秒
            //a     Lowercase Ante meridiem and Post meridiem                                 am or pm
            //A     Uppercase Ante meridiem and Post meridiem                                 AM or PM
            //g     12-hour format of an hour without leading zeros                           1 to 12
            //G     24-hour format of an hour without leading zeros                           0 to 23
            //h     12-hour format of an hour with leading zeros                              01 to 12
            //H     24-hour format of an hour with leading zeros                              00 to 23
            //i     Minutes, with leading zeros                                               00 to 59
            //s     Seconds, with leading zeros                                               00 to 59



            string extjsFormat = dotnetFormat;
            extjsFormat = extjsFormat.Replace("yyyy", "Y").Replace("yy", "y");
            extjsFormat = extjsFormat.Replace("MMMM", "F").Replace("MMM", "M").Replace("MM", "m").Replace("M", "n");
            extjsFormat = extjsFormat.Replace("dddd", "l").Replace("ddd", "D");

            //extjsFormat = extjsFormat.Replace("hh", "h").Replace("HH", "H");
            extjsFormat = extjsFormat.Replace("mm", "i");
            extjsFormat = extjsFormat.Replace("ss", "s");
            extjsFormat = extjsFormat.Replace("tt", "A");

            // 日
            if (extjsFormat.Contains("dd"))
            {
                extjsFormat = extjsFormat.Replace("dd", "d");
            }
            else
            {
                extjsFormat = extjsFormat.Replace("d", "j");
            }

            // 24 - 小时
            if (extjsFormat.Contains("HH"))
            {
                extjsFormat = extjsFormat.Replace("HH", "H");
            }
            else
            {
                extjsFormat = extjsFormat.Replace("H", "G");
            }

            // 12 - 小时
            if (extjsFormat.Contains("hh"))
            {
                extjsFormat = extjsFormat.Replace("hh", "h");
            }
            else
            {
                extjsFormat = extjsFormat.Replace("h", "g");
            }


            return extjsFormat;
        }

    }
}
