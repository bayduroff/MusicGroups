namespace MusicGroups.Client.DTO.Read
{
    public class ReservationDTO
    {
        public int Id { get; set; }
        
        public string Location { get; set; }
        
        public string Date { get; set; }

        public ClubDTO Club { get; set; }
        
        public GroupDTO Group{ get; set; }
    }
}