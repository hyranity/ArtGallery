<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ArtistProfile.aspx.cs" Inherits="ArtGallery.Pages.ArtistProfile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>Art Gallery :: Artist Profile</title>
	<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.0/jquery.min.js"></script>
	<script src="JavaScript/ArtistProfile.js"></script>
	<link href="CSS/ArtistProfile.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css?family=Roboto+Condensed&display=swap" rel="stylesheet">
</head>

	<body>

        <form id="form1" runat="server">

		    <div class='header'>
                <a href='#' class='title'>ART-X</a>
                <a href='#' class='link'>WORKS</a>
                <a href='#' class='link'>ACCOUNT</a>
		    </div>

		    <div class='profile'>
			    <div class='card'>

				    <div id='left'>
                        <asp:Label ID="lblHandle" runat="server" CssClass="label handle">@seandoran</asp:Label>
					    <div id='main'>
						    <img src='https://pbs.twimg.com/profile_images/1055263632861343745/vIqzOHXj.jpg' >
                            <asp:Label ID="lblName" runat="server" CssClass="label name">Sean Doran</asp:Label>
					    </div>
                        <asp:Label ID="lblLocation" runat="server" CssClass="label location">NEW YORK CITY, USA</asp:Label>
                        <asp:Label ID="lblBio" runat="server" CssClass="label bio">UI/UX designer based in NYC.</asp:Label>
					    <div id='tags'>
						    <a class='tag'>UI</a>
						    <a class='tag'>UX</a>
						    <a class='tag'>DESIGN</a>
						    <a class='tag'>WEB</a>
						    <a class='tag'>MOBILE</a>
					    </div>
				    </div>
				
				    <div id='right'>
					    <div id='topstats'>
						    <div>
                                <asp:Label ID="lblNumberArtpiecesPosted" runat="server" CssClass="label number">23</asp:Label>
                                <asp:Label ID="lblStatArtpiecesPosted" runat="server" CssClass="label stat">ARTPIECES<br />POSTED</asp:Label>
						    </div>
						    <div>
                                <asp:Label ID="lblNumberFollowers" runat="server" CssClass="label number">1.5k</asp:Label>
                                <asp:Label ID="lblStatFollowers" runat="server" CssClass="label stat">FOLLOWERS</asp:Label>
						    </div>
					    </div>
					    <div id='bottomstats'>
						    <div>
                                <asp:Label ID="lblNumberArtpiecesLiked" runat="server" CssClass="label number">1.5k</asp:Label>
                                <asp:Label ID="lblStatArtpiecesLiked" runat="server" CssClass="label stat">ARTPIECES<br />LIKED</asp:Label>
						    </div>
						    <div>
                                <asp:Label ID="lblNumberSales" runat="server" CssClass="label number">312</asp:Label>
                                <asp:Label ID="lblStatSales" runat="server" CssClass="label stat">SALES</asp:Label>
						    </div>
						    <div>
                                <asp:Label ID="lblNumberFollowing" runat="server" CssClass="label number">74</asp:Label>
                                <asp:Label ID="lblStatFollowing" runat="server" CssClass="label stat">FOLLOWING</asp:Label>
						    </div>
					    </div>
				    </div>

			    </div>
		    </div>

		    <table class='gallery'>
              <tr>
                <td>
                  <a href='#'>
                    <img src='https://images.unsplash.com/photo-1536851101967-55988a52f455?ixlib=rb-1.2.1&auto=format&fit=crop&w=1936&q=80'>
                    <div class='box'>
                      <a class='artpiece'>Waves</a>
                      <a class='artist'>RYAN KOROH</a>
                    </div>
                  </a>
                </td>
                <td>
                  <a href='#'>
                    <img src='https://images.unsplash.com/photo-1536851101967-55988a52f455?ixlib=rb-1.2.1&auto=format&fit=crop&w=1936&q=80'>
                    <div class='box'>
                      <a class='artpiece'>Waves</a>
                      <a class='artist'>RYAN KOROH</a>
                    </div>
                  </a>
                </td>
                <td>
                  <a href='#'>
                    <img src='https://images.unsplash.com/photo-1536851101967-55988a52f455?ixlib=rb-1.2.1&auto=format&fit=crop&w=1936&q=80'>
                    <div class='box'>
                      <a class='artpiece'>Waves</a>
                      <a class='artist'>RYAN KOROH</a>
                    </div>
                  </a>
                </td>
              </tr>
              <tr>
                <td>
                  <a href='#'>
                    <img src='https://images.unsplash.com/photo-1536851101967-55988a52f455?ixlib=rb-1.2.1&auto=format&fit=crop&w=1936&q=80'>
                    <div class='box'>
                      <a class='artpiece'>Waves</a>
                      <a class='artist'>RYAN KOROH</a>
                    </div>
                  </a>
                </td>
                <td>
                  <a href='#'>
                    <img src='https://images.unsplash.com/photo-1536851101967-55988a52f455?ixlib=rb-1.2.1&auto=format&fit=crop&w=1936&q=80'>
                    <div class='box'>
                      <a class='artpiece'>Waves</a>
                      <a class='artist'>RYAN KOROH</a>
                    </div>
                  </a>
                </td>
                <td>
                  <a href='#'>
                    <img src='https://images.unsplash.com/photo-1536851101967-55988a52f455?ixlib=rb-1.2.1&auto=format&fit=crop&w=1936&q=80'>
                    <div class='box'>
                      <a class='artpiece'>Waves</a>
                      <a class='artist'>RYAN KOROH</a>
                    </div>
                  </a>
                </td>
              </tr>
            </table>

            <div class='footer'>
              <a href='#' class='link'>ABOUT</a>
              <a href='#' class='text'>ART-X 2019</a>
              <a href='#' class='link'>FAQ</a>
            <div>

        </form>

	</body>

</html>
