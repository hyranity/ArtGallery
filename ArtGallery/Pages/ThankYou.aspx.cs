using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ArtGallery.Util;

namespace ArtGallery.Pages
{
    public partial class ThankYou : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			Net.AllowOnly("customer");
        }

		protected void btnProceed_Click(object sender, EventArgs e)
		{
			Net.Redirect("~/Pages/Home.aspx");
		}
	}
}