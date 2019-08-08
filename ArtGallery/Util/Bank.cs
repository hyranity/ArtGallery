using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ArtGallery.Util
{
	public class Bank
	{

		// Validates credit card with a dummy bank table
		public static bool Validate(string CreditCardNo, string Cvv, string ExpDate, string CardHolderName)
		{
			using (SqlConnection con = DBUtil.BuildConnection())
			{
				con.Open();
				SqlCommand Cmd;

				Cmd = new SqlCommand("SELECT * FROM DummyBank WHERE (CreditCardNo = @Value)", con);
				Cmd.Parameters.AddWithValue("@Value", CreditCardNo);

				// Variables to hold the returned data
				string checkCardNo = "";
				string checkCvv = "";
				string checkExpDate = "";
				string checkCardHolderName = "";

				bool hasResults = false;
				
				using (SqlDataReader Dr = Cmd.ExecuteReader())
				{
					if (Dr.Read())
					{
						/* method thanks to Ron C - https://stackoverflow.com/a/41041029 */
						// int i = 0;
						//return new Artist(Dr.GetString(i++), Dr.GetString(i++), Dr.GetString(i++), Dr.GetString(i++), Dr.GetString(i++), (byte[]) Dr["PasswordSalt"], Dr.GetString(i++));

						// method thanks to Andy Edinborough & Cosmin - https://stackoverflow.com/a/5371281

						checkCardNo = (string)Dr["CreditCardNo"];
						checkCvv = (string)Dr["CVV"];
						checkExpDate = (string)Dr["ExpiryDate"];
						checkCardHolderName = (string)Dr["CardHolderName"];

						hasResults = true;

						Dr.Close();
						con.Close();
					}
				}

				if (hasResults)
				{
					if (CreditCardNo == checkCardNo && Cvv == checkCvv && ExpDate == checkExpDate && CardHolderName == checkCardHolderName)
						return true;
					else
						return false;
				}
				else
					return false;

			}
		}
	}
}