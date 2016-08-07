namespace OJCMS.IDao
{
    public partial interface IDBSession
    {
        int SaveChange();//用于在业务逻辑层对提交进行管理
    }   
}
