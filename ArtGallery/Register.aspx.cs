using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ArtGalleryApp
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submit_Click(object sender, EventArgs e)
        {
            // get req attr
            string id = "M01";
            string username = String.Format("{0}", Request.Form["username"]);
            string email = String.Format("{0}", Request.Form["email"]);
            string password = String.Format("{0}", Request.Form["password"]);

            // validate
            Boolean detailsValidated = false;

            detailsValidated = true;

            // register
            if (detailsValidated)
            {
                string conStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\USER\source\repos\ArtGallery\ArtGallery\App_Data\ArtGalleryDB.mdf;Integrated Security=True";
                SqlConnection con = new SqlConnection(conStr);

                con.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO Members(Id, Username, Email, Password) VALUES (@id, @username, @email, @password)", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", password);

                cmd.ExecuteNonQuery();

                con.Close();
            }

            // redirect
            Response.Redirect("RegisterDone.aspx?Id=" + id + "&Username=" + username + "&Email=" + email + "&Password=" + password);
        }
    }
}