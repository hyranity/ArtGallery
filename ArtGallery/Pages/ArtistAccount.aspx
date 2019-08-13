<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ArtistAccount.aspx.cs" MasterPageFile="~/Pages/ArtGallery.Master" Inherits="ArtGallery.Pages.ArtistAccount" %>

<%@ Import Namespace="ArtGallery.Classes" %>
<%@ Import Namespace="ArtGallery.Util" %> 

<asp:Content ContentPlaceHolderID="MainContent" runat="server">

    <title>Art Gallery :: Artist Account</title>
	<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.0/jquery.min.js"></script>
	<script src="JavaScript/CustomerAccount.js"></script>
	<link href="CSS/CustomerAccount.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css?family=Roboto+Condensed&display=swap" rel="stylesheet"/>


		<div class='card'>
                 <!-- ERROR MESSAGE -->
                <asp:Label ID="lblEditError" runat="server" Text="error msg" CssClass="label errorMsg"></asp:Label>
			<asp:Label ID="lblUsername" runat="server" CssClass="label handle"></asp:Label>
			<div id='main'>
				<!--<img src='https://pbs.twimg.com/profile_images/1055263632861343745/vIqzOHXj.jpg'>-->
				<asp:Label ID="lblName" runat="server" CssClass="label name"></asp:Label>
			</div>
            <!--<asp:Label ID="lblLocation" runat="server" CssClass="label location">NEW YORK CITY, USA</asp:Label>-->
			<asp:Label ID="lblBio" runat="server" CssClass="label bio"></asp:Label>
			<!--<div id='tags'>
				<a class='tag'>UI</a>
				<a class='tag'>UX</a>
				<a class='tag'>DESIGN</a>
				<a class='tag'>WEB</a>
				<a class='tag'>MOBILE</a>
			</div>-->
			<!--<div id='topstats'>
				<div>
                    <asp:Label ID="lblNumberArtpiecesPosted" runat="server" CssClass="label number">23</asp:Label>
                    <asp:Label ID="lblStatArtpiecesPosted" runat="server" CssClass="label stat">ARTPIECES<br />POSTED</asp:Label>
				</div>
				<div>
                    <asp:Label ID="lblNumberFollowers" runat="server" CssClass="label number">1.5k</asp:Label>
                    <asp:Label ID="lblStatFollowers" runat="server" CssClass="label stat">FOLLOWERS</asp:Label>
				</div>
			</div>
			<div id='bottomstats'>
				<div>
                    <asp:Label ID="lblNumberArtpiecesLiked" runat="server" CssClass="label number">184</asp:Label>
                    <asp:Label ID="lblStatArtpiecesLiked" runat="server" CssClass="label stat">ARTPIECES<br />LIKED</asp:Label>
				</div>
				<div>
                    <asp:Label ID="lblNumberSales" runat="server" CssClass="label number">312</asp:Label>
                    <asp:Label ID="lblStatSales" runat="server" CssClass="label stat">SALES</asp:Label>
				</div>
				<div>
                    <asp:Label ID="lblNumberFollowing" runat="server" CssClass="label number">74</asp:Label>
                    <asp:Label ID="lblStatFollowing" runat="server" CssClass="label stat">FOLLOWING</asp:Label>
				</div>
			</div>-->
			<%
				string link = "";

				Artist artist = (Artist)Net.GetSession("artist");

				link = "ArtistProfile.aspx?username=" + artist.Username;
			%>
            <a href='<%= link %>' class='back'>BACK TO PROFILE</a>
		</div>

		<div class='purple'>
			<div class='container'>
				<div style='display: flex; flex-direction: row;'>
					<div id='left'>
						<asp:TextBox ID="username" Placeholder="username" MaxLength="40" runat="server"></asp:TextBox>
						<img src='https://image.flaticon.com/icons/svg/3/3897.svg'>
						<asp:TextBox ID="displayName" Placeholder="display name" MaxLength="40" runat="server"></asp:TextBox>
						<img src='https://image.flaticon.com/icons/svg/3/3897.svg'>
						<a class='text'>ARTIST<br>
							ACCOUNT</a>
					</div>
					<div id='center'>
						<asp:Button ID="btnEdit" runat="server" Text="UPDATE DETAILS" OnClick="btnEdit_Click" />
					</div>
					<div id='right'>
						<a href='Logout.aspx' class='text'>LOGOUT</a>
						<asp:TextBox ID="password" TextMode="Password" MaxLength="100" Placeholder="new password" runat="server"></asp:TextBox>
						<img src='https://image.flaticon.com/icons/svg/3/3897.svg'>
						<asp:TextBox ID="email" Placeholder="email" MaxLength="100" runat="server"></asp:TextBox>
						<img src='https://image.flaticon.com/icons/svg/3/3897.svg'>
						<!--<asp:TextBox ID="skills" Placeholder="skills" runat="server"></asp:TextBox>
						<img src='https://image.flaticon.com/icons/svg/3/3897.svg'>-->
						<asp:TextBox ID="bio" Placeholder="bio" MaxLength="200" runat="server"></asp:TextBox>
						<img src='https://image.flaticon.com/icons/svg/3/3897.svg'>
					</div>
				</div>
			</div>
		</div>
</asp:Content>

