using servartur.Enums;

namespace servartur.Entities;
public class Squad
{
    public Squad()
    {
        Status = SquadStatus.Unknown;
    }
    public int SquadId { get; set; }
    public int QuestNumber { get; set; }
    public int RoundNumber { get; set; }
    public int RequiredPlayersNumber { get; set; }
    public SquadStatus Status { get; set; }

    public int LeaderId { get; set; }
    public virtual Player Leader { get; set; } = null!;

    public int RoomId { get; set; } // Required foreign key property

    public virtual List<Membership> Memberships { get; set; } = [];
    public virtual List<SquadVote> SquadVotes { get; set; } = [];
    public virtual List<QuestVote> QuestVotes { get; set; } = [];


}


