using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dateapp;

namespace dateapp.Personal_Info
{
    class idk
    {
        static void prut()
        {
            Console.CursorVisible = (false);
            idk.SUPUI();
            Console.SetCursorPosition(1, 1);
            Console.Write("Usename: ");

            Console.SetCursorPosition(23, 1);
            Console.Write("Alder: ");

            Console.SetCursorPosition(34, 1);
            Console.Write("køn: ");

            Console.ReadKey();
        }
        public static void SUPUI()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            WriteText1("-----------------------------------------------", 1, 0);
            Console.ForegroundColor = ConsoleColor.Blue;
            WriteText1("-----------------------------------------------", 1, 2);

            Console.ForegroundColor = ConsoleColor.Blue;
            WriteText1("+", 0, 0);
            WriteText1("|", 0, 1);
            WriteText1("+", 0, 2);

            Console.ForegroundColor = ConsoleColor.Blue;
            WriteText1("+", 22, 0);
            WriteText1("|", 22, 1);
            WriteText1("+", 22, 2);

            Console.ForegroundColor = ConsoleColor.Blue;
            WriteText1("+", 33, 0);
            WriteText1("|", 33, 1);
            WriteText1("+", 33, 2);

            Console.ForegroundColor = ConsoleColor.Blue;
            WriteText1("+", 47, 0);
            WriteText1("|", 47, 1);
            WriteText1("+", 47, 2);
        }
        private static void WriteText(string text, int left, int top, ConsoleColor color)
        {
            Console.SetCursorPosition(left, top);
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void WriteText1(string text, int left, int top)
        {
            Console.SetCursorPosition(left, top);
            Console.WriteLine(text);

        }
    }
        
    
}
