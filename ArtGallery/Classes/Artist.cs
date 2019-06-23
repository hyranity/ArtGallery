using ArtGallery.Daos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtGallery.Classes
{
	public class Artist : Person
	{
		public string Bio;

		// constructors
		public Artist()
		{

		}

		public Artist(string Id, string Fname, string Lname, string Email, string Passwd, byte[] PasswordSalt, string Bio)
		{
			this.Id = Id;
			this.Fname = Fname;
			this.Lname = Lname;
			this.Email = Email;
			this.Passwd = Passwd;
			this.PasswordSalt = PasswordSalt;
			this.Bio = Bio;
		}

		public static void RegisterArtist(string Id, string Fname, string Lname, string Email, string Password)
		{
			Hasher hash = new Hasher(Password);
			Artist artist = new Artist(Id, Fname, Lname, Email, hash.GetHashedPassword(), hash.GetSalt(), "Tell us about yourself.");
			ArtistDao dao = new ArtistDao();
			dao.Add(artist);
		}
	}
}