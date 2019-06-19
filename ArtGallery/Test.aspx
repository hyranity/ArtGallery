<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="ArtGallery.Test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
		<p>
			FName:<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
		</p>
		<p>
			LName:<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
		</p>
		<p>
			Email:<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
		</p>
		<p>
			Password:<asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
		</p>
		<p>
			CreditCard:<asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
		</p>
		<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Register" />
	</form>
</body>
</html>
