
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    Confirm.cs
 * CreatedOn:   2008-06-30
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
 */

#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace FineUI
{
    /// <summary>
    /// 确认对话框帮助类（静态类）
    /// </summary>
    public class Confirm
    {
        #region public static

        //public static string DefaultTitle = "确认对话框";

        /// <summary>
        /// 确认对话框默认图标
        /// </summary>
        public static MessageBoxIcon DefaultMessageBoxIcon = MessageBoxIcon.Question;


        ///// <summary>
        ///// 确认对话框默认图标
        ///// </summary>
        //public static MessageBoxIcon DefaultIcon = MessageBoxIcon.Question;


        #endregion

        #region class

        private string _cssClass;

        /// <summary>
        /// 样式类名
        /// </summary>
        public string CssClass
        {
            get { return _cssClass; }
            set { _cssClass = value; }
        }


        private string _message;

        /// <summary>
        /// 对话框消息正文
        /// </summary>
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }

        private string _title;

        /// <summary>
        /// 对话框标题
        /// </summary>
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        private MessageBoxIcon _messageBoxIcon = DefaultMessageBoxIcon;

        /// <summary>
        /// 对话框图标
        /// </summary>
        public MessageBoxIcon MessageBoxIcon
        {
            get { return _messageBoxIcon; }
            set { _messageBoxIcon = value; }
        }

        private string _okScript;

        /// <summary>
        /// 点击确认按钮执行的JavaScript脚本
        /// </summary>
        public string OkScript
        {
            get { return _okScript; }
            set { _okScript = value; }
        }


        private string _cancelScript;

        /// <summary>
        /// 点击取消按钮执行的JavaScript脚本
        /// </summary>
        public string CancelScript
        {
            get { return _cancelScript; }
            set { _cancelScript = value; }
        }

        private Target _target;

        /// <summary>
        /// 对话框的目标位置
        /// </summary>
        public Target Target
        {
            get { return _target; }
            set { _target = value; }
        }

        //private string _iconUrl;

        ///// <summary>
        ///// 自定义对话框图标地址
        ///// </summary>
        //public string IconUrl
        //{
        //    get { return _iconUrl; }
        //    set { _iconUrl = value; }
        //}

        //private Icon _icon = Icon.None;

        ///// <summary>
        ///// 自定义对话框图标
        ///// </summary>
        //public Icon Icon
        //{
        //    get { return _icon; }
        //    set { _icon = value; }
        //}


        /// <summary>
        /// 显示对话框
        /// </summary>
        public void Show()
        {
            //Show(Message, Title, MessageBoxIcon, OkScript, Target, Icon, IconUrl);
            PageContext.RegisterStartupScript(this.GetShowReference());
        }

        /// <summary>
        /// 获取显示对话框的客户端脚本
        /// </summary>
        /// <returns>客户端脚本</returns>
        public string GetShowReference()
        {
            string message = "";
            string title = "";
            if (!String.IsNullOrEmpty(Message))
            {
                message = Message;
            }
            if (!String.IsNullOrEmpty(Title))
            {
                title = Title;
            }


            JsObjectBuilder jsOB = new JsObjectBuilder();

            if (!String.IsNullOrEmpty(CancelScript))
            {
                jsOB.AddProperty("cancel", CancelScript);
            }

            if (!String.IsNullOrEmpty(OkScript))
            {
                jsOB.AddProperty("ok", OkScript);
            }

            if (Target != Target.Self)
            {
                jsOB.AddProperty("target", TargetHelper.GetName(Target));
            }

            if (MessageBoxIcon != MessageBoxIcon.Warning)
            {
                jsOB.AddProperty("messageIcon", MessageBoxIconHelper.GetShortName(MessageBoxIcon));
            }

            if (!String.IsNullOrEmpty(title))
            {
                jsOB.AddProperty("title", title.Replace("\r\n", "\n").Replace("\n", "<br/>"));
            }

            if (!String.IsNullOrEmpty(message))
            {
                jsOB.AddProperty("message", JsHelper.EnquoteWithScriptTag(message.Replace("\r\n", "\n").Replace("\n", "<br/>")), true);
            }

            return String.Format("F.confirm({0});", jsOB.ToString());
        }

        #endregion


        #region static Show

        /// <summary>
        /// 显示对话框
        /// </summary>
        /// <param name="message">消息正文</param>
        public static void Show(string message)
        {
            Show(message, String.Empty, DefaultMessageBoxIcon, String.Empty, String.Empty);
        }

        /// <summary>
        /// 显示对话框
        /// </summary>
        /// <param name="message">消息正文</param>
        /// <param name="title">标题</param>
        public static void Show(string message, string title)
        {
            Show(message, title, DefaultMessageBoxIcon, String.Empty, String.Empty);
        }

        /// <summary>
        /// 显示对话框
        /// </summary>
        /// <param name="message">消息正文</param>
        /// <param name="icon">图标</param>
        public static void Show(string message, MessageBoxIcon icon)
        {
            Show(message, String.Empty, icon, String.Empty, String.Empty);
        }

        /// <summary>
        /// 显示对话框
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <param name="title">对话框标题</param>
        /// <param name="okScript">点击确定按钮执行的客户端脚本</param>
        /// <param name="cancelScript">点击取消按钮执行的客户端脚本</param>
        public static void Show(string message, string title, string okScript, string cancelScript)
        {
            Show(message, title, DefaultMessageBoxIcon, okScript, cancelScript);
        }

        /// <summary>
        /// 显示对话框
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <param name="title">对话框标题</param>
        /// <param name="icon">对话框消息图标</param>
        public static void Show(string message, string title, MessageBoxIcon icon)
        {
            Show(message, title, icon, String.Empty, String.Empty);
        }

        /// <summary>
        /// 显示对话框
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <param name="title">对话框标题</param>
        /// <param name="icon">对话框消息图标</param>
        /// <param name="okScript">点击确定按钮执行的客户端脚本</param>
        /// <param name="cancelScript">点击取消按钮执行的客户端脚本</param>
        public static void Show(string message, string title, MessageBoxIcon icon, string okScript, string cancelScript)
        {
            PageContext.RegisterStartupScript(GetShowReference(message, title, icon, okScript, cancelScript));
        }

        /// <summary>
        /// 显示对话框
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <param name="title">对话框标题</param>
        /// <param name="icon">对话框消息图标</param>
        /// <param name="okScript">点击确定按钮执行的客户端脚本</param>
        /// <param name="cancelScript">点击取消按钮执行的客户端脚本</param>
        /// <param name="target">显示对话框的目标页面</param>
        public static void Show(string message, string title, MessageBoxIcon icon, string okScript, string cancelScript, Target target)
        {
            PageContext.RegisterStartupScript(GetShowReference(message, title, icon, okScript, cancelScript, target));
        }

        #endregion

        #region static ShowInParent

        /// <summary>
        /// 在父页面中显示对话框
        /// </summary>
        /// <param name="message">消息正文</param>
        public static void ShowInParent(string message)
        {
            ShowInParent(message, String.Empty, DefaultMessageBoxIcon, String.Empty, String.Empty);
        }

        /// <summary>
        /// 在父页面中显示对话框
        /// </summary>
        /// <param name="message">消息正文</param>
        /// <param name="title">标题</param>
        public static void ShowInParent(string message, string title)
        {
            ShowInParent(message, title, DefaultMessageBoxIcon, String.Empty, String.Empty);
        }

        /// <summary>
        /// 在父页面中显示对话框
        /// </summary>
        /// <param name="message">消息正文</param>
        /// <param name="icon">图标</param>
        public static void ShowInParent(string message, MessageBoxIcon icon)
        {
            ShowInParent(message, String.Empty, icon, String.Empty, String.Empty);
        }

        /// <summary>
        /// 在父页面中显示对话框
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <param name="title">对话框标题</param>
        /// <param name="okScript">点击确定按钮执行的客户端脚本</param>
        /// <param name="cancelScript">点击取消按钮执行的客户端脚本</param>
        public static void ShowInParent(string message, string title, string okScript, string cancelScript)
        {
            ShowInParent(message, title, DefaultMessageBoxIcon, okScript, cancelScript);
        }

        /// <summary>
        /// 在父页面中显示对话框
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <param name="title">对话框标题</param>
        /// <param name="icon">对话框消息图标</param>
        public static void ShowInParent(string message, string title, MessageBoxIcon icon)
        {
            ShowInParent(message, title, icon, String.Empty, String.Empty);
        }

        /// <summary>
        /// 在父页面中显示对话框
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <param name="title">对话框标题</param>
        /// <param name="icon">对话框消息图标</param>
        /// <param name="okScript">点击确定按钮执行的客户端脚本</param>
        /// <param name="cancelScript">点击取消按钮执行的客户端脚本</param>
        public static void ShowInParent(string message, string title, MessageBoxIcon icon, string okScript, string cancelScript)
        {
            PageContext.RegisterStartupScript(GetShowInParentReference(message, title, icon, okScript, cancelScript));
        }

        #endregion

        #region static ShowInTop

        /// <summary>
        /// 在顶层窗口中显示对话框
        /// </summary>
        /// <param name="message">消息正文</param>
        public static void ShowInTop(string message)
        {
            ShowInTop(message, String.Empty, DefaultMessageBoxIcon, String.Empty, String.Empty);
        }

        /// <summary>
        /// 在顶层窗口中显示对话框
        /// </summary>
        /// <param name="message">消息正文</param>
        /// <param name="title">对话框标题</param>
        public static void ShowInTop(string message, string title)
        {
            ShowInTop(message, title, DefaultMessageBoxIcon, String.Empty, String.Empty);
        }

        /// <summary>
        /// 在顶层窗口中显示对话框
        /// </summary>
        /// <param name="message">消息正文</param>
        /// <param name="icon">对话框消息图标</param>
        public static void ShowInTop(string message, MessageBoxIcon icon)
        {
            ShowInTop(message, String.Empty, icon, String.Empty, String.Empty);
        }

        /// <summary>
        /// 在顶层窗口中显示对话框
        /// </summary>
        /// <param name="message">消息正文</param>
        /// <param name="title">对话框标题</param>
        /// <param name="okScript">点击确定按钮执行的客户端脚本</param>
        /// <param name="cancelScript">点击取消按钮执行的客户端脚本</param>
        public static void ShowInTop(string message, string title, string okScript, string cancelScript)
        {
            ShowInTop(message, title, DefaultMessageBoxIcon, okScript, cancelScript);
        }

        /// <summary>
        /// 在顶层窗口中显示对话框
        /// </summary>
        /// <param name="message">消息正文</param>
        /// <param name="title">对话框标题</param>
        /// <param name="icon">对话框消息图标</param>
        public static void ShowInTop(string message, string title, MessageBoxIcon icon)
        {
            ShowInTop(message, title, icon, String.Empty, String.Empty);
        }

        /// <summary>
        /// 在顶层窗口中显示对话框
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <param name="title">对话框标题</param>
        /// <param name="icon">对话框消息图标</param>
        /// <param name="okScript">点击确定按钮执行的客户端脚本</param>
        /// <param name="cancelScript">点击取消按钮执行的客户端脚本</param>
        public static void ShowInTop(string message, string title, MessageBoxIcon icon, string okScript, string cancelScript)
        {
            PageContext.RegisterStartupScript(GetShowInTopReference(message, title, icon, okScript, cancelScript));
        }

        #endregion

        #region GetShowReference

        /// <summary>
        /// 获取显示对话框的客户端脚本
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <returns>客户端脚本</returns>
        public static string GetShowReference(string message)
        {
            return GetShowReference(message, String.Empty, DefaultMessageBoxIcon);
        }

        /// <summary>
        /// 获取显示对话框的客户端脚本
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <param name="title">对话框标题</param>
        /// <returns>客户端脚本</returns>
        public static string GetShowReference(string message, string title)
        {
            return GetShowReference(message, title, DefaultMessageBoxIcon);
        }

        /// <summary>
        /// 获取显示对话框的客户端脚本
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <param name="icon">对话框消息图标</param>
        /// <returns>客户端脚本</returns>
        public static string GetShowReference(string message, MessageBoxIcon icon)
        {
            return GetShowReference(message, String.Empty, icon);
        }

        /// <summary>
        /// 获取显示对话框的客户端脚本
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <param name="title">对话框标题</param>
        /// <param name="icon">对话框消息图标</param>
        /// <returns>客户端脚本</returns>
        public static string GetShowReference(string message, string title, MessageBoxIcon icon)
        {
            return GetShowReference(message, title, icon, String.Empty, String.Empty);
        }

        /// <summary>
        /// 获取显示对话框的客户端脚本
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <param name="title">对话框标题</param>
        /// <param name="okScript">点击确定按钮执行的客户端脚本</param>
        /// <param name="cancelScript">点击取消按钮执行的客户端脚本</param>
        /// <returns>客户端脚本</returns>
        public static string GetShowReference(string message, string title, string okScript, string cancelScript)
        {
            return GetShowReference(message, title, DefaultMessageBoxIcon, okScript, cancelScript);
        }

        /// <summary>
        /// 获取显示对话框的客户端脚本
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <param name="title">对话框标题</param>
        /// <param name="icon">对话框消息图标</param>
        /// <param name="okScript">点击确定按钮执行的客户端脚本</param>
        /// <param name="cancelScript">点击取消按钮执行的客户端脚本</param>
        /// <returns>客户端脚本</returns>
        public static string GetShowReference(string message, string title, MessageBoxIcon icon, string okScript, string cancelScript)
        {
            return GetShowReference(message, title, icon, okScript, cancelScript, Target.Self);
        }

        /// <summary>
        /// 获取显示确认对话框的客户端脚本
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <param name="title">对话框标题</param>
        /// <param name="icon">对话框图标</param>
        /// <param name="okScript">点击确定按钮执行的客户端脚本</param>
        /// <param name="cancelScript">点击取消按钮执行的客户端脚本</param>
        /// <param name="target">弹出对话框的目标页面</param>
        /// <returns>客户端脚本</returns>
        public static string GetShowReference(string message, string title, MessageBoxIcon icon, string okScript, string cancelScript, Target target)
        {
            Confirm confirm = new Confirm();
            confirm.Message = message;
            confirm.Title = title;
            confirm.MessageBoxIcon = icon;
            confirm.OkScript = okScript;
            confirm.CancelScript = cancelScript;
            confirm.Target = target;

            return confirm.GetShowReference();

            /*
                if (String.IsNullOrEmpty(title))
                {
                    title = "F.util.confirmTitle";
                }
                else
                {
                    title = JsHelper.GetJsString(title.Replace("\r\n", "\n").Replace("\n", "<br/>"));
                }
                message = message.Replace("\r\n", "\n").Replace("\n", "<br/>");


                JsObjectBuilder ob = new JsObjectBuilder();
                ob.AddProperty("title", title, true);
                ob.AddProperty("msg", JsHelper.GetJsStringWithScriptTag(message), true);
                ob.AddProperty("buttons", "Ext.MessageBox.OKCANCEL", true);
                ob.AddProperty("icon", String.Format("{0}", MessageBoxIconHelper.GetName(icon)), true);
                ob.AddProperty("fn", String.Format("function(btn){{if(btn=='cancel'){{{0}}}else{{{1}}}}}", cancelScript, okScriptstring), true);

                string targetName = "window";
                if (target != Target.Self)
                {
                    targetName = TargetHelper.GetScriptName(target);
                }
                return String.Format("{0}.Ext.MessageBox.show({1});", targetName, ob.ToString());
                */
            //string scriptTitle = "''";
            //if (!String.IsNullOrEmpty(title))
            //{
            //    scriptTitle = JsHelper.Enquote(title.Replace("\r\n", "\n").Replace("\n", "<br/>"));
            //}
            //string scriptMessage = JsHelper.EnquoteWithScriptTag(message.Replace("\r\n", "\n").Replace("\n", "<br/>"));

            //string scriptIconName = "''";
            //if (icon != MessageBoxIcon.Warning)
            //{
            //    scriptIconName = String.Format("'{0}'", MessageBoxIconHelper.GetShortName(icon));
            //}

            //string scriptTargetName = "''";
            //if (target != Target.Self)
            //{
            //    scriptTargetName = String.Format("'{0}'", TargetHelper.GetName(target));
            //}
            //string scriptCancel = JsHelper.Enquote(cancelScript);
            //string scriptOK = JsHelper.Enquote(okScript);



            //JsObjectBuilder jsOB = new JsObjectBuilder();

            //if (!String.IsNullOrEmpty(cancelScript))
            //{
            //    jsOB.AddProperty("cancel", cancelScript);
            //}

            //if (!String.IsNullOrEmpty(okScript))
            //{
            //    jsOB.AddProperty("ok", okScript);
            //}

            //if (target != Target.Self)
            //{
            //    jsOB.AddProperty("target", TargetHelper.GetName(target));
            //}

            //if (icon != MessageBoxIcon.Warning)
            //{
            //    jsOB.AddProperty("messageIcon", MessageBoxIconHelper.GetShortName(icon));
            //}

            //if (!String.IsNullOrEmpty(title))
            //{
            //    jsOB.AddProperty("title", title.Replace("\r\n", "\n").Replace("\n", "<br/>"));
            //}

            //if (!String.IsNullOrEmpty(message))
            //{
            //    jsOB.AddProperty("message", JsHelper.EnquoteWithScriptTag(message.Replace("\r\n", "\n").Replace("\n", "<br/>")), true);
            //}

            //return String.Format("F.confirm({0});", jsOB.ToString());

            
        }

        #endregion


        #region static GetShowInParentReference

        /// <summary>
        /// 获取在父页面中显示对话框的客户端脚本
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <returns>客户端脚本</returns>
        public static string GetShowInParentReference(string message)
        {
            return GetShowInParentReference(message, String.Empty, DefaultMessageBoxIcon);
        }

        /// <summary>
        /// 获取在父页面中显示对话框的客户端脚本
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <param name="title">对话框标题</param>
        /// <returns>客户端脚本</returns>
        public static string GetShowInParentReference(string message, string title)
        {
            return GetShowInParentReference(message, title, DefaultMessageBoxIcon);
        }

        /// <summary>
        /// 获取在父页面中显示对话框的客户端脚本
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <param name="icon">对话框消息图标</param>
        /// <returns>客户端脚本</returns>
        public static string GetShowInParentReference(string message, MessageBoxIcon icon)
        {
            return GetShowInParentReference(message, String.Empty, icon);
        }

        /// <summary>
        /// 获取在父页面中显示对话框的客户端脚本
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <param name="title">对话框标题</param>
        /// <param name="icon">对话框消息图标</param>
        /// <returns>客户端脚本</returns>
        public static string GetShowInParentReference(string message, string title, MessageBoxIcon icon)
        {
            return GetShowInParentReference(message, title, icon, String.Empty, String.Empty);
        }

        /// <summary>
        /// 获取在父页面中显示对话框的客户端脚本
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <param name="title">对话框标题</param>
        /// <param name="okScript">点击确定按钮执行的客户端脚本</param>
        /// <param name="cancelScript">点击取消按钮执行的客户端脚本</param>
        /// <returns>客户端脚本</returns>
        public static string GetShowInParentReference(string message, string title, string okScript, string cancelScript)
        {
            return GetShowInParentReference(message, title, DefaultMessageBoxIcon, okScript, cancelScript);
        }

        /// <summary>
        /// 获取在父页面中显示对话框的客户端脚本
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <param name="title">对话框标题</param>
        /// <param name="icon">对话框消息图标</param>
        /// <param name="okScript">点击确定按钮执行的客户端脚本</param>
        /// <param name="cancelScript">点击取消按钮执行的客户端脚本</param>
        /// <returns>客户端脚本</returns>
        public static string GetShowInParentReference(string message, string title, MessageBoxIcon icon, string okScript, string cancelScript)
        {
            return GetShowReference(message, title, icon, okScript, cancelScript, Target.Parent);
        }

        #endregion

        #region static GetShowInTopReference

        /// <summary>
        /// 获取在最上层页面中显示对话框的客户端脚本
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <returns>客户端脚本</returns>
        public static string GetShowInTopReference(string message)
        {
            return GetShowInTopReference(message, String.Empty, DefaultMessageBoxIcon);
        }

        /// <summary>
        /// 获取在最上层页面中显示对话框的客户端脚本
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <param name="title">对话框标题</param>
        /// <returns>客户端脚本</returns>
        public static string GetShowInTopReference(string message, string title)
        {
            return GetShowInTopReference(message, title, DefaultMessageBoxIcon);
        }

        /// <summary>
        /// 获取在最上层页面中显示对话框的客户端脚本
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <param name="icon">对话框消息图标</param>
        /// <returns>客户端脚本</returns>
        public static string GetShowInTopReference(string message, MessageBoxIcon icon)
        {
            return GetShowInTopReference(message, String.Empty, icon);
        }

        /// <summary>
        /// 获取在最上层页面中显示对话框的客户端脚本
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <param name="title">对话框标题</param>
        /// <param name="icon">对话框消息图标</param>
        /// <returns>客户端脚本</returns>
        public static string GetShowInTopReference(string message, string title, MessageBoxIcon icon)
        {
            return GetShowInTopReference(message, title, icon, String.Empty, String.Empty);
        }

        /// <summary>
        /// 获取在最上层页面中显示对话框的客户端脚本
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <param name="title">对话框标题</param>
        /// <param name="okScript">点击确定按钮执行的客户端脚本</param>
        /// <param name="cancelScript">点击取消按钮执行的客户端脚本</param>
        /// <returns>客户端脚本</returns>
        public static string GetShowInTopReference(string message, string title, string okScript, string cancelScript)
        {
            return GetShowInTopReference(message, title, DefaultMessageBoxIcon, okScript, cancelScript);
        }

        /// <summary>
        /// 获取在最上层页面中显示对话框的客户端脚本
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <param name="title">对话框标题</param>
        /// <param name="icon">对话框消息图标</param>
        /// <param name="okScript">点击确定按钮执行的客户端脚本</param>
        /// <param name="cancelScript">点击取消按钮执行的客户端脚本</param>
        /// <returns>客户端脚本</returns>
        public static string GetShowInTopReference(string message, string title, MessageBoxIcon icon, string okScript, string cancelScript)
        {
            return GetShowReference(message, title, icon, okScript, cancelScript, Target.Top);
        }

        #endregion
    }
}
