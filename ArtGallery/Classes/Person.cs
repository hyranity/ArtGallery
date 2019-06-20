using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtGallery.Classes
{
	public abstract class Person
	{
		
		public string Id;
		public string Fname;
		public string Lname;
		public string Email;
		public string Passwd;
		public byte[] PasswordSalt;

		// Constructors
		public Person()
		{

		}

		public Person(string Id, string Fname, string Lname, string Email, string Passwd, byte[] PasswordSalt)
		{
			this.Id = Id;
			this.Fname = Fname;
			this.Lname = Lname;
			this.Email = Email;
			this.Passwd = Passwd;
			this.PasswordSalt = PasswordSalt;
		}
	}
}