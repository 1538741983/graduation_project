using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using FineUI;
using OJCMS.APPCode;
using OJCMS.OJCMSService;

namespace OJCMS.Menu
{
    public partial class MenuManager : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            // 每页记录数
            Grid1.PageSize = 60;
            BindGrid();
            // 默认选中第一个角色
            Grid1.SelectedRowIndex = 0;
        }

        private void BindGrid()
        {
            DataTable dt = new DataTable();
            List<MenuModel> menulist = GetMenuModels();

            Grid1.DataSource = menulist;
            Grid1.DataBind();
            Grid1.SelectedRowIndex = 0;
        }

        protected void Window1_Close(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            string parentId = Grid1.DataKeys[Grid1.SelectedRowIndex][0].ToString();
            string parentCode = Grid1.DataKeys[Grid1.SelectedRowIndex][1].ToString();
            if (parentCode.Length == 2)
            {
                PageContext.RegisterStartupScript(WindowDialog.GetShowReference(string.Format("~/Menu/FunctionInfo.aspx?action=New&id={0}", parentId), "添加菜单功能"));
            }
            else
            {
                Alert.ShowInTop("请正确选择节点！");
            }
        }
        protected void btnNewMenu_Click(object sender, EventArgs e)
        {
            CommString.FunctionID = Grid1.DataKeys[Grid1.SelectedRowIndex][0].ToString();
            //if (CommString.FunctionID.Trim().Length < 3)
            //{
            PageContext.RegisterStartupScript(WindowDialog.GetShowReference("~/Menu/FunctionMenuNew.aspx", "添加菜单"));
            //}
            //else
            //{
            //    Alert.ShowInTop("请正确选择节点！");
            //}
        }
        public List<MenuModel> GetMenuModels()
        {
            IOJCMSService ojcmsService = new OJCMSServiceClient();
            List<MenuDO> menuList = ojcmsService.GetMenuList().ToList();
            menuList.Sort((t1, t2) => String.Compare(t1.Code, t2.Code, StringComparison.Ordinal));

            List<MenuModel> Menus = new List<MenuModel>();
            ResolveMenuCollection(menuList, 0, 0, Menus);

            return Menus;
        }

        private int ResolveMenuCollection(List<MenuDO> dt, Int64 parentId, int level, List<MenuModel> newMenus)
        {
            IEnumerable<MenuDO> l = parentId == 0 ? dt.Where(t => dt.All(y => y.Id != t.Id_perent)) : dt.Where(t => t.Id_perent == parentId);

            int count = 0;

            foreach (MenuDO menuDo in l)
            {
                count++;

                MenuModel my = new MenuModel();
                newMenus.Add(my);
                my.Id = menuDo.Id;
                my.Code = menuDo.Code;
                my.Name = menuDo.Name;
                my.ParentId = menuDo.Id_perent;
                my.TreeLevel = level;
                my.MicoHelp = string.Empty;
                my.NavigateUrl = menuDo.NavigateUrl;
                my.Para = string.Empty;
                my.Num = menuDo.Num ?? 0;

                level++;
                int childCount = ResolveMenuCollection(dt, menuDo.Id, level, newMenus);
                if (childCount == 0)
                {
                    my.IsTreeLeaf = true;
                }
                level--;
            }

            return count;
        }

        protected void Grid1_RowCommand(object sender, GridCommandEventArgs e)
        {
            string funcid = Grid1.DataKeys[Grid1.SelectedRowIndex][0].ToString();

            if (e.CommandName == "Delete")
            {
                IOJCMSService service = new OJCMSServiceClient();
                if (service.DeleteMenuById(funcid))
                {
                    LoadData();
                    Alert.ShowInTop("删除成功");
                }
                else
                {
                    Alert.ShowInTop("删除失败");
                }
                //T_FunctionMenu functionMenu = new T_FunctionMenu();
                //functionMenu.Funcid = funcid;
                //if (funcid.Trim().Length > 3)
                //{
                //    functionMenu.DelMenu();
                //    BindGrid();
                //}
                //else
                //{
                //    if (funcid.Trim().Length == 1)
                //    {
                //        Alert.ShowInTop("跟节点不能删除");
                //    }
                //    else
                //    {
                //        functionMenu.DelMenu();
                //        functionMenu.DelParentID();
                //        BindGrid();
                //    }
                //}
            }
        }

        protected void btnEdit_OnClick(object sender, EventArgs e)
        {
            string id = Grid1.DataKeys[Grid1.SelectedRowIndex][0].ToString();
            string parentCode = Grid1.DataKeys[Grid1.SelectedRowIndex][1].ToString();
            if (parentCode.Length >= 4)
            {
                PageContext.RegisterStartupScript(WindowDialog.GetShowReference(string.Format("~/Menu/FunctionInfo.aspx?action=Edit&id={0}", id), "修改功能"));
            }
            else
            {
                Alert.ShowInTop("请正确选择节点！");
            }
        }
    }
}