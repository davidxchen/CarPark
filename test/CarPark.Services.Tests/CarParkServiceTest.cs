using CarPark.Services.Extensions;
using CarPark.Services.Tests.TestFixtures;
using FluentAssertions;
using System;
using Xunit;

namespace CarPark.Services.Tests
{
    public class CarParkServiceTest : IClassFixture<ServiceTestFixture>
    {
        private readonly ServiceTestFixture _fixture;

        public CarParkServiceTest(ServiceTestFixture fixture)
        {
            _fixture = fixture ?? throw new ArgumentNullException(nameof(fixture));
        }

        [Theory]
        [InlineData(150)]
        public void Can_Create_new_CarPark(int capacity)
        {
            var new_park = _fixture.CarParkService.BuildCarPark(capacity).Result;
            
            new_park.Should().NotBeEmpty();
        }

        [Theory]
        [InlineData("487407A8-5C59-4E86-9D91-80CC65AAD5A4")]
        public void Has_Existing_Park(Guid parkId)
        {
            var existing = _fixture.CarParkService.GetCarParkInformation(parkId).Result;

            existing.Should().NotBeNull();
            existing.Capacity.Should().BeInRange(100, 300);
        }

        [Theory]
        [InlineData("487407A8-5C59-4E86-9D91-80CC65AAD5A4")]
        public void Has_Available_Capacity_set(Guid parkId)
        {
            var capacity = _fixture.CarParkService.GetCapacity(parkId).Result;

            capacity.Should().BeInRange(100, 300);
        }

        [Theory]
        [InlineData("487407A8-5C59-4E86-9D91-80CC65AAD5A4")]
        public void Can_Output_Json_String(Guid parkId)
        {
            var carpark = _fixture.CarParkService.GetCarParkInformation(parkId).Result;

            carpark.ToJsonString().Should().NotBeNullOrEmpty();
        }
    }
}
