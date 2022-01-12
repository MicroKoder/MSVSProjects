using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DecoratorPattern
{
    abstract class Beverage
    {
        protected string description;

        public abstract float Cost();
        public abstract string GetDescription();
    }

    class HouseBlend : Beverage
    {
        public HouseBlend()
        {
            description = "Houseblend";
        }
       
        public override float Cost()
        {
            return 0.89f;
        }

        public override string GetDescription()
        {
            return description;
        }
    }

    class DarkRoast : Beverage
    {
        public DarkRoast()
        {
            description = "Darkroast";
        }
        public override float Cost()
        {
            return 0.99f;
        }

        public override string GetDescription()
        {
            return description;
        }

    }

    class Espresso : Beverage
    {
        public Espresso()
        {
            description = "Espresso";
        }

        public override float Cost()
        {
            return 1.99f;
        }

        public override string GetDescription()
        {
            return description;
        }

    }

    class Decaf : Beverage
    {
        public Decaf()
        {
            description = "Decaf";
        }
        public override float Cost()
        {
            return 1.05f;
        }

        public override string GetDescription()
        {
            return description;
        }


    }

    /// <summary>
    ///  Класс - декоратор
    /// </summary>
    abstract class CondimentDecorator : Beverage
    {
        public Beverage beverage;
     //   public abstract string GetDescription();
    }

    class Milk : CondimentDecorator
    {
        public Milk(Beverage beverage)
        {
        
            this.beverage = beverage;
        }
        public override float Cost()
        {
            return beverage.Cost() + 0.10f;
        }

        public override string GetDescription()
        {
           return beverage.GetDescription() + ", Milk";
        //    throw new NotImplementedException();
        }
    }

    class Mocha : CondimentDecorator
    {
        public Mocha(Beverage beverage)
        {
            this.beverage = beverage;
        }
        public override float Cost()
        {
            return beverage.Cost() + 0.20f;
        }

        public override string GetDescription()
        {
            return beverage.GetDescription() + ", Mocha";
            //    throw new NotImplementedException();
        }
    }

    class Soy : CondimentDecorator
    {
        public Soy(Beverage beverage)
        {
            this.beverage = beverage;
        }
        public override float Cost()
        {
            return beverage.Cost() + 0.15f;
        }

        public override string GetDescription()
        {
            return beverage.GetDescription() + ", Soy";
            //     throw new NotImplementedException();
        }
    }

    class Whip : CondimentDecorator
    {
        public Whip(Beverage beverage)
        {
            this.beverage = beverage;
        }

        public override float Cost()
        {
            return beverage.Cost() + 0.10f;
        }

        public override string GetDescription()
        {
            return beverage.GetDescription() + ", Soy";
            //    throw new NotImplementedException();
        }
    }
}
