<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AllGallery.aspx.cs" MasterPageFile="~/Pages/ArtGallery.Master" Inherits="ArtGallery.Pages.AllGallery" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">

    <title>Art Gallery :: All Gallery</title>
	<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.0/jquery.min.js"></script>
	<script src="JavaScript/AllGallery.js"></script>
	<link href="CSS/AllGallery.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css?family=Roboto+Condensed&display=swap" rel="stylesheet">

		
		<table class='text'>
			<tr>
				<td id='title'>
					<a>ARTPIECES</a>
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
				<!--<td id='stats'>
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
				</td>-->
			</tr>
		</table>

        <div class="Search">
            <asp:TextBox CssClass="searchBar" ID="txtSearch" runat="server" placeholder="Search here"></asp:TextBox> 
			<asp:Button CssClass="searchBt" ID="btnSearch" runat="server" Text="SEARCH" OnClick="btnSearch_Click"/>
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
	
		<!-- Pagination -->
		<asp:SqlDataSource ID="GallerySource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>">
		</asp:SqlDataSource>
		
			<div class="arrows">
                    <asp:Button Text="<" runat="server" ID="PrevPage" OnClick="PrevPage_Click"></asp:Button>
                    <asp:Button Text=">" runat="server" ID="NextPage" OnClick="NextPage_Click"></asp:Button>
                </div>

</asp:Content>