using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace ACES4
{
    public partial class Load : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void BtnGetData_Click(object sender, EventArgs e)
        {
            try
            {
                
                GridView1.DataSourceID = Conn2.ID;

                Conn2.UpdateParameters["DrCode"].DefaultValue = TxtBxDrCode.Text.ToString();
                
                Response.Write(TxtBxDrCode.Text);


            }
            catch (Exception ex)
            {
               //Response.Write(ex.Message);
            }
        }
    }
}