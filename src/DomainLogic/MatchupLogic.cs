namespace servartur.DomainLogic;

public static class MatchupLogic
{
    public static int GetNumberOfEvilPlayers(int playersCount)
    {
        return (playersCount - 1) / 2;
    }
}