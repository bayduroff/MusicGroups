using System.Collections.Generic;
using System.Threading.Tasks;
using MusicGroups.Domain;
using MusicGroups.Domain.Contracts;

namespace MusicGroups.BLL.Contracts
{
    public interface IClubGetService
    {
        Task<IEnumerable<Club>> GetAsync();
        Task<Club> GetAsync(IClubIdentity club);
        Task ValidateAsync(IClubContainer departmentContainer);
    }
}