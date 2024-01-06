﻿using AutoMapper;
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
    private readonly IMatchupService _matchupService;

    public MatchupController(IMatchupService matchupService)
    {
        _matchupService = matchupService;
    }

    [HttpPost]
    public ActionResult CreateRoom([FromBody] CreateRoomDto dto)
    {
            var roomId = _matchupService.CreateRoom(dto);
            return Created($"/api/rooms/{roomId}", null);
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
        catch (EntityNotFoundException ex)
        {
            return NotFound(ex.Message);
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
        catch (EntityNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    // TODO add room characters modifications

    // TODO add startRoom - assign roles, create first squad and assign leader

    // TODO remove this later in favour of startRoom()
    [HttpPut("makeTeams/{roomId}")]
    public ActionResult MakeTeams([FromRoute]int roomId)
    {
        // TODO extract this specific try catch block to some func, and then pass service call in lambda
        try
        {
            _matchupService.MakeTeams(roomId);
            return NoContent();
        }
        catch (EntityNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
}
