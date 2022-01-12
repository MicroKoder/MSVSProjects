using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommandPattern
{
    class LightUpCommand : ICommand
    {
        Light light;
        public LightUpCommand(Light light)
        {
            this.light = light;
        }
        public void Execute()
        {
            //   throw new NotImplementedException();
            if (light!=null)
                light.On();
        }

        public void Undo()
        {
            light.Off();
        }
    }
}
