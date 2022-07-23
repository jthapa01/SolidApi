namespace MySpot.Core.Exceptions;

public sealed class InvalidReservationDateException : CustomException
{
    public InvalidReservationDateException(DateTime date) 
        : base($"Reservation date: {date} is invalid.")
    {
        Date = date;
    }

    public DateTime Date { get;}
}