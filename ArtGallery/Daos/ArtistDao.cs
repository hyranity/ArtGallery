public class ArtistDao
{
    private DBUtil DButil {get; set;}

    public ArtistDao()
    {
        DBUtil = new DBUtil();
    }

    public void AddArtist(Artist Artist)
    {
        SqlCommand Cmd = DBUtil.GenerateSql("INSERT INTO Artists(Id, Fname, Lname) VALUES(@Id, @Fname, @Lname)");
        Cmd.Parameters.AddWithValue("@Id", Artist.Id);
        Cmd.Parameters.AddWithValue("@Fname", Artist.Fname);
        Cmd.Parameters.AddWithValue("@Lname", Artist.Lname);
    
        Cmd.ExecuteNonQuery();
    
        DBUtil.Disconnect();
    }
  
    // eg GetArtist("id", "A001")
    public void GetArtist(string Type, string Value)
    {
        
    }
}
