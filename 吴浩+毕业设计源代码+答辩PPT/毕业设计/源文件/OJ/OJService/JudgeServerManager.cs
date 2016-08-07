using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OJService.JudgeService;

namespace OJService
{
    public class JudgeServerManager : IJudgeServerManager
    {
        /// <summary>
        /// 单例对象
        /// </summary>
        private static IJudgeServerManager instance;

        /// <summary>
        /// 辅助对象，用于多线程时的锁定
        /// </summary>
        private static readonly object AuxiliaryObj = new object();

        /// <summary>
        /// 单例对象
        /// </summary>
        public static IJudgeServerManager Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (AuxiliaryObj)
                    {
                        if (instance == null)
                        {
                            instance = new JudgeServerManager();
                        }
                    }
                }
                return instance;
            }
        }


        private List<IJudgeEnginesService> judgeServerList;

        private JudgeServerManager()
        {
            judgeServerList = new List<IJudgeEnginesService>();
        }


        public IJudgeEnginesService GetJudgeServer()
        {
            IJudgeEnginesService server = new JudgeEnginesServiceClient();
            return server;
        }


    }

    public class JudgeServer
    {
    }

    public interface IJudgeServerManager
    {
        IJudgeEnginesService GetJudgeServer();
    }
}