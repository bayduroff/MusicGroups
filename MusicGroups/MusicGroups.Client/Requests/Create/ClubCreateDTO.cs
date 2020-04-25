using System.ComponentModel.DataAnnotations;

namespace MusicGroups.Client.Requests.Create
{
    public class ClubCreateDTO
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }
    }
}