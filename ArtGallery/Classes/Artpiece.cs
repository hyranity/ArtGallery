using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtGallery.Classes
{
	public class Artpiece
	{
		// variables
		public string ArtistId { get; private set; }
		public string Title { get; private set; }
		public string Description { get; private set; }
		public string ImageUrl { get; private set; }

		// constructors

		public Artpiece()
		{

		}

		public Artpiece(string ArtistId, string Title, string Description, string ImageUrl)
		{
			this.ArtistId = ArtistId;
			this.Title = Title;
			this.Description = Description;
			this.ImageUrl = ImageUrl;
		}
	}
}