using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Attendance_management_System.Admin
{
    public partial class Add_teacher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Check2(object sender, EventArgs e)
        {
            // Get connection string from Web.config file
            string connectionString = ConfigurationManager.ConnectionStrings["dbcs2"].ConnectionString;

            // Get values from textboxes
            string uname = username.Text;
            string pwd = password.Text;

            // SQL query to insert data into teacher table
            string query = "INSERT INTO teacher (username, password) VALUES (@Username, @Password)";

            // Create SqlConnection object
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Create SqlCommand object
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters
                    command.Parameters.AddWithValue("@Username", uname);
                    command.Parameters.AddWithValue("@Password", pwd);

                    // Open connection
                    connection.Open();

                    // Execute query
                    int result = command.ExecuteNonQuery();

                    // Check if data is inserted successfully
                    if (result > 0)
                    {
                        Response.Write("<script>alert('Teacher added successfully');</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('Error adding teacher');</script>");
                    }
                }
            }
        }
    }
}