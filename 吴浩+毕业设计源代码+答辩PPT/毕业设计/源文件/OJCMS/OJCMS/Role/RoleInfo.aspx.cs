using System;
using FineUI;
using OJCMS.APPCode;
using OJCMS.OJCMSService;

namespace OJCMS.Role
{
    public partial class RoleInfo : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnCancel.OnClientClick = ActiveWindow.GetHideReference();
                Action.Text = Request.QueryString["action"];
                switch (Action.Text)
                {
                    case "Edit":
                        LoadData();
                        break;
                    case "New":
                        break;
                }
            }
        }

        private void LoadData()
        {
            Int64 roleId = int.Parse(Request.QueryString["id"]);
            IOJCMSService service = new OJCMSServiceClient();
            RoleDo role = service.GetRoleById(roleId);

            //TxtUserName.Text = user.UserName;
            //TxtUserPassWord.Text = user.Pwd;
            TxtName.Text = role.Name;
            //TxtAge.Text = user.Age.ToString();
            //TxtBirthday.SelectedDate = user.Birthday;
            //TxtAddress.Text = user.Address;
            //Ds.Text = user.Ds.ToString();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Action.Text == "Edit")
            {
                RoleDo role = new RoleDo();

                role.Id = Convert.ToInt64(RoleId.Text);
                role.Name = TxtName.Text;
                //user.Ds = Convert.ToBoolean(Ds.Text);
                //user.UserName = TxtUserName.Text;
                //user.Pwd = TxtUserPassWord.Text;
                //user.Name = TxtName.Text;
                //user.Age = string.IsNullOrWhiteSpace(TxtAge.Text) ? (int?)null : Convert.ToInt32(TxtAge.Text);
                //user.Birthday = string.IsNullOrWhiteSpace(TxtBirthday.Text) ? (DateTime?)null : Convert.ToDateTime(TxtBirthday.Text);
                //user.Address = TxtAddress.Text;

                IOJCMSService service = new OJCMSServiceClient();
                if (service.UpdateRole(role))
                {
                    Alert.ShowInTop("保存成功。");
                    PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference());
                }
                else
                {
                    Alert.ShowInTop("保存失败。");
                }
            }
            else if (Action.Text == "New")
            {
                RoleDo role = new RoleDo();

                role.Name = TxtName.Text;

                //user.Ds = Convert.ToBoolean(Ds.Text);
                //user.UserName = TxtUserName.Text;
                //user.Pwd = TxtUserPassWord.Text;
                //user.Name = TxtName.Text;
                //user.Age = string.IsNullOrWhiteSpace(TxtAge.Text) ? (int?)null : Convert.ToInt32(TxtAge.Text);
                //user.Birthday = string.IsNullOrWhiteSpace(TxtBirthday.Text) ? (DateTime?)null : Convert.ToDateTime(TxtBirthday.Text);
                //user.Address = TxtAddress.Text;

                IOJCMSService service = new OJCMSServiceClient();
                if (service.AddRole(role))
                {
                    Alert.ShowInTop("保存成功。");
                    PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference());
                }
                else
                {
                    Alert.ShowInTop("保存失败。");
                }
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