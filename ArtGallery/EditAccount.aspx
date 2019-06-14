<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditAccount.aspx.cs" Inherits="ArtGallery.EditAccount" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        	Username:
			<asp:Label ID="lblUsername" runat="server" Text="Label"></asp:Label>
			<br />
			Current password :
			<asp:Label ID="lblcurr" runat="server" Text="Label"></asp:Label>
			<br />
			New password:
			<asp:TextBox ID="newPass" runat="server"></asp:TextBox>
			<br />
			<br />
			<asp:Button ID="updateBt" runat="server" OnClick="updateBt_Click" Text="Update" />
			<br />
			<br />
			<asp:Label ID="msg" runat="server" Text="Label"></asp:Label>
        </div>
    </form>
</body>
</html>
