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
		public bool IsCanceled;
		public DateTime OrderDate;
		public string DeliveryAddress;

		// Constructors

		public Order()
		{
		}

        public Order(string CustomerId, double TotalPrice, bool IsCanceled, DateTime OrderDate, string DeliveryAddress)
        {
            OrderId = GenerateLocalId();
            this.CustomerId = CustomerId;
            this.TotalPrice = TotalPrice;
			this.IsCanceled = IsCanceled;
			this.OrderDate = OrderDate;
			this.DeliveryAddress = DeliveryAddress;
        }

		public Order(string OrderId, string CustomerId, double TotalPrice, bool IsCanceled, DateTime OrderDate, string DeliveryAddress)
		{
			this.OrderId = OrderId;
			this.CustomerId = CustomerId;
			this.TotalPrice = TotalPrice;
			this.IsCanceled = IsCanceled;
			this.OrderDate = OrderDate;
			this.DeliveryAddress = DeliveryAddress;
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