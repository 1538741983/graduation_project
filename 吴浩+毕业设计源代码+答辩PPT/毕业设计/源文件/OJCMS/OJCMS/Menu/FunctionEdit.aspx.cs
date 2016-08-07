using System;
using System.Data;
using FineUI;
using OJCMS.APPCode;
using OJCMS.OJCMSService;

namespace OJCMS.menu
{
    public partial class FunctionEdit : PageBase
    {
        private MenuDO model;

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
                model = service.GetMenuDoById(CommString.FunctionID);

                TxtMenuId.Text = model.Id;
                TxtFunctionName.Text = model.Name;
                TxtLink.Text = model.NavigateUrl;
                Ds.Text = model.Ds.ToString();
                Fg_sys.Text = model.Fg_sys.ToString();

                MenuDO parentMenu = service.GetMenuDoById(model.Id_perent);

                LabMenuID.Text = parentMenu.Id;
                LabMenuName.Text = parentMenu.Name;
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
            menu.Ds = Convert.ToBoolean(Ds.Text);
            menu.Fg_sys = Convert.ToBoolean(Fg_sys.Text);

            if (string.IsNullOrWhiteSpace(menu.Id) || string.IsNullOrWhiteSpace(menu.Name) ||
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
    }
}