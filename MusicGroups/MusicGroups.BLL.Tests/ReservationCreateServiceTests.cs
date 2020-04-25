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
    public class ReservationCreateServiceTests
    {
        [Test]
        public async Task CreateAsync_DepartmentValidationSucceed_CreatesReservation()
        {
            // Arrange
            var reservation = new ReservationUpdateModel();
            var expected = new Reservation();
            
            var clubGetService = new Mock<IClubGetService>();
            clubGetService.Setup(x => x.ValidateAsync(reservation));

            var groupGetService = new Mock<IGroupGetService>();
            groupGetService.Setup(x => x.ValidateAsync(reservation));

            var reservationDataAccess = new Mock<IReservationDataAccess>();
            reservationDataAccess.Setup(x => x.InsertAsync(reservation)).ReturnsAsync(expected);
            
            var reservationGetService = new ReservationCreateService(reservationDataAccess.Object, clubGetService.Object, groupGetService.Object);
            
            // Act
            var result = await reservationGetService.CreateAsync(reservation);
            
            // Assert
            result.Should().Be(expected);
        }
        
        [Test]
        public async Task CreateAsync_ClubValidationFailed_ThrowsError()
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

            var reservationGetService = new ReservationCreateService(reservationDataAccess.Object, clubGetService.Object, groupGetService.Object);
            
            // Act
            var action = new Func<Task>(() => reservationGetService.CreateAsync(reservation));
            
            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>().WithMessage(expected);
            reservationDataAccess.Verify(x => x.InsertAsync(reservation), Times.Never);
        }
    }
}