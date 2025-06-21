using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Sanura.Movil.Interfaces.Clients;
using Sanura.Movil.Interfaces.ViewModels;
using Sanura.Movil.Models;
using Sanura.Movil.Utils;

namespace Sanura.Movil.ViewModels;

public partial class SyncViewModel : ObservableObject, ISyncViewModel
{
    private readonly IClientSyncService clientSyncService;
    private readonly string filePath;
    public SyncViewModel(IClientSyncService clientSyncService)
    {
        this.clientSyncService = clientSyncService;
        this.filePath = Path.Combine(FileSystem.AppDataDirectory, Constants.FileName);
    }

    [RelayCommand(CanExecute = nameof(CanDownload))]
    private async Task DownloadAsync()
    {
        if (File.Exists(this.filePath))
        {
            await Notifier.ShowAsync("Advertencia", "Ya tienes actualizada tu base de datos");
            return;
        }

        try
        {
            var idSeller = Preferences.Get(Constants.IdSeller, string.Empty);
            var seller = await this.clientSyncService.DownloadAsync(idSeller);
            await File.WriteAllTextAsync(this.filePath, seller);
            await Notifier.ShowAsync("Aviso", "Sincronizacion finalizada");
        }
        catch (Exception ex)
        {
            await Notifier.ShowAsync("Error", ex.Message);
        }

    }

    [RelayCommand(CanExecute = nameof(CanUpload))]
    private async Task UploadAsync()
    {
        File.Delete(this.filePath);
        return;
    }

    private bool CanDownload()
    {
        var idSeller = Preferences.Get(Constants.IdSeller, string.Empty);

        return !string.IsNullOrWhiteSpace(idSeller);
    }

    private bool CanUpload()
    {
        if (File.Exists(this.filePath))
        {
            return true;
        }

        return false;
    }
}
