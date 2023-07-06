using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TetrisConsole
{
    public static class Title
    {
        public static void SplashScreen()
        {
            string[] ss = new string[12];
            ss[0] = "##### ### ###### ####  # ####";
            ss[1] = "  #   #      #   #  #  # #   ";
            ss[2] = "  #   ###    #   ####  # ####";
            ss[3] = "  #   #      #   ##    #    #";
            ss[4] = "  #   #      #   # #   #    #";
            ss[5] = "  #   ###    #   #  #  # ####";
            ss[6] = "                             ";
            ss[7] = "     Pleas, press any key    ";
            ss[8] = "                             ";
            ss[9] = "Control:                     ";
            ss[10] = "A - left  D - rigth         ";
            ss[11] = "S - down  Q - turn          ";
            Console.ForegroundColor= ConsoleColor.Red;
            for (int i = 0; i < ss.Length; i++)
                for (int j = 0; j < ss[i].Length; j++)
                {
                    Console.SetCursorPosition(j + 12, i + 10);
                    Console.Write(ss[i][j]);
                    Thread.Sleep(5);
                }
            Console.ReadKey();
            Console.ResetColor();
            Console.SetCursorPosition(0, 0);
        }

        public static void GameOver()
        {
            string[] go = new string[4];
            go[0] = "            GAME OVER            ";
            go[1] = "                                 ";
            go[2] = "        Pleas, wait restart      ";
            go[3] = ".................................";
            Console.ForegroundColor = ConsoleColor.Red;
            for (int i = 0; i < go.Length; i++)
                for (int j = 0; j < go[i].Length; j++)
                {
                    Console.SetCursorPosition(j + 10, i + 10);
                    Console.Write(go[i][j]);
                    Thread.Sleep(20);
                }
            Console.ResetColor();
            Console.SetCursorPosition(0, 0);
        }

    }
}
