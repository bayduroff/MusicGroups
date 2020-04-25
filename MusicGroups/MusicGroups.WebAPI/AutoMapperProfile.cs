using AutoMapper;
using MusicGroups.Client.DTO.Read;
using MusicGroups.Client.Requests.Create;
using MusicGroups.Client.Requests.Update;
using MusicGroups.DataAccess.Entities;
using MusicGroups.Domain.Models;

namespace MusicGroups.WebAPI
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            this.CreateMap<Club, MusicGroups.Domain.Club>();
            this.CreateMap<Group, MusicGroups.Domain.Group>();
            this.CreateMap<Reservation, MusicGroups.Domain.Reservation>();
            this.CreateMap<MusicGroups.Domain.Club, ClubDTO>();
            this.CreateMap<MusicGroups.Domain.Group, GroupDTO>();
            this.CreateMap<MusicGroups.Domain.Reservation, ReservationDTO>();
            
            this.CreateMap<ClubCreateDTO, ClubUpdateModel>();
            this.CreateMap<ClubUpdateDTO, ClubUpdateModel>();
            this.CreateMap<ClubUpdateModel, Club>();
            
            this.CreateMap<GroupCreateDTO, GroupUpdateModel>();
            this.CreateMap<GroupUpdateDTO, GroupUpdateModel>();
            this.CreateMap<GroupUpdateModel, Group>();
            
            this.CreateMap<ReservationCreateDTO, ReservationUpdateModel>();
            this.CreateMap<ReservationUpdateDTO, ReservationUpdateModel>();
            this.CreateMap<ReservationUpdateModel, Reservation>();
        }
    }
}