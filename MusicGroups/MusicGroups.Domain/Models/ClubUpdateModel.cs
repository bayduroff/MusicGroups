using MusicGroups.Domain.Contracts;

namespace MusicGroups.Domain.Models
{
    public class ClubUpdateModel : IClubIdentity
    {
        public int Id { get; set; }
        
        //Название кинотеатра
        public string Name { get; set; }

        //Адрес
        public string Address { get; set; }
    }
}