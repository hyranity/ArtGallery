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
                        <asp:Label ID="lblHandle" runat="server" CssClass="label handle"></asp:Label>
					    <div id='main'>
						    <img src='https://pbs.twimg.com/profile_images/1055263632861343745/vIqzOHXj.jpg' >
                            <asp:Label ID="lblName" runat="server" CssClass="label name"></asp:Label>
					    </div>
                        <asp:Label ID="lblLocation" runat="server" CssClass="label location"></asp:Label>
                        <asp:Label ID="lblBio" runat="server" CssClass="label bio"></asp:Label>
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
                <div class="arrows">
                    <a href="#"><</a>
                    <a href="#">></a>
                </div>
			</FooterTemplate>
		</asp:Repeater>

		<asp:SqlDataSource ID="GallerySource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"></asp:SqlDataSource>

            <div class='footer'>
              <a href='#' class='link'>ABOUT</a>
              <a href='#' class='text'>ART-X 2019</a>
              <a href='#' class='link'>FAQ</a>
            </div>

        </form>

	</body>

</html>
