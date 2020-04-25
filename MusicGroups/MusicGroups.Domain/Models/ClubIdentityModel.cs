using MusicGroups.Domain.Contracts;

namespace MusicGroups.Domain.Models
{
    public class ClubIdentityModel : IClubIdentity
    {
        public int Id { get; }

        public ClubIdentityModel(int id)
        {
            this.Id = id;
        }
    }
}