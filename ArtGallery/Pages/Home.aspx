<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ArtGallery.Pages.Home" %>

<%@ Import Namespace="ArtGallery.Classes" %>
<%@ Import Namespace="ArtGallery.Util" %> 

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Art Gallery :: Home</title>
	<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.0/jquery.min.js"></script>
	<script src="JavaScript/Home.js"></script>
	<link href="CSS/Home.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css?family=Roboto+Condensed&display=swap" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server">
    <div class='header'>
      <a href='Home.aspx' class='title'>ART-X</a>
      <a href='AllGallery.aspx' class='link'>WORKS</a>
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

    <div class='featured'>

      <a href='#'>
        <div id='one'>
          <img src='https://cdn.dribbble.com/users/15687/screenshots/6517934/ancient-ruins.png'>
          <div>
            <a class='title'>Ancient Ruins</a>
            <a class='artist'>ROMAN KLCO</a>
          </div>
        </div>
      </a>

      <a href='#'>
        <div id='two'>
          <img src='https://cdn.dribbble.com/users/15687/screenshots/6517934/ancient-ruins.png'>
          <div>
            <a class='title'>Ancient Ruins</a>
            <a class='artist'>ROMAN KLCO</a>
          </div>
        </div>
      </a>

      <a href='#'>
        <div id='three'>
          <img src='https://cdn.dribbble.com/users/15687/screenshots/6517934/ancient-ruins.png'>
          <div>
            <a class='title'>Ancient Ruins</a>
            <a class='artist'>ROMAN KLCO</a>
          </div>
        </div>
      </a>

    </div>

    <div class='links'>
      <div>
        <a href='AllGallery.aspx'>VIEW GALLERY</a>
        <img src='https://i.imgur.com/DXquOBN.png'>
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
