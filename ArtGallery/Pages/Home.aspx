<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ArtGallery.Pages.Home" %>

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
      <a href='#' class='title'>ART-X</a>
      <a href='#' class='link'>WORKS</a>
      <a href='#' class='link'>ACCOUNT</a>
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
        <a href='#'>VIEW GALLERY</a>
        <img src='https://i.imgur.com/DXquOBN.png'>
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
