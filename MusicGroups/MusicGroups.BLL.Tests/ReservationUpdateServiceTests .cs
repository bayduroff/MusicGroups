using System;
using System.Threading.Tasks;
using MusicGroups.BLL.Contracts;
using MusicGroups.BLL.Implementation;
using MusicGroups.DataAccess.Contracts;
using MusicGroups.Domain;
using MusicGroups.Domain.Models;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace MusicGroups.BLL.Tests
{
    public class ReservationUpdateServiceTests
    {
        [Test]
        public async Task UpdateAsync_DepartmentValidationSucceed_CreatesReservation()
        {
            // Arrange
            var reservation = new ReservationUpdateModel();
            var expected = new Reservation();
            
            var clubGetService = new Mock<IClubGetService>();
            clubGetService.Setup(x => x.ValidateAsync(reservation));

            var groupGetService = new Mock<IGroupGetService>();
            groupGetService.Setup(x => x.ValidateAsync(reservation));

            var reservationDataAccess = new Mock<IReservationDataAccess>();
            reservationDataAccess.Setup(x => x.UpdateAsync(reservation)).ReturnsAsync(expected);
            
            var reservationGetService = new ReservationUpdateService(reservationDataAccess.Object, clubGetService.Object, groupGetService.Object);
            
            // Act
            var result = await reservationGetService.UpdateAsync(reservation);
            
            // Assert
            result.Should().Be(expected);
        }
        
        [Test]
        public async Task UpdateAsync_ClubValidationFailed_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var reservation = new ReservationUpdateModel();
            var expected = fixture.Create<string>();
            
            var clubGetService = new Mock<IClubGetService>();
            clubGetService
                .Setup(x => x.ValidateAsync(reservation))
                .Throws(new InvalidOperationException(expected));

            var groupGetService = new Mock<IGroupGetService>();
            groupGetService.Setup(x => x.ValidateAsync(reservation)).Throws(new InvalidOperationException(expected));

            
            var reservationDataAccess = new Mock<IReservationDataAccess>();

            var reservationGetService = new ReservationUpdateService(reservationDataAccess.Object, clubGetService.Object, groupGetService.Object);
            
            // Act
            var action = new Func<Task>(() => reservationGetService.UpdateAsync(reservation));
            
            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>().WithMessage(expected);
            reservationDataAccess.Verify(x => x.UpdateAsync(reservation), Times.Never);
        }
    }
}