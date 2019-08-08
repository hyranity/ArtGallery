using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ArtGallery.Util;

namespace ArtGallery.Pages
{
	public partial class ArtGallery : System.Web.UI.MasterPage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			
				Control ctrl;

				if (Net.GetSession("customer") != null)
				{
					// Show customer header
					ctrl = LoadControl("~/Pages/UserControls/CustomerHeader.ascx");
				}
				else if(Net.GetSession("artist") !=null)
				{
					// Show artist header
					ctrl = LoadControl("~/Pages/UserControls/ArtistHeader.ascx");
				}
				else
				{
					// Show default header
					ctrl = LoadControl("~/Pages/UserControls/DefaultHeader.ascx");
				}

				// Add header to placeholder
				HeaderPlaceholder.Controls.Add(ctrl);
			

		}
	}
}