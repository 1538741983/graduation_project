using System;
using System.Data;
using FineUI;
using OJCMS.APPCode;
using OJCMS.OJCMSService;

namespace OJCMS.menu
{
    public partial class FunctionNew : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnCancel.OnClientClick = ActiveWindow.GetHideReference();
                LoadData();

            }
        }

        private void LoadData()
        {
            try
            {
                IOJCMSService service = new OJCMSServiceClient();
                MenuDO menu = service.GetMenuDoById(CommString.FunctionID);
                LabMenuID.Text = menu.Id;
                LabMenuName.Text = menu.Name;
            }
            catch
            {
                Alert.ShowInTop("程序出错了...请联系管理员");
                return;
            }

        }

        protected void btnSaveRefresh_Click(object sender, EventArgs e)
        {
            MenuDO menu = new MenuDO();
            menu.Id_perent = LabMenuID.Text;
            menu.Id = TxtMenuId.Text;
            menu.Name = TxtFunctionName.Text;
            menu.NavigateUrl = TxtLink.Text;
            menu.Ds = false;
            menu.Fg_sys = true;

            if (string.IsNullOrWhiteSpace(menu.Id) || string.IsNullOrWhiteSpace(menu.Name) ||
                string.IsNullOrWhiteSpace(menu.NavigateUrl))
            {
                Alert.ShowInTop("请填写必填信息。");
                return;
            }

            IOJCMSService service = new OJCMSServiceClient();
            if (service.AddMenu(menu))
            {
                Alert.ShowInTop("保存成功。");
                PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference());
            }
            else
            {
                Alert.ShowInTop("保存失败。");
                return;
            }
            //T_FunctionMenu functionMenu = new T_FunctionMenu();
            //functionMenu.Parentid = LabMenuID.Text;
            //DataTable dtFunctionMenu = functionMenu.SelParentID();
            //DataTable dtFunctionMenuItemSort = functionMenu.SelItemSort();
            //if (TxtFunctionName.Text.Trim() != "" && TxtLink.Text.Trim() != "")
            //{
            //    try
            //    {
            //        T_FunctionMenu functionMenu1 = new T_FunctionMenu();
            //        if (dtFunctionMenu.Rows.Count == 0)
            //        {
            //            functionMenu1.Funcid = LabMenuID.Text + "01";
            //        }
            //        else
            //        {
            //            int functionMenuId = int.Parse(dtFunctionMenu.Rows[0]["FUNCID"].ToString()) + 1;
            //            if (functionMenuId.ToString().Length == 4)
            //            {
            //                functionMenu1.Funcid = functionMenuId.ToString();
            //            }
            //            if (functionMenuId.ToString().Length == 3)
            //            {
            //                functionMenu1.Funcid = '0' + functionMenuId.ToString();
            //            }
            //        }
            //        functionMenu1.Funcname = TxtFunctionName.Text;
            //        functionMenu1.Parentid = LabMenuID.Text;
            //        functionMenu1.Visible = 'Y';
            //        functionMenu1.Runwhat = TxtLink.Text;
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
            //    Alert.ShowInTop("请填写菜单名称或链接！");
            //    return;
            //}
            //PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference());
        }
    }
}