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
    public class ReservationDataAccess : IReservationDataAccess
    {
        private ClubContext Context { get; }
        private IMapper Mapper { get; }

        public ReservationDataAccess(ClubContext context, IMapper mapper)
        {
            this.Context = context;
            Mapper = mapper;
        }

        public async Task<Reservation> InsertAsync(ReservationUpdateModel reservation)
        {
            var result = await this.Context.AddAsync(this.Mapper.Map<DataAccess.Entities.Reservation>(reservation));
            await this.Context.SaveChangesAsync();
            return this.Mapper.Map<Reservation>(result.Entity);
        }

        public async Task<IEnumerable<Reservation>> GetAsync()
        {
            //TODO
            return this.Mapper.Map<IEnumerable<Reservation>>(await this.Context.Reservation.Include(x => x.Club).Include(x=>x.Group).ToListAsync());
        }

        public async Task<Reservation> GetAsync(IReservationIdentity reservationId)
        {

            var result = await this.Get(reservationId);
            return this.Mapper.Map<Reservation>(result);
        }
        
        private async Task<Entities.Reservation> Get(IReservationIdentity reservationId)
        {
            //TODO
            if (reservationId == null)
                throw new ArgumentNullException(nameof(reservationId));
            return await this.Context.Reservation.Include(x => x.Club).Include(x=>x.Group).FirstOrDefaultAsync(x => x.Id == reservationId.Id);
            
        }

        public async Task<Reservation> UpdateAsync(ReservationUpdateModel reservation)
        {
            var existing = await this.Get(reservation);

            var result = this.Mapper.Map(reservation, existing);

            this.Context.Update(result);

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<Reservation>(result);
        }

        public async Task<Reservation> GetByAsync(IReservationContainer reservation)
        {
            return reservation.ReservationId.HasValue 
                ? this.Mapper.Map<Reservation>(await this.Context.Reservation.FirstOrDefaultAsync(x => x.Id == reservation.ReservationId)) 
                : null;
        }
    }
}