using Academy.Commands.Contracts;
using Academy.Core.Contracts;
using Bytes2you.Validation;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Academy.Commands.Listing
{
    public class ListUsersInSeasonCommand : ICommand
    {
        private readonly IAcademyFactory factory;
        private readonly IEngine engine;

        public ListUsersInSeasonCommand(IAcademyFactory factory, IEngine engine)
        {
            Guard.WhenArgument(factory, "factory").IsNull().Throw();
            Guard.WhenArgument(engine, "engine").IsNull().Throw();

            this.factory = factory;
            this.engine = engine;
        }

        public string Execute(IList<string> parameters)
        {
            var seasonId = parameters[0];
            var season = this.engine.Database.Seasons[int.Parse(seasonId)];

            return season.ListUsers();
        }
    }
}
