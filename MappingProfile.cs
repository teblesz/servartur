using AutoMapper;
using servartur.Entities;
using servartur.Models;

namespace servartur;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Room, RoomDto>();
        CreateMap<Player, PlayerDto>();

        CreateMap<CreateRoomDto, Room>()
            .ForMember(r => r.Status, c => c.MapFrom(dto => "matchmaking"));

        CreateMap<CreatePlayerDto, Player>();
    }
}
