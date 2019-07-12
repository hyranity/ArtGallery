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
            SqlCommand Cmd = DBUtil.GenerateSql("INSERT INTO Artpiece(ArtpieceId, ArtistId, Title, About, ImageLink, Price, Stocks, IsForSale, Tags, IsPublic)"
                                + "VALUES(@ArtpieceId, @ArtistId, @Title, @About, @ImageLink, @Price, @Stocks, @IsForSale, @Tags, @IsPublic)");
			DBUtil.CheckConnect();
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

            DBUtil.Disconnect();
        }

        public Artpiece Get(string Field, string Value)
        {
			
            SqlCommand Cmd;
                Cmd = DBUtil.GenerateSql("SELECT * FROM Artpiece WHERE ([" + Field + "] = @Value)");
                Cmd.Parameters.AddWithValue("@Value", Value);

			DBUtil.CheckConnect();

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
					DBUtil.Disconnect();
					return artpiece;
                }
            }


			DBUtil.Disconnect();
			return null;
        }

        public List<Artpiece> GetList(string Field, string Value)
        {
            SqlCommand Cmd;
                Cmd = DBUtil.GenerateSql("SELECT * FROM Artpiece WHERE ([" + Field + "] = @Value)");
			DBUtil.CheckConnect();
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
				DBUtil.Disconnect();

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
                ", Stocks = @Stocks" +
                ", IsForSale = @IsForSale" +
                ", Tags = @Tags" +
                ", IsPublic = @IsPublic" +
                " WHERE ArtpieceId = @ArtpieceId"
            );
			DBUtil.CheckConnect();
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

            DBUtil.Disconnect();
        }

        public void Delete(Artpiece Artpiece)
        {
            SqlCommand Cmd = DBUtil.GenerateSql("DELETE FROM Artpiece WHERE ArtpieceId = @ArtpieceId");
			DBUtil.CheckConnect();
			Cmd.Parameters.AddWithValue("@ArtpieceId", Artpiece.ArtpieceId);

            Cmd.ExecuteNonQuery();

            DBUtil.Disconnect();
        }
    }
}