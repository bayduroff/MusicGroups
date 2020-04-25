using System.Threading.Tasks;
using MusicGroups.Domain;
using MusicGroups.Domain.Models;

namespace MusicGroups.BLL.Contracts
{
    public interface IClubUpdateService
    {
        Task<Club> UpdateAsync(ClubUpdateModel club);
    }
}