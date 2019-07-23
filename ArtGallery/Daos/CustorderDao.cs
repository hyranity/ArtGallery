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
            
        }

        // crud functions
        public void Add(Order Custorder)
        {
            using (SqlConnection con = DBUtil.BuildConnection())
            {
                con.Open();
                SqlCommand Cmd = new SqlCommand("INSERT INTO Custorder(OrderId, CustId, TotalPrice, IsCanceled, OrderDate)"
                                + "VALUES(@OrderId, @CustId, @TotalPrice, @IsCanceled, @OrderDate)", con);
                Cmd.Parameters.AddWithValue("@OrderId", Custorder.OrderId);
                Cmd.Parameters.AddWithValue("@CustId", Custorder.CustomerId);
                Cmd.Parameters.AddWithValue("@TotalPrice", Custorder.TotalPrice);
                Cmd.Parameters.AddWithValue("@IsCanceled", Custorder.IsCanceled);
                Cmd.Parameters.AddWithValue("@OrderDate", Custorder.OrderDate);

                Cmd.ExecuteNonQuery();

                con.Close();
            }
        }

        public Order Get(string Field, string Value)
        {
            using (SqlConnection con = DBUtil.BuildConnection())
            {
                con.Open();
                SqlCommand Cmd;
                Cmd = new SqlCommand("SELECT * FROM Custorder WHERE ([" + Field + "] = @Value)", con);
                Cmd.Parameters.AddWithValue("@Value", Value);

                using (SqlDataReader Dr = Cmd.ExecuteReader())
                {
                    if (Dr.Read())
                    {
                        /* method thanks to Ron C - https://stackoverflow.com/a/41041029 */
                        // int i = 0;
                        //return new Customer(Dr.GetString(i++), Dr.GetString(i++), Dr.GetString(i++), Dr.GetString(i++), Dr.GetString(i++), (byte[]) Dr["PasswordSalt"], Dr.GetString(i++));

                        // method thanks to Andy Edinborough & Cosmin - https://stackoverflow.com/a/5371281
                        Order order = new Order(
                            (string)Dr["OrderId"],
                            (string)Dr["CustId"],
                            (double)Dr["TotalPrice"],
                            (bool)Dr["IsCanceled"],
                            (DateTime)Dr["OrderDate"]
                        );

                        Dr.Close();
                        con.Close();
                        return order;
                    }
                }
                con.Close();
                return null;
            }
        }

        public List<Order> GetList(string Field, string Value)
        {
            using (SqlConnection con = DBUtil.BuildConnection())
            {
                con.Open();
                SqlCommand Cmd;
                Cmd = new SqlCommand("SELECT * FROM Custorder WHERE ([" + Field + "] = @Value)", con);
                
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
                            (string)Dr["CustId"],
                            Convert.ToDouble((decimal)Dr["TotalPrice"]),
                            (bool)Dr["IsCanceled"],
                            (DateTime)Dr["OrderDate"]
                        ));
                    }

                    Dr.Close();
                    con.Close();
                    if (Order.Any())
                    {
                        return Order;
                    }

                    return null;
                }
            }
        }

        public void Update(Order Custorder)
        {
            using (SqlConnection con = DBUtil.BuildConnection())
            {
                // SqlCommand Cmd = DBUtil.GenerateSql("UPDATE Custorder SET ... WHERE ([OrderId] = @OrderId)");
                SqlCommand Cmd = new SqlCommand("UPDATE Custorder " +
                "SET CustId = @CustId" +
                ", TotalPrice = @TotalPrice" +
                ", IsCanceled = @IsCanceled" +
                ", OrderDate = @OrderDate" +
                " WHERE OrderId = @OrderId", con
            );
                con.Open();
                Cmd.Parameters.AddWithValue("@OrderId", Custorder.OrderId);
                Cmd.Parameters.AddWithValue("@CustId", Custorder.CustomerId);
                Cmd.Parameters.AddWithValue("@TotalPrice", Custorder.TotalPrice);
                Cmd.Parameters.AddWithValue("@IsCanceled", Custorder.IsCanceled);
                Cmd.Parameters.AddWithValue("@OrderDate", Custorder.OrderDate);

                Cmd.ExecuteNonQuery();

                con.Close();
            }
        }

        public void Delete(Order Custorder)
        {
            using (SqlConnection con = DBUtil.BuildConnection())
            {
                con.Open();
                SqlCommand Cmd = new SqlCommand("DELETE FROM Custorder WHERE OrderId = @OrderId", con);
                
                Cmd.Parameters.AddWithValue("@OrderId", Custorder.OrderId);

                Cmd.ExecuteNonQuery();

                con.Close();
            }
        }
    }
}