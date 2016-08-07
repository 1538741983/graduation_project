namespace OJCMS.IDao
{
	public partial interface IDBSession
	{
    	IGPAssignmentDODao GPAssignmentDODao { get; set; }
    	IMenuDODao MenuDODao { get; set; }
    	IPermissionAssignmentDODao PermissionAssignmentDODao { get; set; }
    	IPermissionDODao PermissionDODao { get; set; }
    	IRoleDoDao RoleDoDao { get; set; }
    	IRPAssignmentDODao RPAssignmentDODao { get; set; }
    	IUGAssignmentDODao UGAssignmentDODao { get; set; }
    	IUPAssignmentDODao UPAssignmentDODao { get; set; }
    	IURAssignmentDODao URAssignmentDODao { get; set; }
    	IUserDODao UserDODao { get; set; }
    	IUserGroupDODao UserGroupDODao { get; set; }
    }
}