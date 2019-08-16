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
		private FormatLabel FormatLbl;
		
		protected void Page_Load(object sender, EventArgs e)
        {
			// load the label
			FormatLbl = new FormatLabel(lblUploadError);

			// Check if logged in as Artist or not
			if (Session["artist"] == null)
				Response.Redirect("~/Pages/LoginRegister.aspx");

			// Set form default values
			if (!IsPostBack)
			{
				rblIsPublic.Items[0].Selected = true;
				rblForSale.Items[0].Selected = true;
			}
		}

		protected void uploadBt_Click(object sender, EventArgs e)
		{
			

			// Validate form first

			string errorMsg = ValidateForm();

			if (errorMsg != null) // If there is an error
			{
				// Set the error msg
				lblUploadError = FormatLbl.Error(errorMsg);
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

				//debug
				Quick.Print("selected forsale is " + rblIsPublic.SelectedValue);
				
				FileUtil file = new FileUtil(fileBt, "~/Pics/");

				// Set image link
				artpiece.ImageLink = file.GetAddress();

				// VERIFY THAT IMAGE LINK DOES NOT HAVE DUPLICATE NAME
				ArtpieceDao linkCheckDao = new ArtpieceDao();
				Classes.Artpiece checkArtpiece = linkCheckDao.Get("IMAGELINK", file.GetAddress());

				if (checkArtpiece != null) // If there is a duplicate file name
				{
					// Set the error msg
					lblUploadError = FormatLbl.Error("An image with that name already exists. Please rename.");
				}
				else // If there is no duplicate
				{
					Quick.Print(file.GetFileName().Substring(file.GetFileName().Length - 4));
					// Check file type
					if (file.GetFileName().Substring(file.GetFileName().Length - 4) != ".jpg" && file.GetFileName().Substring(file.GetFileName().Length - 4) != ".png" && file.GetFileName().Substring(file.GetFileName().Length - 5) != ".jpeg")
					{
						
						// Show error
						lblUploadError = FormatLbl.Error("File must be a picture file that ends in jpg, png, or jpeg");
					}
					else
					{

						// Perform file upload
						file.PerformUpload();

						// Perform database insert
						ArtpieceDao dao = new ArtpieceDao();
						dao.Add(artpiece);

						//To redirect user to the new artpiece
						Response.Redirect("~/Pages/artpiece.aspx?Id=" + artpiece.ArtpieceId);
					}
				}


				
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
				double price = Convert.ToDouble(txtPrice.Text);

                // Check price input is >= 0.00
                if (price < 0)
                {
                    errorMsg = "Price must be a positive value.";
                }
			}
			catch (Exception ex)
			{
				errorMsg = "Price must contain only digits and not more than one decimal point.";
			}

			// Check stock input is numerical
			try
			{
				int stocks = Convert.ToInt32(txtStocks.Text);

                // Check stock input is >= 0
                if (stocks < 0)
                {
                    errorMsg = "Stocks must be a positive value.";
                }
			}
			catch (Exception ex)
			{
				errorMsg = "Stocks must contain only numbers.";
			}
			

			// Check for empty fields
			if (txtDescription.Text == String.Empty || txtPrice.Text == String.Empty || txtTitle.Text == String.Empty || txtStocks.Text == String.Empty || txtTags.Text == String.Empty || fileBt.HasFile == false)
			{
				errorMsg = "All fields are required.";
			}


			return errorMsg;
		}
	}
}