using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

using ArtGallery.Classes;
using ArtGallery.Util;

namespace ArtGallery.Daos
{
    public class CustomerDao : Dao
    {
        public CustomerDao()
        {
            
        }

        // crud functions
        public void Add(Customer Customer)
        {
            using (SqlConnection con = DBUtil.BuildConnection())
            {
                con.Open();
                SqlCommand Cmd = new SqlCommand("INSERT INTO Customer(CustId, Username, DisplayName, Email, Passwd, PasswordSalt, CreditCardNo)"
                                + "VALUES(@CustID, @Username, @DisplayName, @Email, @Passwd, @PasswordSalt, @CreditCardNo)", con);
                Cmd.Parameters.AddWithValue("@CustID", Customer.Id);
                Cmd.Parameters.AddWithValue("@Username", Customer.Username);
                Cmd.Parameters.AddWithValue("@DisplayName", Customer.DisplayName);
                Cmd.Parameters.AddWithValue("@Email", Customer.Email);
                Cmd.Parameters.AddWithValue("@Passwd", Customer.Passwd);
                Cmd.Parameters.AddWithValue("@PasswordSalt", Customer.PasswordSalt);

                if (Customer.CreditCardNo == null)
                    Customer.CreditCardNo = "not given";

                Cmd.Parameters.AddWithValue("@CreditCardNo", Customer.CreditCardNo);

                Cmd.ExecuteNonQuery();

                con.Close();
            }
        }

        public Customer Get(string Field, string Value)
        {
            using (SqlConnection con = DBUtil.BuildConnection())
            {
                con.Open();
                SqlCommand Cmd;

                if (!Field.Equals("Passwd") && !Field.Equals("PasswordSalt"))
                {
                    Cmd = new SqlCommand("SELECT * FROM Customer WHERE ([" + Field + "] = @Value)", con);
                    Cmd.Parameters.AddWithValue("@Value", Value);
                }
                else
                {
                    con.Close();
                    return new Customer();
                }

                using (SqlDataReader Dr = Cmd.ExecuteReader())
                {
                    if (Dr.Read())
                    {
                        /* method thanks to Ron C - https://stackoverflow.com/a/41041029 */
                        // int i = 0;
                        //return new Customer(Dr.GetString(i++), Dr.GetString(i++), Dr.GetString(i++), Dr.GetString(i++), Dr.GetString(i++), (byte[]) Dr["PasswordSalt"], Dr.GetString(i++));

                        // method thanks to Andy Edinborough & Cosmin - https://stackoverflow.com/a/5371281
                        Customer customer = new Customer(
                            (string)Dr["CustID"],
                            (string)Dr["Username"],
                            (string)Dr["DisplayName"],
                            (string)Dr["Email"],
                            (string)Dr["Passwd"],
                            (byte[])Dr["PasswordSalt"],
                            (string)Dr["CreditCardNo"]
                        );

                        Dr.Close();
                        con.Close();
                        return customer;

                    }
                }
                con.Close();
                return null;
            }
        }

        public List<Customer> GetList(string Field, string Value)
        {
            using (SqlConnection con = DBUtil.BuildConnection())
            {
                SqlCommand Cmd;

                if (!Field.Equals("Passwd") && !Field.Equals("PasswordSalt"))
                {
                    con.Open();
                    Cmd = new SqlCommand("SELECT * FROM Customer WHERE ([" + Field + "] = @Value)", con);
                    
                    Cmd.Parameters.AddWithValue("@Value", Value);
                }
                else
                {
                    return null;
                }

                using (SqlDataReader Dr = Cmd.ExecuteReader())
                {
                    List<Customer> Customer = new List<Customer>();

                    while (Dr.Read())
                    {
                        /* method thanks to Ron C - https://stackoverflow.com/a/41041029 */
                        // int i = 0;
                        //return new Customer(Dr.GetString(i++), Dr.GetString(i++), Dr.GetString(i++), Dr.GetString(i++), Dr.GetString(i++), (byte[]) Dr["PasswordSalt"], Dr.GetString(i++));

                        // method thanks to Andy Edinborough & Cosmin - https://stackoverflow.com/a/5371281
                        Customer.Add(new Customer(
                            (string)Dr["CustID"],
                            (string)Dr["Username"],
                            (string)Dr["DisplayName"],
                            (string)Dr["Email"],
                            (string)Dr["Passwd"],
                            (byte[])Dr["PasswordSalt"],
                            (string)Dr["CreditCardNo"])
                        );
                    }

                    Dr.Close();
                    con.Close();
                    if (Customer.Any())
                    {
                        return Customer;
                    }

                    return null;
                }
            }
        }

        public void Update(Customer Customer)
        {
            using (SqlConnection con = DBUtil.BuildConnection())
            {
                // SqlCommand Cmd = DBUtil.GenerateSql("UPDATE Customer SET ... WHERE ([CustID] = @CustID)");
                SqlCommand Cmd = new SqlCommand("UPDATE Customer " +
                "SET Username = @Username" +
                ", DisplayName = @DisplayName" +
                ", Email = @Email" +
                ", Passwd = @Passwd" +
                ", PasswordSalt = @PasswordSalt" +
                ", CreditCardNo = @CreditCardNo" +
                " WHERE CustID = @CustID", con
            );
                con.Open();
                Cmd.Parameters.AddWithValue("@CustID", Customer.Id);
                Cmd.Parameters.AddWithValue("@Username", Customer.Username);
                Cmd.Parameters.AddWithValue("@DisplayName", Customer.DisplayName);
                Cmd.Parameters.AddWithValue("@Email", Customer.Email);
                Cmd.Parameters.AddWithValue("@Passwd", Customer.Passwd);
                Cmd.Parameters.AddWithValue("@PasswordSalt", Customer.PasswordSalt);
                Cmd.Parameters.AddWithValue("@CreditCardNo", Customer.CreditCardNo);

                Cmd.ExecuteNonQuery();

                con.Close();
            }
        }

		public void Update(Customer Customer, string OriginalID)
		{
            using (SqlConnection con = DBUtil.BuildConnection())
            {
                // SqlCommand Cmd = DBUtil.GenerateSql("UPDATE Customer SET ... WHERE ([CustID] = @CustID)");
                SqlCommand Cmd = new SqlCommand("UPDATE Customer " +
                "SET CustID = @CustID, Username = @Username" +
                ", DisplayName = @DisplayName" +
                ", Email = @Email" +
                ", Passwd = @Passwd" +
                ", PasswordSalt = @PasswordSalt" +
                ", CreditCardNo = @CreditCardNo" +
                " WHERE CustID = @OriginalCustID", con
            );
                con.Open();
                Cmd.Parameters.AddWithValue("@CustID", Customer.Id);
                Cmd.Parameters.AddWithValue("@OriginalCustID", OriginalID);
                Cmd.Parameters.AddWithValue("@Username", Customer.Username);
                Cmd.Parameters.AddWithValue("@DisplayName", Customer.DisplayName);
                Cmd.Parameters.AddWithValue("@Email", Customer.Email);
                Cmd.Parameters.AddWithValue("@Passwd", Customer.Passwd);
                Cmd.Parameters.AddWithValue("@PasswordSalt", Customer.PasswordSalt);
                Cmd.Parameters.AddWithValue("@CreditCardNo", Customer.CreditCardNo);

                Cmd.ExecuteNonQuery();

                con.Close();
            }
		}

		public void Delete(Customer Customer)
        {
            using (SqlConnection con = DBUtil.BuildConnection())
            {
                con.Open();
                SqlCommand Cmd = new SqlCommand("DELETE FROM Customer WHERE CustID = @CustID", con);
                
                Cmd.Parameters.AddWithValue("@CustID", Customer.Id);

                Cmd.ExecuteNonQuery();

                con.Close();
            }
        }

    }
}