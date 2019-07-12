﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" MasterPageFile="~/Pages/ArtGallery.Master" Inherits="ArtGallery.Pages.Cart" %>

<%@ Import Namespace="ArtGallery.Classes" %>
<%@ Import Namespace="ArtGallery.Daos" %>
<%@ Import Namespace="ArtGallery.Util" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <title>Art Gallery :: Cart</title>
	<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.0/jquery.min.js"></script>
	<script src="JavaScript/Cart.js"></script>
	<link href="CSS/Cart.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css?family=Roboto+Condensed&display=swap" rel="stylesheet">
        <div class='container'>

          <div class='purple'>

            <div id='left'>
              <a id='heading'>YOUR CART</a>
              <img src='https://i.imgur.com/DXquOBN.png'>
              <a href="AllGallery.aspx" id='back'>CONTINUE BROWSING</a>
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
                <asp:Button Text="CHECKOUT" runat="server" ID="checkoutBt" OnClick="checkoutBt_Click"></asp:Button>
                <img src='https://i.imgur.com/DXquOBN.png'>
              </div>
				<asp:Button runat="server" ID="saveBt" Text="CONFIRM CART" OnClick="saveBt_Click" />
            </div>

          </div>
          <div id="gallery" runat="server">

          </div>

          <!-- <table class='gallery'>
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
                        <asp:Label ID="Label1" runat="server" Text="Play Hard" CssClass="label title"></asp:Label>
                        <asp:Label ID="Label2" runat="server" Text="ENISAURUS" CssClass="label artist"></asp:Label>
            	    </div>
            	    <div class='of_order'>
            		    <div class='quantity'>
                            <asp:Button ID="Button1" runat="server" Text="-" CssClass="decrement" />
            			    <a>2 PCS</a>
                            <asp:Button ID="Button2" runat="server" Text="+" CssClass="increment" />
            		    </div>
            		    <div class='subtotal'>
            			    <a class='caption'>SUBTOTAL</a>
                            <asp:Label ID="Label3" runat="server" Text="RM 76" CssClass="label value"></asp:Label>
            		    </div>
            	    </div>
                </div>
              </td>
            </tr>
          </table> -->

        </div>
</asp:Content>
