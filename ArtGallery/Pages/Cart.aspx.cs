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
        /* ----------------------------------------------------------------------------------------------------
         * Get session attributes to manipulate
         * ---------------------------------------------------------------------------------------------------- */
        public Customer customer = (Customer)Net.GetSession("customer");
        public List<Order_Artwork> oaList = (List<Order_Artwork>)Net.GetSession("oaList");

        /* ----------------------------------------------------------------------------------------------------
         * Initialise daos to use
         * ---------------------------------------------------------------------------------------------------- */
        public ArtpieceDao artpieceDao = new ArtpieceDao();
        public ArtistDao artistDao = new ArtistDao();

        protected void Page_Load(object sender, EventArgs e)
        {



        }
    }
}