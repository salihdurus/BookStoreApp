using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.EFCore;
using Services;
using Services.Contracts;

namespace WebApi.Extensions
{
    public static class ServicesExtensions
    {
        public static void ConfigureSQLContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RepositoryContext>(options =>
    options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
);
        }

        public static void ConfigureRepositoryManager(this IServiceCollection services) => services.AddScoped<IRepositoryManager, RepositoryManager>();
        public static void ConfigureServiceManager(this IServiceCollection services) => services.AddScoped<IServiceManager, ServiceManager>();
        public static void ConfigureLoggerService(this IServiceCollection services) => services.AddSingleton<ILoggerService, LoggerManager>();
    }
}
