using MusicGroups.Domain.Contracts;

namespace MusicGroups.Domain
{
    public class Group 
    {
        public int Id { get; set; }
        
        public string Gname { get; set; }
        
        public string Genre { get; set; }
        
        public string DateC { get; set; }

        public int Price { get; set; }
    }
}