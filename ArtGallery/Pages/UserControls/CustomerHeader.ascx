<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CustomerHeader.ascx.cs" Inherits="ArtGallery.Pages.UserControls.CustomerHeader" %>

<%@ Import Namespace="ArtGallery.Classes" %>
<%@ Import Namespace="ArtGallery.Util" %>

<div class='header'>
			<a href='Home.aspx' class='title'>ART-X</a>
			<a href='AllGallery.aspx' class='link'>WORKS</a>
			<%
				string link = "";

				Customer customer = (Customer)Net.GetSession("customer");

					link = "CustomerProfile.aspx?username=" + customer.Username;
			%>
			<a href='<%= link %>' class='link'>PROFILE</a>

			

			<a href="CustomerAccount.aspx" class="link">ACCOUNT DETAILS</a>

			<%
					List<Order_Artwork> oaList = (List<Order_Artwork>)Net.GetSession("oaList");
					int noOfItems = 0;
					if (oaList != null)
					{
						noOfItems = oaList.Count;
					}
					else
					{
						noOfItems = 0;
					}
			%>

			<a href='Cart.aspx' class='link'>CART <sup style="color: darkred;"><%= noOfItems %></sup></a>

			<a href="paymenthistory.aspx" class="link">PAYMENT HISTORY</a>

		</div>