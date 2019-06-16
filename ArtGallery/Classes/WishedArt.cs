using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtGallery.Classes
{
	
	public class WishedArt
	{
		public string WishId; //PK
		public string ArtpieceId; //FK
		public string CustId; //FK

		public WishedArt()
		{
		}

		public WishedArt(string WishId, string ArtpieceId, string CustId)
		{
			this.WishId = WishId;
			this.ArtpieceId = ArtpieceId;
			this.CustId = CustId;
		}
	}
}