using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrategyPattern
{
    class Troll:BaseCharacter
    {
        public override void UseWeapon()
        {
            Console.WriteLine("Troll moving");
            weapopnBehavior.UseWeapon();
        }
    }
}
