using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRecursion
{
    class Program
    {
        
        static void Main(string[] args)
        {
            do
            {
               int number = int.Parse( Console.ReadLine());
                Console.WriteLine("\n" + GetSum(number).ToString() + "\n");
                

            } while (true);
        }

        static int GetSum(int number)
        {
            int n = number % 10;

            if (number > 10)
                return n + GetSum(number / 10);
            else
                return n;
        }
    }
}
