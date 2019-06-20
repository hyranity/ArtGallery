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
            DBUtil = new DBUtil();
        }

        // crud functions
        public void Add(Order_Artwork Order_Artwork)
        {
            SqlCommand Cmd = DBUtil.GenerateSql("INSERT INTO Order_Artwork(Index, OrderId, ArtpieceId, Quantity)"
                                + "VALUES(@Index, @OrderId, @ArtpieceId, @Quantity)");
            Cmd.Parameters.AddWithValue("@Index", Order_Artwork.Index);
            Cmd.Parameters.AddWithValue("@OrderId", Order_Artwork.OrderId);
            Cmd.Parameters.AddWithValue("@ArtpeiceId", Order_Artwork.ArtpieceId);
            Cmd.Parameters.AddWithValue("@Quantity", Order_Artwork.Quantity);

            Cmd.ExecuteNonQuery();

            DBUtil.Disconnect();
        }

        public Order_Artwork Get(string Field, string Value)
        {
            SqlCommand Cmd;
                Cmd = DBUtil.GenerateSql("SELECT * FROM Order_Artwork WHERE ([" + Field + "] = @Value)");
                Cmd.Parameters.AddWithValue("@Value", Value);

            using (SqlDataReader Dr = Cmd.ExecuteReader())
            {
                if (Dr.Read())
                {
                    /* method thanks to Ron C - https://stackoverflow.com/a/41041029 */
                    // int i = 0;
                    //return new Customer(Dr.GetString(i++), Dr.GetString(i++), Dr.GetString(i++), Dr.GetString(i++), Dr.GetString(i++), (byte[]) Dr["PasswordSalt"], Dr.GetString(i++));

                    // method thanks to Andy Edinborough & Cosmin - https://stackoverflow.com/a/5371281
                    return new Order_Artwork(
                        (string)Dr["Index"],
                        (string)Dr["OrderId"],
                        (string)Dr["ArtpieceId"],
                        (int)Dr["Quantity"]
                    );
                }
            }

            return null;
        }

        public List<Order_Artwork> GetList(string Field, string Value)
        {
            SqlCommand Cmd;
                Cmd = DBUtil.GenerateSql("SELECT * FROM Order_Artwork WHERE ([" + Field + "] = @Value)");
                Cmd.Parameters.AddWithValue("@Value", Value);

            using (SqlDataReader Dr = Cmd.ExecuteReader())
            {
                List<Order_Artwork> Customer = new List<Order_Artwork>();

                while (Dr.Read())
                {
                    /* method thanks to Ron C - https://stackoverflow.com/a/41041029 */
                    // int i = 0;
                    //return new Customer(Dr.GetString(i++), Dr.GetString(i++), Dr.GetString(i++), Dr.GetString(i++), Dr.GetString(i++), (byte[]) Dr["PasswordSalt"], Dr.GetString(i++));

                    // method thanks to Andy Edinborough & Cosmin - https://stackoverflow.com/a/5371281
                    Order_Artwork.Add(new Order_Artwork(
                        (string)Dr["Index"],
                        (string)Dr["OrderId"],
                        (string)Dr["ArtpieceId"],
                        (int)Dr["Quantity"])
                    );
                }

                if (Order_Artwork.Any())
                {
                    return Order_Artwork;
                }

                return null;
            }
        }
        public void Update(Order_Artwork Order_Artwork)
        {
            // SqlCommand Cmd = DBUtil.GenerateSql("UPDATE Order_Artwork SET ... WHERE ([Index] = @Index)");
            SqlCommand Cmd = DBUtil.GenerateSql("UPDATE Order_Artwork " +
                "SET OrderId = @OrderId" +
                ", ArtpeiceId = @ArtpeiceId" +
                ", Quantity = @Quantity" +
                " WHERE Index = @Index"
            );
            Cmd.Parameters.AddWithValue("@Index", Order_Artwork.Index);
            Cmd.Parameters.AddWithValue("@OrderId", Order_Artwork.OrderId);
            Cmd.Parameters.AddWithValue("@ArtpeiceId", Order_Artwork.ArtpieceId);
            Cmd.Parameters.AddWithValue("@Quantity", Order_Artwork.Quantity);

            Cmd.ExecuteNonQuery();

            DBUtil.Disconnect();
        }

        public void Delete(Order_Artwork Order_Artwork)
        {
            SqlCommand Cmd = DBUtil.GenerateSql("DELETE FROM Order_Artwork WHERE Index = @Index");
            Cmd.Parameters.AddWithValue("@CustomerId", Order_Artwork.Index);

            Cmd.ExecuteNonQuery();

            DBUtil.Disconnect();
        }

    }
    }
}