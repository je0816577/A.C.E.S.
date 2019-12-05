using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ACES4
{
    public partial class ReportDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Violations.Attributes["data-name"] = Application["Fleet"].ToString();
            Violations.Attributes["data-test"] = Application["DATA"].ToString();



        }
    }
}