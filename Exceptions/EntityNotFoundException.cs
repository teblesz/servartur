namespace servartur.Exceptions;

public class EntityNotFoundException : Exception
{
    public EntityNotFoundException(string entityName, int entityId)
        : base($"{entityName} with ID {entityId} does not exist.") { }
}
public class RoomNotFoundException : EntityNotFoundException
{
    public RoomNotFoundException(int roomId)
        : base("Room", roomId) { }
}

public class PlayerNotFoundException : EntityNotFoundException
{
    public PlayerNotFoundException(int playerId)
        : base("Player", playerId) { }
}