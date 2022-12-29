using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using WordleSolver.Data;
using WordleSolver.Data.Wordle;
using WordleSolver.Services.DbService;
using WordleSolver.Services.DbServices;

namespace WordleSolver;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		builder.Services.AddMauiBlazorWebView();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

		builder.Services.AddSingleton<WeatherForecastService>();
		string dbPath = DbCheckService.Start(DbCheckService.nameDB);
		builder.Services.AddSingleton<WordRepository>(s => ActivatorUtilities.CreateInstance<WordRepository>(s, dbPath));
		builder.Services.AddSingleton<Board>();

		return builder.Build();
	}
}
