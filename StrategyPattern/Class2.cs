using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrategyPattern
{
    class King : BaseCharacter
    {
        public override void UseWeapon()
        {
            Console.WriteLine("King rushing");
            weapopnBehavior.UseWeapon();
        }
    }
}
