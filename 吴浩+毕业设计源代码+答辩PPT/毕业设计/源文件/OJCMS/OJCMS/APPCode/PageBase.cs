using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using FineUI;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace OJCMS.APPCode
{
    public class PageBase : System.Web.UI.Page
    {
        /// <summary>
        /// 当前系统登陆帮助对象
        /// </summary>
        public UserModel UserAction;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            HttpCookie themeCookie;
            if (PageManager.Instance != null)
            {
                themeCookie = Request.Cookies["Theme"];
                if (themeCookie != null)
                {
                    string themeValue = themeCookie.Value;
                    PageManager.Instance.Theme = (Theme)Enum.Parse(typeof(Theme), themeCookie.Value.ToString(), true);
                }

                themeCookie = Request.Cookies["Language"];
                if (themeCookie != null)
                {
                    PageManager.Instance.Language = (Language)Enum.Parse(typeof(Language), themeCookie.Value.ToString(), true);
                }
            }

            if (Request.IsAuthenticated)
            {
                UserAction = (User.Identity as FormsIdentity).Ticket.UserData.FromJson<UserModel>();
                if (UserAction.UserName == "admin") return;//超级用户
                if (!FunFilter())
                {
                    Response.Write("<script>alert('你没有访问该页面的权限!');window.parent.location.href='/Login.aspx';</script>");
                    Response.End();
                }
            }
            else
            {
                Response.Write("<script>alert('请先登录系统!');window.parent.location.href='/Login.aspx';</script>");
                Response.End();
            }
        }

        /// <summary>
        /// 过滤角色可以访问的页面
        /// </summary>
        /// <returns></returns>
        private bool FunFilter()
        {
            try
            {
                string url = Convert.ToString(HttpContext.Current.Request.Url.AbsolutePath);
                string route = url.Substring(1).ToLower();
                //不需要进行判断的系统默认页面
                string strAcquiescently = @"default.aspx,";
                if (strAcquiescently.ToLower().IndexOf(route, StringComparison.Ordinal) > -1 || UserAction.UserName == "admin")
                {
                    return true;
                }
                return true;
                //                string strTmp = @"SELECT 1
                //                                  FROM T_FunctionMenu A, T_Tasks B
                //                                 WHERE A.FUNCID = B.Taskid
                //                                   AND CHARINDEX(convert(varchar(20),B.ROLEID), '" + UserAction.A_ID + @"') > 0
                //                                   AND LOWER(A.RUNWHAT) LIKE '%" + route + "%'";
                //                return DbHelperSQL.ExecSql(strTmp);
            }
            catch
            {
                Alert.ShowInTop("请刷新页面！！");
                return false;
            }
        }

        #region GetQueryValue/GetQueryIntValue

        /// <summary>
        /// 获取查询字符串中的参数值
        /// </summary>
        protected string GetQueryValue(string queryKey)
        {
            return Request.QueryString[queryKey];
        }


        /// <summary>
        /// 获取查询字符串中的参数值
        /// </summary>
        protected int GetQueryIntValue(string queryKey)
        {
            int queryIntValue = -1;
            try
            {
                queryIntValue = Convert.ToInt32(Request.QueryString[queryKey]);
            }
            catch (Exception)
            {
                // TODO
            }

            return queryIntValue;
        }

        #endregion

        #region GetSelectedIDsFromHiddenField/SyncSelectedRowIndexArrayToHiddenField/UpdateSelectedRowIndexArray

        /// <summary>
        /// 从隐藏字段中获取选择的全部ID列表
        /// </summary>
        /// <param name="hfSelectedIDS"></param>
        /// <returns></returns>
        public List<string> GetSelectedIDsFromHiddenField(FineUI.HiddenField hfSelectedIDS)
        {
            JArray idsArray = new JArray();

            string currentIDS = hfSelectedIDS.Text.Trim();
            if (!String.IsNullOrEmpty(currentIDS))
            {
                idsArray = JArray.Parse(currentIDS);
            }
            else
            {
                idsArray = new JArray();
            }
            return new List<string>(idsArray.ToObject<string[]>());
        }

        /// <summary>
        /// 将表格当前页面选中行对应的数据同步到隐藏字段中
        /// </summary>
        /// <param name="hfSelectedIDS"></param>
        /// <param name="Grid1"></param>
        public void SyncSelectedRowIndexArrayToHiddenField(FineUI.HiddenField hfSelectedIDS, Grid Grid1)
        {
            List<string> ids = GetSelectedIDsFromHiddenField(hfSelectedIDS);

            List<int> selectedRows = new List<int>();
            if (Grid1.SelectedRowIndexArray != null && Grid1.SelectedRowIndexArray.Length > 0)
            {
                selectedRows = new List<int>(Grid1.SelectedRowIndexArray);
            }

            if (Grid1.IsDatabasePaging)
            {
                for (int i = 0, count = Math.Min(Grid1.PageSize, (Grid1.RecordCount - Grid1.PageIndex * Grid1.PageSize)); i < count; i++)
                {
                    string id = Grid1.DataKeys[i][0].ToString();
                    if (selectedRows.Contains(i))
                    {
                        if (!ids.Contains(id))
                        {
                            ids.Add(id);
                        }
                    }
                    else
                    {
                        if (ids.Contains(id))
                        {
                            ids.Remove(id);
                        }
                    }
                }
            }
            else
            {
                int startPageIndex = Grid1.PageIndex * Grid1.PageSize;
                for (int i = startPageIndex, count = Math.Min(startPageIndex + Grid1.PageSize, Grid1.RecordCount); i < count; i++)
                {
                    string id = Grid1.DataKeys[i][0].ToString();
                    if (selectedRows.Contains(i - startPageIndex))
                    {
                        if (!ids.Contains(id))
                        {
                            ids.Add(id);
                        }
                    }
                    else
                    {
                        if (ids.Contains(id))
                        {
                            ids.Remove(id);
                        }
                    }
                }
            }

            hfSelectedIDS.Text = new JArray(ids).ToString(Formatting.None);
        }

        /// <summary>
        /// 根据隐藏字段的数据更新表格当前页面的选中行
        /// </summary>
        /// <param name="hfSelectedIDS"></param>
        /// <param name="Grid1"></param>
        public void UpdateSelectedRowIndexArray(FineUI.HiddenField hfSelectedIDS, Grid Grid1)
        {
            List<string> ids = GetSelectedIDsFromHiddenField(hfSelectedIDS);

            List<int> nextSelectedRowIndexArray = new List<int>();
            if (Grid1.IsDatabasePaging)
            {
                for (int i = 0, count = Math.Min(Grid1.PageSize, (Grid1.RecordCount - Grid1.PageIndex * Grid1.PageSize)); i < count; i++)
                {
                    string id = Grid1.DataKeys[i][0].ToString();
                    if (ids.Contains(id))
                    {
                        nextSelectedRowIndexArray.Add(i);
                    }
                }
            }
            else
            {
                int nextStartPageIndex = Grid1.PageIndex * Grid1.PageSize;
                for (int i = nextStartPageIndex, count = Math.Min(nextStartPageIndex + Grid1.PageSize, Grid1.RecordCount); i < count; i++)
                {
                    string id = Grid1.DataKeys[i][0].ToString();
                    if (ids.Contains(id))
                    {
                        nextSelectedRowIndexArray.Add(i - nextStartPageIndex);
                    }
                }
            }
            Grid1.SelectedRowIndexArray = nextSelectedRowIndexArray.ToArray();
        }

        #endregion
    }
}