using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using FineUI;
using OJCMS.APPCode;
using OJCMS.OJCMSService;

namespace OJCMS
{
    public partial class Default : PageBase
    {
        private List<MenuDO> menuList;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                LoadData();
                InitMenu();
            }
        }

        private void LoadData()
        {
            txtUser.Text = String.Format("欢迎您：<span style=\"font-weight:bold;color:red;\">{0} ", UserAction.UserName, Request.UserHostAddress);
            // txtOnlineUserCount.Text = String.Format();

            try
            {
                IOJCMSService service = new OJCMSServiceClient();
                menuList = service.GetMenuList().ToList();
                menuList.Sort((t1, t2) => String.Compare(t1.Code, t2.Code, StringComparison.Ordinal));
            }
            catch
            {
                string a = "网络不稳定";
                string url = "Error.aspx?cw=" + a + "";
                Response.Redirect(url);
            }
        }

        private void InitMenu()
        {
            IEnumerable<MenuDO> rootMenuList = this.menuList.Where(t => this.menuList.All(y => y.Id != t.Id_perent));

            foreach (MenuDO menuDo in rootMenuList)
            {
                //FineUI.AccordionPane panel = new FineUI.AccordionPane();

                //AccordionmMenu.Items.Add(panel);
                //panel.Title = menuDo.Name;//dr["funcname"].ToString();
                //title = menuDo.Name;//dr["funcname"].ToString();
                //panel.ShowBorder = false;
                //panel.Layout = FineUI.Layout.Fit;
                //panel.IconUrl = "~/Styles/images/16/" + (i++).ToString() + ".png";

                //FineUI.Tree tree = new FineUI.Tree();
                //tree.ShowBorder = false;
                //tree.ShowHeader = false;
                //tree.EnableArrows = true;
                //tree.EnableLines = true;
                //tree.EnableIcons = false;
                //tree.AutoScroll = true;
                //tree.CssStyle = "font-family:仿宋体;font-size:18px; margin-top: 5px;";
                //tree.CssClass = "mainmenu";

                //AccordionmMenu.Items.Add(tree);



                //TreeNode node = new TreeNode();

                //node.Text = menuDo.Name;//dr["funcname"].ToString();
                //node.NodeID = menuDo.Id.ToString();//dr["funcid"].ToString();
                //if (!string.IsNullOrWhiteSpace(menuDo.NavigateUrl))
                //{
                //    node.NavigateUrl = menuDo.NavigateUrl;
                //    node.Target = menuDo.Target;
                //}
                //leftTree.Nodes.Add(node);

                InitMenuTree(leftTree.Nodes, menuDo);
            }
        }

        private void InitMenuTree(TreeNodeCollection treeNodes, MenuDO parentDo)
        {
            IEnumerable<MenuDO> childrenList = this.menuList.Where(t => t.Id_perent == parentDo.Id);
            foreach (MenuDO menuDo in childrenList)
            {
                TreeNode node = new TreeNode();
                node.Expanded = true;
                node.Text = menuDo.Name;//dr["funcname"].ToString();
                node.NodeID = menuDo.Id.ToString();//dr["funcid"].ToString();
                if (!string.IsNullOrWhiteSpace(menuDo.NavigateUrl))
                {
                    node.NavigateUrl = menuDo.NavigateUrl;
                    node.Target = menuDo.Target;
                }
                treeNodes.Add(node);

                InitMenuTree(node.Nodes, menuDo);
            }

        }

        protected void btnExit_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }

        protected void Window1_Close(object sender, EventArgs e)
        {

        }
    }
}