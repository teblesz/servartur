namespace servartur.Entities;
public class Squad
{
    public int SquadId { get; set; }
    public int QuestNumber { get; set; }
    public int RoundNumber { get; set; }
    public int RequiredPlayersNumber { get; set; }
    public string Status { get; set; }

    public int LeaderId { get; set; }
    public virtual Player Leader { get; set; }

    public int RoomId { get; set; } // Required foreign key property

    public virtual List<Membership> Memberships { get; set; } = new();
    public virtual List<SquadVote> SquadVotes { get; set; } = new();
    public virtual List<QuestVote> QuestVotes { get; set; } = new();


}


