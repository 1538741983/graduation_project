using System;
using System.Collections.Generic;
using System.Linq;

namespace JudgeEngine.Process
{
    /// <summary>
    /// 进程仓库
    /// 负责存储所有进程，对进程进行复用
    /// </summary>
    public class ProcessWarehouse
    {
        private static object thisLock = new object();

        private static ProcessWarehouse instance;

        public static ProcessWarehouse Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (thisLock)
                    {
                        if (instance == null)
                            instance = new ProcessWarehouse();
                    }
                }
                return instance;
            }
        }
        /// <summary>
        /// 编译器列表
        /// </summary>
        //private List<CompilerProcess> compilerList;

        private Dictionary<CompilerProcess, bool> compilerList;
        /// <summary>
        /// 运行器列表
        /// </summary>
        //private List<RunProcess> runerList;

        private Dictionary<RunProcess, bool> runerList;

        /// <summary>
        /// 编译器最大个数
        /// </summary>
        private int compilerMaxCount;
        /// <summary>
        /// 运行器最大个数
        /// </summary>
        private int runerMaxCount;


        public ProcessWarehouse()
        {
            compilerMaxCount = 10;
            runerMaxCount = 10;

            //compilerList = new List<CompilerProcess>(compilerMaxCount);
            compilerList = new Dictionary<CompilerProcess, bool>();
            //runerList = new List<RunProcess>(runerMaxCount);
            runerList = new Dictionary<RunProcess, bool>();
        }

        public CompilerProcess GetComoiler(string language)
        {
            lock (thisLock)
            {
                CompilerProcess compiler;
                try
                {
                    compiler = compilerList.FirstOrDefault(t => t.Key != null && t.Value).Key;
                    if (compiler == default(CompilerProcess))
                    {
                        compiler = JudgeProcessFactory.GetCompilerProcess(language);
                        compilerList.Add(compiler, false);
                    }
                }
                catch (Exception)
                {
                    compiler = JudgeProcessFactory.GetCompilerProcess(language);
                    compilerList.Add(compiler, false);
                }
                compiler.Exited += compiler_Exited;
                return compiler;
            }
        }

        void compiler_Exited(object sender, EventArgs e)
        {
            if (sender is CompilerProcess)
            {
                CompilerProcess compilerProcess = sender as CompilerProcess;
                if (this.compilerList.ContainsKey(compilerProcess))
                    this.compilerList[compilerProcess] = true;
            }
        }

        public RunProcess GetRuner()
        {
            lock (thisLock)
            {
                RunProcess runer;
                try
                {
                    runer = runerList.FirstOrDefault(t => t.Key != null && t.Value).Key;
                    if (runer == default(RunProcess))
                    {
                        runer = JudgeProcessFactory.GetRunProcess();
                        runerList.Add(runer, false);
                    }
                }
                catch (Exception)
                {
                    runer = JudgeProcessFactory.GetRunProcess();
                    runerList.Add(runer, false);
                }
                runer.Refresh();
                runer.Exited += runer_Exited;
                return runer;
            }
        }

        void runer_Exited(object sender, EventArgs e)
        {
            if (sender is RunProcess)
            {
                RunProcess runProcess = sender as RunProcess;
                if (this.runerList.ContainsKey(runProcess))
                    this.runerList[runProcess] = true;
            }
        }
    }
}
