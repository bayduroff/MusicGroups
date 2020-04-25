using MusicGroups.Client.Requests.Create;

namespace MusicGroups.Client.Requests.Update
{
    public class GroupUpdateDTO : GroupCreateDTO
    {
        public int Id { get; set; }
    }
}