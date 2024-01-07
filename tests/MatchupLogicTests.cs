using servartur.DomainLogic;

namespace servartur.Tests;

public class MatchupLogicTests
{
    [Theory]
    [InlineData(5, 2)]
    [InlineData(6, 2)]
    [InlineData(7, 3)]
    [InlineData(8, 3)]
    [InlineData(9, 4)]
    [InlineData(10, 4)]
    public void GetNumberOfEvilPlayers_ForPlayersCount_ReturnsAccurateEvilPlayersNumber
        (int playersCount, int evilPlayersCount)
    {
        // arrange

        //act
        var result = MatchupLogic.GetNumberOfEvilPlayers(playersCount);

        //assert
        Assert.Equal(evilPlayersCount, result);
    }
}