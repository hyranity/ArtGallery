using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/*
 * This class is designed to make programming easier by automating multiple operations or 
 * shortening code needed to achieve a result.
 */

namespace ArtGallery.Util
{
	public class Quick
	{
		public static void Print(string str)
		{
			System.Diagnostics.Debug.Print(str);
		}

		//Code possible thanks to Nikhil Agrawal https://stackoverflow.com/questions/48017535/having-an-int-as-a-sql-parameter
		public static SqlParameter GetParam(int num, string field)
		{
			return new SqlParameter(field, System.Data.SqlDbType.Int)
			{
				Value = num
			};
		}
		
	}
}