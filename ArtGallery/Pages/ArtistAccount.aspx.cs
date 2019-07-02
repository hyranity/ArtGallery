﻿using ArtGallery.Classes;
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
	public partial class ArtistAccount : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Session["artist"] == null)
				Response.Redirect("~/Pages/LoginRegister.aspx");
			else
			{
				if (!IsPostBack)
				{
					ArtistDao dao = new ArtistDao();
					Artist artist = (Artist)Session["artist"];

					// Update the one in the session and page
					artist = dao.Get("ARTISTID", artist.Id);
					Session["artist"] = artist;

                    //nameLbl.Text = artist.Username + " " + artist.DisplayName;
                    //usernameLbl.Text = artist.Id;
                    lblName.Text = artist.DisplayName;
                    lblUsername.Text = "@" + artist.Username;
                    lblBio.Text = artist.Bio;

					id.Text = artist.Id;
					username.Text = artist.Username;
					displayName.Text = artist.DisplayName;
					email.Text = artist.Email;
					bio.Text = artist.Bio;
				}
			}
		}

		protected void btnEdit_Click(object sender, EventArgs e)
		{
			Artist OldArtist = (Artist)Session["artist"];
			string NewPass = OldArtist.Passwd;
			byte[] NewSalt = OldArtist.PasswordSalt;

			// If password is not empty
			if (password.Text != String.Empty)
			{
				Hasher hash = new Hasher(password.Text);
				 NewPass = hash.GetHashedPassword();
				 NewSalt = hash.GetSalt();
			}

			Artist newArtist = new Artist(id.Text, username.Text, displayName.Text, email.Text, NewPass, NewSalt, bio.Text);
			
			ArtistDao dao = new ArtistDao();
			dao.Update(newArtist, OldArtist.Id); //Update the record based on original ID
			Session["artist"] = newArtist; // Update the one in the session
			Response.Redirect(Request.RawUrl); // Refreshes the page
		}
	}
}