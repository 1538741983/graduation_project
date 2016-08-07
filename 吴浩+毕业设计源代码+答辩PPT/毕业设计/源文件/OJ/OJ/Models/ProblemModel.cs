using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using OJ.OJService;

namespace OJ.Models
{
    public class ProblemModel
    {
        private IOJService ojService;

        public ProblemModel()
        {
            ojService = new OJServiceClient();
        }

        public ProblemDO GetProblem(long id)
        {
            return ojService.GetProblemById(id);
        }

        public void SubmitCode(Int64 problem, string language, string sourceCode)
        {
            try
            {
                this.ojService.SubmitCode(problem, language, sourceCode);
            }
            catch (UpdateException e)
            {
                string str = e.InnerException.Message;
            }
        }

        public ProblemPageList GetProblemPageList(int pageSize, int currentPage, string seachText)
        {
            if (currentPage < 0)
                return new ProblemPageList();
            return this.ojService.GetProblemPageList(pageSize, currentPage, seachText);
        }
    }
}