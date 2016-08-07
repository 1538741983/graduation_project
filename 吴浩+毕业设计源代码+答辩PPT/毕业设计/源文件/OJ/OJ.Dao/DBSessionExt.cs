using OJ.IDao;

namespace OJ.Dao
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
        
        private ILanguageDODao _LanguageDODao;
        public ILanguageDODao LanguageDODao
        {
            get
            {
                if (_LanguageDODao == null)
                {
                    _LanguageDODao = new LanguageDODao();
                }
                return _LanguageDODao;
            }
            set { _LanguageDODao = value; }
        }
        
        private ILoginlogDODao _LoginlogDODao;
        public ILoginlogDODao LoginlogDODao
        {
            get
            {
                if (_LoginlogDODao == null)
                {
                    _LoginlogDODao = new LoginlogDODao();
                }
                return _LoginlogDODao;
            }
            set { _LoginlogDODao = value; }
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
        
        private IProblemDODao _ProblemDODao;
        public IProblemDODao ProblemDODao
        {
            get
            {
                if (_ProblemDODao == null)
                {
                    _ProblemDODao = new ProblemDODao();
                }
                return _ProblemDODao;
            }
            set { _ProblemDODao = value; }
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
        
        private ISolutionDODao _SolutionDODao;
        public ISolutionDODao SolutionDODao
        {
            get
            {
                if (_SolutionDODao == null)
                {
                    _SolutionDODao = new SolutionDODao();
                }
                return _SolutionDODao;
            }
            set { _SolutionDODao = value; }
        }
        
        private ISourceCodeDODao _SourceCodeDODao;
        public ISourceCodeDODao SourceCodeDODao
        {
            get
            {
                if (_SourceCodeDODao == null)
                {
                    _SourceCodeDODao = new SourceCodeDODao();
                }
                return _SourceCodeDODao;
            }
            set { _SourceCodeDODao = value; }
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