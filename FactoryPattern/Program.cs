using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FactoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            PizzaStore store = new PizzaStoreRaevka();
            Pizza raevkaPizze = store.Order();
            Console.WriteLine(raevkaPizze.description);

            PizzaStore store2 = new PizzaStoreUfa();
            Pizza ufaPizza = store2.Order();
            Console.WriteLine(ufaPizza.description);

            Console.ReadKey();
        }
    }
}
