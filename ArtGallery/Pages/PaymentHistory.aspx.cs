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
    public partial class PaymentHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Get session attributes to manipulate
            Customer customer = (Customer)Net.GetSession("customer");

            // Check if customer logged in
            if (customer == null)
            {
                Net.Redirect("~/Pages/LoginRegister.aspx");
            }

            // Initialise daos to use
            ArtpieceDao artpieceDao = new ArtpieceDao();
            ArtistDao artistDao = new ArtistDao();
            CustorderDao orderDao = new CustorderDao();
            OrderArtworkDao orderArtworkDao = new OrderArtworkDao();

            // Get database attributes to manipulate
            List<Order> orders = orderDao.GetList("CUSTID", customer.Id);
            // Display orders
            Control container = this.Master.FindControl("MainContent").FindControl("container");

            if (container == null) { Quick.Print("Null exception"); }


            // DEBUG BOI
            /*List<Order> orders = new List<Order>();
            orders.Add(new Order("CU0000000003", 1500));*/









            if (orders == null || orders.Count == 0)
            {

            }
            else
            {
                int loopCounter = 0;
                foreach (Order order in orders)
                {
                    // Get oaList of order
                    List<Order_Artwork> oaList = orderArtworkDao.GetList("OrderId", order.OrderId);

					// DEBUG BOI
					/*List<Order_Artwork> oaList = new List<Order_Artwork>();
                    oaList.Add(new Order_Artwork(order.OrderId, "AP0000000007", 3, oaList));
                    oaList.Add(new Order_Artwork(order.OrderId, "MILO", 2, oaList));*/


					loopCounter++;

                    // Calculate no of items and total price of order
                    int totalItems = 0;
                    double totalPrice = 0;
                    foreach (Order_Artwork orderArtwork in oaList)
                    {
                        Classes.Artpiece artpiece = artpieceDao.Get("ArtpieceId", orderArtwork.ArtpieceId); 

                        totalItems += orderArtwork.Quantity;
                        totalPrice += artpiece.Price * (double)orderArtwork.Quantity;
                    }

                    container.Controls.Add(new LiteralControl("" +
                        "<div class='box'>" +
                            "<div class='details'>" +
                                "<div>" +
                                    "<a class='text'>ORDER ID</a>" +
                                    "<a class='value'>" + order.OrderId + "</a>" +
                                "</div>" +
                                "<div>" +
                                    "<a class='text'>DATE</a>" +
                                    "<a class='value'>" + order.OrderDate.ToString("dd MMM yyyy") + "</a>" +
                                "</div>" +
                                "<div>" +
                                    "<a class='text'>ITEMS</a>" +
                                    "<a class='value'>" + totalItems + " PCS</a>" +
                                "</div>" +
                                "<div>" +
                                    "<a class='text'>TOTAL</a>" +
                                    "<a class='value'>RM " + totalPrice + "</a>" +
                                "</div>" +
                            "</div>" +
                            "<div class='artpieces'>"));

                    // Display each order artwork in order
                    foreach (Order_Artwork orderArtwork in oaList)
                    {
                        // Get corresponding artpiece and artist
                        Classes.Artpiece artpiece = artpieceDao.Get("ArtpieceId", orderArtwork.ArtpieceId);
                        Classes.Artist artist = artistDao.Get("ArtistId", artpiece.ArtistId);

                        container.Controls.Add(new LiteralControl("" +
                                "<div class='artpiece'>" +
                                    "<div class='left'>"));

                        Image image = new Image();
                        image.ID = "img" + loopCounter.ToString();
                        image.ImageUrl = artpiece.ImageLink;

                        container.Controls.Add(image);

                        container.Controls.Add(new LiteralControl("" +
                                    "</div>" +
                                    "<div class='right'>" +
                                        "<a class='title'>" + artpiece.Title + "</a>" +
                                        "<a class='artist'>" + artist.DisplayName + "</a>" +
                                        "<a class='quantity'>" + orderArtwork.Quantity + " PCS</a>" +
                                        "<a class='subtotal'><span>SUBTOTAL</span> RM" + (artpiece.Price * (double)orderArtwork.Quantity) + "</a>" +
                                    "</div>" +
                                "</div>"));

                        loopCounter++;
                    }

                    container.Controls.Add(new LiteralControl("" +
                            "</div>" +
                        "</div>"));
                }
            }




        }
    }
}