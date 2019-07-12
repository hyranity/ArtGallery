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
			<a href='Home.aspx' class='title'>ART-X</a>
			<a href='AllGallery.aspx' class='link'>WORKS</a>
			<%
				string link = "";

				Customer customer = (Customer)Net.GetSession("customer");
                Artist artist = (Artist)Net.GetSession("artist");

				if (customer == null)
				{
					if (artist != null)
						link = "ArtistProfile.aspx?username=" + artist.Username;
					else
						link = "LoginRegister.aspx";
				}
				else
					link = "CustomerProfile.aspx?username=" + customer.Username;
			%>
			<a href='<%= link %>' class='link'>PROFILE</a>

			<%
				string url = "";
				bool isLoggedIn = false;

				if (customer == null)
				{
					if (artist != null)
					{
						url = "ArtistAccount.aspx";
						isLoggedIn = true;
					}
					else
						url = "LoginRegister.aspx";
				}
				else
				{
					url = "CustomerAccount.aspx";
					isLoggedIn = true;
				}

				// Only show the following if logged in
				if (isLoggedIn)
				{
			%>

			<a href="<%= url %>" class="link">ACCOUNT DETAILS</a>

			<%
				}


				if (customer != null)
				{
					List<Order_Artwork> oaList = (List<Order_Artwork>)Net.GetSession("oaList");
					int noOfItems = 0;
					if (oaList != null)
					{
						noOfItems = oaList.Count;
					}
					else
					{
						noOfItems = 0;
					}

			%>

			<a href='Cart.aspx' class='link'>CART <sup style="color: darkred;"><%= noOfItems %></sup></a>
			<%} %>

			<%

				if(customer != null)
				{
			%>

			<a href="paymenthistory.aspx" class="link">PAYMENT HISTORY</a>
			<%} %>

            <%

				if(artist != null)
				{
			%>

			<a href="Upload.aspx" class="link">UPLOAD</a>
			<%} %>
		</div>

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
                <asp:Button Text="CHECKOUT" runat="server" ID="checkoutBt" OnClick="checkoutBt_Click" />
                <img src='https://i.imgur.com/DXquOBN.png'>
                <asp:Button runat="server" ID="saveBt" Text="CONFIRM CART" OnClick="saveBt_Click" style="margin-top: 10px;" />
                <img src='https://i.imgur.com/DXquOBN.png'>
              </div>
            </div>

          </div>
          <div id="gallery" runat="server">
                 <!-- ERROR MESSAGE -->
                <asp:Label ID="lblErrorMsg" runat="server" CssClass="label errorMsg"></asp:Label>
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

        <div class='footer'>
          <a href='UnderConstruction.aspx' class='link'>ABOUT</a>
          <a href='Home.aspx' class='text'>ART-X 2019</a>
          <a href='UnderConstruction.aspx' class='link'>FAQ</a>
        </div>
    </form>
</body>
</html>
