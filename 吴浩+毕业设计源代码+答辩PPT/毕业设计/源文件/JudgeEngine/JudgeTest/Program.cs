using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;
using Common;
using JudgeEngine.JudgeTask;
using JudgeEngine.Process;
using OJ.Domain;
using CompilerInfo = System.CodeDom.Compiler.CompilerInfo;

namespace JudgeEngine
{

    class Program
    {
        //  constants  used  to  select  the  performance  counter.   
        //private const string CategoryName = "Processor";
        //private const string CounterName = "% Processor Time";
        //private const string InstanceName = "_Total";

        static void Main(string[] args)
        {
            #region 判题系统性能测试代码

            //Random random = new Random(DateTime.Now.Millisecond);
            IJudgeTaskManager judgeTaskManager = new JudgeTaskManager();

            //Stopwatch stopwatch = new Stopwatch();
            //stopwatch.Start();
            //int ok = 0;
            //for (int i = 160; i <= 200; i++)
            //{
            //    SolutionDO solution = new SolutionDO
            //    {
            //        id = i,
            //        id_problem = 1,
            //        language = new LanguageDO() { name = "C" },
            //        sourcecode = new SourceCodeDO()
            //        {
            //            Source_code =
            //                "#include<stdio.h>\n int main()\n { \nint a,b; \nscanf(\"%d%d\",&a,&b);\n printf(\"%d\\n\",a + b);\n return 0;\n }\n"
            //        }
            //    };
            //    if (judgeTaskManager.AddTask(solution))
            //        ok++;
            //    else
            //    {
            //        int t = 1;
            //    }
            //    //Console.WriteLine(stopwatch.ElapsedMilliseconds);
            //    Logger.Instance.OnLoggerMessage(stopwatch.ElapsedMilliseconds.ToString());
            //    Thread.Sleep(random.Next(1000, 5000));
            //}
            //Logger.Instance.OnLoggerMessage(stopwatch.ElapsedMilliseconds.ToString());
            //Logger.Instance.OnLoggerMessage(String.Format("总计：{0} 成功：{1} 失败：{2}", 100, ok, 100 - ok));


            //Console.WriteLine(stopwatch.ElapsedMilliseconds);
            //Console.WriteLine("总计：{0} 成功：{1} 失败：{2}", 100, ok, 100 - ok);
            //Thread.Sleep(5000);
            //ok = 0;
            //for (int i = 0; i < 100; i++)
            //{
            //    Solution solution = new Solution
            //    {
            //        id = i + 1,
            //        id_problem = 1000,
            //        language = new Language() { name = "C/C++" },
            //        sourceCode = new SourceCode()
            //        {
            //            source_code =
            //                "#include<stdio.h>\n int main()\n { \nint a,b; \nscanf(\"%d%d\",&a,&b);\n printf(\"%d\\n\",a + b);\n return 0;\n }\n"
            //        }
            //    };
            //    if (judgeTaskManager.AddTask(solution))
            //        ok++;
            //    Console.WriteLine(stopwatch.ElapsedMilliseconds);
            //    Thread.Sleep(random.Next(0, 100));
            //}
            //Console.WriteLine(stopwatch.ElapsedMilliseconds);
            //Console.WriteLine("总计：{0} 成功：{1} 失败：{2}", 100, ok, 100 - ok);


            SolutionDO solution = new SolutionDO
                {
                    id = 1,
                    id_problem = 1,
                    language = new LanguageDO() { name = "C" },
                    sourcecode = new SourceCodeDO()
                    {
                        Source_code =
                             "#include<stdio.h>\n int main()\n { \nint a,b; \nscanf(\"%d%d\",&a,&b)\n printf(\"%d\\n\",a + b);\n return 0;\n }\n"
                    }
                };
            judgeTaskManager.AddTask(solution);


                Console.ReadLine();

            #endregion

            #region 编译器，运行器重用测试

            //Stopwatch stopwatch = new Stopwatch();
            //stopwatch.Start();

            //Process compilerProcess = new Process();
            //compilerProcess.StartInfo.WorkingDirectory = @"D:\Judge\Judge\1";
            //compilerProcess.StartInfo.FileName = @"D:\Program Files (x86)\CodeBlocks\MinGW\bin\mingw32-gcc.exe";
            //compilerProcess.StartInfo.Arguments = string.Format("{0} -o {1}", "sourceCode.c", "1.exe");
            //compilerProcess.StartInfo.UseShellExecute = false;
            //compilerProcess.StartInfo.CreateNoWindow = true;
            //compilerProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            //compilerProcess.StartInfo.RedirectStandardOutput = false;
            //compilerProcess.StartInfo.RedirectStandardError = false;
            //compilerProcess.EnableRaisingEvents = true;


            ////Process compilerProcess1 = new Process();
            ////compilerProcess1.StartInfo.WorkingDirectory = @"D:\Judge\Judge\1";
            ////compilerProcess1.StartInfo.FileName = @"D:\Program Files (x86)\CodeBlocks\MinGW\bin\mingw32-gcc.exe";
            ////compilerProcess1.StartInfo.Arguments = string.Format("{0} -o {1}", "sourceCode.c", "2.exe");
            ////compilerProcess1.StartInfo.UseShellExecute = false;
            ////compilerProcess1.StartInfo.CreateNoWindow = true;
            ////compilerProcess1.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            ////compilerProcess1.StartInfo.RedirectStandardOutput = false;
            ////compilerProcess1.StartInfo.RedirectStandardError = false;
            ////compilerProcess1.EnableRaisingEvents = true;

            ////Process compilerProcess2 = new Process();
            ////compilerProcess2.StartInfo.WorkingDirectory = @"D:\Judge\Judge\1";
            ////compilerProcess2.StartInfo.FileName = @"D:\Program Files (x86)\CodeBlocks\MinGW\bin\mingw32-gcc.exe";
            ////compilerProcess2.StartInfo.Arguments = string.Format("{0} -o {1}", "sourceCode.c", "3.exe");
            ////compilerProcess2.StartInfo.UseShellExecute = false;
            ////compilerProcess2.StartInfo.CreateNoWindow = true;
            ////compilerProcess2.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            ////compilerProcess2.StartInfo.RedirectStandardOutput = false;
            ////compilerProcess2.StartInfo.RedirectStandardError = false;
            ////compilerProcess2.EnableRaisingEvents = true;

            //Console.WriteLine(string.Format("构造时间：{0}ms", stopwatch.ElapsedMilliseconds));

            ////compilerProcess.Start();
            ////compilerProcess1.Start();
            ////compilerProcess2.Start();

            ////Console.WriteLine(string.Format("运行后时间：{0}ms", stopwatch.ElapsedMilliseconds));

            ////compilerProcess.WaitForExit();
            ////compilerProcess.WaitForExit();
            ////compilerProcess.WaitForExit();

            ////Console.WriteLine(string.Format("结束时间：{0}ms", stopwatch.ElapsedMilliseconds));

            //compilerProcess.Start();
            //Console.WriteLine(string.Format("运行后时间：{0}ms", stopwatch.ElapsedMilliseconds));
            //compilerProcess.WaitForExit();
            //Console.WriteLine(string.Format("结束时间：{0}ms", stopwatch.ElapsedMilliseconds));

            ////compilerProcess.Refresh();
            //compilerProcess.StartInfo.Arguments = string.Format("{0} -o {1}", "sourceCode.c", "2.exe");
            //compilerProcess.Start();
            //Console.WriteLine(string.Format("运行后时间：{0}ms", stopwatch.ElapsedMilliseconds));
            //compilerProcess.WaitForExit();
            //Console.WriteLine(string.Format("结束时间：{0}ms", stopwatch.ElapsedMilliseconds));

            //compilerProcess.Refresh();
            //compilerProcess.StartInfo.Arguments = string.Format("{0} -o {1}", "sourceCode.c", "3.exe");
            //compilerProcess.Start();
            //Console.WriteLine(string.Format("运行后时间：{0}ms", stopwatch.ElapsedMilliseconds));
            //compilerProcess.WaitForExit();
            //Console.WriteLine(string.Format("结束时间：{0}ms", stopwatch.ElapsedMilliseconds));

            //Console.ReadLine();

            #endregion


            //BuildlingHelper.BuildingJava();
            //C语言编译测试
            // Compiler();
            //CompilerHelper.CompilerC("code");
            //C语言运行测试
            //Run();
            //编译器路径配置测试
            //CompilerTest();
            //Console.ReadLine();
            //process process=new process();
            //process.BuildingJava();
            //JudgeManager judgeManager = new JudgeManager();
            //judgeManager.SetTask("123");

            //GetCategoryNameList();

            //            Console.ReadLine();


            // PerformanceCounter performanceCounter = new PerformanceCounter(CategoryName, CounterName, InstanceName);
            //PerformanceCounter performanceCounter = new PerformanceCounter("Memory", "Available Bytes", "");
            //PerformanceCounter performanceCounter1 = new PerformanceCounter("Memory", "Committed Bytes", "");
            //PerformanceCounter performanceCounter2 = new PerformanceCounter("Memory", "Commit Limit", "");
            //PerformanceCounter performanceCounter3 = new PerformanceCounter("Memory", "Available MBytes", "");
            //PerformanceCounter performanceCounter4 = new PerformanceCounter("Memory", "Free & Zero Page List Bytes", "");//可用
            //PerformanceCounter performanceCounter5 = new PerformanceCounter("Memory", "Modified Page List Bytes", "");
            //PerformanceCounter performanceCounter6 = new PerformanceCounter("Memory", "Free System Page Table Entries", "");

            //ServerPerformance serverPerformance = new ServerPerformance();
            //while (true)
            //{
            //    Thread.Sleep(1000);
            //Console.WriteLine((performanceCounter.NextValue() / 1048576).ToString(CultureInfo.InvariantCulture));
            //Console.WriteLine((performanceCounter1.NextValue() / 1048576).ToString(CultureInfo.InvariantCulture));
            //Console.WriteLine((performanceCounter2.NextValue() / 1048576).ToString(CultureInfo.InvariantCulture));
            //Console.WriteLine((performanceCounter3.NextValue()).ToString(CultureInfo.InvariantCulture));
            //Console.WriteLine((performanceCounter4.NextValue() / 1048576).ToString(CultureInfo.InvariantCulture));
            //Console.WriteLine((performanceCounter5.NextValue() / 1048576).ToString(CultureInfo.InvariantCulture));
            //Console.WriteLine((performanceCounter6.NextValue() / 1048576).ToString(CultureInfo.InvariantCulture));
            //Console.WriteLine("******************************");
            //Console.WriteLine(performanceCounter1.NextValue().ToString(CultureInfo.InvariantCulture));
            //    //float result = performanceCounter.NextValue();
            //    // result = serverPerformance.CPU_Utilization;
            //    Console.WriteLine(ServerPerformance.CPU_Utilization.ToString(CultureInfo.InvariantCulture));

            //Console.WriteLine(ServerPerformance.CpuUtilization.ToString(CultureInfo.InvariantCulture));

            //Console.WriteLine(ServerPerformance.MemoryUtilization.ToString(CultureInfo.InvariantCulture));



            //moc = mc2.GetInstances();
            //foreach (ManagementObject mo in moc)
            //{

            //    //可用内存
            //    if (mo["AvailableMBytes"] != null)
            //    {
            //        long xx = long.Parse(mo["AvailableMBytes"].ToString());
            //        Console.WriteLine(xx);
            //    }
            //}

            //}
        }

        private static void Run()
        {
            System.Diagnostics.Process process = System.Diagnostics.Process.Start(@"D:\个人文件夹\test\test\bin\Debug\code.exe");
            process.StartInfo.WorkingDirectory = @"D:\个人文件夹\test\test\bin\Debug";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.ErrorDialog = false;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            //process.StartInfo.UserName = "test";
            //SecureString password = new SecureString();
            //string str = "123";
            //foreach (char c in str)
            //{
            //    password.AppendChar(c);
            //}
            //process.StartInfo.Password = password;

            //process.StartInfo.Domain = "";
            process.Start();

            using (StreamReader reader = File.OpenText("input.txt"))
            {
                process.StandardInput.Write(reader.ReadToEnd());
            }


            //File.Create("output.txt");
            using (FileStream fileStream = File.Create("output.txt"))
            {
                string output = process.StandardOutput.ReadToEnd();
                Console.WriteLine(output);
                byte[] outBytes = Encoding.UTF8.GetBytes(output);
                fileStream.Write(outBytes, 0, outBytes.Length);
            }
            string strError = process.StandardError.ReadToEnd();
            if (!string.IsNullOrWhiteSpace(strError))
                Console.WriteLine("运行错误。\n" + strError);
            process.Close();
        }

        private static void CompilerTest()
        {
            //CompilerInfo compareInfo = new CompilerInfo();
            //compareInfo.Type = CompilerType.C;
            //compareInfo.Path = string.Format("Compiler\\mingw32-gcc.exe");
            //compareInfo.WorkSpacePath = @"D:\个人文件夹\test\test\bin\Debug";


            //List<CompilerInfo> compilerList = new List<CompilerInfo>();
            //compilerList.Add(compareInfo);

            //XmlDocument xd = new XmlDocument();
            //using (StringWriter sw = new StringWriter())
            //{
            //    XmlSerializer xz = new XmlSerializer(compilerList.GetType());
            //    xz.Serialize(sw, compilerList);
            //    Console.WriteLine(sw.ToString());
            //    xd.LoadXml(sw.ToString());
            //    xd.Save("1.xml");
            //}
        }

        private static void Compiler()
        {
            System.Diagnostics.Process process = System.Diagnostics.Process.Start(@"D:\Program Files (x86)\CodeBlocks\MinGW\bin\mingw32-gcc.exe", "code.c -o code.exe");
            process.StartInfo.WorkingDirectory = @"D:\个人文件夹\test\test\bin\Debug";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardInput = false;
            process.StartInfo.RedirectStandardOutput = false;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.CreateNoWindow = true;
            //process.StartInfo.UserName = "test";
            //SecureString password = new SecureString();
            //string str = "123";
            //foreach (char c in str)
            //{
            //    password.AppendChar(c);
            //}
            //process.StartInfo.Password = password;
            //process.StartInfo.Domain = "";
            process.Start();
            string strError = process.StandardError.ReadToEnd();
            if (!string.IsNullOrWhiteSpace(strError))
                Console.WriteLine("构建错误。\n" + strError);
            process.Close();
        }

        public static void GetCategoryNameList()
        {
            PerformanceCounterCategory[] myCat2;
            myCat2 = PerformanceCounterCategory.GetCategories();
            for (int i = 0; i < myCat2.Length; i++)
            {
                if (myCat2[i].CategoryName.ToString() == "Processor" || myCat2[i].CategoryName.ToString() == "Memory")
                {
                    Console.WriteLine(myCat2[i].CategoryName.ToString());
                    GetInstanceNameListANDCounterNameList(myCat2[i].CategoryName.ToString());
                    //Console.ReadLine();
                }

            }
        }

        public static void GetInstanceNameListANDCounterNameList(string CategoryName)
        {
            string[] instanceNames;
            ArrayList counters = new ArrayList();
            PerformanceCounterCategory mycat = new PerformanceCounterCategory(CategoryName);
            try
            {
                Console.WriteLine("******************************");
                instanceNames = mycat.GetInstanceNames();
                if (instanceNames.Length == 0)
                {
                    counters.AddRange(mycat.GetCounters());
                }
                else
                {
                    for (int i = 0; i < instanceNames.Length; i++)
                    {
                        counters.AddRange(mycat.GetCounters(instanceNames[i]));
                    }
                }
                Console.WriteLine("******************************");
                for (int i = 0; i < instanceNames.Length; i++)
                {
                    Console.WriteLine(instanceNames[i]);
                }
                Console.WriteLine("******************************");
                foreach (PerformanceCounter counter in counters)
                {
                    Console.WriteLine(counter.CounterName);
                }
                Console.WriteLine("******************************");
            }
            catch (Exception)
            {
                Console.WriteLine("Unable to list the counters for this category");
            }
        }

        public static void ComparerTest()
        {

            /*
             Accepted (AC) : OK! Your program is correct!

            Presentation Error (PE) : Output Format Error. Your output format is not exactly the same as the judge's output, although your answer to the problem is correct. Check your output for spaces, blank lines, etc. against the problem output specification.

            Wrong Answer (WA) : Correct solution not reached for the inputs. The inputs and outputs that we use to test the programs are not public. Some problems with special judge may not reply "Presentation Error", replaced by "Wrong Answer".
             */

            string result = "开始判题。";
            Console.WriteLine(result);

            result = "测试结果应该为：AC。";
            Console.WriteLine(result);
            standardOutput = "57";
            result = Start("57");
            Console.WriteLine("实际结果：" + result);

            result = "测试结果应该为：AC。";
            Console.WriteLine(result);
            standardOutput = "57 43\n";
            result = Start("57 43\n");
            Console.WriteLine("实际结果：" + result);


            result = "测试结果应该为：WA。";
            Console.WriteLine(result);
            standardOutput = "57";
            result = Start("55");
            Console.WriteLine("实际结果：" + result);

            result = "测试结果应该为：WA。";
            Console.WriteLine(result);
            standardOutput = "57 43";
            result = Start("55 43");
            Console.WriteLine("实际结果：" + result);

            result = "测试结果应该为：WA。";
            Console.WriteLine(result);
            standardOutput = "57 43";
            result = Start("57 43a");
            Console.WriteLine("实际结果：" + result);

            result = "测试结果应该为：PE。";
            Console.WriteLine(result);
            standardOutput = "57";
            result = Start("57\n");
            Console.WriteLine("实际结果：" + result); ;

            result = "测试结果应该为：PE。";
            Console.WriteLine(result);
            standardOutput = "57 43 ";
            result = Start("57 43");
            Console.WriteLine("实际结果：" + result);

            result = "测试结果应该为：PE。";
            Console.WriteLine(result);
            standardOutput = "57 43 ";
            result = Start("57 43\n");
            Console.WriteLine("实际结果：" + result);
        }

        private static string standardOutput;

        public static string Start(string output)
        {
            if (output == standardOutput)
                return "AC";
            return "WA";
        }
    }
}
