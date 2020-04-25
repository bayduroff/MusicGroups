using MusicGroups.Domain.Contracts;

namespace MusicGroups.Domain
{
    public class Reservation : IClubContainer, IGroupContainer
    {
        public int Id { get; set; }
        
        public Group Group{ get; set; }
        
        public string Location { get; set; }
        
        public string Date { get; set; }

        public Club Club { get; set; }
        
        public int? ClubId => Club.Id;

        public int? GroupId => Group.Id;
    }
}