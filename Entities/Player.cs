using System.ComponentModel.DataAnnotations;

namespace servartur.Entities;
public class Player
{
    public int PlayerId { get; set; }
    //public int UserFid { get; set; }
    [StringLength(maximumLength: 20, MinimumLength = 3)]
    public string Nick { get; set; }
    public string Team { get; set; }
    public string Role { get; set; }

    public int RoomId { get; set; } // Required foreign key property

    public virtual List<Membership> Memberships { get; set; } = new();
    public virtual List<SquadVote> SquadVotes { get; set; } = new();
    public virtual List<QuestVote> QuestVotes { get; set; } = new();
}

