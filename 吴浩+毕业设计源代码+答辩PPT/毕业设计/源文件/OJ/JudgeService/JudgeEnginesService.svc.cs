using System.ServiceModel;
using JudgeEngine.JudgeTask;
using JudgeService.OJService;
using OJ.Domain;

namespace JudgeService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“JudgeService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 JudgeService.svc 或 JudgeService.svc.cs，然后开始调试。
    public class JudgeEnginesService : IJudgeEnginesService
    {
        private static readonly JudgeTaskManager taskManager = new JudgeTaskManager();

        //private static Dictionary<SolutionDO, IOJService> serviveList; 
        public JudgeEnginesService()
        {
            taskManager.Callback = SubmitJudgeResult;
        }

        public void DoWork()
        {
        }

        public bool AddSolution(SolutionDO solution)
        {
            return taskManager.AddTask(solution);
        }

        private bool SubmitJudgeResult(SolutionDO solution)
        {
            IOJService service = new OJServiceClient();
            return service.SubmitJudgeResult(solution);
        }
    }
}
