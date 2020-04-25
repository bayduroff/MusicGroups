using System.Collections.Generic;
using System.Threading.Tasks;
using MusicGroups.Domain;
using MusicGroups.Domain.Contracts;

namespace MusicGroups.BLL.Contracts
{
    public interface IReservationGetService
    {
        Task<IEnumerable<Reservation>> GetAsync();
        Task<Reservation> GetAsync(IReservationIdentity reservation);
        Task ValidateAsync(IReservationContainer departmentContainer);
    }
}