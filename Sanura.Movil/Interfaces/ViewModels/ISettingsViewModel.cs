using CommunityToolkit.Mvvm.Input;

namespace Sanura.Movil.Interfaces.ViewModels;

public interface ISettingsViewModel
{
    string IdSeller
    {
        get;
        set;
    }

    string Url
    {
        get;
        set;
    }

    IRelayCommand LoadDataCommand
    {
        get;
    }
}
