using CMSService;

namespace WCFTest
{
    class Program
    {
        static void Main(string[] args)
        {
            IOJCMSService service=new OJCMSService();
            service.DeleteMenuById(8.ToString());
        }
    }
}
