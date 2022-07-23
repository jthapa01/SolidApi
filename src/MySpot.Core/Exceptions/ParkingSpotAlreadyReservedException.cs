namespace MySpot.Core.Exceptions;

public sealed class ParkingSpotAlreadyReservedException : CustomException
{
    public ParkingSpotAlreadyReservedException(string parkingSpotName, DateTime date) 
        : base($"Parking spot with name {parkingSpotName} is already reserved for date: {date}")
    {
        ParkingSpotName = parkingSpotName;
        Date = date;
    }

    public string ParkingSpotName { get;}
    public DateTime Date { get; }
}