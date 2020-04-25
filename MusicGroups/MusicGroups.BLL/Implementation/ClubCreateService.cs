using System.Threading.Tasks;
using MusicGroups.BLL.Contracts;
using MusicGroups.DataAccess.Contracts;
using MusicGroups.Domain;
using MusicGroups.Domain.Models;

namespace MusicGroups.BLL.Implementation
{
    public class ClubCreateService : IClubCreateService
    {
        private IClubDataAccess ClubDataAccess { get; }

        public ClubCreateService(IClubDataAccess clubDataAccess)
        {
            ClubDataAccess = clubDataAccess;
        }

        public  Task<Club> CreateAsync(ClubUpdateModel club)
        {
            return ClubDataAccess.InsertAsync(club);
        }
    }
}