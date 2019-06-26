<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AllGallery.aspx.cs" Inherits="ArtGallery.Pages.AllGallery" %>

<!DOCTYPE html>
<style>
	@import url('https://fonts.googleapis.com/css?family=Roboto+Condensed&display=swap');

	html, body {
		margin: 0px;
		padding: 0px;
	}

	body {
		display: flex;
		flex-direction: column;
		align-items: center;
		justify-content: flex-start;
	}

	a {
		font-family: Roboto Condensed;
		text-decoration: none;
		color: black;
		font-weight: bold;
	}

	.header {
		display: flex;
		flex-direction: row;
		align-items: center;
		justify-content: center;
		margin-top: 50px;
		/* margin-left: -1300px; */
	}

		.header .title {
			font-size: 100px;
			margin-right: 50px;
		}

		.header .link {
			margin-left: 20px;
			font-size: 20px;
		}

	.footer {
		margin-bottom: 50px;
		display: flex;
		flex-direction: row;
		align-items: center;
		justify-content: center;
		height: 30px; /* weird div size stuff w/out this */
	}

		.footer .link {
			font-size: 15px;
			margin-left: 10px;
			margin-right: 10px;
		}

		.footer .text {
			font-size: 25px;
			margin-left: 20px;
			margin-right: 20px;
		}

	.text {
		margin-top: 100px;
		margin-bottom: 100px;
	}

		.text #title {
			text-align: right;
			padding-right: 20px;
		}

			.text #title a {
				font-size: 80px;
				font-weight: bold;
			}

		.text #quote {
			padding-left: 20px;
			text-align: left;
		}

			.text #quote #content {
				font-weight: bold;
				font-size: 25px;
				line-height: 25px;
				position: relative;
			}

			.text #quote #name {
				font-weight: bolder;
				font-size: 15px;
				color: #F9CA6A;
				position: relative;
				top: 5px;
			}

		.text #description {
			text-align: right;
			padding-right: 20px;
		}

			.text #description a {
				font-weight: bold;
				font-size: 30px;
				line-height: 32px;
			}

		.text #stats {
			padding-left: 20px;
			text-align: left;
		}

			.text #stats div {
				float: left;
				display: flex;
				flex-direction: row;
				align-items: center;
				justify-content: center;
				margin-right: 15px;
			}

				.text #stats div .number {
					font-size: 50px;
					font-weight: bold;
					color: #F9CA6A;
					margin-right: 5px;
				}

				.text #stats div .stat {
					font-size: 15px;
					font-weight: bold;
				}

	.gallery {
		margin-bottom: 100px;
	}

		.gallery tr td {
			padding: 25px;
		}

			.gallery tr td img {
				width: 500px;
				height: 375px;
				border-radius: 20px;
				box-shadow: 0px 0px 5px -5px rgba(0, 0, 0, 0.5);
			}

			.gallery tr td .box {
				position: absolute;
				display: flex;
				flex-direction: column;
				align-items: flex-start;
				justify-content: center;
				background-color: #F9CA6A;
				padding-left: 20px;
				padding-right: 20px;
				padding-top: 5px;
				padding-bottom: 5px;
				border-radius: 10px;
				box-shadow: 0px 0px 15px -5px rgba(0, 0, 0, 0.5);
				margin-top: -25px;
				margin-left: -25px;
				opacity: 0;
				transition: opacity 0.3s;
			}

				.gallery tr td .box a {
					font-weight: bold;
					color: black;
				}

				.gallery tr td .box .artpiece {
					font-size: 20px;
				}

				.gallery tr td .box .artist {
					font-size: 12px;
				}

			.gallery tr td:hover > .box {
				opacity: 1;
			}
</style>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
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

		<asp:Repeater ID="Repeater1" runat="server" DataSourceID="GallerySource">
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

		<asp:SqlDataSource ID="GallerySource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT ARTPIECE.TITLE, ARTPIECE.IMAGELINK AS URL, ARTIST.Username, ARTIST.DisplayName FROM ARTPIECE INNER JOIN ARTIST ON ARTPIECE.ARTISTID = ARTIST.ARTISTID WHERE (ARTPIECE.ISPUBLIC = 1) ORDER BY ARTPIECE.ARTPIECEID DESC"></asp:SqlDataSource>

		<div class='footer'>
			<a href='#' class='link'>ABOUT</a>
			<a href='#' class='text'>ART-X 2019</a>
			<a href='#' class='link'>FAQ</a>
		</div>
	</form>
</body>
</html>
