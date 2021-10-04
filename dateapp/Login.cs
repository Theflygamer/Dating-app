using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dateapp;

namespace dateapp
{
    public class Login
    {
        protected static int origRow;
        protected static int origCol;
        protected static void WriteAt(string s, int x, int y)
        {
            try
            {
                Console.SetCursorPosition(origCol + x, origRow + y);
                Console.Write(s);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }

        public static void Lg()
        {
            Console.Clear();
            origRow = Console.CursorTop;
            origCol = Console.CursorLeft;

            // Draw the left side of a 5x5 rectangle, from top to bottom.
            Console.ForegroundColor = ConsoleColor.Green;
            WriteAt("+", 0, 0);
            WriteAt("|", 0, 1);
            WriteAt("|", 0, 2);
            WriteAt("|", 0, 3);
            WriteAt("|", 0, 4);
            WriteAt("|", 0, 5);
            WriteAt("|", 0, 6);
            WriteAt("|", 0, 7);
            WriteAt("|", 0, 8);
            WriteAt("+", 0, 9);

            // Draw the bottom side, from left to right.
            Console.ForegroundColor = ConsoleColor.Green;
            WriteAt("----------------------------------", 1, 9);

            // Draw the right side, from bottom to top.
            Console.ForegroundColor = ConsoleColor.Green;
            WriteAt("+", 35, 0);
            WriteAt("|", 35, 1);
            WriteAt("|", 35, 2);
            WriteAt("|", 35, 3);
            WriteAt("|", 35, 4);
            WriteAt("|", 35, 5);
            WriteAt("|", 35, 6);
            WriteAt("|", 35, 7);
            WriteAt("|", 35, 8);
            WriteAt("+", 35, 9);

            // Draw the top side, from right to left.
            Console.ForegroundColor = ConsoleColor.Green;
            WriteAt("----------------------------------", 1, 0);

            Console.SetCursorPosition(14, 1);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("LOGIN");

            Console.SetCursorPosition(1, 3);
            Console.Write("Indtast Username:");
            string username = Console.ReadLine();

            Console.SetCursorPosition(1, 6);
            Console.Write("Indtast Password:");
            string password = Console.ReadLine();

            LoginProcedure.Login(username, password);

            Console.ReadKey();
        }
        
    }
}
