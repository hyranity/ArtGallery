using ArtGallery.Classes;
using ArtGallery.Daos;
using ArtGallery.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ArtGallery.Pages
{
    public partial class Cart : System.Web.UI.Page
    {
		public List<Order_Artwork> oaList;

        protected void Page_Load(object sender, EventArgs e)
        {
            /* ----------------------------------------------------------------------------------------------------
             * Get session attributes to manipulate
             * ---------------------------------------------------------------------------------------------------- */

            Customer customer = (Customer)Net.GetSession("Customer");
            List<Order_Artwork> orderArtworks = (List<Order_Artwork>)Net.GetSession("orderArtworks");

            /* ----------------------------------------------------------------------------------------------------
             * Initialise DAOs to use
             * ---------------------------------------------------------------------------------------------------- */

            ArtpieceDao artpieceDao = new ArtpieceDao();
            ArtistDao artistDao = new ArtistDao();

            /* ----------------------------------------------------------------------------------------------------
             * Redirect if not logged in
             * ---------------------------------------------------------------------------------------------------- */

            if (customer == null)
            {
                Response.Redirect("~/Pages/LoginRegister.aspx");
            }

            /* ----------------------------------------------------------------------------------------------------
             * Count and display number of items currently in cart
             * ---------------------------------------------------------------------------------------------------- */

            Literal litNoOfItems = (Literal)this.Page.FindControl("litNoOfItems");
            int noOfItems = 0;

            foreach (Order_Artwork orderArtwork in orderArtworks)
            {
                noOfItems += orderArtwork.Quantity;
            }

            litNoOfItems.Text = "<a class='value'>" + noOfItems + " PCS</a>";

            /* ----------------------------------------------------------------------------------------------------
             * Calculate total price of all items currently in cart
             * ---------------------------------------------------------------------------------------------------- */

            Literal litTotalPrice = (Literal)this.Page.FindControl("litTotalPrice");
            double totalPrice = 0;

            foreach (Order_Artwork orderArtwork in orderArtworks)
            {
                String artpieceId = orderArtwork.ArtpieceId;
                ArtGallery.Classes.Artpiece artpiece = artpieceDao.Get("ArtpieceId", artpieceId); // conflict between Classes.Artpiece and Pages.Artpeice
                totalPrice += artpiece.Price * (double)orderArtwork.Quantity;
            }

            litTotalPrice.Text = "<a class='value'>RM " + totalPrice + "</a>";

            /* ----------------------------------------------------------------------------------------------------
             * Display all items currently in cart
             * ---------------------------------------------------------------------------------------------------- */

            Literal litGallery = (Literal)this.Page.FindControl("litGallery"); // haha yes very lit gallery
            
            litGallery.Text += "<table class='gallery'>";

            int index = 0;

            foreach (Order_Artwork orderArtwork in orderArtworks)
            {
                String artpieceId = orderArtwork.ArtpieceId;
                ArtGallery.Classes.Artpiece artpiece = artpieceDao.Get("ArtpieceId", artpieceId);
                String artistId = artpiece.ArtistId;
                Artist artist = artistDao.Get("ArtistId", artistId);

                double subtotalPrice = artpiece.Price * (double)orderArtwork.Quantity;

                if (index % 3 == 0)
                {
                    litGallery.Text += "<tr>";
                }

                litGallery.Text += "<td>" +
                        "<a href='#'>" +
                            "<asp:Image runat='server' ImageUrl='" + artpiece.ImageLink + "' />" +
                        "</a>" +
                        "<div class='details'>" +
                            "<div class='of_artpiece'>" +
                                "<asp:Label ID='lblTitle" + index + "' runat='server' Text='" + artpiece.Title + "' CssClass='label title'></asp:Label>" +
                                "<asp:Label ID='lblArtist" + index + "' runat='server' Text='" + artist.DisplayName + "' CssClass='label artist'></asp:Label>" +
                            "</div>" +
                            "<div class='of_order'>" +
                                "<div class='quantity'>" +
                                    "<asp:Button ID='btnDecrement" + index + "' runat='server' Text=' - ' CssClass='decrement' />" +
                                    "<a>" + orderArtwork.Quantity + " PCS</a>" +
                                    "<asp:Button ID='btnIncrement" + index + "' runat='server' Text=' + ' CssClass='increment' />" +
                                "</div>" +
                                "<div class='subtotal'>" +
                                    "<a class='caption'>SUBTOTAL</a>" +
                                    "<asp:Label ID='lblValue" + index + "' runat='server' Text='RM " + subtotalPrice + "' CssClass='label value'></asp:Label>" +
                                "</div>" +
                            "</div>" +
                        "</div>" +
                    "</td>";

                if (index % 3 == 0)
                {
                    litGallery.Text += "</tr>";
                }
            }

            /*
			// Check if there is an active cart
			Order order = (Order) Session["order"];

			if (order == null) // if there’s currently no cart
			{
				// Display empty cart message 
			}
			else // if there’s an active cart
			{
				// Get items from session
				oaList = (List<Order_Artwork>)Session["oaList"];
				

				foreach (Order_Artwork oa in oaList)
				{
					// Display items

				}
			}
            */

        }
    }
}