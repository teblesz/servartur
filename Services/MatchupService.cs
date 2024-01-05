﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using servartur.Entities;
using servartur.Models;

namespace servartur.Services;

public interface IMatchupService
{
    int CreatePlayer(CreatePlayerDto dto);
    RoomDto? GetById(int id);
    int CreateRoom([FromBody] CreateRoomDto dto);
    void RemovePlayer(int id);
    void MakeTeams(int roomId);
}

public class MatchupService : IMatchupService
{
    private readonly GameDbContext _dbContext;
    private readonly IMapper _mapper;

    public MatchupService(GameDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public int CreateRoom([FromBody] CreateRoomDto dto)
    {
        var room = _mapper.Map<Room>(dto);
        _dbContext.Rooms.Add(room);
        _dbContext.SaveChanges();
        return room.RoomId;
    }

    public RoomDto? GetById(int id)
    {
        var room = _dbContext
            .Rooms
            .Include(r => r.Players)
            .FirstOrDefault(r => r.RoomId == id);

        if (room == null) return null;
        var result = _mapper.Map<RoomDto>(room);
        return result;
    }
    public int CreatePlayer(CreatePlayerDto dto)
    {
        if (!_dbContext.Rooms.Any(r => r.RoomId == dto.RoomId))
            throw new ArgumentException($"Room with ID {dto.RoomId} does not exist.");

        var player = _mapper.Map<Player>(dto);
        _dbContext.Players.Add(player);
        _dbContext.SaveChanges();

        return player.PlayerId;
    }
    public void RemovePlayer(int id)
    {
        var player = _dbContext
            .Players
            .FirstOrDefault(p => p.PlayerId == id);

        if (player == null)
            throw new ArgumentException($"Player with ID {id} does not exist.");

        _dbContext.Players.Remove(player);
        _dbContext.SaveChanges();
    }

    // TODO remove this later in favour of startRoom()
    public void MakeTeams(int roomId)
    {
        var room = _dbContext
            .Rooms
            .Include(r => r.Players)
            .FirstOrDefault(r => r.RoomId == roomId);

        if (room == null)
            throw new ArgumentException($"Room with ID {roomId} does not exist.");

        var numberOfPlayers = room.Players.Count();
        int numberOfEvils = (numberOfPlayers + 2) / 3;

        List<string> teamAssignmentList = Enumerable.Range(0, numberOfPlayers)
            .Select(index => index < numberOfEvils ? "evil" : "good")
            .ToList();
        teamAssignmentList.Shuffle();

        
        foreach (var player in room.Players)
        {
            player.Team = teamAssignmentList.First();
            teamAssignmentList.RemoveAt(0);
        }
        _dbContext.SaveChanges();
    }
}
public static class ListExtensionShuffle
{
    /// <summary>
    /// Fisher-Yates shuffle for lists
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="list"></param>
    public static void Shuffle<T>(this List<T> list)
    {
        Random rng = new Random();
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}