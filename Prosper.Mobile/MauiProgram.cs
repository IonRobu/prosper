using Microsoft.Extensions.Logging;
using Prosper.MVVM.Models;
using ProsperDaily.Repositories;
using Syncfusion.Maui.Core.Hosting;
using Transaction = Prosper.MVVM.Models.Transaction;

namespace Prosper;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureSyncfusionCore()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				fonts.AddFont("LibreFranklin-Regular.ttf", "Regular");
				fonts.AddFont("Roboto-Black.ttf", "Strong");
			});
		builder.Services.AddSingleton<BaseRepository<Transaction>>();
		builder.Services.AddSingleton<BaseRepository<TransactionCategory>>();
		builder.Services.AddSingleton<BaseRepository<Account>>();
		builder.Services.AddSingleton<BaseRepository<Card>>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}

	internal static void Run(MauiApp app)
	{
		throw new NotImplementedException();
	}
}

