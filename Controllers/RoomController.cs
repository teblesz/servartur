using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using servartur.Entities;
using servartur.Models;

namespace servartur.Controllers;
[ApiController]
[Route("api/rooms")]
public class RoomController : ControllerBase
{
    private readonly GameDbContext _dbContext;
    private readonly IMapper _mapper;

    public RoomController(GameDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<IEnumerable<RoomDto>> GetAll()
    {
        var rooms = _dbContext
            .Rooms
            .Include(r => r.Players)
            .ToList();

        var roomsDtos = _mapper.Map<List<RoomDto>>(rooms);
        return Ok(roomsDtos);
    }

    [HttpGet("{id}")]
    public ActionResult<Room> GetById(int id)
    {
        var room = _dbContext
            .Rooms
            .Include(r => r.Players)
            .FirstOrDefault(r => r.RoomId == id);

        if (room == null)
        {
            return NotFound();
        }
        var roomDto = _mapper.Map<RoomDto>(room);
        return Ok(roomDto);
    }

    [HttpPost]
    public ActionResult CreateRoom([FromBody] CreateRoomDto dto)
    {
        var room = _mapper.Map<Room>(dto);
        _dbContext.Rooms.Add(room);
        _dbContext.SaveChanges();
        return Created($"/api/rooms/{room.RoomId}", null);
    }

    [HttpPost]
    public ActionResult CreatePlayer([FromBody] CreatePlayerDto dto)
    {
        var player = _mapper.Map<Player>(dto);
        _dbContext.Players.Add(player);
        _dbContext.SaveChanges();
        return Created($"/api/rooms/player/{player.PlayerId}", null);
    }
}
