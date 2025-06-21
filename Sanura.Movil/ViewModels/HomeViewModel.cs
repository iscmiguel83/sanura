using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Sanura.Movil.Interfaces.ViewModels;
using Sanura.Movil.Models;
using Sanura.Movil.Views;

namespace Sanura.Movil.ViewModels;

public partial class HomeViewModel : ObservableObject, IHomeViewModel
{
    public HomeViewModel()
    {
        Routing.RegisterRoute(Constants.Billing, typeof(BillingView));
        Routing.RegisterRoute(Constants.Sync, typeof(SyncView));
        Routing.RegisterRoute(Constants.RegisterCash, typeof(RegisterCashView));
        Routing.RegisterRoute(Constants.Settings, typeof(SettingsView));
    }

    [RelayCommand]
    private async Task BillingAsync()
    {
        await Shell.Current.GoToAsync(Constants.Billing);
    }

    [RelayCommand]
    private async Task RegisterCashDepositAsync()
    {
        await Shell.Current.GoToAsync(Constants.RegisterCash);
    }

    [RelayCommand]
    private async Task SyncAsync()
    {
        await Shell.Current.GoToAsync(Constants.Sync);
    }

    [RelayCommand]
    private async Task LogoutAsync()
    {

    }

    [RelayCommand]
    private async Task SettingsAsync()
    {
        await Shell.Current.GoToAsync(Constants.Settings);
    }

}
