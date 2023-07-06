using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TetrisConsole

{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(Constants.Screen_Width + 12, Constants.Screen_Heigth);
            Game game = new Game();
            Title.SplashScreen();
            Console.Clear();
            while (true)
            {
                game.PlayerControl();
                game.Move();
                game.Show();
                //Thread.Sleep(50);
            }

        }
    }
}
