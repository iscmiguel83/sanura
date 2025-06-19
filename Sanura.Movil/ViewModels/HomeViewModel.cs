using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Sanura.Movil.Interfaces.ViewModels;

namespace Sanura.Movil.ViewModels;

public partial class HomeViewModel : ObservableObject, IHomeViewModel
{
    [RelayCommand]
    private async Task Billing()
    {

    }

    [RelayCommand]
    private async Task RegisterCashDeposit()
    {

    }

    [RelayCommand]
    private async Task Sync()
    {

    }

    [RelayCommand]
    private async Task Logout()
    {

    }
}
