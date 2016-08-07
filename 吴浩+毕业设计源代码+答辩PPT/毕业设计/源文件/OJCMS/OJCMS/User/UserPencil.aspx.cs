using FineUI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OJCMS.APPCode;

namespace GDMM.ChildPages
{
    public partial class UserPencil : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BtnClose.OnClientClick = ActiveWindow.GetHidePostBackReference();
                LoadData();
            }
        }

        private void LoadData()
        {
            //给控件DDL绑定值
            T_Access access = new T_Access();
            DataTable dtAccess = access.SelAll();
            DDLAccessName.DataSource = dtAccess;
            DDLAccessName.DataTextField = "权限名称";
            DDLAccessName.DataValueField = "权限编号";
            DDLAccessName.DataBind();

            int uid = int.Parse(Request.QueryString["id"].ToString());
            T_User user = new T_User();
            user.U_id = uid;
            DataTable dtUser = user.SelectOne();
            LabUserID.Text = uid.ToString();
            TxtUserName.Text = dtUser.Rows[0]["用户名"].ToString();
            TxtUserPassWord.Text = dtUser.Rows[0]["用户密码"].ToString();
            DDLAccessName.SelectedValue = dtUser.Rows[0]["权限ID"].ToString();

        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            T_User user = new T_User();
            user.U_id = int.Parse(LabUserID.Text);
            user.U_name = TxtUserName.Text;
            DataTable dtuser = user.SelectNameId();
            if (dtuser.Rows.Count > 0)
            {
                Alert.ShowInTop("输入的用户名已存在,请重新填写用户名...");
                return;
            }
            else
            {
                user.U_password = TxtUserPassWord.Text;
                user.A_id = int.Parse(DDLAccessName.SelectedValue);
                user.U_del = true;
                user.UpdateUser();
                PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string updateSql = "UPDATE T_User SET ComputerID='' WHERE U_Name = @text";
            DbHelperSQL.ExecSql(updateSql, new SqlParameter("@text", TxtUserName.Text));
            Alert.ShowInTop("清除成功");
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }
    }
}