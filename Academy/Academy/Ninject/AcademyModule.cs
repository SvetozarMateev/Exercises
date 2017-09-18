using Academy.Commands.Adding;
using Academy.Commands.Contracts;
using Academy.Commands.Creating;
using Academy.Commands.Listing;
using Academy.Core;
using Academy.Core.Contracts;
using Academy.Core.Factories;
using Academy.Core.Providers;
using Ninject.Modules;

namespace Academy.Ninject
{
    public class AcademyModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IEngine>().To<Engine>().InSingletonScope();

            this.Bind<IReader>().To<ConsoleReader>();
            this.Bind<IWriter>().To<ConsoleWriter>();
            this.Bind<IParser>().To<CommandParser>();
            this.Bind<IInMemoryDatabase>().To<InMemoryDatabase>().InSingletonScope();

            this.Bind<IAcademyFactory>().To<AcademyFactory>().InSingletonScope();
            this.Bind<ICommandFactory>().To<CommandFactory>().InSingletonScope();

            this.Bind<ICommand>().To<AddStudentToCourseCommand>().Named("AddStudentToCourse");
            this.Bind<ICommand>().To<AddStudentToSeasonCommand>().Named("AddStudentToSeason");
            this.Bind<ICommand>().To<AddTrainerToSeasonCommand>().Named("AddTrainerToSeason");

            this.Bind<ICommand>().To<CreateCourseCommand>().Named("CreateCourse");
            this.Bind<ICommand>().To<CreateCourseResultCommand>().Named("CreateCourseResult");
            this.Bind<ICommand>().To<CreateLectureCommand>().Named("CreateLecture");
            this.Bind<ICommand>().To<CreateSeasonCommand>().Named("CreateSeason");
            this.Bind<ICommand>().To<CreateStudentCommand>().Named("CreateStudent");
            this.Bind<ICommand>().To<CreateTrainerCommand>().Named("CreateTrainer");

            this.Bind<ICommand>().To<ListCoursesInSeasonCommand>().Named("ListCoursesInSeason");
            this.Bind<ICommand>().To<ListUsersCommand>().Named("ListUsers");
            this.Bind<ICommand>().To<ListUsersInSeasonCommand>().Named("ListUsersInSeason");
        }
    }
}
