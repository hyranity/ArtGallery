using ArtGallery.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace ArtGallery
{
	public partial class EditAccount : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Session["username"] == null)
				Response.Redirect("~/Login.aspx");
			lblUsername.Text = Convert.ToString(Session["username"]);
			lblcurr.Text = Convert.ToString(Session["password"]);
		}

		protected void FormView1_PageIndexChanging(object sender, FormViewPageEventArgs e)
		{

		}

		protected void updateBt_Click(object sender, EventArgs e)
		{
			DBUtil db = new DBUtil();
			SqlCommand cmd = db.GenerateSql("UPDATE CUSTOMER SET PASSWORD = @password WHERE USERNAME = @username");
			cmd.Parameters.AddWithValue("@username", lblUsername.Text);
			cmd.Parameters.AddWithValue("@password", newPass.Text);
			cmd.ExecuteNonQuery();

			db.Disconnect();

			
			msg.Text = "Success!";
		}

		protected void newPass_TextChanged(object sender, EventArgs e)
		{

		}
	}
}