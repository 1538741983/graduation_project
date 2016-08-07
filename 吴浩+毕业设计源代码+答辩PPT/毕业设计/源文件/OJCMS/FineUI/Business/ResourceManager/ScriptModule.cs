using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Web;
using System.Web.UI;


namespace FineUI
{
    /// <summary>
    /// ������ģ�飨��Ҫ��������Response.Redirect�������
    /// </summary>
    public class ScriptModule : IHttpModule
    {
        private void PreSendRequestHeadersHandler(object sender, EventArgs args)
        {
            HttpApplication application = (HttpApplication)sender;
            HttpResponse response = application.Response;

            if (response.StatusCode == 302)
            {
                if (application.Request.Form["F_AJAX"] == "true")
                {
                    string redirectLocation = response.RedirectLocation;
                    List<HttpCookie> cookies = new List<HttpCookie>(response.Cookies.Count);
                    for (int i = 0; i < response.Cookies.Count; i++)
                    {
                        cookies.Add(response.Cookies[i]);
                    }


                    response.ClearContent();
                    response.ClearHeaders();
                    for (int i = 0; i < cookies.Count; i++)
                    {
                        response.AppendCookie(cookies[i]);
                    }
                    response.Cache.SetCacheability(HttpCacheability.NoCache);
                    response.ContentType = "text/html";
                    response.Write(String.Format("window.location.href='{0}';", redirectLocation));
                }
            }
        }

        #region IHttpModule ��Ա

        /// <summary>
        /// �����Դ
        /// </summary>
        public void Dispose()
        {

        }

        /// <summary>
        /// ��ʼ��ģ��
        /// </summary>
        /// <param name="context">HttpӦ�ó���</param>
        public void Init(HttpApplication context)
        {
            context.PreSendRequestHeaders += new EventHandler(PreSendRequestHeadersHandler);
        }

        #endregion
    }
}
