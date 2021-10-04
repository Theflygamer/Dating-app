using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dateapp.Personal_Info;

namespace dateapp.Personal_Info
{
    public class Profil_match
    {
        public static void match()
        {
            Console.Clear();
            SeeMatchesProc.SeeMatches(usID.Userid);

            string response = "";
            bool checker = false;
            while (checker == false)
            {
                Console.WriteLine("\nTryk y for at gå tilbage til forrige menu");
                var userinput = Console.ReadKey();
                response = userinput.KeyChar.ToString();

                if (response != "y")
                {

                }
                else if (response == "y")
                {
                    Profil_menu.Velkommen();
                    checker = true;
                }
            }
        }
    }
}
