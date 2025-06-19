using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Sanura.Movil.Interfaces.ViewModels;
using Sanura.Movil.ViewModels;
using Sanura.Movil.Views;

namespace Sanura.Movil;

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
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			})
			.RegisterViews()
			.RegisterViewModels()
			.RegisterClients()
			.RegisterServices();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}

	public static MauiAppBuilder RegisterClients(this MauiAppBuilder builder)
	{
		return builder;
	}

	public static MauiAppBuilder RegisterServices(this MauiAppBuilder builder)
	{
		return builder;
	}

	public static MauiAppBuilder RegisterViews(this MauiAppBuilder builder)
	{
		builder.Services.AddSingleton<HomeView>();

		return builder;
	}

	public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder builder)
	{
		builder.Services.AddSingleton<IHomeViewModel, HomeViewModel>();

        return builder;
	}
}
