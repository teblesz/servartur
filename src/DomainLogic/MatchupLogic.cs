namespace servartur.DomainLogic;

public static class MatchupLogic
{
    public static int GetNumberOfEvilPlayers(int playersCount)
    {
        return (playersCount + 2) / 3;
    }
}