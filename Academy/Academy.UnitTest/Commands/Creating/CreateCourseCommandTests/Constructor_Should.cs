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
        [TestMethod]
        public void ReturnACommandWhichIsNotNull_WhenParametersAreCorrect()
        {
            //Arrange
            var factoryMock = new Mock<IAcademyFactory>();
            var engineMock = new Mock<IEngine>();

            //Act
            var command = new CreateCourseCommand(factoryMock.Object, engineMock.Object);

            //Assert
            Assert.IsNotNull(command);
        }

        [TestMethod]
        public void ThrowAnArgumentNullException_WhenFactoryIsNull()
        {
            //Arrange
            IAcademyFactory factoryMock = null;
            var engineMock = new Mock<IEngine>();

            //Act&Assert
            Assert.ThrowsException<ArgumentNullException>(()=>new CreateCourseCommand(factoryMock, engineMock.Object));
        }

        [TestMethod]
        public void ThrowAnArgumentNullException_WhenEngineIsNull()
        {
            //Arrange
            var factoryMock = new Mock<IAcademyFactory>(); ;
            IEngine engineMock =null;

            //Act&Assert
            Assert.ThrowsException<ArgumentNullException>(() => new CreateCourseCommand(factoryMock.Object, engineMock));
        }
    }
}
