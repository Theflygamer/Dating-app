using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dateapp.Personal_Info;
using dateapp;

namespace dateapp.Personal_Info
{
    public class Profil_menu
    {
        public static void Velkommen()
        {
            Console.Clear();
            Console.CursorVisible=false;
            WriteText("PROFIL MENU", 14, 1, ConsoleColor.Red);
            WriteText("Tryk A for at se like", 5, 3, ConsoleColor.Magenta);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            WriteText1("-------------------------------------", 1, 4);
            WriteText("Tryk B for at se match", 5, 5, ConsoleColor.Green);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            WriteText1("-------------------------------------", 1, 6);
            WriteText("Tryk C for at se ny Personer", 5, 7, ConsoleColor.Blue);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            WriteText1("-------------------------------------", 1, 8);
            WriteText("Tryk D for at se din egen profil", 5, 9, ConsoleColor.Red);
            WriteText("Tryk X for log out", 1, 14, ConsoleColor.Gray);

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            WriteText1("+", 0, 0);
            WriteText1("|", 0, 1);
            WriteText1("|", 0, 2);
            WriteText1("|", 0, 3);
            WriteText1("|", 0, 4);
            WriteText1("|", 0, 5);
            WriteText1("|", 0, 6);
            WriteText1("|", 0, 7);
            WriteText1("|", 0, 8);
            WriteText1("|", 0, 9);
            WriteText1("+", 0, 10);

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            WriteText1("--------------------------------------", 1, 10);


            Console.ForegroundColor = ConsoleColor.DarkYellow;
            WriteText1("+", 39, 0);
            WriteText1("|", 39, 1);
            WriteText1("|", 39, 2);
            WriteText1("|", 39, 3);
            WriteText1("|", 39, 4);
            WriteText1("|", 39, 5);
            WriteText1("|", 39, 6);
            WriteText1("|", 39, 7);
            WriteText1("|", 39, 8);
            WriteText1("|", 39, 9);
            WriteText1("+", 39, 10);


            Console.ForegroundColor = ConsoleColor.DarkYellow;
            WriteText1("--------------------------------------", 1, 0);

            ConsoleKeyInfo inputKey = Console.ReadKey(true);
            switch (inputKey.Key)
            {
                case ConsoleKey.A:
                    Profil_like.Like();
                    break;
                case ConsoleKey.B:
                    Profil_match.match();
                    break;
                case ConsoleKey.C:
                    Profil_Discover.SU();
                    break;
                case ConsoleKey.D:
                    Se_profil.Get_ProfilData();
                    break;
                case ConsoleKey.X:
                    TextRendering.FrontMenu();
                    TextRendering.keypress();
                    break;
                default:
                    break;
            }
            Console.ReadKey();

        }
        //public static void MenuKeys()
        //{

        //    ConsoleKeyInfo inputKey = Console.ReadKey(true);
        //    switch (inputKey.Key)
        //    {
        //case ConsoleKey.A:
        //    Profil_like.SU();
        //    break;
        //        case ConsoleKey.B:
        //            Profil_match.match();
        //            break;
        //        case ConsoleKey.C:
        //            Profil_Discover.SU();
        //            break;
        //        default:
        //            break;
        //    }
        //    Console.ReadKey();
        //}
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
