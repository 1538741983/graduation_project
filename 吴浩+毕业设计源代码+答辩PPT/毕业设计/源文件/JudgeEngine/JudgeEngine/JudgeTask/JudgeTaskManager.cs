using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Common;
using OJ.Domain;

namespace JudgeEngine.JudgeTask
{
    /// <summary>
    /// 判题任务管理器
    /// author: wuhao
    /// </summary>
    public class JudgeTaskManager : IJudgeTaskManager
    {
        #region 变量定义区域

        public Func<SolutionDO, bool> Callback { get; set; }

        private static bool canMove = false;

        /// <summary>
        /// 判题任务队列大小
        /// </summary>
        private int judgeListSize;

        /// <summary>
        /// 等待任务队列大小
        /// </summary>
        private int waitListSize;

        /// <summary>
        /// 判题任务队列
        /// </summary>
        private List<IJudgeTask> judgeList;

        /// <summary>
        /// 等待任务队列
        /// </summary>
        private Queue<SolutionDO> waitList;

        #endregion


        /// <summary>
        /// 添加等待任务事件
        /// </summary>
        public EventHandler AddWaitTask { get; set; }

        public EventHandler TaskJudged { get; set; }


        #region 构造函数区域

        public JudgeTaskManager()
        {
            this.judgeListSize = 100;
            this.waitListSize = 100;
            this.judgeList = new List<IJudgeTask>(judgeListSize);
            this.waitList = new Queue<SolutionDO>(waitListSize);
            canMove = true;

            AddWaitTask += MoveWaitToJudge;
            TaskJudged += MoveWaitToJudge;
        }

        #endregion


        #region 接口实现区域

        /// <summary>
        /// 添加判题任务
        /// </summary>
        /// <param name="solutionInfo">运行信息</param>
        /// <returns>是否添加成功</returns>
        public bool AddTask(SolutionDO solutionInfo)
        {
            Logger.Instance.OnLoggerMessage(string.Format("添加{0}任务。", solutionInfo.id));
            //bool success = AddTaskToJudgeList(solutionInfo);
            //if (!success)
            //{
            bool success = AddTaskToWaitList(solutionInfo);
            // }

            return success;
        }

        #endregion


        #region 辅助处理区域

        /// <summary>
        /// 添加判题任务到判题队列
        /// </summary>
        /// <param name="solutionInfo">运行信息</param>
        /// <returns>是否成功</returns>
        private bool AddTaskToJudgeList(SolutionDO solutionInfo)
        {
            //如果判题队列已满，则不添加
            if (this.judgeList.Count >= judgeListSize)
                return false;
            ////创建判题任务实例
            IJudgeTask judgeTask = JudgeTaskFactory.GetJudgeTask(solutionInfo);
            judgeTask.Compared += judgeTask_Compared;
            //judgeTask.Complete += judgeTask_Complete;
            this.judgeList.Add(judgeTask);
            Logger.Instance.OnLoggerMessage(string.Format("任务{0}加入判题队列。", solutionInfo.id));

            WaitCallback callback = delegate
            {
                judgeTask.Start();
            };

            ThreadPool.QueueUserWorkItem(callback);

            return true;
        }

        void judgeTask_Compared(object sender, ComparedEventArgs e)
        {
            List<IJudgeTask> taskList = judgeList.Where(t => t.SolutionDO.id == e.Solution.id).ToList();
            for (int i = 0; i < taskList.Count(); i++)
            {
                judgeList.Remove(taskList[i]);
            }

            if (Callback != null)
                Logger.Instance.OnLoggerMessage(Callback(e.Solution).ToString());
        }

        /// <summary>
        /// 添加判题任务到等待队列
        /// </summary>
        /// <param name="solutionInfo">运行信息</param>
        /// <returns>是否成功</returns>
        private bool AddTaskToWaitList(SolutionDO solutionInfo)
        {
            lock (waitList)
            {
                //如果等待队列已满，则不添加
                if (waitList.Count >= waitListSize)
                {
                    Logger.Instance.OnLoggerMessage(string.Format("添加任务{0}失败，等待队列已满。", solutionInfo.id));
                    return false;
                }

                this.waitList.Enqueue(solutionInfo);
                Logger.Instance.OnLoggerMessage(string.Format("任务{0}加入等待队列。", solutionInfo.id));
                //Move();
                if (AddWaitTask != null)
                    AddWaitTask(this, EventArgs.Empty);
                return true;
            }

        }



        /// <summary>
        /// 判题任务退出时触发
        /// 对判题列表中的任务进行移除
        /// 提交判题结果
        /// </summary>
        /// <param name="sender">判题任务</param>
        /// <param name="e"></param>
        private void judgeTask_Complete(object sender, EventArgs e)
        {
            if (sender is IJudgeTask && judgeList.Contains((IJudgeTask)sender))
            {
                IJudgeTask judgeTask = sender as IJudgeTask;
                judgeList.Remove(judgeTask);
                Logger.Instance.OnLoggerMessage(string.Format("移除任务{0}成功。", (judgeTask).SolutionDO.id));
            }
            else
            {
                if (sender is IJudgeTask)
                    Logger.Instance.OnLoggerMessage(string.Format("移除任务{0}失败，找不到任务。", ((IJudgeTask)sender).SolutionDO.id));
            }
            if (TaskJudged != null)
                TaskJudged(this, EventArgs.Empty);
        }

        ///// <summary>
        ///// 建立异步的任务移动器
        ///// </summary>
        //private void Move()
        //{
        //    if (!canMove)
        //        return;
        //    lock (moveAction)
        //    {
        //        this.canMove = false;
        //        moveAction.BeginInvoke(delegate { this.canMove = true; }, null);
        //    }
        //}
        static private ReaderWriterLockSlim _waitListRwl = new ReaderWriterLockSlim();
        /// <summary>
        /// 移动等待中任务到判题队列
        /// </summary>
        private void MoveWaitToJudge(object sender, EventArgs e)
        {
            _waitListRwl.EnterReadLock();
            while (judgeList.Count < judgeListSize && waitList.Count > 0)
            {
                SolutionDO solution = waitList.Peek();
                Logger.Instance.OnLoggerMessage(string.Format("从等待队列获取到需要移动的运行任务，运行ID:{0}", solution.id));
                if (AddTaskToJudgeList(solution))
                {
                    waitList.Dequeue();
                    Logger.Instance.OnLoggerMessage(string.Format("从等待队列移除运行任务，运行ID:{0}", solution.id));
                }
            }
            _waitListRwl.ExitReadLock();
        }

        #endregion

        //public void Dispose()
        //{
        //    foreach (IJudgeTask judgeTask in judgeList)
        //    {
        //        judgeTask.Dispose();
        //    }
        //    judgeList.Clear();
        //}

        //public void Close()
        //{
        //    waitList.Clear();
        //    foreach (IJudgeTask judgeTask in judgeList)
        //    {
        //        judgeTask.Close();
        //    }
        //}
    }
}
