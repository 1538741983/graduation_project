using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;
using OJCMS.APPCode;
using OJCMS.OJCMSService;

namespace OJCMS.Permission
{
    public partial class PermissionManager : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnNew.OnClientClick = WindowDialog.GetShowReference("~/Permission/PermissionInfo.aspx?action=New", "新增权限");
                LoadGridData();
            }
        }

        private PermissionPageList LoadData()
        {
            int pageIndex = Grid1.PageIndex;
            int pageSize = Grid1.PageSize;
            string searchText = ttbSearchMessage.Text.Trim();
            IOJCMSService service = new OJCMSServiceClient();
            return service.GetPermissionPage(pageSize, pageIndex, searchText);
        }

        private void BindGrid(PermissionPageList permissionPageList)
        {
            //获取总条目
            Grid1.RecordCount = permissionPageList.RecordCount;

            PermissionDo[] roleList = permissionPageList.DataList;
            //获取分页数据
            //DataTable paged = GetDataTablePage();

            //绑定到Grid1
            Grid1.DataSource = roleList;
            Grid1.DataBind();
        }

        protected void ttbSearchMessage_Trigger2Click(object sender, EventArgs e)
        {
            ttbSearchMessage.ShowTrigger1 = true;
            if (Grid1.PageCount > 0)
            {
                Grid1.PageIndex = 0;
            }
            LoadGridData();
        }

        protected void ttbSearchMessage_Trigger1Click(object sender, EventArgs e)
        {
            ttbSearchMessage.ShowTrigger1 = false;
            ttbSearchMessage.Text = string.Empty;
            Grid1.PageIndex = 0;
            LoadGridData();
        }


        protected void Grid1_Sort(object sender, GridSortEventArgs e)
        {
            Grid1.SortField = e.SortField;
            Grid1.SortDirection = e.SortDirection;
            LoadGridData();
        }

        protected void Grid1_PageIndexChange(object sender, GridPageEventArgs e)
        {
            Grid1.PageIndex = e.NewPageIndex;
            LoadGridData();
        }

        protected void Grid1_RowCommand(object sender, GridCommandEventArgs e)
        {
            object[] values = Grid1.DataKeys[e.RowIndex];
            Int64 perId = int.Parse(values[0].ToString());
            if (e.CommandName == "Delete")
            {
                IOJCMSService service = new OJCMSServiceClient();
                if (service.DeletePermissionById(perId))
                {
                    LoadGridData();
                    Alert.ShowInTop("删除成功。");
                }
                else
                {
                    Alert.ShowInTop("删除失败。");
                }
            }
        }

        protected void ddlGridPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            Grid1.PageSize = int.Parse(ddlGridPageSize.SelectedValue);
            if (Grid1.PageIndex > Grid1.PageCount - 1)
            {
                Grid1.PageIndex = Grid1.PageCount - 1;
            }
            LoadGridData();
        }

        /// <summary>
        /// 加载表格数据
        /// </summary>
        private void LoadGridData()
        {
            PermissionPageList permissionPageList = LoadData();
            BindGrid(permissionPageList);
        }
    }
}