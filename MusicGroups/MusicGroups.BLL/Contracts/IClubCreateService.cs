using System.Threading.Tasks;
using MusicGroups.Domain;
using MusicGroups.Domain.Models;

namespace MusicGroups.BLL.Contracts
{
    public interface IClubCreateService
    {
        Task<Club> CreateAsync(ClubUpdateModel club);
    }
}