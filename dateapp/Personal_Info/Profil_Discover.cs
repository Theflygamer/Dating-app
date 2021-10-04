using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dateapp.Personal_Info;

namespace dateapp.Personal_Info
{
    public class Profil_Discover
    {
        public static void SU()
        {
            Console.Clear();
            Console.WriteLine("Indtast startdato: ");
            string startdate = Console.ReadLine();
            DateTime startdt;
            while (!DateTime.TryParseExact(startdate, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out startdt))
            {
                Console.WriteLine("Invalid date, please retry");
                startdate = Console.ReadLine();
            }

            Console.WriteLine("Indtast slutdato: ");
            string slutdate = Console.ReadLine();
            DateTime slutdt;
            while (!DateTime.TryParseExact(slutdate, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out slutdt))
            {
                Console.WriteLine("Invalid date, please retry");
                slutdate = Console.ReadLine();
            }

            SearchUsersProcedure.SearchUsr(startdt, slutdt);


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
