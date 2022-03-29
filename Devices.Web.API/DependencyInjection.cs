using Devices.Web.API.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace Devices.Web.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<DevicesDBContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DevicesDB")), ServiceLifetime.Transient);

            return services;
        }
    }
}