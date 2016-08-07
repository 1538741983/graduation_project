
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    ObjectUtil.cs
 * CreatedOn:   2008-06-11
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
using System.Reflection;
using System.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FineUI
{
    /// <summary>
    /// 对象帮助类
    /// </summary>
    public class ObjectUtil
    {
        /// <summary>
        /// 获取对象的属性值
        /// </summary>
        /// <param name="obj">可能是DataRowView或一个对象</param>
        /// <param name="propertyName">属性名</param>
        /// <returns>属性值</returns>
        public static object GetPropertyValue(object obj, string propertyName)
        {
            object result = null;

            try
            {
                if (obj is DataRow)
                {
                    result = (obj as DataRow)[propertyName];
                }
                else if (obj is DataRowView)
                {
                    result = (obj as DataRowView)[propertyName];
                }
                else if (obj is JObject)
                {
                    result = (obj as JObject).Value<JValue>(propertyName).Value; //.getValue(propertyName);
                }
                else
                {
                    result = GetPropertyValueFormObject(obj, propertyName);
                }
            }
            catch (Exception)
            {
                // 找不到此属性
            }

            return result;
        }

        /// <summary>
        /// 获取对象的属性值
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="propertyName">属性名（"Color"、"BodyStyle"或者"Info.UserName"）</param>
        /// <returns>属性值</returns>
        private static object GetPropertyValueFormObject(object obj, string propertyName)
        {
            object rowObj = obj;
            object result = null;

            if (propertyName.IndexOf(".") > 0)
            {
                string[] properties = propertyName.Split('.');
                object tmpObj = rowObj;

                for (int i = 0; i < properties.Length; i++)
                {
                    PropertyInfo property = tmpObj.GetType().GetProperty(properties[i], BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                    if (property != null)
                    {
                        tmpObj = property.GetValue(tmpObj, null);
                    }
                }

                result = tmpObj;
            }
            else
            {
                PropertyInfo property = rowObj.GetType().GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                if (property != null)
                {
                    result = property.GetValue(rowObj, null);
                }
            }

            return result;
        }
    }
}
