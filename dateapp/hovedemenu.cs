using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dateapp;
using dateapp.Personal_Info;

namespace dateapp
{
    public class TextRendering
    {
        public static void FrontMenu()
        {
            Console.Clear();
            WriteText("VELKOMMEN TIL PRODATING", 40, 1, ConsoleColor.Red);
            WriteText("tryk A for at for at oprette en profil", 5, 3, ConsoleColor.Green);
            WriteText("Tryk B for at logge ind", 5, 4, ConsoleColor.Blue);
            WriteText("Tryk C for se profil Menu", 5, 5, ConsoleColor.Yellow);

            Console.WriteLine();
            
        }

        public static void keypress()
        {
            ConsoleKeyInfo inputKey = Console.ReadKey(true);
            switch (inputKey.Key)
            {

                case ConsoleKey.A:
                    create_useracc.acc();
                    break;
                case ConsoleKey.B:
                    Login.Lg();
                    break;
                case ConsoleKey.C:
                    Profil_menu.Velkommen();
                    break;
                default:
                    break;
            }  
        }

        private static void WriteText(string text){
            Console.WriteLine(text);
        }
        
        private static void WriteText(string text, int left, int top) {
            Console.SetCursorPosition(left, top);
            Console.WriteLine(text);
        }

        private static void WriteText(string text, int left, int top, ConsoleColor color) {
            Console.SetCursorPosition(left, top);
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
