<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestRepeater.aspx.cs" Inherits="ArtGallery.TestRepeater" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
</head>
<body>
	<form id="form1" runat="server">
		<div>
			<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [ARTIST]" OnSelecting="SqlDataSource1_Selecting"></asp:SqlDataSource>
		</div>
		<asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ARTISTID" DataSourceID="SqlDataSource1">
			<Columns>
				<asp:BoundField DataField="ARTISTID" HeaderText="ARTISTID" ReadOnly="True" SortExpression="ARTISTID" />
				<asp:BoundField DataField="BIO" HeaderText="BIO" SortExpression="BIO" />
				<asp:BoundField DataField="FNAME" HeaderText="FNAME" SortExpression="FNAME" />
				<asp:BoundField DataField="LNAME" HeaderText="LNAME" SortExpression="LNAME" />
				<asp:BoundField DataField="EMAIL" HeaderText="EMAIL" SortExpression="EMAIL" />
				<asp:BoundField DataField="PASSWD" HeaderText="PASSWD" SortExpression="PASSWD" />
				<asp:CheckBoxField DataField="ACTIVE" HeaderText="ACTIVE" SortExpression="ACTIVE" />
			</Columns>
		</asp:GridView>
	</form>
</body>
</html>
