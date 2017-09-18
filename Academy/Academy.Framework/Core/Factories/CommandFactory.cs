using Academy.Commands.Contracts;
using Ninject;
using System;

namespace Academy.Core.Factories
{
    public class CommandFactory : ICommandFactory
    {
        private readonly IKernel kernel;
        public CommandFactory(IKernel kernel)
        {
            this.kernel = kernel;
        }
        public ICommand CreateCommand(string commandName)
        {
            return kernel.Get<ICommand>(commandName);
        }
    }
}
