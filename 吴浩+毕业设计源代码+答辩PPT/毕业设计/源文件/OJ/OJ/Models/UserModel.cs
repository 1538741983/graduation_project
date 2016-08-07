using System.Collections.Generic;
using System.Linq;
using OJ.OJService;

namespace OJ.Models
{
    public class UserModel
    {
        private IOJService ojService;

        public UserModel()
        {
            ojService = new OJServiceClient();
            //userList = new List<UserDO>(ojService.GetUserList());
        }

        public UserDO GetUser(long id)
        {
            return null;
            //return userList.FirstOrDefault(t => t.Id == id);
        }

        public UserDO GetUser(string username)
        {
           return ojService.GetUserDoByUserName(username)[0];
           // return userList.FirstOrDefault(t => t.Id == id);
        }

        //public void Add(ProblemDO problem)
        //{
        //    ProblemDO result = ojService.AddProblem(problem);
        //    this.problemList.Add(result);
        //}

        //public void Update(ProblemDO problem)
        //{
        //    ProblemDO result = this.ojService.UpdateProblem(problem);
        //    this.ProblemList.Remove(problem);
        //    this.ProblemList.Add(result);
        //}

        //public void Delete(long id)
        //{
        //    ProblemDO problem = this.problemList.FirstOrDefault(t => t.id == id);
        //    bool flag = this.ojService.DeleleProblem(problem);
        //    if (flag)
        //    {
        //        this.problemList.Remove(problem);
        //    }
        //}

        //public void SubmitCode(long problemId, string sourceCode)
        //{
        //    try
        //    {
        //        this.ojService.SubmitCode(problemId, sourceCode);
        //    }
        //    catch (UpdateException e)
        //    {
        //        string str = e.InnerException.Message;
        //    }

        //}

        public bool AddUser(UserDO user)
        {
            return ojService.AddUserDo(user);
        }
    }
}