
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    HeaderResourceHelper.cs
 * CreatedOn:   2008-05-04
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
using System.Configuration;
using System.Reflection;
using System.Web.UI;
using System.IO;
using System.Web.UI.HtmlControls;

namespace FineUI
{
    internal static class CommonResourceHelper
    {
        #region static

        public static readonly string CONTROL_ID_PREFIX = "FineUI_";

        //private static readonly string HeaderCommentId = HeaderControlIdPrefix + "comment";
        //private static readonly string HeaderDefaultCssId = HeaderControlIdPrefix + "ext-all-css";
        //private static readonly string HeaderGrayCssId = HeaderControlIdPrefix + "xtheme-gray-css";
        //private static readonly string HeaderExtBaseJsId = HeaderControlIdPrefix + "ext-base-js";
        //private static readonly string HeaderExtAllJsId = HeaderControlIdPrefix + "ext-all-js";



        public static readonly string COMMENT_INCLUDE_TEMPLATE = "<!-- {0} -->\r\n";
        public static readonly string SCRIPT_INCLUDE_TEMPLATE = "<script src=\"{0}\" type=\"text/javascript\"></script>\r\n";
        //public static readonly string SCRIPT_CONTENT_TEMPLATE = "\r\n<script type=\"text/javascript\">{0}</script>\r\n";
        public static readonly string STYLE_INCLUDE_TEMPLATE = "<link href=\"{0}\" rel=\"stylesheet\" type=\"text/css\"/>\r\n";
        public static readonly string STYLE_CONTENT_TEMPLATE = "<style type=\"text/css\">{0}</style>\r\n";
        public static readonly string META_TEMPLATE = "<meta http-equiv=\"{0}\" content=\"{1}\" />\r\n";


        #endregion

        #region RegisterCommonResource

        internal static void RegisterCommonResource(Page page)
        {
            #region powered-by

            string metaName = "powered-by";
            string metaContent = String.Format("FineUI v{0} - 基于 ExtJS 的开源 ASP.NET 控件库 - http://fineui.com/", GlobalConfig.ProductVersion);
            AddContentToHead(page, CONTROL_ID_PREFIX + "comments", String.Format(META_TEMPLATE, metaName, metaContent));


            // 是否向页面输出IE=edge标识
            if (PageManager.Instance.IEEdge)
            {
                AddContentToHead(page, CONTROL_ID_PREFIX + "xua", String.Format(META_TEMPLATE, "X-UA-Compatible", "IE=edge,chrome=1"));
            }


            #endregion

            // ExtJS CSS & JS 版本号，只有升级更新CSS或者JS时才需要更新。
            //string extjsCSSJSVersion = "3";
            //string fineuiVersion = GlobalConfig.ProductVersion;
            string extjsBasePath = page.ResolveUrl(GlobalConfig.GetJSBasePath());

            #region css

            if (!String.IsNullOrEmpty(PageManager.Instance.CustomTheme))
            {
                /*
                AddCssPathToHead(page, CONTROL_ID_PREFIX + "notheme.css", String.Format("{0}/res/css/notheme.css", extjsBasePath));

                string themePath = String.Format("{0}/css/xtheme-{1}.css", page.ResolveUrl(PageManager.Instance.CustomThemeBasePath), PageManager.Instance.CustomTheme);
                AddCssPathToHead(page, CONTROL_ID_PREFIX + "custom-theme.css", themePath);

                AddCssPathToHead(page, CONTROL_ID_PREFIX + "ux.css", String.Format("{0}/res/css/ux.css", extjsBasePath));
                */

                string themeName = PageManager.Instance.CustomTheme;

                AddCssPathToHead(page, CONTROL_ID_PREFIX + themeName + ".css", String.Format("{0}/ext-theme-{1}/all.css?v{2}", page.ResolveUrl(PageManager.Instance.CustomThemeBasePath), themeName, GlobalConfig.ProductVersion));
            }
            else
            {
                string themeName = ThemeHelper.GetName(PageManager.Instance.Theme);

                if (themeName == "blue")
                {
                    themeName = "classic";
                }

                AddCssPathToHead(page, CONTROL_ID_PREFIX + themeName + ".css", String.Format("{0}/res/ext-theme-{1}/all.css?v{2}", extjsBasePath, themeName, GlobalConfig.ProductVersion));

                //AddCssPathToHead(page, CONTROL_ID_PREFIX + "ux.css", String.Format("{0}/res/css/ux.css", extjsBasePath));
            }



            #endregion

            #region javascript

            if (GlobalConfig.GetDebugMode())
            {
                AddJavascriptPathToPageBottom(page, "ext-part1.js", String.Format("{0}/ext-part1.js?v{1}", extjsBasePath, GlobalConfig.ProductVersion));
                AddJavascriptPathToPageBottom(page, "ext-part2.js", String.Format("{0}/ext-part2.js?v{1}", extjsBasePath, GlobalConfig.ProductVersion));

            }
            else
            {
                AddJavascriptPathToPageBottom(page, "ext-all.js", String.Format("{0}/ext-all.js?v{1}", extjsBasePath, GlobalConfig.ProductVersion));
            }

            // Neptune需要额外的JavaScript文件
            if (String.IsNullOrEmpty(PageManager.Instance.CustomTheme) && PageManager.Instance.Theme == Theme.Neptune)
            {
                AddJavascriptPathToPageBottom(page, "ext-theme-neptune.js", String.Format("{0}/ext-theme-neptune.js?v{1}", extjsBasePath, GlobalConfig.ProductVersion));
            }


            // 语言资源应该放在最后，其中包含对 X.js 的语言定义
            string langName = LanguageHelper.GetName(PageManager.Instance.Language);
            AddJavascriptPathToPageBottom(page, langName + ".js", String.Format("{0}/lang/{1}.js?v{2}", extjsBasePath, langName, GlobalConfig.ProductVersion));

            #endregion
        }

        #endregion

        #region GetResourceUrlFromName

        private static string GetResourceUrlFromName(Page page, string resName)
        {
            return ResourceHelper.GetWebResourceUrlResAxd(page, resName);
        } 

        #endregion

        #region AddJavascriptIncludeToPageBottom

        public static void AddJavascriptPathToPageBottom(Page page, string controlId, string jsPath)
        {
            if (!page.ClientScript.IsClientScriptIncludeRegistered(controlId))
            {
                page.ClientScript.RegisterStartupScript(page.GetType(), controlId, String.Format(SCRIPT_INCLUDE_TEMPLATE, jsPath), false);
            }
        }

        /// <summary>
        /// 添加JS文件到页面的底部
        /// </summary>
        /// <param name="page"></param>
        /// <param name="controlId"></param>
        /// <param name="resourceName"></param>
        public static void AddJavascriptIncludeToPageBottom(Page page, string controlId, string resourceName)
        {
            if (!page.ClientScript.IsClientScriptIncludeRegistered(controlId))
            {
                page.ClientScript.RegisterStartupScript(page.GetType(), controlId, String.Format(SCRIPT_INCLUDE_TEMPLATE, GetResourceUrlFromName(page, resourceName)), false);
            }
        }

        public static void AddCssPathToHead(Page page, string controlId, string cssPath)
        {
            if (!IsHeaderContains(page, controlId))
            {
                LiteralControl control = new LiteralControl();
                control.ID = controlId;
                control.Text = String.Format(STYLE_INCLUDE_TEMPLATE, cssPath);

                page.Header.Controls.AddAt(GetNextControlIndex(page), control);
            }
        }

        /// <summary>
        /// 添加样式表到页头
        /// </summary>
        /// <param name="page"></param>
        /// <param name="controlId"></param>
        /// <param name="resourceName"></param>
        public static void AddCssResourceToHead(Page page, string controlId, string resourceName)
        {
            AddCssPathToHead(page, controlId, GetResourceUrlFromName(page, resourceName));
        }

        public static void AddCssContentToHead(Page page, string controlId, string cssContent)
        {
            if (!IsHeaderContains(page, controlId))
            {
                LiteralControl control = new LiteralControl();
                control.ID = controlId;
                control.Text = String.Format(STYLE_CONTENT_TEMPLATE, cssContent);

                page.Header.Controls.AddAt(GetNextControlIndex(page), control);
            }
        }

        /// <summary>
        /// 向页面头部添加内容
        /// </summary>
        /// <param name="page"></param>
        /// <param name="controlId"></param>
        /// <param name="msg"></param>
        public static void AddContentToHead(Page page, string controlId, string msg)
        {
            if (!IsHeaderContains(page, controlId))
            {
                LiteralControl control = new LiteralControl();
                control.ID = controlId;
                control.Text = msg;

                page.Header.Controls.AddAt(GetNextControlIndex(page), control);
            }
        }

        /// <summary>
        /// 页头是否包含控件
        /// </summary>
        /// <param name="page"></param>
        /// <param name="controlId"></param>
        /// <returns></returns>
        public static bool IsHeaderContains(Page page, string controlId)
        {
            foreach (Control c in page.Header.Controls)
            {
                if (c.ID != null && c.ID == controlId)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 取得下一个控件的位置
        /// </summary>
        /// <returns></returns>
        private static int GetNextControlIndex(Page page)
        {
            int index = 0;

            // 如果存在自定义（以CONTROL_ID_PREFIX开头）的控件，则返回最后一个自定义控件的下一个位置
            // 如果不存在自定义的控件，则返回<title>的下一个位置
            bool startControlBlock = false;
            int titleIndex = 0;
            foreach (Control c in page.Header.Controls)
            {
                if (c is HtmlTitle)
                {
                    titleIndex = index;
                }

                if (c.ID != null && c.ID.StartsWith(CONTROL_ID_PREFIX))
                {
                    startControlBlock = true;
                }
                else
                {
                    if (startControlBlock)
                    {
                        break;
                    }
                }

                index++;
            }

            int retIndex = startControlBlock ? index : titleIndex + 1;
            if (retIndex < 0)
            {
                retIndex = 0;
            }
            else if (retIndex >= page.Header.Controls.Count)
            {
                retIndex = page.Header.Controls.Count - 1;
            }

            return retIndex;
        }

        ///// <summary>
        ///// 取得Comment控件的位置（默认在title的下面）
        ///// </summary>
        ///// <returns></returns>
        //private static int GetCommentControlIndex(Page page)
        //{
        //    int index = 0;

        //    bool isFindTitle = false;
        //    foreach (Control c in page.Header.Controls)
        //    {
        //        if (c is System.Web.UI.HtmlControls.HtmlTitle)
        //        {
        //            isFindTitle = true;
        //            break;
        //        }

        //        index++;
        //    }

        //    return isFindTitle ? ++index : 0;
        //}
        #endregion

        #region RegisterHeaderCSS

        public static void RegisterHeaderCSS(Page page, string cssContent)
        {
            string controlId = CONTROL_ID_PREFIX + "user_defined_css";
            if (!IsHeaderContains(page, controlId))
            {
                AddCssContentToHead(page, controlId, cssContent);
            }
        }

        #endregion
    }
}
