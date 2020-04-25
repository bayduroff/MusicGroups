using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MusicGroups.BLL.Contracts;
using MusicGroups.DataAccess.Contracts;
using MusicGroups.Domain;
using MusicGroups.Domain.Contracts;

namespace MusicGroups.BLL.Implementation
{
    
    public class ClubGetService : IClubGetService
    {
        private IClubDataAccess ClubDataAccess { get; }
        
        public ClubGetService(IClubDataAccess clubDataAccess)
        {
            this.ClubDataAccess = clubDataAccess;
        }
        public Task<IEnumerable<Club>> GetAsync()
        {
            return this.ClubDataAccess.GetAsync();
        }

        public Task<Club> GetAsync(IClubIdentity club)
        {
            return this.ClubDataAccess.GetAsync(club);
        }

        public async Task ValidateAsync(IClubContainer clubContainer)
        {
            if (clubContainer == null)
            {
                throw new ArgumentNullException(nameof(clubContainer));
            }
            
            var club = await this.GetBy(clubContainer);

            if (clubContainer.ClubId.HasValue && club == null)
            {
                throw new InvalidOperationException($"Club not found by id {clubContainer.ClubId}");
            }
        }
        private Task<Club> GetBy(IClubContainer clubContainer)
        {
            return this.ClubDataAccess.GetByAsync(clubContainer);
        }
    }
}