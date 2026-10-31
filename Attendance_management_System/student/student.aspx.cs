using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Attendance_management_System.student
{
    public partial class student : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Check2(object sender, EventArgs e)
        {
            Response.Redirect("view attendance student.aspx");
        }
        protected void Check3(object sender, EventArgs e)
        {
            Response.Redirect("~/login/login.aspx");
        }
    }
}