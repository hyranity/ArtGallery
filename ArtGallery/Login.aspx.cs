using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ArtGallery.Util;

namespace ArtGalleryApp
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


		protected void login_Click(object sender, EventArgs e)
		{
			// initialise variables
			string password = "";
			string username = "";

			// validate login
			DBUtil db = new DBUtil();

			SqlCommand cmd = db.GenerateSql("SELECT * FROM Customer WHERE ([Username] = @username) AND ([Password] = @password)");
			cmd.Parameters.AddWithValue("@username", String.Format("{0}", Request.Form["username"]));
			cmd.Parameters.AddWithValue("@password", String.Format("{0}", Request.Form["password"]));

			SqlDataReader dr = cmd.ExecuteReader();

			if (dr.Read())
			{
				password = Convert.ToString(dr["password"]);
				username = Convert.ToString(dr["username"]); ;
				loginText.Text = "Success!";
			}
			else
			{
				password = "N/A";
				username = "N/A";
				loginText.Text = "Error!";
			}

			db.Disconnect();

			// redirect

		}
	}
}