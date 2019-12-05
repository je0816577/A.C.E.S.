using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Data.SqlClient;



namespace ACES4
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                GetFleetViolationsByMonth();
                GetViolationsByFleet("JPT");
                GetViolationsByFleet("WLT");
                GetViolationsByFleet("POR");
            }
        }
        public void LoadChartDetails()
        {
            
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           
        }

        private void GetFleetViolationsByMonth()
        {
            int dateYearNow = DateTime.Now.Year;
            int dateSixMonths = DateTime.Now.AddMonths(-6).Month + 1;

            int jpt = 0;
            int wlt = 0;
            int por = 0;
            ViolationsByMonth.Attributes["data-test"] = "";
            SqlConnection conn = new SqlConnection(Connector.ConString("wilsonlogistics"));
           // SqlCommand cmd = new SqlCommand("sp_test", conn);
            SqlCommand cmd = new SqlCommand("sp_GetFleetViolationsByMonth", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            
           
            conn.Open();
            cmd.Parameters.AddWithValue("@Fleet", " ");
            cmd.Parameters.AddWithValue("@Month", 0);
            for (int i = 6; i > 0; i--)
            {

                conn.Close();
                conn.Open();
                if (dateSixMonths == 13)
                {
                    dateSixMonths = 1;
                }
                cmd.Parameters["@Fleet"].Value = "JPT";
                cmd.Parameters["@Month"].Value = dateSixMonths.ToString() + "-" + dateYearNow.ToString();
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {

                    jpt = (int)sdr["Violation"];

                }
                else
                {
                    jpt = 0;
                }
                cmd.Parameters["@Fleet"].Value = "WLT";
                conn.Close();
                conn.Open();
                SqlDataReader sdr2 = cmd.ExecuteReader();
                if (sdr2.Read())
                {

                    wlt = (int)sdr2["Violation"];


                }
                else
                {
                    wlt = 0;
                }
                cmd.Parameters["@Fleet"].Value = "POR";
                conn.Close();
                conn.Open();
                SqlDataReader sdr3 = cmd.ExecuteReader();
                if (sdr3.Read())
                {
                    por = (int)sdr3["Violation"];
                }
                else
                {
                    por = 0;
                }
                ViolationsByMonth.Attributes["data-test"] += dateSixMonths.ToString() + "," + jpt + "," + wlt + "," + por + ",";
                dateSixMonths++;
            }






            conn.Close();
        }

        private void GetViolationsByFleet(string fleet)
        {
            
            int dateYearNow = DateTime.Now.Year;
            int dateSixMonths = DateTime.Now.AddMonths(-6).Month + 1;
            SqlConnection conn = new SqlConnection(Connector.ConString("wilsonlogistics"));
            SqlCommand cmd = new SqlCommand("sp_GetViolationsByFleet", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            conn.Open();
            cmd.Parameters.AddWithValue("@Fleet", " ");
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
                cmd.Parameters["@Fleet"].Value = fleet;
                cmd.Parameters["@Date"].Value = dateSixMonths.ToString() + "-" + dateYearNow.ToString();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {

                    hos = (int)sdr["TotalHos"];
                    failedInspectioin = (int)sdr["TotalFailedIns"];
                    citation = (int)sdr["TotalCitations"];

                }
                if (fleet == "JPT")
                {
                    JPTViolations.Attributes["data-test"] += dateSixMonths.ToString() + "," + hos + "," + failedInspectioin + "," + citation +  ",";

                }
                if (fleet == "WLT")
                {
                    WLTViolations.Attributes["data-test"] += dateSixMonths.ToString() + "," + hos + "," + failedInspectioin + "," + citation + ",";

                }
                if (fleet == "POR")
                {
                    PORViolations.Attributes["data-test"] += dateSixMonths.ToString() + "," + hos + "," + failedInspectioin + "," + citation + ",";

                }

                dateSixMonths++;
            }

            conn.Close();



        }

        protected void btnCCC_Click(object sender, EventArgs e)
        {
            Application["DATA"] = WLTViolations.Attributes["data-test"];
            Application["Fleet"] = "WLT";
            Response.Redirect("ReportDetails.aspx");
        }
        protected void btnCCR_Click(object sender, EventArgs e)
        {
            Application["DATA"] = PORViolations.Attributes["data-test"];
            Application["Fleet"] = "POR";
            Response.Redirect("ReportDetails.aspx");
        }
        protected void btnCCL_Click(object sender, EventArgs e)
        {
            Application["DATA"] = JPTViolations.Attributes["data-test"];
            Application["Fleet"] = "JPT";
            JPTViolations.Text = JPTViolations.Attributes["data-test"];
            Response.Redirect("ReportDetails.aspx");

        }
    }
}