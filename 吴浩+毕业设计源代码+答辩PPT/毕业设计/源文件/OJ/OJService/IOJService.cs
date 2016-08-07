using System.Linq;
using System.ServiceModel;
using OJ.BLL;
using OJ.BLL.PageList;
using OJ.Domain;

namespace OJService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IOJService”。
    [ServiceContract]
    public interface IOJService
    {
        [OperationContract]
        void AfreshJudge();

        [OperationContract]
        string Test(string str);

        [OperationContract]
        IQueryable<ProblemDO> GetProblemList();

        [OperationContract]
        ProblemPageList GetProblemPageList(int pageSize, int pageIndex, string queryText);

        [OperationContract]
        ProblemDO GetProblemById(long problemId);

        [OperationContract]
        ProblemDO AddProblem(ProblemDO problem);

        [OperationContract]
        ProblemDO UpdateProblem(ProblemDO problem);

        [OperationContract]
        bool DeleleProblemById(long problemId);

        [OperationContract]
        bool DeleleProblem(ProblemDO problem);

        [OperationContract]
        SolutionDO SubmitCode(long problem, string language, string code);

        [OperationContract]
        bool SubmitJudgeResult(SolutionDO solution);

        [OperationContract]
        SolutionPageList GetSolutionPageList(int pageSize, int pageIndex);


        [OperationContract]
        UserDO[] GetUserDoByUserName(string userName);

        [OperationContract]
        UserPageList GetUserPageList(int pageSize, int pageIndex, string queryText);

        [OperationContract]
        UserDO GetUserById(int userId);

        [OperationContract]
        string AddUser(string userInfo);

        [OperationContract(Name = "AddUserDo")]
        bool AddUser(UserDO user);

        [OperationContract]
        bool UpdateUser(UserDO user);

        [OperationContract]
        bool DeleteUserById(int userId);

    }
}
