using Microsoft.Extensions.DependencyInjection;
using Application.Authentication.Implementation;
using Application.Authentication.Interfaces;
using Application.Utilization.Implementation;
using Application.Utilization.Interfaces;

namespace Application
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            return services;

        }
    }
}
