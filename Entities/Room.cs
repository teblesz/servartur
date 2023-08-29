namespace servartur.Models;
public class Room
{
    public int Id { get; set; }
    public string HostUserId { get; set; }
    public bool GameStarted { get; set; }
    //public string[] Characters { get; set; }
    //public string[] SpecialCharacters { get; set; }
    public bool MerlinKilled { get; set; }

    public string CurrentSquadId { get; set; }
    public virtual Squad CurrentSquad { get; set; }
}

