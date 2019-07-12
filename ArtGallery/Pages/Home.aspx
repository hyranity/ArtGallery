<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" MasterPageFile="~/Pages/ArtGallery.Master" Inherits="ArtGallery.Pages.Home" %>

<%@ Import Namespace="ArtGallery.Classes" %>
<%@ Import Namespace="ArtGallery.Util" %> 

<asp:Content ContentPlaceHolderID="MainContent" runat="server" >
    <title>Art Gallery :: Home</title>
	<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.0/jquery.min.js"></script>
	<script src="JavaScript/Home.js"></script>
	<link href="CSS/Home.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css?family=Roboto+Condensed&display=swap" rel="stylesheet"/>

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

</asp:Content>