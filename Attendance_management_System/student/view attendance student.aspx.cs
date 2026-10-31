using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration; // Make sure to include this namespace for ConfigurationManager

namespace Attendance_management_System.student
{
    public partial class ViewAttendanceStudent : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs2"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string studentName = Session["Username"]?.ToString();
                if (!string.IsNullOrEmpty(studentName))
                {
                    BindGridView(studentName);
                    DisplayTotalLecture(); // Call DisplayTotalLecture method here
                }
                else
                {
                    // Handle case when there is no username in session
                    Response.Write("No username found in session.");
                }
            }
        }

        private void BindGridView(string studentName)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = "SELECT name, Attendance FROM student_Attendance WHERE name = @studentName";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@studentName", studentName);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    GridView1.DataSource = rdr;
                    GridView1.DataBind();
                }
                else
                {
                    // Handle case when there are no attendance records for the student
                    Response.Write("No attendance data available for " + studentName + ".");
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