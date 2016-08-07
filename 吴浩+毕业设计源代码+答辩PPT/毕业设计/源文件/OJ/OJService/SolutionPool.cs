using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using OJ.Domain;
using OJService.JudgeService;

namespace OJService
{
    public class SolutionPool : ISolutionPool
    {
        private static ISolutionPool instance;

        private static readonly object AuxiliaryObj = new object();

        public static ISolutionPool Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (AuxiliaryObj)
                    {
                        if (instance == null)
                        {
                            instance = new SolutionPool();
                        }
                    }
                }
                return new SolutionPool();
            }
        }

        private List<SolutionDO> solutionList;

        private SolutionPool()
        {
            solutionList = new List<SolutionDO>();
        }

        public void AddSolution(SolutionDO solution)
        {
            WaitCallback callback = delegate
            {
                solutionList.Add(solution);
                IJudgeEnginesService judgeService = JudgeServerManager.Instance.GetJudgeServer();
                judgeService.AddSolution(solution);
            };

            ThreadPool.QueueUserWorkItem(callback);
        }
    }

    public interface ISolutionPool
    {
        void AddSolution(SolutionDO solution);
    }
}