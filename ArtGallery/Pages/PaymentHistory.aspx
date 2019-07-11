    <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaymentHistory.aspx.cs" Inherits="ArtGallery.Pages.PaymentHistory" %>

<%@ Import Namespace="ArtGallery.Classes" %>
<%@ Import Namespace="ArtGallery.Util" %> 

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Art Gallery :: Payment History</title>
	<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.0/jquery.min.js"></script>
	<script src="JavaScript/PaymentHistory.js"></script>
	<link href="CSS/PaymentHistory.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css?family=Roboto+Condensed&display=swap" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server">
    <div class='header'>
      <a href='#' class='title'>ART-X</a>
      <a href='#' class='link'>WORKS</a>
      <a href='ArtistProfile.aspx?username=session' class='link'>ACCOUNT</a>
            <%
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

            <a href='Cart.aspx' class='link'>CART <sup><%= noOfItems %></sup></a>
    </div>

    <div class='heading'>
    	<a>PAYMENT HISTORY</a>
    	<img src='https://i.imgur.com/DXquOBN.png'>
    </div>

    <div class='container' id="container" runat="server">

      <div class='box'>
        <div class='details'>
          <div>
            <a class='text'>ORDER ID</a>
            <a class='value'>OR00013</a>
          </div>
          <div>
            <a class='text'>DATE</a>
            <a class='value'>22 Mar 2019</a>
          </div>
          <div>
            <a class='text'>ITEMS</a>
            <a class='value'>6 PCS</a>
          </div>
          <div>
            <a class='text'>TOTAL</a>
            <a class='value'>RM 231</a>
          </div>
        </div>

        <div class='artpieces'>

          <div class='artpiece'>
            <div class='left'>
              <img src='https://cdn.dribbble.com/users/15687/screenshots/6517934/ancient-ruins.png'>
            </div>
            <div class='right'>
              <a class='title'>Ancient Ruins</a>
              <a class='artist'>ROMAN KLCO</a>
              <a class='quantity'>2 PCS</a>
              <a class='subtotal'><span>SUBTOTAL</span> RM 76</a>
            </div>
          </div>

          <div class='artpiece'>
            <div class='left'>
              <img src='https://cdn.dribbble.com/users/15687/screenshots/6517934/ancient-ruins.png'>
            </div>
            <div class='right'>
              <a class='title'>Ancient Ruins</a>
              <a class='artist'>ROMAN KLCO</a>
              <a class='quantity'>2 PCS</a>
              <a class='subtotal'><span>SUBTOTAL</span> RM 76</a>
            </div>
          </div>

          <div class='artpiece'>
            <div class='left'>
              <img src='https://cdn.dribbble.com/users/15687/screenshots/6517934/ancient-ruins.png'>
            </div>
            <div class='right'>
              <a class='title'>Ancient Ruins</a>
              <a class='artist'>ROMAN KLCO</a>
              <a class='quantity'>2 PCS</a>
              <a class='subtotal'><span>SUBTOTAL</span> RM 76</a>
            </div>
          </div>

        </div>

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
