using System.Data.Objects;
using System.Runtime.Remoting.Messaging;
using OJCMS.Domain;

namespace OJCMS.Dao
{
    class ObjectContextFactory
    {
        public static ObjectContext GetCurrentObjectContext()
        {
            //从CallContext数据槽中获取EF上下文
            ObjectContext objectContext = CallContext.GetData(typeof(ObjectContextFactory).FullName) as ObjectContext;

            if (objectContext == null)
            {
                //如果CallContext数据槽中没有EF上下文，则创建EF上下文，并保存到CallContext数据槽中
                objectContext = new ModelContainer();
                CallContext.SetData(typeof(ObjectContextFactory).FullName, objectContext);
            }

            return objectContext;
        }
    }
}
