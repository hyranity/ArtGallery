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
          <img src='https://images.unsplash.com/photo-1524664399170-77e7118fdb6d?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=1350&q=80'>
          <div>
            <a class='title'>Art of the Paint</a>
            <a class='artist'>JOHANN LEE</a>
          </div>
        </div>
      </a>

      <a href='#'>
        <div id='two'>
          <img src='https://images.unsplash.com/photo-1526304760382-3591d3840148?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=1350&q=80'>
          <div>
            <a class='title'>Hand of Pink</a>
            <a class='artist'>JOHANN LEE</a>
          </div>
        </div>
      </a>

      <a href='#'>
        <div id='three'>
          <img src='https://images.unsplash.com/photo-1524664399170-77e7118fdb6d?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=1350&q=80'>
          <div>
            <a class='title'>Art of the Paint</a>
            <a class='artist'>JOHANN LEE</a>
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