using Academy.Core;
using Academy.Core.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace Academy.UnitTests.Core.EngineTests
{
    [TestClass]

    public class Constructor_Should
    {
        private Mock<IReader> readerMock;
        private Mock<IWriter> writerMock;
        private Mock<IParser> parserMock;
        private Mock<IInMemoryDatabase> databaseMock;

        [TestInitialize]
        public void InitializeMocks()
        {
            this.readerMock = new Mock<IReader>();
            this.writerMock = new Mock<IWriter>();
            this.parserMock = new Mock<IParser>();
            this.databaseMock = new Mock<IInMemoryDatabase>();
        }
        [TestMethod]

        public void CreateAnObjectSuccessfuly_WhenParametersAreCorrect()
        {
            //Arrange
            //Act
            var engine = new Engine(this.readerMock.Object, this.writerMock.Object, this.parserMock.Object, this.databaseMock.Object);

            //Assert
            Assert.IsNotNull(engine);
        }

        [TestMethod]
        public void ThrowsArgumentNullException_WhenReaderIsNull()
        {
            //Arrange
            IReader reader = null;

            //Act & Assert
            Assert.ThrowsException<ArgumentNullException>(
                () => new Engine(reader, this.writerMock.Object, this.parserMock.Object, this.databaseMock.Object));
        }

        [TestMethod]
        public void ThrowsArgumentNullException_WhenWriterIsNull()
        {
            //Arrange           
            IWriter writer = null;

            //Act & Assert
            Assert.ThrowsException<ArgumentNullException>(
                () => new Engine(this.readerMock.Object, writer, this.parserMock.Object, this.databaseMock.Object));
        }

        [TestMethod]
        public void ThrowsArgumentNullException_WhenParserIsNull()
        {
            //Arrange
            IParser parser = null;

            //Act & Assert
            Assert.ThrowsException<ArgumentNullException>(
                () => new Engine(this.readerMock.Object, this.writerMock.Object, parser, this.databaseMock.Object));
        }

        [TestMethod]
        public void ThrowsArgumentNullException_WhenDatabaseIsNull()
        {
            //Arrange
            IInMemoryDatabase database = null;

            //Act & Assert
            Assert.ThrowsException<ArgumentNullException>(
                () => new Engine(this.readerMock.Object, this.writerMock.Object, this.parserMock.Object, database));
        }
    }
}
