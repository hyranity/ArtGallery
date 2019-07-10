using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ArtGallery.Util;

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

        public Order(string CustomerId, double TotalPrice)
        {
            OrderId = GenerateLocalId();
            this.CustomerId = CustomerId;
            this.TotalPrice = TotalPrice;
        }

		public Order(string OrderId, string CustomerId, double TotalPrice)
		{
			this.OrderId = OrderId;
			this.CustomerId = CustomerId;
			this.TotalPrice = TotalPrice;
		}

		// Creates a new order with the first artpiece's price updated
		public static Order CreateNewOrder(Artpiece artpiece)
		{
			// Obtain customer from session
			Customer customer = (Customer) Net.GetSession("customer");

			Order order = new Order();

			//OrderID Generator
			IdGen IdGen = new IdGen();
			order.OrderId = IdGen.GenerateId("Order");

			order.CustomerId = customer.Id; // Get customer ID
			order.TotalPrice = artpiece.Price; // Set total price;

			return order;
		}

        public string GenerateLocalId()
        {
            // For generating a local, temporary index (holding in session before adding to database)
            return "O1"; // Only one order in session at any given moment
        }

    }
}