using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MouseEvent
{
    class Program
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern bool SetCursorPos(int x, int y);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        public const int MOUSE_LEFTDOWN = 0x02;
        public const int MOUSE_LEFTUP = 0x04;

        public static void LeftMouseClick(int xpos, int ypos)
        {
            SetCursorPos(xpos, ypos);
            mouse_event(MOUSE_LEFTDOWN, xpos, ypos, 0, 0);
            mouse_event(MOUSE_LEFTUP, xpos, ypos, 0, 0);
        }

        static void Main(string[] args)
        {
            while(true)
            {
                Console.ReadKey();
                LeftMouseClick(960, 540);
            }
        }
    }
}
