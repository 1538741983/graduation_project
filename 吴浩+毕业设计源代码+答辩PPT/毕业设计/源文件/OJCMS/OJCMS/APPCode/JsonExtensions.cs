using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace OJCMS.APPCode
{
    public static class JsonExtensions
    {
        /// <summary>
        /// 将一个对象序列化成 JSON 格式字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToJson(this object obj)
        {
            if (obj == null)
                return string.Empty;

            JavaScriptSerializer jss = new JavaScriptSerializer();
            return jss.Serialize(obj);
        }

        /// <summary>
        /// 从JSON字符串中反序列化对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cookie"></param>
        /// <returns></returns>
        public static T FromJson<T>(this string cookie)
        {
            if (string.IsNullOrEmpty(cookie))
                return default(T);

            JavaScriptSerializer jss = new JavaScriptSerializer();
            return jss.Deserialize<T>(cookie);
        }

        /// <summary>
        /// 从JSON字符串中反序列化对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cookie"></param>
        /// <returns></returns>
        public static List<T> FromJsonList<T>(this string cookie)
        {
            if (string.IsNullOrEmpty(cookie))
                return default(List<T>);

            JavaScriptSerializer jss = new JavaScriptSerializer();
            return jss.Deserialize<List<T>>(cookie);
        }
    }
}