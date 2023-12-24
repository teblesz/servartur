﻿namespace servartur.Entities;

public class QuestVote
{
    public int QuestVoteId { get; set; }
    public bool Value { get; set; }
    public int SquadId { get; set; }
    public virtual Squad Squad { get; set; }
    public int PlayerId { get; set; }
    public virtual Player Player { get; set; }
}
