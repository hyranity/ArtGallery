using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ArtGallery.Classes;
using ArtGallery.Util;
using ArtGallery.Daos;

namespace ArtGallery.Pages
{
    public partial class Payment : System.Web.UI.Page
    {
		private FormatLabel FormatLbl;
        protected void Page_Load(object sender, EventArgs e)
        {
			Net.AllowOnly("customer");

			Customer cust = (Customer) Session["customer"];
			Order order = (Order)Net.GetSession("order");
			List<Order_Artwork> oaList = (List<Order_Artwork>)Net.GetSession("oaList");

			// if order is empty, redirect to cart
			if (order == null || oaList == null)
				Net.Redirect("~/Pages/Cart.aspx");

			if (!IsPostBack)
			{
				if (cust.CreditCardNo != null)
					txtCardNo.Text = cust.CreditCardNo;

				lblTotalItems.Text = "" + oaList.Count;
				lblTotalPrice.Text = "RM " + Quick.FormatPrice(order.TotalPrice);
			}

			// Initiate error msg label
			FormatLbl = new FormatLabel(lblErrorMsg);
			
		}

		private void pay()
		{
			
				// Get customer details
				Customer customer = (Customer)Net.GetSession("customer");

				// Get count
				List<Order_Artwork> oaList = (List<Order_Artwork>)Net.GetSession("oaList");
				int itemCount = oaList.Count;
				double total = 0;

				// Create order
				Order order = (Order)Net.GetSession("order");
				IdGen IdGen = new IdGen();
				order.OrderId = IdGen.GenerateId("custorder");
				order.OrderDate = DateTime.Now;
				order.IsCanceled = false;
				order.CustomerId = customer.Id;
				order.DeliveryAddress = txtAddress.Text;


				foreach (Order_Artwork oa in oaList)
				{
					// Cumulate price
					ArtpieceDao dao = new ArtpieceDao();
					Classes.Artpiece artpiece = dao.Get("ARTPIECEID", oa.ArtpieceId);

					total += oa.Quantity * artpiece.Price;


					// Set Foreign Keys
					oa.ArtpieceId = artpiece.ArtpieceId;
					oa.OrderId = order.OrderId;

					// Update stocks
					artpiece.Stocks = artpiece.Stocks - oa.Quantity;

					// Update artpiece 
					ArtpieceDao artpieceDao = new ArtpieceDao();
					artpieceDao.Update(artpiece);
				}

				// Set cumulated price as total price
				order.TotalPrice = total;

				// Insert order
				CustorderDao custorderDao = new CustorderDao();
				custorderDao.Add(order);

				// Insert OrderArtwork
				foreach (Order_Artwork oa in oaList)
				{
					OrderArtworkDao orderArtworkDao = new OrderArtworkDao();
					orderArtworkDao.Add(oa);
				}

			// Send receipt
			sendReceipt(order, oaList, customer.Email);

				// Clear cart
				Net.SetSession("order", new Order());
				Net.SetSession("oaList", new List<Order_Artwork>());
				Net.SetSession("cartSaved", false);

				// Redirect
				Net.Redirect("Home.aspx");
			
		}

		protected void btnSubmit_Click(object sender, EventArgs e)
		{
			if (!FormHasError())
			{
				pay();
			}
		}

		private void sendReceipt(Order order, List<Order_Artwork> oaList, string emailAddress)
		{
			string subject = "Thank you for your purchase!";
			string body = 
				"<h1>Your order has been successfully confirmed</h1>" 
				+ "\n<h2>Order ID: " + order.OrderId + "</h2>"
				+ "\n<h2>Order Date: " + order.OrderDate + "</h2>"
				+ "\n<h3>Delivering to: " + order.DeliveryAddress + "</h2>"
				+ "\n<hr/>"
				+ "\n<h4>Order Items</h5>";

			

			foreach(Order_Artwork oa in oaList)
			{
				// Get artpiece name
				ArtpieceDao artpieceDao = new ArtpieceDao();
				Classes.Artpiece artpiece = artpieceDao.Get("ARTPIECEID", oa.ArtpieceId);

				// Get artist name
				ArtistDao artistDao = new ArtistDao();
				Classes.Artist artist = artistDao.Get("ARTISTID", artpiece.ArtistId);

				body += "<b>" + artpiece.Title +"</b> by <i>"+ artist.DisplayName +"</i> ( x"+ oa.Quantity +" )<br/>";
			}

			// Display total
			body += "\n<h4>Total: RM" + Quick.FormatPrice(order.TotalPrice)+ "</h4>";

			// Send email
			Email.SendEmail(emailAddress, subject, body);
		}

		private bool FormHasError()
		{
			string errorMsg = String.Empty;

			if (txtCardHolderName.Text == String.Empty || txtCardNo.Text == String.Empty || txtCvv.Text == String.Empty || txtExpDate.Text == String.Empty || txtAddress.Text == String.Empty)
			{
				errorMsg = "Ensure all fields are filled in.";
			}

			//char[] cardNoChar = txtCardNo.Text.ToCharArray();

			/*for (int i = 0; i < cardNoChar.Length; i++)
			{
				if (!Char.IsDigit(cardNoChar[i]))
					errorMsg = "Ensure that Card No. contains only digits";
			}*/

			// check the credit card
			if (!Bank.Validate(txtCardNo.Text, txtCvv.Text, txtExpDate.Text, txtCardHolderName.Text)) // If card is invalid
			{
				errorMsg = "Credit Card is invalid";
			}

			// Check date
			if (!Quick.checkRegex(txtExpDate.Text, @"\d\d\/\d\d")) // If expDate is not 00/00 format
			{
				errorMsg = "Ensure that Expiry Date is MM/YY format";
			}

			if (errorMsg == String.Empty)
				return false;
			else
			{
				lblErrorMsg = FormatLbl.Error(errorMsg);
				return true;
			}

		}
	}
}