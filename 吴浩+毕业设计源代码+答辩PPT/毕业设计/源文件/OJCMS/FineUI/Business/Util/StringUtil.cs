
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    StringUtil.cs
 * CreatedOn:   2008-06-25
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
using System.Web;
using System.Text.RegularExpressions;
using System.IO;
using System.IO.Compression;

namespace FineUI
{
    /// <summary>
    /// 字符串帮助类
    /// </summary>
    public class StringUtil
    {
        #region GZIPPED_VIEWSTATE

        /// <summary>
        /// GZIP压缩的ViewState隐藏字段的ID
        /// </summary>
        public static readonly string VIEWSTATE_ID = "__VIEWSTATE";

        /// <summary>
        /// GZIP压缩的ViewState隐藏字段的ID
        /// </summary>
        public static readonly string GZIPPED_VIEWSTATE_ID = "__VIEWSTATE_GZ";

        #endregion

        #region EnumFromName EnumToName

        /// <summary>
        /// 获取枚举实例
        /// </summary>
        /// <param name="enumType">枚举类型</param>
        /// <param name="enumName">枚举实例名称</param>
        /// <returns>枚举实例</returns>
        public static object EnumFromName(Type enumType, string enumName)
        {
            return Enum.Parse(enumType, enumName);
        }

        /// <summary>
        /// 获取枚举实例名称
        /// </summary>
        /// <param name="param">枚举实例</param>
        /// <returns>枚举实例名称</returns>
        public static string EnumToName(Enum param)
        {
            return Enum.GetName(param.GetType(), param);
        }

        #endregion

        #region StripHtml

        /// <summary>
        /// 去除字符串中的Html
        /// </summary>
        /// <param name="source">字符串</param>
        /// <returns>字符串</returns>
        public static string StripHtml(string source)
        {
            return Regex.Replace(source, @"<[\s\S]*?>", "", RegexOptions.IgnoreCase);
        }

        #endregion

        #region GetIntListFromString GetStringListFromString

        /// <summary>
        /// 将字符串"1,2,3"转化为整形列表[1,2,3]
        /// </summary>
        /// <param name="postValue">字符串</param>
        /// <returns>整形列表</returns>
        public static List<int> GetIntListFromString(string postValue)
        {
            return GetIntListFromString(postValue, false);
        }

        /// <summary>
        /// 将字符串"1,2,3"转化为整形列表[1,2,3]
        /// </summary>
        /// <param name="postValue">字符串</param>
        /// <param name="sortBeforeReturn">返回之前是否对数组进行排序（由小到大）</param>
        /// <returns>整形列表</returns>
        public static List<int> GetIntListFromString(string postValue, bool sortBeforeReturn)
        {
            if (String.IsNullOrEmpty(postValue))
            {
                return new List<int>();
            }

            List<int> intList = new List<int>();
            string[] intStrArray = postValue.Trim().TrimEnd(',').Split(',');
            foreach (string rowIndex in intStrArray)
            {
                if (!String.IsNullOrEmpty(rowIndex))
                {
                    intList.Add(Convert.ToInt32(rowIndex));
                }
            }

            if (sortBeforeReturn)
            {
                // 按照从小到大排序 
                intList.Sort();
            }

            return intList;
        }


        /// <summary>
        /// 将字符串"ssdd,2,ok"转化为字符串列表["ssdd","2","ok"]
        /// </summary>
        /// <param name="postValue">字符串</param>
        /// <returns>字符串列表</returns>
        public static List<string> GetStringListFromString(string postValue)
        {
            return GetStringListFromString(postValue, false);
        }

        /// <summary>
        /// 将字符串"ssdd,2,ok"转化为字符串列表["ssdd","2","ok"]
        /// </summary>
        /// <param name="postValue"></param>
        /// <param name="sortBeforeReturn">返回之前是否对数组进行排序（由小到大）</param>
        /// <returns>字符串列表</returns>
        public static List<string> GetStringListFromString(string postValue, bool sortBeforeReturn)
        {
            if (String.IsNullOrEmpty(postValue))
            {
                return new List<string>();
            }

            List<string> strList = new List<string>();
            string[] strArray = postValue.Trim().TrimEnd(',').Split(',');
            foreach (string str in strArray)
            {
                if (!String.IsNullOrEmpty(str))
                {
                    strList.Add(str);
                }
            }

            if (sortBeforeReturn)
            {
                // 按照从小到大排序 
                strList.Sort();
            }

            return strList;
        }

        /// <summary>
        /// 将字符串数组["ssdd","2","ok"]转化为字符串"ssdd,2,ok"
        /// </summary>
        /// <param name="strArray">字符串数组</param>
        /// <returns>字符串</returns>
        public static string GetStringFromStringArray(string[] strArray)
        {
            if (strArray == null || strArray.Length == 0)
            {
                return String.Empty;
            }

            StringBuilder sb = new StringBuilder();
            foreach (string str in strArray)
            {
                sb.AppendFormat("{0},", str);
            }

            return sb.ToString().TrimEnd(',');
        }

        /// <summary>
        /// 将整型数组[2,3,4]转化为字符串"2,3,4"
        /// </summary>
        /// <param name="intArray">整形数组</param>
        /// <returns>字符串</returns>
        public static string GetStringFromIntArray(int[] intArray)
        {
            if (intArray == null || intArray.Length == 0)
            {
                return String.Empty;
            }

            StringBuilder sb = new StringBuilder();
            foreach (int str in intArray)
            {
                sb.AppendFormat("{0},", str);
            }

            return sb.ToString().TrimEnd(',');
        }

        #endregion

        #region CompareIntArray/CompareStringArray

        /// <summary>
        /// 比较两个整形数组是否相等
        /// 顺序无关，比如 [1,2] 和 [2,1] 被认为是相同的
        /// </summary>
        /// <param name="array1">整形数组1</param>
        /// <param name="array2">整形数组2</param>
        /// <returns>是否相等</returns>
        public static bool CompareIntArray(int[] array1, int[] array2)
        {
            return CompareIntArray(array1, array2, false);
        }

        /// <summary>
        /// 比较两个整形数组是否相等
        /// </summary>
        /// <param name="array1">整形数组1</param>
        /// <param name="array2">整形数组2</param>
        /// <param name="keepOrder">是否保持顺序</param>
        /// <returns>是否相等</returns>
        public static bool CompareIntArray(int[] array1, int[] array2, bool keepOrder)
        {
            if (array1 == null && array2 == null)
            {
                return true;
            }

            if ((array1 == null && array2 != null) || (array1 != null && array2 == null))
            {
                return false;
            }

            if (array1.Length != array2.Length)
            {
                return false;
            }

            if (keepOrder)
            {
                for (int i = 0, count = array1.Length; i < count; i++)
                {
                    if (array1[i] != array2[i])
                    {
                        return false;
                    }
                }
            }
            else
            {
                List<int> list1 = new List<int>(array1);
                List<int> list2 = new List<int>(array2);

                foreach (int item in list1)
                {
                    if (!list2.Contains(item))
                    {
                        return false;
                    }
                }
            }

            /*
            for (int i = 0; i < list1.Count; i++)
            {
                if (list1[i] != list2[i])
                {
                    return false;
                }
            }
            */

            return true;
        }

        /// <summary>
        /// 比较两个字符串数组是否相等
        /// 顺序无关，比如 ["value1","value2"] 和 ["value2","value1"] 被认为是相同的
        /// </summary>
        /// <param name="array1">字符串数组1</param>
        /// <param name="array2">字符串数组2</param>
        /// <returns>是否相等</returns>
        public static bool CompareStringArray(string[] array1, string[] array2)
        {
            return CompareStringArray(array1, array2, false);
        }

        /// <summary>
        /// 比较两个字符串数组是否相等
        /// </summary>
        /// <param name="array1">字符串数组1</param>
        /// <param name="array2">字符串数组2</param>
        /// <param name="keepOrder">是否保持顺序</param>
        /// <returns>是否相等</returns>
        public static bool CompareStringArray(string[] array1, string[] array2, bool keepOrder)
        {
            if (array1 == null && array2 == null)
            {
                return true;
            }

            if ((array1 == null && array2 != null) || (array1 != null && array2 == null))
            {
                return false;
            }

            if (array1.Length != array2.Length)
            {
                return false;
            }

            if (keepOrder)
            {
                for (int i = 0, count = array1.Length; i < count; i++)
                {
                    if (array1[i] != array2[i])
                    {
                        return false;
                    }
                }
            }
            else
            {
                List<string> list1 = new List<string>(array1);
                List<string> list2 = new List<string>(array2);

                foreach (string item in list1)
                {
                    if (!list2.Contains(item))
                    {
                        return false;
                    }
                }
            }

            /*
            for (int i = 0; i < list1.Count; i++)
            {
                if (list1[i] != list2[i])
                {
                    return false;
                }
            }
            */

            return true;
        }

        #endregion

        #region ConvertPercentageToDecimalString

        /// <summary>
        /// 将 10% 转换为 0.1 的字符串的形式
        /// </summary>
        /// <param name="percentageStr">百分比字符串</param>
        /// <returns>小数</returns>
        public static string ConvertPercentageToDecimalString(string percentageStr)
        {
            //string decimalStr = String.Empty;

            //percentageStr = percentageStr.Trim().Replace("％", "%").TrimEnd('%');

            //try
            //{
            //    decimalStr = (Convert.ToDouble(percentageStr) * 0.01).ToString("F2", System.Globalization.CultureInfo.InvariantCulture);
            //}
            //catch
            //{
            //    ;
            //}

            //return decimalStr;

            string decimalStr = String.Empty;

            percentageStr = percentageStr.Trim().ToLower().Replace("％", "%");
            if (percentageStr.EndsWith("%"))
            {
                percentageStr = percentageStr.TrimEnd('%');

                try
                {
                    decimalStr = (Convert.ToDouble(percentageStr) * 0.01).ToString("F2", System.Globalization.CultureInfo.InvariantCulture);
                }
                catch
                {
                    // nothing
                }
            }
            else if (percentageStr.EndsWith("px"))
            {
                decimalStr = percentageStr.Substring(0, percentageStr.Length - 2);
            }
            else
            {
                decimalStr = percentageStr;
            }

            return decimalStr;
        }

        #endregion

        #region DecodeFrom64/EncodeTo64

        /// <summary>
        /// Base64解码
        /// </summary>
        /// <param name="encodedDataAsBytes">需要解码的字节数组</param>
        /// <returns>解码后的字符串</returns>
        public static string DecodeFrom64(byte[] encodedDataAsBytes)
        {
            return System.Text.UTF8Encoding.UTF8.GetString(encodedDataAsBytes);
        }

        /// <summary>
        /// Base64解码
        /// </summary>
        /// <param name="encodedData">需要解码的字符串</param>
        /// <returns>解码后的字符串</returns>
        public static string DecodeFrom64(string encodedData)
        {
            byte[] encodedDataAsBytes = System.Convert.FromBase64String(encodedData);
            return System.Text.UTF8Encoding.UTF8.GetString(encodedDataAsBytes);
        }

        /// <summary>
        /// Base64编码
        /// </summary>
        /// <param name="toEncodeAsBytes">需要编码的字节数组</param>
        /// <returns>编码后的字符串</returns>
        public static string EncodeTo64(byte[] toEncodeAsBytes)
        {
            return System.Convert.ToBase64String(toEncodeAsBytes);
        }

        /// <summary>
        /// Base64编码
        /// </summary>
        /// <param name="toEncode">需要编码的字符串</param>
        /// <returns>编码后的字符串</returns>
        public static string EncodeTo64(string toEncode)
        {
            byte[] toEncodeAsBytes = System.Text.UTF8Encoding.UTF8.GetBytes(toEncode);
            return System.Convert.ToBase64String(toEncodeAsBytes);
        }
        #endregion

        #region Gzip/Ungzip

        /// <summary>
        /// Gzip编码字符串
        /// </summary>
        /// <param name="source">源字符串</param>
        /// <returns>Gzip后的字符串</returns>
        public static string Gzip(string source)
        {
            using (var outStream = new MemoryStream())
            {
                using (var gzipStream = new GZipStream(outStream, CompressionMode.Compress))
                {
                    using (var mStream = new MemoryStream(Encoding.UTF8.GetBytes(source)))
                    {
                        mStream.WriteTo(gzipStream);
                    }
                }

                return StringUtil.EncodeTo64(outStream.ToArray());
            }
        }

        /// <summary>
        /// 解码Gzip字符串
        /// </summary>
        /// <param name="source">Gzip后的字符串</param>
        /// <returns>源字符串</returns>
        public static string Ungzip(string source)
        {
            byte[] bytes = Convert.FromBase64String(source);

            using (GZipStream stream = new GZipStream(new MemoryStream(bytes), CompressionMode.Decompress))
            {
                const int size = 512;
                byte[] buffer = new byte[size];
                using (MemoryStream memory = new MemoryStream())
                {
                    int count = 0;
                    do
                    {
                        count = stream.Read(buffer, 0, size);
                        if (count > 0)
                        {
                            memory.Write(buffer, 0, count);
                        }
                    } while (count > 0);

                    return System.Text.Encoding.UTF8.GetString(memory.ToArray());
                }
            }
        }
        #endregion

        #region LoadGzippedViewState
        /// <summary>
        /// 加载Gzipped的ViewState
        /// </summary>
        /// <param name="gzippedState"></param>
        /// <returns></returns>
        public static object LoadGzippedViewState(string gzippedState)
        {
            string ungzippedState = StringUtil.Ungzip(gzippedState);
            LosFormatter formatter = new LosFormatter();
            return formatter.Deserialize(ungzippedState);
        }

        /// <summary>
        /// 生成Gzipped的ViewState
        /// </summary>
        /// <param name="viewState"></param>
        /// <returns></returns>
        public static string GenerateGzippedViewState(object viewState)
        {
            LosFormatter formatter = new LosFormatter();
            using (StringWriter writer = new StringWriter())
            {
                formatter.Serialize(writer, viewState);
                return StringUtil.Gzip(writer.ToString());
            }
        }
        #endregion

    }
}
