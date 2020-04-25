using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicGroups.DataAccess.Entities
{
    public class Group
    {
        public Group()
        {
            this.Reservations = new HashSet<Reservation>();
        }
        
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public string Gname { get; set; }
        
        public string Genre { get; set; }
        
        public string DateC { get; set; }
        
        public int Price { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}