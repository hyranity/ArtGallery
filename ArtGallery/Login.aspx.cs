using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
            string id = "";
            string username = "";
            string email = "";
            string password = "";

            // validate login
            string conStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\USER\source\repos\ArtGallery\ArtGallery\App_Data\ArtGalleryDB.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(conStr);

            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Members WHERE ([Username] = @username) AND ([Password] = @password)", con);
            cmd.Parameters.AddWithValue("@username", String.Format("{0}", Request.Form["username"]));
            cmd.Parameters.AddWithValue("@password", String.Format("{0}", Request.Form["password"]));

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                id = dr.GetString(dr.GetOrdinal("id"));
                username = dr.GetString(dr.GetOrdinal("username"));
                email = dr.GetString(dr.GetOrdinal("email"));
                password = dr.GetString(dr.GetOrdinal("password"));
            }
            else
            {
                id = "N/A";
                username = "N/A";
                email = "N/A";
                password = "N/A";
            }

            con.Close();

            // redirect
            Response.Redirect("LoginDone.aspx?Id=" + id + "&Username=" + username + "&Email=" + email + "&Password=" + password);
        }
    }
}