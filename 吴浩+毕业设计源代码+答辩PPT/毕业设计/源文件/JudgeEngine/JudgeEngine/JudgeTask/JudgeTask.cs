using System;
using System.IO;
using System.Text;
using System.Threading;
using Common;
using JudgeEngine.Process;
using OJ.Domain;

namespace JudgeEngine.JudgeTask
{
    public class ComparedEventArgs : EventArgs
    {
        public SolutionDO Solution { get; set; }
    }

    //public delegate void ComparedEventhandler(object sender,EventArgs)


    /// <summary>
    /// 判题任务
    /// author: wuhao
    /// </summary>
    public class JudgeTask : IJudgeTask
    {
        #region 变量定义区域

        //标准环境目录信息
        private string standardSpaceDirectoryPath;
        //判题环境目录信息
        private string judgeSpaceDirectoryPath;

        //标准输入文件名称
        private string standardInputFileName;
        //标准输入文件路径
        private string standardInputFilePath;

        //标准输出文件名称
        private string standardOutputFileName;
        //标准输出文件路径
        private string standardOutputFilePath;

        //程序输出文件名称
        private string judgeOutputFileName;
        //程序输出文件路径
        private string judgeOutputFilePath;

        //源代码文件名称
        private string sourceCodeFileName;
        //源代码文件路径
        private string sourceCodeFilePath;

        //可执行文件名称
        private string executableFileName;
        //可执行文件路径
        private string executableFilePath;




        //运行信息
        private SolutionDO solution;
        //编译进程
        private CompilerProcess compilerProcess;
        //运行进程
        private RunProcess runProcess;
        //比较器
        private Comparer comparer;

        #endregion

        public SolutionDO SolutionDO
        {
            get { return this.solution; }
        }


        #region 构造函数区域

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="solutionInfo">运行信息</param>
        public JudgeTask(SolutionDO solutionInfo)
        {
            this.solution = solutionInfo;

            string BaseDirectory = "D:\\Judge";
            string standardLibraryDirectory = BaseDirectory + "\\StandardLibrary";
            string judgeBaseDirectory = BaseDirectory + "\\Judge";
            sourceCodeFileName = "sourceCode.c";
            executableFileName = string.Format("{0}.exe", solution.id);
            standardInputFileName = "input.txt";
            standardOutputFileName = "output.txt";
            judgeOutputFileName = "judgeoutput.txt";

            //设置环境目录信息
            standardSpaceDirectoryPath = Path.Combine(standardLibraryDirectory, solution.id_problem.ToString());
            judgeSpaceDirectoryPath = Path.Combine(judgeBaseDirectory, solution.id.ToString());
            sourceCodeFilePath = Path.Combine(judgeSpaceDirectoryPath, sourceCodeFileName);
            executableFilePath = Path.Combine(judgeSpaceDirectoryPath, executableFileName);
            standardInputFilePath = Path.Combine(judgeSpaceDirectoryPath, standardInputFileName);
            standardOutputFilePath = Path.Combine(judgeSpaceDirectoryPath, standardOutputFileName);
            judgeOutputFilePath = Path.Combine(judgeSpaceDirectoryPath, judgeOutputFileName);
        }

        #endregion


        #region 辅助处理区域

        private bool Init()
        {
            //初始化工作环境
            bool ok = InitWorkSpace();

            if (!ok)
                return ok;

            //初始化编译器
            ok = InitCompiler();

            if (!ok)
                return ok;

            //初始化运行器
            ok = InitRuner();

            return ok;
        }



        #region 初始化

        /// <summary>
        /// 初始化工作空间
        /// </summary>
        private bool InitWorkSpace()
        {
            //从标准库中拉取标准判题环境
            if (!GetStandardSpace())
            {
                Logger.Instance.OnLoggerMessage("从标准库中拉取标准判题环境失败。");
                return false;
            }

            //构建源代码文件
            FileStream sourceCodeFileStream = File.Create(sourceCodeFilePath);
            byte[] sourceCodeBytes = Encoding.UTF8.GetBytes(solution.sourcecode.Source_code);
            sourceCodeFileStream.Write(sourceCodeBytes, 0, sourceCodeBytes.Length);
            sourceCodeFileStream.Close();


            //检查可执行文件
            if (File.Exists(executableFilePath))
                File.Delete(executableFilePath);

            //构建判题输出文件
            //File.Create(judgeOutputFilePath);

            return true;
        }

        /// <summary>
        /// 初始化编译器
        /// </summary>
        private bool InitCompiler()
        {
            //从仓库获取编译器
            compilerProcess = JudgeProcessFactory.GetCompilerProcess(this.solution.language.name);
            //compilerProcess = ProcessWarehouse.Instance.GetComoiler(this.solution.language.name);
            compilerProcess.SetWorkingDirectory(judgeSpaceDirectoryPath);
            compilerProcess.SetCompilerInfo(sourceCodeFileName, executableFileName);
            //compilerProcess.Exited += compilerProcess_Exited;
            return true;
        }

        /// <summary>
        /// 初始化运行器
        /// </summary>
        private bool InitRuner()
        {
            //runProcess = ProcessWarehouse.Instance.GetRuner();
            runProcess = JudgeProcessFactory.GetRunProcess();
            runProcess.SetWorkingDirectory(judgeSpaceDirectoryPath);
            runProcess.SetRunInfo(executableFilePath, standardInputFilePath, judgeOutputFilePath);
            //runProcess.Exited += runProcess_Exited;

            return true;
        }

        #endregion


        #region 判题流程

        /// <summary>
        /// 编译完成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void compilerProcess_Exited(object sender, EventArgs e)
        {
            compilerProcess.Exited -= compilerProcess_Exited;
            if (compilerProcess.HasErrors)
            {
                Logger.Instance.OnLoggerMessage(compilerProcess.ErrorInfo);
                OnComplete();
                compilerProcess.Close();
            }
            else
            {
                compilerProcess.Close();
                Logger.Instance.OnLoggerMessage("开始运行可执行文件");
                runProcess.Start();
            }
        }

        /// <summary>
        /// 运行完成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void runProcess_Exited(object sender, EventArgs e)
        {
            compilerProcess.Exited -= compilerProcess_Exited;
            if (runProcess.HasErrors)
            {
                Logger.Instance.OnLoggerMessage(runProcess.ErrorInfo);
                //OnComplete();
                runProcess.Close();
            }
            else
            {
                runProcess.Close();
                Logger.Instance.OnLoggerMessage("开始对比输出文件");
                Compare();
            }
        }

        /// <summary>
        /// 对比输出文件
        /// </summary>
        private void Compare()
        {

        }

        #endregion

        public event EventHandler Complete;

        /// <summary>
        /// 任务完成
        /// </summary>
        private void OnComplete()
        {
            //卸载退出事件
            compilerProcess.Exited -= compilerProcess_Exited;
            runProcess.Exited -= runProcess_Exited;
            EventHandler handler = Complete;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        #endregion

        public bool Start()
        {
            if (!Init())
            {
                CompilerError();
                return false;
            }

            // return compilerProcess.Start();
            this.solution.judgeTime = DateTime.Now;

            WaitCallback callback = delegate
            {
                bool isStart = compilerProcess.Start();
                if (!isStart)
                {
                    Logger.Instance.OnLoggerMessage("编译进程运行失败。");
                    CompilerError();
                    return;
                }
                Logger.Instance.OnLoggerMessage("编译进程运行成功。");

                bool isExit = compilerProcess.WaitForExit(5000);

                if (!isExit)
                {
                    compilerProcess.Kill();
                    CompilerError();
                    return;
                }
                compilerProcess.Dispose();

                if (compilerProcess.HasErrors)
                {
                    Logger.Instance.OnLoggerMessage(string.Format("编译出错，错误信息：{0}", compilerProcess.ErrorInfo));
                    CompilerError();
                    return;
                }

                isStart = runProcess.Start();
                if (!isStart)
                {
                    Logger.Instance.OnLoggerMessage("运行进程运行失败。");
                    return;
                }
                Logger.Instance.OnLoggerMessage("运行进程运行成功。");

                isExit = runProcess.WaitForExit(5000);

                if (!isExit)
                {
                    runProcess.Kill();
                }

                runProcess.Dispose();

                if (runProcess.HasErrors)
                {
                    Logger.Instance.OnLoggerMessage(string.Format("运行出错，错误信息：{0}", compilerProcess.ErrorInfo));
                    return;
                }

                Logger.Instance.OnLoggerMessage("对比输出文件。");

                comparer = new Comparer(standardOutputFilePath);
                string result = comparer.Start(runProcess.OutputInfo);

                Logger.Instance.OnLoggerMessage(result);

                this.solution.result = result;

                if (Compared != null)
                    Compared(this, new ComparedEventArgs { Solution = this.solution });
            };

            return ThreadPool.QueueUserWorkItem(callback);
        }

        private void CompilerError()
        {
            this.solution.result = "CompilerError";

            if (Compared != null)
                Compared(this, new ComparedEventArgs { Solution = this.solution });
        }

        public event EventHandler<ComparedEventArgs> Compared;

        public void Close()
        {
            //等待编译进程关闭
            if (!compilerProcess.HasExited)
            {
                compilerProcess.WaitForExit();
                compilerProcess.Dispose();
            }

            //等待运行进程关闭
            if (!runProcess.HasExited)
            {
                runProcess.WaitForExit();
                runProcess.Dispose();
            }

        }

        public void Dispose()
        {

        }








        /// <summary>
        /// 获取标准环境
        /// </summary>
        /// <returns></returns>
        private bool GetStandardSpace()
        {
            if (Directory.Exists(standardSpaceDirectoryPath))
            {
                //如果检查到标准环境，则进行copy
                if (Directory.Exists(judgeSpaceDirectoryPath))
                    Directory.Delete(judgeSpaceDirectoryPath, true);

                Directory.CreateDirectory(judgeSpaceDirectoryPath);
                //judgeSpaceDirectoryInfo.Create();
                if (!Directory.Exists(judgeSpaceDirectoryPath))
                {
                    Logger.Instance.OnLoggerMessage("创建工作路径失败。");
                    return false;
                }

                CopyDirectory(standardSpaceDirectoryPath, judgeSpaceDirectoryPath);
                return true;
            }
            return false;
        }

        /// <summary>
        /// 复制路径下所有文件和路径
        /// </summary>
        /// <param name="sourceDirPath">要复制的路径</param>
        /// <param name="destDirPath"></param>
        private void CopyDirectory(string sourceDirPath, string destDirPath)
        {

            string[] childrenDirectories = Directory.GetDirectories(sourceDirPath);
            foreach (string childrenDirectory in childrenDirectories)
            {
                if (Directory.Exists(Path.Combine(destDirPath, childrenDirectory)))
                    Directory.Delete(Path.Combine(destDirPath, childrenDirectory), true);
                Directory.CreateDirectory(Path.Combine(destDirPath, childrenDirectory));
                CopyDirectory(Path.Combine(sourceDirPath, childrenDirectory),
                    Path.Combine(destDirPath, childrenDirectory));

            }

            foreach (string fileName in Directory.GetFiles(sourceDirPath))
            {
                File.Copy(fileName, Path.Combine(destDirPath, Path.GetFileName(fileName) ?? ""), true);
            }
        }


    }
}
