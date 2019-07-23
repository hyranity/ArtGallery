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
		string ConnectStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\ArtGallery.mdf;Integrated Security=True";
		SqlConnection Con;

		// Builds a connection to the database
		public DBUtil()
		{
			
			/*Con = new SqlConnection(ConnectStr);

			// Prevent opening too many connections
			if (Con.State == System.Data.ConnectionState.Open)
				Con.Close();

			Con.Open();*/
		}

		public static SqlConnection BuildConnection()
		{
			string ConnectStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\ArtGallery.mdf;Integrated Security=True";
			return new SqlConnection(ConnectStr);
		}

		public void CheckConnect()
		{
			Con = new SqlConnection(ConnectStr);

			if (Con.State == System.Data.ConnectionState.Closed)
				Connect();
		}
        
		// Generates an SQL 
		public SqlCommand GenerateSql(String query)
		{
			SqlCommand cmd = new SqlCommand(query, Con);
			return cmd;
		}

		// Connects to DB
		public void Connect()
		{
			Con = new SqlConnection(ConnectStr);
			Con.Open();
		}

		// Closes DB connection
		public void Disconnect()
		{
			
				Con.Close();
		}

		/*public static int CountRecords(string Query)
		{
			DBUtil DBUtil = new DBUtil();

			// Get no of records in selected table
			SqlCommand Cmd = DBUtil.GenerateSql(Query);
			DBUtil.CheckConnect();
			DBUtil.Disconnect();

			return Convert.ToInt32(Cmd.ExecuteScalar());
		}*/
		}
	}