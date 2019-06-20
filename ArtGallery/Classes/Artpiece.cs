using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtGallery.Classes
{
    public class Artpiece
    {
        // variables
        public string ArtpieceId { get; private set; }
        public string ArtistId { get; private set; }
        public string Title { get; private set; }
        public string About { get; private set; }
        public string ImageUrl { get; private set; }
        public double Price { get; private set; }
        public int QuantityLeft { get; private set; }
        public Boolean IsForSale { get; private set; }
        public string Tags { get; private set; }

		// constructors

		public Artpiece()
		{

		}

		public Artpiece(string ArtistId, string Title, string About, string ImageUrl, double Price, int QuantityLeft, Boolean IsForSale, string Tags)
		{
			this.ArtistId = ArtistId;
			this.Title = Title;
			this.About = About;
			this.ImageUrl = ImageUrl;
            this.Price = Price;
            this.QuantityLeft = QuantityLeft;
            this.IsForSale = IsForSale;
            this.Tags = Tags;
		}
	}
}