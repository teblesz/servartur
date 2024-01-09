namespace servartur.Exceptions;

public class BadRequestException : Exception
{
    public BadRequestException(string message) 
        : base(message) { }
}
public class RoomNotInMatchupException : BadRequestException
{
    /// <param name="roomId">Id of the room that is not in matchup state.</param>
    public RoomNotInMatchupException(int roomId)
        : base($"Room with id {roomId} is not in matchup and cannot be joined") { }
}
public class RoomIsFullException : BadRequestException
{
    /// <param name="roomId">Id of the room that is full.</param>
    public RoomIsFullException(int roomId)
        : base($"Room with id {roomId} is full and cannot be joined") { }
}