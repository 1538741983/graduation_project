namespace OJCMS.IDao
{
    public interface IDBSessionFactory
    {
        IDBSession GetCurrentDBSession();
    }
}
