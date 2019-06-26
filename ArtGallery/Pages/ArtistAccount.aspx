<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ArtistAccount.aspx.cs" Inherits="ArtGallery.Pages.ArtistAccount" %>

<!DOCTYPE html>

<style>
	@import url('https://fonts.googleapis.com/css?family=Roboto+Condensed&display=swap');

	html, body {
		margin: 0px;
		padding: 0px;
		width: 1920px;
		overflow: hidden;
	}

	.labels, a {
		font-family: Roboto Condensed;
		text-decoration: none;
		color: #4B4848;
		font-weight: bold;
	}

	.header {
		display: flex;
		flex-direction: row;
		align-items: center;
		margin-top: 30px;
		margin-left: 50px;
		/* margin-left: -1300px; */
	}

		.header .title {
			font-size: 100px;
			margin-right: 50px;
		}

		.header .link {
			font-size: 25px;
			margin-right: 25px;
		}

	.card {
		display: flex;
		flex-direction: column;
		align-items: center;
		justify-content: center;
		margin-left: -1000px;
		margin-top: 100px;
	}

		.card .handle {
			font-size: 30px;
		}

		.card #main {
			display: flex;
			flex-direction: row;
			align-items: center;
			justify-content: center;
			margin-top: -10px;
		}

			.card #main img {
				border-radius: 100px;
				width: 80px;
				margin-right: 20px;
			}

			.card #main .name {
				font-size: 90px;
			}

		.card .location {
			font-size: 20px;
			color: grey;
		}

		.card .bio {
			margin-top: 20px;
			font-size: 35px;
		}

		.card #tags {
			display: flex;
			flex-direction: row;
			align-items: center;
			justify-content: center;
			margin-top: 5px;
			margin-bottom: 20px;
		}

			.card #tags .tag {
				font-size: 20px;
				margin-right: 10px;
				color: grey;
			}

		.card #topstats, .card #bottomstats {
			display: flex;
			flex-direction: row;
			align-items: center;
			justify-content: center;
		}

			.card #topstats div {
				float: left;
				display: flex;
				flex-direction: row;
				align-items: center;
				justify-content: center;
				margin-right: 15px;
			}

			.card #topstats .number {
				font-size: 70px;
				font-weight: bold;
				color: #F9CA6A;
				margin-right: 5px;
			}

			.card #topstats .stat {
				font-size: 20px;
				font-weight: bold;
			}

			.card #bottomstats div {
				float: left;
				display: flex;
				flex-direction: row;
				align-items: center;
				justify-content: center;
				margin-right: 15px;
			}

			.card #bottomstats .number {
				font-size: 50px;
				font-weight: bold;
				color: #F9CA6A;
				margin-right: 5px;
			}

			.card #bottomstats .stat {
				font-size: 15px;
				font-weight: bold;
			}

		.card .back {
			margin-top: 50px;
			color: grey;
			font-size: 25px;
		}

	.purple {
		background-color: #807187;
		height: 2000px;
		width: 1200px;
		transform: rotate(20deg);
		margin-left: 800px;
		margin-top: -1000px;
		display: flex;
		flex-direction: column;
		align-items: center;
		justify-content: center;
	}

		.purple .container {
			display: flex;
			flex-direction: row;
			align-items: center;
			justify-content: center;
			margin-top: -350px;
			margin-right: 100px;
		}

			.purple .container #center {
				transform: rotate(-90deg);
				z-index: 1;
			}

				.purple .container #center input {
					color: white;
					font-size: 80px;
					background: transparent;
					border: none;
					font-family: Roboto Condensed;
					font-weight: bold;
				}

					.purple .container #center input:focus {
						outline: none;
					}

			.purple .container #left {
				display: flex;
				flex-direction: column;
				align-items: flex-end;
				justify-content: center;
				z-index: 1;
				margin-right: -180px;
				margin-top: -190px;
			}

				.purple .container #left input {
					font-size: 35px;
					z-index: 2;
					font-weight: bold;
					width: 200px;
					border: none;
					background: transparent;
					color: white;
					text-align: right;
					font-family: Roboto Condensed;
				}

					.purple .container #left input::placeholder {
						color: white;
						font-size: 35px;
						font-family: Roboto Condensed;
					}

					.purple .container #left input:focus {
						outline: none;
					}

				.purple .container #left img {
					margin-top: -18px;
					z-index: 1;
					width: 50px;
					margin-bottom: -15px;
					filter: invert(100%);
					float: right;
				}

				.purple .container #left .text {
					transform: rotate(-90deg);
					color: #87D291;
					font-size: 35px;
					text-align: right;
					margin-top: 50px;
					position: relative;
					left: 30px;
				}

			.purple .container #right {
				display: flex;
				flex-direction: column;
				align-items: flex-start;
				justify-content: center;
				z-index: 1;
				margin-left: -270px;
				margin-bottom: -200px;
			}

				.purple .container #right input {
					font-size: 35px;
					z-index: 2;
					font-weight: bold;
					width: 200px;
					border: none;
					background: transparent;
					color: white;
					text-align: left;
					font-family: Roboto Condensed;
				}

					.purple .container #right input::placeholder {
						color: white;
						font-size: 35px;
						font-family: Roboto Condensed;
					}

					.purple .container #right input:focus {
						outline: none;
					}

				.purple .container #right img {
					margin-top: -18px;
					z-index: 1;
					width: 50px;
					margin-bottom: -15px;
					filter: invert(100%);
					float: right;
				}

				.purple .container #right .text {
					transform: rotate(-90deg);
					color: #E88484;
					font-size: 35px;
					text-align: left;
					margin-bottom: 60px;
					position: relative;
					right: 45px;
				}
</style>

<html>

<body>
	<form runat="server">
		<div class='header'>
			<a href='#' class='title'>ART-X</a>
			<a href='#' class='link'>WORKS</a>
			<a href='#' class='link'>ACCOUNT</a>
		</div>

		<div class='card'>
			<asp:Label ID="usernameLbl" runat="server" CssClass="handle labels"></asp:Label>
			<div id='main'>
				<img src='https://pbs.twimg.com/profile_images/1055263632861343745/vIqzOHXj.jpg'>
				<asp:Label ID="nameLbl" runat="server" CssClass="name labels"></asp:Label>
			</div>
			<a class='location'>NEW YORK CITY, USA</a>
			<asp:Label ID="bioLbl" CssClass="labels" runat="server"/>
			<div id='tags'>
				<a class='tag'>UI</a>
				<a class='tag'>UX</a>
				<a class='tag'>DESIGN</a>
				<a class='tag'>WEB</a>
				<a class='tag'>MOBILE</a>
			</div>
			<div id='topstats'>
				<div>
					<a class='number'>23</a>
					<a class='stat'>ARTPIECES<br>
						POSTED</a>
				</div>
				<div>
					<a class='number'>1.5k</a>
					<a class='stat'>FOLLOWERS</a>
				</div>
			</div>
			<div id='bottomstats'>
				<div>
					<a class='number'>184</a>
					<a class='stat'>ARTPIECES<br>
						LIKED</a>
				</div>
				<div>
					<a class='number'>312</a>
					<a class='stat'>SALES</a>
				</div>
				<div>
					<a class='number'>74</a>
					<a class='stat'>FOLLOWING</a>
				</div>
			</div>
			<a href='#' class='back'>BACK TO PROFILE</a>
		</div>

		<div class='purple'>
			<div class='container'>
				<div style='display: flex; flex-direction: row;'>
					<div id='left'>
						<asp:TextBox ID="id" Placeholder="id" runat="server"></asp:TextBox>
						<img src='https://image.flaticon.com/icons/svg/3/3897.svg'>
						<asp:TextBox ID="username" Placeholder="username" runat="server"></asp:TextBox>
						<img src='https://image.flaticon.com/icons/svg/3/3897.svg'>
						<asp:TextBox ID="displayName" Placeholder="display name" runat="server"></asp:TextBox>
						<img src='https://image.flaticon.com/icons/svg/3/3897.svg'>
						<a class='text'>ARTIST<br>
							ACCOUNT</a>
					</div>
					<div id='center'>
						<asp:Button ID="btnEdit" runat="server" Text="UPDATE DETAILS" OnClick="btnEdit_Click" />
					</div>
					<div id='right'>
						<a href='#' class='text'>LOGOUT</a>
						<asp:TextBox ID="password" TextMode="Password" Placeholder="new password" runat="server"></asp:TextBox>
						<img src='https://image.flaticon.com/icons/svg/3/3897.svg'>
						<asp:TextBox ID="email" Placeholder="email" runat="server"></asp:TextBox>
						<img src='https://image.flaticon.com/icons/svg/3/3897.svg'>
						<asp:TextBox ID="skills" Placeholder="skills" runat="server"></asp:TextBox>
						<img src='https://image.flaticon.com/icons/svg/3/3897.svg'>
						<asp:TextBox ID="bio" Placeholder="bio" runat="server"></asp:TextBox>
						<img src='https://image.flaticon.com/icons/svg/3/3897.svg'>
					</div>
				</div>
			</div>
		</div>
	</form>
</body>

</html>

