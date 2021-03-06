﻿using System.Runtime.Remoting.Messaging;
using OJCMS.IDao;

namespace OJCMS.Dao
{
    public class DBSessionFactory : IDBSessionFactory
    {
        public IDBSession GetCurrentDBSession()
        {
            IDBSession dbSession = CallContext.GetData(typeof(DBSessionFactory).FullName) as DBSession;
            if (dbSession == null)
            {
                dbSession = new DBSession();
                CallContext.SetData(typeof(DBSessionFactory).FullName, dbSession);
            }
            return dbSession;
        }
    }
}
