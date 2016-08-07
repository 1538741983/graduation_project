
using System;
using OJ.Domain;

namespace JudgeEngine.JudgeTask
{
    /// <summary>
    /// 判题任务管理器接口
    /// </summary>
    public interface IJudgeTaskManager
    {
        /// <summary>
        /// 添加判题任务
        /// </summary>
        /// <param name="solutionInfo">运行信息</param>
        /// <returns>是否添加成功</returns>
        bool AddTask(SolutionDO solutionInfo);
    }
}
