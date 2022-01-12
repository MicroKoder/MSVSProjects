using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrategyPattern
{
    class Knight : BaseCharacter
    {

        bool IsFeature;
        public override void UseWeapon()
        {
            IsFeature = true;
            Console.WriteLine("Knight making move"+IsFeature.ToString());
            //throw new NotImplementedException();
            weapopnBehavior.UseWeapon();
        }
    }
}
