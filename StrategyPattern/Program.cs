using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrategyPattern
{
    class Program
    {
        static bool isf;

        static void Main(string[] args)
        {
            King king = new King();
            king.weapopnBehavior = new Knife();

            Queen queen = new Queen();
            queen.weapopnBehavior = new Bow();

            Knight knight = new Knight();
            knight.weapopnBehavior = new Sword();

            Troll troll = new Troll();
            troll.weapopnBehavior = new Axe();


            king.UseWeapon();
            queen.UseWeapon();
            knight.UseWeapon();
            troll.UseWeapon();

            Console.ReadKey();
           
            isf = true;
            Console.Write(isf);
        }
    }
}
