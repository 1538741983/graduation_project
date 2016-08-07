using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace JudgeEngine
{
    /// <summary>
    /// 日志操作
    /// author: wuhao
    /// </summary>
    public class Logger
    {
        #region 单例定义区域

        private static Logger instance;

        public static Logger Instance
        {
            get
            {
                lock (typeof(Logger))
                {
                    if (instance == null)
                        instance = new Logger();
                    return instance;
                }
            }
        }

        #endregion

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="text">日志信息</param>
        /// <param name="fname">日志文件名</param>
        public void OnLoggerMessage(string text, string fname = null)
        {
            WaitCallback callback = delegate
            {
                try
                {
                    lock (this)
                    {
                        string msg = string.Format("\r\nThreadId:{0},TickCount:{1}\r\n{2}\r\n",
                            Thread.CurrentThread.ManagedThreadId, Environment.TickCount, text);

                        string path = GetLogPath(fname);
                        File.AppendAllText(path, msg);
                    }
                }
                catch (Exception ee)
                {
                    Trace.WriteLine(ee.StackTrace);
                }
            };

            ThreadPool.QueueUserWorkItem(callback);

            Console.WriteLine(text);
        }

        /// <summary>
        /// 获取日志文件路径
        /// </summary>
        /// <param name="fname">日志文件名称</param>
        /// <returns>日志文件路径</returns>
        private string GetLogPath(string fname)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            //path = Path.GetTempPath();

            if (fname == null)
            {
                return path + "\\" + @"\judge.log";
            }

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            return path + @"\" + fname;
        }
    }
}
