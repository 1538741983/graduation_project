using System;
using FineUI;
using OJCMS.APPCode;
using OJCMS.OJCMSService;

namespace OJCMS.Role
{
    public partial class RoleNew : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnCancel.OnClientClick = ActiveWindow.GetHideReference();
                TxtBirthday.MaxDate = DateTime.Now;
                //BtnClose.OnClientClick = ActiveWindow.GetHidePostBackReference();
                //LoadData();
            }
        }

        private void LoadData()
        {
            ////给控件DDL绑定值
            //T_Access access = new T_Access();
            //DataTable dtAccess = access.SelAll();
            //DDLAccess.DataSource = dtAccess;
            //DDLAccess.DataTextField = "权限名称";
            //DDLAccess.DataValueField = "权限编号";
            //DDLAccess.DataBind();

            //FineUI.ListItem li = new FineUI.ListItem("请选择", "0");
            //DDLAccess.Items.Add(li);
            //DDLAccess.SelectedValue = "0";

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            UserDO user = new UserDO();

            user.Ds = false;
            user.UserName = TxtUserName.Text;
            user.Pwd = TxtUserPassWord.Text;
            user.Name = TxtName.Text;
            user.Age = string.IsNullOrWhiteSpace(TxtAge.Text) ? (int?)null : Convert.ToInt32(TxtAge.Text);
            user.Birthday = string.IsNullOrWhiteSpace(TxtBirthday.Text) ? (DateTime?)null : Convert.ToDateTime(TxtBirthday.Text);
            user.Address = TxtAddress.Text;

            IOJCMSService service = new OJCMSServiceClient();
            if (service.AddUserDo(user))
            {
                Alert.ShowInTop("保存成功。");
                PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference());
            }
            else
            {
                Alert.ShowInTop("保存失败。");
            }



            //T_User user = new T_User();
            //user.U_del = true;
            //if (DDLAccess.SelectedItem != null)
            //{
            //    if (Hid.Text.ToString() == "" || Hid.Text.ToString() == "0")
            //    {
            //        Alert.ShowInTop("请选择所属权限！！！");
            //        return;
            //    }
            //    else
            //    {
            //        user.A_id = int.Parse(Hid.Text.ToString());
            //    }
            //}
            //else
            //{
            //    Alert.ShowInTop("请选择所属权限！！！");
            //    return;
            //}

            //user.U_name = TxtUserName.Text.Trim();
            //DataTable dtuser = user.SelectName();
            //if (dtuser.Rows.Count > 0)
            //{
            //    Alert.ShowInTop("输入的用户名已存在,请重新填写用户名...");
            //    return;
            //}
            //else
            //{
            //    user.U_password = TxtUserPassWord.Text;

            //    user.InsertUser();
            //    PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
            //}
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