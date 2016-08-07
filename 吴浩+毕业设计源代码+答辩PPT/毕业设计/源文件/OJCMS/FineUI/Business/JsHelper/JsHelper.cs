
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
using System.Globalization;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace FineUI
{
    /// <summary>
    /// JavaScript帮助类
    /// </summary>
    public class JsHelper
    {

        #region GetFunction GetDeferScript

        /// <summary>
        /// 获取一段完成的JavaScript函数
        /// </summary>
        /// <param name="jsContent">函数主体</param>
        /// <param name="funParameters">函数参数</param>
        /// <returns>字符串表示的JavaScript函数</returns>
        public static string GetFunction(string jsContent, params string[] funParameters)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("function(");
            if (funParameters.Length > 0)
            {
                for (int i = 0, count = funParameters.Length; i < count; i++)
                {
                    sb.Append(funParameters[i]);
                    if (i != count - 1)
                    {
                        sb.Append(",");
                    }
                }
            }
            sb.Append("){");
            sb.Append(jsContent);
            sb.Append("}");
            return sb.ToString();
        }

        /// <summary>
        /// 获取延迟执行JavaScript脚本的字符串
        /// </summary>
        /// <param name="jsContent">需要执行的脚本内容</param>
        /// <param name="milliseconds">延迟毫秒数</param>
        /// <returns>延迟执行的客户端脚本</returns>
        public static string GetDeferScript(string jsContent, int milliseconds)
        {
            return String.Format("Ext.defer({0},{1});", GetFunction(jsContent), milliseconds);
        }

        /// <summary>
        /// 获取延迟执行JavaScript脚本的字符串
        /// </summary>
        /// <param name="jsContent">需要执行的脚本内容</param>
        /// <param name="milliseconds">延迟毫秒数</param>
        /// <param name="scope">执行脚本时的函数上下文</param>
        /// <returns>延迟执行的客户端脚本</returns>
        public static string GetDeferScript(string jsContent, int milliseconds, string scope)
        {
            return String.Format("Ext.defer({0},{1},{2});", GetFunction(jsContent), milliseconds, scope);
        }
        #endregion

        #region Enquote

        ///// <summary>
        ///// Produce a string in double quotes with backslash sequences in all the right places.
        ///// 
        ///// 常用的用法：String.Format("{0}.setValue({1});", ClientJavascriptID, JsHelper.Enquote(Text))
        ///// 大部分情况下，可以使用 GetJsString 函数代替此函数
        ///// 此函数返回的是双引号括起来的字符串，用来作为JSON属性比较合适，一般用在OnAjaxPreRender
        ///// 但是作为HTML属性时，由于HTML属性本身就是双引号括起来的，就容易引起冲突
        ///// 
        ///// </summary>
        ///// <param name="s">A String</param>
        ///// <returns>A String correctly formatted for insertion in a JSON message.</returns>
        
        /// <summary>
        /// 返回的是单引号括起来的字符串，用来作为JSON属性比较合适
        /// </summary>
        /// <param name="s">源字符串</param>
        /// <returns>单引号括起来的字符串</returns>
        public static string Enquote(string s)
        {
            /*
            string jsonString = new JValue(s).ToString(Formatting.None);

            // The browser HTML parser will see the </script> within the string and it will interpret it as the end of the script element.
            // http://www.xiaoxiaozi.com/2010/02/24/1708/
            // http://stackoverflow.com/questions/1659749/script-tag-in-javascript-string
            jsonString = jsonString.Replace("</script>", @"<\/script>");

            return jsonString;
            */

            if (s == null || s.Length == 0)
            {
                return "''";
            }

            char c;
            StringBuilder sb = new StringBuilder();

            sb.Append('\'');
            for (int i = 0, len = s.Length; i < len; i++)
            {
                c = s[i];
                if ((c == '\\') || (c == '\'') || (c == '>'))
                {
                    sb.Append('\\');
                    sb.Append(c);
                }
                else if (c == '\b')
                {
                    sb.Append("\\b");
                }
                else if (c == '\t')
                {
                    sb.Append("\\t");
                }
                else if (c == '\n')
                {
                    sb.Append("\\n");
                }
                else if (c == '\f')
                {
                    sb.Append("\\f");
                }
                else if (c == '\r')
                {
                    sb.Append("\\r");
                }
                else
                {
                    sb.Append(c);
                    /*
                    if (c < ' ')
                    {
                        //t = "000" + Integer.toHexString(c);
                        string tmp = new string(c, 1);
                        string t = "000" + int.Parse(tmp, System.Globalization.NumberStyles.HexNumber);
                        sb.Append("\\u" + t.Substring(t.Length - 4));
                    }
                    else
                    {
                        sb.Append(c);
                    }
                    */
                }
            }
            sb.Append('\'');

            // The browser HTML parser will see the </script> within the string and it will interpret it as the end of the script element.
            // http://www.xiaoxiaozi.com/2010/02/24/1708/
            // http://stackoverflow.com/questions/1659749/script-tag-in-javascript-string

            return sb.ToString().Replace("</script>", @"<\/script>");
        }

        /// <summary>
        /// 将包含JavaScript代码块的字符串转换为可以使用的客户端脚本
        /// </summary>
        /// <param name="text">包含JavaScript代码块的字符串</param>
        /// <returns>转换后的客户端脚本</returns>
        public static string EnquoteWithScriptTag(string text)
        {
            if (text.Contains("&lt;script&gt;"))
            {
                text = text.Replace("&lt;script&gt;", "<script>");
                text = text.Replace("&lt;/script&gt;", "</script>");
            }

            string[] splits = text.Split(new string[] { "<script>" }, StringSplitOptions.None);

            StringBuilder sb = new StringBuilder();
            foreach (string split in splits)
            {
                string[] subSplits = split.Split(new string[] { "</script>" }, StringSplitOptions.None);
                if (subSplits.Length == 2)
                {
                    sb.AppendFormat("+{0}+", subSplits[0]);
                    sb.Append(Enquote(subSplits[1]));
                }
                else
                {
                    sb.Append(Enquote(subSplits[0]));
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// 获取字符串数组的脚本字符串形式
        /// </summary>
        /// <param name="values">字符串数组</param>
        /// <returns>字符串数组的脚本字符串</returns>
        public static string EnquoteStringArray(string[] values)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string value in values)
            {
                sb.AppendFormat("{0},", JsHelper.Enquote(value));
            }
            return String.Format("[{0}]", sb.ToString().TrimEnd(','));
        }


        /// <summary>
        /// 获取整形数组的脚本字符串形式
        /// </summary>
        /// <param name="values">整数数组</param>
        /// <returns>整形数组的脚本字符串</returns>
        public static string EnquoteIntArray(int[] values)
        {
            StringBuilder sb = new StringBuilder();
            foreach (int value in values)
            {
                sb.AppendFormat("{0},", value);
            }
            return String.Format("[{0}]", sb.ToString().TrimEnd(','));
        }

        #endregion

        #region NumberToString

        /// <summary>
        /// 将数字对象转化为字符串
        /// </summary>
        /// <param name="number">数字对象</param>
        /// <returns>字符串</returns>
        public static string NumberToString(object number)
        {
            if (number is float && ((float)number) == float.NaN)
            {
                string msg = string.Format("");
                throw new ArgumentException("object must be a valid number", "number");
            }
            if (number is double && ((double)number) == double.NaN)
            {
                string msg = string.Format("");
                throw new ArgumentException("object must be a valid number", "number");
            }

            // Shave off trailing zeros and decimal point, if possible

            string s = ((double)number).ToString(NumberFormatInfo.InvariantInfo).ToLower();

            if (s.IndexOf('e') < 0 && s.IndexOf('.') > 0)
            {
                while (s.EndsWith("0"))
                {
                    s.Substring(0, s.Length - 1);
                }
                if (s.EndsWith("."))
                {
                    s.Substring(0, s.Length - 1);
                }
            }
            return s;
        }

        #endregion
    }
}
