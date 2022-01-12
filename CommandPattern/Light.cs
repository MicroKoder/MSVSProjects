using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommandPattern
{
    class Light
    {
        public void On()
        {
            Console.WriteLine("Включается свет в гостинной");
        }

        public void Off()
        {
            Console.WriteLine("Выключается свет в гостинной");
        }
    }
}
