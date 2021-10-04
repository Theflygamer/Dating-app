using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dateapp;

namespace dateapp.Personal_Info
{
    class LikeBack
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
        public static void SeeLikes(int UID)
        {

            using (SqlConnection con = new SqlConnection(SQLCON.ConnectionString))
            {


                SqlCommand cmd = new SqlCommand("dbo.SeeLikes", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@pPersonIDLikee", UID));
                cmd.Parameters.Add(new SqlParameter("@responseMessage", "@responseMessage OUTPUT"));

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.Clear();
                        DateTime date = reader.GetDateTime(1);
                        int result = CalculateAge(date);
                        Boolean genderSQL = reader.GetBoolean(2);
                        string gender = CalcGender(genderSQL);
                        Console.WriteLine("{0}\t{1}\t{2}", reader.GetString(0), result, gender);
                        Console.CursorVisible = (false);

                        
                        int ID = reader.GetInt32(3);
                        string response = "";
                        bool checker = false;
                        while (checker == false)
                        {

                            Console.WriteLine("Vil du like denne person? Tryk y for ja, og n for nej");
                            var userinput = Console.ReadKey();
                            response = userinput.KeyChar.ToString().ToUpper();

                            if (response != "Y")
                            {
                                if (response != "N")
                                {
                                    Console.WriteLine("\nIkke gyldigt");
                                }
                                else if (response == "N")
                                {
                                    NoLikeProc.NoLike(usID.Userid, ID);
                                    checker = true;
                                }
                            }
                            else if (response == "Y")
                            {
                                LikebackProc.LikeBack(usID.Userid, ID);
                                checker = true;
                            }

                        }
                    }
                    Profil_menu.Velkommen();

                }
                else
                {
                    Console.WriteLine("Ingen personer fundet.");
                }
                reader.Close();
            }
        }
    }
        
    
}
