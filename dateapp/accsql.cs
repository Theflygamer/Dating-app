using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dateapp;


namespace dateapp
{
    public class CreateAccount
    {
        public static void Insert(string navn, string efternavn, string ppassword, string eemail, string username, DateTime birthdate, bool gender, int postnummer)
        {
            using (SqlConnection con = new SqlConnection(SQLCON.ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("dbo.CreateAccount", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@pfirstname", navn));
                cmd.Parameters.Add(new SqlParameter("@plastname", efternavn));
                cmd.Parameters.Add(new SqlParameter("@ppassword", ppassword));
                cmd.Parameters.Add(new SqlParameter("@pemail", eemail));
                cmd.Parameters.Add(new SqlParameter("@pusername", username));
                cmd.Parameters.Add(new SqlParameter("@pbirthdate", birthdate));
                cmd.Parameters.Add(new SqlParameter("@pgender", gender));
                cmd.Parameters.Add(new SqlParameter("@ppostnummer", postnummer));
                cmd.Parameters.Add(new SqlParameter("@responseMessage", "@responseMessage OUTPUT"));

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        
                    }
                }
            }

            Console.Clear();
            Login.Lg();

        }

    }
}
