using System;
using System.Diagnostics;
using System.Text;

namespace JudgeEngine
{
    /// <summary>
    /// 基础进程
    /// quthor: wuhao
    /// </summary>
    public class BaseProcess : System.Diagnostics.Process, IBaseProcess
    {
        #region 变量定义区域

        private StringBuilder outputStringInfo;

        private StringBuilder errorStringInfo;

        private bool hasOutput;
        private bool hasErrors;

        #endregion


        #region 公共属性区域

        public bool HasErrors
        {
            get { return this.hasErrors; }
        }

        public string ErrorInfo
        {
            get { return this.errorStringInfo.ToString(); }
        }

        #endregion


        #region 构造函数区域

        public BaseProcess()
        {
            outputStringInfo = new StringBuilder();
            errorStringInfo = new StringBuilder();
            this.StartInfo.UseShellExecute = false;
            this.StartInfo.CreateNoWindow = true;
            this.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            this.StartInfo.RedirectStandardOutput = true;
            this.StartInfo.RedirectStandardError = true;
            this.EnableRaisingEvents = true;
            this.OutputDataReceived += BaseProcess_OutputDataReceived;
            this.ErrorDataReceived += BaseProcess_ErrorDataReceived;
            this.Exited += OnExited;
        }

        #endregion


        #region 接口实现区域

        public new bool Start()
        {
            //base.Refresh();
            base.Start();
            this.
            SetInputStream();
            try
            {
                this.BeginOutputReadLine();
                this.BeginErrorReadLine();
            }
            catch (Exception)
            {
                // ignored
            }

            this.WaitForExit();
            this.CancelOutputRead();
            this.CancelErrorRead();
            return true;
        }

        protected virtual void SetInputStream()
        {

        }

        protected virtual void OnExited(object sender, EventArgs e)
        {

        }

        public void SetWorkingDirectory(string workingDirectory)
        {
            this.StartInfo.WorkingDirectory = workingDirectory;
        }

        #endregion


        #region 内部事件区域

        private void BaseProcess_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data == null)
                return;
            hasErrors = true;
            this.errorStringInfo.Append(e.Data);
        }

        private void BaseProcess_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data == null)
                return;
            hasOutput = true;
            outputStringInfo.Append(e.Data);
        }

        #endregion

    }

    /// <summary>
    /// 基础进程接口
    /// author: 吴浩
    /// </summary>
    public interface IBaseProcess : IDisposable
    {
        /// <summary>
        /// 开始运行进程
        /// </summary>
        /// <returns>是否成功</returns>
        bool Start();
        /// <summary>
        /// 进程退出时触发
        /// </summary>
        event EventHandler Exited;
        /// <summary>
        /// 进程是否有运行错误信息
        /// </summary>
        bool HasErrors { get; }
        /// <summary>
        /// 进程的运行错误信息
        /// </summary>
        string ErrorInfo { get; }
        /// <summary>
        /// 无限制的等待进程退出
        /// </summary>
        void WaitForExit();

        bool HasExited { get; }

        void Refresh();

        /// <summary>
        /// 设置工作目录
        /// </summary>
        /// <param name="workingDirectory">工作目录</param>
        void SetWorkingDirectory(string workingDirectory);
    }
}
