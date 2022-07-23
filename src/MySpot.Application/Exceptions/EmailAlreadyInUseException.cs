using MySpot.Core.Exceptions;

namespace MySpot.Application.Exceptions;

public sealed class EmailAlreadyInUseException : CustomException
{
    private readonly string _email;

    public EmailAlreadyInUseException(string email) : base($"Email: '{email}' already in use.")
    {
        _email = email;
    }
}