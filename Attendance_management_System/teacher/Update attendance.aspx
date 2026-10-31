<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Update attendance.aspx.cs" Inherits="Attendance_management_System.teacher.Update_attendance" %>

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
</style>
</head>
<body>
    <form id="form1" runat="server">
    <fieldset style="margin-right: 500px; margin-left: 500px; margin-top: 200px;border-radius: 65px; background-color: white; color: black;">
        <div>
            <asp:GridView ID="GridViewAttendance" runat="server" AutoGenerateColumns="False" CssClass="center-gridview">
                <Columns>
                    <asp:BoundField DataField="Name" HeaderText="Name" />
                    <asp:TemplateField HeaderText="Attendance">
                        <ItemTemplate>
                            <asp:RadioButtonList ID="rblAttendance" runat="server">
                                <asp:ListItem Text="Present" Value="Present"></asp:ListItem>
                                <asp:ListItem Text="Absent" Value="Absent"></asp:ListItem>
                            </asp:RadioButtonList>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            </br>
            <center><asp:Button ID="btnUpdateAttendance" runat="server" Text="Mark Attendance" OnClick="btnUpdateAttendance_Click" /></center>
        </div>
    </fieldset>
    </form>
</body>
</html>
