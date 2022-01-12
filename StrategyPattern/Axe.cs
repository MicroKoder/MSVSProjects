using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrategyPattern
{
    class Axe : WeaponBehavior
    {
        public void UseWeapon()
        {
            Console.WriteLine("Axe making hurt");
        }
    }
}
