using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtGallery.Classes
{
    public class Artpiece
    {
        // variables
        public string ArtpieceId { get; set; }
        public string ArtistId { get; set; }
        public string Title { get; set; }
        public string About { get; set; }
        public string ImageLink { get; set; }
        public double Price { get; set; }
        public int Stocks { get; set; }
        public Boolean IsForSale { get; set; }
        public string Tags { get; set; }
        public Boolean IsPublic { get; set; }
        // constructors

        public Artpiece()
		{

		}

		public Artpiece(string ArtpieceId, string ArtistId, string Title, string About, string ImageLink, double Price, int Stocks, Boolean IsForSale, string Tags, Boolean IsPublic)
		{
			this.ArtpieceId = ArtpieceId;
			this.ArtistId = ArtistId;
			this.Title = Title;
			this.About = About;
			this.ImageLink = ImageLink;
            this.Price = Price;
            this.Stocks = Stocks;
            this.IsForSale = IsForSale;
            this.Tags = Tags;
            this.IsPublic = IsPublic;

        }
	}
}