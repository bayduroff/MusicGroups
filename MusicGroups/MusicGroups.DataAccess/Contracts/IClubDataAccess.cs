using System.Collections.Generic;
using System.Threading.Tasks;
using MusicGroups.Domain;
using MusicGroups.Domain.Contracts;
using MusicGroups.Domain.Models;
namespace MusicGroups.DataAccess.Contracts
{
    public interface IClubDataAccess
    {
        Task<Club> InsertAsync(ClubUpdateModel club);
        Task<IEnumerable<Club>> GetAsync();
        Task<Club> GetAsync(IClubIdentity clubId);
        Task<Club> UpdateAsync(ClubUpdateModel club);
        Task<Club> GetByAsync(IClubContainer departmentId);

    }
}