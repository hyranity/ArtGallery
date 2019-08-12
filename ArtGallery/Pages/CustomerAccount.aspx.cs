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
    public partial class CustomerAccount : System.Web.UI.Page
    {
		private FormatLabel FormatLbl;
        protected void Page_Load(object sender, EventArgs e)
        {
			// Initialize
			FormatLbl = new FormatLabel(lblEditError);

			if (Session["customer"] == null)
				Response.Redirect("~/Pages/LoginRegister.aspx");
			else
			{
				// Clear error message
				lblEditError.Text = "";

				if (!IsPostBack)
				{
					CustomerDao dao = new CustomerDao();
					Customer customer = (Customer)Session["customer"];

					// Update the one in the session and page
					customer = dao.Get("CUSTID", customer.Id);
					Session["customer"] = customer;

					//nameLbl.Text = customer.Username + " " + customer.DisplayName;
					//usernameLbl.Text = customer.Id;
					lblName.Text = customer.DisplayName;
					lblUsername.Text = "@" + customer.Username;

					username.Text = customer.Username;
					displayName.Text = customer.DisplayName;
					email.Text = customer.Email;
					cardNo.Text = customer.CreditCardNo;
					
				}
			}

			if (Request.QueryString["Edit"] != null)
				lblEditError = FormatLbl.Success("Account successfully updated");

			lblEditError.ID = "lblEditError";
		}

		private bool ErrorInEdit(Customer cust)
		{
			bool hasError = false;

			// Check for existing username from both tables
			CustomerDao custUsernameDao = new CustomerDao();
			Customer checkCust = custUsernameDao.Get("USERNAME", username.Text);
			ArtistDao artistUsernameDao = new ArtistDao();
			Artist checkArtist = artistUsernameDao.Get("USERNAME", username.Text);

			if (checkCust != null)
			{
				if (checkCust.Username == cust.Username)
					checkCust = null;
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

			if (checkCust != null)
			{
				if (checkCust.Email == cust.Email)
					checkCust = null;
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
			Customer OldCustomer = (Customer)Session["customer"];
			// Check for empty fields
			if (Quick.IsEmpty(username, email, displayName, cardNo))
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
					if (!ErrorInEdit(OldCustomer))
					{
						string NewPass = OldCustomer.Passwd;
						byte[] NewSalt = OldCustomer.PasswordSalt;

						// If password is not empty
						if (password.Text != String.Empty)
						{
							Hasher hash = new Hasher(password.Text);
							NewPass = hash.GetHashedPassword();
							NewSalt = hash.GetSalt();
						}

						string cardNoStr = "";

						// If no card number is inserted, make the data null
						if (cardNo.Text == String.Empty)
							cardNoStr = "not given";
						else
							cardNoStr = cardNo.Text;

						Customer newCustomer = new Customer(OldCustomer.Id, username.Text, displayName.Text, email.Text, NewPass, NewSalt, cardNoStr);
						CustomerDao dao = new CustomerDao();
						dao.Update(newCustomer, OldCustomer.Id); //Update the record based on original ID
						Session["customer"] = newCustomer; // Update the one in the session
						Response.Redirect("CustomerAccount.aspx?Edit=Success"); // Refreshes the page
					}
				}
			}
		}

		protected void BackBt_Click(object sender, EventArgs e)
		{
			// Get customer
			Customer customer = (Customer) Util.Net.GetSession("customer");

			// Redirect
			Util.Net.Redirect("~/Pages/CustomerProfile.aspx?username="+customer.Username);
		}
	}
}