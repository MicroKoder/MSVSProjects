using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrategyPattern
{
    class Sword:WeaponBehavior
    {
        public void UseWeapon()
        {
            Console.WriteLine("Sword doing 'squeeeeshshhhh'");
        }
    }
}
