<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ArtpieceEdit.aspx.cs" MasterPageFile="~/Pages/ArtGallery.Master" Inherits="ArtGallery.Pages.ArtpieceEdit" %>

<%@ Import Namespace="ArtGallery.Classes" %>
<%@ Import Namespace="ArtGallery.Util" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">

	<title>Art Gallery :: Artpiece</title>
	<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.0/jquery.min.js"></script>
	<script src="JavaScript/Artpiece.js"></script>
	<link href="CSS/Artpiece.css" rel="stylesheet" />
	<link href="https://fonts.googleapis.com/css?family=Roboto+Condensed&display=swap" rel="stylesheet">

	<div class='container'>
		<div id='image'>
			<asp:Image runat="server" ID="artpieceImg" />
		</div>
		<div id='details'>
			<asp:Label ID="lblType" runat="server" CssClass="label type"></asp:Label>
			<asp:Label ID="lblTitle" runat="server" CssClass="label title"></asp:Label>
			<asp:Label ID="lblArtist" runat="server" CssClass="label artist"></asp:Label>
			<asp:Label ID="lblDescription" runat="server" CssClass="label description"></asp:Label>
			<div class='tags'>
				<asp:Label runat="server" ID="lblForSale" CssClass='label sale'>FOR SALE</asp:Label>

				<!--<a href='#' class='tag'>ILLUSRATION</a>
					<a href='#' class='tag'>MODERN</a>
					<br>
					<a href='#' class='tag'>COLOUR</a>
					<a href='#' class='tag'>ABSTRACT</a>-->
			</div>
			<div class='buttons'>
				<div>
					<asp:Button ID="btnEdit" runat="server" Text="SAVE EDIT" CssClass="button" OnClick="btnEdit_Click" />
					<img src='https://i.imgur.com/DXquOBN.png'>
				</div>
			</div>
			<!-- ERROR MESSAGE -->
			<asp:Label ID="lblEditError" runat="server" CssClass="label errorMsg"></asp:Label>

			<div class='stats'>
				<div>
					<asp:Label ID="Label2" runat="server" CssClass="label stat">RM </asp:Label>
					<asp:Label ID="lblArtpiecePrice" runat="server" CssClass="label number"></asp:Label>

				</div>
				
					
				<div>
					<asp:TextBox ID="txtStocks" runat="server" CssClass="label number" Width="100px">14</asp:TextBox>
					<asp:Label ID="lblStats" runat="server" CssClass="label stat">PCS LEFT</asp:Label>
				</div>
				<!--
					    <div>
                            <asp:Label ID="lblNumberViews" runat="server" CssClass="label number">1.3k</asp:Label>
                            <asp:Label ID="lblStatViews" runat="server" CssClass="label stat">VIEWS</asp:Label>
					    </div>
					    <div>
                            <asp:Label ID="lblNumberLikes" runat="server" CssClass="label number">357</asp:Label>
                            <asp:Label ID="lblStatLikes" runat="server" CssClass="label stat">LIKES</asp:Label>
					    </div>
					    <div>
                            <asp:Label ID="lblNumberSales" runat="server" CssClass="label number">42</asp:Label>
                            <asp:Label ID="lblStatSales" runat="server" CssClass="label stat">SALES</asp:Label>
					    </div>
						-->
			</div>
		</div>
	</div>
</asp:Content>
