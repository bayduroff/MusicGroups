using System.Threading.Tasks;
using MusicGroups.BLL.Contracts;
using MusicGroups.DataAccess.Contracts;
using MusicGroups.DataAccess.Implementations;
using MusicGroups.Domain;
using MusicGroups.Domain.Models;

namespace MusicGroups.BLL.Implementation
{
    public class GroupCreateService : IGroupCreateService
    {
        private IGroupDataAccess GroupDataAccess { get; }

        public GroupCreateService(IGroupDataAccess reservationDataAccess)
        {
            GroupDataAccess = reservationDataAccess;
        }

        public Task<Group> CreateAsync(GroupUpdateModel group)
        {
            return GroupDataAccess.InsertAsync(group);
        }
    }
}