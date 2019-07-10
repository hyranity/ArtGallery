using ArtGallery.Classes;
using ArtGallery.Daos;
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
    public partial class ArtistProfile : System.Web.UI.Page
    {

		public int pageNo;
		string username = "";

		protected void Page_Load(object sender, EventArgs e)
        {
			// To ensure that a valid username is entered
			
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


			// Convert page into number
			try
			{
				pageNo = Convert.ToInt32(Request.QueryString["page"].ToString());
				LoadButtons(ItemLimit);
			}
			catch (Exception ex)
			{
				Net.Redirect("~/Pages/ArtistProfile.aspx?username=" + username + "&page=1");
			}

			if (pageNo < 1)
				Net.Redirect("~/Pages/ArtistProfile.aspx?username=" + username + "&page=1");

			offsetAmt = CalculateOffset(ItemLimit);

			// Clear parameters
			GallerySource.SelectParameters.Clear();

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

		protected int CalculateOffset(int ItemLimit)
		{
			return (pageNo - 1) * ItemLimit;
		}

		protected void LoadButtons(int ItemLimit)
		{
			if (pageNo == 1)
				PrevPage.Visible = false;
			else
				PrevPage.Visible = true;

			// Get no of records in selected table
			DBUtil DBUtil = new DBUtil();
			SqlCommand Cmd = DBUtil.GenerateSql("SELECT COUNT(*) FROM ARTPIECE INNER JOIN ARTIST ON ARTPIECE.ARTISTID = ARTIST.ARTISTID WHERE (ARTPIECE.ISPUBLIC = 1) AND ARTIST.USERNAME = @USERNAME");
			Cmd.Parameters.AddWithValue("@USERNAME", username);
			int NoOfRecords = Convert.ToInt32(Cmd.ExecuteScalar());


			if (pageNo * ItemLimit < NoOfRecords)
				NextPage.Visible = true;
			else
				NextPage.Visible = false;
		}

		protected void PrevPage_Click(object sender, EventArgs e)
		{
			pageNo--;
			Net.Redirect("~/Pages/ArtistProfile.aspx?username=" + username + "&page=" + pageNo);
		}

		protected void NextPage_Click(object sender, EventArgs e)
		{
			pageNo++;
			Net.Redirect("~/Pages/ArtistProfile.aspx?username=" + username + "&page=" + pageNo);
		}
	}
}