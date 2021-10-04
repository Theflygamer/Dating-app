using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace dateapp.Personal_Info
{
    class SendLikeProcedure
    {
        public static void SendLike(int AccountID, int SearchAccountID)
        {

            using (SqlConnection con = new SqlConnection(SQLCON.ConnectionString))
            {


                SqlCommand cmd = new SqlCommand("dbo.SendLike", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@pPersonIDLiker", AccountID));
                cmd.Parameters.Add(new SqlParameter("@pPersonIDLikee", SearchAccountID));
                cmd.Parameters.Add(new SqlParameter("@responseMessage", "@responseMessage OUTPUT"));

                con.Open();

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {

                    }
                }
            }
        }
    }
}
