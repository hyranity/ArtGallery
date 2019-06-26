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
            DBUtil = new DBUtil();
        }

        // crud functions
        public void Add(Customer Customer)
        {
            SqlCommand Cmd = DBUtil.GenerateSql("INSERT INTO Customer(CustId, Username, DisplayName, Email, Passwd, PasswordSalt, CreditCardNo)"
								+ "VALUES(@CustID, @Username, @DisplayName, @Email, @Passwd, @PasswordSalt, @CreditCardNo)");
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

            DBUtil.Disconnect();
        }

        public Customer Get(string Field, string Value)
        {
            SqlCommand Cmd;

            if (!Field.Equals("Passwd") && !Field.Equals("PasswordSalt"))
            {
                Cmd = DBUtil.GenerateSql("SELECT * FROM Customer WHERE ([" + Field + "] = @Value)");
                Cmd.Parameters.AddWithValue("@Value", Value);
            }
            else
            {
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
                    return new Customer(
                        (string) Dr["CustID"],
                        (string) Dr["Username"],
                        (string) Dr["DisplayName"],
                        (string) Dr["Email"],
                        (string) Dr["Passwd"],
                        (byte[]) Dr["PasswordSalt"],
                        (string) Dr["CreditCardNo"]
                    );
                }
            }

            return null;
        }

        public List<Customer> GetList(string Field, string Value)
        {
            SqlCommand Cmd;

            if (!Field.Equals("Passwd") && !Field.Equals("PasswordSalt"))
            {
                Cmd = DBUtil.GenerateSql("SELECT * FROM Customer WHERE ([" + Field + "] = @Value)");
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
                        (string) Dr["CustID"],
                        (string) Dr["Username"],
                        (string) Dr["DisplayName"],
                        (string) Dr["Email"],
                        (string) Dr["Passwd"],
                        (byte[]) Dr["PasswordSalt"],
                        (string) Dr["CreditCardNo"])
                    );
                }

                if (Customer.Any())
                {
                    return Customer;
                }
                
                return null;
            }
        }

        public void Update(Customer Customer)
        {
            // SqlCommand Cmd = DBUtil.GenerateSql("UPDATE Customer SET ... WHERE ([CustID] = @CustID)");
            SqlCommand Cmd = DBUtil.GenerateSql("UPDATE Customer " +
                "SET Username = @Username" +
                ", DisplayName = @DisplayName" +
                ", Email = @Email" +
				", Passwd = @Passwd" +
                ", PasswordSalt = @PasswordSalt" +
                ", CreditCardNo = @CreditCardNo" +
                " WHERE CustID = @CustID"
            );
            Cmd.Parameters.AddWithValue("@CustID", Customer.Id);
            Cmd.Parameters.AddWithValue("@Username", Customer.Username);
            Cmd.Parameters.AddWithValue("@DisplayName", Customer.DisplayName);
            Cmd.Parameters.AddWithValue("@Email", Customer.Email);
            Cmd.Parameters.AddWithValue("@Passwd", Customer.Passwd);
            Cmd.Parameters.AddWithValue("@PasswordSalt", Customer.PasswordSalt);
            Cmd.Parameters.AddWithValue("@CreditCardNo", Customer.CreditCardNo);

            Cmd.ExecuteNonQuery();

            DBUtil.Disconnect();
        }

        public void Delete(Customer Customer)
        {
            SqlCommand Cmd = DBUtil.GenerateSql("DELETE FROM Customer WHERE CustID = @CustID");
            Cmd.Parameters.AddWithValue("@CustID", Customer.Id);

            Cmd.ExecuteNonQuery();

            DBUtil.Disconnect();
        }

    }
}