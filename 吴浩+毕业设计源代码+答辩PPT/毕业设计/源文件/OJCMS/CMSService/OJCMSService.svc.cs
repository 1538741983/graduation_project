using System;
using System.Linq;
using Newtonsoft.Json;
using OJCMS.BLL;
using OJCMS.Domain;
using OJCMS.IBLL;

namespace CMSService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“OJCMSService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 OJCMSService.svc 或 OJCMSService.svc.cs，然后开始调试。
    public class OJCMSService : IOJCMSService
    {
        public void DoWork()
        {
        }

        #region 菜单服务

        public IQueryable<MenuDO> GetMenuList()
        {
            IMenuDOService menuDoService = new MenuDOService();
            return menuDoService.LoadEntites(t => t.Ds == false);
        }

        public bool DeleteMenuById(string menuId)
        {
            IMenuDOService menuDoService = new MenuDOService();
            IQueryable<MenuDO> dataList = menuDoService.LoadEntites(t => t.Id == Convert.ToInt64(menuId));
            if (dataList != null && dataList.Count() == 1)
            {
                MenuDO data = dataList.First();
                data.Ds = true;
                if (menuDoService.UpdateEntity(data) != null)
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        public MenuDO[] GetChildrenMenuList(Int64 parentId)
        {
            IMenuDOService menuDoService = new MenuDOService();
            return menuDoService.LoadEntites(t => t.Id_perent == parentId).ToArray();
        }

        public UserDO[] GetUserDoByUserName(string userName)
        {
            IUserDOService userService = new UserDOService();
            return userService.LoadEntites(t => t.UserName == userName).ToArray();
        }

        public MenuDO GetMenuDoById(Int64 id)
        {
            IMenuDOService menuDoService = new MenuDOService();
            MenuDO[] menuDoList = menuDoService.LoadEntites(t => t.Id == id).ToArray();
            if (menuDoList.Length == 1)
                return menuDoList[0];
            return null;
        }

        public bool UpdateMenu(MenuDO menu)
        {
            IMenuDOService service = new MenuDOService();
            MenuDO result = service.UpdateEntity(menu);
            return result != null;
        }

        public bool AddMenu(MenuDO menu)
        {
            IMenuDOService service = new MenuDOService();
            MenuDO result = service.AddEntity(menu);
            return result != null;
        }

        #endregion

        public UserDO GetUserById(int userId)
        {
            IUserDOService userService = new UserDOService();
            UserDO[] result = userService.LoadEntites(t => t.Id == userId).ToArray();
            if (result.Length == 1)
                return result[0];
            return null;
        }

        public string AddUser(string userInfo)
        {
            IUserDOService userService = ServiceFinder.Find<IUserDOService>();
            JsonConvert.DeserializeObject<UserDO>(userInfo);
            UserDO newInfo = userService.AddEntity(new UserDO());
            return newInfo.ToString();
        }

        public bool AddUser(UserDO user)
        {
            IUserDOService userService = new UserDOService();
            UserDO result = userService.AddEntity(user);
            return result != null;
        }

        public bool UpdateUser(UserDO user)
        {
            IUserDOService userService = new UserDOService();
            UserDO result = userService.UpdateEntity(user);
            return result != null;
        }

        public bool DeleteUserById(int userId)
        {
            IUserDOService userService = new UserDOService();
            return userService.DelEntityByWhere(t => t.Id == userId);
        }

        //public UserPageList GetUserPage(int pageSize, int pageIndex, string queryText)
        //{
        //    UserPageList userPageList = new UserPageList();
        //    IUserDOService userService = new UserDOService();
        //    int totalCount;
        //    userPageList.DataList = userService.LoadEntites(t => t.Name.Contains(queryText), pageIndex, pageSize, out totalCount).ToArray();
        //    userPageList.RecordCount = totalCount;


        //    //string sqlString = "use OJCMS;select count(*) from [OJCMS].[dbo].[User]";
        //    //if (queryText != null)
        //    //    sqlString += " where name like '%" + queryText + "%'";
        //    //int[] result = userService.ExecuteStoreQuery<int>(sqlString);
        //    //if (result.Length != 1)
        //    //    return null;
        //    //userPageList.RecordCount = result[0];

        //    //if (queryText == null)
        //    //{
        //    //    userPageList.DataList = userService.LoadEntites(t => true).ToArray();
        //    //}
        //    //else
        //    //{
        //    //    userPageList.DataList = userService.LoadEntites(t => t.Name.Contains(queryText)).ToArray();
        //    //}

        //    return userPageList;
        //}


        #region 角色服务

        //public RolePageList GetRolePage(int pageSize, int pageIndex, string queryText)
        //{
        //    RolePageList rolePageList = new RolePageList();
        //    IRoleDoService roleDoService = new RoleDoService();
        //    int totalCount;
        //    rolePageList.DataList =
        //        roleDoService.LoadEntites(t => string.IsNullOrWhiteSpace(queryText) || t.Name.Contains(queryText), pageIndex, pageSize, out totalCount).ToArray();
        //    rolePageList.RecordCount = totalCount;

        //    return rolePageList;
        //}

        public bool AddRole(RoleDo role)
        {
            IRoleDoService roleDoService = new RoleDoService();
            return roleDoService.AddEntity(role) != null;
        }

        public bool UpdateRole(RoleDo role)
        {
            IRoleDoService roleDoService = new RoleDoService();
            return roleDoService.UpdateEntity(role) != null;
        }

        public bool DeleteRole(RoleDo role)
        {
            IRoleDoService roleDoService = new RoleDoService();
            return roleDoService.DelEntity(role);
        }

        public bool DeleteRoleById(Int64 id)
        {
            IRoleDoService roleDoService = new RoleDoService();
            return roleDoService.DelEntityByWhere(t => t.Id == id);
        }

        public RoleDo GetRoleById(long id)
        {
            IRoleDoService roleDoService = new RoleDoService();
            IQueryable<RoleDo> result = roleDoService.LoadEntites(t => t.Id == id);

            if (result != null && result.Count() == 1)
            {
                return result.First();
            }
            throw new Exception("获取的角色信息为null。");
        }

        #endregion

    }
}
