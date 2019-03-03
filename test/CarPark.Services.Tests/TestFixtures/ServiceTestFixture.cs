using CarPark.Services.Interfaces;
using CarPark.Services.Models;
using CarPark.Services.Services;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using Xunit;

namespace CarPark.Services.Tests.TestFixtures
{
    public class ServiceTestFixture : IDisposable
    {
        public ICarParkService CarParkService;
        public ITollGateService TollGateService;
        public Mock<CarParkInformation> carParkInfo;

        public ServiceTestFixture()
        {
            IServiceCollection services = new ServiceCollection();
            
            services.AddMemoryCache();

            //  Mimic internal asp.net core logic.
            services.AddTransient<ICarParkService, CarParkService>();
            services.AddTransient<ITollGateService, TollGateService>();

            //  Assert
            var serviceProvider = services.BuildServiceProvider();

            CarParkService = serviceProvider.GetService<ICarParkService>();
            TollGateService = serviceProvider.GetService<ITollGateService>();
        }
        
        [Fact]
        public void should_all_services_not_be_null()
        {
            CarParkService.Should().NotBeNull();
            TollGateService.Should().NotBeNull();
        }

        public void Dispose()
        {
            //CarParkService.Dispose();
            //TollGateService.Dispose();

            carParkInfo = null;
        }
    }
}
