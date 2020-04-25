using System.Collections.Generic;
using System.Threading.Tasks;
using MusicGroups.Domain;
using MusicGroups.Domain.Contracts;
using MusicGroups.Domain.Models;
namespace MusicGroups.DataAccess.Contracts
{
    public interface IReservationDataAccess
    {
        Task<Reservation> InsertAsync(ReservationUpdateModel reservation);
        Task<IEnumerable<Reservation>> GetAsync();
        Task<Reservation> GetAsync(IReservationIdentity reservationId);
        Task<Reservation> UpdateAsync(ReservationUpdateModel reservation);
        Task<Reservation> GetByAsync(IReservationContainer reservation);

    }
}