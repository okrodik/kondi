using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kondi
{
    static class BD
    {
        public static SqlConnection conn = new SqlConnection("Data Source = 192.168.166.120\\sqlexpress; Initial Catalog = basa17; User ID = basa17; Password = basa17");

        public static void openSQL()
        {
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }
        }

        public static void closeSQL()
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }
        }
    }
}
