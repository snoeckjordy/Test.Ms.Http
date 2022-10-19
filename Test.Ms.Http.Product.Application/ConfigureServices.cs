using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Test.Ms.Http.Product.Application.Common.Interfaces;
using Test.Ms.Http.Product.Application.Product;

namespace Test.Ms.Http.Product.Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        { 
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
