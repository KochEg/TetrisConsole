using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;

namespace TetrisConsole
{
    static class WInApi
    {
        //получение состояния указанной клавиши
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern short GetKeyState(char key);
    }
}
