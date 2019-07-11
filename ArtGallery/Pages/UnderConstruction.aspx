<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UnderConstruction.aspx.cs" Inherits="ArtGallery.Pages.UnderConstruction" %>

<%@ Import Namespace="ArtGallery.Classes" %>
<%@ Import Namespace="ArtGallery.Util" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Art Gallery :: Under Construction</title>
	<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.0/jquery.min.js"></script>
	<script src="JavaScript/UnderConstruction.js"></script>
	<link href="CSS/UnderConstruction.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css?family=Roboto+Condensed&display=swap" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
        <div>
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

            <div class="container">
                <a class="text">It appears that this page is still under construction!</a>
                <a href="Home.aspx" class="link">BACK TO HOMEPAGE</a>
            </div>

            <div class='footer'>
              <a href='UnderConstruction.aspx' class='link'>ABOUT</a>
              <a href='Home.aspx' class='text'>ART-X 2019</a>
              <a href='UnderConstruction.aspx' class='link'>FAQ</a>
            </div>
        </div>
    </form>
</body>
</html>
