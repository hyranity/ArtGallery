using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtGallery.Classes
{
	public class Order
	{
		public string OrderId; //PK
		public string CustomerId; //FK
		public double TotalPrice;

		// Constructors

		public Order()
		{
		}

		public Order(string OrderId, string CustomerId, double TotalPrice)
		{
			this.OrderId = OrderId;
			this.CustomerId = CustomerId;
			this.TotalPrice = TotalPrice;
		}

	}
}