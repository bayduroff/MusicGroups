using MusicGroups.Domain.Contracts;

namespace MusicGroups.Domain.Models
{
    public class ReservationUpdateModel : IReservationIdentity, IGroupContainer, IClubContainer
    {
        public int Id { get; set; }
        
        //Время сеанса
        public string Location { get; set; }
        
        //Дата сеанса
        public string Date { get; set; }
        
        public int? GroupId { get; set; }
        public int? ClubId { get; set; }
    }
}