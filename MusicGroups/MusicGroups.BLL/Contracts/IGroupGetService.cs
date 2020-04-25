using System.Collections.Generic;
using System.Threading.Tasks;
using MusicGroups.Domain;
using MusicGroups.Domain.Contracts;

namespace MusicGroups.BLL.Contracts
{
    public interface IGroupGetService
    {
        Task<IEnumerable<Group>> GetAsync();
        Task<Group> GetAsync(IGroupIdentity group);
        Task ValidateAsync(IGroupContainer departmentContainer);
    }
}