using System;
using FineUI;
using OJCMS.APPCode;
using OJCMS.OJService;

namespace OJCMS.User
{
    public partial class UserEdit : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnCancel.OnClientClick = ActiveWindow.GetHideReference();
                TxtBirthday.MaxDate = DateTime.Now;
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
            //Ds.Text = user.Ds.ToString();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            UserDO user = new UserDO();

            //user.Ds = Convert.ToBoolean(Ds.Text);
            user.Username = TxtUserName.Text;
            user.Password = TxtUserPassWord.Text;
            user.Name = TxtName.Text;
            user.Age = string.IsNullOrWhiteSpace(TxtAge.Text) ? (int?)null : Convert.ToInt32(TxtAge.Text);
            user.Birthday = string.IsNullOrWhiteSpace(TxtBirthday.Text) ? (DateTime?)null : Convert.ToDateTime(TxtBirthday.Text);
            user.Address = TxtAddress.Text;

            IOJService service = new OJServiceClient();
            if (service.UpdateUser(user))
            {
                Alert.ShowInTop("保存成功。");
                PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference());
            }
            else
            {
                Alert.ShowInTop("保存失败。");
            }
        }

        //protected void DDLAccess_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (DDLAccess.SelectedItem != null)
        //    {
        //        Hid.Text = DDLAccess.SelectedValue;
        //    }
        //}
    }
}