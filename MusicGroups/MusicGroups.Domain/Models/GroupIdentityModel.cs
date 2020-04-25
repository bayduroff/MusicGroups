using MusicGroups.Domain.Contracts;

namespace MusicGroups.Domain.Models
{
    public class GroupIdentityModel : IGroupIdentity
    {
        public int Id { get; }

        public GroupIdentityModel(int id)
        {
            this.Id = id;
        }
    }
}