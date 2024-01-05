using System.ComponentModel.DataAnnotations;

namespace servartur.Models;

public class CreatePlayerDto
{
    //public int UserFid { get; set; }

    [Required]
    [StringLength(20, MinimumLength = 3)]
    public string Nick { get; set; } = null!;
    [Required]
    public int RoomId { get; set; }
}
