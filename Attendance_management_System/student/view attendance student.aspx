<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="view attendance student.aspx.cs" Inherits="Attendance_management_System.student.ViewAttendanceStudent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
       body{
            background-image:url("background2.jpg");
            background-size:cover;
        }
       .center-gridview {
                margin: auto;
            }
       .lecture-box {
                border: 1px solid #ccc;
                border-radius: 5px;
                padding: 10px;
                margin-top: 20px;
                width: 200px;
                text-align: center;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <fieldset style="margin-right: 500px; margin-left: 500px; margin-top: 200px;border-radius: 65px; background-color: white; color: black;">    
        <div>
            <center><h2>View Attendance</h2></center>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="center-gridview">
                 <Columns>
                    <asp:BoundField DataField="name" HeaderText="Name" ItemStyle-HorizontalAlign="Center"/>
                    <asp:BoundField DataField="Attendance" HeaderText="Attendance" ItemStyle-HorizontalAlign="Center"/>
                </Columns>
            </asp:GridView>
            <center><div class="lecture-box">
                <label>Total Lecture:</label>
                <asp:Label ID="lblTotalLecture" runat="server" Text=""></asp:Label>
            </div></center>
        </div>
    </fieldset>  
    </form>
</body>
</html>
