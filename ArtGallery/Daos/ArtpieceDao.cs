using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

using ArtGallery.Classes;
using ArtGallery.Util;

namespace ArtGallery.Daos
{
    public class ArtpieceDao : Dao
    {
        public ArtpieceDao()
        {
            DBUtil = new DBUtil();
        }

        // crud functions
        public void Add(Artpiece Artpiece)
        {
            SqlCommand Cmd = DBUtil.GenerateSql("INSERT INTO Artpiece(ArtpieceId, ArtistId, Title, ImageLink, Price, QuantityLeft, IsForSale, Tags, IsPublic)"
                                + "VALUES(@CustomerId, @Fname, @Lname, @Email, @Password, @PasswordSalt, @CreditCardNo)");
            Cmd.Parameters.AddWithValue("@ArtpieceId", Artpiece.ArtpieceId);
            Cmd.Parameters.AddWithValue("@ArtistId", Artpiece.ArtistId);
            Cmd.Parameters.AddWithValue("@Title", Artpiece.Title);
            Cmd.Parameters.AddWithValue("@ImageLink", Artpiece.ImageLink);
            Cmd.Parameters.AddWithValue("@Price", Artpiece.Price);
            Cmd.Parameters.AddWithValue("@QuantityLeft", Artpiece.QuantityLeft);
            Cmd.Parameters.AddWithValue("@ForSale", Artpiece.IsForSale);
            Cmd.Parameters.AddWithValue("@Tags", Artpiece.Tags);
            Cmd.Parameters.AddWithValue("@IsPublic", Artpiece.IsPublic);

            Cmd.ExecuteNonQuery();

            DBUtil.Disconnect();
        }

        public Artpiece Get(string Field, string Value)
        {
            SqlCommand Cmd;
                Cmd = DBUtil.GenerateSql("SELECT * FROM Artpiece WHERE ([" + Field + "] = @Value)");
                Cmd.Parameters.AddWithValue("@Value", Value);

            using (SqlDataReader Dr = Cmd.ExecuteReader())
            {
                if (Dr.Read())
                {
                    /* method thanks to Ron C - https://stackoverflow.com/a/41041029 */
                    // int i = 0;
                    //return new Customer(Dr.GetString(i++), Dr.GetString(i++), Dr.GetString(i++), Dr.GetString(i++), Dr.GetString(i++), (byte[]) Dr["PasswordSalt"], Dr.GetString(i++));

                    // method thanks to Andy Edinborough & Cosmin - https://stackoverflow.com/a/5371281
                    /*return new Artpiece(
                        (string)Dr["ArtpieceId"],
                        (string)Dr["ArtistId"],
                        (string)Dr["Title"],
                        (string)Dr["ImageLink"],
                        (double)Dr["Price"],
                        (int)Dr["QuantityLeft"],
                        (byte[])Dr["IsForSale"],
                        (string)Dr["Tags"],
                        (byte[])Dr["IsPublic"]
                    );*/
                }
            }

            return null;
        }

        public List<Artpiece> GetList(string Field, string Value)
        {
            SqlCommand Cmd;
                Cmd = DBUtil.GenerateSql("SELECT * FROM Artpiece WHERE ([" + Field + "] = @Value)");
                Cmd.Parameters.AddWithValue("@Value", Value);

            using (SqlDataReader Dr = Cmd.ExecuteReader())
            {
                List<Artpiece> Artpiece = new List<Artpiece>();

                while (Dr.Read())
                {
                    /* method thanks to Ron C - https://stackoverflow.com/a/41041029 */
                    // int i = 0;
                    //return new Customer(Dr.GetString(i++), Dr.GetString(i++), Dr.GetString(i++), Dr.GetString(i++), Dr.GetString(i++), (byte[]) Dr["PasswordSalt"], Dr.GetString(i++));

                    // method thanks to Andy Edinborough & Cosmin - https://stackoverflow.com/a/5371281
                    /*Artpiece.Add(new Artpiece(
                        (string)Dr["ArtpieceId"],
                        (string)Dr["ArtistId"],
                        (string)Dr["Title"],
                        (string)Dr["ImageLink"],
                        (double)Dr["Price"],
                        (int)Dr["QuantityLeft"],
                        (byte[])Dr["IsForSale"],
                        (string)Dr["Tags"],
                        (byte[])Dr["IsPublic"])
                    );*/
                }

                if (Artpiece.Any())
                {
                    return Artpiece;
                }

                return null;
            }
        }

        public void Update(Artpiece Artpiece)
        {
            // SqlCommand Cmd = DBUtil.GenerateSql("UPDATE Customer SET ... WHERE ([CustomerId] = @CustomerId)");
            SqlCommand Cmd = DBUtil.GenerateSql("UPDATE Artpiece " +
                "SET ArtistId = @ArtistId" +
                ", Title = @Title" +
                ", ImageLink = @ImageLink" +
                ", Price = @Price" +
                ", QuantityLeft = @QuantityLeft" +
                ", IsForSale = @IsForSale" +
                ", Tags = @Tags" +
                ", IsPublic = @IsPublic" +
                " WHERE ArtpieceId = @ArtpieceId"
            );
            Cmd.Parameters.AddWithValue("@ArtpieceId", Artpiece.ArtpieceId);
            Cmd.Parameters.AddWithValue("@ArtistId", Artpiece.ArtistId);
            Cmd.Parameters.AddWithValue("@Title", Artpiece.Title);
            Cmd.Parameters.AddWithValue("@ImageLink", Artpiece.ImageLink);
            Cmd.Parameters.AddWithValue("@Price", Artpiece.Price);
            Cmd.Parameters.AddWithValue("@QuantityLeft", Artpiece.QuantityLeft);
            Cmd.Parameters.AddWithValue("@ForSale", Artpiece.IsForSale);
            Cmd.Parameters.AddWithValue("@Tags", Artpiece.Tags);
            Cmd.Parameters.AddWithValue("@IsPublic", Artpiece.IsPublic);

            Cmd.ExecuteNonQuery();

            DBUtil.Disconnect();
        }

        public void Delete(Artpiece Artpiece)
        {
            SqlCommand Cmd = DBUtil.GenerateSql("DELETE FROM Artpiece WHERE ArtpieceId = @ArtpieceId");
            Cmd.Parameters.AddWithValue("@ArtpieceId", Artpiece.ArtpieceId);

            Cmd.ExecuteNonQuery();

            DBUtil.Disconnect();
        }
    }
}