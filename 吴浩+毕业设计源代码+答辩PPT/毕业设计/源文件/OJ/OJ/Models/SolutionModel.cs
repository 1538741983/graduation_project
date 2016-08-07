using OJ.OJService;

namespace OJ.Models
{
    public class SolutionModel
    {
        private IOJService service;

        public SolutionModel()
        {
            service = new OJServiceClient();
        }

        public SolutionPageList GetSolutionPageList(int pageSize, int currentPage, string seachText)
        {
            if (currentPage < 0)
                return new SolutionPageList();
            return service.GetSolutionPageList(pageSize, currentPage);
        }
    }
}