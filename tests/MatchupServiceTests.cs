using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using servartur.Entities;
using servartur.Enums;
using servartur.Models;
using servartur.Services;
using Moq.EntityFrameworkCore;

namespace servartur.Tests;
public class MatchupServiceTests
{
    [Fact]
    public void CreateRoom_ValidDto_ReturnsRoomId()
    {
        // Arrange
        var loggerMock = new Mock<ILogger<MatchupService>>();

        var createRoomDto = new CreateRoomDto();
        var expectedRoomId = 1;
        var room = new Room { RoomId = expectedRoomId, Status = RoomStatus.Matchup };
        var mapperMock = new Mock<IMapper>();
        mapperMock.Setup(m => m.Map<Room>(It.IsAny<CreateRoomDto>())).Returns(room);

        // Setup the DbContext mock
        var dbContextMock = new Mock<GameDbContext>(new DbContextOptionsBuilder<GameDbContext>()
            .UseInMemoryDatabase(databaseName: "CreateRoom_ValidDto")
            .Options);

        IList<Room> rooms = new List<Room> { room };
        dbContextMock.SetupGet(x => x.Rooms).ReturnsDbSet(rooms);

        // Act
        var matchupService = new MatchupService(dbContextMock.Object, mapperMock.Object, loggerMock.Object);
        var result = matchupService.CreateRoom(createRoomDto);

        // Assert
        result.Should().Be(expectedRoomId);

        // Ensure the room was added to the DbContext
        dbContextMock.Verify(db => db.Rooms.Add(It.IsAny<Room>()), Times.Once);
        dbContextMock.Verify(db => db.SaveChanges(), Times.Once);
    }
}
