using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;

namespace ACES4
{
    public partial class Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                populate();
            }


        }
        private void populate()
        {
            //bool training = false;
            //bool preventable = false;
            //bool counseled = false;
            //bool termed = false;
            int incidentNum = int.Parse(Request.QueryString["IncidentNum"]);
            string ManagerCode = Request.QueryString["ManagerCode"];
            DateTime addedDate;
            SqlConnection conn = new SqlConnection(Connector.ConString("wilsonlogistics"));
            SqlCommand cmd = new SqlCommand("sp_GetIncident", conn);
            conn.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@incidentNum", incidentNum);
            cmd.Parameters.AddWithValue("@mgrCode", ManagerCode);
            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {
                TxtBxDate.Text = DateTime.Parse(sdr["Refdate"].ToString()).ToString("MM/dd/yyyy");
                TxtBxDrCode.Text = sdr["DriverCode"].ToString();
                TxtBxDrName.Text = sdr["DriverName"].ToString();
                TxtBxFMCode.Text = sdr["ManagerCode"].ToString();
                TxtBxFMName.Text = sdr["FMName"].ToString();
                TxtBxFMInit.Text = sdr["FltMgrInits"].ToString();
                TxtBxFleetCode.Text = sdr["Fleet"].ToString();
                TxtBxHOSViolation.Text = sdr["HOSViolation"].ToString();
                TxtBxInspect.Text = sdr["FailedInspection"].ToString();
                TxtBxCitation.Text = sdr["Citation"].ToString();
                //TxtBxService.Text = sdr["ServiceFail"].ToString();
                TxtBxNote.Text = sdr["Note"].ToString();

                
                if (sdr["Counseled"].ToString() == "True")
                {
                    CkBxList.Items[0].Selected = true;
                }
                if (sdr["Termed"].ToString() == "True")
                {
                    CkBxList.Items[1].Selected = true;
                }

            }
            conn.Close();

            SqlCommand cmd2 = new SqlCommand("sp_GetNotes", conn);
            cmd2.CommandType = System.Data.CommandType.StoredProcedure;
            cmd2.Parameters.AddWithValue("@IncidentNum", incidentNum);
            conn.Open();
            SqlDataReader rdr2 = cmd2.ExecuteReader();

            while (rdr2.Read())
            {
                
                TxtBxNote.Text += "\n\n"+ DateTime.Parse(rdr2["AddedDate"].ToString()).ToString("MM/dd/yyyy") + " - "+ rdr2["Addedby"].ToString() + " " + rdr2["Note"].ToString();
            }
            conn.Close();
            TxtBxNote.Enabled = false;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            // Response.Write("<script>alert('DFEFJE')</script>");


            //var p = new HtmlGenericControl("p") { InnerText = "Products Elements here" };
            //p.ID = "TestId";
            //contentArea.Controls.Add(p);
            try
            {
                int hos;
                int failedInspection;
                int citation;
                int serviceFail;
                bool training = false;
                bool preventable = false;
                bool counseled = false;
                bool termed = false;
                int id2 = 0;
                int incidentNum = int.Parse(Request.QueryString["IncidentNum"]);

                SqlConnection conn = new SqlConnection(Connector.ConString("wilsonlogistics"));
                SqlCommand cmd = new SqlCommand("sp_UpdateIncident", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                conn.Open();
                
                if (CkBxList.Items[0].Selected)
                {
                    counseled = true;
                }

                
                if (CkBxList.Items[1].Selected)
                {
                    termed = true;
                }
                int.TryParse(TxtBxHOSViolation.Text, out hos);
                int.TryParse(TxtBxInspect.Text, out failedInspection);
                int.TryParse(TxtBxCitation.Text, out citation);

                cmd.Parameters.AddWithValue("@IncidentId", incidentNum);
                cmd.Parameters.AddWithValue("@RefDate", TxtBxDate.Text);
                //cmd.Parameters.AddWithValue("@EntryDate", DateTime.Now.ToString("MM/dd/yyyy"));
                cmd.Parameters.AddWithValue("@DrCode", TxtBxDrCode.Text);
                cmd.Parameters.AddWithValue("@DrName", TxtBxDrName.Text);
                cmd.Parameters.AddWithValue("@MgrCode", TxtBxFMCode.Text);
                cmd.Parameters.AddWithValue("@FMInits", TxtBxFMInit.Text);
                cmd.Parameters.AddWithValue("@FleetCode", TxtBxFleetCode.Text);
                cmd.Parameters.AddWithValue("@Counsel", counseled);
                cmd.Parameters.AddWithValue("@Termed", termed);
                cmd.Parameters.AddWithValue("@HOSViolation", hos);
                cmd.Parameters.AddWithValue("@FailedIn", failedInspection);
                cmd.Parameters.AddWithValue("@Citation", citation);
                cmd.Parameters.AddWithValue("@Note", TxtBxNote.Text.ToString());
                cmd.ExecuteNonQuery();

                if (TxtBxAddNote.Text != "")
                {
                    SqlCommand cmd2 = new SqlCommand("sp_NewNotes", conn);
                    cmd2.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd2.Parameters.AddWithValue("@NoteText", TxtBxAddNote.Text.ToString());
                    cmd2.Parameters.AddWithValue("@IncidentNum", incidentNum);
                    cmd2.Parameters.AddWithValue("@AddedDate", DateTime.Now.ToString("MM/dd/yyyy"));
                    cmd2.ExecuteNonQuery();
                }
                

                lblErrMessage.Visible = true;
                lblErrMessage.Text = "Comlete";
                
                conn.Close();
                Response.Write("Complete");
                Response.Redirect("Home.aspx");
            }
            catch(Exception ex)
            {
                lblErrMessage.Visible = true;
                lblErrMessage.Text = ex.Message;
            }


        }
    }
}