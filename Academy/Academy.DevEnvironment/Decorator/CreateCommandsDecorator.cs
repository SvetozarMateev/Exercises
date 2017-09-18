using Academy.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.DevEnvironment.Decorator
{
    public class CreateCommandsDecorator : ICommand
    {
        private readonly ICommand command;
        public CreateCommandsDecorator(ICommand command)
        {
            this.command = command;
        }
        public string Execute(IList<string> parameters)
        {
            return string.Concat($"-->Command is called at: {DateTime.Now}",
                Environment.NewLine,
                command.Execute(parameters),
                Environment.NewLine, 
                $"-->Command has finished at: {DateTime.Now}");
        }
    }
}
