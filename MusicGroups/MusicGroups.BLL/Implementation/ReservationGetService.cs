using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MusicGroups.BLL.Contracts;
using MusicGroups.DataAccess.Contracts;
using MusicGroups.Domain;
using MusicGroups.Domain.Contracts;

namespace MusicGroups.BLL.Implementation
{
    public class ReservationGetService : IReservationGetService
    {
        private IReservationDataAccess ReservationDataAccess { get; }
        
        public ReservationGetService(IReservationDataAccess clubDataAccess)
        {
            this.ReservationDataAccess = clubDataAccess;
        }
        public Task<IEnumerable<Reservation>> GetAsync()
        {
            return this.ReservationDataAccess.GetAsync();
        }

        public Task<Reservation> GetAsync(IReservationIdentity reservation)
        {
            return this.ReservationDataAccess.GetAsync(reservation);
        }

        public async Task ValidateAsync(IReservationContainer reservationContainer)
        {
            if (reservationContainer == null)
            {
                throw new ArgumentNullException(nameof(reservationContainer));
            }
            
            var reservation = await this.GetBy(reservationContainer);

            if (reservationContainer.ReservationId.HasValue && reservation == null)
            {
                throw new InvalidOperationException($"Reservation not found by id {reservationContainer.ReservationId}");
            }
        }
        private Task<Reservation> GetBy(IReservationContainer departmentContainer)
        {
            return this.ReservationDataAccess.GetByAsync(departmentContainer);
        }
    }
}