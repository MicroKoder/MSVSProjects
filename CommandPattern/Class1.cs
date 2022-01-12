using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommandPattern
{
    class GarageDoor
    {
        public void Up()
        {
            Console.WriteLine("Гараж открыт");
        }
        public void LightUp()
        {
            Console.WriteLine("Свет в гараже включен");
        }

        public void Down()
        {
            Console.WriteLine("Опускаем дверь в гараже");
        }
    }
}
