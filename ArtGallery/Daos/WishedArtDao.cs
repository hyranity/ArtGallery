using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

using ArtGallery.Classes;
using ArtGallery.Util;

namespace ArtGallery.Daos
{
    public class WishedArtDao :Dao
    {
        public WishedArtDao()
        {
            DBUtil = new DBUtil();
        }

        // crud functions
        public void Add(WishedArt WishedArt)
        {
            SqlCommand Cmd = DBUtil.GenerateSql("INSERT INTO WishedArt(ArtpieceId, CustId)"
                                + "VALUES(@ArtpieceId, @CustId)");
            Cmd.Parameters.AddWithValue("@ArtpieceId", WishedArt.ArtpieceId);
            Cmd.Parameters.AddWithValue("@CustId", WishedArt.CustId);

            Cmd.ExecuteNonQuery();

            DBUtil.Disconnect();
        }

        public WishedArt Get(string Field, string Value)
        {
            SqlCommand Cmd;
                Cmd = DBUtil.GenerateSql("SELECT * FROM WishedArt WHERE ([" + Field + "] = @Value)");
                Cmd.Parameters.AddWithValue("@Value", Value);

            using (SqlDataReader Dr = Cmd.ExecuteReader())
            {
                if (Dr.Read())
                {
                    /* method thanks to Ron C - https://stackoverflow.com/a/41041029 */
                    // int i = 0;
                    //return new Customer(Dr.GetString(i++), Dr.GetString(i++), Dr.GetString(i++), Dr.GetString(i++), Dr.GetString(i++), (byte[]) Dr["PasswordSalt"], Dr.GetString(i++));

                    // method thanks to Andy Edinborough & Cosmin - https://stackoverflow.com/a/5371281
                    WishedArt wishedArt = new WishedArt(
                        (int)Dr["WishIndex"],
                        (string)Dr["ArtpieceId"],
                        (string)Dr["CustId"]
                    );

                    Dr.Close();

                    return wishedArt;
                }
            }

            return null;
        }

		public WishedArt GetSpecific(string custId, string artpieceId)
		{
			SqlCommand Cmd;
			Cmd = DBUtil.GenerateSql("SELECT * FROM WishedArt WHERE ([CUSTID] = @CUSTID) AND ([ARTPIECEID] = @ARTPIECEID)");
			Cmd.Parameters.AddWithValue("@CUSTID", custId);
			Cmd.Parameters.AddWithValue("@ARTPIECEID", artpieceId);

			using (SqlDataReader Dr = Cmd.ExecuteReader())
			{
				if (Dr.Read())
				{
                    /* method thanks to Ron C - https://stackoverflow.com/a/41041029 */
                    // int i = 0;
                    //return new Customer(Dr.GetString(i++), Dr.GetString(i++), Dr.GetString(i++), Dr.GetString(i++), Dr.GetString(i++), (byte[]) Dr["PasswordSalt"], Dr.GetString(i++));

					// method thanks to Andy Edinborough & Cosmin - https://stackoverflow.com/a/5371281
					WishedArt wishedArt = new WishedArt(
						(int)Dr["WishIndex"],
						(string)Dr["ArtpieceId"],
						(string)Dr["CustId"]
					);

                    Dr.Close();

                    return wishedArt;
				}
			}

			return null;
		}

		public List<WishedArt> GetList(string Field, string Value)
        {
            SqlCommand Cmd;
                Cmd = DBUtil.GenerateSql("SELECT * FROM Customer WHERE ([" + Field + "] = @Value)");
                Cmd.Parameters.AddWithValue("@Value", Value);

            using (SqlDataReader Dr = Cmd.ExecuteReader())
            {
                List<WishedArt> WishedArt = new List<WishedArt>();

                while (Dr.Read())
                {
                    /* method thanks to Ron C - https://stackoverflow.com/a/41041029 */
                    // int i = 0;
                    //return new Customer(Dr.GetString(i++), Dr.GetString(i++), Dr.GetString(i++), Dr.GetString(i++), Dr.GetString(i++), (byte[]) Dr["PasswordSalt"], Dr.GetString(i++));

                    // method thanks to Andy Edinborough & Cosmin - https://stackoverflow.com/a/5371281
                    WishedArt.Add(new WishedArt(
                        (int)Dr["WishIndex"],
                        (string)Dr["ArtpieceId"],
                        (string)Dr["CustId"])
                    );
                }

                Dr.Close();

                if (WishedArt.Any())
                {
                    return WishedArt;
                }

                return null;
            }
        }

        public void Update(WishedArt WishedArt)
        {
            // SqlCommand Cmd = DBUtil.GenerateSql("UPDATE Customer SET ... WHERE ([CustomerId] = @CustomerId)");
            SqlCommand Cmd = DBUtil.GenerateSql("UPDATE WishedArt " +
                "SET ArtpieceId = @ArtpieceId" +
                ", CustId = @CustId" +
                " WHERE WishIndex = @WishIndex"
            );
            Cmd.Parameters.AddWithValue("@WishIndex", WishedArt.WishIndex);
            Cmd.Parameters.AddWithValue("@ArtpieceId", WishedArt.ArtpieceId);
            Cmd.Parameters.AddWithValue("@CustId", WishedArt.CustId);

            Cmd.ExecuteNonQuery();

            DBUtil.Disconnect();
        }

        public void Delete(WishedArt WishedArt)
        {
            SqlCommand Cmd = DBUtil.GenerateSql("DELETE FROM WishedArt WHERE WishIndex = @WishIndex");
            Cmd.Parameters.AddWithValue("@WishIndex", WishedArt.WishIndex);

            Cmd.ExecuteNonQuery();

            DBUtil.Disconnect();
        }
    }
}