using System.Threading.Tasks;
using MusicGroups.BLL.Contracts;
using MusicGroups.DataAccess.Contracts;
using MusicGroups.Domain;
using MusicGroups.Domain.Models;

namespace MusicGroups.BLL.Implementation
{
    public class ReservationUpdateService : IReservationUpdateService
    {
        private IReservationDataAccess ReservationDataAccess { get; }
        private IGroupGetService GroupGetService { get; }
        private IClubGetService ClubGetService { get; }

        public ReservationUpdateService(IReservationDataAccess reservationDataAccess, IClubGetService clubGetService,
            IGroupGetService groupGetService)
        {
            ReservationDataAccess = reservationDataAccess;
            GroupGetService = groupGetService;
            ClubGetService = clubGetService;
        }

        public async Task<Reservation> UpdateAsync(ReservationUpdateModel reservation)
        {
            await GroupGetService.ValidateAsync(reservation);
            await ClubGetService.ValidateAsync(reservation);

            return await ReservationDataAccess.UpdateAsync(reservation);

        }
    }
}