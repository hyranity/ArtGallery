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
            List<Order> orders = orderDao.GetList("CustomerId", customer.Id);

            // Display orders
            Control container = this.FindControl("container");

            if (orders == null || orders.Count == 0)
            {

            }
            else
            {
                foreach (Order order in orders)
                {
                    // Get oaList of order
                    List<Order_Artwork> oaList = orderArtworkDao.GetList("OrderId", order.OrderId);

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
                                    "<a class='label'>ORDER ID</a>" +
                                    "<a class='value'>" + order.OrderId + "</a>" +
                                "</div>" +
                                "<div>" +
                                    "<a class='label'>DATE</a>" +
                                    "<a class='value'>" + /* order.Date.ToString("dd/MMM/yyyy") + */ "</a>" + // havent stored order date
                                "</div>" +
                                "<div>" +
                                    "<a class='label'>ITEMS</a>" +
                                    "<a class='value'>" + totalItems + " PCS</a>" +
                                "</div>" +
                                "<div>" +
                                    "<a class='label'>TOTAL</a>" +
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
                                    "<div class='left'>" +
                                        "<img src='" + artpiece.ImageLink + "'>" +
                                    "</div>" +
                                    "<div class='right'>" +
                                        "<a class='title'>" + artpiece.Title + "</a>" +
                                        "<a class='artist'>" + artist.DisplayName + "</a>" +
                                        "<a class='quantity'>" + orderArtwork.Quantity + " PCS</a>" +
                                        "<a class='subtotal'><span>SUBTOTAL</span> RM" + (artpiece.Price * (double)orderArtwork.Quantity) + "</a>" +
                                    "</div>" +
                                "</div>" +
                            "</div>" +
                        "</div>"));
                    }

                    container.Controls.Add(new LiteralControl("</div>"));
                }
            }




        }
    }
}