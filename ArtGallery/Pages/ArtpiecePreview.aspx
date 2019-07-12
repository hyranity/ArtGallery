<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ArtpiecePreview.aspx.cs" MasterPageFile="~/Pages/ArtGallery.Master" Inherits="ArtGallery.Pages.ArtpiecePreview" %>

<%@ Import Namespace="ArtGallery.Classes" %>
<%@ Import Namespace="ArtGallery.Util" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <title>Art Gallery :: Artpiece Preview</title>
	<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.0/jquery.min.js"></script>
	<script src="JavaScript/ArtpiecePreview.js"></script>
	<link href="CSS/ArtpiecePreview.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css?family=Roboto+Condensed&display=swap" rel="stylesheet">
		    <div class='container'>
			    <div id='image'>
				    <img src='https://images.unsplash.com/photo-1526304760382-3591d3840148?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=1950&q=80'>
			    </div>
			    <div id='details'>
                    <asp:Label ID="lblType" runat="server" CssClass="label type">ILLUSTRATION</asp:Label>
                    <asp:Label ID="lblTitle" runat="server" CssClass="label title">Prism Hand</asp:Label>
                    <asp:Label ID="lblArtist" runat="server" CssClass="label artist">GUSTAVO CENTURION</asp:Label>
                    <asp:Label ID="lblDescription" runat="server" CssClass="label description">My latest street art piece!</asp:Label>
				    <div class='tags'>
					    <a href='#' class='sale'>FOR SALE</a>
					    <a href='#' class='tag'>ILLUSRATION</a>
					    <a href='#' class='tag'>MODERN</a>
					    <br>
					    <a href='#' class='tag'>COLOUR</a>
					    <a href='#' class='tag'>ABSTRACT</a>
				    </div>
			    </div>
		    </div>
</asp:Content>
