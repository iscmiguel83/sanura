using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Sanura.Movil.Clients;
using Sanura.Movil.Interfaces.Clients;
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
		builder.Services.AddSingleton<IClientSyncService, ClientSyncService>();
		return builder;
	}

	public static MauiAppBuilder RegisterServices(this MauiAppBuilder builder)
	{
		return builder;
	}

	public static MauiAppBuilder RegisterViews(this MauiAppBuilder builder)
	{
		builder.Services.AddSingleton<BillingView>();
		builder.Services.AddSingleton<HomeView>();
		builder.Services.AddSingleton<RegisterCashView>();
		builder.Services.AddSingleton<SyncView>();

		builder.Services.AddTransient<BillingCustomerView>();
		builder.Services.AddTransient<SettingsView>();

		return builder;
	}

	public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder builder)
	{
		builder.Services.AddSingleton<IBillingViewModel, BillingViewModel>();
		builder.Services.AddSingleton<IHomeViewModel, HomeViewModel>();
		builder.Services.AddSingleton<IRegisterCashViewModel, RegisterCashViewModel>();
		builder.Services.AddSingleton<ISyncViewModel, SyncViewModel>();

		builder.Services.AddTransient<IBillingCustomerViewModel, BillingCustomerViewModel>();
		builder.Services.AddTransient<ISettingsViewModel, SettingsViewModel>();

        return builder;
	}
}
