namespace CMSService
{
    /// <summary>
    /// 判题服务接口
    /// author: wuhao
    /// </summary>
    public interface IJudgeService
    {
        /// <summary>
        /// 重启判题服务
        /// </summary>
        void ReStart();

        /// <summary>
        /// 根据题目ID进行判题
        /// </summary>
        /// <param name="problemId">题目ID</param>
        /// <returns>是否成功建立判题线程</returns>
        bool JudgeById(string problemId);

        /// <summary>
        /// 根据题目信息进行判题
        /// </summary>
        /// <param name="problemInfo">题目信息
        /// (包括所需要的所有信息，压缩方式：1.Json )</param>
        /// <returns>是否成功建立判题线程</returns>
        bool Judge(string problemInfo);

        /// <summary>
        /// 获取判题服务状态信息
        /// （当前判题数量，运行号，运行状态，运行方式及其他）
        /// </summary>
        /// <returns>判题服务当前状态信息（Json）</returns>
        string GetServiceStateInfo();

        /// <summary>
        /// 获取服务主机的负载信息（次要）
        /// （包括CPU使用率，内存使用率及其他）
        /// </summary>
        /// <returns>服务主机的负载信息（Json）</returns>
        string GetServiceHostWorkLoadInfo();
    }
}
