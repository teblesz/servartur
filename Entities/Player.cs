namespace servartur.Models;
public class Player
{
    public int Id { get; set; }
    public string Nick { get; set; }
    public bool IsLeader { get; set; }
    public string Character { get; set; }
    public string SpecialCharacter { get; set; }
    public int UserId { get; set; }
}

