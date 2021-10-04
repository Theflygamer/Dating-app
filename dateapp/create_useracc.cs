using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dateapp;
namespace dateapp
{
    public class create_useracc
    { 
        public static void acc()
        {
            Console.Clear();
            Console.WriteLine(" indtast dit fornavn");
            
            string navn = Console.ReadLine();

            Console.Clear();
            Console.WriteLine(" indtast dit efternavn");
            string efternavn = Console.ReadLine();

            string gender = "";
            bool checker = false;
            while (checker == false)
            {
                Console.Clear();
                Console.WriteLine("vælg dit køn K=Kvinde M=Mænd");
                var userinput = Console.ReadKey();
                gender = userinput.KeyChar.ToString();

                if (gender != "m")
                {
                    if (gender != "k")
                    {
                        Console.WriteLine("\nForkert!!");
                    }
                    else
                    {
                        Console.WriteLine("\nKorrekt");
                        checker = true;
                    }
                }
                else
                {
                    Console.WriteLine("\nKorrekt");
                    checker = true;
                }
            }
            bool genderbit = true;
            if (gender == "m")
            {
                gender = "Mand";
                genderbit = true;
            }
            else if (gender == "k")
            {
                gender = "Kvinde";
                genderbit = true;
            }
            



            Console.Clear();
            Console.WriteLine(" indtast din føseldagsdato. Format er dd/mm/yyyy");
            string date = Console.ReadLine();
            DateTime dt;
            while (!DateTime.TryParseExact(date, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dt))
            {
                Console.WriteLine("Invalid date, please retry");
                date = Console.ReadLine();
            }


            Console.Clear();
            Console.WriteLine("indstast dit postnummer");
            int postnummer = Convert.ToInt32(Console.ReadLine());

            Console.Clear();
            Console.WriteLine("indstast et username");
            string username = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("indtast dit password");
            string password = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("indtast din email");
            string email = Console.ReadLine();


            CreateAccount.Insert(navn, efternavn, password, email, username, dt, genderbit, postnummer);
            
        }

        private static void writetext(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(text);
            
        }
    }
}
