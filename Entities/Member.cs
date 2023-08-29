namespace servartur.Models;
public class Member
{
    public int Id { get; set; }
    public string Nick { get; set; }
    public bool SecretVote { get; set; }

    public int PlayerId { get; set; }
    public virtual Player Player { get; set; }
}

