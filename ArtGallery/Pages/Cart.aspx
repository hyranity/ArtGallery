<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="ArtGallery.Pages.Cart" %>

<%@ Import Namespace="ArtGallery.Classes" %>
<%@ Import Namespace="ArtGallery.Daos" %>
<%@ Import Namespace="ArtGallery.Util" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Art Gallery :: Cart</title>
	<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.0/jquery.min.js"></script>
	<script src="JavaScript/Cart.js"></script>
	<link href="CSS/Cart.css" rel="stylesheet" />
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

          <div class='purple'>

            <div id='left'>
              <a id='heading'>YOUR CART</a>
              <img src='https://i.imgur.com/DXquOBN.png'>
              <a href='#' id='back'>CONTINUE BROWSING</a>
            </div>

            <div id='centre'>
              <div>
                <a class='stat'>ITEMS</a>
                <asp:Label ID="lblItems" runat="server" Text="0 PCS" CssClass="label value"></asp:Label>
              </div>
              <div>
                <a class='stat'>TOTAL</a>
                <asp:Label ID="lblPrice" runat="server" Text="RM 0" CssClass="label value"></asp:Label>
              </div>
            </div>

            <div id='right'>
              <div id='image'>
              </div>
              <div id='text'>
                <a href='#'>CHECKOUT</a>
                <img src='https://i.imgur.com/DXquOBN.png'>
              </div>
            </div>

          </div>

          <table class='gallery'>
            <%
                int indexCounter = 0;

                foreach (Order_Artwork orderArtwork in oaList)
                {
                    // Get corresponding artpiece and artist
                    Artpiece artpiece = artpieceDao.Get("ArtpieceId", orderArtwork.ArtpieceId);
                    Artist artist = artistDao.Get("ArtistId", artpiece.ArtistId);

                    if (indexCounter % 3 == 0)
                    {
                        %> <tr> <%
                    }
                    %>
                        <td>
                            <a href="#">
                                <asp:Image runat="server" ImageUrl='<%= artpiece.ImageUrl %>' />
                            </a>
                            <div class="details">
                                <div class="of_artpiece">
                                    <asp:Label ID='<%= "lblTitle" + indexCounter %>' runat="server" Text='<%= artpiece.Title %>' CssClass='label title'></asp:Label>
                                    <asp:Label ID='<%= "lblArtist" + indexCounter %>' runat="server" Text='<%= artist.DisplayName %>' CssClass='label artist'></asp:Label>
                                </div>
            	                <div class='of_order'>
            		                <div class='quantity'>
                                        <asp:Button ID='<%= "btnDecrement" + indexCounter %>' runat='server' Text='-' CssClass='decrement'  />
            			                <a><%= orderArtwork.Quantity %> PCS</a>
                                        <asp:Button ID='<%= "btnIncrement" + indexCounter %>' runat='server' Text='+' CssClass='increment' />
            		                </div>
            		                <div class='subtotal'>
            			                <a class='caption'>SUBTOTAL</a>
                                        <asp:Label ID='<%= "lblSubtotal" + indexCounter %>' runat='server' Text='<%= "RM " + (artpiece.Price * (double)orderArtwork.Quantity) %>' CssClass='label value'></asp:Label>
            		                </div>
            	                </div>
                            </div>
                        </td>
                    <%
                    if (indexCounter % 3 == 0)
                    {
                        %> </tr> <%
                    }
                }
            %>
          </table>

        </div>

        <div class='footer'>
          <a href='#' class='link'>ABOUT</a>
          <a href='#' class='text'>ART-X 2019</a>
          <a href='#' class='link'>FAQ</a>
        <div>
    </form>
</body>
</html>
