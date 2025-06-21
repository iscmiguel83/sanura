using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Sanura.Movil.Interfaces.ViewModels;
using Sanura.Movil.Models;

namespace Sanura.Movil.ViewModels;

public partial class SettingsViewModel : ObservableObject, ISettingsViewModel
{
    [ObservableProperty]
    private string idSeller = string.Empty;

    [RelayCommand]
    private void LoadData()
    {
        this.IdSeller = Preferences.Get(Constants.IdSeller, string.Empty);
    }

    partial void OnIdSellerChanged(string value)
    {
        Preferences.Set(Constants.IdSeller, value);
    }
}
