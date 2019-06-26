using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtGallery.Classes
{
	public abstract class Person
	{
		
		public string Id;
		public string Username;
		public string DisplayName;
		public string Email;
		public string Passwd;
		public byte[] PasswordSalt;

		// Constructors
		public Person()
		{

		}

		public Person(string Id, string Username, string DisplayName, string Email, string Passwd, byte[] PasswordSalt)
		{
			this.Id = Id;
			this.Username = Username;
			this.DisplayName = DisplayName;
			this.Email = Email;
			this.Passwd = Passwd;
			this.PasswordSalt = PasswordSalt;
		}
	}
}