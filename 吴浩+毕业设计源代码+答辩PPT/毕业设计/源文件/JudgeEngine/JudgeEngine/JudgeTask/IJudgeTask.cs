using System;
using OJ.Domain;

namespace JudgeEngine.JudgeTask
{
    public interface IJudgeTask : IDisposable
    {
        /// <summary>
        /// 开始执行判题任务
        /// </summary>
        /// <returns>是否成功</returns>
        bool Start();
        /// <summary>
        /// 运行信息
        /// </summary>
        SolutionDO SolutionDO { get; }
        /// <summary>
        /// 关闭判题任务
        /// </summary>
        void Close();

        /// <summary>
        /// 结果对比完成
        /// </summary>
        event EventHandler<ComparedEventArgs> Compared;
    }
}
