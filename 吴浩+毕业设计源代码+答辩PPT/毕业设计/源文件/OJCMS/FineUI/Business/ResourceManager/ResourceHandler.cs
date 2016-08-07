using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Reflection;
using System.IO;
using System.Drawing.Imaging;

namespace FineUI
{
    /// <summary>
    /// 资源处理程序
    /// </summary>
    public class ResourceHandler : IHttpHandler
    {
        /// <summary>
        /// 处理资源的请求
        /// </summary>
        /// <param name="context">Http请求上下文</param>
        public void ProcessRequest(HttpContext context)
        {
            string type = String.Empty;
            string typeValue = String.Empty;
            string extjsBasePath = GlobalConfig.GetJSBasePath();


            if (!String.IsNullOrEmpty(typeValue = context.Request.QueryString["icon"]))
            {
                type = "icon";
            }
            else if (!String.IsNullOrEmpty(typeValue = context.Request.QueryString["theme"]))
            {
                type = "theme";
            }
            else if (!String.IsNullOrEmpty(typeValue = context.Request.QueryString["img"]))
            {
                type = "img";
            }
            else
            {
                context.Response.Write("Not supported!");
                return;
            }

            string filePath = String.Empty;
            string fileBasePath = String.Empty;
            switch (type)
            {
                case "icon":
                    if (!typeValue.EndsWith(".png") && !typeValue.EndsWith(".gif"))
                    {
                        typeValue = IconHelper.GetName((Icon)Enum.Parse(typeof(Icon), typeValue));
                    }
                    fileBasePath = GlobalConfig.GetIconBasePath();
                    filePath = String.Format("{0}/{1}", fileBasePath, typeValue);
                    break;
                case "theme":
                    string themePath = "";
                    string themeImageFormat = "";
                    int lastDotIndex = typeValue.LastIndexOf(".");
                    if (lastDotIndex >= 0)
                    {
                        themePath = typeValue.Substring(0, lastDotIndex).Replace('.', '/');
                        themeImageFormat = typeValue.Substring(lastDotIndex + 1);
                    }

                    fileBasePath = String.Format("{0}/res/images", extjsBasePath);
                    filePath = String.Format("{0}/{1}.{2}", fileBasePath, themePath, themeImageFormat);
                    break;
                case "img":
                    fileBasePath = String.Format("{0}/res/images", extjsBasePath);
                    filePath = String.Format("{0}/{1}", fileBasePath, typeValue);
                    break;
            }

            string imageType = GetImageFormat(typeValue);
            string filePathServer = context.Server.MapPath(filePath);

            // 非法图片后缀
            if (!_allowedImageTypes.Contains(imageType))
            {
                return;
            }

            // 不是根目录下的文件
            string rootPath = context.Server.MapPath(fileBasePath);
            if (!filePathServer.StartsWith(rootPath))
            {
                return;
            }

            // 不存在此文件
            if (!File.Exists(filePathServer))
            {
                return;
            }

            context.Response.WriteFile(filePathServer);
            context.Response.ContentType = "image/" + imageType;

            // 缓存一年，只能通过改变 URL 来强制更新缓存
            context.Response.Cache.SetExpires(DateTime.Now.AddYears(1));
            context.Response.Cache.SetCacheability(HttpCacheability.Public);
        }

        //private void RenderImage(HttpContext context, string resName)
        //{
        //    Assembly assembly = Assembly.GetExecutingAssembly();
        //    using (Stream stream = assembly.GetManifestResourceStream(resName))
        //    {
        //        using (System.Drawing.Image image = System.Drawing.Image.FromStream(stream))
        //        {
        //            // PNG输出时出现“GDI+ 中发生一般性错误”
        //            using (MemoryStream ms = new MemoryStream())
        //            {
        //                image.Save(ms, image.RawFormat);
        //                ms.WriteTo(context.Response.OutputStream);
        //                context.Response.ContentType = "image/" + GetImageFormat(image.RawFormat);
        //            }
        //        }
        //    }
        //}

        private string GetImageFormat(string fileName)
        {
            string imageFormat = String.Empty;

            int lastDotIndex = fileName.LastIndexOf(".");
            if (lastDotIndex >= 0)
            {
                imageFormat = fileName.Substring(lastDotIndex + 1);
            }
            return imageFormat;
        }


        private static readonly List<string> _allowedImageTypes = new List<string> { "bmp", "gif", "jpg", "jpeg", "png", "tiff", "icon" };


        private string GetImageFormat(ImageFormat format)
        {
            if (format == ImageFormat.Bmp)
            {
                return "bmp";
            }
            else if (format == ImageFormat.Gif)
            {
                return "gif";
            }
            else if (format == ImageFormat.Jpeg)
            {
                return "jpeg";
            }
            else if (format == ImageFormat.Png)
            {
                return "png";
            }
            else if (format == ImageFormat.Tiff)
            {
                return "tiff";
            }
            else if (format == ImageFormat.Icon)
            {
                return "icon";
            }
            return "gif";
        }


        /// <summary>
        /// 只要请求的 URL 相同，则请求可以重用
        /// </summary>
        public bool IsReusable
        {
            get
            {
                return true;
            }
        }
    }
}
