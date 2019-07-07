<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="ArtGallery.Pages.Cart" %>

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
                <a class='value'>6 PCS</a>
              </div>
              <div>
                <a class='stat'>TOTAL</a>
                <a class='value'>RM 231</a>
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
            <tr>

              <td>
                <a href='#'>
                  <asp:Image runat="server" ImageUrl='https://images.unsplash.com/photo-1536851101967-55988a52f455?ixlib=rb-1.2.1&auto=format&fit=crop&w=1936&q=80' />
                </a>
                <div class='details'>
            	    <div class='of_artpiece'>
                        <asp:Label ID="lblTitle1" runat="server" Text="Play Hard" CssClass="label title"></asp:Label>
                        <asp:Label ID="lblArtist1" runat="server" Text="ENISAURUS" CssClass="label artist"></asp:Label>
            	    </div>
            	    <div class='of_order'>
            		    <div class='quantity'>
                            <asp:Button ID="btnDecrement1" runat="server" Text="-" CssClass="decrement" />
            			    <a>2 PCS</a>
                            <asp:Button ID="btnIncrement1" runat="server" Text="+" CssClass="increment" />
            		    </div>
            		    <div class='subtotal'>
            			    <a class='caption'>SUBTOTAL</a>
                            <asp:Label ID="lblValue1" runat="server" Text="RM 76" CssClass="label value"></asp:Label>
            		    </div>
            	    </div>
                </div>
              </td>

              <td>
                <a href='#'>
                  <asp:Image runat="server" ImageUrl='https://images.unsplash.com/photo-1536851101967-55988a52f455?ixlib=rb-1.2.1&auto=format&fit=crop&w=1936&q=80' />
                </a>
                <div class='details'>
            	    <div class='of_artpiece'>
                        <asp:Label ID="lblTitle2" runat="server" Text="Play Hard" CssClass="label title"></asp:Label>
                        <asp:Label ID="lblArtist2" runat="server" Text="ENISAURUS" CssClass="label artist"></asp:Label>
            	    </div>
            	    <div class='of_order'>
            		    <div class='quantity'>
                            <asp:Button ID="btnDecrement2" runat="server" Text="-" CssClass="decrement" />
            			    <a>2 PCS</a>
                            <asp:Button ID="btnIncrement2" runat="server" Text="+" CssClass="increment" />
            		    </div>
            		    <div class='subtotal'>
            			    <a class='caption'>SUBTOTAL</a>
                            <asp:Label ID="lblValue2" runat="server" Text="RM 76" CssClass="label value"></asp:Label>
            		    </div>
            	    </div>
                </div>
              </td>

              <td>
                <a href='#'>
                  <asp:Image runat="server" ImageUrl='https://images.unsplash.com/photo-1536851101967-55988a52f455?ixlib=rb-1.2.1&auto=format&fit=crop&w=1936&q=80' />
                </a>
                <div class='details'>
            	    <div class='of_artpiece'>
                        <asp:Label ID="lblTitle3" runat="server" Text="Play Hard" CssClass="label title"></asp:Label>
                        <asp:Label ID="lblArtist3" runat="server" Text="ENISAURUS" CssClass="label artist"></asp:Label>
            	    </div>
            	    <div class='of_order'>
            		    <div class='quantity'>
                            <asp:Button ID="btnDecrement3" runat="server" Text="-" CssClass="decrement" />
            			    <a>2 PCS</a>
                            <asp:Button ID="btnIncrement3" runat="server" Text="+" CssClass="increment" />
            		    </div>
            		    <div class='subtotal'>
            			    <a class='caption'>SUBTOTAL</a>
                            <asp:Label ID="lblValue3" runat="server" Text="RM 76" CssClass="label value"></asp:Label>
            		    </div>
            	    </div>
                </div>
              </td>

            </tr>
            <tr>

              <td>
                <a href='#'>
                  <asp:Image runat="server" ImageUrl='https://images.unsplash.com/photo-1536851101967-55988a52f455?ixlib=rb-1.2.1&auto=format&fit=crop&w=1936&q=80' />
                </a>
                <div class='details'>
            	    <div class='of_artpiece'>
                        <asp:Label ID="lblTitle4" runat="server" Text="Play Hard" CssClass="label title"></asp:Label>
                        <asp:Label ID="lblArtist4" runat="server" Text="ENISAURUS" CssClass="label artist"></asp:Label>
            	    </div>
            	    <div class='of_order'>
            		    <div class='quantity'>
                            <asp:Button ID="btnDecrement4" runat="server" Text="-" CssClass="decrement" />
            			    <a>2 PCS</a>
                            <asp:Button ID="btnIncrement4" runat="server" Text="+" CssClass="increment" />
            		    </div>
            		    <div class='subtotal'>
            			    <a class='caption'>SUBTOTAL</a>
                            <asp:Label ID="lblValue4" runat="server" Text="RM 76" CssClass="label value"></asp:Label>
            		    </div>
            	    </div>
                </div>
              </td>

              <td>
                <a href='#'>
                  <asp:Image runat="server" ImageUrl='https://images.unsplash.com/photo-1536851101967-55988a52f455?ixlib=rb-1.2.1&auto=format&fit=crop&w=1936&q=80' />
                </a>
                <div class='details'>
            	    <div class='of_artpiece'>
                        <asp:Label ID="lblTitle5" runat="server" Text="Play Hard" CssClass="label title"></asp:Label>
                        <asp:Label ID="lblArtist5" runat="server" Text="ENISAURUS" CssClass="label artist"></asp:Label>
            	    </div>
            	    <div class='of_order'>
            		    <div class='quantity'>
                            <asp:Button ID="btnDecrement5" runat="server" Text="-" CssClass="decrement" />
            			    <a>2 PCS</a>
                            <asp:Button ID="btnIncrement5" runat="server" Text="+" CssClass="increment" />
            		    </div>
            		    <div class='subtotal'>
            			    <a class='caption'>SUBTOTAL</a>
                            <asp:Label ID="lblValue5" runat="server" Text="RM 76" CssClass="label value"></asp:Label>
            		    </div>
            	    </div>
                </div>
              </td>

              <td>
                <a href='#'>
                  <asp:Image runat="server" ImageUrl='https://images.unsplash.com/photo-1536851101967-55988a52f455?ixlib=rb-1.2.1&auto=format&fit=crop&w=1936&q=80' />
                </a>
                <div class='details'>
            	    <div class='of_artpiece'>
                        <asp:Label ID="lblTitle6" runat="server" Text="Play Hard" CssClass="label title"></asp:Label>
                        <asp:Label ID="lblArtist6" runat="server" Text="ENISAURUS" CssClass="label artist"></asp:Label>
            	    </div>
            	    <div class='of_order'>
            		    <div class='quantity'>
                            <asp:Button ID="btnDecrement6" runat="server" Text="-" CssClass="decrement" />
            			    <a>2 PCS</a>
                            <asp:Button ID="btnIncrement6" runat="server" Text="+" CssClass="increment" />
            		    </div>
            		    <div class='subtotal'>
            			    <a class='caption'>SUBTOTAL</a>
                            <asp:Label ID="lblValue6" runat="server" Text="RM 76" CssClass="label value"></asp:Label>
            		    </div>
            	    </div>
                </div>
              </td>

            </tr>
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
