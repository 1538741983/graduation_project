
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    Alert.cs
 * CreatedOn:   2008-04-07
 * CreatedBy:   30372245@qq.com
 * 
 * 
 * Description：
 *      ->
 *   
 * History：
 *       
 *      ->2008-04-30    30372245@qq.com    改为静态帮助类
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
    /// 对话框帮助类
    /// </summary>
    public class Alert
    {
        #region public static

        /// <summary>
        /// 默认提示对话图标
        /// </summary>
        public static readonly MessageBoxIcon DefaultMessageBoxIcon = MessageBoxIcon.Information;

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

        private Target _target;

        /// <summary>
        /// 对话框的目标位置
        /// </summary>
        public Target Target
        {
            get { return _target; }
            set { _target = value; }
        }

        private string _iconUrl;

        /// <summary>
        /// 自定义对话框图标地址
        /// </summary>
        public string IconUrl
        {
            get { return _iconUrl; }
            set { _iconUrl = value; }
        }

        private Icon _icon = Icon.None;

        /// <summary>
        /// 自定义对话框图标
        /// </summary>
        public Icon Icon
        {
            get { return _icon; }
            set { _icon = value; }
        }


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
            //return GetShowReference(Message, Title, MessageBoxIcon, OkScript, Target, Icon, IconUrl);

            //if (message == null)
            //{
            //    message = String.Empty;
            //}
            //if (title == null)
            //{
            //    title = String.Empty;
            //}

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


            string addCSSScript = String.Empty;
            string iconScriptFragment = String.Empty;
            string resolvedIconUrl = IconHelper.GetResolvedIconUrl(Icon, IconUrl);

            Page page = HttpContext.Current.CurrentHandler as Page;
            if (page != null)
            {
                resolvedIconUrl = page.ResolveUrl(resolvedIconUrl);
            }

            Target target = Target;
            // Icon 或者 IconUrl 不为空
            if (!String.IsNullOrEmpty(resolvedIconUrl))
            {
                string className = String.Format("f-{0}-alert-icon", System.Guid.NewGuid().ToString("N"));

                var addCSSPrefix = String.Empty;
                if (target == Target.Parent)
                {
                    addCSSPrefix = "parent.";
                }
                else if (target == Target.Top)
                {
                    addCSSPrefix = "top.";
                }
                addCSSScript = String.Format("{0}F.addCSS('{1}','{2}');", addCSSPrefix, className, StyleUtil.GetNoRepeatBackgroundStyle("." + className, resolvedIconUrl));

                iconScriptFragment = String.Format("'{0}'", className);
            }
            else
            {
                iconScriptFragment = MessageBoxIconHelper.GetName(MessageBoxIcon);
            }

            message = message.Replace("\r\n", "\n").Replace("\n", "<br/>");
            title = title.Replace("\r\n", "\n").Replace("\n", "<br/>");
            string targetScript = "window";
            if (target != Target.Self)
            {
                targetScript = TargetHelper.GetScriptName(target);
            }

            JsObjectBuilder jsob = new JsObjectBuilder();
            if (!String.IsNullOrEmpty(CssClass))
            {
                jsob.AddProperty("cls", CssClass);
            }
            if (!String.IsNullOrEmpty(title))
            {
                jsob.AddProperty("title", title);
            }
            if (!String.IsNullOrEmpty(OkScript))
            {
                jsob.AddProperty("ok", JsHelper.GetFunction(OkScript), true);
            }
            if (!String.IsNullOrEmpty(message))
            {
                jsob.AddProperty("message", JsHelper.EnquoteWithScriptTag(message), true);
            }
            if (!String.IsNullOrEmpty(iconScriptFragment))
            {
                jsob.AddProperty("messageIcon", iconScriptFragment, true);
            }

            return addCSSScript + String.Format("{0}.F.alert({1});", targetScript, jsob);
        }

        #endregion

        #region static Show

        /// <summary>
        /// 显示对话框
        /// </summary>
        /// <param name="message">消息正文</param>
        public static void Show(string message)
        {
            Show(message, String.Empty, DefaultMessageBoxIcon, String.Empty);
        }

        /// <summary>
        /// 显示对话框
        /// </summary>
        /// <param name="message">消息正文</param>
        /// <param name="title">标题</param>
        public static void Show(string message, string title)
        {
            Show(message, title, DefaultMessageBoxIcon, String.Empty);
        }

        /// <summary>
        /// 显示对话框
        /// </summary>
        /// <param name="message">消息正文</param>
        /// <param name="icon">图标</param>
        public static void Show(string message, MessageBoxIcon icon)
        {
            Show(message, String.Empty, icon, String.Empty);
        }

        /// <summary>
        /// 显示对话框
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <param name="title">对话框标题</param>
        /// <param name="okScript">点击确定按钮执行的客户端脚本</param>
        public static void Show(string message, string title, string okScript)
        {
            Show(message, title, DefaultMessageBoxIcon, okScript);
        }

        /// <summary>
        /// 显示对话框
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <param name="title">对话框标题</param>
        /// <param name="icon">自定义对话框图标</param>
        public static void Show(string message, string title, MessageBoxIcon icon)
        {
            Show(message, title, icon, String.Empty);
        }

        /// <summary>
        /// 显示对话框
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <param name="title">对话框标题</param>
        /// <param name="icon">自定义对话框图标</param>
        /// <param name="okScript">点击确定按钮执行的客户端脚本</param>
        public static void Show(string message, string title, MessageBoxIcon icon, string okScript)
        {
            PageContext.RegisterStartupScript(GetShowReference(message, title, icon, okScript));
        }

        /// <summary>
        /// 显示对话框
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <param name="title">对话框标题</param>
        /// <param name="icon">自定义对话框图标</param>
        /// <param name="okScript">点击确定按钮执行的客户端脚本</param>
        /// <param name="target">显示对话框的目标页面</param>
        public static void Show(string message, string title, MessageBoxIcon icon, string okScript, Target target)
        {
            PageContext.RegisterStartupScript(GetShowReference(message, title, icon, okScript, target));
        }

        /// <summary>
        /// 显示对话框
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <param name="title">对话框标题</param>
        /// <param name="messageBoxIcon"></param>
        /// <param name="okScript">点击确定按钮执行的客户端脚本</param>
        /// <param name="target">显示对话框的目标页面</param>
        /// <param name="icon">自定义对话框图标</param>
        /// <param name="iconUrl">自定义对话框图标地址</param>
        public static void Show(string message, string title, MessageBoxIcon messageBoxIcon, string okScript, Target target, Icon icon, string iconUrl)
        {
            PageContext.RegisterStartupScript(GetShowReference(message, title, messageBoxIcon, okScript, target, icon, iconUrl));
        }

        #endregion

        #region static ShowInParent

        /// <summary>
        /// 在父页面中显示对话框
        /// </summary>
        /// <param name="message">消息正文</param>
        public static void ShowInParent(string message)
        {
            ShowInParent(message, String.Empty, DefaultMessageBoxIcon, String.Empty);
        }

        /// <summary>
        /// 在父页面中显示对话框
        /// </summary>
        /// <param name="message">消息正文</param>
        /// <param name="title">标题</param>
        public static void ShowInParent(string message, string title)
        {
            ShowInParent(message, title, DefaultMessageBoxIcon, String.Empty);
        }

        /// <summary>
        /// 在父页面中显示对话框
        /// </summary>
        /// <param name="message">消息正文</param>
        /// <param name="icon">图标</param>
        public static void ShowInParent(string message, MessageBoxIcon icon)
        {
            ShowInParent(message, String.Empty, icon, String.Empty);
        }

        /// <summary>
        /// 在父页面中显示对话框
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <param name="title">对话框标题</param>
        /// <param name="okScript">点击确定按钮执行的客户端脚本</param>
        public static void ShowInParent(string message, string title, string okScript)
        {
            ShowInParent(message, title, DefaultMessageBoxIcon, okScript);
        }

        /// <summary>
        /// 在父页面中显示对话框
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <param name="title">对话框标题</param>
        /// <param name="icon">自定义对话框图标</param>
        public static void ShowInParent(string message, string title, MessageBoxIcon icon)
        {
            ShowInParent(message, title, icon, String.Empty);
        }

        /// <summary>
        /// 在父页面中显示对话框
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <param name="title">对话框标题</param>
        /// <param name="icon">自定义对话框图标</param>
        /// <param name="okScript">点击确定按钮执行的客户端脚本</param>
        public static void ShowInParent(string message, string title, MessageBoxIcon icon, string okScript)
        {
            PageContext.RegisterStartupScript(GetShowInParentReference(message, title, icon, okScript));
        }

        #endregion

        #region static ShowInTop

        /// <summary>
        /// 在顶层窗口中显示对话框
        /// </summary>
        /// <param name="message">消息正文</param>
        public static void ShowInTop(string message)
        {
            ShowInTop(message, String.Empty, DefaultMessageBoxIcon, String.Empty);
        }

        /// <summary>
        /// 在顶层窗口中显示对话框
        /// </summary>
        /// <param name="message">消息正文</param>
        /// <param name="title">对话框标题</param>
        public static void ShowInTop(string message, string title)
        {
            ShowInTop(message, title, DefaultMessageBoxIcon, String.Empty);
        }

        /// <summary>
        /// 在顶层窗口中显示对话框
        /// </summary>
        /// <param name="message">消息正文</param>
        /// <param name="icon">自定义对话框图标</param>
        public static void ShowInTop(string message, MessageBoxIcon icon)
        {
            ShowInTop(message, String.Empty, icon, String.Empty);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message">消息正文</param>
        /// <param name="title">对话框标题</param>
        /// <param name="okScript">点击确定按钮执行的客户端脚本</param>
        public static void ShowInTop(string message, string title, string okScript)
        {
            ShowInTop(message, title, DefaultMessageBoxIcon, okScript);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message">消息正文</param>
        /// <param name="title">对话框标题</param>
        /// <param name="icon">自定义对话框图标</param>
        public static void ShowInTop(string message, string title, MessageBoxIcon icon)
        {
            ShowInTop(message, title, icon, String.Empty);
        }

        /// <summary>
        /// 在顶层窗口中显示对话框
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <param name="title">对话框标题</param>
        /// <param name="icon">自定义对话框图标</param>
        /// <param name="okScript">点击确定按钮执行的客户端脚本</param>
        public static void ShowInTop(string message, string title, MessageBoxIcon icon, string okScript)
        {
            PageContext.RegisterStartupScript(GetShowInTopReference(message, title, icon, okScript));
        }

        #endregion

        #region static GetShowReference

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
        /// <param name="icon">自定义对话框图标</param>
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
        /// <param name="icon">自定义对话框图标</param>
        /// <returns>客户端脚本</returns>
        public static string GetShowReference(string message, string title, MessageBoxIcon icon)
        {
            return GetShowReference(message, title, icon, String.Empty);
        }

        /// <summary>
        /// 获取显示对话框的客户端脚本
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <param name="title">对话框标题</param>
        /// <param name="okScript">点击确定按钮执行的客户端脚本</param>
        /// <returns>客户端脚本</returns>
        public static string GetShowReference(string message, string title, string okScript)
        {
            return GetShowReference(message, title, DefaultMessageBoxIcon, okScript);
        }

        /// <summary>
        /// 获取显示对话框的客户端脚本
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <param name="title">对话框标题</param>
        /// <param name="icon">自定义对话框图标</param>
        /// <param name="okScript">点击确定按钮执行的客户端脚本</param>
        /// <returns>客户端脚本</returns>
        public static string GetShowReference(string message, string title, MessageBoxIcon icon, string okScript)
        {
            return GetShowReference(message, title, icon, okScript, Target.Self);
        }

        /// <summary>
        /// 获取显示对话框的客户端脚本
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <param name="title">对话框标题</param>
        /// <param name="icon">自定义对话框图标</param>
        /// <param name="okScript">点击确定按钮执行的客户端脚本</param>
        /// <param name="target">显示对话框的目标页面</param>
        /// <returns>客户端脚本</returns>
        public static string GetShowReference(string message, string title, MessageBoxIcon icon, string okScript, Target target)
        {
            return GetShowReference(message, title, icon, okScript, target, Icon.None, null);
        }

        /// <summary>
        /// 获取显示对话框的客户端脚本
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <param name="title">对话框标题</param>
        /// <param name="messageBoxIcon"></param>
        /// <param name="okScript">点击确定按钮执行的客户端脚本</param>
        /// <param name="target">显示对话框的目标页面</param>
        /// <param name="icon"></param>
        /// <param name="iconUrl">自定义对话框图标地址</param>
        /// <returns>客户端脚本</returns>
        public static string GetShowReference(string message, string title, MessageBoxIcon messageBoxIcon, string okScript, Target target, Icon icon, string iconUrl)
        {
            Alert alert = new Alert();
            alert.Message = message;
            alert.Title = title;
            alert.MessageBoxIcon = messageBoxIcon;
            alert.OkScript = okScript;
            alert.Target = target;
            alert.Icon = icon;
            alert.IconUrl = iconUrl;
            return alert.GetShowReference();    

            
            //if (String.IsNullOrEmpty(title) &&
            //    messageBoxIcon == DefaultMessageBoxIcon &&
            //    String.IsNullOrEmpty(okScript) &&
            //    String.IsNullOrEmpty(resolvedIconUrl))
            //{
            //    return addCSSScript + String.Format("{0}.F.alert({1});", targetScript, JsHelper.Enquote(message));
            //}
            //else
            //{
            //    return addCSSScript + String.Format("{0}.F.alert({1},{2},{3},{4});",
            //        targetScript,
            //        JsHelper.EnquoteWithScriptTag(message),
            //        JsHelper.Enquote(title),
            //        iconScriptFragment,
            //        String.IsNullOrEmpty(okScript) ? "''" : JsHelper.GetFunction(okScript));
            //}
            
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
        /// <param name="icon">自定义对话框图标</param>
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
        /// <param name="icon">自定义对话框图标</param>
        /// <returns>客户端脚本</returns>
        public static string GetShowInParentReference(string message, string title, MessageBoxIcon icon)
        {
            return GetShowInParentReference(message, title, icon, String.Empty);
        }

        /// <summary>
        /// 获取在父页面中显示对话框的客户端脚本
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <param name="title">对话框标题</param>
        /// <param name="okScript">点击确定按钮执行的客户端脚本</param>
        /// <returns>客户端脚本</returns>
        public static string GetShowInParentReference(string message, string title, string okScript)
        {
            return GetShowInParentReference(message, title, DefaultMessageBoxIcon, okScript);
        }

        /// <summary>
        /// 获取在父页面中显示对话框的客户端脚本
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <param name="title">对话框标题</param>
        /// <param name="icon">自定义对话框图标</param>
        /// <param name="okScript">点击确定按钮执行的客户端脚本</param>
        /// <returns>客户端脚本</returns>
        public static string GetShowInParentReference(string message, string title, MessageBoxIcon icon, string okScript)
        {
            return GetShowReference(message, title, icon, okScript, Target.Parent);
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
        /// <param name="icon">自定义对话框图标</param>
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
        /// <param name="icon">自定义对话框图标</param>
        /// <returns>客户端脚本</returns>
        public static string GetShowInTopReference(string message, string title, MessageBoxIcon icon)
        {
            return GetShowInTopReference(message, title, icon, String.Empty);
        }

        /// <summary>
        /// 获取在最上层页面中显示对话框的客户端脚本
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <param name="title">对话框标题</param>
        /// <param name="okScript">点击确定按钮执行的客户端脚本</param>
        /// <returns>客户端脚本</returns>
        public static string GetShowInTopReference(string message, string title, string okScript)
        {
            return GetShowInTopReference(message, title, DefaultMessageBoxIcon, okScript);
        }

        /// <summary>
        /// 获取在最上层页面中显示对话框的客户端脚本
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <param name="title">对话框标题</param>
        /// <param name="icon">自定义对话框图标</param>
        /// <param name="okScript">点击确定按钮执行的客户端脚本</param>
        /// <returns>客户端脚本</returns>
        public static string GetShowInTopReference(string message, string title, MessageBoxIcon icon, string okScript)
        {
            return GetShowReference(message, title, icon, okScript, Target.Top);
        }

        #endregion

    }
}
