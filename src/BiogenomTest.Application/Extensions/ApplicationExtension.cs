using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace BiogenomTest.Application.Extensions;

public static class ApplicationExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(configuration =>
        {
            configuration.Lifetime = ServiceLifetime.Scoped;
            configuration.RegisterServicesFromAssembly(typeof(ApplicationExtension).GetTypeInfo().Assembly);
        });
    }
}