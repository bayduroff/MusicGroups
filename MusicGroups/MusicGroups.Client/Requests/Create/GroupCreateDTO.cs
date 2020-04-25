using System.ComponentModel.DataAnnotations;

namespace MusicGroups.Client.Requests.Create
{
    public class GroupCreateDTO
    {
        [Required(ErrorMessage = "Gname is required")]
        public string Gname { get; set; }
        
        [Required(ErrorMessage = "Genre is required")]
        public string Genre { get; set; }
        
        [Required(ErrorMessage = "Date of premiere is required")]
        public string DateC { get; set; }
        
        [Required(ErrorMessage = "Rating is required")]
        public int Price { get; set; }
        }
}