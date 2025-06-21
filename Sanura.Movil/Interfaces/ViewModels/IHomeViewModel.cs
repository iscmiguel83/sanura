using CommunityToolkit.Mvvm.Input;

namespace Sanura.Movil.Interfaces.ViewModels;

public interface IHomeViewModel
{
    IAsyncRelayCommand BillingCommand
    {
        get;
    }

    IAsyncRelayCommand RegisterCashDepositCommand
    {
        get;
    }

    IAsyncRelayCommand SyncCommand
    {
        get;
    }

    IAsyncRelayCommand LogoutCommand
    {
        get;
    }

    IAsyncRelayCommand SettingsCommand
    {
        get;
    }
}
