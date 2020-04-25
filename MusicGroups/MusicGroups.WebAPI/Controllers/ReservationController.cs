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
    [Route("api/reservation")]
    public class ReservationController
    {
        private ILogger<ReservationController> Logger { get; }
        private IReservationCreateService ReservationCreateService { get; }
        private IReservationGetService ReservationGetService { get; }
        private IReservationUpdateService ReservationUpdateService { get; }
        private IMapper Mapper { get; }

        public ReservationController(ILogger<ReservationController> logger, IMapper mapper, IReservationCreateService reservationCreateService, IReservationGetService reservationGetService, IReservationUpdateService reservationUpdateService)
        {
            this.Logger = logger;
            this.ReservationCreateService = reservationCreateService;
            this.ReservationGetService = reservationGetService;
            this.ReservationUpdateService = reservationUpdateService;
            this.Mapper = mapper;
        }

        [HttpPut]
        [Route("")]
        public async Task<ReservationDTO> PutAsync(ReservationCreateDTO reservation)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");

            var result = await this.ReservationCreateService.CreateAsync(this.Mapper.Map<ReservationUpdateModel>(reservation));

            return this.Mapper.Map<ReservationDTO>(result);
        }

        [HttpPatch]
        [Route("")]
        public async Task<ReservationDTO> PatchAsync(ReservationUpdateDTO reservation)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");

            var result = await this.ReservationUpdateService.UpdateAsync(this.Mapper.Map<ReservationUpdateModel>(reservation));

            return this.Mapper.Map<ReservationDTO>(result);
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<ReservationDTO>> GetAsync()
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called");

            return this.Mapper.Map<IEnumerable<ReservationDTO>>(await this.ReservationGetService.GetAsync());
        }

        [HttpGet]
        [Route("{reservationId}")]
        public async Task<ReservationDTO> GetAsync(int reservationId)
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called for {reservationId}");

            return this.Mapper.Map<ReservationDTO>(await this.ReservationGetService.GetAsync(new ReservationIdentityModel(reservationId)));
        }
    }
}