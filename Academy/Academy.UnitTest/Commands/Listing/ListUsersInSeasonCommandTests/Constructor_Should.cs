using Academy.Commands.Listing;
using Academy.Core.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace Academy.UnitTest.Commands.Listing.ListUsersInSeasonCommandTests
{
    [TestClass]
    public class Constructor_Should
    {
        private Mock<IAcademyFactory> factoryMock;
        private Mock<IEngine> engineMock;

        [TestInitialize]
        public void InitializingMocks()
        {
            this.factoryMock = new Mock<IAcademyFactory>();
            this.engineMock = new Mock<IEngine>();
        }
        [TestMethod]
        public void ReturnAListUsersInSeasonCommand_WhenParametersAreCorrect()
        {
            //Arrange
            //Act & Assert
            Assert.IsNotNull(new ListUsersInSeasonCommand(this.factoryMock.Object, this.engineMock.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenFactoryIsNull()
        {
            //Arrange
            IAcademyFactory factory = null;
            //Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new ListUsersInSeasonCommand(factory, this.engineMock.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenEngineIsNull()
        {
            //Arrange
            IEngine engine = null;
            //Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new ListUsersInSeasonCommand(this.factoryMock.Object, engine));
        }
    }
}
