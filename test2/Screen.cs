using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisConsole
{
    public class Screen
    {
        /*Двумерный массив хранит символы которые будут нарисованы на экране*/
        public Constants.Type_ScreenMap scr = new Constants.Type_ScreenMap();

        public Screen()
        {
            Clear();

        }

        /*Заполняем точками массив*/
        public void Clear()
        {
            for (int i = 0; i < scr.screenMap.GetLength(0); i++)
            {
                for (int j = 0; j < scr.screenMap.GetLength(1); j++)
                    scr.screenMap[i, j] = '.';
            }
           
        }

        /*Выводим массив на экран*/
        public void Show()
        {
            for (int i = 0; i < scr.screenMap.GetLength(0); i++)
            {
                for (int j = 0; j < scr.screenMap.GetLength(1); j++)
                    Console.Write(scr.screenMap[i, j]);
                Console.WriteLine();
            }
            Console.SetCursorPosition(41, 3);
            Console.Write("level " + Game.level);
            Console.SetCursorPosition(0, 0);
            Console.SetCursorPosition(41, 5);
            Console.Write("Score " + Game.score);
            Console.SetCursorPosition(0, 0);
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
        }

    }
}
