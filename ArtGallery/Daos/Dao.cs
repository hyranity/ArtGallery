using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using ArtGallery.Util;

namespace ArtGallery.Daos
{
    public class Dao
    {
        // variables
        protected DBUtil DBUtil { get; set; } // can be used by inherting daos

        // constructor
        public Dao()
        {
            DBUtil = new DBUtil();
        }
    }
}