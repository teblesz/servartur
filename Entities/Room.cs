namespace servartur.Entities;
public class Room
{
    public Room()
    {
        Status = "unknown";
        LastRoundWithSquadOnQuest = -1;
    }

    public int RoomId { get; set; }
    //public string HostUserFId { get; set; }
    public string Status { get; set; }
    public int LastRoundWithSquadOnQuest { get; set; }

    public int? CurrentSquadId { get; set; }
    public virtual Squad? CurrentSquad { get; set; }
    public virtual Assassination? Assassination { get; set; }

    public virtual List<Player> Players { get; set; } = new List<Player>();
    public virtual List<Squad> Squads { get; set; } = new List<Squad>();

}

