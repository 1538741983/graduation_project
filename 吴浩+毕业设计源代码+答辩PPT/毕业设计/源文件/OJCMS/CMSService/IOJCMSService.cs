using System;
using System.Linq;
using System.ServiceModel;
using OJCMS.Domain;

namespace CMSService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IOJCMSService”。
    [ServiceContract]
    public interface IOJCMSService
    {
        [OperationContract]
        void DoWork();

        [OperationContract]
        IQueryable<MenuDO> GetMenuList();

        [OperationContract]
        bool DeleteMenuById(string menuId);

        [OperationContract]
        MenuDO[] GetChildrenMenuList(Int64 parentId);

        //[OperationContract]
        //UserDO[] GetUserDoByUserName(string userName);

        [OperationContract]
        MenuDO GetMenuDoById(Int64 id);

        [OperationContract]
        bool UpdateMenu(MenuDO menu);

        [OperationContract]
        bool AddMenu(MenuDO menu);


        //[OperationContract]
        //UserDO[] GetUserDoByUserName(string userName);

        //[OperationContract]
        //UserPageList GetUserPage(int pageSize, int pageIndex, string queryText);

        //[OperationContract]
        //UserDO GetUserById(int userId);

        //[OperationContract]
        //string AddUser(string userInfo);

        //[OperationContract(Name = "AddUserDo")]
        //bool AddUser(UserDO user);

        //[OperationContract]
        //bool UpdateUser(UserDO user);

        //[OperationContract]
        //bool DeleteUserById(int userId);

        //[OperationContract]
        //RolePageList GetRolePage(int pageSize, int pageIndex, string queryText);

        //[OperationContract]
        //bool AddRole(RoleDo role);

        //[OperationContract]
        //bool UpdateRole(RoleDo role);

        //[OperationContract]
        //bool DeleteRole(RoleDo role);

        //[OperationContract]
        //bool DeleteRoleById(Int64 id);

        //[OperationContract]
        //RoleDo GetRoleById(Int64 id);
    }
}
