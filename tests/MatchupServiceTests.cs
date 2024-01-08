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
    private readonly DbContextOptions<GameDbContext> _dummyDbContextOptions = new DbContextOptionsBuilder<GameDbContext>()
                .UseInMemoryDatabase(databaseName: "CreateRoom_ValidDto")
                .Options;
    [Fact]
    public void CreateRoom_ValidDto_ReturnsRoomId()
    {
        // Arrange
        var dbContextMock = new Mock<GameDbContext>(_dummyDbContextOptions);
        var loggerMock = new Mock<ILogger<MatchupService>>();
        var mapperMock = new Mock<IMapper>();
        var matchupService = new MatchupService(dbContextMock.Object, mapperMock.Object, loggerMock.Object);

        var createRoomDto = new CreateRoomDto();
        var expectedRoomId = 1;
        var room = new Room { RoomId = expectedRoomId, Status = RoomStatus.Matchup };
        IList<Room> rooms = new List<Room> { room };

        mapperMock.Setup(m => m.Map<Room>(It.IsAny<CreateRoomDto>())).Returns(room);
        dbContextMock.SetupGet(x => x.Rooms).ReturnsDbSet(rooms);

        // Act
        var result = matchupService.CreateRoom(createRoomDto);

        // Assert
        result.Should().Be(expectedRoomId);

        // Ensure the room was added to the DbContext
        dbContextMock.Verify(db => db.Rooms.Add(It.IsAny<Room>()), Times.Once);
        dbContextMock.Verify(db => db.SaveChanges(), Times.Once);
    }
}
