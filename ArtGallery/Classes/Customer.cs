using ArtGallery.Daos;
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

		public static void RegisterCustomer(string Id, string Fname, string Lname, string Email, string Password, string CreditCardNo)
		{
			Hasher hash = new Hasher(Password);
			Customer customer = new Customer(Id, Fname, Lname, Email, hash.GetHashedPassword(), hash.GetSalt(), CreditCardNo);
			CustomerDao dao = new CustomerDao();
			dao.Add(customer);
		}
	}
}