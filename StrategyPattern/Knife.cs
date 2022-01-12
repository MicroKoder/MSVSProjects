using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrategyPattern
{
    class Knife : WeaponBehavior
    {
        public void UseWeapon()
        {
            Console.WriteLine("Knife hits");
        }
    }
}
