using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtGallery.Classes
{
	public class Artist : Person
	{
		public string SelfDescription;

		// constructors
		public Artist()
		{

		}

		public Artist(string Id, string Fname, string Lname, string Email, string Password, byte[] PasswordSalt, string SelfDescription)
		{
			this.Id = Id;
			this.Fname = Fname;
			this.Lname = Lname;
			this.Email = Email;
			this.Password = Password;
			this.PasswordSalt = PasswordSalt;
			this.SelfDescription = SelfDescription;
		}
	}
}