using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Points.Application.Interfaces;
using Points.Infrastructure.Persistance;
using Points.Infrastructure.Services;

namespace Points.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(opt =>
                opt.UseInMemoryDatabase(databaseName: "DotBase"));

            services.AddTransient<IDotRepository, DotRepository>();
            return services;
        }

    }
}