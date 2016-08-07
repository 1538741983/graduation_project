using System;
using FineUI;
using OJCMS.APPCode;
using OJCMS.OJService;

namespace OJCMS.ProblemTest
{
    public partial class ProblemEdit : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnCancel.OnClientClick = ActiveWindow.GetHideReference();
                LoadData();
            }
        }

        private void LoadData()
        {
            int problemId = int.Parse(Request.QueryString["id"]);
            string action = Request.QueryString["action"];
            Alert.ShowInTop(action);
            IOJService service = new OJServiceClient();
            ProblemDO problem = service.GetProblemById(problemId);
            ProblemId.Text = problem.Id.ToString();
            TxtTitle.Text = problem.Title;
            TxtDifficulty.Text = problem.Difficulty;
            TxtTimeLimit.Text = problem.Time_limit.ToString();
            TxtMemeoryLimit.Text = problem.Memory_limit.ToString();
            TxtSource.Text = problem.Source;
            TxtInput.Text = problem.Input;
            TxtOutput.Text = problem.Output;
            TxtSampleInput.Text = problem.Sample_input;
            TxtSampleOutput.Text = problem.Sample_output;
            TxtHint.Text = problem.Hint;

            PageContext.RegisterStartupScript(String.Format("content = {0};", JsHelper.Enquote(problem.Describe)));
            //PageContext.RegisterStartupScript(String.Format("updateEditor({0});", JsHelper.Enquote(problem.Describe)));

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            ProblemDO problem = new ProblemDO();

            problem.Id = Convert.ToInt64(ProblemId.Text);
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
            ProblemDO result = service.UpdateProblem(problem);
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