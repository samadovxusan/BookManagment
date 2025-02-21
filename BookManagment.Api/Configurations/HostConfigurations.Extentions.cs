using System.Reflection;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Configurations;

public static partial class HostConfigurations
{
    private static readonly ICollection<Assembly> Assemblies;

    static HostConfigurations()
    {
        Assemblies = Assembly.GetExecutingAssembly().GetReferencedAssemblies().Select(Assembly.Load).ToList();
        Assemblies.Add(Assembly.GetExecutingAssembly());
    }

    private static WebApplicationBuilder AddDevTools(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        return builder;
    }


    private static WebApplicationBuilder AddExposers(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<ApiBehaviorOptions>(
            options => { options.SuppressModelStateInvalidFilter = true; }
        );
        builder.Services.AddRouting(options => options.LowercaseUrls = true);
        builder.Services.AddControllers();

        return builder;
    }


    private static WebApplication UseDevTools(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();

        return app;
    }

    private static WebApplication UseExposers(this WebApplication app)
    {
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();

        return app;
    }
}