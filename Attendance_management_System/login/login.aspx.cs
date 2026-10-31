using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

namespace Attendance_management_System.login
{
    public partial class login : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs2"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Check2(object sender, EventArgs e)
        {
            if (username.Text == "admin" && password.Text == "12345")
            {
                Response.Redirect("~/Admin/admin.aspx");
            }

            SqlConnection con = new SqlConnection(cs);
            string queryTeacher = "select * from teacher where username = @user and password = @pass";
            SqlCommand cmdTeacher = new SqlCommand(queryTeacher, con);
            cmdTeacher.Parameters.AddWithValue("@user", username.Text);
            cmdTeacher.Parameters.AddWithValue("@pass", password.Text);

            con.Open();
            SqlDataReader drTeacher = cmdTeacher.ExecuteReader();

            if (drTeacher.HasRows)
            {
                Session["Username"] = username.Text; // Store the username in session
                Response.Redirect("~/teacher/teacher.aspx");
            }
            con.Close();

            con.Open();
            string queryStudent = "select * from student where username = @user and password = @pass";
            SqlCommand cmdStudent = new SqlCommand(queryStudent, con);
            cmdStudent.Parameters.AddWithValue("@user", username.Text);
            cmdStudent.Parameters.AddWithValue("@pass", password.Text);

            SqlDataReader drStudent = cmdStudent.ExecuteReader();

            if (drStudent.HasRows)
            {
                Session["Username"] = username.Text; // Store the username in session
                Response.Redirect("~/student/student.aspx");
            }
            else
            {
                Response.Redirect("login.aspx");
            }

            con.Close();
        }
    }
}