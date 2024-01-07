using AutoMapper;
using servartur.Entities;
using servartur.Models;
using servartur.Enums;

namespace servartur;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Room, RoomDto>();
        CreateMap<Player, PlayerDto>();

        CreateMap<CreateRoomDto, Room>();

        CreateMap<CreatePlayerDto, Player>();
    }
}
