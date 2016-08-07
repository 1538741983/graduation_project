namespace OJ.IDao
{
	public partial interface IDBSession
	{
    	IGPAssignmentDODao GPAssignmentDODao { get; set; }
    	ILanguageDODao LanguageDODao { get; set; }
    	ILoginlogDODao LoginlogDODao { get; set; }
    	IPermissionDODao PermissionDODao { get; set; }
    	IProblemDODao ProblemDODao { get; set; }
    	IRoleDoDao RoleDoDao { get; set; }
    	IRPAssignmentDODao RPAssignmentDODao { get; set; }
    	ISolutionDODao SolutionDODao { get; set; }
    	ISourceCodeDODao SourceCodeDODao { get; set; }
    	IUGAssignmentDODao UGAssignmentDODao { get; set; }
    	IUPAssignmentDODao UPAssignmentDODao { get; set; }
    	IURAssignmentDODao URAssignmentDODao { get; set; }
    	IUserDODao UserDODao { get; set; }
    	IUserGroupDODao UserGroupDODao { get; set; }
    }
}