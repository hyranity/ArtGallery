using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ArtGallery.Pages
{
	public partial class AllGallery : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

			// How many items per page
			int itemLimit = 3;

			int pageNo = 0;
				bool hasError = false;

				// Convert page into number
				try
				{
					pageNo = Convert.ToInt32(Request.QueryString["page"].ToString());
				}
				catch (Exception ex)
				{
					 hasError = true;
				}

			// If the querystring is simply entered, show default
			if (hasError)
				GallerySource.SelectCommand = "SELECT ARTPIECE.TITLE, ARTPIECE.IMAGELINK AS URL, ARTIST.Username, ARTIST.DisplayName FROM ARTPIECE INNER JOIN ARTIST ON ARTPIECE.ARTISTID = ARTIST.ARTISTID WHERE (ARTPIECE.ISPUBLIC = 1) ORDER BY ARTPIECE.ARTPIECEID DESC OFFSET 0 ROWS FETCH NEXT " + itemLimit + " ROWS ONLY";
			else
			{
				
				GallerySource.SelectCommand = "SELECT ARTPIECE.TITLE, ARTPIECE.IMAGELINK AS URL, ARTIST.Username, ARTIST.DisplayName FROM ARTPIECE INNER JOIN ARTIST ON ARTPIECE.ARTISTID = ARTIST.ARTISTID WHERE (ARTPIECE.ISPUBLIC = 1) ORDER BY ARTPIECE.ARTPIECEID DESC OFFSET " + (pageNo * itemLimit + 1) +" ROWS FETCH NEXT " + itemLimit + "ROWS ONLY";

			}


			Repeater1.DataSource = GallerySource;
			Repeater1.DataBind();

		}
	}
}