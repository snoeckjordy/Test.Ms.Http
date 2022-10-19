using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Test.Ms.Http.Application.Common.Interfaces;
using Test.Ms.Http.Application.Order;

namespace Test.Ms.Http.Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IOrderService, OrderService>();
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
