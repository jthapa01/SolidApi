using MySpot.Core.Exceptions;
using MySpot.Core.ValueObjects;

namespace MySpot.Application.Exceptions;

public class InvalidCredentialsException : CustomException
{
    public InvalidCredentialsException() : base($"Invalid Credentials.")
    {
    }
}