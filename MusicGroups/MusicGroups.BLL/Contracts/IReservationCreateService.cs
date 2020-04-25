using System.Threading.Tasks;
using MusicGroups.Domain;
using MusicGroups.Domain.Models;

namespace MusicGroups.BLL.Contracts
{
    public interface IReservationCreateService
    {
        Task<Reservation> CreateAsync(ReservationUpdateModel reservation);
    }
}