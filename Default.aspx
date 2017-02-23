<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 60%;
        }
        .auto-style2 {
        }
        .auto-style3 {
            height: 26px;
        }
        .auto-style4 {
            width: 206px;
        }
        .auto-style5 {
            height: 26px;
            width: 206px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1 style="text-align:center;">Doctor Information Form</h1>
        <fieldset class="auto-style1">
            <legend>Doctor Infromatin</legend>
        <table class="auto-style1">
            <tr>
                <td class="auto-style4">Doctor ID :</td>
                <td>
                    <asp:TextBox ID="txtDId" runat="server"></asp:TextBox> *Search By 'Doctor ID' 
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Doctor Name :</td>
                <td>
                    <asp:TextBox ID="txtDName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style5">Email :</td>
                <td class="auto-style3">
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Appointed Date :</td>
                <td>
                    <asp:Literal ID="Literal2" runat="server"></asp:Literal>
                    <asp:Calendar ID="calSDay" runat="server"   OnLoad="calSDay_Load" OnSelectionChanged="calSDay_SelectionChanged" Height="71px" Width="160px"  ></asp:Calendar>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Department :</td>
                <td>
                    <asp:DropDownList ID="dlistDepartment" runat="server">
                        <asp:ListItem Selected="True">-- Please Select --</asp:ListItem>
                      
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Room No :</td>
                <td>
                    <asp:DropDownList ID="dListRoomNo" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="2">
                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                    <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search" />
                    <asp:Button ID="btnEdit" runat="server" Text="Edit" style="width: 37px" OnClick="btnEdit_Click" />
                    <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" OnClientClick="return confirm('The selected user information will be deleted. Do you wish to continue?'); return false;"/>
                    <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" />
                </td>
            </tr>
        </table>
              </fieldset>
        <br />

        <asp:Literal ID="Literal1" runat="server"></asp:Literal>

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="DoctorId" HeaderText="Doctor Id" />
                <asp:BoundField DataField="dName" HeaderText="Name" />
                <asp:BoundField DataField="dEmail" HeaderText="Email" />
                <asp:BoundField DataField="dScheduleDay" HeaderText="Appointed Date" />
                <asp:BoundField DataField="DepartmentName" HeaderText="Department Name" />
                <asp:BoundField DataField="RoomNo" HeaderText="Room No" />
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
