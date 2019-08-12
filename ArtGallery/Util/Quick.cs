using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI.WebControls;

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

		public static string FormatPrice(double price)
		{
			return String.Format("{0:0.00}", price);
		}

		public static bool CheckRegex(string str, string regex)
		{
			Regex rx = new Regex(regex);
			str.Trim();

			if (rx.IsMatch(str))
				return true;
			else
				return false;
		}

		//Check whether textbox is empty or not
		public static bool IsEmpty(TextBox textbox)
		{
			if (textbox.Text == String.Empty)
				return true;
			else
				return false;
		}

		public static bool IsEmpty(TextBox textbox1, TextBox textbox2)
		{
			if (textbox1.Text == String.Empty || textbox2.Text == String.Empty)
				return true;
			else
				return false;
		}

		public static bool IsEmpty(TextBox textbox1, TextBox textbox2, TextBox textbox3)
		{
			if (textbox1.Text == String.Empty || textbox2.Text == String.Empty || textbox3.Text == String.Empty)
				return true;
			else
				return false;
		}
		public static bool IsEmpty(TextBox textbox1, TextBox textbox2, TextBox textbox3, TextBox textbox4)
		{
			if (textbox1.Text == String.Empty || textbox2.Text == String.Empty || textbox3.Text == String.Empty || textbox4.Text == String.Empty)
				return true;
			else
				return false;
		}

		public static bool IsEmpty(TextBox textbox1, TextBox textbox2, TextBox textbox3, TextBox textbox4, TextBox textbox5)
		{
			if (textbox1.Text == String.Empty || textbox2.Text == String.Empty || textbox3.Text == String.Empty || textbox4.Text == String.Empty || textbox5.Text == String.Empty)
				return true;
			else
				return false;
		}

	}
}