using MusicGroups.Domain.Contracts;

namespace MusicGroups.Domain.Models
{
    public class GroupUpdateModel : IGroupIdentity
    {
        public int Id { get; set; }

        //Название фильма
        public string Gname { get; set; }

        //Режиссер
        public string Genre { get; set; }

        //Дата премьеры
        public string DateC { get; set; }

        //Возрастное ограничение
        public int Price { get; set; }
    }
}