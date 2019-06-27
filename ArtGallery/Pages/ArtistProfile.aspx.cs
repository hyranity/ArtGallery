using ArtGallery.Classes;
using ArtGallery.Daos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ArtGallery.Pages
{
    public partial class ArtistProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			// To ensure that a valid username is entered
			string username = "";
			try
			{
				username = Request.QueryString["username"].ToString();
			}
			catch (Exception ex)
			{
				// Show error msg
			}

			int offsetAmt = 0;
			int ItemLimit = 9; // How many items per page


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
				offsetAmt = pageNo * ItemLimit + 1;
			}

			GallerySource.SelectCommand = "SELECT ARTPIECE.TITLE, ARTPIECE.IMAGELINK AS URL, ARTIST.USERNAME, ARTIST.DisplayName FROM ARTPIECE INNER JOIN ARTIST ON ARTPIECE.ARTISTID = ARTIST.ARTISTID WHERE (ARTPIECE.ISPUBLIC = 1) AND ARTIST.USERNAME = @USERNAME ORDER BY ARTPIECE.ARTPIECEID DESC OFFSET @OFFSETAMT ROWS FETCH NEXT @ItemLimit ROWS ONLY";
			GallerySource.SelectParameters.Add("offsetAmt", System.Data.DbType.Int32, offsetAmt + "");
			GallerySource.SelectParameters.Add("ItemLimit", System.Data.DbType.Int32, ItemLimit + "");
			GallerySource.SelectParameters.Add("USERNAME", username);

			//Fetch from DB
			ArtistDao Dao = new ArtistDao();
			Artist Artist = Dao.Get("username", username);

			if (Artist == null)
			{
				lblName.Text = "Artist does not exist.";
			}
			else
			{
				lblHandle.Text = Artist.Username;
				lblName.Text = Artist.DisplayName;
				lblBio.Text = Artist.Bio;
			}

			ArtRepeater.DataSource = GallerySource;
			ArtRepeater.DataBind();
		}
    }
}