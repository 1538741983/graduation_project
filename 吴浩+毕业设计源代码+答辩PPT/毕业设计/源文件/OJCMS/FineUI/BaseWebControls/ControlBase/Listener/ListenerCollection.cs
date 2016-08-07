
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    ListenerCollection.cs
 * CreatedOn:   2014-09-03
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
using System.Collections.ObjectModel;
using System.Web.UI;
using System.Collections;

namespace FineUI
{
    /// <summary>
    /// 客户端事件集合
    /// </summary>
    public class ListenerCollection : Collection<Listener>
    {
        /// <summary>
        /// 获取客户端处理函数名称
        /// </summary>
        /// <param name="eventName">事件名称</param>
        /// <returns>客户端处理函数名称</returns>
        public string GetEventHandler(string eventName)
        {
            string handler = String.Empty;
            foreach (Listener item in this)
            {
                if (item.Event == eventName)
                {
                    handler = item.Handler;
                    break;
                }
            }

            return handler;
        }

    }
}
