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
			
		}

		protected void btnRegister_Click(object sender, EventArgs e)
		{
			// Should be changed to dropdownlist
			if (txtRegisterPosition.Text == "customer")
				Customer.RegisterCustomer(txtRegisterID.Text, txtRegisterUsername.Text, txtRegisterDisplayName.Text, txtRegisterEmail.Text, txtRegisterPassword.Text, null);

			if (txtRegisterPosition.Text == "artist")
				Artist.RegisterArtist(txtRegisterID.Text, txtRegisterUsername.Text, txtRegisterDisplayName.Text, txtRegisterEmail.Text, txtRegisterPassword.Text);

			txtRegisterID.Text = "";
			txtRegisterEmail.Text = "";
			txtRegisterDisplayName.Text = "";
			txtRegisterPassword.Text = "";
			txtRegisterPosition.Text = "";
			txtRegisterUsername.Text = "";
            Quick.Print("lol!");
        }

		protected void btnLogin_Click(object sender, EventArgs e)
		{
			bool isCust = true;
			bool hasError = false;

			// Creates both objects to read from both Customer and Artist tables
			CustomerDao custDao = new CustomerDao();
			Customer cust = custDao.Get("CUSTID", txtLoginID.Text);

			ArtistDao artistDao = new ArtistDao();
			Artist artist = artistDao.Get("ARTISTID", txtLoginID.Text);

			if (cust == null)			// If no customer has that ID
				if (artist == null)		// If no artist has that ID
					hasError = true;	// Then no user has that ID
				else
					isCust = false;		// An artist has that ID

			if (hasError) // If ID is invalidd
				Quick.Print("Invalid ID!");
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
						Response.Redirect("~/Pages/CustomerAccount.aspx", false);
					}
					else
					{
						Quick.Print("Invalid password");
					}
				}
				else // If the ID belongs to an artist
				{
					// Compare the password
					if (Hasher.ComparePassword(artist.Passwd, txtLoginPassword.Text, artist.PasswordSalt))
					{
						Quick.Print("Artist logged in.");
						Session["artist"] = artist;
						Response.Redirect("~/Pages/ArtistAccount.aspx", false);
					}
					else
					{
						Quick.Print("Invalid password");
					}
				}
			}


		}
	}
}