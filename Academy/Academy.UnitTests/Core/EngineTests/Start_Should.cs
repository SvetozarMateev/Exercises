using Academy.Core.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Text;

namespace Academy.Core.Tests
{
    [TestClass]
    public class Start_Should
    {
        [TestMethod]
        public void WriteACustomExceptionMessages_WhenArgumentOutOfRangeExceptionIsThrown()
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

    }
}