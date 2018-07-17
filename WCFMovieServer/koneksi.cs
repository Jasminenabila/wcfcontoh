using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace WCFMovieServer
{
    public class koneksi
    {
        public SqlConnection getConnection()
        {
            SqlConnection sqlcon = new SqlConnection("Data Source= NIA\\SQLEXPRESS;" +
                "Initial Catalog = WCFMovie;" +
                "User Id = sa;" +
                "Password = hanif;"
                );
            return sqlcon;
        }
    }
}