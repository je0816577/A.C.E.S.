using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace ACES4
{
    public partial class ReportDetailsSpecific : System.Web.UI.Page
    {
        private string type;
        protected void Page_Load(object sender, EventArgs e)
        {
            type = Request.Params["type"];
            labelInfo.Text = "Enter " + type + " code:";
        }

        protected void BtnGetData_Click(object sender, EventArgs e)
        {
            try
            {
                int dateYearNow = DateTime.Now.Year;
                int dateSixMonths = DateTime.Now.AddMonths(-6).Month + 1;
                string procedure = "sp_GetViolationsBy" + type;
                SqlConnection conn = new SqlConnection(Connector.ConString("wilsonlogistics"));
                SqlCommand cmd = new SqlCommand(procedure, conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                cmd.Parameters.AddWithValue("@Code", "");
                cmd.Parameters.AddWithValue("@Date", 0);
                for (int i = 6; i > 0; i--)
                {
                    int hos = 0;
                    int failedInspectioin = 0;
                    int citation = 0;
                    conn.Close();
                    conn.Open();
                    if (dateSixMonths == 13)
                    {
                        dateSixMonths = 1;
                    }
                    cmd.Parameters["@Code"].Value = TxtBxDrCode.Text;
                    cmd.Parameters["@Date"].Value = dateSixMonths.ToString() + "-" + dateYearNow.ToString();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {

                        hos = (int)sdr["TotalHos"];
                        failedInspectioin = (int)sdr["TotalFailedIns"];
                        citation = (int)sdr["TotalCitations"];

                    }
                    Violations.Attributes["data-test"] += dateSixMonths.ToString() + "," + hos + "," + failedInspectioin + "," + citation + ",";
                    dateSixMonths++;
                }
                
                conn.Close();
            }
            catch (Exception ex)
            {
                Violations.Text = ex.Message;
            }
        }
    }
}