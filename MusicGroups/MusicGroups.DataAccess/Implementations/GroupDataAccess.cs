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
    public class GroupDataAccess : IGroupDataAccess
    {
        private ClubContext Context { get; }
        private IMapper Mapper { get; }

        public GroupDataAccess(ClubContext context, IMapper mapper)
        {
            this.Context = context;
            Mapper = mapper;
        }

        public async Task<Group> InsertAsync(GroupUpdateModel group)
        {
            var result = await this.Context.AddAsync(this.Mapper.Map<DataAccess.Entities.Group>(group));

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<Group>(result.Entity);
        }

        public async Task<IEnumerable<Group>> GetAsync()
        {
            return this.Mapper.Map<IEnumerable<Group>>(
                await this.Context.Group.ToListAsync());
        }

        public async Task<Group> GetAsync(IGroupIdentity group)
        {
            var result = await this.Get(group);

            return this.Mapper.Map<Group>(result);
        }

        public async Task<Group> UpdateAsync(GroupUpdateModel group)
        {
            var existing = await this.Get(group);

            var result = this.Mapper.Map(group, existing);

            this.Context.Update(result);

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<Group>(result);
        }

        public async Task<Group> GetByAsync(IGroupContainer group)
        {
            return group.GroupId.HasValue 
                ? this.Mapper.Map<Group>(await this.Context.Group.FirstOrDefaultAsync(x => x.Id == group.GroupId)) 
                : null;
        }

        private async Task<Entities.Group> Get(IGroupIdentity group)
        {
            if(group == null)
                throw new ArgumentNullException(nameof(group));
            return await this.Context.Group.FirstOrDefaultAsync(x => x.Id == group.Id);
        }
    }
}