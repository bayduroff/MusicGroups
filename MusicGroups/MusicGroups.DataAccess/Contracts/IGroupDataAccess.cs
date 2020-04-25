using System.Collections.Generic;
using System.Threading.Tasks;
using MusicGroups.Domain;
using MusicGroups.Domain.Contracts;
using MusicGroups.Domain.Models;
namespace MusicGroups.DataAccess.Contracts
{
    public interface IGroupDataAccess
    {
        Task<Group> InsertAsync(GroupUpdateModel group);
        Task<IEnumerable<Group>> GetAsync();
        Task<Group> GetAsync(IGroupIdentity groupId);
        Task<Group> UpdateAsync(GroupUpdateModel group);
        Task<Group> GetByAsync(IGroupContainer group);

    }
}