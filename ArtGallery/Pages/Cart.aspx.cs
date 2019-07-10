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
    public partial class Cart : System.Web.UI.Page
    {
		protected void Page_Load(object sender, EventArgs e)
        {
            /* ----------------------------------------------------------------------------------------------------
             * Get session attributes to manipulate
             * ---------------------------------------------------------------------------------------------------- */
            Customer customer = (Customer)Net.GetSession("customer");
            List<Order_Artwork> oaList = (List<Order_Artwork>)Net.GetSession("oaList");

            /* ----------------------------------------------------------------------------------------------------
             * Check if customer logged in
             * ---------------------------------------------------------------------------------------------------- */
            if (customer == null)
            {
                Response.Redirect("~/Pages/LoginRegister.aspx");
            }

            /* ----------------------------------------------------------------------------------------------------
             * Initialise daos to use
             * ---------------------------------------------------------------------------------------------------- */
            ArtpieceDao artpieceDao = new ArtpieceDao();

            /* ----------------------------------------------------------------------------------------------------
             * Calculate and display number of items and total price of oaList
             * ---------------------------------------------------------------------------------------------------- */
            int noOfItems = 0;
            double totalPrice = 0;
            foreach (Order_Artwork orderArtwork in oaList)
            {
                noOfItems += orderArtwork.Quantity;

                ArtGallery.Classes.Artpiece artpiece = artpieceDao.Get("ArtpieceId", orderArtwork.ArtpieceId);
                totalPrice += (artpiece.Price * (double)orderArtwork.Quantity);
            }
            lblItems.Text = Convert.ToString(noOfItems);
            lblPrice.Text = "RM " + Convert.ToString(totalPrice);

            /* ----------------------------------------------------------------------------------------------------
             * Calculate and display number of items and total price of oaList
             * ---------------------------------------------------------------------------------------------------- */
            
            // TBC

        }
    }
}