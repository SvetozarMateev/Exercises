using Academy.Commands.Contracts;
using Academy.Core.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Linq;
using System.Text;

namespace Academy.Core.Tests
{
    [TestClass]
    public class Start_Should
    {
        public const string exitCommand = "Exit";
        private Mock<IReader> readerMock;
        private Mock<IWriter> writerMock;
        private Mock<IParser> parserMock;
        private Mock<IInMemoryDatabase> databaseMock;
        private StringBuilder builder;
        private IEngine engine;
        [TestInitialize]
        public void InitializingMocks()
        {
            this.readerMock = new Mock<IReader>();
            this.writerMock = new Mock<IWriter>();
            this.parserMock = new Mock<IParser>();
            this.databaseMock = new Mock<IInMemoryDatabase>();
            this.builder = new StringBuilder();
            this.engine = new Engine(readerMock.Object, writerMock.Object, parserMock.Object, databaseMock.Object);
        }
        [TestMethod]
        public void WriteACustomExceptionMessage_WhenArgumentOutOfRangeExceptionIsThrown()
        {
            //Arrange
            this.readerMock.SetupSequence(x => x.ReadLine()).Throws<ArgumentOutOfRangeException>().Returns(exitCommand);          
            this.builder.AppendLine("Invalid command parameters supplied or the entity with that ID for does not exist.");

            //Act
           this.engine.Start();

            //Assert
            this.writerMock.Verify(x => x.Write(builder.ToString()), Times.Once());
        }

        [TestMethod]
        public void WriteAnExceptionMessage_WhenExceptionIsThrown()
        {
            //Arrange
            var exception = new Exception();
            this.readerMock.SetupSequence(x => x.ReadLine()).Throws<Exception>().Returns(exitCommand);
            this.builder.AppendLine(exception.Message);

            //Act
            this.engine.Start();

            //Assert
            this.writerMock.Verify(x => x.Write(builder.ToString()), Times.Once());
        }
        [TestMethod]
        public void ProcessCommandAndWriteCorrectExecutionMessage_WhenParametersAreCorrect()
        {
            //Arrange                     
            var commandMock = new Mock<ICommand>();
            var randomCommand = "CreateSeason 2016 2017 SoftwareAcademy";
            var inputParameters = randomCommand.Split(' ').ToList();
            var executionMessage = "Season with ID 0 was created.";

            commandMock.Setup(x => x.Execute(inputParameters)).Returns(executionMessage);
            this.readerMock.SetupSequence(x => x.ReadLine()).Returns(randomCommand).Returns(exitCommand);
            this.parserMock.Setup(x => x.ParseCommand(randomCommand)).Returns(commandMock.Object);
            this.parserMock.Setup(x => x.ParseParameters(randomCommand)).Returns(inputParameters);
            this.builder.AppendLine(executionMessage);

            //Act
            this.engine.Start();

            //Assert
           this.writerMock.Verify(x => x.Write(builder.ToString()), Times.Once());
        }
    }
}