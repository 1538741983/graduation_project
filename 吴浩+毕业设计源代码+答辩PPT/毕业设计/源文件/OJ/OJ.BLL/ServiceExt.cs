using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OJ.IBLL;
using OJ.Domain;

namespace OJ.BLL
{
    
    public partial class GPAssignmentDOService : BaseService<GPAssignmentDO>, IGPAssignmentDOService
    {
       public override void SetCurrentDao()
       {
           this.CurrentDao = this.DbSession.GPAssignmentDODao;
       }
    }
    
    public partial class LanguageDOService : BaseService<LanguageDO>, ILanguageDOService
    {
       public override void SetCurrentDao()
       {
           this.CurrentDao = this.DbSession.LanguageDODao;
       }
    }
    
    public partial class LoginlogDOService : BaseService<LoginlogDO>, ILoginlogDOService
    {
       public override void SetCurrentDao()
       {
           this.CurrentDao = this.DbSession.LoginlogDODao;
       }
    }
    
    public partial class PermissionDOService : BaseService<PermissionDO>, IPermissionDOService
    {
       public override void SetCurrentDao()
       {
           this.CurrentDao = this.DbSession.PermissionDODao;
       }
    }
    
    public partial class ProblemDOService : BaseService<ProblemDO>, IProblemDOService
    {
       public override void SetCurrentDao()
       {
           this.CurrentDao = this.DbSession.ProblemDODao;
       }
    }
    
    public partial class RoleDoService : BaseService<RoleDo>, IRoleDoService
    {
       public override void SetCurrentDao()
       {
           this.CurrentDao = this.DbSession.RoleDoDao;
       }
    }
    
    public partial class RPAssignmentDOService : BaseService<RPAssignmentDO>, IRPAssignmentDOService
    {
       public override void SetCurrentDao()
       {
           this.CurrentDao = this.DbSession.RPAssignmentDODao;
       }
    }
    
    public partial class SolutionDOService : BaseService<SolutionDO>, ISolutionDOService
    {
       public override void SetCurrentDao()
       {
           this.CurrentDao = this.DbSession.SolutionDODao;
       }
    }
    
    public partial class SourceCodeDOService : BaseService<SourceCodeDO>, ISourceCodeDOService
    {
       public override void SetCurrentDao()
       {
           this.CurrentDao = this.DbSession.SourceCodeDODao;
       }
    }
    
    public partial class UGAssignmentDOService : BaseService<UGAssignmentDO>, IUGAssignmentDOService
    {
       public override void SetCurrentDao()
       {
           this.CurrentDao = this.DbSession.UGAssignmentDODao;
       }
    }
    
    public partial class UPAssignmentDOService : BaseService<UPAssignmentDO>, IUPAssignmentDOService
    {
       public override void SetCurrentDao()
       {
           this.CurrentDao = this.DbSession.UPAssignmentDODao;
       }
    }
    
    public partial class URAssignmentDOService : BaseService<URAssignmentDO>, IURAssignmentDOService
    {
       public override void SetCurrentDao()
       {
           this.CurrentDao = this.DbSession.URAssignmentDODao;
       }
    }
    
    public partial class UserDOService : BaseService<UserDO>, IUserDOService
    {
       public override void SetCurrentDao()
       {
           this.CurrentDao = this.DbSession.UserDODao;
       }
    }
    
    public partial class UserGroupDOService : BaseService<UserGroupDO>, IUserGroupDOService
    {
       public override void SetCurrentDao()
       {
           this.CurrentDao = this.DbSession.UserGroupDODao;
       }
    }
}