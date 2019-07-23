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
		int pageNo;
		protected void Page_Load(object sender, EventArgs e)
		{
			 int offsetAmt = 0;
			int itemLimit = 9; // How many items per page


			bool hasError = false;

			// Convert page into number
			try
			{
				pageNo = Convert.ToInt32(Request.QueryString["page"].ToString());
				LoadButtons(itemLimit);
			}
			catch (Exception ex)
			{
				
				Net.Redirect("~/Pages/AllGallery.aspx?page=1");
			}
			
			if(pageNo<1)
				Net.Redirect("~/Pages/AllGallery.aspx?page=1");

			offsetAmt = CalculateOffset(itemLimit);

			GallerySource.SelectParameters.Clear();

			GallerySource.SelectCommand = "SELECT ARTPIECE.TITLE, ARTPIECE.IMAGELINK AS URL, ARTPIECE.ArtpieceId, ARTIST.Username, ARTIST.DisplayName FROM ARTPIECE INNER JOIN ARTIST ON ARTPIECE.ARTISTID = ARTIST.ARTISTID WHERE (ARTPIECE.ISPUBLIC = 1) ORDER BY ARTPIECE.ARTPIECEID DESC OFFSET @OFFSETAMT ROWS FETCH NEXT @ITEMLIMIT ROWS ONLY";
			GallerySource.SelectParameters.Add("offsetAmt", System.Data.DbType.Int32, offsetAmt + "");
			GallerySource.SelectParameters.Add("itemLimit", System.Data.DbType.Int32, itemLimit + "");

			ArtRepeater.DataSource = GallerySource;
			ArtRepeater.DataBind();

		}
		protected void LoadButtons(int ItemLimit)
		{
			if (pageNo == 1)
				PrevPage.Visible = false;
			else
				PrevPage.Visible = true;

			// Get no of records in selected table
			using (SqlConnection con = DBUtil.BuildConnection())
			{
				con.Open();
				SqlCommand Cmd = new SqlCommand("SELECT COUNT(*) FROM ARTPIECE INNER JOIN ARTIST ON ARTPIECE.ARTISTID = ARTIST.ARTISTID WHERE (ARTPIECE.ISPUBLIC = 1)", con);
				int NoOfRecords = Convert.ToInt32(Cmd.ExecuteScalar());


				if (pageNo * ItemLimit < NoOfRecords)
					NextPage.Visible = true;
				else
					NextPage.Visible = false;

				con.Close();
			}
		}

		protected void PrevPage_Click(object sender, EventArgs e)
		{
			pageNo--;
			Net.Redirect("~/Pages/AllGallery.aspx?page=" + pageNo);
		}

		protected void NextPage_Click(object sender, EventArgs e)
		{
			pageNo++;
			Net.Redirect("~/Pages/AllGallery.aspx?page=" + pageNo);
		}

		protected int CalculateOffset(int ItemLimit)
		{
			return (pageNo - 1) * ItemLimit;
		}
	}
}