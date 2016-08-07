using System;
using System.Linq;
using FineUI;
using OJCMS.APPCode;
using OJCMS.OJCMSService;

namespace OJCMS.menu
{
    public partial class FunctionInfo : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnCancel.OnClientClick = ActiveWindow.GetHideReference();
                string action = Request.QueryString["action"];
                Action.Text = action;
                switch (action)
                {
                    case "Edit":
                        LoadData();
                        break;
                    case "New":
                        LoadData();
                        break;
                }
            }
        }

        private void LoadData()
        {
            if (!Request.QueryString.AllKeys.Contains("id"))
                return;
            Int64 id = Convert.ToInt64(Request.QueryString["id"]);

            if (Action.Text == "Edit")
            {
                IOJCMSService service = new OJCMSServiceClient();
                MenuDO menu = service.GetMenuDoById(id);
                TxtMenuId.Text = menu.Id.ToString();
                TxtMenuCode.Text = menu.Code;
                TxtFunctionName.Text = menu.Name;
                TxtLink.Text = menu.NavigateUrl;
                Ds.Text = menu.Ds.ToString();
                Fg_sys.Text = menu.Fg_sys.ToString();

                if (menu.Id_perent != null)
                {
                    MenuDO parentMenu = service.GetMenuDoById((long)menu.Id_perent);

                    LabMenuId.Text = parentMenu.Id.ToString();
                    LabMenuCode.Text = parentMenu.Code;
                    LabMenuName.Text = parentMenu.Name;
                }

            }
            else if (Action.Text == "New")
            {
                IOJCMSService service = new OJCMSServiceClient();
                MenuDO parentMenu = service.GetMenuDoById(id);
                LabMenuId.Text = parentMenu.Id.ToString();
                LabMenuCode.Text = parentMenu.Code;
                LabMenuName.Text = parentMenu.Name;
            }
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            if (Action.Text == "Edit")
            {
                MenuDO menu = new MenuDO();
                menu.Id_perent = string.IsNullOrWhiteSpace(LabMenuId.Text) ? (long?)null : Convert.ToInt64(LabMenuId.Text);
                menu.Id = Convert.ToInt64(TxtMenuId.Text);
                menu.Code = TxtMenuCode.Text;
                menu.Name = TxtFunctionName.Text;
                menu.NavigateUrl = TxtLink.Text;
                menu.Ds = Convert.ToBoolean(Ds.Text);
                menu.Fg_sys = Convert.ToBoolean(Fg_sys.Text);

                if (string.IsNullOrWhiteSpace(menu.Code) || string.IsNullOrWhiteSpace(menu.Name) ||
                    string.IsNullOrWhiteSpace(menu.NavigateUrl))
                {
                    Alert.ShowInTop("请填写必填信息。");
                    return;
                }

                IOJCMSService service = new OJCMSServiceClient();
                if (service.UpdateMenu(menu))
                {
                    Alert.ShowInTop("保存成功。");
                    PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference());
                }
                else
                {
                    Alert.ShowInTop("保存失败。");
                    return;
                }
            }
            else if (Action.Text == "New")
            {
                MenuDO menu = new MenuDO();
                menu.Id_perent = string.IsNullOrWhiteSpace(LabMenuId.Text) ? (long?)null : Convert.ToInt64(LabMenuId.Text);
                menu.Code = TxtMenuCode.Text;
                menu.Name = TxtFunctionName.Text;
                menu.NavigateUrl = TxtLink.Text;
                menu.Ds = true;
                menu.Fg_sys = true;

                if (string.IsNullOrWhiteSpace(menu.Code) || string.IsNullOrWhiteSpace(menu.Name) ||
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
            }
        }
    }
}