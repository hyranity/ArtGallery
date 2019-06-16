using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ArtGallery.Classes;
using ArtGallery.Daos;

namespace ArtGallery
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ArtistDao ArtistDao = new ArtistDao();

			List<Artist> alist = ArtistDao.GetList("fname", "John");
			lbl.Text = alist[0].Fname;
        }
    }
}