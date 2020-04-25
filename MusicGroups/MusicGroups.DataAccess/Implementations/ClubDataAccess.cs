using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MusicGroups.Domain;
using MusicGroups.Domain.Contracts;
using MusicGroups.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore;
using AutoMapper;
using MusicGroups.DataAccess.Context;
using MusicGroups.DataAccess.Contracts;

namespace MusicGroups.DataAccess.Implementations
{
    public class ClubDataAccess : IClubDataAccess
    {
        private ClubContext Context { get; }
        private IMapper Mapper { get; }

        public ClubDataAccess(ClubContext context, IMapper mapper)
        {
            this.Context = context;
            Mapper = mapper;
        }

        public async Task<Club> InsertAsync(ClubUpdateModel club)
        {
            var result = await this.Context.AddAsync(this.Mapper.Map<DataAccess.Entities.Club>(club));

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<Club>(result.Entity);
        }

        public async Task<IEnumerable<Club>> GetAsync()
        {
            return this.Mapper.Map<IEnumerable<Club>>(
                await this.Context.Club.ToListAsync());

        }

        public async Task<Club> GetAsync(IClubIdentity club)
        {
            var result = await this.Get(club);

            return this.Mapper.Map<Club>(result);
        }

        public async Task<Club> UpdateAsync(ClubUpdateModel club)
        {
            var existing = await this.Get(club);

            var result = this.Mapper.Map(club, existing);

            this.Context.Update(result);

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<Club>(result);
        }

        public async Task<Club> GetByAsync(IClubContainer club)
        {
            return club.ClubId.HasValue 
                ? this.Mapper.Map<Club>(await this.Context.Club.FirstOrDefaultAsync(x => x.Id == club.ClubId)) 
                : null;
        }

        private async Task<Entities.Club> Get(IClubIdentity club)
        {
            //TODO
            if(club == null)
                throw new ArgumentNullException(nameof(club));
            return await this.Context.Club.FirstOrDefaultAsync(x => x.Id == club.Id);
        }
    }
}