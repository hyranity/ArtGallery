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
            
        }

        // crud functions
        public void Add(WishedArt WishedArt)
        {
            using (SqlConnection con = DBUtil.BuildConnection())
            {
                con.Open();
                SqlCommand Cmd = new SqlCommand("INSERT INTO WishedArt(ArtpieceId, CustId)"
                                + "VALUES(@ArtpieceId, @CustId)", con);
                Cmd.Parameters.AddWithValue("@ArtpieceId", WishedArt.ArtpieceId);
                Cmd.Parameters.AddWithValue("@CustId", WishedArt.CustId);

                Cmd.ExecuteNonQuery();

                con.Close();
            }
        }

        public WishedArt Get(string Field, string Value)
        {
            using (SqlConnection con = DBUtil.BuildConnection())
            {
                con.Open();
                SqlCommand Cmd;
                Cmd = new SqlCommand("SELECT * FROM WishedArt WHERE ([" + Field + "] = @Value)", con);
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
                        con.Close();
                        return wishedArt;
                    }
                }
                con.Close();
                return null;
            }
        }

		public WishedArt GetSpecific(string custId, string artpieceId)
		{
            using (SqlConnection con = DBUtil.BuildConnection())
            {
                con.Open();
                SqlCommand Cmd;
                Cmd = new SqlCommand("SELECT * FROM WishedArt WHERE ([CUSTID] = @CUSTID) AND ([ARTPIECEID] = @ARTPIECEID)", con);
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
                        con.Close();
                        return wishedArt;
                    }
                }
                con.Close();
                return null;
            }
		}

		public List<WishedArt> GetList(string Field, string Value)
        {
            using (SqlConnection con = DBUtil.BuildConnection())
            {
                con.Open();
                SqlCommand Cmd;
                Cmd = new SqlCommand("SELECT * FROM Customer WHERE ([" + Field + "] = @Value)", con);
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
                    con.Close();
                    if (WishedArt.Any())
                    {
                        return WishedArt;
                    }

                    return null;
                }
            }
        }

        public void Update(WishedArt WishedArt)
        {
            using (SqlConnection con = DBUtil.BuildConnection())
            {
                // SqlCommand Cmd = DBUtil.GenerateSql("UPDATE Customer SET ... WHERE ([CustomerId] = @CustomerId)");
                SqlCommand Cmd = new SqlCommand("UPDATE WishedArt " +
                "SET ArtpieceId = @ArtpieceId" +
                ", CustId = @CustId" +
                " WHERE WishIndex = @WishIndex", con
            );
                con.Open();
                Cmd.Parameters.AddWithValue("@WishIndex", WishedArt.WishIndex);
                Cmd.Parameters.AddWithValue("@ArtpieceId", WishedArt.ArtpieceId);
                Cmd.Parameters.AddWithValue("@CustId", WishedArt.CustId);

                Cmd.ExecuteNonQuery();

                con.Close();
            }
        }

        public void Delete(WishedArt WishedArt)
        {
            using (SqlConnection con = DBUtil.BuildConnection())
            {
                con.Open();
                SqlCommand Cmd = new SqlCommand("DELETE FROM WishedArt WHERE WishIndex = @WishIndex", con);
                Cmd.Parameters.AddWithValue("@WishIndex", WishedArt.WishIndex);

                Cmd.ExecuteNonQuery();

                con.Close();
            }
        }
    }
}