using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;

namespace OJ.Dao
{
    public class BaseDao<T> where T : class
    {
        ObjectContext objectContext = ObjectContextFactory.GetCurrentObjectContext() as ObjectContext;//获取EF上下文

        /// <summary>
        /// 加载实体集合
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public virtual IQueryable<T> LoadEntites(Func<T, bool> whereLambda)
        {
            return objectContext.CreateObjectSet<T>().Where<T>(whereLambda).AsQueryable<T>();
        }

        /// <summary>
        /// 分页加载数据
        /// </summary>
        /// <param name="whereLambda">过滤条件</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="totalCount">总记录数</param>
        /// <returns></returns>
        public virtual IQueryable<T> LoadEntites(Func<T, bool> whereLambda, int pageIndex, int pageSize, out int totalCount, Func<IEnumerable<T>, IEnumerable<T>> orderFunc = null)
        {
            var tmp = objectContext.CreateObjectSet<T>().Where<T>(whereLambda);
            totalCount = tmp.Count();

            if (orderFunc != null)
                tmp = orderFunc(tmp);

            return tmp.Skip<T>(pageSize * (pageIndex - 1))//跳过行数，最终生成的sql语句是Top(n)
                      .Take<T>(pageSize) //返回指定数量的行
                      .AsQueryable<T>();
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>返回更新后的实体</returns>
        public virtual T AddEntity(T entity)
        {
            objectContext.CreateObjectSet<T>().AddObject(entity);
            objectContext.SaveChanges();
            return entity;
        }

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>返回更新后的实体</returns>
        public virtual T UpdateEntity(T entity)
        {
            if (!IsAttached(entity))
                objectContext.CreateObjectSet<T>().Attach(entity);
            objectContext.ObjectStateManager.ChangeObjectState(entity, System.Data.EntityState.Modified);//将附加的对象状态更改为修改
            objectContext.SaveChanges();
            return entity;
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual bool DelEntity(T entity)
        {
            if (!IsAttached(entity))
                objectContext.CreateObjectSet<T>().Attach(entity);
            objectContext.ObjectStateManager.ChangeObjectState(entity, System.Data.EntityState.Deleted);//将附加的实体状态更改为删除
            if (objectContext.SaveChanges() > 0)
            {
                return true;//删除成功
            }
            else
            {
                return false;//删除失败
            }
        }

        /// <summary>
        /// 根据条件删除对象
        /// </summary>
        /// <param name="whereLambda">条件</param>
        /// <returns></returns>
        public virtual bool DelEntityByWhere(Func<T, bool> whereLambda)
        {
            var tmp = objectContext.CreateObjectSet<T>().Where<T>(whereLambda);//根据条件从数据库中获取对象集合
            foreach (var entity in tmp)
            {
                objectContext.CreateObjectSet<T>().DeleteObject(entity);//标记对象为删除状态删除
            }
            if (objectContext.SaveChanges() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public ObjectContext GetObjectContext()
        {
            return this.objectContext;
        }

        /// <summary>
        /// 判断实体状态是否是Attached
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        private bool IsAttached(T entity)
        {
            if (entity is EntityObject)
            {
                EntityObject entityObject = entity as EntityObject;
                ObjectStateEntry entry = null;
                if (objectContext.ObjectStateManager.TryGetObjectStateEntry(entityObject.EntityKey, out entry))
                {
                    if (entry.State != EntityState.Detached)
                    {
                        return true;
                    }
                    return false;
                }
            }
            return false;
        }
    }
}
