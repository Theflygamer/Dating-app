using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace dateapp.Personal_Info
{
    class NoLikeProc
    {
        public static void NoLike(int LikeeID, int LikerID)
        {

            using (SqlConnection con = new SqlConnection(SQLCON.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("dbo.NoLike", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@pPersonIDLiker", LikerID));
                cmd.Parameters.Add(new SqlParameter("@pPersonIDLikee", LikeeID));
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
