using Common;

namespace JudgeEngine.Process
{
    /// <summary>
    /// 判题进程工厂
    /// </summary>
    /// <remarks>生产JudgeProcess</remarks>
    public class JudgeProcessFactory
    {
        /// <summary>
        /// 生产编译进程
        /// </summary>
        /// <param name="language">语言</param>
        /// <returns>编译进程</returns>
        public static CompilerProcess GetCompilerProcess(string language)
        {
            CompilerInfo compilerInfo = GetCompilerInfo(language);
            CompilerProcess compilerProcess = new CompilerProcess(compilerInfo.Path, compilerInfo.ArgumentsFormat);
            Logger.Instance.OnLoggerMessage("编译器生产成功");
            return compilerProcess;
        }

        /// <summary>
        /// 生产运行进程
        /// </summary>
        /// <returns>运行进程</returns>
        internal static RunProcess GetRunProcess()
        {
            RunProcess runProcess = new RunProcess();
            Logger.Instance.OnLoggerMessage("运行器生产成功");
            return runProcess;
        }

        /// <summary>
        /// 获取编译器信息
        /// </summary>
        /// <param name="language">语言</param>
        /// <returns>编译器信息</returns>
        private static CompilerInfo GetCompilerInfo(string language)
        {
            if (language == "C")
            {
                CompilerInfo compilerInfo = new CompilerInfo
                {
                    Type = CompilerType.C,
                    Path = @"D:\Program Files (x86)\CodeBlocks\MinGW\bin\mingw32-gcc.exe",
                    ArgumentsFormat = "{0} -o {1}"
                };
                return compilerInfo;
            }
            return null;
        }
    }
}
