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
    [Route("api/club")]
    public class ClubController
    {
        private ILogger<ClubController> Logger { get; }
        private IClubCreateService ClubCreateService { get; }
        private IClubGetService ClubGetService { get; }
        private IClubUpdateService ClubUpdateService { get; }
        private IMapper Mapper { get; }

        public ClubController(ILogger<ClubController> logger, IMapper mapper, IClubCreateService clubCreateService, IClubGetService clubGetService, IClubUpdateService clubUpdateService)
        {
            this.Logger = logger;
            this.ClubCreateService = clubCreateService;
            this.ClubGetService = clubGetService;
            this.ClubUpdateService = clubUpdateService;
            this.Mapper = mapper;
        }

        [HttpPut]
        [Route("")]
        public async Task<ClubDTO> PutAsync(ClubCreateDTO club)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");

            var result = await this.ClubCreateService.CreateAsync(this.Mapper.Map<ClubUpdateModel>(club));

            return this.Mapper.Map<ClubDTO>(result);
        }

        [HttpPatch]
        [Route("")]
        public async Task<ClubDTO> PatchAsync(ClubUpdateDTO club)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");

            var result = await this.ClubUpdateService.UpdateAsync(this.Mapper.Map<ClubUpdateModel>(club));

            return this.Mapper.Map<ClubDTO>(result);
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<ClubDTO>> GetAsync()
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called");

            return this.Mapper.Map<IEnumerable<ClubDTO>>(await this.ClubGetService.GetAsync());
        }

        [HttpGet]
        [Route("{clubId}")]
        public async Task<ClubDTO> GetAsync(int clubId)
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called for {clubId}");

            return this.Mapper.Map<ClubDTO>(await this.ClubGetService.GetAsync(new ClubIdentityModel(clubId)));
        }
    }
}