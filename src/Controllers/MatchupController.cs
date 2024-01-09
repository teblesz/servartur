using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using servartur.Entities;
using servartur.Exceptions;
using servartur.Models;
using servartur.Services;

namespace servartur.Controllers;
[ApiController]
[Route("api/[controller]")]
public class MatchupController : ControllerBase
{
    private readonly IMatchupService matchupService;

    public MatchupController(IMatchupService matchupService)
    {
        this.matchupService = matchupService;
    }

    [HttpPost]
    public ActionResult CreateRoom([FromBody] CreateRoomDto dto)
    {
        var roomId = matchupService.CreateRoom(dto);
        return Created($"/api/rooms/{roomId}", null);
    }

    [HttpGet("{id}")]
    public ActionResult<RoomDto> GetRoomById([FromRoute] int id)
    {
        var room = matchupService.GetById(id);
        return room == null ? NotFound() : Ok(room);
    }


    [HttpPost("player")]
    public ActionResult CreatePlayer([FromBody] CreatePlayerDto dto)
    {
        var playerId = matchupService.CreatePlayer(dto);
        return Created($"/api/rooms/player/{playerId}", null);
    }

    [HttpDelete("player/{id}")]
    public ActionResult RemovePlayer([FromRoute] int id)
    {
        matchupService.RemovePlayer(id);
        return NoContent();
    }


    // TODO add startRoom - assign roles, create first squad and assign leader
    // TODO remove this later in favour of startRoom()
    [HttpPut("makeTeams/{roomId}")]
    public ActionResult MakeTeams([FromRoute] int roomId)
    {    
        matchupService.MakeTeams(roomId);
        return NoContent();
    }
}
