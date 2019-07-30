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
	public partial class ArtpieceEdit : System.Web.UI.Page
    {

		public Order_Artwork orderArtwork;
		protected Classes.Artpiece artpiece;
        protected Classes.Artist artist;


        protected void Page_Load(object sender, EventArgs e)
        {
			artpiece = new Classes.Artpiece();

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
				Net.Redirect("Artpiece.aspx?id=UNKNOWN");
			else
			{
				// Get Artist info
				ArtistDao artistDao = new ArtistDao();
				artist = artistDao.Get("ARTISTID", artpiece.ArtistId);

				// Will be null if currently logged in user is not an artist
				Artist currentArtist = (Artist)Session["Artist"];

				// Redirect if not original artist
				if (currentArtist == null || artpiece.ArtistId != artist.Id)
				{
					Net.Redirect("Artpiece.aspx?id=" + artpiece.ArtpieceId);
				}

					// Show private artpiece to the original artist
					 if (!artpiece.IsPublic && currentArtist.Id == artist.Id)
					{
						//Display artpiece details
						lblArtist.Text = artist.DisplayName;
						lblDescription.Text = artpiece.About;
						lblTitle.Text = artpiece.Title + "(PRIVATE ARTPIECE)";
						txtStocks.Text = artpiece.Stocks + "";
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

						//Display artpiece details
						lblArtist.Text = artist.DisplayName;
						lblDescription.Text = artpiece.About;
						lblTitle.Text = artpiece.Title;
						txtStocks.Text = artpiece.Stocks + "";
						lblArtpiecePrice.Text = Quick.FormatPrice(artpiece.Price);
						artpieceImg.ImageUrl = artpiece.ImageLink;
						

						if (!artpiece.IsForSale)
						{
							lblForSale.Text = "NOT FOR SALE";
							lblForSale.CssClass = "notforsale";
						}
					}
				}
			

        }

		protected void btnEdit_Click(object sender, EventArgs e)
		{
			bool hasError = false;

			//Verify that stocks are correctly entered
			try
			{
				artpiece.Stocks = Convert.ToInt32(txtStocks.Text);
			}
			catch (Exception ex)
			{
				hasError = true;

				// Show error message
			}

			if (!hasError)
			{
				//Update artpiece
				ArtpieceDao dao = new ArtpieceDao();
				dao.Update(artpiece);
			}
		}
	}
}