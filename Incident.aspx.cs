using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace ACES4
{
    public partial class Incident : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //TxtBxHOSViolation.Text = "0";
            //TxtBxService.Text = "0";
            //TxtBxInspect.Text = "0";
            //TxtBxCitation.Text = "0";
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            int hos = 0;
            int failedInspection = 0;
            int citation = 0;
            int serviceFail = 0;
            bool training = false;
            bool preventable = false;
            bool counseled = false;
            bool termed = false;
            int id2 = 0;



            try
            {
                SqlConnection conn = new SqlConnection(Connector.ConString("wilsonlogistics"));
                //SqlCommand cmd = new SqlCommand("INSERT INTO Incidents (EntryDate, RefDate, DriverCode, DriverName, ManagerCode, FltMgrInits, Fleet, PrevAccident," +
                //    "Counseled, Termed, HosViolation, FailedInspection, Citation, ServiceFail, TrainEnrichment) VALUES(@EntryDate, @RefDate, " +
                //    "@DrCode, @DrName, @MgrCode, @FMInits, @FleetCode, " +
                //    "@Prevent, @Counsel, @Termed, @HOSViolation, @FailedIn, @Citation, @Servicefail, @TrainEnrich)", conn);
                SqlCommand cmd2 = new SqlCommand("sp_NewIncident", conn);
                cmd2.CommandType = System.Data.CommandType.StoredProcedure;

                conn.Open();

                
                if (CkBxList.Items[0].Selected)
                {
                    counseled = true;
                }
                
                if (CkBxList.Items[1].Selected)
                {
                    termed = true;
                }

                //cmd.Parameters.AddWithValue("@RefDate", TxtBxDate.Text);
                //cmd.Parameters.AddWithValue("@EntryDate", DateTime.Now.ToString("MM/dd/yyyy"));
                //cmd.Parameters.AddWithValue("@DrCode", TxtBxDrCode.Text);
                //cmd.Parameters.AddWithValue("@DrName", TxtBxDrName.Text);
                //cmd.Parameters.AddWithValue("@MgrCode", TxtBxFMCode.Text);
                //cmd.Parameters.AddWithValue("@FMInits", TxtBxFMInit.Text);
                //cmd.Parameters.AddWithValue("@FleetCode", TxtBxFleetCode.Text);
                //cmd.Parameters.AddWithValue("@Prevent", preventable);
                //cmd.Parameters.AddWithValue("@Counsel", counseled);
                //cmd.Parameters.AddWithValue("@Termed", termed);
                //cmd.Parameters.AddWithValue("@HOSViolation", hos);
                //cmd.Parameters.AddWithValue("@FailedIn", failedInspection);
                //cmd.Parameters.AddWithValue("@Citation", citation);
                //cmd.Parameters.AddWithValue("@Servicefail", serviceFail);
                //cmd.Parameters.AddWithValue("@TrainEnrich", training);

                
                int.TryParse(TxtBxHOSViolation.Text, out hos);
                int.TryParse(TxtBxInspect.Text, out failedInspection);
                int.TryParse(TxtBxCitation.Text, out citation);

               
                cmd2.Parameters.AddWithValue("@RefDate", TxtBxDate.Text);
                cmd2.Parameters.AddWithValue("@EntryDate", DateTime.Now.ToString("MM/dd/yyyy"));
                cmd2.Parameters.AddWithValue("@DrCode", TxtBxDrCode.Text);
                cmd2.Parameters.AddWithValue("@DrName", TxtBxDrName.Text);
                cmd2.Parameters.AddWithValue("@MgrCode", TxtBxFMCode.Text);
                cmd2.Parameters.AddWithValue("@FMInits", TxtBxFMInit.Text);
                cmd2.Parameters.AddWithValue("@FleetCode", TxtBxFleetCode.Text);
                //cmd2.Parameters.AddWithValue("@Prevent", preventable);
                cmd2.Parameters.AddWithValue("@Counsel", counseled);
                cmd2.Parameters.AddWithValue("@Termed", termed);
                cmd2.Parameters.AddWithValue("@HOSViolation", hos);
                cmd2.Parameters.AddWithValue("@FailedIn", failedInspection);
                cmd2.Parameters.AddWithValue("@Citation", citation);
                //cmd2.Parameters.AddWithValue("@Servicefail", serviceFail);
               // cmd2.Parameters.AddWithValue("@TrainEnrich", training);
                cmd2.Parameters.AddWithValue("@Note", TxtBxNotes.Text.ToString());
                id2 = Convert.ToInt16(cmd2.ExecuteScalar());
                lblErrMessage.Visible = true;
                lblErrMessage.Text = "Complete";
                lblErrMessage.Text = id2.ToString() + " Done" + hos.ToString() + TxtBxHOSViolation.Text;

                //if(TxtBxNotes.Text != "")
                //{
                //    SqlCommand cmd3 = new SqlCommand("sp_NewNotes", conn);
                //    cmd3.CommandType = System.Data.CommandType.StoredProcedure;
                //    cmd3.Parameters.AddWithValue("@IncidentNum", id2);
                //    //cmd3.Parameters.AddWithValue("@AddedBy", "ME");
                //    cmd3.Parameters.AddWithValue("@AddedDate", DateTime.Now.ToString("MM/dd/yyyy"));
                //    cmd3.Parameters.AddWithValue("@NoteText", TxtBxNotes.Text);
                //    cmd3.ExecuteNonQuery();
                //}
                conn.Close();
                //Response.Write("<script>alert('Complete!!!')</script>");
                Response.Write("<h2>DONT</h2>");
                

                Response.Redirect("Incident.aspx");
            }

            catch (Exception ex)
            {
                lblErrMessage.Visible = true;
                lblErrMessage.Text = ex.Message;
            }
        }

        protected void BtnGetData_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(Connector.ConString("wilsonlogistics"));
            SqlCommand cmd = new SqlCommand("sp_DriverLookup", conn);
            conn.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DriverCode", TxtBxDrCode.Text);

            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {
                TxtBxDrName.Text = sdr["DFN"].ToString();
                TxtBxFMInit.Text = sdr["Initials"].ToString();
                TxtBxFMName.Text = sdr["FMFN"].ToString();
                TxtBxFMCode.Text = sdr["ManagerCode"].ToString();
                TxtBxFleetCode.Text = sdr["Fleet"].ToString();
            }
            conn.Close();
        }
    }
}