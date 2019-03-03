using CarPark.WebServer.Tests.TestFixtures;
using FluentAssertions;
using Xunit;

namespace CarPark.WebServer.Tests
{
    public class StartupTest : IClassFixture<ControllerTestFixture>
    {
        ControllerTestFixture _fixture;

        public StartupTest(ControllerTestFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void Test_Add()
        {
            _fixture.ValuesController.Should().NotBeNull();
        }
    }
}
