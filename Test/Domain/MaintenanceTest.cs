using Domain.Configuration;
using Domain.Models;
using FluentAssertions;
using Microsoft.Extensions.Configuration;

namespace Test.Domain
{
    public class MaintenanceTest
    {
        private MaintenanceImp _maintenance;
        private IConfiguration _configuration;
        private Alert _parameters;

        public MaintenanceTest()
        {
            _maintenance = new MaintenanceImp();
            _configuration = InitConfiguration();
            _parameters = _configuration.GetSection("Parameters").Get<Alert>();
        }

        [Fact]
        public void GetNextMaintenanceDate_Should_Be_Success()
        {
            var lastMaintenanceDate = DateTime.Today.AddDays(15);

            var result = _maintenance.GetNextMaintenanceDate(_parameters.FirstAlert);

            result.Should().Be(lastMaintenanceDate);
        }

        [Fact]
        public void GetNextMaintenanceDate_Should_Be_Fail()
        {
            var lastMaintenanceDate = DateTime.Today.AddDays(10);

            var result = _maintenance.GetNextMaintenanceDate(_parameters.FirstAlert);

            result.Should().NotBe(lastMaintenanceDate);
        }

        public static IConfiguration InitConfiguration()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.Test.json")
                .Build();

            return configuration;
        }
    }
}
