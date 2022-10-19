using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Test.Ms.Http.Product.Application.Common.Interfaces;
using Test.Ms.Http.Product.Infrastructure.Persistence;

namespace Test.Ms.Http.Product.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastrucure(this IServiceCollection services)
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            services.AddDbContext<ProductDbContext>(options =>
            {
                options.UseSqlite(connection);
            });


            services.AddScoped<IProductDbContext>(collection => collection.GetRequiredService<ProductDbContext>());

            services.BuildServiceProvider();

            return services;
        }
    }
}
