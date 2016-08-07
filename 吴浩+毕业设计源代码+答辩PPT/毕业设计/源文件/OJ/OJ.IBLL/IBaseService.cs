using System;
using System.Collections.Generic;
using System.Linq;

namespace OJ.IBLL
{
    public interface IBaseService<T> where T : class
    {
        //根据条件获取实体对象集合
        IQueryable<T> LoadEntites(Func<T, bool> whereLambda);

        //根据条件获取实体对象集合分页
        IQueryable<T> LoadEntites(Func<T, bool> whereLambda, int pageIndex, int pageSize, out int totalCount, Func<IEnumerable<T>, IEnumerable<T>> orderFunc = null);

        //增加
        T AddEntity(T entity);

        //更新
        T UpdateEntity(T entity);

        //删除
        bool DelEntity(T entity);

        //根据条件删除
        bool DelEntityByWhere(Func<T, bool> whereLambda);

        T[] ExecuteStoreQuery(string commandText, params object[] parameters);
    }
}
