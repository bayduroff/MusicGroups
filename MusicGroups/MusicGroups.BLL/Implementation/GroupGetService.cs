using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MusicGroups.BLL.Contracts;
using MusicGroups.DataAccess.Contracts;
using MusicGroups.Domain;
using MusicGroups.Domain.Contracts;

namespace MusicGroups.BLL.Implementation
{
    public class GroupGetService : IGroupGetService
    {
        private IGroupDataAccess GroupDataAccess { get; }
        
        public GroupGetService(IGroupDataAccess groupDataAccess)
        {
            this.GroupDataAccess = groupDataAccess;
        }
        public Task<IEnumerable<Group>> GetAsync()
        {
            return this.GroupDataAccess.GetAsync();
        }

        public Task<Group> GetAsync(IGroupIdentity group)
        {
            return this.GroupDataAccess.GetAsync(group);
        }

        public async Task ValidateAsync(IGroupContainer groupContainer)
        {
            if (groupContainer == null)
            {
                throw new ArgumentNullException(nameof(groupContainer));
            }
            
            var reservation = await this.GetBy(groupContainer);

            if (groupContainer.GroupId.HasValue && reservation == null)
            {
                throw new InvalidOperationException($"Reservation not found by id {groupContainer.GroupId}");
            }
        }
        private Task<Group> GetBy(IGroupContainer departmentContainer)
        {
            return this.GroupDataAccess.GetByAsync(departmentContainer);
        }
    }
}