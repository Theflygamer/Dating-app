using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dateapp;
using dateapp.Personal_Info;

namespace dateapp
{

    public class LoginProcedure
    {
        public static void Login(string uusername, string ppassword)
        {

            using (SqlConnection con = new SqlConnection(SQLCON.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("dbo.Login", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@pusername", uusername));
                cmd.Parameters.Add(new SqlParameter("@ppassword", ppassword));
                cmd.Parameters.Add(new SqlParameter("@responseMessage", "@responseMessage OUTPUT"));

                con.Open();
                try
                {
                    //Virker ikke optimalt. Hvis man indtaster forkert login, crasher programmet. SPØRG PALLE
                    int asd = (int)cmd.ExecuteScalar();
                    usID.Userid = asd;
                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.WriteLine("forkert!");
                    Console.ReadKey();

                    throw;
                }

            }
            Profil_menu.Velkommen();
            
            

            //var usID.Userid = cmd.ExecuteScalar();
            //if (usID.Userid != null)
            //{
            //    return (int)usid.Userid;
            //}
            //else
            //{
            //    return 0;
            //}


        }
    }

}
public class usID
{
    public static int Userid;
}

