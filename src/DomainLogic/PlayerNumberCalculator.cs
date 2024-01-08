namespace servartur.DomainLogic;

public static class PlayerNumberCalculator
{
    public static bool IsPlayerCountValid(int playersCount)
    => playersCount >= 5 && playersCount <= 10;
    public static bool IsQuestNumberValid(int questNumber)
    => questNumber >= 1 && questNumber <= 5;

    public static int GetEvilPlayersNumber(int playersCount)
    {
        if (!IsPlayerCountValid(playersCount))
            throw new ArgumentException("Invalid number of players given");

        return (playersCount - 1) / 2;
    }

    public static int GetSquadRequiredSize(int playersCount, int questNumber)
    {
        if (!IsPlayerCountValid(playersCount))
            throw new ArgumentException("Invalid number of players given");
        if (!IsQuestNumberValid(questNumber))
            throw new ArgumentException("Invalid quest number given");

        return squadRequiredSizes[playersCount - 5, questNumber - 1];
    }
    private static readonly int[,] squadRequiredSizes = new int[,]
    {
        {2, 3, 2, 3, 3}, // 5 players
        {2, 3, 4, 3, 4}, // 6 players
        {2, 3, 3, 4, 4}, // 7 players
        {3, 4, 4, 5, 5}, // 8 players
        {3, 4, 4, 5, 5}, // 9 players
        {3, 4, 4, 5, 5}, // 10 players
    };
}