using OJCMS.IBLL;
using OJCMS.Domain;

namespace OJCMS.BLL
{
    
    public partial class GPAssignmentDOService : BaseService<GPAssignmentDO>, IGPAssignmentDOService
    {
       public override void SetCurrentDao()
       {
           this.CurrentDao = this.DbSession.GPAssignmentDODao;
       }
    }
    
    public partial class MenuDOService : BaseService<MenuDO>, IMenuDOService
    {
       public override void SetCurrentDao()
       {
           this.CurrentDao = this.DbSession.MenuDODao;
       }
    }
    
    public partial class PermissionAssignmentDOService : BaseService<PermissionAssignmentDO>, IPermissionAssignmentDOService
    {
       public override void SetCurrentDao()
       {
           this.CurrentDao = this.DbSession.PermissionAssignmentDODao;
       }
    }
    
    public partial class PermissionDOService : BaseService<PermissionDO>, IPermissionDOService
    {
       public override void SetCurrentDao()
       {
           this.CurrentDao = this.DbSession.PermissionDODao;
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