using MusicGroups.Domain.Contracts;

namespace MusicGroups.Domain.Models
{
    public class ReservationIdentityModel : IReservationIdentity
    {
        public int Id { get; }

        public ReservationIdentityModel(int id)
        {
            this.Id = id;
        }
    }
}