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
            SqlCommand Cmd = DBUtil.GenerateSql("INSERT INTO Customer(CustId, Fname, Lname, Email, Password, PasswordSalt, CreditCardNo)"
                                + "VALUES(@CustomerId, @Fname, @Lname, @Email, @Password, @PasswordSalt, @CreditCardNo)");
            Cmd.Parameters.AddWithValue("@CustomerId", Customer.Id);
            Cmd.Parameters.AddWithValue("@Fname", Customer.Fname);
            Cmd.Parameters.AddWithValue("@Lname", Customer.Lname);
            Cmd.Parameters.AddWithValue("@Email", Customer.Email);
            Cmd.Parameters.AddWithValue("@Password", Customer.Password);
            Cmd.Parameters.AddWithValue("@PasswordSalt", Customer.PasswordSalt);
            Cmd.Parameters.AddWithValue("@CreditCardNo", Customer.CreditCardNo);

            Cmd.ExecuteNonQuery();

            DBUtil.Disconnect();
        }

        public Customer Get(string Field, string Value)
        {
            SqlCommand Cmd;

            if (!Field.Equals("Password") && !Field.Equals("PasswordSalt"))
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
                        (string) Dr["CustomerId"],
                        (string) Dr["Fname"],
                        (string) Dr["Lname"],
                        (string) Dr["Email"],
                        (string) Dr["Password"],
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

            if (!Field.Equals("Password") && !Field.Equals("PasswordSalt"))
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
                        (string) Dr["CustomerId"],
                        (string) Dr["Fname"],
                        (string) Dr["Lname"],
                        (string) Dr["Email"],
                        (string) Dr["Password"],
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
            // SqlCommand Cmd = DBUtil.GenerateSql("UPDATE Customer SET ... WHERE ([CustomerId] = @CustomerId)");
            SqlCommand Cmd = DBUtil.GenerateSql("UPDATE Customer " +
                "SET Fname = @Fname" +
                ", Lname = @Lname" +
                ", Email = @Email" +
                ", Password = @Password" +
                ", PasswordSalt = @PasswordSalt" +
                ", CreditCardNo = @CreditCardNo" +
                " WHERE CustomerId = @CustomerId"
            );
            Cmd.Parameters.AddWithValue("@CustomerId", Customer.Id);
            Cmd.Parameters.AddWithValue("@Fname", Customer.Fname);
            Cmd.Parameters.AddWithValue("@Lname", Customer.Lname);
            Cmd.Parameters.AddWithValue("@Email", Customer.Email);
            Cmd.Parameters.AddWithValue("@Password", Customer.Password);
            Cmd.Parameters.AddWithValue("@PasswordSalt", Customer.PasswordSalt);
            Cmd.Parameters.AddWithValue("@CreditCardNo", Customer.CreditCardNo);

            Cmd.ExecuteNonQuery();

            DBUtil.Disconnect();
        }

        public void Delete(Customer Customer)
        {
            SqlCommand Cmd = DBUtil.GenerateSql("DELETE FROM Customer WHERE CustomerId = @CustomerId");
            Cmd.Parameters.AddWithValue("@CustomerId", Customer.Id);

            Cmd.ExecuteNonQuery();

            DBUtil.Disconnect();
        }

    }
}