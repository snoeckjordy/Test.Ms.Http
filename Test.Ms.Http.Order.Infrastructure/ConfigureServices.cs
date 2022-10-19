using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Test.Ms.Http.Application.Common.Interfaces;
using Test.Ms.Http.Order.Infrastructure.Persistence;

namespace Test.Ms.Http.Order.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastrucure(this IServiceCollection services)
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            services.AddDbContext<OrderDbContext>(options =>
            {
                options.UseSqlite(connection);
            });

            services.AddScoped<IOrderDbContext>(collection => collection.GetRequiredService<OrderDbContext>());

            services.BuildServiceProvider();

            return services;
        }
    }
}
