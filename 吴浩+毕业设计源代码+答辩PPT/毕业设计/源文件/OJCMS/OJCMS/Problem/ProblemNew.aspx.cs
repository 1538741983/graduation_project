using System;
using FineUI;
using OJCMS.APPCode;
using OJCMS.OJCMSService;
using OJCMS.OJService;

namespace OJCMS.Problem
{
    public partial class ProblemNew : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //btnCancel.OnClientClick = ActiveWindow.GetHideReference();
                //TxtBirthday.MaxDate = DateTime.Now;
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
            ProblemDO problem = new ProblemDO();

            problem.Title = TxtTitle.Text;
            problem.Difficulty = TxtDifficulty.Text;
            problem.Time_limit = Convert.ToInt32(TxtTimeLimit.Text);
            problem.Memory_limit = Convert.ToInt32(TxtMemeoryLimit.Text);
            problem.Source = TxtSource.Text;

            string describe = Request.Form["Editor"];
            problem.Describe = describe;

            problem.Input = TxtInput.Text;
            problem.Sample_input = TxtSampleInput.Text;
            problem.Output = TxtOutput.Text;
            problem.Sample_output = TxtSampleOutput.Text;
            problem.Hint = TxtHint.Text;



            IOJService service = new OJServiceClient();
            ProblemDO result = service.AddProblem(problem);
            if (result != null)
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