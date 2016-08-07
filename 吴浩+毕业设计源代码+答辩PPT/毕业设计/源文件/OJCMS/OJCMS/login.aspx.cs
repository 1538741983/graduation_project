using System;
using System.Data;
using System.Web;
using System.Web.Security;
using OJCMS.APPCode;
using OJCMS.OJService;

namespace OJCMS
{
    public partial class Login : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.TxtZH.Text = "";
                this.TxtMM.Text = "";
            }
        }
        protected void Submit_Click(object sender, EventArgs e)
        {
            if (TxtZH.Text == "" || TxtMM.Text == "")
            {
                LBtishi2.Text = "账号或密码不能为空";
            }
            else
            {
                UserDO[] userList;
                try
                {
                    IOJService service = new OJServiceClient();
                    userList = service.GetUserDoByUserName(TxtZH.Text);
                }
                catch
                {
                    string a = "访问服务器失败！网络出现异常...";
                    string url = "Error.aspx?cw=" + a + "";
                    Response.Redirect(url);
                    return;
                }

                if (userList.Length == 0)
                {
                    LBtishi2.Text = "不存在该用户";
                }
                else
                {
                    if (TxtMM.Text == userList[0].Password)
                    {
                        UserModel model = new UserModel
                        {
                            UserId = userList[0].Id.ToString(),
                            UserName = userList[0].Username,
                            PassWord = userList[0].Password,
                            A_ID = "1",
                            Ds = false,
                        };

                        FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                         1,
                         string.Format("OJ_{0}", TxtZH.Text),
                         DateTime.Now,
                         DateTime.Now.AddMinutes(600),
                         false,
                         model.ToJson()
                         );
                        string token = FormsAuthentication.Encrypt(ticket);
                        HttpCookie userCookie = new HttpCookie(FormsAuthentication.FormsCookieName, token);
                        Response.Cookies.Add(userCookie);
                        Response.Redirect("~/Default.aspx");
                    }
                    else
                    {
                        LBtishi2.Text = "密码错误";
                    }
                }
            }
        }

        protected void cs_Click(object sender, EventArgs e)
        {

        }
    }
}