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
    public class ReservationGetServiceTests
    {
        [Test]
        public async Task ValidateAsync_ReservationExists_DoesNothing()
        {
            // Arrange
            var reservationContainer = new Mock<IReservationContainer>();

            var reservation = new Reservation();
            var reservationDataAccess = new Mock<IReservationDataAccess>();
            reservationDataAccess.Setup(x => x.GetByAsync(reservationContainer.Object)).ReturnsAsync(reservation);

            var reservationGetService = new ReservationGetService(reservationDataAccess.Object);
            
            // Act
            var action = new Func<Task>(() => reservationGetService.ValidateAsync(reservationContainer.Object));
            
            // Assert
            await action.Should().NotThrowAsync<Exception>();
        }
        
        [Test]
        public async Task ValidateAsync_ReservationNotExists_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var id = fixture.Create<int>();
            
            var reservationContainer = new Mock<IReservationContainer>();
            reservationContainer.Setup(x => x.ReservationId).Returns(id);

            var reservation = new Reservation();
            var reservationDataAccess = new Mock<IReservationDataAccess>();
            reservationDataAccess.Setup(x => x.GetByAsync(reservationContainer.Object)).ReturnsAsync((Reservation)null);

            var reservationGetService = new ReservationGetService(reservationDataAccess.Object);
            
            // Act
            var action = new Func<Task>(() => reservationGetService.ValidateAsync(reservationContainer.Object));
            
            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>($"Reservation not found by id {id}");
        }
    }
}