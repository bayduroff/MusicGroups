using System.ComponentModel.DataAnnotations;

namespace MusicGroups.Client.Requests.Create
{
    public class ReservationCreateDTO
    {
        public int? GroupId{ get; set; }
        
        [Required(ErrorMessage = "Location is required")]
        public string Location { get; set; }
        
        [Required(ErrorMessage = "Date is required")]
        public string Date { get; set; }

        public int? ClubId { get; set; }
    }
}