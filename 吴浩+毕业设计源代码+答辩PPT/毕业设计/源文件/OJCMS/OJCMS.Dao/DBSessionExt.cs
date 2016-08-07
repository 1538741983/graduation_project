using OJCMS.IDao;

namespace OJCMS.Dao
{
  public partial class DBSession : IDBSession
  {
        
        private IGPAssignmentDODao _GPAssignmentDODao;
        public IGPAssignmentDODao GPAssignmentDODao
        {
            get
            {
                if (_GPAssignmentDODao == null)
                {
                    _GPAssignmentDODao = new GPAssignmentDODao();
                }
                return _GPAssignmentDODao;
            }
            set { _GPAssignmentDODao = value; }
        }
        
        private IMenuDODao _MenuDODao;
        public IMenuDODao MenuDODao
        {
            get
            {
                if (_MenuDODao == null)
                {
                    _MenuDODao = new MenuDODao();
                }
                return _MenuDODao;
            }
            set { _MenuDODao = value; }
        }
        
        private IPermissionAssignmentDODao _PermissionAssignmentDODao;
        public IPermissionAssignmentDODao PermissionAssignmentDODao
        {
            get
            {
                if (_PermissionAssignmentDODao == null)
                {
                    _PermissionAssignmentDODao = new PermissionAssignmentDODao();
                }
                return _PermissionAssignmentDODao;
            }
            set { _PermissionAssignmentDODao = value; }
        }
        
        private IPermissionDODao _PermissionDODao;
        public IPermissionDODao PermissionDODao
        {
            get
            {
                if (_PermissionDODao == null)
                {
                    _PermissionDODao = new PermissionDODao();
                }
                return _PermissionDODao;
            }
            set { _PermissionDODao = value; }
        }
        
        private IRoleDoDao _RoleDoDao;
        public IRoleDoDao RoleDoDao
        {
            get
            {
                if (_RoleDoDao == null)
                {
                    _RoleDoDao = new RoleDoDao();
                }
                return _RoleDoDao;
            }
            set { _RoleDoDao = value; }
        }
        
        private IRPAssignmentDODao _RPAssignmentDODao;
        public IRPAssignmentDODao RPAssignmentDODao
        {
            get
            {
                if (_RPAssignmentDODao == null)
                {
                    _RPAssignmentDODao = new RPAssignmentDODao();
                }
                return _RPAssignmentDODao;
            }
            set { _RPAssignmentDODao = value; }
        }
        
        private IUGAssignmentDODao _UGAssignmentDODao;
        public IUGAssignmentDODao UGAssignmentDODao
        {
            get
            {
                if (_UGAssignmentDODao == null)
                {
                    _UGAssignmentDODao = new UGAssignmentDODao();
                }
                return _UGAssignmentDODao;
            }
            set { _UGAssignmentDODao = value; }
        }
        
        private IUPAssignmentDODao _UPAssignmentDODao;
        public IUPAssignmentDODao UPAssignmentDODao
        {
            get
            {
                if (_UPAssignmentDODao == null)
                {
                    _UPAssignmentDODao = new UPAssignmentDODao();
                }
                return _UPAssignmentDODao;
            }
            set { _UPAssignmentDODao = value; }
        }
        
        private IURAssignmentDODao _URAssignmentDODao;
        public IURAssignmentDODao URAssignmentDODao
        {
            get
            {
                if (_URAssignmentDODao == null)
                {
                    _URAssignmentDODao = new URAssignmentDODao();
                }
                return _URAssignmentDODao;
            }
            set { _URAssignmentDODao = value; }
        }
        
        private IUserDODao _UserDODao;
        public IUserDODao UserDODao
        {
            get
            {
                if (_UserDODao == null)
                {
                    _UserDODao = new UserDODao();
                }
                return _UserDODao;
            }
            set { _UserDODao = value; }
        }
        
        private IUserGroupDODao _UserGroupDODao;
        public IUserGroupDODao UserGroupDODao
        {
            get
            {
                if (_UserGroupDODao == null)
                {
                    _UserGroupDODao = new UserGroupDODao();
                }
                return _UserGroupDODao;
            }
            set { _UserGroupDODao = value; }
        }
     }
}