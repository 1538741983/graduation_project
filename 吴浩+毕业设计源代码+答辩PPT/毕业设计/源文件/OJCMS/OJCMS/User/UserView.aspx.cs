using System;
using OJCMS.APPCode;
using OJCMS.OJService;

namespace OJCMS.User
{
    public partial class UserView : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            int userId = int.Parse(Request.QueryString["id"]);
            IOJService service = new OJServiceClient();
            UserDO user = service.GetUserById(userId);

            TxtUserName.Text = user.Username;
            TxtUserPassWord.Text = user.Password;
            TxtName.Text = user.Name;
            TxtAge.Text = user.Age.ToString();
            TxtBirthday.SelectedDate = user.Birthday;
            TxtAddress.Text = user.Address;
        }
    }
}