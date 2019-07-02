﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AllGallery.aspx.cs" Inherits="ArtGallery.Pages.AllGallery" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Art Gallery :: All Gallery</title>
	<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.0/jquery.min.js"></script>
	<script src="JavaScript/AllGallery.js"></script>
	<link href="CSS/AllGallery.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css?family=Roboto+Condensed&display=swap" rel="stylesheet">
</head>

<body>
	<form id="form1" runat="server">
		<div class='header'>
			<a href='#' class='title'>ART-X</a>
			<a href='#' class='link'>WORKS</a>
			<a href='#' class='link'>ACCOUNT</a>
		</div>
		<table class='text'>
			<tr>
				<td id='title'>
					<a>ILLUSTRATION</a>
				</td>
				<td id='quote'>
					<a id='content'>"Painting is the silence of thought<br>
						and the music of sight."</a><br>
					<a id='name'>ORHAN PAMUK</a>
				</td>
			</tr>
			<tr>
				<td id='description'>
					<a>Brawn, painted;<br>
						blood, sweat and tears.</a>
				</td>
				<td id='stats'>
					<div>
						<a class='number'>95</a>
						<a class='stat'>ARTPIECES<br>
							THIS WEEK</a>
					</div>
					<div>
						<a class='number'>86</a>
						<a class='stat'>ARTISTS<br>
							THIS WEEK</a>
					</div>
				</td>
			</tr>
		</table>

		<asp:Repeater ID="ArtRepeater" runat="server">
			<HeaderTemplate>
				<table class='gallery'>
			</HeaderTemplate>
			<ItemTemplate>
				<!-- The following code is obtained from: Jeff Sternal @ https://stackoverflow.com/questions/1765942/how-do-you-show-x-items-per-row-in-a-repeater/1766379#1766379 -->
				<%# (Container.ItemIndex + 3) % 3 == 0 ? "<tr>" : string.Empty %>
				<td>
					<a href='#'>
						<asp:Image runat="server" ImageUrl='<%# Eval("URL") %>' />
						
						<div class='box'>
							<a class='artpiece'><%# Eval("TITLE") %></a>
							<a class='artist'><%# Eval("Username") %> <%# Eval("DisplayName") %></a>
						</div>
					</a>
				</td>
				&nbsp;&nbsp;<%# (Container.ItemIndex + 3) % 3 == 2 ? "</tr>" : string.Empty %>
			</ItemTemplate>
			<FooterTemplate>
				</table>
			</FooterTemplate>
		</asp:Repeater>

		
		<!-- Pagination -->
		<asp:SqlDataSource ID="GallerySource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>">
		</asp:SqlDataSource>
		
        <div class="arrows">
            <a href="#"><</a>
            <a href="#">></a>
        </div>

		<div class='footer'>
			<a href='#' class='link'>ABOUT</a>
			<a href='#' class='text'>ART-X 2019</a>
			<a href='#' class='link'>FAQ</a>
		</div>
	</form>
</body>
</html>