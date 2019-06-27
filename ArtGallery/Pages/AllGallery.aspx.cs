using ArtGallery.Util;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
			 int offsetAmt = 0;
			int itemLimit = 9; // How many items per page


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
			if (!hasError)
			{
				pageNo--;
				offsetAmt = pageNo * itemLimit + 1;
			}

			GallerySource.SelectCommand = "SELECT ARTPIECE.TITLE, ARTPIECE.IMAGELINK AS URL, ARTIST.Username, ARTIST.DisplayName FROM ARTPIECE INNER JOIN ARTIST ON ARTPIECE.ARTISTID = ARTIST.ARTISTID WHERE (ARTPIECE.ISPUBLIC = 1) ORDER BY ARTPIECE.ARTPIECEID DESC OFFSET @OFFSETAMT ROWS FETCH NEXT @ITEMLIMIT ROWS ONLY";
			GallerySource.SelectParameters.Add("offsetAmt", System.Data.DbType.Int32, offsetAmt + "");
			GallerySource.SelectParameters.Add("itemLimit", System.Data.DbType.Int32, itemLimit + "");

			ArtRepeater.DataSource = GallerySource;
			ArtRepeater.DataBind();

		}
	}
}