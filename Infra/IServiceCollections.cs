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

        public static IServiceCollection AddServicesAPI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDomain()
                    .AddApplication()
                    .AddDapperRepository(configuration)
                    .AddDbContext(configuration);

            return services;
        }

        public static IServiceCollection AddServicesJob(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddParameters(configuration)
                    .AddDomain()
                    .AddApplication()
                    .AddDapperRepository(configuration)
                    .AddDbContext(configuration);

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
            services.AddScoped<EmailService, EmailServiceImp>();
            services.AddScoped<MaintenanceService, MaintenanceServiceImp>();

            return services;
        }

        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            services.AddScoped<Email, EmailImp>();
            services.AddScoped<Maintenance, MaintenanceImp>();

            return services;
        }

        public static IServiceCollection AddDapperRepository(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = GetDbConnectionString(configuration);

            services.AddScoped<MaintenanceRepository>(r => new MaintenanceRepositoryImp(connection))
                    .AddScoped<EmailRepository>(r => new EmailRepositoryImp(connection));

            return services;
        }

        public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = GetDbConnectionString(configuration);

            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(connection);
            });

            services.AddScoped<BaseContext, BaseContextImp>();

            return services;
        }

        private static string GetDbConnectionString(IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString(CONNECTION_STRING) ?? string.Empty;

            return connectionString;
        }
    }
}
