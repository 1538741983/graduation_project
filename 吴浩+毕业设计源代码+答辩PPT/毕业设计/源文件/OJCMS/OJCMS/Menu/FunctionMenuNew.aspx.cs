using System;
using FineUI;
using OJCMS.APPCode;

namespace OJCMS.menu
{
    public partial class FunctionMenuNew : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnClose.OnClientClick = ActiveWindow.GetHidePostBackReference();
                LoadData();
            }
        }

        private void LoadData()
        {

        }

        protected void btnSaveRefresh_Click(object sender, EventArgs e)
        {
            //T_FunctionMenu functionMenu = new T_FunctionMenu();
            //DataTable dtFunctionMenu = functionMenu.SelParentID1();
            //DataTable dtFunctionMenuItemSort=functionMenu.SelItemSort();
            //if (TxtMenuName.Text.Trim().Length > 0)
            //{
            //    try
            //    {
            //        T_FunctionMenu functionMenu1 = new T_FunctionMenu();
            //        if (dtFunctionMenu.Rows.Count == 0)
            //        {
            //            functionMenu1.Funcid = "01";
            //        }
            //        else
            //        {
            //            int functionMenuId = int.Parse(dtFunctionMenu.Rows[0]["FUNCID"].ToString()) + 1;
            //            if (functionMenuId.ToString().Length == 2)
            //            {
            //                functionMenu1.Funcid = functionMenuId.ToString();
            //            }
            //            if (functionMenuId.ToString().Length == 1)
            //            {
            //                functionMenu1.Funcid = '0' + functionMenuId.ToString();
            //            }
            //        }
            //        functionMenu1.Funcname = TxtMenuName.Text;
            //        functionMenu1.Parentid = "1";
            //        functionMenu1.Visible = 'Y';
            //        functionMenu1.Runwhat = "#";
            //        functionMenu1.Itemsort = int.Parse(dtFunctionMenuItemSort.Rows[0]["Itemsort"].ToString()) + 1;
            //        functionMenu1.Del = true;
            //        functionMenu1.AddMenus();
            //    }
            //    catch
            //    {
            //        Alert.ShowInTop("保存失败！可能输入了非法字符。");
            //        return;
            //    }
            //}
            //else
            //{
            //    Alert.ShowInTop("请填写菜单名称！");
            //    return;
            //}

            //PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference());
        }
    }
}