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

		public Customer(string Id, string Username, string DisplayName, string Email, string Passwd, byte[] PasswordSalt, string CreditCardNo)
		{
			this.Id = Id;
			this.Username = Username;
			this.DisplayName = DisplayName;
			this.Email = Email;
			this.Passwd = Passwd;
			this.PasswordSalt = PasswordSalt;
			this.CreditCardNo = CreditCardNo;
		}

		public static void RegisterCustomer(string Id, string Username, string DisplayName, string Email, string Password, string CreditCardNo)
		{
			Hasher hash = new Hasher(Password);
			Customer customer = new Customer(Id, Username, DisplayName, Email, hash.GetHashedPassword(), hash.GetSalt(), CreditCardNo);
			CustomerDao dao = new CustomerDao();
			dao.Add(customer);
		}
	}
}