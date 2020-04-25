using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicGroups.DataAccess.Entities
{
        public partial class Club
    {
        public Club()
        {
            this.Reservation = new HashSet<Reservation>();
        }
        
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual ICollection<Reservation> Reservation { get; set; }
        
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Address { get; set; }
        
    }
}