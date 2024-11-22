using ToDo.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Diagnostics;
using ToDo.Infrastructure.Data.Interceptors;
using ToDo.Application.Common.Interfaces;
using ToDo.Infrastructure.Specifications;

namespace ToDo.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        string dbName = "ToDoDB";

        services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();

        services.AddDbContext<InMemoryEFCoreContext>((serviceProvider, options) =>
        {
            options.AddInterceptors(serviceProvider.GetServices<ISaveChangesInterceptor>());

            options.UseInMemoryDatabase(dbName);
        });

        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<InMemoryEFCoreContext>());

        services.AddScoped(typeof(ISpecificationEvaluator<>), typeof(SpecificationEvaluator<>));

        return services;
    }
}
