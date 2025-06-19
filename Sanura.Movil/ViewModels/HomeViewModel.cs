using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Sanura.Movil.Interfaces.ViewModels;

namespace Sanura.Movil.ViewModels;

public partial class HomeViewModel : ObservableObject, IHomeViewModel
{
    [RelayCommand]
    private async Task BillingAsync()
    {

    }

    [RelayCommand]
    private async Task RegisterCashDepositAsync()
    {

    }

    [RelayCommand]
    private async Task SyncAsync()
    {

    }

    [RelayCommand]
    private async Task LogoutAsync()
    {

    }
}
