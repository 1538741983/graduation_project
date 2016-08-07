namespace OJ.IDao
{
    public interface IDBSessionFactory
    {
        IDBSession GetCurrentDBSession();
    }
}
