using ArtGallery.Classes;
using ArtGallery.Daos;
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
        protected void Page_Load(object sender, EventArgs e)
        {
			if (Session["customer"] == null)
				Response.Redirect("~/Pages/LoginRegister.aspx");
			else
			{
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
		}

		protected void btnEdit_Click(object sender, EventArgs e)
		{
			Customer OldCustomer = (Customer)Session["customer"];
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
			Response.Redirect(Request.RawUrl); // Refreshes the page
		}
	}
}