using CarPark.Services.Tests.TestFixtures;
using FluentAssertions;
using System;
using Xunit;

namespace CarPark.Services.Tests
{
    public class TollGateTest : IClassFixture<ServiceTestFixture>
    {
        ServiceTestFixture _fixture;

        public TollGateTest(ServiceTestFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void Has_Available_Lots()
        {
            var info = _fixture.CarParkService.GetCarParkInformation(Guid.NewGuid()).Result;

            _fixture.CarParkService.HasAvailableLots(info.CarParkId).Should().Be(true);
        }

        [Theory]
        [InlineData("X001-34")]
        public void Car_Can_Park(string car_plate_no)
        {
            var info = _fixture.CarParkService.GetCarParkInformation(Guid.NewGuid()).Result;

            _fixture.TollGateService.Enter(car_plate_no).Should().Be(true);
        }
    }
}
