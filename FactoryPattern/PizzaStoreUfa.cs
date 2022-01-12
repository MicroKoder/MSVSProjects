using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FactoryPattern
{
    class PizzaStoreUfa : PizzaStore
    {
        public Pizza Order()
        {
            return new PizzaUfa();
        //    throw new NotImplementedException();
        }
    }
}
