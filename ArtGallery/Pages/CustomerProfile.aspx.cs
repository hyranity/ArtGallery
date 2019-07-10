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
	public partial class CustomerProfile : System.Web.UI.Page
	{

		public int pageNo;

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

			// Clear parameters
			GallerySource.SelectParameters.Clear();

			GallerySource.SelectCommand = "SELECT ARTPIECE.TITLE, ARTPIECE.IMAGELINK AS URL, ARTIST.USERNAME, ARTIST.DisplayName FROM ARTPIECE INNER JOIN ARTIST ON ARTPIECE.ARTISTID = ARTIST.ARTISTID INNER JOIN WISHEDART ON WISHEDART.ARTPIECEID = ARTPIECE.ARTPIECEID INNER JOIN CUSTOMER ON CUSTOMER.CUSTID = WISHEDART.CUSTID WHERE CUSTOMER.USERNAME = @USERNAME ORDER BY ARTPIECE.ARTPIECEID DESC OFFSET @offsetAmt ROWS FETCH NEXT @ItemLimit ROWS ONLY";
			GallerySource.SelectParameters.Add("offsetAmt", System.Data.DbType.Int32, offsetAmt + "");
			GallerySource.SelectParameters.Add("ItemLimit", System.Data.DbType.Int32, ItemLimit + "");
			GallerySource.SelectParameters.Add("USERNAME", username);


			//Fetch from DB
			CustomerDao Dao = new CustomerDao();
			Customer Customer = Dao.Get("username", username);

			if (Customer == null)
			{
				lblName.Text = "Customer does not exist.";
			}
			else
			{
				lblHandle.Text = Customer.Username;
				lblName.Text = Customer.DisplayName;
				lblBio.Text = "TBA";
			}

			ArtRepeater.DataSource = GallerySource;
			ArtRepeater.DataBind();
		}

		protected void ArtRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
		{

		}

		protected void LoadButtons()
		{
			if (pageNo == 0)
				PrevPage.Visible = false;
			else
				PrevPage.Visible = true;

			
		}

		protected void PrevPage_Click(object sender, EventArgs e)
		{
			int newPage = 0;

			if (pageNo > 0)
				pageNo--;

			
		}
	}
}