using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Bench.Classes
{
    public class Queries
    {
        public static bool FindEmail(string email)
        {
            string QUERY = $"SELECT Email FROM USERS WHERE Email = {email}";
            SqlCommand CMD = new SqlCommand(QUERY);//missing a connection string object
            CMD.ExecuteNonQuery();
            if (CMD.ExecuteNonQuery() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
