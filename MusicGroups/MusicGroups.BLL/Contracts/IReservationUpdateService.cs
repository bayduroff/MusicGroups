using System.Threading.Tasks;
using MusicGroups.Domain;
using MusicGroups.Domain.Models;

namespace MusicGroups.BLL.Contracts
{
    public interface IReservationUpdateService
    {
        Task<Reservation> UpdateAsync(ReservationUpdateModel reservation);
    }
}