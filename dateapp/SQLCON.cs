using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dateapp;
using System.Data.SqlClient;

namespace dateapp
{
    public class SQLCON
    {
        public static string ConnectionString = @"Data Source=localhost;Initial Catalog=datingapp; Integrated Security=SSPI;Connect Timeout=5;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static bool SqlConnectionOK()
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                try
                {
                    con.Open();
                    return true;
                    
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw;
                }

            }
        }

        

    }
}
