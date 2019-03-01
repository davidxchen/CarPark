using CarPark.WebServer.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;

namespace CarPark.WebServer.Tests.TestFixtures
{
    public class ControllerTestFixture : IDisposable
    {
        public ValuesController ValuesController;

        public ControllerTestFixture()
        {
            //  Setting up the stuff required for Configuration.GetConnectionString("DefaultConnection")
            Mock<IConfigurationSection> configurationSectionStub = new Mock<IConfigurationSection>();
            configurationSectionStub.Setup(x => x["DefaultConnection"]).Returns("TestConnectionString");

            Mock<IConfiguration> configurationStub = new Mock<IConfiguration>();
            configurationStub.Setup(x => x.GetSection("ConnectionStrings")).Returns(configurationSectionStub.Object);

            IServiceCollection services = new ServiceCollection();
            var target = new Startup(configurationStub.Object);

            //  Act
            target.ConfigureServices(services);
            //  Mimic internal asp.net core logic.
            services.AddTransient<ValuesController>();

            //  Assert

            var serviceProvider = services.BuildServiceProvider();

            ValuesController = serviceProvider.GetService<ValuesController>();
        }

        public void Dispose()
        {
            ValuesController = null;
        }
    }
}
