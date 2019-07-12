using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

using ArtGallery.Classes;
using ArtGallery.Util;

namespace ArtGallery.Daos
{
    public class ArtistDao : Dao
    {
        public ArtistDao()
        {
            DBUtil = new DBUtil();
        }

        // crud functions
        public void Add(Artist Artist)
        {
            SqlCommand Cmd = DBUtil.GenerateSql("INSERT INTO Artist(ArtistId, Username, DisplayName, Email, Passwd, PasswordSalt, Bio, Active)"
								+ "VALUES(@ArtistId, @Username, @DisplayName, @Email, @Passwd, @PasswordSalt, @Bio, @Active)");
			DBUtil.CheckConnect();
			Cmd.Parameters.AddWithValue("@ArtistId", Artist.Id);
            Cmd.Parameters.AddWithValue("@Username", Artist.Username);
            Cmd.Parameters.AddWithValue("@DisplayName", Artist.DisplayName);
            Cmd.Parameters.AddWithValue("@Email", Artist.Email);
            Cmd.Parameters.AddWithValue("@Passwd", Artist.Passwd);
            Cmd.Parameters.AddWithValue("@PasswordSalt", Artist.PasswordSalt);
            Cmd.Parameters.AddWithValue("@Bio", Artist.Bio);
			Cmd.Parameters.AddWithValue("@Active", true);
			Cmd.ExecuteNonQuery();

            DBUtil.Disconnect();
        }

        public Artist Get(string Type, string Value)
        {
            SqlCommand Cmd;

            if (!Type.Equals("Passwd") && !Type.Equals("PasswordSalt"))
            {
                Cmd = DBUtil.GenerateSql("SELECT * FROM Artist WHERE ([" + Type + "] = @Value)");
				DBUtil.CheckConnect();
				Cmd.Parameters.AddWithValue("@Value", Value);
            }
            else
            {
                return new Artist();
            }

            using (SqlDataReader Dr = Cmd.ExecuteReader())
            {
                if (Dr.Read())
                {
                    /* method thanks to Ron C - https://stackoverflow.com/a/41041029 */
                    // int i = 0;
                    //return new Artist(Dr.GetString(i++), Dr.GetString(i++), Dr.GetString(i++), Dr.GetString(i++), Dr.GetString(i++), (byte[]) Dr["PasswordSalt"], Dr.GetString(i++));

                    // method thanks to Andy Edinborough & Cosmin - https://stackoverflow.com/a/5371281
                    Artist artist = new Artist(
                        (string) Dr["ArtistId"],
                        (string) Dr["Username"],
                        (string) Dr["DisplayName"],
                        (string) Dr["Email"],
                        (string) Dr["Passwd"],
                        (byte[]) Dr["PasswordSalt"],
                        (string) Dr["Bio"]
                    );

                    Dr.Close();
					DBUtil.Disconnect();
					return artist;
                }
            }
			DBUtil.Disconnect();
			return null;
        }

        public List<Artist> GetList(string Type, string Value)
        {
            SqlCommand Cmd;

            if (!Type.Equals("Passwd") && !Type.Equals("PasswordSalt"))
            {
                Cmd = DBUtil.GenerateSql("SELECT * FROM Artist WHERE ([" + Type + "] = @Value)");
				DBUtil.CheckConnect();
				Cmd.Parameters.AddWithValue("@Value", Value);
            }
            else
            {
                return null;
            }

            using (SqlDataReader Dr = Cmd.ExecuteReader())
            {
                List<Artist> Artists = new List<Artist>();

                while (Dr.Read())
                {
                    /* method thanks to Ron C - https://stackoverflow.com/a/41041029 */
                    // int i = 0;
                    //return new Artist(Dr.GetString(i++), Dr.GetString(i++), Dr.GetString(i++), Dr.GetString(i++), Dr.GetString(i++), (byte[]) Dr["PasswordSalt"], Dr.GetString(i++));

                    // method thanks to Andy Edinborough & Cosmin - https://stackoverflow.com/a/5371281
                    Artists.Add(new Artist(
                        (string) Dr["ArtistId"],
                        (string) Dr["Username"],
                        (string) Dr["DisplayName"],
                        (string) Dr["Email"],
                        (string) Dr["Passwd"],
                        (byte[]) Dr["PasswordSalt"],
                        (string) Dr["Bio"])
                    );
                }

                Dr.Close();
				DBUtil.Disconnect();
				if (Artists.Any())
                {
                    return Artists;
                }

                return null;
            }
        }

        public void Update(Artist Artist, string OriginalID)
        {
            // SqlCommand Cmd = DBUtil.GenerateSql("UPDATE Artist SET ... WHERE ([ArtistId] = @ArtistId)");
            SqlCommand Cmd = DBUtil.GenerateSql("UPDATE Artist " +
				"SET ArtistId = @ArtistId, Username = @Username" +
                ", DisplayName = @DisplayName" +
                ", Email = @Email" +
				", Passwd = @Passwd" +
                ", PasswordSalt = @PasswordSalt" +
                ", Bio = @Bio" +
                " WHERE ArtistId = @OriginalArtistId"
            );
			DBUtil.CheckConnect();
			Cmd.Parameters.AddWithValue("@ArtistId", Artist.Id);
			Cmd.Parameters.AddWithValue("@OriginalArtistId", OriginalID);
			Cmd.Parameters.AddWithValue("@Username", Artist.Username);
            Cmd.Parameters.AddWithValue("@DisplayName", Artist.DisplayName);
            Cmd.Parameters.AddWithValue("@Email", Artist.Email);
            Cmd.Parameters.AddWithValue("@Passwd", Artist.Passwd);
            Cmd.Parameters.AddWithValue("@PasswordSalt", Artist.PasswordSalt);
            Cmd.Parameters.AddWithValue("@Bio", Artist.Bio);

            Cmd.ExecuteNonQuery();

            DBUtil.Disconnect();
        }

		public void Update(Artist Artist)
		{
			// SqlCommand Cmd = DBUtil.GenerateSql("UPDATE Artist SET ... WHERE ([ArtistId] = @ArtistId)");
			SqlCommand Cmd = DBUtil.GenerateSql("UPDATE Artist " +
				"SET Username = @Username" +
				", DisplayName = @DisplayName" +
				", Email = @Email" +
				", Passwd = @Passwd" +
				", PasswordSalt = @PasswordSalt" +
				", Bio = @Bio" +
				" WHERE ArtistId = @ArtistId"
			);
			DBUtil.CheckConnect();
			Cmd.Parameters.AddWithValue("@ArtistId", Artist.Id);

			Cmd.Parameters.AddWithValue("@Username", Artist.Username);
			Cmd.Parameters.AddWithValue("@DisplayName", Artist.DisplayName);
			Cmd.Parameters.AddWithValue("@Email", Artist.Email);
			Cmd.Parameters.AddWithValue("@Passwd", Artist.Passwd);
			Cmd.Parameters.AddWithValue("@PasswordSalt", Artist.PasswordSalt);
			Cmd.Parameters.AddWithValue("@Bio", Artist.Bio);

			Cmd.ExecuteNonQuery();
			Quick.Print(Artist.Id);

			DBUtil.Disconnect();
		}

		public void Delete(Artist Artist)
        {
            SqlCommand Cmd = DBUtil.GenerateSql("DELETE FROM Artist WHERE ArtistId = @ArtistId");
			DBUtil.CheckConnect();
			Cmd.Parameters.AddWithValue("@ArtistId", Artist.Id);

            Cmd.ExecuteNonQuery();

            DBUtil.Disconnect();
        }	



    }
}