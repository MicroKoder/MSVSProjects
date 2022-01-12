using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrategyPattern
{
    abstract class BaseCharacter
    {
        WeaponBehavior _weaponBehavior;

        public WeaponBehavior weapopnBehavior
        {
            set { _weaponBehavior = value; }
            get { return _weaponBehavior; }
        }

        public abstract void UseWeapon();
    }
}
