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
        [TestMethod]
        public void WriteACustomExceptionMessage_WhenArgumentOutOfRangeExceptionIsThrown()
        {
            //Arrange
            var readerMock = new Mock<IReader>();
            var writerMock = new Mock<IWriter>();
            var parserMock = new Mock<IParser>();
            var databaseMock = new Mock<IInMemoryDatabase>();
            var engine = new Engine(readerMock.Object, writerMock.Object, parserMock.Object,databaseMock.Object);
            var builder = new StringBuilder();

            readerMock.SetupSequence(x => x.ReadLine()).Throws<ArgumentOutOfRangeException>().Returns("Exit");          
            builder.AppendLine("Invalid command parameters supplied or the entity with that ID for does not exist.");

            //Act
            engine.Start();

            //Assert
            writerMock.Verify(x => x.Write(builder.ToString()), Times.Once());
        }

        [TestMethod]
        public void WriteAnExceptionMessage_WhenExceptionIsThrown()
        {
            //Arrange
            var readerMock = new Mock<IReader>();
            var writerMock = new Mock<IWriter>();
            var parserMock = new Mock<IParser>();
            var databaseMock = new Mock<IInMemoryDatabase>();
            var engine = new Engine(readerMock.Object, writerMock.Object, parserMock.Object, databaseMock.Object);
            var builder = new StringBuilder();
            var exception = new Exception();
            readerMock.SetupSequence(x => x.ReadLine()).Throws<Exception>().Returns("Exit");
            builder.AppendLine(exception.Message);

            //Act
            engine.Start();

            //Assert
            writerMock.Verify(x => x.Write(builder.ToString()), Times.Once());
        }
        [TestMethod]
        public void ProcessCommandAndWriteCorrectExecutionMessage_WhenParametersAreCorrect()
        {
            //Arrange
            var readerMock = new Mock<IReader>();
            var writerMock = new Mock<IWriter>();
            var parserMock = new Mock<IParser>();
            var databaseMock = new Mock<IInMemoryDatabase>();
            var engine = new Engine(readerMock.Object, writerMock.Object, parserMock.Object, databaseMock.Object);
            var builder = new StringBuilder();
            var commandMock = new Mock<ICommand>();
            var randomCommand = "CreateSeason 2016 2017 SoftwareAcademy";
            var inputParameters = randomCommand.Split(' ').ToList();
            var executionMessage = "Season with ID 0 was created.";

            commandMock.Setup(x => x.Execute(inputParameters)).Returns(executionMessage);
            readerMock.SetupSequence(x => x.ReadLine()).Returns(randomCommand).Returns("Exit");
            parserMock.Setup(x => x.ParseCommand("CreateSeason 2016 2017 SoftwareAcademy")).Returns(commandMock.Object);
            parserMock.Setup(x => x.ParseParameters(randomCommand)).Returns(inputParameters);
            builder.AppendLine(executionMessage);
            //Act
            engine.Start();

            //Assert
            writerMock.Verify(x => x.Write(builder.ToString()), Times.Once());
        }
    }
}