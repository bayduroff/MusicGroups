using MusicGroups.Client.Requests.Create;

namespace MusicGroups.Client.Requests.Update
{
    public class ClubUpdateDTO : ClubCreateDTO
    {
        public int Id { get; set; }
    }
}