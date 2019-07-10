using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtGallery.Classes
{
	public class Order_Artwork
	{
		public string Index; //PK (Meaningless because it's an associative entity
		public string OrderId; //FK
		public string ArtpieceId; //FK
		public int Quantity;

		public Order_Artwork()
		{
		}

        public Order_Artwork(string OrderId, string ArtpieceId, int Quantity, List<Order_Artwork> oaList)
        {
            Index = GenerateLocalId(oaList);
            this.OrderId = OrderId;
            this.ArtpieceId = ArtpieceId;
            this.Quantity = Quantity;
        }

		public Order_Artwork(string Index, string OrderId, string ArtpieceId, int Quantity)
		{
			this.Index = Index;
			this.OrderId = OrderId;
			this.ArtpieceId = ArtpieceId;
			this.Quantity = Quantity;
		}

        public string GenerateLocalId(List<Order_Artwork> oaList)
        {
            // For generating a local, temporary index (holding in session before adding to database)
            return "OA" + Convert.ToString(oaList.Count + 1);
        }
	}
}