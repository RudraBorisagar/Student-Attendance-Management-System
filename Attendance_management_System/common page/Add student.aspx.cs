using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Attendance_management_System.common_page
{
    public partial class Add_student : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Check2(object sender, EventArgs e)
        {
            // Get connection string from web.config
            string connectionString = ConfigurationManager.ConnectionStrings["dbcs2"].ConnectionString;

            // Get username and password from textboxes
            string usernameValue = username.Text;
            string passwordValue = password.Text;

            // Validate if passwords match
            if (passwordValue != TextBox1.Text)
            {
                // Passwords do not match
                Response.Write("<script>alert('Passwords do not match!');</script>");
                return;
            }

            // SQL query to insert data into student table
            string insertStudentQuery = "INSERT INTO student (username, password) VALUES (@username, @password)";

            // SQL query to insert data into student_Attendance table
            string insertAttendanceQuery = "INSERT INTO student_Attendance (name, Attendance) VALUES (@name, 0)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Insert data into student table
                using (SqlCommand command = new SqlCommand(insertStudentQuery, connection))
                {
                    // Add parameters to the SQL query
                    command.Parameters.AddWithValue("@username", usernameValue);
                    command.Parameters.AddWithValue("@password", passwordValue);

                    try
                    {
                        // Execute the command
                        int rowsAffected = command.ExecuteNonQuery();

                        // Check if data was inserted successfully
                        if (rowsAffected > 0)
                        {
                            // Insert data into student_Attendance table
                            using (SqlCommand attendanceCommand = new SqlCommand(insertAttendanceQuery, connection))
                            {
                                // Add parameter to the SQL query
                                attendanceCommand.Parameters.AddWithValue("@name", usernameValue);

                                // Execute the command
                                attendanceCommand.ExecuteNonQuery();
                            }

                            Response.Write("<script>alert('Student added successfully!');</script>");
                        }
                        else
                        {
                            Response.Write("<script>alert('Error adding student!');</script>");
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle any exceptions
                        Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
                    }
                }
            }
        }
    }
}