using Academy.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Decorator
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
            var started = $"-->Command is called at: {DateTime.Now}";
            var result = command.Execute(parameters);
            var ended = $"-->Command has finished at: {DateTime.Now}";
            return string.Concat(started,
                Environment.NewLine,
                result,
                Environment.NewLine,
                ended);
        }
    }
}
