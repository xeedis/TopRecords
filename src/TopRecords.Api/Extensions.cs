using Microsoft.OpenApi.Models;
using TopRecords.Api.Abstractions;
using TopRecords.Api.Clients;
using TopRecords.Api.DTO;
using TopRecords.Api.Helpers;
using TopRecords.Api.Middleware;
using TopRecords.Api.Queries;
using TopRecords.Api.Queries.Handlers;

namespace TopRecords.Api;

public static class Extensions
{
    
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<AppOptions>(configuration.GetSection(AppOptions.SectionName));

        services.AddSingleton<ExceptionMiddleware>();
        services.AddHttpClient(W3SchoolEndpoints.ClientName);
        services.AddScoped<IQueryHandler<GetCatalogQuery, CatalogDto>, GetCatalogsHandler>();
        services.AddHttpClient<IW3SchoolClient, W3SchoolClient>();
        services.AddSwaggerGen(swagger =>
        {
            swagger.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "TopRecords API",
                Version = "v1"
            });
        });

        return services;
    }
    public static T GetOptions<T>(this IConfiguration configuration, string sectionName) where T : class, new()
    {
        var options = new T();
        var section = configuration.GetSection(sectionName);
        section.Bind(options);

        return options;
    }
}