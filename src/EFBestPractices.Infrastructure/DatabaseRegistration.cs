using EFBestPractices.Domain;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace EFBestPractices.Infrastructure.ServiceRegistration
{
    public static class DatabaseRegistration
    {
        public static IServiceCollection AddDatabaseInfrastructure(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<EFBestPracticesDbContext>(options =>
            {
                options.UseSqlServer(connectionString, sqlOptions =>
                {
                    sqlOptions.MigrationsAssembly(typeof(DatabaseRegistration).Assembly.FullName);
                });
            });

            return services;
        }
    }
}