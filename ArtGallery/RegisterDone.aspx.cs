using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ArtGallery
{
    public partial class RegisterDone : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["Id"];
            string username = Request.QueryString["Username"];
            string email = Request.QueryString["Email"];
            string password = Request.QueryString["Password"];

            lblId.Text = id;
            lblUsername.Text = username;
            lblEmail.Text = email;
            lblPassword.Text = password;
        }
    }
}