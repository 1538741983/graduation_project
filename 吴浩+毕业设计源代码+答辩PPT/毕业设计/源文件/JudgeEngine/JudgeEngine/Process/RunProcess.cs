using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace JudgeEngine.Process
{
    public class RunProcess : BaseProcess
    {
        private string input;
        //private StreamReader inputStreamReader;
        //private StreamWriter outputStreamWriter;

        public RunProcess()
        {
            this.StartInfo.RedirectStandardInput = true;
            //this.OutputDataReceived += RunProcess_OutputDataReceived;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            //this.inputStreamReader.Close();
            //this.inputStreamReader.Dispose();
            //this.outputStreamWriter.Close();
            //this.outputStreamWriter.Dispose();
        }

        private void RunProcess_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            //outputStreamWriter.Write(e.Data);
        }

        public new bool Start()
        {
            this.Refresh();
            return base.Start();
        }

        /// <summary>
        /// 设置输入流
        /// </summary>
        protected override void SetInputStream()
        {
            //string input = inputStreamReader.ReadToEnd();
            this.StandardInput.Write(input);
        }

        /// <summary>
        /// 设置运行信息
        /// </summary>
        /// <param name="programPath">程序名称</param>
        /// <param name="inputFilePath">输入文件名称</param>
        /// <param name="outputFilePath">输出文件名称</param>
        public void SetRunInfo(string programPath, string inputFilePath, string outputFilePath)
        {
            this.StartInfo.FileName = programPath;
            using (StreamReader reader = new StreamReader(inputFilePath, Encoding.UTF8))
            {
                input = reader.ReadToEnd();
            }

            //inputStreamReader = new StreamReader(inputFilePath, Encoding.UTF8);
            //outputStreamWriter = new StreamWriter(File.Create(outputFilePath), Encoding.UTF8);
            //outputStreamWriter.AutoFlush = true;
        }
    }
}
