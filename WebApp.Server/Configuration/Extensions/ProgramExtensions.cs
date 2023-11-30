using NLog.Web;
using System.Text.Json.Serialization;

namespace WebApi.Backend.Configuration.Extensions;

public static class ProgramExtensions
{
    public static WebApplication RunApplication(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddControllersWithViews()
            .AddJsonOptions(x =>
            {
                x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault;
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });

        builder.Services.AddRazorPages();
        builder.Services.AddSignalR();
        //builder.Services.AddDefaultConfiguration();
		builder.Services.AddHttpClient();

		builder.Logging.ClearProviders();
        builder.Host.UseNLog();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
        }
        //app.Services.ConfigureDefault();

		app.UseBlazorFrameworkFiles();
		app.UseStaticFiles();
        app.UseRouting();
        app.MapControllers();
        //app.MapHub<NotificationHub>("/api/notificationhub");
        app.MapFallbackToFile("index.html");

        app.Run();

        return app;
    }
}