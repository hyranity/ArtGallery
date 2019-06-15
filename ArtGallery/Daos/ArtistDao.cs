public class ArtistDao : Dao<T>
{
    private DBUtil DButil {get; set;}

    public ArtistDao()
    {
        DBUtil = new DBUtil();
    }

    public void Add(Artist Artist)
    {
        SqlCommand Cmd = DBUtil.GenerateSql("INSERT INTO Artists(Id, Fname, Lname) VALUES(@Id, @Fname, @Lname)");
        Cmd.Parameters.AddWithValue("@Id", Artist.Id);
        Cmd.Parameters.AddWithValue("@Fname", Artist.Fname);
        Cmd.Parameters.AddWithValue("@Lname", Artist.Lname);
    
        Cmd.ExecuteNonQuery();
    
        DBUtil.Disconnect();
    }
  
    // eg GetArtist("Id", "A001")
    public Artist Get(string Type, string Value)
    {
        SqlCommand Cmd;
        
        if (Type.Equals("Id"))
        {
            Cmd = DBUtil.GenerateSql("SELECT * FROM Artists WHERE ([Id] = @Id)");
            Cmd.Parameters.AddWtihValue("@Id", Value);
            
            SqlDataReader Dr = Cmd.ExecuteReader();
            
            // TBC TBC TBC TBC TBC
            
        }
    }
}
