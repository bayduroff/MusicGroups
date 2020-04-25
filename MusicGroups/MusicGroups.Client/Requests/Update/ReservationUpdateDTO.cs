using MusicGroups.Client.Requests.Create;

namespace MusicGroups.Client.Requests.Update
{
    public class ReservationUpdateDTO : ReservationCreateDTO
    {
        public int Id { get; set; }
    }
}