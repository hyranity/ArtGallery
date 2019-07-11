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

		protected void Page_Load(object sender, EventArgs e)
		{
			/* ----------------------------------------------------------------------------------------------------
             * Get session attributes to manipulate
             * ---------------------------------------------------------------------------------------------------- */
			Customer customer = (Customer)Net.GetSession("customer");
			List<Order_Artwork> oaList = (List<Order_Artwork>)Net.GetSession("oaList");




            /* FOR DEBUG PURPOSES */
            oaList = new List<Order_Artwork>();
            oaList.Add(new Order_Artwork("testorder", "MILO", 1, oaList));
            oaList.Add(new Order_Artwork("testorder", "LILO", 5, oaList));
            /* END */



            /* ----------------------------------------------------------------------------------------------------
             * Initialise daos to use
             * ---------------------------------------------------------------------------------------------------- */
            ArtpieceDao artpieceDao = new ArtpieceDao();
			ArtistDao artistDao = new ArtistDao();

            /* ----------------------------------------------------------------------------------------------------
             * Display statics in page header
             * ---------------------------------------------------------------------------------------------------- */

            // TODO TODO TODO 
            // TODO TODO TODO
            // TODO TODO TODO
            // TODO TODO TODO
            // TODO TODO TODO

            /* ----------------------------------------------------------------------------------------------------
             * Display items in cart
             * ---------------------------------------------------------------------------------------------------- */
            Control gallery = this.FindControl("gallery");

			int loopCounter = 0;

			// if cart is empty
			if (oaList == null || oaList.Count == 0)
			{

			}
			else
			{

				gallery.Controls.Add(new LiteralControl("<table class='gallery'>"));

				foreach (Order_Artwork orderArtwork in oaList)
				{
					// Get corresponding artpiece and artist
					ArtGallery.Classes.Artpiece artpiece = artpieceDao.Get("ArtpieceId", orderArtwork.ArtpieceId);
					Artist artist = artistDao.Get("ArtistId", artpiece.ArtistId);

					if (loopCounter % 3 == 0)
					{
						if (loopCounter != 0)
						{
							gallery.Controls.Add(new LiteralControl("</tr>"));
						}
						gallery.Controls.Add(new LiteralControl("<tr>"));
					}

					// ---

					gallery.Controls.Add(new LiteralControl("" +
						"<td>" +
							"<a href='#'>"));

					// ---

					Image image = new Image();
					image.ImageUrl = artpiece.ImageLink;

					gallery.Controls.Add(image);

					// ---

					gallery.Controls.Add(new LiteralControl("" +
							"</a>" +
							"<div class='details'>" +
								"<div class='of_artpiece'>"));

					// ---

					/*Label lblTitle = new Label();
					lblTitle.ID = "lblTitle" + loopCounter.ToString();
					lblTitle.Text = artpiece.Title;
					lblTitle.CssClass = "label title";

					gallery.Controls.Add(lblTitle);*/

					//gallery.Controls.Add(new LiteralControl("<asp:Label ID='lblTitle" + loopCounter + "' runat='server' Text='" + artpiece.Title + "' CssClass='label title'></asp:Label>"));

					gallery.Controls.Add(new LiteralControl("<a class='title'>" + artpiece.Title + "</a>"));

					/*Label lblArtist = new Label();
					lblArtist.ID = "lblArtist" + loopCounter.ToString();
					lblArtist.Text = artist.DisplayName;
					lblTitle.CssClass = "label artist";

					gallery.Controls.Add(lblArtist);*/

					//gallery.Controls.Add(new LiteralControl("<asp:Label ID='lblArtist" + loopCounter + "' runat='server' Text='" + artist.DisplayName + "' CssClass='label artist'></asp:Label>"));

					gallery.Controls.Add(new LiteralControl("<a class='artist'>" + artist.DisplayName + "</a>"));

					// ---

					gallery.Controls.Add(new LiteralControl("" +
								"</div>" +
								"<div class='of_order'>" +
									"<div class='quantity'>"));

                    // ---

                    /*Button btnDecrement = new Button();
					btnDecrement.ID = "btnDecrement" + (loopCounter + 1).ToString();
					btnDecrement.Text = "-";
					btnDecrement.CssClass = "decrement";
                    //btnDecrement.Click += Decrement;

					gallery.Controls.Add(btnDecrement);*/

                    gallery.Controls.Add(new LiteralControl("<input type='button' id='btnDecrement" + (loopCounter + 1).ToString() + "' class='decrement' value='-'>"));

                    Label lblQuantity = new Label();
					lblQuantity.ID = "lblQuantity" + (loopCounter + 1).ToString();
					lblQuantity.Text = orderArtwork.Quantity.ToString() + " PCS";
                    lblQuantity.CssClass = "label";
                    lblQuantity.Visible = false;

					gallery.Controls.Add(lblQuantity);

					gallery.Controls.Add(new LiteralControl("<a id='quantity" + (loopCounter + 1).ToString() + "'>" + orderArtwork.Quantity.ToString() + " PCS</a>"));

                    /*Button btnIncrement = new Button();
					btnIncrement.ID = "btnIncrement" + (loopCounter + 1).ToString();
					btnIncrement.Text = "+";
					btnIncrement.CssClass = "increment";
                    //btnIncrement.Click += Increment;

					gallery.Controls.Add(btnIncrement);*/

                    gallery.Controls.Add(new LiteralControl("<input type='button' id='btnIncrement" + (loopCounter + 1).ToString() + "' class='increment' value='+'>"));

                    // ---

                    gallery.Controls.Add(new LiteralControl("" +
									"</div>" +
									"<div class='subtotal'>" +
										"<a class='caption'>SUBTOTAL</a>"));

					// ---

					Label lblSubtotal = new Label();
					lblSubtotal.ID = "lblSubtotal" + (loopCounter + 1).ToString();
					lblSubtotal.Text = "RM " + Convert.ToString(artpiece.Price * (double)orderArtwork.Quantity);
					lblSubtotal.CssClass = "label value";

					gallery.Controls.Add(lblSubtotal);

					// ---

					gallery.Controls.Add(new LiteralControl("" +
									"</div>" +
								"</div>" +
							"</div>" +
						"</td>"));

					// ---

					loopCounter++;
				}

				if (oaList.Count > 0)
				{
					gallery.Controls.Add(new LiteralControl("</tr>"));
				}

				gallery.Controls.Add(new LiteralControl("</table>"));
			}
		}

        public void Decrement(object sender, EventArgs e)
        {
            Button button = sender as Button;

            Quick.Print("hey this be a test");
            // todo
        }

        public void Increment(object sender, EventArgs e)
        {
            Button button = sender as Button;

            // todo
        }
    }
}