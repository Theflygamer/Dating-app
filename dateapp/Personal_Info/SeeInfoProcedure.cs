using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace dateapp.Personal_Info
{
    class SeeInfoProcedure
    {
        public static string CalcGender(Boolean gender)
        {
            string GenderResult = "";
            if (gender == true)
            {
                GenderResult = "Mand";
            }
            else if (gender == false)
            {
                GenderResult = "Kvinde";
            }
            return GenderResult;
    
        }
        public static void SeeInfo(int AccountID)
        {

            using (SqlConnection con = new SqlConnection(SQLCON.ConnectionString))
            {


                SqlCommand cmd = new SqlCommand("dbo.SeeInfo", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@pUID", AccountID));
                cmd.Parameters.Add(new SqlParameter("@responseMessage", "@responseMessage OUTPUT"));

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.Clear();
                        byte[] binaryString = (byte[])reader[2];
                        string z = Encoding.Unicode.GetString(binaryString);
                        Boolean genderSQL = reader.GetBoolean(6);
                        string gender = CalcGender(genderSQL);
                        Console.WriteLine("Fornavn: {0}\nEfternavn: {1}\nAdgangskode: {2}\nEmail: {3}\nBrugernavn: {4}\nFødselsdag: {5}\nKøn: {6}\nPostnummer: {7}\n", reader.GetString(0), reader.GetString(1), z, reader.GetString(3),reader.GetString(4),reader.GetDateTime(5),gender,reader.GetInt32(7));
                        

                        

                        // if the original encoding was UTF-1
                    }
                }
                else
                {
                    Console.WriteLine("Error!! :(");
                }
            }
        }
    }
}
