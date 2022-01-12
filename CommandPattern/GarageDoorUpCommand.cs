using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommandPattern
{
    class GarageDoorUpCommand : ICommand
    {
        GarageDoor door;

        public GarageDoorUpCommand(GarageDoor door)
        {
            this.door = door;
        }
        public void Execute()
        {
            door.Up();
            door.LightUp();
         //   throw new NotImplementedException();
        }

        public void Undo()
        {
            door.Down();
        }
    }
}
