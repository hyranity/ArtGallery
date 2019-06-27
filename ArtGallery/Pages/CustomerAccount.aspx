<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerAccount.aspx.cs" Inherits="ArtGallery.Pages.CustomerAccount" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
	<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.0/jquery.min.js"></script>
	<script src="JavaScript/CustomerAccount.js"></script>
	<link href="CSS/CustomerAccount.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css?family=Roboto+Condensed&display=swap" rel="stylesheet">
</head>
<body>
	<form runat="server">
		<div class='header'>
			<a href='#' class='title'>ART-X</a>
			<a href='#' class='link'>WORKS</a>
			<a href='#' class='link'>ACCOUNT</a>
		</div>

		<div class='card'>
			<asp:Label ID="lblUsername" runat="server" CssClass="handle labels"></asp:Label>
			<div id='main'>
				<img src='https://pbs.twimg.com/profile_images/1055263632861343745/vIqzOHXj.jpg'>
				<asp:Label ID="lblName" runat="server" CssClass="name labels"></asp:Label>
			</div>
            <asp:Label ID="lblLocation" runat="server" CssClass="label location">NEW YORK CITY, USA</asp:Label>
			<asp:Label ID="lblBio" runat="server" CssClass="label bio"></asp:Label>
			<div id='tags'>
				<a class='tag'>UI</a>
				<a class='tag'>UX</a>
				<a class='tag'>DESIGN</a>
				<a class='tag'>WEB</a>
				<a class='tag'>MOBILE</a>
			</div>
			<div id='topstats'>
				<div>
                    <asp:Label ID="lblNumberArtpiecesBought" runat="server" CssClass="label number">23</asp:Label>
                    <asp:Label ID="lblStatArtpiecesBought" runat="server" CssClass="label stat">ARTPIECES<br />BOUGHT</asp:Label>
				</div>
				<div>
                    <asp:Label ID="lblNumberFollowing" runat="server" CssClass="label number">48</asp:Label>
                    <asp:Label ID="lblStatFollowing" runat="server" CssClass="label stat">FOLLOWING</asp:Label>
				</div>
			</div>
			<div id='bottomstats'>
				<div>
                    <asp:Label ID="lblNumberArtpiecesLiked" runat="server" CssClass="label number">184</asp:Label>
                    <asp:Label ID="lblStatArtpiecesLiked" runat="server" CssClass="label stat">ARTPIECES<br />LIKED</asp:Label>
				</div>
				<div>
                    <asp:Label ID="lblNumberArtpiecesWhitelisted" runat="server" CssClass="label number">74</asp:Label>
                    <asp:Label ID="lblStatArtpiecesWhitelisted" runat="server" CssClass="label stat">ARTPIECES<br />WHITELISTED</asp:Label>
				</div>
			</div>
			<a href='#' class='back'>BACK TO PROFILE</a>
		</div>

		<div class='purple'>
			<div class='container'>
				<div style='display: flex; flex-direction: row;'>
					<div id='left'>
						<asp:TextBox ID="id" Placeholder="id" runat="server"></asp:TextBox>
						<img src='https://image.flaticon.com/icons/svg/3/3897.svg'>
						<asp:TextBox ID="username" Placeholder="username" runat="server"></asp:TextBox>
						<img src='https://image.flaticon.com/icons/svg/3/3897.svg'>
						<asp:TextBox ID="displayName" Placeholder="display name" runat="server"></asp:TextBox>
						<img src='https://image.flaticon.com/icons/svg/3/3897.svg'>
						<a class='text'>CUSTOMER<br>
							ACCOUNT</a>
					</div>
					<div id='center'>
						<asp:Button ID="btnEdit" runat="server" Text="UPDATE DETAILS" />
					</div>
					<div id='right'>
						<a href='#' class='text'>LOGOUT</a>
						<asp:TextBox ID="password" TextMode="Password" Placeholder="new password" runat="server"></asp:TextBox>
						<img src='https://image.flaticon.com/icons/svg/3/3897.svg'>
						<asp:TextBox ID="email" Placeholder="email" runat="server"></asp:TextBox>
						<img src='https://image.flaticon.com/icons/svg/3/3897.svg'>
						<asp:TextBox ID="cardNo" Placeholder="card no" runat="server"></asp:TextBox>
                        <img src='https://image.flaticon.com/icons/svg/3/3897.svg'>
					</div>
				</div>
			</div>
		</div>
	</form>
</body>
</html>
