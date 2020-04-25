using System;
using System.Threading.Tasks;
using AutoFixture;
using MusicGroups.BLL.Implementation;
using MusicGroups.DataAccess.Contracts;
using MusicGroups.Domain;
using MusicGroups.Domain.Contracts;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace MusicGroups.BLL.Tests
{
    public class ClubGetServiceTests
    {
        [Test]
        public async Task ValidateAsync_ClubExists_DoesNothing()
        {
            // Arrange
            var clubContainer = new Mock<IClubContainer>();

            var club = new Club();
            var clubDataAccess = new Mock<IClubDataAccess>();
            clubDataAccess.Setup(x => x.GetByAsync(clubContainer.Object)).ReturnsAsync(club);

            var clubGetService = new ClubGetService(clubDataAccess.Object);
            
            // Act
            var action = new Func<Task>(() => clubGetService.ValidateAsync(clubContainer.Object));
            
            // Assert
            await action.Should().NotThrowAsync<Exception>();
        }
        
        [Test]
        public async Task ValidateAsync_ClubNotExists_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var id = fixture.Create<int>();
            
            var clubContainer = new Mock<IClubContainer>();
            clubContainer.Setup(x => x.ClubId).Returns(id);

            var club = new Club();
            var clubDataAccess = new Mock<IClubDataAccess>();
            clubDataAccess.Setup(x => x.GetByAsync(clubContainer.Object)).ReturnsAsync((Club)null);

            var clubGetService = new ClubGetService(clubDataAccess.Object);
            
            // Act
            var action = new Func<Task>(() => clubGetService.ValidateAsync(clubContainer.Object));
            
            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>($"Club not found by id {id}");
        }
    }
}