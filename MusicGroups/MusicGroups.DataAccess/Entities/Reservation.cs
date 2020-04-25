using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicGroups.DataAccess.Entities
{
    public class Reservation
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public string Location { get; set; }
        
        public string Date { get; set; }
        
        public int? ClubId { get; set; }

        public int? GroupId { get; set; }

        public virtual Group Group { get; set; }

        public virtual Club Club { get; set; }
    }
}