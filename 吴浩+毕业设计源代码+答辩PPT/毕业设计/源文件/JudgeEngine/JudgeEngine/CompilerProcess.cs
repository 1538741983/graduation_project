using System;

namespace JudgeEngine
{
    public class CompilerProcess : BaseProcess, ICompilerProcess
    {

        private string argumentsFormat;

        /// <summary>
        /// 编译进程构造函数
        /// </summary>
        /// <param name="workingDirectory">工作目录</param>
        /// <param name="compilerPath">编译器路径</param>
        /// <param name="argumentsFormat">参数格式化</param>
        /// <param name="socrceCodeFileName">源代码文件名称</param>
        /// <param name="executableFileName">可执行文件名称</param>
        public CompilerProcess(string workingDirectory, string compilerPath, string argumentsFormat, string socrceCodeFileName, string executableFileName)
        {
            this.argumentsFormat = argumentsFormat;
            this.StartInfo.WorkingDirectory = workingDirectory;
            this.StartInfo.FileName = compilerPath;
            this.StartInfo.Arguments = string.Format(argumentsFormat, socrceCodeFileName, executableFileName);
        }

        /// <summary>
        /// 编译进程构造函数
        /// </summary>
        /// <param name="compilerPath">编译器路径</param>
        /// <param name="argumentsFormat">参数格式化</param>
        public CompilerProcess(string compilerPath, string argumentsFormat)
        {
            this.argumentsFormat = argumentsFormat;
            this.StartInfo.FileName = compilerPath;
        }

        public void SetCompilerInfo(string sourceCodeFileName, string executableFileName)
        {
            this.StartInfo.Arguments = String.Format(argumentsFormat, sourceCodeFileName, executableFileName);
        }
    }
}
