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
			
        }

        // crud functions
        public void Add(Artist Artist)
        {
			// Prevent any connection leak
			using (SqlConnection con = DBUtil.BuildConnection())
			{
				con.Open(); // Open connection to DB
				SqlCommand Cmd = new SqlCommand("INSERT INTO Artist(ArtistId, Username, DisplayName, Email, Passwd, PasswordSalt, Bio, Active)"
									+ "VALUES(@ArtistId, @Username, @DisplayName, @Email, @Passwd, @PasswordSalt, @Bio, @Active)", con);
				Cmd.Parameters.AddWithValue("@ArtistId", Artist.Id);
				Cmd.Parameters.AddWithValue("@Username", Artist.Username);
				Cmd.Parameters.AddWithValue("@DisplayName", Artist.DisplayName);
				Cmd.Parameters.AddWithValue("@Email", Artist.Email);
				Cmd.Parameters.AddWithValue("@Passwd", Artist.Passwd);
				Cmd.Parameters.AddWithValue("@PasswordSalt", Artist.PasswordSalt);
				Cmd.Parameters.AddWithValue("@Bio", Artist.Bio);
				Cmd.Parameters.AddWithValue("@Active", true);
				Cmd.ExecuteNonQuery();

				con.Close(); // Close connection to DB
			}
        }

        public Artist Get(string Type, string Value)
        {
			using (SqlConnection con = DBUtil.BuildConnection())
			{
				con.Open();
				SqlCommand Cmd;

				if (!Type.Equals("Passwd") && !Type.Equals("PasswordSalt"))
				{
					Cmd = new SqlCommand("SELECT * FROM Artist WHERE ([" + Type + "] = @Value)", con);
					Cmd.Parameters.AddWithValue("@Value", Value);
				}
				else
				{
					con.Close();
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
							(string)Dr["ArtistId"],
							(string)Dr["Username"],
							(string)Dr["DisplayName"],
							(string)Dr["Email"],
							(string)Dr["Passwd"],
							(byte[])Dr["PasswordSalt"],
							(string)Dr["Bio"]
						);

						Dr.Close();
						con.Close();
						return artist;
					}
				}
				con.Close();
				return null;
			}
        }

        public List<Artist> GetList(string Type, string Value)
        {
			using (SqlConnection con = DBUtil.BuildConnection())
			{
				SqlCommand Cmd;

				if (!Type.Equals("Passwd") && !Type.Equals("PasswordSalt"))
				{
                    con.Open();
                    Cmd = new SqlCommand("SELECT * FROM Artist WHERE ([" + Type + "] = @Value)", con);
					
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
							(string)Dr["ArtistId"],
							(string)Dr["Username"],
							(string)Dr["DisplayName"],
							(string)Dr["Email"],
							(string)Dr["Passwd"],
							(byte[])Dr["PasswordSalt"],
							(string)Dr["Bio"])
						);
					}

					Dr.Close();
					con.Close();
					if (Artists.Any())
					{
						return Artists;
					}

					return null;
				}
			}
        }

        public void Update(Artist Artist, string OriginalID)
        {
			using (SqlConnection con = DBUtil.BuildConnection())
			{
				// SqlCommand Cmd = new SqlCommand("UPDATE Artist SET ... WHERE ([ArtistId] = @ArtistId)");
				SqlCommand Cmd = new SqlCommand("UPDATE Artist " +
				"SET ArtistId = @ArtistId, Username = @Username" +
				", DisplayName = @DisplayName" +
				", Email = @Email" +
				", Passwd = @Passwd" +
				", PasswordSalt = @PasswordSalt" +
				", Bio = @Bio" +
				" WHERE ArtistId = @OriginalArtistId", con 
			);
				con.Open();
				Cmd.Parameters.AddWithValue("@ArtistId", Artist.Id);
				Cmd.Parameters.AddWithValue("@OriginalArtistId", OriginalID);
				Cmd.Parameters.AddWithValue("@Username", Artist.Username);
				Cmd.Parameters.AddWithValue("@DisplayName", Artist.DisplayName);
				Cmd.Parameters.AddWithValue("@Email", Artist.Email);
				Cmd.Parameters.AddWithValue("@Passwd", Artist.Passwd);
				Cmd.Parameters.AddWithValue("@PasswordSalt", Artist.PasswordSalt);
				Cmd.Parameters.AddWithValue("@Bio", Artist.Bio);

				Cmd.ExecuteNonQuery();

				con.Close();
			}
        }

		public void Update(Artist Artist)
		{
			using (SqlConnection con = DBUtil.BuildConnection())
			{
				// SqlCommand Cmd = new SqlCommand("UPDATE Artist SET ... WHERE ([ArtistId] = @ArtistId)");
				SqlCommand Cmd = new SqlCommand("UPDATE Artist " +
				"SET Username = @Username" +
				", DisplayName = @DisplayName" +
				", Email = @Email" +
				", Passwd = @Passwd" +
				", PasswordSalt = @PasswordSalt" +
				", Bio = @Bio" +
				" WHERE ArtistId = @ArtistId", con
			);
				con.Open();
				Cmd.Parameters.AddWithValue("@ArtistId", Artist.Id);

				Cmd.Parameters.AddWithValue("@Username", Artist.Username);
				Cmd.Parameters.AddWithValue("@DisplayName", Artist.DisplayName);
				Cmd.Parameters.AddWithValue("@Email", Artist.Email);
				Cmd.Parameters.AddWithValue("@Passwd", Artist.Passwd);
				Cmd.Parameters.AddWithValue("@PasswordSalt", Artist.PasswordSalt);
				Cmd.Parameters.AddWithValue("@Bio", Artist.Bio);

				Cmd.ExecuteNonQuery();
				Quick.Print(Artist.Id);

				con.Close();
			}
		}

		public void Delete(Artist Artist)
        {
			using (SqlConnection con = DBUtil.BuildConnection())
			{
                con.Open();
                SqlCommand Cmd = new SqlCommand("DELETE FROM Artist WHERE ArtistId = @ArtistId", con);
				
				Cmd.Parameters.AddWithValue("@ArtistId", Artist.Id);

				Cmd.ExecuteNonQuery();

				con.Close();
			}
        }	



    }
}