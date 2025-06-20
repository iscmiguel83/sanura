using CommunityToolkit.Mvvm.Input;

namespace Sanura.Movil.Interfaces.ViewModels;

public interface ISyncViewModel
{
    IAsyncRelayCommand DownloadCommand
    {
        get;
    }

    IAsyncRelayCommand UploadCommand
    {
        get;
    }
}
