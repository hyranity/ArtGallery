<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ArtGalleryApp.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 147px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="width:100%;">
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="lblUsername" runat="server" Text="Username"></asp:Label>
                    </td>
                    <td>
                        <input id="username" name="username" type="text" /></td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
                    </td>
                    <td>
                        <input id="password" name="password" type="text" /></td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td>
                        <input id="login" type="submit" value="Login" runat="server" onserverclick="login_Click"/></td>
                </tr>
            </table>
        </div>
    	<asp:Label ID="loginText" runat="server" Text="Label"></asp:Label>
    </form>
</body>
</html>
