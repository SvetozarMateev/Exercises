using Academy.Commands.Adding;
using Academy.Commands.Contracts;
using Academy.Commands.Creating;
using Academy.Commands.Listing;
using Academy.Core;
using Academy.Core.Contracts;
using Academy.Core.Factories;
using Academy.Core.Providers;
using Academy.Decorator;
using Academy.Framework.Core.Contracts;
using Ninject;
using Ninject.Modules;
using System.Configuration;

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
            this.Bind<IDatabase>().To<InMemoryDatabase>().InSingletonScope();

            this.Bind<IAcademyFactory>().To<AcademyFactory>().InSingletonScope();
            this.Bind<ICommandFactory>().To<CommandFactory>().InSingletonScope();

            this.Bind<ICommand>().To<AddStudentToCourseCommand>().Named("AddStudentToCourse");
            this.Bind<ICommand>().To<AddStudentToSeasonCommand>().Named("AddStudentToSeason");
            this.Bind<ICommand>().To<AddTrainerToSeasonCommand>().Named("AddTrainerToSeason");

            bool testEnvironment = bool.Parse(ConfigurationManager.AppSettings["TestEnvironment"]);
            if (testEnvironment)
            {
                this.Bind<ICommand>().To<CreateCourseCommand>().Named("InternalCreateCourse");
                this.Bind<ICommand>().To<CreateCourseResultCommand>().Named("InternalCreateCourseResult");
                this.Bind<ICommand>().To<CreateLectureCommand>().Named("InternalCreateLecture");
                this.Bind<ICommand>().To<CreateSeasonCommand>().Named("InternalCreateSeason");
                this.Bind<ICommand>().To<CreateStudentCommand>().Named("InternalCreateStudent");
                this.Bind<ICommand>().To<CreateTrainerCommand>().Named("InternalCreateTrainer");

                this.Bind<ICommand>().To<CreateCommandsDecorator>().Named("CreateCourse")
                    .WithConstructorArgument(this.Kernel.Get<ICommand>("InternalCreateCourse"));
                this.Bind<ICommand>().To<CreateCommandsDecorator>().Named("CreateCourseResult")
                    .WithConstructorArgument(this.Kernel.Get<ICommand>("InternalCreateCourseResult"));
                this.Bind<ICommand>().To<CreateCommandsDecorator>().Named("CreateLecture")
                    .WithConstructorArgument(this.Kernel.Get<ICommand>("InternalCreateLecture"));
                this.Bind<ICommand>().To<CreateCommandsDecorator>().Named("CreateSeason")
                    .WithConstructorArgument(this.Kernel.Get<ICommand>("InternalCreateSeason"));
                this.Bind<ICommand>().To<CreateCommandsDecorator>().Named("CreateStudent")
                    .WithConstructorArgument(this.Kernel.Get<ICommand>("InternalCreateStudent"));
                this.Bind<ICommand>().To<CreateCommandsDecorator>().Named("CreateTrainer")
                    .WithConstructorArgument(this.Kernel.Get<ICommand>("InternalCreateTrainer"));
            }
            else
            {
                this.Bind<ICommand>().To<CreateCourseCommand>().Named("CreateCourse");
                this.Bind<ICommand>().To<CreateCourseResultCommand>().Named("CreateCourseResult");
                this.Bind<ICommand>().To<CreateLectureCommand>().Named("CreateLecture");
                this.Bind<ICommand>().To<CreateSeasonCommand>().Named("CreateSeason");
                this.Bind<ICommand>().To<CreateStudentCommand>().Named("CreateStudent");
                this.Bind<ICommand>().To<CreateTrainerCommand>().Named("CreateTrainer");
            }

            this.Bind<ICommand>().To<ListCoursesInSeasonCommand>().Named("ListCoursesInSeason");
            this.Bind<ICommand>().To<ListUsersCommand>().Named("ListUsers");
            this.Bind<ICommand>().To<ListUsersInSeasonCommand>().Named("ListUsersInSeason");
        }
    }
}
