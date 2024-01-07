namespace servartur.Models;

public class RoomDto
{
    public int RoomId { get; set; }
    public string Status { get; set; } = null!;

    public List<PlayerDto> Players { get; set; } = null!;

}
