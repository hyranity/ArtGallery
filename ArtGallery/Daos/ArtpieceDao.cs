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
            
        }

        // crud functions
        public void Add(Artpiece Artpiece)
        {
            // Prevent any connection leak
            using (SqlConnection con = DBUtil.BuildConnection())
            {
                con.Open(); // Open connection to DB
                SqlCommand Cmd = new SqlCommand("INSERT INTO Artpiece(ArtpieceId, ArtistId, Title, About, ImageLink, Price, Stocks, IsForSale, Tags, IsPublic)"
                                    + "VALUES(@ArtpieceId, @ArtistId, @Title, @About, @ImageLink, @Price, @Stocks, @IsForSale, @Tags, @IsPublic)", con);
                Cmd.Parameters.AddWithValue("@ArtpieceId", Artpiece.ArtpieceId);
                Cmd.Parameters.AddWithValue("@ArtistId", Artpiece.ArtistId);
                Cmd.Parameters.AddWithValue("@Title", Artpiece.Title);
                Cmd.Parameters.AddWithValue("@ImageLink", Artpiece.ImageLink);
                Cmd.Parameters.AddWithValue("@Price", Artpiece.Price);
                Cmd.Parameters.AddWithValue("@Stocks", Artpiece.Stocks);
                Cmd.Parameters.AddWithValue("@IsForSale", Artpiece.IsForSale);
                Cmd.Parameters.AddWithValue("@Tags", Artpiece.Tags);
                Cmd.Parameters.AddWithValue("@IsPublic", Artpiece.IsPublic);
                Cmd.Parameters.AddWithValue("@About", Artpiece.About);
                Cmd.ExecuteNonQuery();

                con.Close(); // Close connection to DB
            }
        }

        public Artpiece Get(string Field, string Value)
        {
            using (SqlConnection con = DBUtil.BuildConnection())
            {
                con.Open();
                SqlCommand Cmd;
                Cmd = new SqlCommand("SELECT * FROM Artpiece WHERE ([" + Field + "] = @Value)", con);
                Cmd.Parameters.AddWithValue("@Value", Value);

                using (SqlDataReader Dr = Cmd.ExecuteReader())
                {
                    if (Dr.Read())
                    {
                        /* method thanks to Ron C - https://stackoverflow.com/a/41041029 */
                        // int i = 0;
                        //return new Customer(Dr.GetString(i++), Dr.GetString(i++), Dr.GetString(i++), Dr.GetString(i++), Dr.GetString(i++), (byte[]) Dr["PasswordSalt"], Dr.GetString(i++));

                        // method thanks to Andy Edinborough & Cosmin - https://stackoverflow.com/a/5371281
                        Artpiece artpiece = new Artpiece(
                            (string)Dr["ArtpieceId"],
                            (string)Dr["ArtistId"],
                            (string)Dr["Title"],
                            (string)Dr["About"],
                            (string)Dr["ImageLink"],
                            Convert.ToDouble((decimal)Dr["Price"]),
                            (int)Dr["Stocks"],
                            (bool)Dr["IsForSale"],
                            (string)Dr["Tags"],
                            (bool)Dr["IsPublic"]
                        );

                        Dr.Close();
                        con.Close();
                        return artpiece;
                    }
                }
                con.Close();
                return null;
            }
        }

        public List<Artpiece> GetList(string Field, string Value)
        {
            using (SqlConnection con = DBUtil.BuildConnection())
            {
                con.Open();
                SqlCommand Cmd;
                Cmd = new SqlCommand("SELECT * FROM Artpiece WHERE ([" + Field + "] = @Value)", con);
                
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
                            (string)Dr["About"],
                            (string)Dr["ImageLink"],
                            Convert.ToDouble((decimal)Dr["Price"]),
                            (int)Dr["Stocks"],
                            (bool)Dr["IsForSale"],
                            (string)Dr["Tags"],
                            (bool)Dr["IsPublic"]
                        );*/
                    }

                    Dr.Close();
                    con.Close();
                    if (Artpiece.Any())
                    {
                        return Artpiece;
                    }

                    return null;
                }
            }
        }

        public void Update(Artpiece Artpiece)
        {
            using (SqlConnection con = DBUtil.BuildConnection())
            {
                // SqlCommand Cmd = DBUtil.GenerateSql("UPDATE Customer SET ... WHERE ([CustomerId] = @CustomerId)");
                SqlCommand Cmd = new SqlCommand("UPDATE Artpiece " +
                "SET ArtistId = @ArtistId" +
                ", Title = @Title" +
                ", ImageLink = @ImageLink" +
                ", Price = @Price" +
                ", Stocks = @Stocks" +
                ", IsForSale = @IsForSale" +
                ", Tags = @Tags" +
                ", IsPublic = @IsPublic" +
                " WHERE ArtpieceId = @ArtpieceId", con
            );
                con.Open();
                Cmd.Parameters.AddWithValue("@ArtpieceId", Artpiece.ArtpieceId);
                Cmd.Parameters.AddWithValue("@ArtistId", Artpiece.ArtistId);
                Cmd.Parameters.AddWithValue("@Title", Artpiece.Title);
                Cmd.Parameters.AddWithValue("@ImageLink", Artpiece.ImageLink);
                Cmd.Parameters.AddWithValue("@Price", Artpiece.Price);
                Cmd.Parameters.AddWithValue("@Stocks", Artpiece.Stocks);
                Cmd.Parameters.AddWithValue("@IsForSale", Artpiece.IsForSale);
                Cmd.Parameters.AddWithValue("@Tags", Artpiece.Tags);
                Cmd.Parameters.AddWithValue("@IsPublic", Artpiece.IsPublic);

                Cmd.ExecuteNonQuery();

                con.Close();
            }
        }

        public void Delete(Artpiece Artpiece)
        {
            using (SqlConnection con = DBUtil.BuildConnection())
            {
                con.Open();
                SqlCommand Cmd = new SqlCommand("DELETE FROM Artpiece WHERE ArtpieceId = @ArtpieceId", con);
                
                Cmd.Parameters.AddWithValue("@ArtpieceId", Artpiece.ArtpieceId);

                Cmd.ExecuteNonQuery();

                con.Close();
            }
        }
    }
}