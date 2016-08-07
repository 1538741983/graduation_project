using System;
using FineUI;
using OJCMS.APPCode;
using OJCMS.OJCMSService;
using OJCMS.OJService;

namespace OJCMS.Problem
{
    public partial class ProblemView : PageBase
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
            int problemId = int.Parse(Request.QueryString["id"]);
            IOJService service = new OJServiceClient();
            ProblemDO problem = service.GetProblemById(problemId);
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
            //PageContext.RegisterStartupScript(String.Format("updateEditor1({0});", problem.Describe /*JsHelper.Enquote(problem.Describe)*/));
        }
    }
}