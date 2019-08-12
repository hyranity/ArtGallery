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
	public partial class ArtistAccount : System.Web.UI.Page
	{
		private FormatLabel FormatLbl;
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Session["artist"] == null)
				Response.Redirect("~/Pages/LoginRegister.aspx");
			else
			{
				// Clear error message
				lblEditError.Text = "";

				if (!IsPostBack)
				{
					ArtistDao dao = new ArtistDao();
					Artist artist = (Artist)Session["artist"];

					// Update the one in the session and page
					artist = dao.Get("ARTISTID", artist.Id);
					Session["artist"] = artist;

					//nameLbl.Text = artist.Username + " " + artist.DisplayName;
					//usernameLbl.Text = artist.Id;
					lblName.Text = artist.DisplayName;
					lblUsername.Text = "@" + artist.Username;
					lblBio.Text = artist.Bio;

					username.Text = artist.Username;
					displayName.Text = artist.DisplayName;
					email.Text = artist.Email;
					bio.Text = artist.Bio;
				}
			}

			if (Request.QueryString["Edit"] != null)
				lblEditError = FormatLbl.Success("Account successfully updated");
		}

		private bool ErrorInEdit(Artist artist)
		{
			bool hasError = false;

			// Check for existing username from both tables
			CustomerDao custUsernameDao = new CustomerDao();
			Customer checkCust = custUsernameDao.Get("USERNAME", username.Text);
			ArtistDao artistUsernameDao = new ArtistDao();
			Artist checkArtist = artistUsernameDao.Get("USERNAME", username.Text);


			if (checkArtist != null)
			{
				if (checkArtist.Username == artist.Username)
					checkArtist = null;
			}

			if (checkCust != null || checkArtist != null)
			{
				// There is an existing username
				lblEditError = FormatLbl.Error("An account with this username already exists.");
				lblEditError.ID = "lblEditError";
				hasError = true;
			}

			// Reset values
			checkCust = null;
			checkArtist = null;

			// Check for existing email
			CustomerDao custEmailDao = new CustomerDao();
			checkCust = custEmailDao.Get("EMAIL", email.Text);
			ArtistDao artistEmailDao = new ArtistDao();
			checkArtist = artistEmailDao.Get("EMAIL", email.Text);

			if (checkArtist != null)
			{
				if (checkArtist.Email == artist.Email)
					checkArtist = null;
			}

			if (checkCust != null || checkArtist != null)
			{
				// There is an existing email
				lblEditError = FormatLbl.Error("An account with this email already exists.");
				lblEditError.ID = "lblEditError";
				hasError = true;
			}

			return hasError;
		}

		protected void btnEdit_Click(object sender, EventArgs e)
		{
			Artist OldArtist = (Artist)Session["artist"];

			// Check for empty fields
			if (Quick.IsEmpty(username, email, displayName, bio))
			{
				// There are empty fields
				lblEditError = FormatLbl.Error("Ensure you do not have empty fields (except for password).");
				lblEditError.ID = "lblEditError";
			}
			else
			{
				// Check for valid email
				if (!Quick.CheckRegex(email.Text, @".+\@.+\..+"))
				{
					lblEditError = FormatLbl.Error("Email must be valid.");
					lblEditError.ID = "lblEditError";
				}
				else
				{
					if (!ErrorInEdit(OldArtist))
					{
						string NewPass = OldArtist.Passwd;
						byte[] NewSalt = OldArtist.PasswordSalt;

						// If password is not empty, update password
						if (password.Text != String.Empty)
						{
							Hasher hash = new Hasher(password.Text);
							NewPass = hash.GetHashedPassword();
							NewSalt = hash.GetSalt();
						}

						Artist newArtist = new Artist(OldArtist.Id, username.Text, displayName.Text, email.Text, NewPass, NewSalt, bio.Text);

						ArtistDao dao = new ArtistDao();
						dao.Update(newArtist, OldArtist.Id); //Update the record based on original ID
						Session["artist"] = newArtist; // Update the one in the session
						Response.Redirect("ArtistAccount.aspx?Edit=Success"); // Refreshes the page
					}
				}
			}
		}
	}
}