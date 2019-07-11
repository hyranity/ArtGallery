<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Upload.aspx.cs" Inherits="ArtGallery.Pages.Upload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Art Gallery :: Upload</title>
	<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.0/jquery.min.js"></script>
	<script src="JavaScript/Upload.js"></script>
	<link href="CSS/Upload.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css?family=Roboto+Condensed&display=swap" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
		<div class='header'>
      <a href='Home.aspx' class='title'>ART-X</a>
      <a href='AllGallery.aspx' class='link'>WORKS</a>
      <a href='ArtistProfile.aspx?username=session' class='link'>ACCOUNT</a>
		</div>

		<div class='container'>

			<div id='left'>
				<asp:Textbox ID="txtTitle" runat="server" Placeholder="title"></asp:Textbox>
				<img src='https://image.flaticon.com/icons/svg/3/3897.svg'>
                <asp:Textbox ID="txtDescription" runat="server" Placeholder="description"></asp:Textbox>
				<img src='https://image.flaticon.com/icons/svg/3/3897.svg'>
				<asp:Textbox ID="txtTags" runat="server" Placeholder="tags"></asp:Textbox>
				<img src='https://image.flaticon.com/icons/svg/3/3897.svg'>
			</div>

			<div id='center'>
				<asp:Button runat="server" ID="uploadBt" OnClick="uploadBt_Click" CssClass="upload" Text="UPLOAD"/>
                <asp:FileUpload runat="server" ID="fileBt" CssClass="file" Text="select file"/>
				<div id='category'>
					<div id='image'>
                        <!-- TBC -->
					</div>
					<div id='input'>
                        <!-- TBC -->
					</div>
				</div>
			</div>

			<div id='right'>
                <a>is public?</a>
                <asp:RadioButtonList ID="rblIsPublic" runat="server" CssClass="rblIsPublic" RepeatDirection="Horizontal">
                    <asp:ListItem>yes</asp:ListItem>
                    <asp:ListItem>no</asp:ListItem>
                </asp:RadioButtonList>
                <a>for sale?</a>
                <asp:RadioButtonList ID="rblForSale" runat="server" CssClass="rblForSale" RepeatDirection="Horizontal">
                    <asp:ListItem>yes</asp:ListItem>
                    <asp:ListItem>no</asp:ListItem>
                </asp:RadioButtonList>
				<asp:Textbox ID="txtStocks" runat="server" Placeholder="stocks"></asp:Textbox>
				<img src='https://image.flaticon.com/icons/svg/3/3897.svg'>
				<asp:Textbox ID="txtPrice" runat="server" Placeholder="price"></asp:Textbox>
				<img src='https://image.flaticon.com/icons/svg/3/3897.svg'>
			</div>

		</div>

    <div class='footer'>
      <a href='UnderConstruction.aspx' class='link'>ABOUT</a>
      <a href='Home.aspx' class='text'>ART-X 2019</a>
      <a href='UnderConstruction.aspx' class='link'>FAQ</a>
    <div>
    </form>
</body>
</html>
