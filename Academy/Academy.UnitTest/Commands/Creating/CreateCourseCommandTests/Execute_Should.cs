using Academy.Commands.Contracts;
using Academy.Commands.Creating;
using Academy.Core.Contracts;
using Academy.Models.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace Academy.UnitTests.Commands.Creating.CreateCourseCommandTests
{
    [TestClass]
    public class Execute_Should
    {
        private Mock<IAcademyFactory> factoryMock;
        private Mock<IEngine> engineMock;
        private Mock<ICourse> courseMock;
        private IList<ISeason> seasonsMock;
        private Mock<ISeason> seasonZeroMock;
        private IList<ICourse> coursesMock;
        private ICommand commandMock;

        [TestInitialize]
        public void InitializingMocks()
        {
            this.factoryMock = new Mock<IAcademyFactory>();
            this.engineMock = new Mock<IEngine>();
            this.courseMock = new Mock<ICourse>();
            this.seasonsMock = new List<ISeason>();
            this.seasonZeroMock = new Mock<ISeason>();
            this.coursesMock = new List<ICourse>();
            this.commandMock= new CreateCourseCommand(factoryMock.Object, engineMock.Object);
        }

        [TestMethod]
        public void ReturnCorrectString_WhenParametersAreCorrect()
        {
            //Arrange          
            var testParameters = new List<string>()
            {
                "0",
                It.IsAny<string>(),
                "Integer",
                "Valid DateTime"

            };
            this.seasonsMock.Add(this.seasonZeroMock.Object);
            this.factoryMock.Setup(x => x.CreateCourse(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(this.courseMock.Object);
            this.engineMock.SetupGet(x => x.Database.Seasons).Returns(this.seasonsMock);
            this.seasonZeroMock.SetupGet(x => x.Courses).Returns(this.coursesMock);

            var expectedResult = $"Course with ID {0} was created in Season {0}.";

            //Act
            var result = commandMock.Execute(testParameters);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void AddCourseToCurrentSeasong_WhenParametersAreCorrect()
        {
            //Arrange         
            var testParameters = new List<string>()
                    {
                        "0",
                        It.IsAny<string>(),
                        "Integer",
                        "Valid DateTime"

                    };

            this.seasonsMock.Add(this.seasonZeroMock.Object);
            this.factoryMock.Setup(x => x.CreateCourse(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(this.courseMock.Object);
            this.engineMock.SetupGet(x => x.Database.Seasons).Returns(this.seasonsMock);
            this.seasonZeroMock.SetupGet(x => x.Courses).Returns(this.coursesMock);

            var expectedResult = 1;

            //Act
            commandMock.Execute(testParameters);

            //Assert
            Assert.AreEqual(expectedResult, this.seasonZeroMock.Object.Courses.Count);
        }

        [TestMethod]       
        public void ThrowsArgumentOutOfRangeException_WhenParametersAreFewerThanExpected()
        {
            //Arrange
            var testParameters = new List<string>();

            //Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => commandMock.Execute(testParameters));
        }

        [TestMethod]
        public void ThrowsArgumentOutOfRangeException_WhenParametersAreMoteThanExpected()
        {
            //Arrange
            var testParameters = new List<string>() {
            It.IsAny<string>(),
            It.IsAny<string>(),
            It.IsAny<string>(),
            It.IsAny<string>(),
            It.IsAny<string>()           
            };

            //Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => commandMock.Execute(testParameters));
        }
    }
}
