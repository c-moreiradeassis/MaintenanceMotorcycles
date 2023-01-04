using Application.Interface;
using Application.Service;
using Data.Repository.Dapper;
using Data.Repository.Entity;
using Domain.Configuration;
using Domain.Interface;
using Domain.Models;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infra
{
    public static class IServiceCollections
    {
        private const string CONNECTION_STRING = "DefaultConnection";

        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddParameters(configuration)
                    .AddDomain()
                    .AddApplication()
                    .AddDapperRepository(configuration);

            return services;
        }

        public static IServiceCollection AddParameters(this IServiceCollection services, IConfiguration configuration)
        {
            var alert = configuration.GetSection("Parameters:Alert").Get<Alert>();
            var smtp = configuration.GetSection("Parameters:Smtp").Get<Smtp>();

            services.AddSingleton(alert);
            services.AddSingleton(smtp);

            return services;
        }

        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddSingleton<EmailService, EmailServiceImp>();
            services.AddSingleton<MaintenanceService, MaintenanceServiceImp>();

            return services;
        }

        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            services.AddSingleton<Email, EmailImp>();
            services.AddSingleton<Maintenance, MaintenanceImp>();

            return services;
        }

        public static IServiceCollection AddDapperRepository(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = GetDbConnectionString(configuration);

            services.AddSingleton<MaintenanceRepository>(r => new Data.Repository.Dapper.MaintenanceRepositoryImp(connection))
                    .AddSingleton<EmailRepository>(r => new EmailRepositoryImp(connection));

            return services;
        }

        public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString(CONNECTION_STRING));
            });

            return services;
        }

        private static string GetDbConnectionString(IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString(CONNECTION_STRING) ?? string.Empty;

            return connectionString;
        }
    }
}
