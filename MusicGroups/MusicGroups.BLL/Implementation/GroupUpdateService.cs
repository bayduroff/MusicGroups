using System.Threading.Tasks;
using MusicGroups.BLL.Contracts;
using MusicGroups.DataAccess.Contracts;
using MusicGroups.Domain;
using MusicGroups.Domain.Models;

namespace MusicGroups.BLL.Implementation
{
    public class GroupUpdateService : IGroupUpdateService
    {
        private IGroupDataAccess GroupDataAccess { get; }

        public GroupUpdateService(IGroupDataAccess reservationDataAccess)
        {
            GroupDataAccess = reservationDataAccess;
        }

        public Task<Group> UpdateAsync(GroupUpdateModel group)
        {
            return GroupDataAccess.UpdateAsync(group);
        }
    }
}