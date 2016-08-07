namespace JudgeEngine
{
    public interface ICompilerProcess : IBaseProcess
    {
        /// <summary>
        /// 设置编译信息
        /// </summary>
        /// <param name="sourceCodeFileName">源代码文件名称</param>
        /// <param name="executableFileName">可执行文件名称</param>
        void SetCompilerInfo(string sourceCodeFileName, string executableFileName);
    }
}
