using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TetrisConsole
{
    public struct COORD
    {
        public short X;
        public short Y;
    }
    public class Figure
    {
        int x, y;
        Constants.Type_ShapeFigure forma = new Constants.Type_ShapeFigure();
        int turn;
        COORD[] coord = new COORD[Constants.MaxSizeFigure_Width * Constants.MaxSizeFigure_Heigth];
        int coordCnt;
        Field field1 = new Field();

        public Figure() { }


        public void FieldSet(ref Field _field)
        {
            field1 = _field;
        }


        public void Pos(int _x, int _y)
        {
            x = _x;
            y = _y;
            CalcCoord();
        }

        public void Put(ref Constants.Type_ScreenMap scr)
        {
            //for (int i = 0; i < Constants.MaxSizeFigure_Width; ++i)
            //    for (int j = 0; j < Constants.MaxSizeFigure_Heigth; ++j)
            //        if (forma.shapeFigure[j, i] == '*')
            //        {
            //            scr.screenMap[y + j, (x + i) * 2] = scr.screenMap[y + j, (x + i) * 2 + 1] = Constants.c_Figure;
            //        }
            for (int i = 0; i < coordCnt; i++) /*объект выводится в буфер по координатам каждой клетки*/
            {
                scr.screenMap[coord[i].Y, coord[i].X * 2] = scr.screenMap[coord[i].Y, (coord[i].X * 2 + 1)] = Constants.c_Figure;
            }
        }

        public void Shape(ref string[] ShapeArr)
        {
            Random rand = new Random();
            char[] chars = new char[ShapeArr.Length];
            chars = ShapeArr[rand.Next(0, 6)].ToCharArray();

            for (int i = 0; i < forma.shapeFigure.GetLength(0); ++i)
                for (int j = 0; j < forma.shapeFigure.GetLength(1); ++j)
                {
                    forma.shapeFigure[i, j] = chars[i * forma.shapeFigure.GetLength(0) + j];
                }
        }


        public bool Move(int dx, int dy)
        {
            int oldX = x, oldY = y;
            Pos(x + dx, y + dy);
            int chk = Check(); /*после перемещения обекта проверяем его координаты*/
            if (chk >= 1) /*если мы за них вышли*/
            {
                Pos(oldX, oldY); /*то возвращаем объект обратно*/
                if (chk == 2) /*если уперлись в низ то оставляем обект внизу*/
                    return false;
            }
            return true;
        }



        private void CalcCoord()
        {
            //int xx = 0, yy = 0;
            //coordCnt = 0;
            //for (int i = 0; i < Constants.MaxSizeFigure_Width; i++) /*проходим по всей фигуре*/
            //    for (int j = 0; j < Constants.MaxSizeFigure_Heigth; j++)
            //        if (forma.shapeFigure[j, i] == '*') /*если натыкаемся на звездочку*/
            //        {
            //            xx = x + i;
            //            yy = y + j;
            //            coord[coordCnt].X = xx; /*и записываем их в массив*/
            //            coord[coordCnt].Y = yy;
            //            coordCnt++;


            int xx = 0, yy = 0;
            coordCnt = 0;
            for (int i = 0; i < Constants.MaxSizeFigure_Width; i++) /*проходим по всей фигуре*/
                for (int j = 0; j < Constants.MaxSizeFigure_Heigth; j++)
                    if (forma.shapeFigure[j, i] == '*') /*если натыкаемся на звездочку*/
                    {
                        if (turn == 0)
                        {
                            xx = x + i;
                            yy = y + j;
                        }/*в зависимости от угла берем порядок перебора клеток фигуры*/

                        if (turn == 1)
                        {
                            xx = x + (Constants.MaxSizeFigure_Heigth - j - 1);
                            yy = y + i;
                        }/*1 поворот по часовой стрелке на 90 градусов*/

                        if (turn == 2)
                        {
                            xx = x + (Constants.MaxSizeFigure_Width - i - 1);
                            yy = y + (Constants.MaxSizeFigure_Heigth - j - 1);
                        }/*2 на 180*/

                        if (turn == 3)
                        {
                            xx = x + j;
                            yy = y + (Constants.MaxSizeFigure_Heigth - i - 1) + (Constants.MaxSizeFigure_Width - Constants.MaxSizeFigure_Heigth);
                        }/*3 на 270*/

                        coord[coordCnt].X = (short)xx; /*и записываем их в массив*/
                        coord[coordCnt].Y = (short)yy;
                        coordCnt++;
                    }
        }


        public int Check()
        {
            CalcCoord(); /*вычесляем координаты каждой клеточки*/
            for (int i = 0; i < coordCnt; i++)
                if (coord[i].X < 0 || coord[i].X >= Constants.Field_Width)/*если вышли за границы возвращаем фигуру обратно*/
                    return 1;
            for (int i = 0; i < coordCnt; i++)
                if (coord[i].Y >= Constants.Field_Heigth || field1.field.saveFieldMap[coord[i].Y, coord[i].X] == Constants.c_FigureDown)
                    return 2;
            /*а если вышли за нижнюю границу, эту фигуру нужно оставить на месте и запустить новую в методе Move или столкнулись с другой фигурой*/
            return 0;
        }



        public void Put(ref Constants.Type_SaveFieldMap field)
        {
            //for (int i = 0; i < Constants.MaxSizeFigure_Width; ++i)
            //    for (int j = 0; j < Constants.MaxSizeFigure_Heigth; ++j)
            //        if (forma.shapeFigure[j, i] == '*')
            //        {
            //            field.saveFieldMap[y + j, x + i] = Constants.c_FigureDown;
            //        }

            for (int i = 0; i < coordCnt; i++) /*заполняем игровое поле по координатам фигуры*/
            {
                field.saveFieldMap[coord[i].Y, coord[i].X] = Constants.c_FigureDown;
            }
        }




        public void TurnSet(int _turn)
        {
            int oldTurn = turn;
            turn = (_turn > 3 ? 0 : (_turn < 0 ? 3 : _turn)); /*поворачиваем объект на один из 4х углов*/
            int chk = Check(); /*проверяем на столкновение*/
            if (chk == 0) return; /*если все ок то выходим*/
            if (chk == 1) /*если вышли за границы слева или справа*/
            {
                int xx = x; /*то пробуем 3 раза подвинуть объект от границ*/
                int k = (x > (Constants.Field_Width / 2) ? -1 : +1);
                for (int i = 1; i < 3; i++)
                {
                    x += k;
                    if (Check() == 0) return; /* и если получилось то выходим*/
                }
                x = xx; /*а если нет возвращаем обхект на место*/
            }
            turn = oldTurn; /*и поворачиваем как было*/
            CalcCoord(); /*после чего пересчитываем координаты*/
        }

        public int TurnGet()
        {
            return turn;
        }

    }

    
}
