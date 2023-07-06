using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisConsole
{
    public class Game
    {
        Screen screen = new Screen();
        public Field field = new Field();
        Figure figure = new Figure();
        int tick = 0;
        int trn = 0;
        public static int level;
        public static int score;
        int speed = 5;
        

        public Game()
        {
            figure.FieldSet(ref field);
            figure.Shape(ref Constants.ShapeArr);
            figure.Pos(Constants.Field_Width / 2 - Constants.MaxSizeFigure_Width / 2, 0);
        }
        public void Show()
        {
            screen.Clear();
            field.Put(ref screen.scr);
            figure.Put(ref screen.scr);
            screen.Show();
        }


        public void PlayerControl()
        {
            //ConsoleKeyInfo pressedKey = Console.ReadKey(true);

            //if (pressedKey.Key == ConsoleKey.S) figure.Move(0, 1);
            //if (pressedKey.Key == ConsoleKey.A) figure.Move(-1, 0);
            //if (pressedKey.Key == ConsoleKey.D) figure.Move(1, 0);

            
            if (WInApi.GetKeyState('Q') < 0) trn += 1;
            if (trn == 1)
            {
                figure.TurnSet(figure.TurnGet() + 1);
                trn++;
            }
            if (WInApi.GetKeyState('Q') >= 0) trn = 0;

            if (WInApi.GetKeyState('S') < 0) figure.Move(0, 1);
            if (WInApi.GetKeyState('A') < 0) figure.Move(-1, 0);
            if (WInApi.GetKeyState('D') < 0) figure.Move(1, 0);
        }



        public void Move()
        {
            if (score >= 1000) speed = 4; if (speed == 4) level = 1;
            if (score >= 2000) speed = 3; if (speed == 3) level = 2;
            if (score >= 3000) speed = 2; if (speed == 2) level = 3;
            if (score >= 4000) speed = 1; if (speed == 1) level = 4;
            if (score >= 5000) speed = 0; if (speed == 0) level = 5;

            tick++;
            if (tick >= speed)
            {
                if (!figure.Move(0, 1)) /*если обект в самом низу появляется новая фигура*/
                {
                    figure.Put(ref field.field); /*кладем игровую фигуру на игровое поле*/
                    figure.Shape(ref Constants.ShapeArr); /*случайная фигура*/
                    figure.Pos(Constants.Field_Width / 2 - Constants.MaxSizeFigure_Width / 2, 0); /*и помещаем её на верх*/
                    if (figure.Check() > 0) /*если создаем новую фигуру сверху и она сразу с чем то сталкивается,то игровое поле заполнено*/
                    {
                        Console.Clear();
                        Title.GameOver();
                        Console.Clear();
                        score = 0;
                        level= 0;
                        speed = 5;
                        field.Clear(); /*и игру нужно начинать заного, просто очищаем игровое поле*/
                    }
                }
                field.BurningFigure();
                tick = 0;
            }

            /*двигать объект вниз будем один раз в 5 этераций*/
            //tick++;
            //if (tick >= 5)
            //{
            //    if (!figure.Move(0, 1))
            //    {
            //        figure.Put(ref field.field);
            //        figure.Shape(ref Constants.ShapeArr); /*случайная фигура*/
            //        figure.Pos(Constants.Field_Width / 2 - Constants.MaxSizeFigure_Width / 2, 0);
            //    }
            //    tick = 0;
            //}
        }
    }
}
