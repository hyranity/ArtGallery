<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestRepeater.aspx.cs" Inherits="ArtGallery.TestRepeater" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
</head>
<body>
	<form id="form1" runat="server">
		<div>
			<asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1" OnItemCommand="Repeater1_ItemCommand">
				<HeaderTemplate>
					<table>
				</HeaderTemplate>
				<ItemTemplate>
					<!-- The following code is obtained from: Jeff Sternal @ https://stackoverflow.com/questions/1765942/how-do-you-show-x-items-per-row-in-a-repeater/1766379#1766379 -->
					<%# (Container.ItemIndex + 4) % 4 == 0 ? "<tr>" : string.Empty %>
					<td><%# Eval("ARTISTID") %></td>
					<%# (Container.ItemIndex + 4) % 4 == 3 ? "</tr>" : string.Empty %>
				</ItemTemplate>
				<FooterTemplate>
					</table>
				</FooterTemplate>
			</asp:Repeater>
			<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [ARTIST]"></asp:SqlDataSource>
		</div>
	</form>
</body>
</html>
