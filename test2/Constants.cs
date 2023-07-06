using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisConsole
{

    public class Constants
    {
        /*Размер игрового поля*/
        public const int Field_Width = 20;
        public const int Field_Heigth = 30;

        /*Размер окана в символах*/
        public const int Screen_Width = Field_Width * 2;
        public const int Screen_Heigth = Field_Heigth;

        /*Максимальные размеры фигуры*/
        public const int MaxSizeFigure_Width = 4;
        public const int MaxSizeFigure_Heigth = 4;

        public const char c_Figure = '\u2588';
        public const char c_Field = '\u2591';
        public const char c_FigureDown = '\u2593';

        /*Хранит символы вывода на экран*/
        public class Type_ScreenMap
        {
            public char[,] screenMap = new char[Screen_Heigth, Screen_Width];
        }

        /*Хранит матрицу фигуры*/
        public class Type_ShapeFigure
        {
            public char[,] shapeFigure = new char[MaxSizeFigure_Heigth, MaxSizeFigure_Width];
        }

        /*Хранит накопленные клетки фигур*/
        public class Type_SaveFieldMap
        {
            public char[,] saveFieldMap = new char[Field_Heigth, Field_Width];
        }


        public static string[] ShapeArr = new string[] { ".....**..**.....",
                                                         "....****........",
                                                         "....***..*......",
                                                         ".....***.*......",
                                                         ".....**.**......",
                                                         ".....***...*....",
                                                         ".....**...**...." };
    }
}
