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
	public partial class Artpiece : System.Web.UI.Page
    {

		public Order_Artwork orderArtwork;
		public WishedArt wish;
		protected Classes.Artpiece artpiece;
        protected Classes.Artist artist;


        protected void Page_Load(object sender, EventArgs e)
        {
			artpiece = new Classes.Artpiece();

			// Hide edit button first
			btnEdit.Visible = false;

            //Hide buttons first
            btnAddToWishlist.Visible = false;
            btnAddToCart.Visible = false;
			btnViewArtist.Visible = false;
			

			// To ensure that a valid username is entered
			string artpieceId = "";
			try
			{
				artpieceId = Request.QueryString["id"].ToString();
			}
			catch (Exception ex)
			{
				//Show error msg
			}

			// Get from DB
			ArtpieceDao dao = new ArtpieceDao();
			artpiece = dao.Get("ARTPIECEID", artpieceId);

			// Validate artpiece ID
			if (artpiece == null)
				lblTitle.Text = "Artpiece does not exist";
			else
			{
				// Get Artist info
				ArtistDao artistDao = new ArtistDao();
				artist = artistDao.Get("ARTISTID", artpiece.ArtistId);

				// Will be null if currently logged in user is not an artist
				Artist currentArtist = (Artist)Session["Artist"];

				// Block private artpiece from customer
				if (!artpiece.IsPublic && currentArtist == null)
				{
					lblTitle.Text = "Artpiece is private";
					
				}
				else
				{

					// Block private artpiece from other artists
					if (!artpiece.IsPublic && currentArtist.Id != artist.Id)
					{
						lblTitle.Text = "Artpiece is private";
					}
					// Show private artpiece to the original artist
					else if (!artpiece.IsPublic && currentArtist.Id == artist.Id)
					{
						//Display artpiece details
						lblArtist.Text = artist.DisplayName;
						lblDescription.Text = artpiece.About;
						lblTitle.Text = artpiece.Title + "(PRIVATE ARTPIECE)";
						lblStocks.Text = artpiece.Stocks + "";
						artpieceImg.ImageUrl = artpiece.ImageLink;
						lblArtpiecePrice.Text = Quick.FormatPrice(artpiece.Price);

						if (!artpiece.IsForSale)
						{
							lblForSale.Text = "NOT FOR SALE";
							lblForSale.CssClass = "notforsale";
						}
					}
					else // Show public artpiece
					{
						LoadBt();

						// Make buttons visible
						btnViewArtist.Visible = true;

						//Display artpiece details
						lblArtist.Text = artist.DisplayName;
						lblDescription.Text = artpiece.About;
						lblTitle.Text = artpiece.Title;
						lblStocks.Text = artpiece.Stocks + "";
						lblArtpiecePrice.Text = Quick.FormatPrice(artpiece.Price);
						artpieceImg.ImageUrl = artpiece.ImageLink;
						

						if (!artpiece.IsForSale)
						{
							lblForSale.Text = "NOT FOR SALE";
							lblForSale.CssClass = "notforsale";
						}
					}

					// Show edit button if this is the original artist
					if (currentArtist != null && currentArtist.Id == artist.Id)
						btnEdit.Visible = true;
				}
			}

        }

		private void LoadBt()
		{
			// Get customer from session
			Customer customer = (Customer)Net.GetSession("customer");

			// Show the buttons status
			if (customer != null)
			{
				// Make buttons visible
				btnAddToWishlist.Visible = true;

				if(artpiece.IsForSale)
					btnAddToCart.Visible = true;

				WishedArtDao dao = new WishedArtDao();
				wish = dao.GetSpecific(customer.Id, Net.GetQueryStr("id"));

				// If wish already exists, show Added to Wishlist
				if (wish != null)
				{
					btnAddToWishlist.Text = "ADDED TO WISHLIST";
				}

				bool found = false;

				List<Order_Artwork> oaList = (List<Order_Artwork>)Net.GetSession("oaList");

				if (oaList != null)
				{
					// Loop through order list in session to see if this artpiece already added to cart
					foreach (Order_Artwork oa in oaList)
					{
						if (oa.ArtpieceId.ToLower() == Net.GetQueryStr("id").ToLower())
							found = true;
						Quick.Print(oa.ArtpieceId.ToLower() + " == " + Net.GetQueryStr("id"));
					}
				}
				if (found)
					btnAddToCart.Text = "ADDED TO CART";
				else
					btnAddToCart.Text = "ADD TO CART";

			}

		}

		protected void btnAddToWishlist_Click(object sender, EventArgs e)
		{
			// Get customer from session
			Customer customer = (Customer)Net.GetSession("customer");

			// Redirect if not logged in
			if (customer == null)
				Net.Redirect("~/ Pages / LoginRegister.aspx");
			else
			{
				if (wish == null) // If havent added yet
				{
					wish = new WishedArt();

					//Make new wish 
					wish.CustId = customer.Id;
					wish.ArtpieceId = Net.GetQueryStr("Id");

					// Perform insert operation
					WishedArtDao dao = new WishedArtDao();
					dao.Add(wish);

					// Change button label to tell user already added to wishlist
					btnAddToWishlist.Text = "Added to Wishlist";
				}
				else // If already added
				{
					// If already added, should already be loaded during page load
					WishedArtDao dao = new WishedArtDao();

					// Delete wish in DB
					dao.Delete(wish);

					// Change button label to let user know is no longer in wishlist
					btnAddToWishlist.Text = "Add to Wishlist";
				}
			}

		}

        protected void btnAddToCart_Click(object sender, EventArgs e) // TESTING!
        {
            /* ----------------------------------------------------------------------------------------------------
            * Get session attributes to manipulate
            * ---------------------------------------------------------------------------------------------------- */
            Customer customer = (Customer)Net.GetSession("customer");
            Order order = (Order)Net.GetSession("order");
            List<Order_Artwork> oaList = (List<Order_Artwork>)Net.GetSession("oaList");

            /* ----------------------------------------------------------------------------------------------------
            * Initialise daos to use
            * ---------------------------------------------------------------------------------------------------- */
            ArtpieceDao artpieceDao = new ArtpieceDao();

            /* ----------------------------------------------------------------------------------------------------
            * Add/remove artpiece from oaList
            * ---------------------------------------------------------------------------------------------------- */
            string buttonStr = (sender as Button).Text;

            // Adding artpiece to oaList
            if (buttonStr.ToLower().Equals("add to cart"))
            {
                Order_Artwork orderArtwork = new Order_Artwork(order.OrderId, artpiece.ArtpieceId, 1, oaList); // Set default quantity to 1
                oaList.Add(orderArtwork);

				// Add order total price
				order.TotalPrice += artpiece.Price;

				// Update session
				Net.SetSession("oaList",oaList);
				Net.SetSession("order", order);

                (sender as Button).Text = "ADDED TO CART";
            }

            // Removing artpiece from oaList
            else if (buttonStr.ToLower().Equals("added to cart"))
            {
                oaList.RemoveAll(orderArtwork => orderArtwork.ArtpieceId == artpiece.ArtpieceId); // Thanks to Jon Skeet - https://stackoverflow.com/a/853551

				// Refund order total price
				order.TotalPrice = order.TotalPrice - artpiece.Price;

				// Update session
				Net.SetSession("oaList", oaList);
				Net.SetSession("order", order);

				(sender as Button).Text = "ADD TO CART";
            }

			

        }

        protected void btnViewArtist_Click(object sender, EventArgs e)
        {
            // Redirect to artist page
            Net.Redirect("~/Pages/ArtistProfile.aspx?username=" + artist.Username);
        }

        protected void btnLike_Click(object sender, EventArgs e)
        {
            // 'Like' feature is under construction
            Net.Redirect("~/Pages/UnderConstruction.aspx");
        }

		protected void btnEdit_Click(object sender, EventArgs e)
		{
			Net.Redirect("~/Pages/ArtpieceEdit.aspx?id="+artpiece.ArtpieceId);
		}
	}
}