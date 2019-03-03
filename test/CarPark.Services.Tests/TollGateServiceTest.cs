using CarPark.Services.Extensions;
using CarPark.Services.Tests.TestFixtures;
using FluentAssertions;
using System;
using Xunit;

namespace CarPark.Services.Tests
{
    public class TollGateServiceTest : IClassFixture<ServiceTestFixture>
    {
        private readonly ServiceTestFixture _fixture;

        public TollGateServiceTest(ServiceTestFixture fixture)
        {
            _fixture = fixture;
        }

        [Theory]
        [InlineData("487407A8-5C59-4E86-9D91-80CC65AAD5A4")]
        public void Has_Available_Lots(Guid parkId)
        {
            var available = _fixture.CarParkService.HasAvailableLots(parkId).Result;
            
            available.Should().Be(true);
        }

        [Theory]
        [InlineData("487407A8-5C59-4E86-9D91-80CC65AAD5A4", "X001-34")]
        public void Car_Can_Park(Guid parkId, string car_plate_no)
        {
            var info = _fixture.CarParkService.GetCarParkInformation(parkId).Result;
            var entryResult = _fixture.TollGateService.Enter(car_plate_no).Result;
            
            entryResult.Should().Be(true);
        }

        [Theory]
        [InlineData("487407A8-5C59-4E86-9D91-80CC65AAD5A4", "X001-34")]
        public void Car_Can_Leave(Guid parkId, string car_plate_no)
        {
            var info = _fixture.CarParkService.GetCarParkInformation(parkId).Result;
            var entryResult = _fixture.TollGateService.Leave(car_plate_no).Result;
            
            entryResult.Should().Be(true);
        }
    }
}
