using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Newtonsoft.Json;
using OJ.BLL;
using OJ.BLL.PageList;
using OJ.Domain;
using OJ.IBLL;
using OJService.JudgeService;

namespace OJService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“OJService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 OJService.svc 或 OJService.svc.cs，然后开始调试。
    public class OJService : IOJService
    {
        private IProblemDOService problemService = new ProblemDOService();
        private IUserDOService userService = new UserDOService();

        public OJService()
        {

        }

        public void AfreshJudge()
        {
            WaitCallback callback = delegate
                {
                    IJudgeEnginesService judgeEnginesService = new JudgeEnginesServiceClient();

                    ISolutionDOService solutionDoService = new SolutionDOService();
                    IQueryable<SolutionDO> waitList = solutionDoService.LoadEntites(t => t.result == "Waiting");

                    foreach (SolutionDO solutionDo in waitList)
                    {
                        solutionDo.sourcecodeReference.Load();
                        solutionDo.languageReference.Load();

                        judgeEnginesService.AddSolution(solutionDo);
                        Thread.Sleep(1000);
                    }
                };

            ThreadPool.QueueUserWorkItem(callback);
        }


        public string Test(string str)
        {
            return str;
        }

        public IQueryable<ProblemDO> GetProblemList()
        {
            IProblemDOService problemService1 = new ProblemDOService();
            IQueryable<ProblemDO> list = problemService1.LoadEntites(t => true);
            return list;
        }

        public ProblemPageList GetProblemPageList(int pageSize, int pageIndex, string queryText)
        {
            ProblemPageList problemPageList = new ProblemPageList();
            problemPageList.CurrentPage = pageIndex;
            problemPageList.PageSize = pageSize;

            IProblemDOService service = new ProblemDOService();
            int totalCount;
            problemPageList.DataList = service.LoadEntites(t => string.IsNullOrEmpty(queryText) || t.Title.Contains(queryText), pageIndex, pageSize, out totalCount).ToArray();
            if (problemPageList.PageSize <= 0)
            {
                throw new Exception("页面大小不能小于等于0.");
            }
            problemPageList.TotalPages = totalCount / problemPageList.PageSize +
                                         ((totalCount % problemPageList.PageSize) > 0 ? 1 : 0);
            //string sqlString = "use OJ;select count(*) from [OJ].[dbo].[ProblemSet]";
            //int[] result = service.ExecuteStoreQuery<int>(sqlString);
            //if (result.Length != 1)
            //    return null;
            //problemPageList.RecordCount = result[0];

            //if (queryText == null)
            //{
            //    problemPageList.DataList = service.LoadEntites(t => true).ToArray();
            //}
            //else
            //{
            //    problemPageList.DataList = service.LoadEntites(t => t.Title.Contains(queryText)).ToArray();
            //}

            return problemPageList;


        }

        public ProblemDO GetProblemById(long problemId)
        {
            IProblemDOService service = new ProblemDOService();
            IQueryable<ProblemDO> result = service.LoadEntites(t => t.Id == problemId);
            if (result == null)
            {
                return null;
            }
            return result.First();
        }

        public ProblemDO AddProblem(ProblemDO problem)
        {
            problem.Uploader = 1;
            problem.Defunct = false;
            problem.In_date = DateTime.Now;
            problem.Accepted = 0;
            problem.Submit = 0;
            return problemService.AddEntity(problem);
        }

        public ProblemDO UpdateProblem(ProblemDO problem)
        {
            ProblemDO oldProblem = GetProblemById(problem.Id);
            oldProblem.Defunct = problem.Defunct;
            oldProblem.Describe = problem.Describe;
            //oldProblem.In_date = problem.In_date;
            oldProblem.Input = problem.Input;
            oldProblem.Output = problem.Output;
            oldProblem.Sample_input = problem.Sample_input;
            oldProblem.Sample_output = problem.Sample_output;
            // oldProblem.Uploader = problem.Uploader;
            oldProblem.Accepted = problem.Accepted;
            oldProblem.Difficulty = problem.Difficulty;
            oldProblem.Fg_special = problem.Fg_special;
            oldProblem.Hint = problem.Hint;
            oldProblem.Memory_limit = problem.Memory_limit;
            oldProblem.Solved = problem.Solved;
            oldProblem.Source = problem.Source;
            oldProblem.Submit = problem.Submit;
            oldProblem.Time_limit = problem.Time_limit;
            oldProblem.Title = problem.Title;

            return problemService.UpdateEntity(oldProblem);
        }

        public bool DeleleProblemById(long problemId)
        {
            IProblemDOService service = new ProblemDOService();
            return service.DelEntityByWhere(t => t.Id == problemId);
        }

        public bool DeleleProblem(ProblemDO problem)
        {
            return problemService.DelEntity(problem);
        }

        public SolutionDO SubmitCode(long problem, string language, string code)
        {
            ISolutionDOService solutionService = new SolutionDOService();
            SolutionDO solution = new SolutionDO();
            solution.id_problem = problem;
            solution.id_user = 1;
            //if (language == "C")
            solution.id_language = 1;
            solution.createTime = DateTime.Now;
            solution.codeLenght = code.Length.ToString();



            solution = solutionService.AddEntity(solution);
            solution.sourcecode = new SourceCodeDO();
            solution.sourcecode.Id_solution = solution.id;
            solution.sourcecode.Source_code = code;
            solution.result = "Waiting";

            ISourceCodeDOService sourceCodeService = new SourceCodeDOService();
            solution.sourcecode = sourceCodeService.AddEntity(solution.sourcecode);


            IProblemDOService problemDoService = new ProblemDOService();
            IQueryable<ProblemDO> problemList = problemDoService.LoadEntites(t => t.Id == solution.id_problem);
            if (problemList.Count() == 1)
            {
                ProblemDO problemTemp = problemList.First();
                problemTemp.Submit += 1;
                problemDoService.UpdateEntity(problemTemp);

            }

            //加载语言信息
            if (!solution.languageReference.IsLoaded)
                solution.languageReference.Load();

            //加载源代码信息
            if (!solution.sourcecodeReference.IsLoaded)
                solution.sourcecodeReference.Load();

            SolutionPool.Instance.AddSolution(solution);

            return solution;
        }

        public bool SubmitJudgeResult(SolutionDO solution)
        {
            IProblemDOService problemDoService = new ProblemDOService();
            if (solution.result == "Accepted")
            {
                IQueryable<ProblemDO> problemList = problemDoService.LoadEntites(t => t.Id == solution.id_problem);
                if (problemList.Count() == 1)
                {
                    ProblemDO problem = problemList.First();
                    problem.Accepted += 1;
                    problemDoService.UpdateEntity(problem);
                }
            }


            //ICallBack
            ISolutionDOService solutionService = new SolutionDOService();
            IQueryable<SolutionDO> solutionDataList = solutionService.LoadEntites(t => t.id == solution.id);
            if (solutionDataList.Count() != 1)
            {
                return false;
            }

            SolutionDO oldSolution = solutionDataList.First();
            oldSolution.result = solution.result;
            return solutionService.UpdateEntity(oldSolution) != null;
        }

        public SolutionPageList GetSolutionPageList(int pageSize, int pageIndex)
        {
            SolutionPageList solutionPageList = new SolutionPageList();
            solutionPageList.CurrentPage = pageIndex;
            solutionPageList.PageSize = pageSize;

            ISolutionDOService service = new SolutionDOService();
            int totalCount;

            solutionPageList.DataList = service.LoadEntites(t => true, pageIndex, pageSize, out totalCount, delegate(IEnumerable<SolutionDO> y)
            {
                return y.OrderByDescending(s => s.id);
            }).ToArray();
            if (solutionPageList.PageSize <= 0)
            {
                throw new Exception("页面大小不能小于等于0.");
            }
            solutionPageList.TotalPages = totalCount / solutionPageList.PageSize + ((totalCount % solutionPageList.PageSize) > 0 ? 1 : 0);

            //加载语言信息
            foreach (SolutionDO solutionDo in solutionPageList.DataList)
            {
                if (!solutionDo.languageReference.IsLoaded)
                    solutionDo.languageReference.Load();
            }

            return solutionPageList;
        }

        public UserDO[] GetUserDoByUserName(string userName)
        {
            return userService.LoadEntites(t => t.Username == userName).ToArray();
        }

        public UserPageList GetUserPageList(int pageSize, int pageIndex, string queryText)
        {
            UserPageList userPageList = new UserPageList();
            userPageList.CurrentPage = pageIndex;
            userPageList.PageSize = pageSize;

            IUserDOService service = new UserDOService();
            int totalCount;
            userPageList.DataList = service.LoadEntites(t => true, pageIndex, pageSize, out totalCount).ToArray();
            if (userPageList.PageSize <= 0)
            {
                throw new Exception("页面大小不能小于等于0.");
            }
            userPageList.TotalPages = totalCount / userPageList.PageSize + (totalCount % userPageList.PageSize) > 0 ? 1 : 0;
            return userPageList;
        }

        public UserDO GetUserById(int userId)
        {
            UserDO[] result = userService.LoadEntites(t => t.Id == userId).ToArray();
            if (result.Length == 1)
                return result[0];
            return null;
        }

        public string AddUser(string userInfo)
        {
            JsonConvert.DeserializeObject<UserDO>(userInfo);
            UserDO newInfo = userService.AddEntity(new UserDO());
            return newInfo.ToString();
        }

        public bool AddUser(UserDO user)
        {
            user.Id_language = 1;

            UserDO result = userService.AddEntity(user);
            return result != null;
        }

        public bool UpdateUser(UserDO user)
        {
            UserDO result = userService.UpdateEntity(user);
            return result != null;
        }

        public bool DeleteUserById(int userId)
        {
            return userService.DelEntityByWhere(t => t.Id == userId);
        }
    }
}
