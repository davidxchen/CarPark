using CarPark.Services.Interfaces;
using CarPark.Services.Models;
using CarPark.Services.Services;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;

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
            
            //  Mimic internal asp.net core logic.
            services.AddTransient<ICarParkService, CarParkService>();
            services.AddTransient<ITollGateService, TollGateService>();

            //  Assert
            var serviceProvider = services.BuildServiceProvider();

            CarParkService = serviceProvider.GetService<ICarParkService>();
            TollGateService = serviceProvider.GetService<ITollGateService>();
        }

        public void Dispose()
        {
            CarParkService.Dispose();
            TollGateService.Dispose();

            carParkInfo = null;
        }
    }
}
