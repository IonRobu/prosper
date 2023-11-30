using BlazorDownloadFile;
using Methodic.Blazor.UI.Configuration;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;
using Toolbelt.Blazor.I18nText.Interfaces;
using WebApp.UI;
using WebApp.UI.Configuration;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services
	.AddSingleton(x => new HttpClient
	{
		BaseAddress = new Uri(builder.HostEnvironment.BaseAddress),
		Timeout = TimeSpan.FromSeconds(3600)
	});
builder.Services.AddMxClient();

builder.Services.AddAdminConfigurator();

builder.Services.AddTelerikBlazor();
builder.Services.DisableTrialForTelerik();
builder.Services.AddBlazorDownloadFile();

builder.Services
	.AddScoped<EnumData>();

builder.Logging.AddConfiguration(
	builder.Configuration.GetSection("Logging")
);

//Constants.BackendUrl = builder.Configuration.GetSection("Services")["BackendUrl"];
//Constants.Version = builder.Configuration.GetValue<string>("Version");
//HttpServiceBase.SetBackEndUrl(Constants.BackendUrl);

var host = builder.Build();

ConsoleEx.Init(host.Services.GetService<IJSRuntime>());

await host.Services
		.GetRequiredService<Navigation>()
		.ConfigureAsync();

var appSettings = host.Services
		.GetRequiredService<AppSettings>()
		.Configure();

var navigation = host.Services
		.GetRequiredService<Navigation>();

await host.RunAsync();
