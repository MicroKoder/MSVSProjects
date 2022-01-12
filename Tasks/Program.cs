using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            MyAsyncMethod();
            Console.WriteLine("continue Main");
            Console.ReadKey();
        }

        static async Task MyAsyncMethod()
        {
            Console.WriteLine("Starting async method");
            await MyAsync();
      //      System.Threading.Thread.Sleep(1000);

            Console.WriteLine("Ending async method");
        }

        static async Task<bool> MyAsync()
        {
            Console.WriteLine("MyAsync");
            for (int i = 0; i < 999999; i++)
            {
            }
            Console.WriteLine("end MyAsync");
            return true;
        }

    }
}
