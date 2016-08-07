namespace OJ.BLL
{
    public static class ServiceFinder
    {
        public static T Find<T>() where T : class
        {
            return new object() as T;
        }
    }
}
