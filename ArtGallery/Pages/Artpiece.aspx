<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Artpiece.aspx.cs" Inherits="ArtGallery.Pages.Artpiece" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>Art Gallery :: Artpiece</title>
	<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.0/jquery.min.js"></script>
	<script src="JavaScript/Artpiece.js"></script>
	<link href="CSS/Artpiece.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css?family=Roboto+Condensed&display=swap" rel="stylesheet">
</head>

	<body>

        <form id="form1" runat="server">

		    <div class='header'>
			    <a href='#' class='title'>ART-X</a>
			    <a href='#' class='link'>WORKS</a>
			    <a href='#' class='link'>ACCOUNT</a>
		    </div>

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
					    <asp:Label runat="server" id="lblForSale" CssClass='sale'>FOR SALE</asp:Label>
					    <a href='#' class='tag'>ILLUSRATION</a>
					    <a href='#' class='tag'>MODERN</a>
					    <br>
					    <a href='#' class='tag'>COLOUR</a>
					    <a href='#' class='tag'>ABSTRACT</a>
				    </div>
				    <div class='buttons'>
					    <div>
						    <a href='#'>LIKE</a>
						    <img src='https://i.imgur.com/DXquOBN.png'>
					    </div>
					    <div>
						    <a href='#'>VIEW ARTIST</a>
						    <img src='https://i.imgur.com/DXquOBN.png'>
					    </div>
				    </div>
				    <div class='stats'>
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
				    </div>
			    </div>
		    </div>

		    <div class='footer'>
    	        <a href='#' class='link'>ABOUT</a>
     	        <a href='#' class='text'>ART-X 2019</a>
     	        <a href='#' class='link'>FAQ</a>
            <div>

        </form>

	</body>
</html>
