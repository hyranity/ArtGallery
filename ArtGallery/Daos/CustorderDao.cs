using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

using ArtGallery.Classes;
using ArtGallery.Util;

namespace ArtGallery.Daos
{
    public class CustorderDao : Dao
    {
        public CustorderDao()
        {
            DBUtil = new DBUtil();
        }

        // crud functions
        public void Add(Order Custorder)
        {
            SqlCommand Cmd = DBUtil.GenerateSql("INSERT INTO Custorder(OrderId, CustomerId, TotalPrice)"
                                + "VALUES(@OrderId, @CustomerId, @TotalPrice)");
            Cmd.Parameters.AddWithValue("@CustomerId", Custorder.OrderId);
            Cmd.Parameters.AddWithValue("@Fname", Custorder.CustomerId);
            Cmd.Parameters.AddWithValue("@Lname", Custorder.TotalPrice);

            Cmd.ExecuteNonQuery();

            DBUtil.Disconnect();
        }

        public Order Get(string Field, string Value)
        {
            SqlCommand Cmd;

            Cmd = DBUtil.GenerateSql("SELECT * FROM Custorder WHERE ([" + Field + "] = @Value)");
            Cmd.Parameters.AddWithValue("@Value", Value);

            using (SqlDataReader Dr = Cmd.ExecuteReader())
            {
                if (Dr.Read())
                {
                    /* method thanks to Ron C - https://stackoverflow.com/a/41041029 */
                    // int i = 0;
                    //return new Customer(Dr.GetString(i++), Dr.GetString(i++), Dr.GetString(i++), Dr.GetString(i++), Dr.GetString(i++), (byte[]) Dr["PasswordSalt"], Dr.GetString(i++));

                    // method thanks to Andy Edinborough & Cosmin - https://stackoverflow.com/a/5371281
                    return new Order(
                        (string)Dr["OrderId"],
                        (string)Dr["CustomerId"],
                        (double)Dr["TotalPrice"]
                    );
                }
            }

            return null;
        }

        public List<Order> GetList(string Field, string Value)
        {
            SqlCommand Cmd;

            Cmd = DBUtil.GenerateSql("SELECT * FROM Customer WHERE ([" + Field + "] = @Value)");
            Cmd.Parameters.AddWithValue("@Value", Value);

            using (SqlDataReader Dr = Cmd.ExecuteReader())
            {
                List<Order> Order = new List<Order>();

                while (Dr.Read())
                {
                    /* method thanks to Ron C - https://stackoverflow.com/a/41041029 */
                    // int i = 0;
                    //return new Customer(Dr.GetString(i++), Dr.GetString(i++), Dr.GetString(i++), Dr.GetString(i++), Dr.GetString(i++), (byte[]) Dr["PasswordSalt"], Dr.GetString(i++));

                    // method thanks to Andy Edinborough & Cosmin - https://stackoverflow.com/a/5371281
                    Order.Add(new Order(
                        (string)Dr["OrderId"],
                        (string)Dr["CustomerId"],
                        (double)Dr["TotalPrice"])
                    );
                }

                if (Order.Any())
                {
                    return Order;
                }

                return null;
            }
        }

        public void Update(Order Custorder)
        {
            // SqlCommand Cmd = DBUtil.GenerateSql("UPDATE Custorder SET ... WHERE ([OrderId] = @OrderId)");
            SqlCommand Cmd = DBUtil.GenerateSql("UPDATE Custorder " +
                "SET CustomerId = @CustomerId" +
                ", TotalPrice = @TotalPrice" +
                " WHERE OrderId = @OrderId"
            );
            Cmd.Parameters.AddWithValue("@OrderId", Custorder.OrderId);
            Cmd.Parameters.AddWithValue("@CustomerId", Custorder.CustomerId);
            Cmd.Parameters.AddWithValue("@TotalPrice", Custorder.TotalPrice);

            Cmd.ExecuteNonQuery();

            DBUtil.Disconnect();
        }

        public void Delete(Order Custorder)
        {
            SqlCommand Cmd = DBUtil.GenerateSql("DELETE FROM Custorder WHERE OrderId = @OrderId");
            Cmd.Parameters.AddWithValue("@OrderId", Custorder.OrderId);

            Cmd.ExecuteNonQuery();

            DBUtil.Disconnect();
        }
    }
}