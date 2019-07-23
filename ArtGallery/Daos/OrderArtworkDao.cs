using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

using ArtGallery.Classes;
using ArtGallery.Util;

namespace ArtGallery.Daos
{
    public class OrderArtworkDao : Dao
    {
        public OrderArtworkDao()
        {
            
        }

        // crud functions
        public void Add(Order_Artwork Order_Artwork)
        {
            using (SqlConnection con = DBUtil.BuildConnection())
            {
                con.Open();
                SqlCommand Cmd = new SqlCommand("INSERT INTO Order_Artwork(OrderId, ArtpieceId, Quantity)"
                                + "VALUES(@OrderId, @ArtpieceId, @Quantity)", con);
                // Cmd.Parameters.AddWithValue("@Index", Order_Artwork.Index); Auto generated hence no need to insert
                Cmd.Parameters.AddWithValue("@OrderId", Order_Artwork.OrderId);
                Cmd.Parameters.AddWithValue("@ArtpieceId", Order_Artwork.ArtpieceId);
                Cmd.Parameters.AddWithValue("@Quantity", Order_Artwork.Quantity);

                Cmd.ExecuteNonQuery();

                con.Close();
            }
        }

        public Order_Artwork Get(string Field, string Value)
        {
            using (SqlConnection con = DBUtil.BuildConnection())
            {
                con.Open();
                SqlCommand Cmd;
                Cmd = new SqlCommand("SELECT * FROM Order_Artwork WHERE ([" + Field + "] = @Value)", con);
                Cmd.Parameters.AddWithValue("@Value", Value);

                using (SqlDataReader Dr = Cmd.ExecuteReader())
                {
                    if (Dr.Read())
                    {
                        /* method thanks to Ron C - https://stackoverflow.com/a/41041029 */
                        // int i = 0;
                        //return new Customer(Dr.GetString(i++), Dr.GetString(i++), Dr.GetString(i++), Dr.GetString(i++), Dr.GetString(i++), (byte[]) Dr["PasswordSalt"], Dr.GetString(i++));

                        // method thanks to Andy Edinborough & Cosmin - https://stackoverflow.com/a/5371281
                        Order_Artwork orderArtwork = new Order_Artwork(
                            (int)Dr["Index"],
                            (string)Dr["OrderId"],
                            (string)Dr["ArtpieceId"],
                            (int)Dr["Quantity"]
                        );

                        Dr.Close();
                        con.Close();
                        return orderArtwork;
                    }
                }
                con.Close();
                return null;
            }
        }

        public List<Order_Artwork> GetList(string Field, string Value)
        {
            using (SqlConnection con = DBUtil.BuildConnection())
            {
                con.Open();
                SqlCommand Cmd;
                Cmd = new SqlCommand("SELECT * FROM Order_Artwork WHERE ([" + Field + "] = @Value)", con);
                Cmd.Parameters.AddWithValue("@Value", Value);

                using (SqlDataReader Dr = Cmd.ExecuteReader())
                {
                    List<Order_Artwork> oaList = new List<Order_Artwork>();

                    while (Dr.Read())
                    {
                        /* method thanks to Ron C - https://stackoverflow.com/a/41041029 */
                        // int i = 0;
                        //return new Customer(Dr.GetString(i++), Dr.GetString(i++), Dr.GetString(i++), Dr.GetString(i++), Dr.GetString(i++), (byte[]) Dr["PasswordSalt"], Dr.GetString(i++));

                        // method thanks to Andy Edinborough & Cosmin - https://stackoverflow.com/a/5371281
                        oaList.Add(new Order_Artwork(
                            (int)Dr["Index"],
                            (string)Dr["OrderId"],
                            (string)Dr["ArtpieceId"],
                            (int)Dr["Quantity"]
                        ));
                    }

                    Dr.Close();
                    con.Close();
                    if (oaList.Any())
                    {
                        return oaList;
                    }
                    else
                        return null;
                }
            }
        }
        public void Update(Order_Artwork Order_Artwork)
        {
            using (SqlConnection con = DBUtil.BuildConnection())
            {
                // SqlCommand Cmd = DBUtil.GenerateSql("UPDATE Order_Artwork SET ... WHERE ([Index] = @Index)");
                SqlCommand Cmd = new SqlCommand("UPDATE Order_Artwork " +
                "SET OrderId = @OrderId" +
                ", ArtpeiceId = @ArtpeiceId" +
                ", Quantity = @Quantity" +
                " WHERE Index = @Index", con
            );
                con.Open();
                Cmd.Parameters.AddWithValue("@Index", Order_Artwork.Index);
                Cmd.Parameters.AddWithValue("@OrderId", Order_Artwork.OrderId);
                Cmd.Parameters.AddWithValue("@ArtpeiceId", Order_Artwork.ArtpieceId);
                Cmd.Parameters.AddWithValue("@Quantity", Order_Artwork.Quantity);

                Cmd.ExecuteNonQuery();

                con.Close();
            }
        }

        public void Delete(Order_Artwork Order_Artwork)
        {
            using (SqlConnection con = DBUtil.BuildConnection())
            {
                con.Open();
                SqlCommand Cmd = new SqlCommand("DELETE FROM Order_Artwork WHERE Index = @Index", con);
                Cmd.Parameters.AddWithValue("@CustomerId", Order_Artwork.Index);

                Cmd.ExecuteNonQuery();

                con.Close();
            }
        }

    }
}