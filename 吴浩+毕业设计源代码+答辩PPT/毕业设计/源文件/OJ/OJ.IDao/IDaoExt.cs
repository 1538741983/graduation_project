using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OJ.Domain;//引用Domain的命名空间

namespace OJ.IDao //实体类接口所在的命名空间
{
    
    public interface IGPAssignmentDODao:IBaseDao<GPAssignmentDO> //生成实体对象接口
    {
    }
    
    public interface ILanguageDODao:IBaseDao<LanguageDO> //生成实体对象接口
    {
    }
    
    public interface ILoginlogDODao:IBaseDao<LoginlogDO> //生成实体对象接口
    {
    }
    
    public interface IPermissionDODao:IBaseDao<PermissionDO> //生成实体对象接口
    {
    }
    
    public interface IProblemDODao:IBaseDao<ProblemDO> //生成实体对象接口
    {
    }
    
    public interface IRoleDoDao:IBaseDao<RoleDo> //生成实体对象接口
    {
    }
    
    public interface IRPAssignmentDODao:IBaseDao<RPAssignmentDO> //生成实体对象接口
    {
    }
    
    public interface ISolutionDODao:IBaseDao<SolutionDO> //生成实体对象接口
    {
    }
    
    public interface ISourceCodeDODao:IBaseDao<SourceCodeDO> //生成实体对象接口
    {
    }
    
    public interface IUGAssignmentDODao:IBaseDao<UGAssignmentDO> //生成实体对象接口
    {
    }
    
    public interface IUPAssignmentDODao:IBaseDao<UPAssignmentDO> //生成实体对象接口
    {
    }
    
    public interface IURAssignmentDODao:IBaseDao<URAssignmentDO> //生成实体对象接口
    {
    }
    
    public interface IUserDODao:IBaseDao<UserDO> //生成实体对象接口
    {
    }
    
    public interface IUserGroupDODao:IBaseDao<UserGroupDO> //生成实体对象接口
    {
    }
}