using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ArtGallery.Util
{
    public class IdGen
    {
        public IdGen()
        {
            // Nothing to see here >_>
        }

        /*
         * Example of GenerateId use:
         *      String ArtistId = IdGen.GenerateId("Artist");
         */
        public String GenerateId(string Type)
        {
            // Initialise variables
            DBUtil DBUtil = new DBUtil();
            String Id = "";

            // Set opening letter set for Id based on selected type
            switch (Type.ToLower())
            {
                case "artist": Id += "AR"; break;
                case "artpiece": Id += "AP"; break;
                case "customer": Id += "CU"; break;
                case "custorder": Id += "CO"; break;
                case "orderartwork": Id += "OA"; break;
                case "wishedart":  Id += "WA"; break;
                default: return null;
            }

            // Get no of records in selected table
            SqlCommand Cmd = DBUtil.GenerateSql("SELECT COUNT(*) FROM " + Type + "");
			DBUtil.CheckConnect();
			int NoOfRecords = Convert.ToInt32(Cmd.ExecuteScalar());

            // Create Id based on no of records
            NoOfRecords++;
            for (int i = 0; i < 10 - NoOfRecords.ToString().Length; i++)
            {
                Id += "0";
            }
            Id += NoOfRecords.ToString();

			DBUtil.Disconnect();

            // Return generated Id
            return Id;
        }

    }
}