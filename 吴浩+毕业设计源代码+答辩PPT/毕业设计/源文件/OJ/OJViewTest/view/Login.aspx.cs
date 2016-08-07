using System;
using System.Web.UI;

namespace OJViewTest.view
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        private void UserLogin(string username, string password)
        {

        }

        protected void btn_login_OnServerClick(object sender, EventArgs e)
        {
            string username = input_username.Value;
            string password = input_password.Value;

            UserLogin(username, password);

            Response.Redirect("MainPage.html" + "?pagenum=1");
        }
    }
}