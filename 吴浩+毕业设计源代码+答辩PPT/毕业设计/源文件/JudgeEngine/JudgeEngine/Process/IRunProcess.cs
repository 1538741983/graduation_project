namespace JudgeEngine.Process
{
    /// <summary>
    /// 判题进程接口
    /// </summary>
    public interface IRunProcess : IBaseProcess
    {
        ///// <summary>
        ///// 设置输入文件路径
        ///// </summary>
        ///// <param name="filePath">文件路径</param>
        ///// <returns>是否设置成功</returns>
        //bool SetInputFile(string filePath);
        ///// <summary>
        ///// 设置输出文件路径
        ///// </summary>
        ///// <param name="filePath">文件路径</param>
        ///// <returns>是否设置成功</returns>
        //bool SetOutputFile(string filePath);
        ///// <summary>
        ///// 设置错误输出文件路径
        ///// </summary>
        ///// <param name="filePath">文件路径</param>
        ///// <returns>是否设置成功</returns>
        //bool SetErrorFile(string filePath);
        ///// <summary>
        ///// 获取输出信息
        ///// </summary>
        ///// <returns>输出信息</returns>
        //string GetOutputInfo();
        ///// <summary>
        ///// 获取错误信息
        ///// </summary>
        ///// <returns>错误信息</returns>
        //string GetErrorInfo();

        ///// <summary>
        ///// 创建编译线程
        ///// </summary>
        ///// <returns>是否成功</returns>
        //bool CreateCompilerProcess();

        ///// <summary>
        ///// 创建运行线程
        ///// </summary>
        ///// <returns>是否成功</returns>
        //bool CreateRunProcess();
        ///// <summary>
        ///// 获取判题线程状态
        ///// </summary>
        ///// <returns></returns>
        //JudgeProcessStatus Status { get; }

        /// <summary>
        /// 设置运行信息
        /// </summary>
        /// <param name="programName">程序名称</param>
        /// <param name="inputFileName">输入文件名称</param>
        /// <param name="outputFileName">输出文件名称</param>
        void SetRunInfo(string programName, string inputFileName,
            string outputFileName);
    }
}
