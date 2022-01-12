using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrategyPattern
{
    class Bow : WeaponBehavior
    {
        public void UseWeapon()
        {
            Console.WriteLine("Bow making holes between eyes");
        }
    }
}
