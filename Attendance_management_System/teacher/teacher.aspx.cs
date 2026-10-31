using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Attendance_management_System.teacher
{
    public partial class teacher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Check2(object sender, EventArgs e)
        {
            Response.Redirect("Update attendance.aspx");
        }
        protected void Check3(object sender, EventArgs e)
        {
            Response.Redirect("~/Common page/view attendance.aspx");
        }
        protected void Check4(object sender, EventArgs e)
        {
            Response.Redirect("~/Common page/Add student.aspx");
        }
        protected void Check5(object sender, EventArgs e)
        {
            Response.Redirect("~/login/login.aspx");
        }
    }
}