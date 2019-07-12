<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UnderConstruction.aspx.cs" MasterPageFile="~/Pages/ArtGallery.Master" Inherits="ArtGallery.Pages.UnderConstruction" %>

<%@ Import Namespace="ArtGallery.Classes" %>
<%@ Import Namespace="ArtGallery.Util" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server" >
    <title>Art Gallery :: Under Construction</title>
	<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.0/jquery.min.js"></script>
	<script src="JavaScript/UnderConstruction.js"></script>
	<link href="CSS/UnderConstruction.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css?family=Roboto+Condensed&display=swap" rel="stylesheet">

        <div>

            <div class="container">
                <a class="text">It appears that this page is still under construction!</a>
                <a href="Home.aspx" class="link">BACK TO HOMEPAGE</a>
            </div>

        </div>
</asp:Content>
