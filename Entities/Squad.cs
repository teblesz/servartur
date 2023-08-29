namespace servartur.Models;
public class Squad
{
    public int Id { get; set; }
    public int QuestNumber { get; set; }
    public bool IsSubmitted { get; set; }
    public bool IsApproved { get; set; }
    public bool IsSuccessfull { get; set; }
    //public Dictionary<string, bool> Votes { get; set; }
}


