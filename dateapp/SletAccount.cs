using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dateapp
{
    class SletAccount
    {
        public static void SA()
        {

            string response = "";
            bool checker = false;
            while (checker == false)
            {
                Console.Clear();
                Console.WriteLine("Tryk y for at slette din konto. Tryk n for at gå tilbage");
                var userinput = Console.ReadKey();
                response = userinput.KeyChar.ToString();

                if (response != "y")
                {
                    if (response != "n")
                    {
                        Console.WriteLine("\nIkke gyldigt");
                    }
                    else
                    {
                        checker = true;
                    }
                }
                else
                {
                    checker = true;
                }
            }

            SletAccountProcedure.SletAcc(usID.Userid);

            Console.Clear();
        }
    }
}
