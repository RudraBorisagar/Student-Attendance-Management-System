using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Attendance_management_System
{
    public partial class ViewAttendance : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs2"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
                DisplayTotalLecture();
            }
        }

        private void BindGridView()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("SELECT name, Attendance FROM student_Attendance", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    GridView1.DataSource = rdr;
                    GridView1.DataBind();
                }
                else
                {
                    // Handle case when there is no data
                    Response.Write("No attendance data available.");
                }
            }
        }
        private void DisplayTotalLecture()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = "SELECT lecture FROM total_lecture";

                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    lblTotalLecture.Text = result.ToString();
                }
                else
                {
                    // Handle case when total lecture count is not available
                    lblTotalLecture.Text = "N/A";
                }
            }
        }
    }
}