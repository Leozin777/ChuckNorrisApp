using ChuckNorrisApp.Services;
using ChuckNorrisApp.Services.Interfaces;
using ChuckNorrisApp.View;
using ChuckNorrisApp.ViewModel;
using Microsoft.Extensions.Logging;

namespace ChuckNorrisApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddScoped<IServiceGeral, ServiceGeral>();
        builder.Services.AddScoped(sp => new HttpClient());
        builder.Services.AddTransient<JokesChuckView>();
		builder.Services.AddTransient<MainPage>();
		builder.Services.AddTransient<AboutView>();
		builder.Services.AddTransient<AppShell>();
		builder.Services.AddScoped<JokesChuckViewModel>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
