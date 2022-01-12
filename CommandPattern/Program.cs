using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommandPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            //-- управляемые объекты --
            Light light = new Light();
            GarageDoor door = new GarageDoor();

            //--- пульт управления ----
            RemoteControl remote = new RemoteControl();

            //-- команды --
            GarageDoorUpCommand garageDoorUpCmd = new GarageDoorUpCommand(door);
            LightUpCommand lightUpCmd = new LightUpCommand(light);

            remote.SetCommand(garageDoorUpCmd);
            remote.PressButton(0);

            remote.PressUndo();

            remote.SetCommand(lightUpCmd);
            remote.PressButton(1);
            remote.PressUndo();


            Console.ReadKey();

        }
    }
}
