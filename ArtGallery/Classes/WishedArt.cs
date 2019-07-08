using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtGallery.Classes
{
	
	public class WishedArt
	{
		public int WishIndex; //PK
		public string ArtpieceId; //FK
		public string CustId; //FK

		public WishedArt()
		{
		}

		public WishedArt(int WishIndex, string ArtpieceId, string CustId)
		{
			this.WishIndex = WishIndex;
			this.ArtpieceId = ArtpieceId;
			this.CustId = CustId;
		}

		
	}
}