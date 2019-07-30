using ArtGallery.Classes;
using ArtGallery.Daos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ArtGallery.Util;

namespace ArtGallery.Pages
{
    public partial class Upload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			// Check if logged in as Artist or not
			if (Session["artist"] == null)
				Response.Redirect("~/Pages/LoginRegister.aspx");
        }

		protected void uploadBt_Click(object sender, EventArgs e)
		{
			// Validate form first

			string errorMsg = ValidateForm();

			if (errorMsg != null) // If there is an error
			{

			}
			else // If there is no error
			{
				// Obtain artist info
				Artist artist = (Artist)Session["artist"];

				// Generate Artpiece Id
				IdGen IdGen = new IdGen();
				String ArtpieceId = IdGen.GenerateId("Artpiece");

				// Obtain the values from the form
				Classes.Artpiece artpiece = new Classes.Artpiece();
				artpiece.ArtpieceId = ArtpieceId;
				artpiece.ArtistId = artist.Id;
				artpiece.Tags = txtTags.Text;
				artpiece.About = txtDescription.Text;
				artpiece.Title = txtTitle.Text;
				artpiece.Price = Convert.ToDouble(txtPrice.Text);

				artpiece.Stocks = Convert.ToInt32(txtStocks.Text);  // Need to validate        

				// NOTE! NEED TO CHANGE TO DROPDOWNLIST
				if (rblForSale.SelectedValue == "yes") // If the artpiece is for sale
					artpiece.IsForSale = true;
				else
					artpiece.IsForSale = false;

				// NOTE! NEED TO CHANGE TO DROPDOWNLIST
				if (rblIsPublic.SelectedValue == "yes") // If the artpiece is public
					artpiece.IsPublic = true;
				else
					artpiece.IsPublic = false;

				artpiece.ImageLink = FileUtil.Upload(fileBt, "~/Pics/");     // For image link


				// Perform database insert
				ArtpieceDao dao = new ArtpieceDao();
				dao.Add(artpiece);

				//To redirect user to the new artpiece
				Response.Redirect("~/Pages/artpiece.aspx?Id=" + artpiece.ArtpieceId);
			}
		}

		private string ValidateForm()
		{
			string errorMsg = null;
			int linkLimit = 200;

			// Check file name length
			string fileName = "~/Pics/" + fileBt.FileName;

			if (fileName.Length > linkLimit)
				errorMsg = "Please use a shorter file name.";

			// Check price input is numerical
			try
			{
				Convert.ToDouble(txtPrice.Text);
			}
			catch (Exception ex)
			{
				errorMsg = "Price must contain only digits and not more than one decimal point.";
			}

			// Check stock input is numerical
			try
			{
				Convert.ToInt32(txtStocks.Text);
			}
			catch (Exception ex)
			{
				errorMsg = "Stocks must contain only numbers.";
			}

			return errorMsg;
		}
	}
}