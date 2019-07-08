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

		protected void Page_Load(object sender, EventArgs e)
        {
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
			Classes.Artpiece artpiece = dao.Get("ARTPIECEID", artpieceId);

			// Validate artpiece ID
			if (artpiece == null)
				lblTitle.Text = "Artpiece does not exist";
			else
			{
				// Get Artist info
				ArtistDao artistDao = new ArtistDao();
				Classes.Artist artist = artistDao.Get("ARTISTID", artpiece.ArtistId);

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
						artpieceImg.ImageUrl = artpiece.ImageLink;

						if (!artpiece.IsForSale)
						{
							lblForSale.Text = "NOT FOR SALE";
							lblForSale.CssClass = "notforsale";
						}
					}
					else // Show public artpiece
					{
						LoadWishlistBt();

						// Make buttons visible
						btnViewArtist.Visible = true;

						//Display artpiece details
						lblArtist.Text = artist.DisplayName;
						lblDescription.Text = artpiece.About;
						lblTitle.Text = artpiece.Title;
						artpieceImg.ImageUrl = artpiece.ImageLink;

						if (!artpiece.IsForSale)
						{
							lblForSale.Text = "NOT FOR SALE";
							lblForSale.CssClass = "notforsale";
						}
					}
				}
			}

        }

		private void LoadWishlistBt()
		{
			// Get customer from session
			Customer customer = (Customer)Net.GetSession("customer");

			// Show the wish status (whether added or not to wishlist) to customer
			if (customer != null)
			{
				// Make buttons visible
				btnAddToWishlist.Visible = true;
				btnAddToCart.Visible = true;

				WishedArtDao dao = new WishedArtDao();
				wish = dao.GetSpecific(customer.Id, Net.GetQueryStr("id"));

				// If wish already exists, show Added to Wishlist
				if (wish != null)
				{
					btnAddToWishlist.Text = "ADDED TO WISHLIST";
				}
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
					wish = new WishedArt(); // Create new object

					//Make new wish 
					IdGen IdGen = new IdGen();
					wish.WishId = IdGen.GenerateId("wishedart");
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
	}
}