using System.Threading.Tasks;
using MusicGroups.Domain;
using MusicGroups.Domain.Models;

namespace MusicGroups.BLL.Contracts
{
    public interface IGroupCreateService
    {
        Task<Group> CreateAsync(GroupUpdateModel group);
    }
}