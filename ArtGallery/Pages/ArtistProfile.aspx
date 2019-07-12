<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ArtistProfile.aspx.cs" MasterPageFile="~/Pages/ArtGallery.Master" Inherits="ArtGallery.Pages.ArtistProfile" %>

<%@ Import Namespace="ArtGallery.Classes" %>
<%@ Import Namespace="ArtGallery.Util" %> 

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <title>Art Gallery :: Artist Profile</title>
	<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.0/jquery.min.js"></script>
	<script src="JavaScript/ArtistProfile.js"></script>
	<link href="CSS/ArtistProfile.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css?family=Roboto+Condensed&display=swap" rel="stylesheet">

		    <div class='profile'>
			    <div class='card'>

				    <div id='left'>
                        <asp:Label ID="lblHandle" runat="server" CssClass="label handle"></asp:Label>
					    <div id='main'>
						    <!--<img src='https://pbs.twimg.com/profile_images/1055263632861343745/vIqzOHXj.jpg' -->
                            <asp:Label ID="lblName" runat="server" CssClass="label name"></asp:Label>
					    </div>
                        <!--<asp:Label ID="lblLocation" runat="server" CssClass="label location"></asp:Label>-->
                        <asp:Label ID="lblBio" runat="server" CssClass="label bio"></asp:Label>
					    <!--<div id='tags'>
						    <a class='tag'>UI</a>
						    <a class='tag'>UX</a>
						    <a class='tag'>DESIGN</a>
						    <a class='tag'>WEB</a>
						    <a class='tag'>MOBILE</a>
					    </div>-->
                        <% if (username != null && !username.Equals("") && Net.GetSession("artist") != null)
                           { %>
                            <a href="ArtistAccount.aspx" class="editLink">EDIT PROFILE</a>
                        <% } %>
				    </div>
				
				    <!--<div id='right'>
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
				    </div>-->

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
					<a href='Artpiece.aspx?id=<%# Eval("ArtpieceId") %>'>
						<asp:Image runat="server" ImageUrl='<%# Eval("URL") %>' />

						<div class='box'>
							<a class='artpiece'><%# Eval("TITLE") %></a>
							<a class='artist'><%# Eval("DisplayName") %></a>
						</div>
					</a>
				</td>
				&nbsp;&nbsp;<%# (Container.ItemIndex + 3) % 3 == 2 ? "</tr>" : string.Empty %>
			</ItemTemplate>
			<FooterTemplate>
				</table>
			</FooterTemplate>
		</asp:Repeater>

			<div class="arrows">
                    <asp:Button Text="<" runat="server" ID="PrevPage" OnClick="PrevPage_Click" style="width: 22px"></asp:Button>
                    <asp:Button Text=">" runat="server" ID="NextPage" OnClick="NextPage_Click"></asp:Button>
                </div>

		<asp:SqlDataSource ID="GallerySource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"></asp:SqlDataSource>

</asp:Content>