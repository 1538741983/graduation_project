
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    ControlUtil.cs
 * CreatedOn:   2008-05-20
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

namespace FineUI
{
    /// <summary>
    /// 控件相关帮助函数
    /// </summary>
    public class ControlUtil
    {
        #region FindParentControl

        /// <summary>
        /// 查找父控件
        /// </summary>
        /// <param name="control">当前控件</param>
        /// <param name="controlType">查找控件的类型</param>
        /// <param name="checkSubclassOf">如果找到的控件实例继承自controlType，同样也认为是找到了</param>
        /// <returns>找到的第一个父控件</returns>
        public static Control FindParentControl(Control control, Type controlType, Boolean checkSubclassOf)
        {
            if (control == null || control is System.Web.UI.HtmlControls.HtmlForm)
            {
                return null;
            }

            if (control.Parent != null)
            {
                Type parentType = control.Parent.GetType();

                // http://stackoverflow.com/questions/2742276/in-c-how-do-i-check-if-a-type-is-a-subtype-or-the-type-of-an-object
                if (parentType.Equals(controlType) || (checkSubclassOf && parentType.IsSubclassOf(controlType)))
                {
                    return control.Parent;
                }
                else
                {
                    return FindParentControl(control.Parent, controlType, checkSubclassOf);
                }
            }

            return null;
        }


        /// <summary>
        /// 查找父控件
        /// </summary>
        /// <param name="control">当前控件</param>
        /// <param name="controlType">查找控件的类型</param>
        /// <returns>找到的第一个父控件</returns>
        public static Control FindParentControl(Control control, Type controlType)
        {
            return FindParentControl(control, controlType, false);
        }


        #endregion

        /// <summary>
        /// 获得服务器控件ID的客户端ID数组
        /// </summary>
        /// <param name="serverIDs"></param>
        /// <returns></returns>
        public static JsArrayBuilder GetControlClientIDs(string[] serverIDs)
        {
            JsArrayBuilder array = new JsArrayBuilder();
            foreach (string controlID in serverIDs)
            {
                Control control = ControlUtil.FindControl(controlID);
                if (control != null && control is ControlBase)
                {
                    array.AddProperty((control as ControlBase).ClientID);
                }
            }
            return array;
        }

        #region FindControl

        /// <summary>
        /// 查找父层次结构中是否存在用户控件
        /// </summary>
        /// <param name="ctrl">当前控件</param>
        /// <returns>父层次中的用户控件</returns>
        public static UserControl FindParentUserControl(Control ctrl)
        {
            Control found = FindParentControl(ctrl, typeof(UserControl), true);
            if (found != null)
            {
                return found as UserControl;
            }
            else
            {
                return null;
            }
            /*
            while (ctrl != null && !(ctrl is UserControl))
            {
                ctrl = ctrl.Parent;
            }
            if (ctrl != null)
            {
                return ctrl as UserControl;
            }
            return null;
             * */
        }

        // 在当前 ctrl 所在的用户控件中查找，如果找不到则在页面中查找
        internal static Control FindControlInUserControlOrPage(Control ctrl, string findControlID)
        {
            Control found = null;

            UserControl parentUserControl = FindParentUserControl(ctrl);
            if (parentUserControl != null)
            {
                found = FindControl(parentUserControl, findControlID);
            }

            if (found == null)
            {
                found = FindControl(findControlID);
            }

            return found;
        }

        /// <summary>
        /// 根据控件ID查找控件
        /// </summary>
        /// <param name="findControlID">要查找的控件ID</param>
        /// <returns>找到的控件</returns>
        public static Control FindControl(string findControlID)
        {
            Page page = HttpContext.Current.CurrentHandler as Page;
            if (page != null)
            {
                return FindControl(page, findControlID);
            }

            return null;
        }

        

        /// <summary>
        /// 根据控件类型查找控件
        /// </summary>
        /// <param name="controlType">要查找的控件类型</param>
        /// <returns>找到的控件</returns>
        public static Control FindControl(Type controlType)
        {
            Page page = HttpContext.Current.CurrentHandler as Page;
            if (page != null)
            {
                return FindControl(page, controlType);
            }

            return null;
        }

        /// <summary>
        /// 在父控件的所有子控件中查找控件
        /// </summary>
        /// <param name="control">父控件</param>
        /// <param name="findControlId">要查找的控件ID</param>
        /// <returns>找到的控件</returns>
        public static Control FindControl(Control control, string findControlId)
        {
            if (control != null && control.Controls.Count > 0)
            {
                foreach (Control c in control.Controls)
                {
                    if (c != null && c.ID == findControlId)
                    {
                        return c;
                    }
                    else
                    {
                        Control childControl = FindControl(c, findControlId);
                        if (childControl != null)
                        {
                            return childControl;
                        }
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// 在父控件的所有子控件中查找控件
        /// </summary>
        /// <param name="control">父控件</param>
        /// <param name="controlType">要查找的控件类型</param>
        /// <returns>找到的控件</returns>
        public static Control FindControl(Control control, Type controlType)
        {
            if (control != null && control.Controls.Count > 0)
            {
                foreach (Control c in control.Controls)
                {
                    if (c != null && c.GetType() == controlType)
                    {
                        return c;
                    }
                    else
                    {
                        Control childControl = FindControl(c, controlType);
                        if (childControl != null)
                        {
                            return childControl;
                        }
                    }
                }
            }

            return null;
        }

        #endregion
    }
}
