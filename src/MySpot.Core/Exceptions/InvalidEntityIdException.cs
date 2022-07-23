namespace MySpot.Core.Exceptions;

public sealed class InvalidEntityIdException : CustomException
{
    public InvalidEntityIdException(object id) : base($"Cannot set: {id} as entity identifier.") 
        => Id = id;
    public object Id { get; }
}