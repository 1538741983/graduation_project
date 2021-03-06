﻿using System;
using FineUI;
using OJCMS.APPCode;
using OJCMS.OJService;

namespace OJCMS.ProblemTest
{
    public partial class ProblmeManager : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnNew.OnClientClick = WindowDialog.GetShowReference("~/ProblemTest/ProblemNewTest.aspx", "新增问题");
                ProblemPageList problemPageList = LoadData();
                BindGrid(problemPageList);
            }
        }

        private ProblemPageList LoadData()
        {
            int pageIndex = Grid1.PageIndex;
            int pageSize = Grid1.PageSize;
            string searchText = ttbSearchMessage.Text.Trim();
            IOJService service = new OJServiceClient();
            return service.GetProblemPageList(pageSize, pageIndex, string.IsNullOrWhiteSpace(searchText) ? null : searchText);
        }

        private void BindGrid(ProblemPageList problemPageList)
        {
            //获取总条目
            Grid1.RecordCount = problemPageList.RecordCount;

            ProblemDO[] userList = problemPageList.DataList;
            //获取分页数据
            //DataTable paged = GetDataTablePage();

            //绑定到Grid1
            Grid1.DataSource = userList;
            Grid1.DataBind();
        }

        //绑定搜索数据
        //private void BindGridSelect()
        //{
        //    if (!string.IsNullOrEmpty(ttbSearchMessage.Text))
        //    {
        //        string searchText = ttbSearchMessage.Text.Trim();

        //        //设置数据总个数
        //        Grid1.RecordCount = GetDataTableSelect(searchText).Rows.Count;

        //        //获取当前分页数据
        //        DataTable table = GetDataTablePage();

        //        //绑定到Grid
        //        Grid1.DataSource = table;
        //        Grid1.DataBind();
        //    }
        //    else
        //    {
        //        Alert.ShowInTop("请输入要搜索条件");
        //    }
        //}

        //private DataTable GetDataTablePage()
        //{
        //    int pageIndex = Grid1.PageIndex;
        //    int pageSize = Grid1.PageSize;
        //    string sortField = Grid1.SortField;
        //    string sortDirection = Grid1.SortDirection;
        //    DataTable table = new DataTable();
        //    if (!string.IsNullOrEmpty(ttbSearchMessage.Text))
        //    {
        //        string searchText = ttbSearchMessage.Text.Trim();
        //        table = GetDataTableSelect(searchText);
        //    }
        //    else
        //    {
        //        table = GetDataTable();
        //    }
        //    DataView view = table.DefaultView;
        //    view.Sort = string.Format("{0} {1}", sortField, sortDirection);

        //    DataTable table2 = view.ToTable();
        //    DataTable paged = table2.Clone();

        //    int rowbegin = pageIndex * pageSize;
        //    int rowend = (pageIndex + 1) * pageSize;

        //    if (rowend > table2.Rows.Count)
        //    {
        //        rowend = table2.Rows.Count;
        //    }

        //    for (int i = rowbegin; i < rowend; i++)
        //    {
        //        paged.ImportRow(table2.Rows[i]);
        //    }
        //    return paged;
        //}

        ////private DataTable GetDataTableSelect(string searchText)
        ////{

        ////    T_User user = new T_User();
        ////    user.SearchText = searchText;
        ////    return user.SearchUserAll();

        ////}

        ////private DataTable GetDataTable()
        ////{
        ////    T_User user = new T_User();
        ////    return user.SelectAll();
        ////}

        protected void ttbSearchMessage_Trigger2Click(object sender, EventArgs e)
        {
            ttbSearchMessage.ShowTrigger1 = true;
            if (Grid1.PageCount > 0)
            {
                Grid1.PageIndex = 0;
            }
            ProblemPageList problemPageList = LoadData();
            BindGrid(problemPageList);
        }

        protected void ttbSearchMessage_Trigger1Click(object sender, EventArgs e)
        {
            ttbSearchMessage.ShowTrigger1 = false;
            ttbSearchMessage.Text = string.Empty;
            Grid1.PageIndex = 0;
            ProblemPageList problemPageList = LoadData();
            BindGrid(problemPageList);
        }


        protected void Grid1_Sort(object sender, GridSortEventArgs e)
        {
            Grid1.SortField = e.SortField;
            Grid1.SortDirection = e.SortDirection;
            //if (!string.IsNullOrEmpty(ttbSearchMessage.Text))
            //{
            //    BindGridSelect();
            //}
            //else
            //{
            ProblemPageList problemPageList = LoadData();
            BindGrid(problemPageList);
            //}
        }

        protected void Grid1_PageIndexChange(object sender, GridPageEventArgs e)
        {
            Grid1.PageIndex = e.NewPageIndex;
            //if (!string.IsNullOrEmpty(ttbSearchMessage.Text))
            //{
            //    BindGridSelect();
            //}
            //else
            //{
            ProblemPageList problemPageList = LoadData();
            BindGrid(problemPageList);
            //}
        }

        protected void Grid1_RowCommand(object sender, GridCommandEventArgs e)
        {
            object[] values = Grid1.DataKeys[e.RowIndex];
            int problemId = int.Parse(values[0].ToString());
            //string problemTitle = values[1].ToString();
            if (e.CommandName == "Delete")
            {
                IOJService service = new OJServiceClient();
                if (service.DeleleProblemById(problemId))
                {
                    ProblemPageList problemPageList = LoadData();
                    BindGrid(problemPageList);
                    Alert.ShowInTop("删除成功。");
                }
                else
                {
                    Alert.ShowInTop("删除失败。");
                }
            }
        }



        //protected void Window1_Close(object sender, EventArgs e)
        //{
        //    if (!string.IsNullOrEmpty(ttbSearchMessage.Text))
        //    {
        //        BindGridSelect();
        //    }
        //    else
        //    {
        //        UserPageList userPageList = LoadData();
        //        BindGrid(userPageList);
        //    }
        //}

        protected void ddlGridPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            Grid1.PageSize = int.Parse(ddlGridPageSize.SelectedValue);
            if (Grid1.PageIndex > Grid1.PageCount - 1)
            {
                Grid1.PageIndex = Grid1.PageCount - 1;
            }
            //if (!string.IsNullOrEmpty(ttbSearchMessage.Text))
            //{
            //    BindGridSelect();
            //}
            //else
            //{
            ProblemPageList problemPageList = LoadData();
            BindGrid(problemPageList);
            //}
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
        }

        protected void BtnSelectDel_Click(object sender, EventArgs e)
        {
            //if (Grid1.SelectedRowIndexArray != null && Grid1.SelectedRowIndexArray.Length > 0)
            //{
            //    try
            //    {
            //        foreach (int index in Grid1.SelectedRowIndexArray)
            //        {
            //            int guid = int.Parse(Grid1.DataKeys[index][0].ToString());
            //            string guname = Grid1.DataKeys[index][1].ToString();
            //            if (guname == "admin")
            //            {
            //                Alert.ShowInTop("admin用户不能删除");
            //            }
            //            else
            //            {
            //                T_User user = new T_User();
            //                user.U_id = guid;
            //                user.DeleteUser();
            //            }
            //        }
            //        ttbSearchMessage.Text = string.Empty;
            //        ttbSearchMessage.ShowTrigger1 = false;
            //        Grid1.PageIndex = 0;
            //        BindGrid();
            //        Alert.ShowInTop("删除成功！！！");
            //    }
            //    catch
            //    {
            //        Alert.ShowInTop("删除时出错了...");
            //    }

            //}
        }
    }
}