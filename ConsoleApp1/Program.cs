using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                Console.WriteLine("Enter value: \r");
                short a =  short.Parse( Console.ReadLine());
                byte []bytes= BitConverter.GetBytes(a);

                Console.WriteLine("\r");
                Console.WriteLine(bytes[0].ToString("X2") + " " + bytes[1].ToString("X2"));
            }
        }
    }
}
