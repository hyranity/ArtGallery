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
	public partial class CustomerProfile : System.Web.UI.Page
	{

		public int pageNo;
		public string username = "";


		protected void Page_Load(object sender, EventArgs e)
		{
            // Redirects
            if (Request.QueryString["username"] == null)
            {
                Net.Redirect("~/Pages/Home.aspx");
            }

            if (Request.QueryString["username"].ToString().Equals("session") && Net.GetSession("artist") == null && Net.GetSession("customer") == null)
            {
                Net.Redirect("~/Pages/LoginRegister.aspx");
            }

            /*if (Net.GetSession("customer") == null && Net.GetSession("artist") != null)
            {
                Net.Redirect("~/Pages/ArtistProfile.aspx?username=session");
            }*/

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
				Net.Redirect("~/Pages/CustomerProfile.aspx?username=" + username + "&page=1");
			}

			if(pageNo<1)
				Net.Redirect("~/Pages/CustomerProfile.aspx?username=" + username + "&page=1");

			offsetAmt = CalculateOffset(ItemLimit);

			// Clear parameters
			GallerySource.SelectParameters.Clear();

			GallerySource.SelectCommand = "SELECT ARTPIECE.ARTPIECEID AS ID, ARTPIECE.TITLE, ARTPIECE.IMAGELINK AS URL, ARTIST.USERNAME, ARTIST.DisplayName FROM ARTPIECE INNER JOIN ARTIST ON ARTPIECE.ARTISTID = ARTIST.ARTISTID INNER JOIN WISHEDART ON WISHEDART.ARTPIECEID = ARTPIECE.ARTPIECEID INNER JOIN CUSTOMER ON CUSTOMER.CUSTID = WISHEDART.CUSTID WHERE CUSTOMER.USERNAME = @USERNAME ORDER BY ARTPIECE.ARTPIECEID DESC OFFSET @offsetAmt ROWS FETCH NEXT @ItemLimit ROWS ONLY";
			GallerySource.SelectParameters.Add("offsetAmt", System.Data.DbType.Int32, offsetAmt + "");
			GallerySource.SelectParameters.Add("ItemLimit", System.Data.DbType.Int32, ItemLimit + "");
			GallerySource.SelectParameters.Add("USERNAME", username);


            //Fetch from DB
            Customer Customer = null;
            if (username.Equals("session"))
            {
                Customer = (Customer)Net.GetSession("customer");
            }
            else
            {
                CustomerDao Dao = new CustomerDao();
                Customer = Dao.Get("username", username);
            }

			if (Customer == null)
			{
				lblName.Text = "Customer does not exist.";
			}
			else
			{
				lblHandle.Text =  "@" + Customer.Username;
				lblName.Text = Customer.DisplayName;
                //lblBio.Text = "TBA";
                lblBio.Text = "<span style='font-size: 20px; color: grey;'>Viewing " + Customer.DisplayName + "'s wishlist.</span>";
			}

			ArtRepeater.DataSource = GallerySource;
			ArtRepeater.DataBind();
		}

		protected void ArtRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
		{

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
			SqlCommand Cmd = DBUtil.GenerateSql("SELECT COUNT(*) FROM ARTPIECE INNER JOIN ARTIST ON ARTPIECE.ARTISTID = ARTIST.ARTISTID INNER JOIN WISHEDART ON WISHEDART.ARTPIECEID = ARTPIECE.ARTPIECEID INNER JOIN CUSTOMER ON CUSTOMER.CUSTID = WISHEDART.CUSTID WHERE CUSTOMER.USERNAME = @USERNAME ");
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
			Net.Redirect("~/Pages/CustomerProfile.aspx?username=" + username + "&page=" + pageNo);
		}

		protected void NextPage_Click(object sender, EventArgs e)
		{
			pageNo++;
			Net.Redirect("~/Pages/CustomerProfile.aspx?username=" + username + "&page=" + pageNo);
		}
	}
}