using System;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Diagnostics;

namespace Attendance_management_System.teacher
{
    public partial class Update_attendance : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs2"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
            }
        }

        private void BindGridView()
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("SELECT Name, Attendance FROM student_Attendance", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridViewAttendance.DataSource = dt;
                GridViewAttendance.DataBind();
            }
        }

        private int GetCurrentAttendance(string studentName)
        {
            int currentAttendance = 0;

            using (SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand($"SELECT Attendance FROM student_Attendance WHERE Name = '{studentName}'", conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    currentAttendance = reader.GetInt32(0);
                }
            }

            return currentAttendance;
        }

        protected void btnUpdateAttendance_Click(object sender, EventArgs e)
        {
            int lectureIncrement = 1; // Increment value for lecture column

            foreach (GridViewRow row in GridViewAttendance.Rows)
            {
                RadioButtonList rblAttendance = (RadioButtonList)row.FindControl("rblAttendance");
                if (rblAttendance != null)
                {
                    string studentName = row.Cells[0].Text;
                    int newAttendance = 0;

                    if (rblAttendance.SelectedValue == "Present")
                    {
                        newAttendance = GetCurrentAttendance(studentName) + 1;
                    }
                    else if (rblAttendance.SelectedValue == "Absent")
                    {
                        newAttendance = GetCurrentAttendance(studentName);
                    }

                    Debug.WriteLine($"Updating attendance for {studentName}: New = {newAttendance}");

                    // Update student attendance
                    using (SqlConnection conn = new SqlConnection(cs))
                    {
                        string updateAttendanceQuery = "UPDATE student_Attendance SET Attendance = @Attendance WHERE Name = @Name";
                        SqlCommand cmd = new SqlCommand(updateAttendanceQuery, conn);
                        cmd.Parameters.AddWithValue("@Attendance", newAttendance);
                        cmd.Parameters.AddWithValue("@Name", studentName);
                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Debug.WriteLine($"Successfully updated attendance for {studentName}. Rows affected: {rowsAffected}");
                        }
                        else
                        {
                            Debug.WriteLine($"No rows updated for {studentName}. Check the WHERE clause.");
                        }
                    }
                }
            }

            // Update lecture count once outside the loop
            using (SqlConnection conn = new SqlConnection(cs))
            {
                string updateLectureQuery = "UPDATE total_lecture SET lecture = lecture + @Increment";
                SqlCommand updateLectureCmd = new SqlCommand(updateLectureQuery, conn);
                updateLectureCmd.Parameters.AddWithValue("@Increment", lectureIncrement);
                conn.Open();
                int lectureRowsAffected = updateLectureCmd.ExecuteNonQuery();
                if (lectureRowsAffected > 0)
                {
                    Debug.WriteLine($"Successfully updated lecture count.");
                }
                else
                {
                    Debug.WriteLine($"Failed to update lecture count.");
                }
            }

            // Rebind the GridView to reflect changes
            BindGridView();
        }
    }
}
