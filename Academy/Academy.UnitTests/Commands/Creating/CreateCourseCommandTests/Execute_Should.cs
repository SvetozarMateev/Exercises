using Academy.Commands.Creating;
using Academy.Core.Contracts;
using Academy.Models.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace Academy.UnitTests.Commands.Creating.CreateCourseCommandTests
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void ReturnCorrectString_WhenParametersAreCorrect()
        {
            //Arrange
            var factoryMock = new Mock<IAcademyFactory>();
            var engineMock = new Mock<IEngine>();
            var courseMock = new Mock<ICourse>();
            var seasonsMock = new List<ISeason>();
            var commandMock = new CreateCourseCommand(factoryMock.Object, engineMock.Object);
            var coursesMock = new List<ICourse>();
            var seasonZeroMock = new Mock<ISeason>();
            var testParameters = new List<string>()
            {
                "0",
                It.IsAny<string>(),
                "Integer",
                "Valid DateTime"

            };

            seasonsMock.Add(seasonZeroMock.Object);
            factoryMock.Setup(x => x.CreateCourse(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(courseMock.Object);
            engineMock.SetupGet(x => x.Database.Seasons).Returns(seasonsMock);
            seasonZeroMock.SetupGet(x => x.Courses).Returns(coursesMock);

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
            var factoryMock = new Mock<IAcademyFactory>();
            var engineMock = new Mock<IEngine>();
            var courseMock = new Mock<ICourse>();
            var seasonsMock = new List<ISeason>();
            var commandMock = new CreateCourseCommand(factoryMock.Object, engineMock.Object);
            var coursesMock = new List<ICourse>();
            var seasonZeroMock = new Mock<ISeason>();
            var testParameters = new List<string>()
            {
                "0",
                It.IsAny<string>(),
                "Integer",
                "Valid DateTime"

            };

            seasonsMock.Add(seasonZeroMock.Object);
            factoryMock.Setup(x => x.CreateCourse(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(courseMock.Object);
            engineMock.SetupGet(x => x.Database.Seasons).Returns(seasonsMock);
            seasonZeroMock.SetupGet(x => x.Courses).Returns(coursesMock);


            var expectedResult = 1;

            //Act
            commandMock.Execute(testParameters);

            //Assert
            Assert.AreEqual(expectedResult, seasonZeroMock.Object.Courses.Count);
        }
    }
}
