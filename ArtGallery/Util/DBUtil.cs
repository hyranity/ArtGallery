using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/*
 * The purpose of this class is to simply DB hand coding by automating certain tasks.
 */

namespace ArtGallery.Util
{
	public class DBUtil
	{
		string ConnectStr;
		SqlConnection Con;

		// Builds a connection to the database
		public DBUtil()
		{
			ConnectStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\ArtGallery.mdf;Integrated Security=True";
			Con = new SqlConnection(ConnectStr);
			Con.Open();
		}
        
		// Generates an SQL 
		public SqlCommand GenerateSql(String query)
		{
			SqlCommand cmd = new SqlCommand(query, Con);
			return cmd;
		}

		// Connects to DB (this is automatically done during object construction)
		public void Connect()
		{
			Con.Open();
		}

		// Closes DB connection
		public void Disconnect()
		{
			Con.Close();
		}

		public static int CountRecords(string Query)
		{
			DBUtil DBUtil = new DBUtil();

			// Get no of records in selected table
			SqlCommand Cmd = DBUtil.GenerateSql(Query);

			DBUtil.Disconnect();

			return Convert.ToInt32(Cmd.ExecuteScalar());
		}
	}
}