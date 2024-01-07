using System.Runtime.Serialization;

namespace servartur.Enums;

public enum RoomStatus
{
    [EnumMember(Value = "Unknown")]
    Unknown,

    [EnumMember(Value = "Matchup")]
    Matchup,

    [EnumMember(Value = "Playing")]
    Playing,

    [EnumMember(Value = "Assassination")]
    Assassination,

    [EnumMember(Value = "Result")]
    Result,
}
