using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MusicGroups.BLL.Contracts;
using MusicGroups.Client.DTO.Read;
using MusicGroups.Client.Requests.Create;
using MusicGroups.Client.Requests.Update;
using MusicGroups.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
namespace MusicGroups.WebAPI.Controllers
{
    [ApiController]
    [Route("api/group")]
    public class GroupController : ControllerBase
    {
        private ILogger<GroupController> Logger { get; }
        private IGroupCreateService GroupCreateService { get; }
        private IGroupGetService GroupGetService { get; }
        private IGroupUpdateService GroupUpdateService { get; }
        private IMapper Mapper { get; }

        public GroupController(ILogger<GroupController> logger, IMapper mapper, IGroupCreateService groupCreateService, IGroupGetService groupGetService, IGroupUpdateService groupUpdateService)
        {
            this.Logger = logger;
            this.GroupCreateService = groupCreateService;
            this.GroupGetService = groupGetService;
            this.GroupUpdateService = groupUpdateService;
            this.Mapper = mapper;
        }

        [HttpPut]
        [Route("")]
        public async Task<GroupDTO> PutAsync(GroupCreateDTO group)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");

            var result = await this.GroupCreateService.CreateAsync(this.Mapper.Map<GroupUpdateModel>(group));

            return this.Mapper.Map<GroupDTO>(result);
        }

        [HttpPatch]
        [Route("")]
        public async Task<GroupDTO> PatchAsync(GroupUpdateDTO group)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");

            var result = await this.GroupUpdateService.UpdateAsync(this.Mapper.Map<GroupUpdateModel>(group));

            return this.Mapper.Map<GroupDTO>(result);
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<GroupDTO>> GetAsync()
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called");

            return this.Mapper.Map<IEnumerable<GroupDTO>>(await this.GroupGetService.GetAsync());
        }

        [HttpGet]
        [Route("{groupId}")]
        public async Task<GroupDTO> GetAsync(int groupId)
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called for {groupId}");

            return this.Mapper.Map<GroupDTO>(await this.GroupGetService.GetAsync(new GroupIdentityModel(groupId)));
        }
    }
}