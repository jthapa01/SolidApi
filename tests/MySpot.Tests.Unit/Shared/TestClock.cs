using MySpot.Application.Services;
using MySpot.Core.Abstractions;

namespace MySpot.Tests.Unit.Shared;

internal sealed class TestClock : IClock
{
    public DateTime Current() => new DateTime(2022, 06, 20);
}