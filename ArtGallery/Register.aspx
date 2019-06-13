<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="ArtGalleryApp.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 131px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="width: 100%;">
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="Label1" runat="server" Text="Username"></asp:Label>
                    </td>
                    <td>
                        <input id="username" name="username" type="text" /></td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="Label2" runat="server" Text="Email"></asp:Label>
                    </td>
                    <td>
                        <input id="email" name="email" type="text" /></td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="Label3" runat="server" Text="Password"></asp:Label>
                    </td>
                    <td>
                        <input id="password" name="password" type="text" /></td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td>
                        <input id="register" type="submit" value="Register" runat="server" onserverclick="submit_Click"/></td>
                </tr>
            </table>
        </div>
    	<asp:FormView ID="FormView1" runat="server" DataKeyNames="username" DataSourceID="SqlDataSource1" DefaultMode="Insert">
			<EditItemTemplate>
				username:
				<asp:Label ID="usernameLabel1" runat="server" Text='<%# Eval("username") %>' />
				<br />
				password:
				<asp:TextBox ID="passwordTextBox" runat="server" Text='<%# Bind("password") %>' />
				<br />
				<asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				&nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</EditItemTemplate>
			<InsertItemTemplate>
				username:
				<asp:TextBox ID="usernameTextBox" runat="server" Text='<%# Bind("username") %>' />
				<br />
				password:
				<asp:TextBox ID="passwordTextBox" runat="server" Text='<%# Bind("password") %>' />
				<br />
				<asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				&nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</InsertItemTemplate>
			<ItemTemplate>
				username:
				<asp:Label ID="usernameLabel" runat="server" Text='<%# Eval("username") %>' />
				<br />
				password:
				<asp:Label ID="passwordLabel" runat="server" Text='<%# Bind("password") %>' />
				<br />

			</ItemTemplate>
		</asp:FormView>
		<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" InsertCommand="INSERT INTO Customer(username, password) VALUES (@username, @password)" SelectCommand="SELECT * FROM [Customer]">
			<InsertParameters>
				<asp:Parameter Name="username" />
				<asp:Parameter Name="password" />
			</InsertParameters>
		</asp:SqlDataSource>
    </form>
</body>
</html>
