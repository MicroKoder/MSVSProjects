using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommandPattern
{
    class RemoteControl
    {
        List<ICommand> commands = new List<ICommand>();

        ICommand lastCommand;

        public void SetCommand(ICommand command)
        {
            commands.Add(command);
        }

        public void PressButton(int numbutton)
        {
            if (numbutton < commands.Count)
            {
                commands[numbutton].Execute();
                lastCommand = commands[numbutton];
            }
        }

        public void PressUndo()
        {
            if (lastCommand != null)
                lastCommand.Undo();
        }
    }
}
