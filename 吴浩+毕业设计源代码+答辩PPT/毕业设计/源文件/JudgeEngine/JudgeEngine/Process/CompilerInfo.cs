namespace JudgeEngine.Process
{
    /// <summary>
    /// 编译器信息
    /// </summary>
    class CompilerInfo
    {
        public string Path { get; set; }
        public string ArgumentsFormat { get; set; }
        public CompilerType Type { get; set; }
    }

    /// <summary>
    /// 编译器类型
    /// </summary>
    public enum CompilerType
    {
        C = 0
    }
}
