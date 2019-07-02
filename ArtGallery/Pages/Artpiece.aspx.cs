﻿using ArtGallery.Daos;
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
        protected void Page_Load(object sender, EventArgs e)
        {
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
			else if (!artpiece.IsPublic)
			{
				lblTitle.Text = "Artpiece is private";
			}
			else
			{
				// Get Artist info
				ArtistDao artistDao = new ArtistDao();
				Classes.Artist artist = artistDao.Get("ARTISTID", artpiece.ArtistId);

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