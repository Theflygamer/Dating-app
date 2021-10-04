using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dateapp;
using dateapp.Personal_Info;
using System.Data.SqlClient;

namespace dateapp
{
    class Program
    {
        public static void Main(string[] args)
        {
            SQLCON.SqlConnectionOK();

            TextRendering.FrontMenu();
            
            TextRendering.keypress();

            Console.ReadKey();
        }
    }
}
