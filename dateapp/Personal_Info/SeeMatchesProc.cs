using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace dateapp.Personal_Info
{
    class SeeMatchesProc
    {
        //Her konverterer vi en datetime til en string så personen får alderen frem for fødselsdatoen
        public static int CalculateAge(DateTime birthdate)
        {
            var today = DateTime.Today;
            int age = today.Year - birthdate.Year;
            if (birthdate.Date > today.AddYears(-age)) age--;
            return age;
        }
        //I denne metode regner finder vi kønnet på personen via gender som er en bool.
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
        public static void SeeMatches(int AccountID)
        {

            using (SqlConnection con = new SqlConnection(SQLCON.ConnectionString))
            {


                SqlCommand cmd = new SqlCommand("dbo.SeeMatches", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@pUID", AccountID));
                cmd.Parameters.Add(new SqlParameter("@responseMessage", "@responseMessage OUTPUT"));

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Boolean genderSQL = reader.GetBoolean(2);
                        string gender = CalcGender(genderSQL);
                        DateTime date = reader.GetDateTime(1);
                        int result = CalculateAge(date);
                        Console.WriteLine("Brugernavn: {0}\nAlder: {1}\nKøn: {2}\n", reader.GetString(0), result, gender);
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
