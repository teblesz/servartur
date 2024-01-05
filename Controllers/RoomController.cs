using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using servartur.Entities;
using servartur.Models;

namespace servartur.Controllers;
[ApiController]
[Route("api/[controller]")]
public class RoomController : ControllerBase
{
    private readonly GameDbContext _dbContext;
    private readonly IMapper _mapper;

    public RoomController(GameDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    [HttpGet("{id}")]
    public ActionResult<RoomDto> GetById(int id)
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

    [HttpPost("player")]
    public ActionResult CreatePlayer([FromBody] CreatePlayerDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if (!_dbContext.Rooms.Any(r => r.RoomId == dto.RoomId))
        {
            ModelState.AddModelError("RoomId", $"Room with ID {dto.RoomId} does not exist.");
            return BadRequest(ModelState);
        }

        var player = _mapper.Map<Player>(dto);
        _dbContext.Players.Add(player);
        try { _dbContext.SaveChanges(); }
        catch (DbUpdateException) { return StatusCode(500, "An error occured while saving changes to database"); }
        return Created($"/api/rooms/player/{player.PlayerId}", null);
    }
}
