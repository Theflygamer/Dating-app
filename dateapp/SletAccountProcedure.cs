using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dateapp
{
    class SletAccountProcedure
    {
        public static void SletAcc(int AccountID)
        {

            using (SqlConnection con = new SqlConnection(SQLCON.ConnectionString))
            {


                SqlCommand cmd = new SqlCommand("dbo.DeleteAccount", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@pAccountID", AccountID));
                cmd.Parameters.Add(new SqlParameter("@responseMessage", "@responseMessage OUTPUT"));

                con.Open();

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {

                    }
                }


                //using (SqlDataReader rdr = cmd.ExecuteReader())
                //{
                //    while (rdr.Read())
                //    {

                //    }
                //}
            }


        }
    }
}
