<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ThankYou.aspx.cs" MasterPageFile="~/Pages/ArtGallery.Master" Inherits="ArtGallery.Pages.ThankYou" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <title>Art Gallery :: Thank You</title>
	<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.0/jquery.min.js"></script>
	<script src="JavaScript/ThankYou.js"></script>
	<link href="CSS/ThankYou.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css?family=Roboto+Condensed&display=swap" rel="stylesheet">

        <div class='container'>
          <a class='title'>THANK YOU!</a>
          <a class='description'>Thank you for your purchase.</a>
          <asp:Button ID="btnProceed" runat="server" Text="Proceed" />
        </div>

</asp:Content>
