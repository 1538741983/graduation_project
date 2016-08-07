using System;
using System.Web.Helpers;
using FineUI;
using OJCMS.APPCode;
using OJCMS.OJService;

namespace OJCMS.Problem
{
    public partial class ProblemInfo : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string action = Request.QueryString["action"];
                Action.Text = action;
                switch (action)
                {
                    case "View":
                        SetControlReadOnly(true);
                        LoadData();
                        break;
                    case "Edit":
                        this.Toolbar1.Hidden = false;
                        btnCancel.OnClientClick = ActiveWindow.GetHideReference();
                        LoadData();
                        break;
                    case "New":
                        this.Toolbar1.Hidden = false;
                        btnCancel.OnClientClick = ActiveWindow.GetHideReference();
                        break;
                }
                //btnCancel.OnClientClick = ActiveWindow.GetHideReference();
                //LoadData();
            }
        }

        /// <summary>
        /// 设置所有控件只读
        /// </summary>
        /// <param name="readOnly"></param>
        private void SetControlReadOnly(bool readOnly)
        {
            foreach (ControlBase item in BasicInfo.Items)
            {
                if (item is Field)
                {
                    (item as Field).Readonly = readOnly;
                }
            }

            foreach (ControlBase item in Panel1.Items)
            {
                if (item is Field)
                {
                    (item as Field).Readonly = readOnly;
                }
            }

            PageContext.RegisterStartupScript(String.Format("readonly = {0};", JsHelper.Enquote(readOnly.ToString())));
        }

        private void LoadData()
        {
            int problemId = int.Parse(Request.QueryString["id"]);
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


            problem.Title = TxtTitle.Text;
            problem.Difficulty = TxtDifficulty.Text;
            problem.Time_limit = Convert.ToInt32(TxtTimeLimit.Text);
            problem.Memory_limit = Convert.ToInt32(TxtMemeoryLimit.Text);
            problem.Source = TxtSource.Text;

            string describe = Request.Unvalidated().Form["Editor"];
            problem.Describe = describe;

            problem.Input = TxtInput.Text;
            problem.Sample_input = TxtSampleInput.Text;
            problem.Output = TxtOutput.Text;
            problem.Sample_output = TxtSampleOutput.Text;
            problem.Hint = TxtHint.Text;

            IOJService service = new OJServiceClient();
            ProblemDO result;
            if (Action.Text == "Edit")
            {
                problem.Id = Convert.ToInt64(ProblemId.Text);
                result = service.UpdateProblem(problem);
            }
            else if (Action.Text == "New")
            {
                result = service.AddProblem(problem);
            }
            else
            {
                return;
            }

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
    }
}