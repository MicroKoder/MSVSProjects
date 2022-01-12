using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrategyPattern
{
    class Queen : BaseCharacter
    {
        public override void UseWeapon()
        {
            Console.WriteLine("Queen making turn");
            weapopnBehavior.UseWeapon();
           // throw new NotImplementedException();
        }
    }
}
