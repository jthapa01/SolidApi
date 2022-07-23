using System.Runtime.CompilerServices;
using MySpot.Application.Commands;
using MySpot.Application.Services;
using MySpot.Core.Abstractions;
using MySpot.Core.Repositories;
using MySpot.Infrastructure.DAL.Repositories;
using MySpot.Tests.Unit.Shared;
using Shouldly;
using Xunit;

namespace MySpot.Tests.Unit.Services;

public class ReservationsServiceTests
{
    [Fact]
    public async Task given_valid_command_create_should_add_reservation()
    {
        //ARRANGE
        var command = new ReserveParkingSpotForVehicle(Guid.Parse("00000000-0000-0000-0000-000000000001"),
            Guid.NewGuid(), "Joe Doe", "XYZ123", DateTime.UtcNow.AddDays(1));
        
        //ACT
        var reservationId =  await _reservationsService.ReserveForVehicleAsync(command);
        
        //ASSERT
        reservationId.ShouldNotBeNull();
        reservationId.Value.ShouldBe(command.ReservationId);
    }
    
    [Fact]
    public async Task given_invalid_parking_spot_id_create_should_fail()
    {
        //ARRANGE
        var command = new ReserveParkingSpotForVehicle(Guid.Parse("00000000-0000-0000-0000-000000000011"),
            Guid.NewGuid(), "Joe Doe", "XYZ123", DateTime.UtcNow.AddDays(1));
        
        //ACT
        var reservationId = await _reservationsService.ReserveForVehicleAsync(command);
        
        //ASSERT
        reservationId.ShouldBeNull();
    }
    
    [Fact]
    public async Task given_reservation_for_already_taken_date_create_should_fail()
    {
        //ARRANGE
        var command = new ReserveParkingSpotForVehicle(Guid.Parse("00000000-0000-0000-0000-000000000001"),
            Guid.NewGuid(), "Joe Doe", "XYZ123", DateTime.UtcNow.AddDays(1));
        await _reservationsService.ReserveForVehicleAsync(command);
        
        //ACT
        var reservationId = await _reservationsService.ReserveForVehicleAsync(command);
        
        //ASSERT
        reservationId.ShouldBeNull();
    }

    #region ARRANGE

    private readonly IClock _clock;
    private readonly IWeeklyParkingSpotRepository _weeklyParkingSpotRepository;
    private readonly ReservationsService _reservationsService;
    public ReservationsServiceTests()
    {
        _clock = new TestClock();
        _weeklyParkingSpotRepository = new InMemoryWeeklyParkingSpotRepository(_clock);
        _reservationsService = new ReservationsService(_clock, _weeklyParkingSpotRepository);
    }

    #endregion
}