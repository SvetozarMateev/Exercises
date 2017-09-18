using Academy.Commands.Creating;
using Academy.Core.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace Academy.UnitTests.Commands.Creating.CreateCourseCommandTests
{
    [TestClass]
    public class Constructor_Should
    {
        private Mock<IAcademyFactory> factoryMock;
        private Mock<IEngine> engineMock;

        [TestInitialize]
        public void InitializeMocks()
        {
            this.factoryMock = new Mock<IAcademyFactory>();
            this.engineMock = new Mock<IEngine>();
        }
        [TestMethod]
        public void ReturnACommandWhichIsNotNull_WhenParametersAreCorrect()
        {
            //Arrange
            //Act
            var command = new CreateCourseCommand(this.factoryMock.Object, this.engineMock.Object);

            //Assert
            Assert.IsNotNull(command);
        }

        [TestMethod]
        public void ThrowAnArgumentNullException_WhenFactoryIsNull()
        {
            //Arrange
            IAcademyFactory factory = null;

            //Act&Assert
            Assert.ThrowsException<ArgumentNullException>(() => new CreateCourseCommand(factory, this.engineMock.Object));
        }

        [TestMethod]
        public void ThrowAnArgumentNullException_WhenEngineIsNull()
        {
            //Arrange
            IEngine engine = null;

            //Act&Assert
            Assert.ThrowsException<ArgumentNullException>(() => new CreateCourseCommand(this.factoryMock.Object, engine));
        }
    }
}
