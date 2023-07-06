using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TetrisConsole
{
    public class Field
    {
        /*Хранит игровое поле*/
        public Constants.Type_SaveFieldMap field = new Constants.Type_SaveFieldMap();
        bool fillLine;
        public Field()
        {
            Clear();
        }

        /*Заполняет поле значениями*/
        public void Clear()
        {
            for (int i = 0; i < field.saveFieldMap.GetLength(0); i++)
                for (int j = 0; j < field.saveFieldMap.GetLength(1); j++)
                    field.saveFieldMap[i, j] = Constants.c_Field;
        }

        /*Рисует игровое поле на экранном буфере*/
        public void Put(ref Constants.Type_ScreenMap scr)
        {
            for (int i = 0; i < Constants.Field_Width; i++)
                for (int j = 0; j < Constants.Field_Heigth; j++)
                    scr.screenMap[j, i * 2] = scr.screenMap[j, i * 2 + 1] = field.saveFieldMap[j, i];
        }

        /*Сжигание заполненой строки*/
        public void BurningFigure()
        {
            for (int j = Constants.Field_Heigth - 1; j >= 0; j--)
            {
               int x = 0;
               fillLine = true;
                for (int i = 0; i < Constants.Field_Width; i++)
                {
                    if (field.saveFieldMap[j, i] != Constants.c_FigureDown)
                        fillLine = false;
                    x = i;
                }

                
                if (fillLine)
                {
                    for (int y = j; y >= 1; y--)
                        for (int q = x; q >= 0; q--)
                        {
                            field.saveFieldMap[y, q] = field.saveFieldMap[y-1 , q];
                        }
                            Game.score += 100;
                    return;
                }
            }
        }
    }
}
