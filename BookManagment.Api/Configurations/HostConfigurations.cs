namespace WebApplication1.Configurations;

public static partial class HostConfigurations
{
    public static ValueTask<WebApplicationBuilder> ConfigureAsync(this WebApplicationBuilder builder)
    {
        builder
            .AddPersistence()
            .AddDevTools()
            .AddExposers();

        return new(builder);
    }

    public static async ValueTask<WebApplication> ConfigureAsync(this WebApplication app)
    {
        app.UseCors();
        app
            .UseDevTools()
            .UseExposers();

        return app;
    }
}