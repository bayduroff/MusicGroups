using System.Threading.Tasks;
using MusicGroups.BLL.Contracts;
using MusicGroups.DataAccess.Contracts;
using MusicGroups.Domain;
using MusicGroups.Domain.Models;

namespace MusicGroups.BLL.Implementation
{
    public class ClubUpdateService : IClubUpdateService
    {
        private IClubDataAccess ClubDataAccess { get; }

        public ClubUpdateService(IClubDataAccess clubDataAccess)
        {
            ClubDataAccess = clubDataAccess;
        }

        public Task<Club> UpdateAsync(ClubUpdateModel club)
        {
            return ClubDataAccess.UpdateAsync(club);
        }
    }
}