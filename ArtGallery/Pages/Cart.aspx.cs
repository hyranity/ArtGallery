using ArtGallery.Classes;
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
		public List<Order_Artwork> oaList;

		protected void Page_Load(object sender, EventArgs e)
        {
			// Check if there is an active cart
			Order order = (Order) Session["order"];

			if (order == null) // if there’s currently no cart
			{
				// Display empty cart message 
			}
			else // if there’s an active cart
			{
				// Get items from session
				oaList = (List<Order_Artwork>)Session["oaList"];
				

				foreach (Order_Artwork oa in oaList)
				{
					// Display items

				}
			}

		}
	}
}