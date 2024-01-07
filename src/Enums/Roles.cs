using System.Runtime.Serialization;

namespace servartur.Enums;

public enum Team
{
    [EnumMember(Value = "Evil")]
    Evil,

    [EnumMember(Value = "Good")]
    Good,
}
public enum Role
{
    [EnumMember(Value = "Merlin")]
    Merlin,

    [EnumMember(Value = "Assassin")]
    Assassin,

    [EnumMember(Value = "Percival")]
    Percival,

    [EnumMember(Value = "Morgana")]
    Morgana,

    [EnumMember(Value = "Mordred")]
    Mordred,

    [EnumMember(Value = "Oberon")]
    Oberon,
}
public static class RoleMapping
{
    public static readonly Dictionary<Role, Team> Map = new()
    {
        { Role.Merlin, Team.Good },
        { Role.Assassin, Team.Evil },

        { Role.Percival, Team.Good },
        { Role.Morgana, Team.Evil },

        { Role.Mordred, Team.Evil },
        { Role.Oberon, Team.Evil },
    };
}