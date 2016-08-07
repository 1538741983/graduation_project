using System;
using System.Web.Helpers;
using System.Web.Mvc;
using OJ.Models;
using OJ.OJService;

namespace OJ.Controllers
{
    public class ProblemController : Controller
    {
        private ProblemModel model;

        public ProblemController()
        {
            model = new ProblemModel();
        }

        public ViewResult ProblemList(string id)
        {
            string[] actionParams = id == null ? new string[0] : id.Split('/');
            ProblemPageList problemPageList = model.GetProblemPageList(3,
                actionParams.Length >= 1 ? Convert.ToInt32(actionParams[0]) : 1,
                actionParams.Length >= 2 ? actionParams[1] : string.Empty);
            return View(problemPageList);
        }

        public ViewResult ProblemDetails(long id)
        {
            ProblemDO problem = model.GetProblem(id);
            TempData["id_problem"] = id;
            ViewData["id_problem"] = id;
            return View(problem);
        }

        [HttpPost]
        public ActionResult SubmitCode()
        {

            Int64 id_problem = Convert.ToInt64(TempData["id_problem"]);
            string code = Request.Unvalidated().Form["code"];
            string language = Request.Form["language"];
            if (string.IsNullOrWhiteSpace(code) || string.IsNullOrWhiteSpace(language))
            {
                return null;
            }

            model.SubmitCode(id_problem, language, code);
            return RedirectToAction("SolutionList", "Solution");
        }
    }
}