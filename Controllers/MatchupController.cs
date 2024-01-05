using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using servartur.Entities;
using servartur.Models;
using servartur.Services;

namespace servartur.Controllers;
[ApiController]
[Route("api/[controller]")]
public class MatchupController : ControllerBase
{
    private readonly IMatchupService _matchupService;

    public MatchupController(IMatchupService matchupService)
    {
        _matchupService = matchupService;
    }

    [HttpPost]
    public ActionResult CreateRoom([FromBody] CreateRoomDto dto)
    {
        try
        {
            var roomId = _matchupService.CreateRoom(dto);
            return Created($"/api/rooms/{roomId}", null);
        }
        catch (DbUpdateException)
        {
            return StatusCode(500, "An error occured while saving changes to database");
        }
    }

    [HttpGet("{id}")]
    public ActionResult<RoomDto> GetRoomById([FromRoute] int id)
    {
        var room = _matchupService.GetById(id);

        return room == null ? NotFound() : Ok(room);
    }


    [HttpPost("player")]
    public ActionResult CreatePlayer([FromBody] CreatePlayerDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var playerId = _matchupService.CreatePlayer(dto);
            return Created($"/api/rooms/player/{playerId}", null);
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
        catch (DbUpdateException)
        {
            return StatusCode(500, "An error occured while saving changes to database");
        }
    }

    [HttpDelete("player/{id}")]
    public ActionResult RemovePlayer([FromRoute] int id)
    {
        try
        {
            _matchupService.RemovePlayer(id);
            return NoContent();
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
        catch (DbUpdateException)
        {
            return StatusCode(500, "An error occured while saving changes to database");
        }
    }

}
