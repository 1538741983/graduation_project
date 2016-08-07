using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;
using OJCMS.APPCode;
using Button = FineUI.Button;

namespace OJCMS.ProblemTest
{
    public partial class ProblemInfoBase : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void SetState(string state)
        {
            if (state == "New")
            {
                TxtTitle.Readonly = false;
                Toolbar toolbar = new Toolbar();

                Button button1 = new Button();
                button1.Text = "保存";
                toolbar.Items.Add(button1);
                //this.SimpleForm1.Toolbars.Add(toolbar);
            }
        }
    }
}