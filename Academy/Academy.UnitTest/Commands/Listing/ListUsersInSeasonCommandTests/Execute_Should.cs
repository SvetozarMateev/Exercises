using Academy.Commands.Listing;
using Academy.Core.Contracts;
using Academy.Framework.Core.Contracts;
using Academy.Models.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace Academy.UnitTest.Commands.Listing.ListUsersInSeasonCommandTests
{
    [TestClass]
   public class Execute_Should
    {
        [TestMethod]
        public void ShouldInvokeListUsersMethord_WhenParametersAreCorrect()
        {
            //Arrange
            var factoryMock = new Mock<IAcademyFactory>();
            var engineMock = new Mock<IEngine>();
            var databaseMock = new Mock<IDatabase>();
            var firstSeason = new Mock<ISeason>();
            var secondSeason = new Mock<ISeason>();

            var testParameters = new List<string>() {"1"};
            var seasons = new List<ISeason>();
            var command = new ListUsersInSeasonCommand(factoryMock.Object, engineMock.Object);

            
            seasons.Add(firstSeason.Object);
            seasons.Add(secondSeason.Object);
            engineMock.SetupGet(x => x.Database).Returns(databaseMock.Object);
            databaseMock.SetupGet(x => x.Seasons).Returns(seasons);

            //Act
            command.Execute(testParameters);

            //Assert
            secondSeason.Verify(x => x.ListUsers(), Times.Once);
        }
    }
}
