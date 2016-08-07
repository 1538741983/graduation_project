using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;
using OJCMS.APPCode;

namespace OJCMS.ProblemTest
{
    public partial class ProblemNewTest : ProblemInfoBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            Alert.ShowInTop("OK");
        }
    }
}