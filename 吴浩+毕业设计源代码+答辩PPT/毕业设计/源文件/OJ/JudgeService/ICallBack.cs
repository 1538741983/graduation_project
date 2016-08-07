using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Web.Services.Description;
using OJ.Domain;

namespace JudgeService
{
    [ServiceContract]
    public interface ICallBack
    {
        [OperationContract]
        bool SubmitJudgeResult(SolutionDO solutionDo);
    }
}
