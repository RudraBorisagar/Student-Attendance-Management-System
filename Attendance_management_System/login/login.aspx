<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Attendance_management_System.login.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Attendance management System</title>
    <style>
        body {
            background-image:url("images/background2.jpg");
            background-size:cover;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <fieldset style="margin-right: 500px; margin-left: 500px; margin-top: 200px;border-radius: 65px; background-color: white; color: black;">
        <h1 style="color: #3563a9; margin-bottom:-36px;"><center>Welcome!</center></h1><br/>
        <h2 style="color: #0dc4e8;"><center>Log in to your account</center></h2><br/>
        <b><center><asp:TextBox runat="server" ID="username" TextMode="SingleLine" placeholder="   user_name   " style="border-radius: 25px;width:165px;height: 26px;margin-top: -10px;" ></asp:TextBox></center></b><br/>
        <b><center><asp:TextBox runat="server" ID="password" TextMode="Password" placeholder="   password   " style="border-radius: 25px;width:165px;height: 26px; margin-top: -5px;" ></asp:TextBox></center></b><br/>
        <center><asp:Button ID="Button1" runat="server" Text="submit" OnClick="Check2"/></center>
    </fieldset>    
    </form>
</body>
</html>
