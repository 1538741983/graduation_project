using System.ServiceModel;
using OJ.Domain;

namespace JudgeService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IJudgeService”。
    [ServiceContract]
    public interface IJudgeEnginesService
    {
        [OperationContract]
        void DoWork();

        [OperationContract]
        bool AddSolution(SolutionDO solution);

    }
}
