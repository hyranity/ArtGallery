<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ArtistHeader.ascx.cs" Inherits="ArtGallery.Pages.UserControls.ArtistHeader" %>

<%@ Import Namespace="ArtGallery.Classes" %>
<%@ Import Namespace="ArtGallery.Util" %>

<div class='header'>
			<a href='Home.aspx' class='title'>ART-X</a>
			<a href='AllGallery.aspx' class='link'>WORKS</a>
			<%
				string link = "";

                Artist artist = (Artist)Net.GetSession("artist");

				link = "ArtistProfile.aspx?username=" + artist.Username;
			%>
			<a href='<%= link %>' class='link'>PROFILE</a>

			<a href="ArtistAccount.aspx" class="link">ACCOUNT DETAILS</a>

			<a href="Upload.aspx" class="link">UPLOAD</a>

		</div>