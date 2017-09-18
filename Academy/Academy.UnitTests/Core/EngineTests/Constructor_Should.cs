using Academy.Core;
using Academy.Core.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.UnitTests.Core.EngineTests
{
    [TestClass]
    public class Constructor_Should
    {


        [TestMethod]
        public void CreateAnObjectSuccessfuly_WhenParametersAreCorrect()
        {
            //Arrange
            var readerMock = new Mock<IReader>();
            var writerMock = new Mock<IWriter>();
            var parserMock = new Mock<IParser>();
            var databaseMock = new Mock<IInMemoryDatabase>();

            //Act
            var engine = new Engine(readerMock.Object, writerMock.Object, parserMock.Object, databaseMock.Object);

            //Assert
            Assert.IsNotNull(engine);
        }

        [TestMethod]
        public void ThrowsArgumentNullException_WhenReaderIsNull()
        {
            //Arrange
            IReader readerMock = null;
            var writerMock = new Mock<IWriter>();
            var parserMock = new Mock<IParser>();
            var databaseMock = new Mock<IInMemoryDatabase>();

            //Act & Assert
            Assert.ThrowsException<ArgumentNullException>(
                () => new Engine(readerMock, writerMock.Object, parserMock.Object, databaseMock.Object));
        }

        [TestMethod]
        public void ThrowsArgumentNullException_WhenWriterIsNull()
        {
            //Arrange
            var readerMock = new Mock<IReader>();
            IWriter writerMock = null;
            var parserMock = new Mock<IParser>();
            var databaseMock = new Mock<IInMemoryDatabase>();

            //Act & Assert
            Assert.ThrowsException<ArgumentNullException>(
                () => new Engine(readerMock.Object, writerMock, parserMock.Object, databaseMock.Object));
        }

        [TestMethod]
        public void ThrowsArgumentNullException_WhenParserIsNull()
        {
            //Arrange
            var readerMock = new Mock<IReader>();
            var writerMock = new Mock<IWriter>();
            IParser parserMock = null;
            var databaseMock = new Mock<IInMemoryDatabase>();

            //Act & Assert
            Assert.ThrowsException<ArgumentNullException>(
                () => new Engine(readerMock.Object, writerMock.Object, parserMock, databaseMock.Object));
        }

        [TestMethod]
        public void ThrowsArgumentNullException_WhenDatabaseIsNull()
        {
            //Arrange
            var readerMock = new Mock<IReader>();
            var writerMock = new Mock<IWriter>();
            var parserMock = new Mock<IParser>();
            IInMemoryDatabase databaseMock = null;

            //Act & Assert
            Assert.ThrowsException<ArgumentNullException>(
                () => new Engine(readerMock.Object, writerMock.Object, parserMock.Object, databaseMock));
        }
    }
}
