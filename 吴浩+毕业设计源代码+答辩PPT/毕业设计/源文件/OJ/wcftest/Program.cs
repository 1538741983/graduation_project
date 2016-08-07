using System;
using System.Threading;
using wcftest.OJService;

//using wcftest.JudgeServiceTest;

namespace wcftest
{
    class Program
    {

        static void Main(string[] args)
        {
            //IProblemDOService problemService = new ProblemDOService();

            //ProblemDO problem = new ProblemDO();
            //problem.Title = "123";
            //problem.Difficulty = "1";
            //problem.Time_limit = 1;
            //problem.Memory_limit = 1;
            //problem.Source = "123";

            //problem.Input = "1";
            //problem.Sample_input = "1";
            //problem.Output = "1";
            //problem.Sample_output = "1";
            //problem.Describe = "1";


            //problem.Uploader = 1;
            //problem.Defunct = false;
            //problem.In_date = DateTime.Now;

            //IProblemDOService problemService = new ProblemDOService();
            //problemService.AddEntity(problem);

            //ProblemDO problem = problemService.LoadEntites(t => true || t.Id == 6).First();


            //ProblemDO problemDo = new ProblemDO();
            //problemDo.Title = problem.Title;
            //problemDo.Difficulty = problem.Difficulty;
            //problemDo.Time_limit = problem.Time_limit;
            //problemDo.Memory_limit = problem.Memory_limit;
            //problemDo.Source = problem.Source;
            ////problemDo
            //problemDo.Input = problem.Input;
            //problemDo.Sample_input = problem.Sample_input;
            //problemDo.Output = problem.Output;
            //problemDo.Sample_output = problem.Sample_output;
            //problemDo.Describe = problem.Describe;
            ////problemDo
            ////problemDo
            //problemDo.Uploader = problem.Uploader;
            //problemDo.Defunct = problem.Defunct;
            //problemDo.In_date = problem.In_date;

            //problem.Describe += "123";

            //problemService.UpdateEntity(problem);


            //OJService.IOJService service = new OJService.OJServiceClient();
            //var va = service.GetProblemList();

            //IJudgeService service = new JudgeServiceClient();
            //Console.WriteLine(service.Test());
            //for (int i = 2; i < 100; i++)
            //{
            //    SolutionDO solution = new SolutionDO
            //    {
            //        id = i,
            //        id_problem = 1000,
            //        language = new LanguageDO() { name = "C/C++" },
            //        sourcecode = new SourceCodeDO()
            //        {
            //            source_code =
            //                "#include<stdio.h>\n int main()\n { \nint a,b; \nscanf(\"%d%d\",&a,&b);\n printf(\"%d\\n\",a + b);\n return 0;\n }\n"
            //        }
            //    };
            //    Console.WriteLine(service.Judge(solution));
            //}


            //Console.ReadLine();

            Random random = new Random(DateTime.Now.Millisecond);

            IOJService service = new OJServiceClient();

            for (int i = 0; i < 100; i++)
            {
                string code;
                if (random.Next(0, 3) == 1)
                {
                    code =
                   "#include<stdio.h>\n int main()\n { \nint a,b; \nscanf(\"%d%d\",&a,&b);\n printf(\"%d\\n\",a + b);\n return 0;\n }\n";
                }
                else if (random.Next(0, 3) == 0)
                {
                    code =
                   "#include<stdio.h>\n int main()\n { \nint a,b; \nscanf(\"%d%d\",&a,&b);\n printf(\"%d\\n\",a + b + 1);\n return 0;\n }\n";
                }
                else
                {
                    code =
                   "#include<stdio.h>\n int main()\n { \nint a,b; \nscanf(\"%d%d\",&a,&b);\n printf(\"%d\\n\",a + b + 1);\n return 0\n \n";
                }

                Thread.Sleep(random.Next(1, 2));

                service.SubmitCode(1, "C", code);
            }
            //service.GetSolutionPageList(100, 2);
            //service.AfreshJudge();
        }
    }
}
