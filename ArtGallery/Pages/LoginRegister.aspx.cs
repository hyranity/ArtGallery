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
	public partial class LoginRegister : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			lblRegisterError.Text = "";
			lblLoginError.Text = "";

			// set default choice
			if (!IsPostBack)
				ddlRegisterPosition.SelectedIndex = 0;
		}

		private bool ErrorInReg()
		{
			bool hasError = false;

			// Check for existing username from both tables
			CustomerDao custUsernameDao = new CustomerDao();
			Customer checkCust = custUsernameDao.Get("USERNAME", txtRegisterUsername.Text);
			ArtistDao artistUsernameDao = new ArtistDao();
			Artist checkArtist = artistUsernameDao.Get("USERNAME", txtRegisterUsername.Text);


			if (checkCust != null || checkArtist != null)
			{
				// There is an existing username
				lblRegisterError.Text = "An account with this username already exists.";
				hasError = true;
			}

			// Reset values
			checkCust = null;
			checkArtist = null;

			// Check for existing email
			CustomerDao custEmailDao = new CustomerDao();
			checkCust = custEmailDao.Get("EMAIL", txtRegisterEmail.Text);
			ArtistDao artistEmailDao = new ArtistDao();
			checkArtist = artistEmailDao.Get("EMAIL", txtRegisterEmail.Text);

			if (checkCust != null || checkArtist != null)
			{
				// There is an existing email
				lblRegisterError.Text = "An account with this email already exists.";
				hasError = true;
			}

			return hasError;
		}

        protected void btnRegister_Click(object sender, EventArgs e)
        {
			if (regHasEmptyFields())
			{
				lblRegisterError.Text = "Ensure all fields are filled in.";
			}
			else
			{
				if (!Quick.CheckRegex(txtRegisterEmail.Text, @".+\@.+\..+"))
				{
					lblRegisterError.Text = "Email must be valid.";
				}
				else
				{
					IdGen IdGen = new IdGen();

					// Should be changed to dropdownlist
					if (ddlRegisterPosition.SelectedValue.Equals("Customer"))
					{

						// Register only if there's no error
						if (!ErrorInReg())
						{
							String Id = IdGen.GenerateId("Customer");
							Customer.RegisterCustomer(Id, txtRegisterUsername.Text, txtRegisterDisplayName.Text, txtRegisterEmail.Text, txtRegisterPassword.Text, null);
							Email.SendEmail(txtRegisterEmail.Text, "Welcome to ART-X Gallery", "<h1>Thank you for registering with us!</h1>Do check out the latest creations from our gallery!");
						}
					}

					if (ddlRegisterPosition.SelectedValue.Equals("Artist"))
					{
						// Register only if there's no error
						if (!ErrorInReg())
						{
							String Id = IdGen.GenerateId("Artist");
							Artist.RegisterArtist(Id, txtRegisterUsername.Text, txtRegisterDisplayName.Text, txtRegisterEmail.Text, txtRegisterPassword.Text);
							Email.SendEmail(txtRegisterEmail.Text, "Welcome to ART-X Gallery", "<h1>Thank you for registering with us!</h1>Start sharing your creations with the world!");
						}
					}

					txtRegisterEmail.Text = "";
					txtRegisterDisplayName.Text = "";
					txtRegisterPassword.Text = "";
					txtRegisterPosition.Text = "";
					txtRegisterUsername.Text = "";
				}
			}
        }

		private bool regHasEmptyFields()
		{
			if (Quick.IsEmpty(txtRegisterDisplayName, txtRegisterDisplayName, txtRegisterPassword, txtRegisterUsername))
				return true; 
			else
				return false;
		}

		protected void btnLogin_Click(object sender, EventArgs e)
		{
			bool isCust = true;
			bool hasError = false;

			// Creates both objects to read from both Customer and Artist tables
			CustomerDao custDao = new CustomerDao();
			Customer cust = custDao.Get("USERNAME", txtLoginUsername.Text);

			ArtistDao artistDao = new ArtistDao();
			Artist artist = artistDao.Get("USERNAME", txtLoginUsername.Text);

			if (cust == null)			// If no customer has that username
				if (artist == null)     // If no artist has that username
					hasError = true;    // Then no user has that username
				else
					isCust = false;     // An artist has that username

			if (hasError) // If ID is invalidd
				lblLoginError.Text = "Your username and/or password is invalid.";
			else
			{
				if (isCust) // If the ID belongs to a customer
				{
					// Compare the password
					if (Hasher.ComparePassword(cust.Passwd, txtLoginPassword.Text, cust.PasswordSalt))
					{
						//Login successful
						Quick.Print("Customer logged in.");
						Session["customer"] = cust;
                        Session["order"] = new Order();
                        Session["oaList"] = new List<Order_Artwork>(); // for cart
						Net.Redirect("~/Pages/CustomerProfile.aspx?username=" + cust.Username);
					}
					else
					{
						Quick.Print("Invalid password");
						lblLoginError.Text = "Your username and/or password is invalid.";
					}
				}
				else // If the ID belongs to an artist
				{
					// Compare the password
					if (Hasher.ComparePassword(artist.Passwd, txtLoginPassword.Text, artist.PasswordSalt))
					{
						Quick.Print("Artist logged in.");
						Session["artist"] = artist;
						Net.Redirect("~/Pages/ArtistProfile.aspx?username=" + artist.Username);
					}
					else
					{
						Quick.Print("Invalid password");
						lblLoginError.Text = "Your username and/or password is invalid.";
					}
				}
			}


		}
	}
}