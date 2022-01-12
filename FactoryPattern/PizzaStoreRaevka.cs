using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FactoryPattern
{
    class PizzaStoreRaevka : PizzaStore
    {
        public Pizza Order()
        {
            return new PizzaRaevka();
        }
    }
}
