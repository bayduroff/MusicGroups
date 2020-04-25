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
    public class GroupGetServiceTests
    {
        [Test]
        public async Task ValidateAsync_GroupExists_DoesNothing()
        {
            // Arrange
            var departmentContainer = new Mock<IGroupContainer>();

            var group = new Group();
            var groupDataAccess = new Mock<IGroupDataAccess>();
            groupDataAccess.Setup(x => x.GetByAsync(departmentContainer.Object)).ReturnsAsync(group);

            var groupGetService = new GroupGetService(groupDataAccess.Object);
            
            // Act
            var action = new Func<Task>(() => groupGetService.ValidateAsync(departmentContainer.Object));
            
            // Assert
            await action.Should().NotThrowAsync<Exception>();
        }
        
        [Test]
        public async Task ValidateAsync_GroupNotExists_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var id = fixture.Create<int>();
            
            var groupContainer = new Mock<IGroupContainer>();
            groupContainer.Setup(x => x.GroupId).Returns(id);

            var group = new Group();
            var groupDataAccess = new Mock<IGroupDataAccess>();
            groupDataAccess.Setup(x => x.GetByAsync(groupContainer.Object)).ReturnsAsync((Group)null);

            var groupGetService = new GroupGetService(groupDataAccess.Object);
            
            // Act
            var action = new Func<Task>(() => groupGetService.ValidateAsync(groupContainer.Object));
            
            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>($"Group not found by id {id}");
        }
    }
}