<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="teacher.aspx.cs" Inherits="Attendance_management_System.teacher.teacher" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
       body{
            background-image:url("background2.jpg");
            background-size:cover;
        }
    </style>
</head>
<body>
    <form id="form2" runat="server">
    <fieldset style="margin-right: 500px; margin-left: 500px; margin-top: 200px;border-radius: 65px;background-color: white; color: black;">
        <h1 style="color: #3563a9; margin-bottom:10px;"><center>Welcome Teacher</center></h1><br/>
        <center><asp:Button ID="Button4" runat="server" Text="Mark attendance" OnClick="Check2"/></center><br/>
        <center><asp:Button ID="Button6" runat="server" Text="View attendance" OnClick="Check3"/></center><br/>
        <center><asp:Button ID="Button1" runat="server" Text="Add student" OnClick="Check4"/></center><br/>
        <center><asp:Button ID="Button2" runat="server" Text="logout" OnClick="Check5"/></center><br/>
    </fieldset>    
    </form>
</body>
</html>
