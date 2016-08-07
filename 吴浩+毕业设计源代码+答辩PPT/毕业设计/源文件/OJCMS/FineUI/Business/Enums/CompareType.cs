
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    CompareType.cs
 * CreatedOn:   2008-07-10
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
    /// 相比较的数据类型（用于表单控件的客户端验证）
    /// </summary>
    public enum CompareType
    {
        /// <summary>
        /// 浮点数
        /// </summary>
        Float,
        /// <summary>
        /// 整形
        /// </summary>
        Int,
        /// <summary>
        /// 字符串（默认值）
        /// </summary>
        String
    }

    ///// <summary>
    ///// 操作符名称
    ///// </summary>
    //internal static class OperatorName
    //{
    //    public static string GetName(Operator type)
    //    {
    //        string result = String.Empty;

    //        switch (type)
    //        {
    //            case Operator.Equal:
    //                result = "==";
    //                break;
    //            case Operator.GreaterThan:
    //                result = ">";
    //                break;
    //            case Operator.GreaterThanEqual:
    //                result = ">=";
    //                break;
    //            case Operator.LessThan:
    //                result = "<";
    //                break;
    //            case Operator.LessThanEqual:
    //                result = "<=";
    //                break;
    //            case Operator.NotEqual:
    //                result = "!=";
    //                break;
    //        }

    //        return result;
    //    }
    //}
}