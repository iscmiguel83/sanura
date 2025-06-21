using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Sanura.Movil.Interfaces.ViewModels;
using Sanura.Movil.Models;

namespace Sanura.Movil.ViewModels;

public partial class SettingsViewModel : ObservableObject, ISettingsViewModel
{
    [ObservableProperty]
    private string idSeller = string.Empty;

    [ObservableProperty]
    private string url = string.Empty;

    [RelayCommand]
    private void LoadData()
    {
        this.IdSeller = Preferences.Get(Constants.IdSeller, string.Empty);
        this.Url = Preferences.Get(Constants.Url, "https://192.168.100.215:7142");
    }

    partial void OnIdSellerChanged(string value)
    {
        Preferences.Set(Constants.IdSeller, value);
    }

    partial void OnUrlChanged(string value)
    {
        Preferences.Set(Constants.Url, value);
    }
}
