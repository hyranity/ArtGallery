using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtGallery.Classes
{
	public class Customer : Person
	{
		public string CreditCardNo;

		//Constructors

		public Customer()
		{
		}

		public Customer(string Id, string Fname, string Lname, string Email, string Password, byte[] PasswordSalt, string CreditCardNo)
		{
			this.Id = Id;
			this.Fname = Fname;
			this.Lname = Lname;
			this.Email = Email;
			this.Password = Password;
			this.PasswordSalt = PasswordSalt;
			this.CreditCardNo = CreditCardNo;
		}
	}
}