using OJ.Domain;

namespace JudgeEngine.JudgeTask
{
    public static class JudgeTaskFactory
    {
        /// <summary>
        /// 获取一个判题任务对象
        /// </summary>
        /// <param name="solutionInfo">运行信息</param>
        /// <returns>判题任务</returns>
        public static IJudgeTask GetJudgeTask(SolutionDO solutionInfo)
        {
            IJudgeTask task = new JudgeTask(solutionInfo);
            return task;
        }
    }
}
